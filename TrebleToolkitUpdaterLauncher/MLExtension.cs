// New versions of Multi-Language may include updated versions of this file.
// The following definition will be used to detect if the file must be updated.
// ML_EXTENSION_VERSION=4

// Multi-Language may add the project MLRuntime to your solution and add a reference
// to MLRuntime to your project. This supports language switching across multiple DLLs.
// In this case it will change "undef" to "define" in the following statement.
#undef USE_PROJECT_MLRUNTIME

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Markup;
using System.Text;
using System.Threading.Tasks;
using System.Resources;
using System.Reflection;
using System.Windows;

namespace MultiLanguageMarkup
{
  [System.Diagnostics.CodeAnalysis.SuppressMessage( "Globalization", "CA1304:Specify CultureInfo", Justification = "We want the localized string." )]
  [System.Diagnostics.CodeAnalysis.SuppressMessage( "Microsoft.Performance", "CA1812", Justification="FXCop doesn't detect usage in XAML !!!" )]
  internal class LangExtension : MarkupExtension
  {
    private class target
    {
      public FrameworkElement     elem ;
      public DependencyObject     depobj ;
      public DependencyProperty   depprop ;
      public bool                 loaded ;
    }


    // This will be updated by Multi-Language
    private static string RootNamespace = "TrebleToolkitUpdaterLauncher";     //MLHIDE

    // We only need one resource manager object.
    // Create it here, because using a static constructor generates warning CA1810.
    private static ResourceManager  ResMgr = new ResourceManager ( RootNamespace + ".Properties.Resources", Assembly.GetExecutingAssembly() ) ;

    // The resource key will be provided as a parameter to the constructor,
    // using markup in the format
    // Text="{m:Lang MyResourceName}"
    private string                  _ResourceKey ;

    // If the markup extension is used in a data template, there may be multiple
    // FrameworkElement objects referring to a single MarkupExtension object.
    // To change the language at runtime, we must keep a list of all of them.
    private List<target>            _Targets ;

    // Class constructor.
    // When you use markup in the format Text="{m:Lang MyResourceName}"
    // the constructor is called with the resource name as a parameter
    public LangExtension ( string resourceKey )
    {
      _ResourceKey = resourceKey ;
      _Targets     = new List<target>() ;

#if USE_PROJECT_MLRUNTIME
      // Hook up to language changed event.
      MLRuntime.MLRuntime.LanguageChanged += ml_UpdateControls ;
#else
      // Hook up to our local language changed event
      MultiLanguageMarkup.LangExtension.LanguageChanged += ml_UpdateControls ;
#endif
    }

    //
    // ProvideValue is an abstract method in the base class MarkupExtension, which we
    // must implement to return the text contained in the resource string.
    //
    // We use this call to store a reference to the property, so that we can update it
    // when the language is changed at runtime. This is not possible in the constructor.
    //
    public override object ProvideValue (IServiceProvider serviceProvider)
    {
      // Save the FrameworkElement and the Property so that we can change the language on the fly.
	  var provider = serviceProvider.GetService(typeof(IProvideValueTarget)) as IProvideValueTarget ;
      if ( provider == null ) return null ;     // For warning VSSDK006
	  var dp       = provider.TargetProperty as DependencyProperty ;

      if ( provider.TargetObject is FrameworkElement )
      {
	    var element  = provider.TargetObject as FrameworkElement ;
		element.Unloaded += Element_Unloaded;
        element.Loaded   += Element_Loaded;
        _Targets.Add ( new target { elem = element, depobj = element, depprop = dp, loaded = false } ) ;
      }
      else if ( provider.TargetObject is FrameworkContentElement )
      {
        // This case is to handle handle System.Windows.Documents.Run, for example as the
        // child of a TextBlock control.
        // System.Windows.Documents.Run derives from FrameworkContentElement but not from FrameworkElement
        var fce = provider.TargetObject as FrameworkContentElement ;
        if ( fce.Parent is FrameworkElement )
        {
	      var element  = fce.Parent as FrameworkElement ;
          element.Unloaded += Element_Unloaded;
          element.Loaded   += Element_Loaded;
          _Targets.Add ( new target { elem = element, depobj = fce, depprop = dp, loaded = false } );
        }
      }
      else if ( provider.TargetObject.GetType().FullName == "System.Windows.SharedDp" )
      {
        // See
        // https://thomaslevesque.com/2009/08/23/wpf-markup-extensions-and-templates/
        //
        // By returning "this", we will be called again.
        // If the markup extension is used in a data template which is instantiated multiple times,
        // there will be a call for each instance. This means that we must build a list of targets.
        //
        return this ;
      }

      // Now get the actual resource.
      return ResMgr.GetString ( _ResourceKey ) ;
    }

    protected virtual void ml_UpdateControls()
    {
      //
      // For a normal element, there will be one item in the list of targets.
      // For an element in a data template, there may be multiple items.
      //
      foreach ( var t in _Targets )
      {
        if ( t.loaded )
        {
          if ( ( t.elem != null ) && ( t.depprop != null ) )
          {
            var resString = ResMgr.GetString ( _ResourceKey ) ;
            t.depobj.SetValue ( t.depprop, resString ) ;
          }
        }
      }
    }

    //
    // If the markup extension is used in a data template, for example in a list box
    // item, the FrameworkElements may be added and deleted dynamically. When a
    // FrameworkElement is removed we should remove it from our list. Otherwise it
    // will prevent garbage collection from cleaning up these items and we might end
    // up trying to change the language on items which have long been deleted.
    //
    // (In simple cases, nothing bad will happen if we do not remove them, but
    // there will probably be some cases where it causes problems.)
    //
    private void Element_Unloaded ( object sender, RoutedEventArgs e )
    {
      var element = sender as FrameworkElement ;
      if ( element != null )
      {
        _Targets.Where ( x => x.elem == element )
                .ToList()
                .ForEach ( x => x.loaded = false ) ;
      }
    }

    private void Element_Loaded ( object sender, RoutedEventArgs e )
    {
      var element = sender as FrameworkElement ;
      if ( element != null )
      {
        foreach ( var x in _Targets )
        {
          if ( ( x.elem == element ) && ( !x.loaded ) )
          {
            x.loaded = true ;
            // There might be a pending language chnge.
            // Specifically if the element is on a TabItem which was hidden during a language change.
            if ( x.depprop != null )
            {
              // Might be inefficient to get multiple times, but this is very unusual anyway.
              var resString = ResMgr.GetString ( _ResourceKey ) ;
              x.depobj.SetValue ( x.depprop, resString ) ;
            }
          }
        }
      }
    }

    public delegate void LanguageChangedDelegate ( );
    public static event LanguageChangedDelegate LanguageChanged;

    public static void BroadcastLanguageChanged ( )
    {
      LanguageChanged?.Invoke ();
    }
  }

  //
  // Attached property Hide.Option
  // -----------------------------
  // The following class allows you do define the attributes
  //   m:Hide.Option="node"
  //   m:Hide.Option="tree"
  // on just about any XAML element.
  //
  // The attribute
  //   m:Hide.Option="none"
  // can be used to undo the operation of the "tree" option on child nodes.
  //
  // Note that the property is NOT defined as a dependency property and that the value is
  // not stored at all. The class has no function at runtime.
  //
  // The GetOption and SetOption specify (unusually) Object rather than DependencyObject.
  // As a result, the options can be applied to XAML nodes which are not DependencyObject,
  // like - for example - setter tags within a style.
  //
  internal enum HideOption
  {
    node,
    tree,
    none
  }

  [System.Diagnostics.CodeAnalysis.SuppressMessage ( "Usage", "CA1801:Review unused parameters", Justification = "The parameters are not used. This dummy class is used to annotate objects in XAML code.") ]
  internal static class Hide
  {
    public static HideOption GetOption ( Object obj )
    {
      return HideOption.node ;
    }

    public static void SetOption ( Object obj, HideOption value )
    {
    }
  }
}

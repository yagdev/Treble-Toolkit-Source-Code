﻿#pragma checksum "..\..\..\UpdateAvailable.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "969A5043683DE3D0B09FE6DADEFDFEC0A01EF3FA4BF55B0839D7A61AABC04929"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using SourceChord.FluentWPF;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;
using TrebleToolkitLauncher;


namespace TrebleToolkitLauncher {
    
    
    /// <summary>
    /// UpdateAvailable
    /// </summary>
    public partial class UpdateAvailable : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 123 "..\..\..\UpdateAvailable.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid GridMain;
        
        #line default
        #line hidden
        
        
        #line 128 "..\..\..\UpdateAvailable.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ProgressBar status_pgr;
        
        #line default
        #line hidden
        
        
        #line 149 "..\..\..\UpdateAvailable.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button No;
        
        #line default
        #line hidden
        
        
        #line 159 "..\..\..\UpdateAvailable.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Yes;
        
        #line default
        #line hidden
        
        
        #line 169 "..\..\..\UpdateAvailable.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label copyright;
        
        #line default
        #line hidden
        
        
        #line 179 "..\..\..\UpdateAvailable.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Changelog;
        
        #line default
        #line hidden
        
        
        #line 199 "..\..\..\UpdateAvailable.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label BootmgTitle;
        
        #line default
        #line hidden
        
        
        #line 209 "..\..\..\UpdateAvailable.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label CurrentVersion;
        
        #line default
        #line hidden
        
        
        #line 229 "..\..\..\UpdateAvailable.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label BootmgTitle_Copy;
        
        #line default
        #line hidden
        
        
        #line 239 "..\..\..\UpdateAvailable.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label NewVersion;
        
        #line default
        #line hidden
        
        
        #line 249 "..\..\..\UpdateAvailable.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Changelog_Copy;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/TrebleToolkitLauncher;component/updateavailable.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\UpdateAvailable.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.GridMain = ((System.Windows.Controls.Grid)(target));
            return;
            case 2:
            this.status_pgr = ((System.Windows.Controls.ProgressBar)(target));
            return;
            case 3:
            this.No = ((System.Windows.Controls.Button)(target));
            
            #line 149 "..\..\..\UpdateAvailable.xaml"
            this.No.Click += new System.Windows.RoutedEventHandler(this.No_btn);
            
            #line default
            #line hidden
            return;
            case 4:
            this.Yes = ((System.Windows.Controls.Button)(target));
            
            #line 159 "..\..\..\UpdateAvailable.xaml"
            this.Yes.Click += new System.Windows.RoutedEventHandler(this.Yes_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.copyright = ((System.Windows.Controls.Label)(target));
            return;
            case 6:
            this.Changelog = ((System.Windows.Controls.Button)(target));
            
            #line 179 "..\..\..\UpdateAvailable.xaml"
            this.Changelog.Click += new System.Windows.RoutedEventHandler(this.Changelogs);
            
            #line default
            #line hidden
            return;
            case 7:
            this.BootmgTitle = ((System.Windows.Controls.Label)(target));
            return;
            case 8:
            this.CurrentVersion = ((System.Windows.Controls.Label)(target));
            return;
            case 9:
            this.BootmgTitle_Copy = ((System.Windows.Controls.Label)(target));
            return;
            case 10:
            this.NewVersion = ((System.Windows.Controls.Label)(target));
            return;
            case 11:
            this.Changelog_Copy = ((System.Windows.Controls.Button)(target));
            
            #line 249 "..\..\..\UpdateAvailable.xaml"
            this.Changelog_Copy.Click += new System.Windows.RoutedEventHandler(this.BackToMain);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}


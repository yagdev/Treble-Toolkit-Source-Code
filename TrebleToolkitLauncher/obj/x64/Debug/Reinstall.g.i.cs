﻿#pragma checksum "..\..\..\Reinstall.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "DFFE1A042679B3C3E7A8642CFA0028CE2338C8742C08EA14B2F2D91F1AA7E5D7"
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
    /// Reinstall
    /// </summary>
    public partial class Reinstall : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 126 "..\..\..\Reinstall.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid GridMain;
        
        #line default
        #line hidden
        
        
        #line 131 "..\..\..\Reinstall.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ProgressBar status_pgr;
        
        #line default
        #line hidden
        
        
        #line 151 "..\..\..\Reinstall.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button No;
        
        #line default
        #line hidden
        
        
        #line 161 "..\..\..\Reinstall.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Yes;
        
        #line default
        #line hidden
        
        
        #line 171 "..\..\..\Reinstall.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label copyright;
        
        #line default
        #line hidden
        
        
        #line 191 "..\..\..\Reinstall.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label BootmgTitle;
        
        #line default
        #line hidden
        
        
        #line 201 "..\..\..\Reinstall.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label CurrentVersion;
        
        #line default
        #line hidden
        
        
        #line 221 "..\..\..\Reinstall.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label BootmgTitle_Copy;
        
        #line default
        #line hidden
        
        
        #line 231 "..\..\..\Reinstall.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label NewVersion;
        
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
            System.Uri resourceLocater = new System.Uri("/TrebleToolkitLauncher;component/reinstall.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Reinstall.xaml"
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
            
            #line 151 "..\..\..\Reinstall.xaml"
            this.No.Click += new System.Windows.RoutedEventHandler(this.No_btn);
            
            #line default
            #line hidden
            return;
            case 4:
            this.Yes = ((System.Windows.Controls.Button)(target));
            
            #line 161 "..\..\..\Reinstall.xaml"
            this.Yes.Click += new System.Windows.RoutedEventHandler(this.Yes_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.copyright = ((System.Windows.Controls.Label)(target));
            return;
            case 6:
            this.BootmgTitle = ((System.Windows.Controls.Label)(target));
            return;
            case 7:
            this.CurrentVersion = ((System.Windows.Controls.Label)(target));
            return;
            case 8:
            this.BootmgTitle_Copy = ((System.Windows.Controls.Label)(target));
            return;
            case 9:
            this.NewVersion = ((System.Windows.Controls.Label)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

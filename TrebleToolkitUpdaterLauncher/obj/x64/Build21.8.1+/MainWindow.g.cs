﻿#pragma checksum "..\..\..\MainWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "EB1E031C643413FC7B965F3CBDC0681300CD8424E569EE906BFF92E8BB1EFFFB"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using MultiLanguageMarkup;
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
using TrebleToolkitUpdaterLauncher;


namespace TrebleToolkitUpdaterLauncher {
    
    
    /// <summary>
    /// MainWindow
    /// </summary>
    public partial class MainWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 214 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid GridMain;
        
        #line default
        #line hidden
        
        
        #line 221 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label status_lbl;
        
        #line default
        #line hidden
        
        
        #line 222 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label Title;
        
        #line default
        #line hidden
        
        
        #line 223 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button UpdateLauncher;
        
        #line default
        #line hidden
        
        
        #line 233 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button JoinBeta;
        
        #line default
        #line hidden
        
        
        #line 243 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Reinstall;
        
        #line default
        #line hidden
        
        
        #line 253 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button CheckConnection;
        
        #line default
        #line hidden
        
        
        #line 263 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Launch;
        
        #line default
        #line hidden
        
        
        #line 273 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Launch2;
        
        #line default
        #line hidden
        
        
        #line 283 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ProgressBar status_pgr;
        
        #line default
        #line hidden
        
        
        #line 293 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Protection;
        
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
            System.Uri resourceLocater = new System.Uri("/TrebleToolkitLauncher;component/mainwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\MainWindow.xaml"
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
            this.status_lbl = ((System.Windows.Controls.Label)(target));
            return;
            case 3:
            this.Title = ((System.Windows.Controls.Label)(target));
            return;
            case 4:
            this.UpdateLauncher = ((System.Windows.Controls.Button)(target));
            
            #line 223 "..\..\..\MainWindow.xaml"
            this.UpdateLauncher.Click += new System.Windows.RoutedEventHandler(this.Button_ClickL);
            
            #line default
            #line hidden
            return;
            case 5:
            this.JoinBeta = ((System.Windows.Controls.Button)(target));
            
            #line 233 "..\..\..\MainWindow.xaml"
            this.JoinBeta.Click += new System.Windows.RoutedEventHandler(this.JoinBeta_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.Reinstall = ((System.Windows.Controls.Button)(target));
            
            #line 243 "..\..\..\MainWindow.xaml"
            this.Reinstall.Click += new System.Windows.RoutedEventHandler(this.Button_Click1);
            
            #line default
            #line hidden
            return;
            case 7:
            this.CheckConnection = ((System.Windows.Controls.Button)(target));
            
            #line 253 "..\..\..\MainWindow.xaml"
            this.CheckConnection.Click += new System.Windows.RoutedEventHandler(this.CheckConnection_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.Launch = ((System.Windows.Controls.Button)(target));
            
            #line 263 "..\..\..\MainWindow.xaml"
            this.Launch.Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.Launch2 = ((System.Windows.Controls.Button)(target));
            
            #line 273 "..\..\..\MainWindow.xaml"
            this.Launch2.Click += new System.Windows.RoutedEventHandler(this.Button_Click2);
            
            #line default
            #line hidden
            return;
            case 10:
            this.status_pgr = ((System.Windows.Controls.ProgressBar)(target));
            return;
            case 11:
            this.Protection = ((System.Windows.Controls.Button)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

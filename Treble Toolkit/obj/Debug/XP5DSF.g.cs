﻿#pragma checksum "..\..\XP5DSF.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "51803043378856B8D235DD5EF40D6D7F151E84FFD20405F2EB671CB44BCFE5DA"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using NHotkey.Wpf;
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
using Treble_Toolkit;


namespace Treble_Toolkit {
    
    
    /// <summary>
    /// XP5DSF
    /// </summary>
    public partial class XP5DSF : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 214 "..\..\XP5DSF.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid GridMain;
        
        #line default
        #line hidden
        
        
        #line 225 "..\..\XP5DSF.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ProgressBar status_pgr;
        
        #line default
        #line hidden
        
        
        #line 236 "..\..\XP5DSF.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label Title;
        
        #line default
        #line hidden
        
        
        #line 246 "..\..\XP5DSF.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label VersionString;
        
        #line default
        #line hidden
        
        
        #line 256 "..\..\XP5DSF.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button DeviceSpecificFeatures_Copy;
        
        #line default
        #line hidden
        
        
        #line 266 "..\..\XP5DSF.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BackAbout;
        
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
            System.Uri resourceLocater = new System.Uri("/gui;component/xp5dsf.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\XP5DSF.xaml"
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
            this.Title = ((System.Windows.Controls.Label)(target));
            return;
            case 4:
            this.VersionString = ((System.Windows.Controls.Label)(target));
            return;
            case 5:
            this.DeviceSpecificFeatures_Copy = ((System.Windows.Controls.Button)(target));
            
            #line 256 "..\..\XP5DSF.xaml"
            this.DeviceSpecificFeatures_Copy.Click += new System.Windows.RoutedEventHandler(this.BACK_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.BackAbout = ((System.Windows.Controls.Button)(target));
            
            #line 266 "..\..\XP5DSF.xaml"
            this.BackAbout.Click += new System.Windows.RoutedEventHandler(this.HM10L_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}


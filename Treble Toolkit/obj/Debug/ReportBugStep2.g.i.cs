﻿#pragma checksum "..\..\ReportBugStep2.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "2F5055702BB4B2F279FB7F3140A13A0263759897D1D727A8493D75A4979D0169"
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
    /// ReportBugStep2
    /// </summary>
    public partial class ReportBugStep2 : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 151 "..\..\ReportBugStep2.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid GridMain;
        
        #line default
        #line hidden
        
        
        #line 161 "..\..\ReportBugStep2.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button DeviceSpecificFeatures_Copy1;
        
        #line default
        #line hidden
        
        
        #line 163 "..\..\ReportBugStep2.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button DeviceSpecificFeatures_Copy4;
        
        #line default
        #line hidden
        
        
        #line 165 "..\..\ReportBugStep2.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button DeviceSpecificFeatures_Copy;
        
        #line default
        #line hidden
        
        
        #line 167 "..\..\ReportBugStep2.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button DeviceSpecificFeatures_Copy2;
        
        #line default
        #line hidden
        
        
        #line 169 "..\..\ReportBugStep2.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Shapes.Rectangle BugReport;
        
        #line default
        #line hidden
        
        
        #line 171 "..\..\ReportBugStep2.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label cc;
        
        #line default
        #line hidden
        
        
        #line 173 "..\..\ReportBugStep2.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label FileSizeCheck;
        
        #line default
        #line hidden
        
        
        #line 175 "..\..\ReportBugStep2.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image DeviceInfoImg;
        
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
            System.Uri resourceLocater = new System.Uri("/gui;component/reportbugstep2.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\ReportBugStep2.xaml"
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
            this.DeviceSpecificFeatures_Copy1 = ((System.Windows.Controls.Button)(target));
            
            #line 161 "..\..\ReportBugStep2.xaml"
            this.DeviceSpecificFeatures_Copy1.Click += new System.Windows.RoutedEventHandler(this.Back_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.DeviceSpecificFeatures_Copy4 = ((System.Windows.Controls.Button)(target));
            
            #line 163 "..\..\ReportBugStep2.xaml"
            this.DeviceSpecificFeatures_Copy4.Click += new System.Windows.RoutedEventHandler(this.More_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.DeviceSpecificFeatures_Copy = ((System.Windows.Controls.Button)(target));
            
            #line 165 "..\..\ReportBugStep2.xaml"
            this.DeviceSpecificFeatures_Copy.Click += new System.Windows.RoutedEventHandler(this.BackAbout_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.DeviceSpecificFeatures_Copy2 = ((System.Windows.Controls.Button)(target));
            
            #line 167 "..\..\ReportBugStep2.xaml"
            this.DeviceSpecificFeatures_Copy2.Click += new System.Windows.RoutedEventHandler(this.Location_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.BugReport = ((System.Windows.Shapes.Rectangle)(target));
            return;
            case 7:
            this.cc = ((System.Windows.Controls.Label)(target));
            return;
            case 8:
            this.FileSizeCheck = ((System.Windows.Controls.Label)(target));
            return;
            case 9:
            this.DeviceInfoImg = ((System.Windows.Controls.Image)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}


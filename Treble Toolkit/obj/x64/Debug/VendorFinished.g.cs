﻿#pragma checksum "..\..\..\VendorFinished.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "FAEF1C81F9C4004E57FB0FF1D293803CFE98747055ECF1E2ADA642150457375A"
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
    /// VendorFinished
    /// </summary>
    public partial class VendorFinished : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 59 "..\..\..\VendorFinished.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid GridMain;
        
        #line default
        #line hidden
        
        
        #line 68 "..\..\..\VendorFinished.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button DeviceSpecificFeatures_Copy1;
        
        #line default
        #line hidden
        
        
        #line 70 "..\..\..\VendorFinished.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button DeviceSpecificFeatures_Copy;
        
        #line default
        #line hidden
        
        
        #line 72 "..\..\..\VendorFinished.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Shapes.Rectangle GSIRectangle;
        
        #line default
        #line hidden
        
        
        #line 74 "..\..\..\VendorFinished.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label PhoneStatus;
        
        #line default
        #line hidden
        
        
        #line 76 "..\..\..\VendorFinished.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label PhoneStatus2;
        
        #line default
        #line hidden
        
        
        #line 78 "..\..\..\VendorFinished.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image DeviceInfoImg;
        
        #line default
        #line hidden
        
        
        #line 79 "..\..\..\VendorFinished.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button DeviceSpecificFeatures_Copy3;
        
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
            System.Uri resourceLocater = new System.Uri("/gui;component/vendorfinished.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\VendorFinished.xaml"
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
            
            #line 68 "..\..\..\VendorFinished.xaml"
            this.DeviceSpecificFeatures_Copy1.Click += new System.Windows.RoutedEventHandler(this.Back_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.DeviceSpecificFeatures_Copy = ((System.Windows.Controls.Button)(target));
            
            #line 70 "..\..\..\VendorFinished.xaml"
            this.DeviceSpecificFeatures_Copy.Click += new System.Windows.RoutedEventHandler(this.ReportBug_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.GSIRectangle = ((System.Windows.Shapes.Rectangle)(target));
            return;
            case 5:
            this.PhoneStatus = ((System.Windows.Controls.Label)(target));
            return;
            case 6:
            this.PhoneStatus2 = ((System.Windows.Controls.Label)(target));
            return;
            case 7:
            this.DeviceInfoImg = ((System.Windows.Controls.Image)(target));
            return;
            case 8:
            this.DeviceSpecificFeatures_Copy3 = ((System.Windows.Controls.Button)(target));
            
            #line 79 "..\..\..\VendorFinished.xaml"
            this.DeviceSpecificFeatures_Copy3.Click += new System.Windows.RoutedEventHandler(this.Next_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}


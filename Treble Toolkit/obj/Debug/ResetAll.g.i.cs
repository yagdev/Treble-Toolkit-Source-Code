﻿#pragma checksum "..\..\ResetAll.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "1EC02CA894C9FF58B2E9980A7B986CDAE52E0F23A60EC241433E1BE7A3944D4C"
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código foi gerado por uma ferramenta.
//     Versão de Tempo de Execução:4.0.30319.42000
//
//     As alterações a este ficheiro poderão provocar um comportamento incorrecto e perder-se-ão se
//     o código for regenerado.
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
    /// ResetAll
    /// </summary>
    public partial class ResetAll : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 165 "..\..\ResetAll.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid GridMain;
        
        #line default
        #line hidden
        
        
        #line 173 "..\..\ResetAll.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Shapes.Rectangle BugReport_Copy;
        
        #line default
        #line hidden
        
        
        #line 193 "..\..\ResetAll.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button DeviceSpecificFeatures_Copy1;
        
        #line default
        #line hidden
        
        
        #line 203 "..\..\ResetAll.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button DeviceSpecificFeatures_Copy4;
        
        #line default
        #line hidden
        
        
        #line 213 "..\..\ResetAll.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label cc;
        
        #line default
        #line hidden
        
        
        #line 223 "..\..\ResetAll.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label FileSizeCheck;
        
        #line default
        #line hidden
        
        
        #line 233 "..\..\ResetAll.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image DeviceInfoImg;
        
        #line default
        #line hidden
        
        
        #line 234 "..\..\ResetAll.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image DeviceInfoImg_Copy;
        
        #line default
        #line hidden
        
        
        #line 235 "..\..\ResetAll.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image DeviceInfoImg_Copy1;
        
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
            System.Uri resourceLocater = new System.Uri("/gui;component/resetall.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\ResetAll.xaml"
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
            this.BugReport_Copy = ((System.Windows.Shapes.Rectangle)(target));
            return;
            case 3:
            this.DeviceSpecificFeatures_Copy1 = ((System.Windows.Controls.Button)(target));
            
            #line 193 "..\..\ResetAll.xaml"
            this.DeviceSpecificFeatures_Copy1.Click += new System.Windows.RoutedEventHandler(this.BackAbout_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.DeviceSpecificFeatures_Copy4 = ((System.Windows.Controls.Button)(target));
            
            #line 203 "..\..\ResetAll.xaml"
            this.DeviceSpecificFeatures_Copy4.Click += new System.Windows.RoutedEventHandler(this.More_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.cc = ((System.Windows.Controls.Label)(target));
            return;
            case 6:
            this.FileSizeCheck = ((System.Windows.Controls.Label)(target));
            return;
            case 7:
            this.DeviceInfoImg = ((System.Windows.Controls.Image)(target));
            return;
            case 8:
            this.DeviceInfoImg_Copy = ((System.Windows.Controls.Image)(target));
            return;
            case 9:
            this.DeviceInfoImg_Copy1 = ((System.Windows.Controls.Image)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}


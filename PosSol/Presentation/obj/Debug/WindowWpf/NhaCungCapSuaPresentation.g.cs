﻿#pragma checksum "..\..\..\WindowWpf\NhaCungCapSuaPresentation.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "97518CFB4800C6C0C33A5D18D857BB5AFB417BE1DB2470E5FE10B35D94D6C653"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using RootLibrary.WPF.Localization;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.Integration;
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


namespace Presentation.WindowWpf {
    
    
    /// <summary>
    /// NhaCungCapSuaPresentation
    /// </summary>
    public partial class NhaCungCapSuaPresentation : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 26 "..\..\..\WindowWpf\NhaCungCapSuaPresentation.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtMaNCC;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\WindowWpf\NhaCungCapSuaPresentation.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtTenNCC;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\WindowWpf\NhaCungCapSuaPresentation.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RichTextBox rtxtGhiChu;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\..\WindowWpf\NhaCungCapSuaPresentation.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnLuu;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\..\WindowWpf\NhaCungCapSuaPresentation.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnHuy;
        
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
            System.Uri resourceLocater = new System.Uri("/Presentation;component/windowwpf/nhacungcapsuapresentation.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\WindowWpf\NhaCungCapSuaPresentation.xaml"
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
            
            #line 6 "..\..\..\WindowWpf\NhaCungCapSuaPresentation.xaml"
            ((Presentation.WindowWpf.NhaCungCapSuaPresentation)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.txtMaNCC = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.txtTenNCC = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.rtxtGhiChu = ((System.Windows.Controls.RichTextBox)(target));
            return;
            case 5:
            this.btnLuu = ((System.Windows.Controls.Button)(target));
            
            #line 39 "..\..\..\WindowWpf\NhaCungCapSuaPresentation.xaml"
            this.btnLuu.Click += new System.Windows.RoutedEventHandler(this.btnLuu_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.btnHuy = ((System.Windows.Controls.Button)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}


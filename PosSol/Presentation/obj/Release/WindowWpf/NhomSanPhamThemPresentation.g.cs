﻿#pragma checksum "..\..\..\WindowWpf\NhomSanPhamThemPresentation.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "AF17C13C8CA7FBE547F96FA637DFDBB3"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

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


namespace Presentation.WindowWpf {
    
    
    /// <summary>
    /// NhomSanPhamThemPresentation
    /// </summary>
    public partial class NhomSanPhamThemPresentation : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 1 "..\..\..\WindowWpf\NhomSanPhamThemPresentation.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Presentation.WindowWpf.NhomSanPhamThemPresentation wpfThemNhomSanPham;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\WindowWpf\NhomSanPhamThemPresentation.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtTenNhom;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\WindowWpf\NhomSanPhamThemPresentation.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtMaNhom;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\WindowWpf\NhomSanPhamThemPresentation.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RichTextBox rtxtGhiChu;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\WindowWpf\NhomSanPhamThemPresentation.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox ckDangDung;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\WindowWpf\NhomSanPhamThemPresentation.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnHuy;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\WindowWpf\NhomSanPhamThemPresentation.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnLuu;
        
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
            System.Uri resourceLocater = new System.Uri("/Presentation;component/windowwpf/nhomsanphamthempresentation.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\WindowWpf\NhomSanPhamThemPresentation.xaml"
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
            this.wpfThemNhomSanPham = ((Presentation.WindowWpf.NhomSanPhamThemPresentation)(target));
            return;
            case 2:
            this.txtTenNhom = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.txtMaNhom = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.rtxtGhiChu = ((System.Windows.Controls.RichTextBox)(target));
            return;
            case 5:
            this.ckDangDung = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 6:
            this.btnHuy = ((System.Windows.Controls.Button)(target));
            return;
            case 7:
            this.btnLuu = ((System.Windows.Controls.Button)(target));
            
            #line 20 "..\..\..\WindowWpf\NhomSanPhamThemPresentation.xaml"
            this.btnLuu.Click += new System.Windows.RoutedEventHandler(this.btnLuu_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}


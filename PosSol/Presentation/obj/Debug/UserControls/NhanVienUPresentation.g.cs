﻿#pragma checksum "..\..\..\UserControls\NhanVienUPresentation.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "0CE6247AF5FA5A306D8FBDD7E47331E266598043ADA29FC55F65F52D5B19F395"
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


namespace Presentation.UserControls {
    
    
    /// <summary>
    /// NhanVienUPresentation
    /// </summary>
    public partial class NhanVienUPresentation : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 37 "..\..\..\UserControls\NhanVienUPresentation.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtTimKiem;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\UserControls\NhanVienUPresentation.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnTimKiem;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\..\UserControls\NhanVienUPresentation.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lbWarning;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\..\UserControls\NhanVienUPresentation.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnReset;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\..\UserControls\NhanVienUPresentation.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dgNhanVien;
        
        #line default
        #line hidden
        
        
        #line 190 "..\..\..\UserControls\NhanVienUPresentation.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnThemMoi;
        
        #line default
        #line hidden
        
        
        #line 197 "..\..\..\UserControls\NhanVienUPresentation.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnDong;
        
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
            System.Uri resourceLocater = new System.Uri("/Presentation;component/usercontrols/nhanvienupresentation.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\UserControls\NhanVienUPresentation.xaml"
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
            
            #line 7 "..\..\..\UserControls\NhanVienUPresentation.xaml"
            ((Presentation.UserControls.NhanVienUPresentation)(target)).Loaded += new System.Windows.RoutedEventHandler(this.ucNhanVien_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.txtTimKiem = ((System.Windows.Controls.TextBox)(target));
            
            #line 37 "..\..\..\UserControls\NhanVienUPresentation.xaml"
            this.txtTimKiem.PreviewKeyDown += new System.Windows.Input.KeyEventHandler(this.txtTimKiem_PreviewKeyDown);
            
            #line default
            #line hidden
            return;
            case 3:
            this.btnTimKiem = ((System.Windows.Controls.Button)(target));
            
            #line 38 "..\..\..\UserControls\NhanVienUPresentation.xaml"
            this.btnTimKiem.Click += new System.Windows.RoutedEventHandler(this.btnTimKiem_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.lbWarning = ((System.Windows.Controls.Label)(target));
            return;
            case 5:
            this.btnReset = ((System.Windows.Controls.Button)(target));
            
            #line 46 "..\..\..\UserControls\NhanVienUPresentation.xaml"
            this.btnReset.Click += new System.Windows.RoutedEventHandler(this.btnReset_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.dgNhanVien = ((System.Windows.Controls.DataGrid)(target));
            
            #line 53 "..\..\..\UserControls\NhanVienUPresentation.xaml"
            this.dgNhanVien.LoadingRow += new System.EventHandler<System.Windows.Controls.DataGridRowEventArgs>(this.dgNhomSanPham_LoadingRow);
            
            #line default
            #line hidden
            
            #line 54 "..\..\..\UserControls\NhanVienUPresentation.xaml"
            this.dgNhanVien.MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.dgNhanVien_MouseDoubleClick);
            
            #line default
            #line hidden
            return;
            case 10:
            this.btnThemMoi = ((System.Windows.Controls.Button)(target));
            
            #line 190 "..\..\..\UserControls\NhanVienUPresentation.xaml"
            this.btnThemMoi.Click += new System.Windows.RoutedEventHandler(this.btnThemMoi_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            this.btnDong = ((System.Windows.Controls.Button)(target));
            
            #line 197 "..\..\..\UserControls\NhanVienUPresentation.xaml"
            this.btnDong.Click += new System.Windows.RoutedEventHandler(this.btnDong_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        void System.Windows.Markup.IStyleConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 7:
            
            #line 131 "..\..\..\UserControls\NhanVienUPresentation.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.btnSua_Click);
            
            #line default
            #line hidden
            break;
            case 8:
            
            #line 143 "..\..\..\UserControls\NhanVienUPresentation.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.btnXoa_Click);
            
            #line default
            #line hidden
            break;
            case 9:
            
            #line 167 "..\..\..\UserControls\NhanVienUPresentation.xaml"
            ((System.Windows.Controls.Image)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Image_Loaded);
            
            #line default
            #line hidden
            break;
            }
        }
    }
}


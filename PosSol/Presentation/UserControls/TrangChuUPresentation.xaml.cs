using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Public;
using Business;

namespace Presentation.UserControls
{
    /// <summary>
    /// Interaction logic for TrangChuUPresentation.xaml
    /// </summary>
    public partial class TrangChuUPresentation : UserControl
    {
        //Khai báo
        public int _ChucNang;
        public event EventHandler _ChonChucNang;
        public List<QuyenChucNangPublic> _lstQuyen;

        public TrangChuUPresentation()
        {
            InitializeComponent();
        }

        //Nút bán hàng
        private void btnBanHang_Click(object sender, RoutedEventArgs e)
        {
            _ChucNang = 1;
            EventHandler _eh = _ChonChucNang;
            if (_eh != null)
                _eh(this, e);
        }

        //Nút nhập hàng trả
        private void btnHangTra_Click(object sender, RoutedEventArgs e)
        {
            _ChucNang = 2;
            EventHandler _eh = _ChonChucNang;
            if (_eh != null)
                _eh(this, e);
        }

        //Nút nhập mua
        private void btnNhanMua_Click(object sender, RoutedEventArgs e)
        {
            _ChucNang = 3;
            EventHandler _eh = _ChonChucNang;
            if (_eh != null)
                _eh(this, e);
        }

        //In tem sản phẩm
        private void btnMaVach_Click(object sender, RoutedEventArgs e)
        {
            _ChucNang = 4;
            EventHandler _eh = _ChonChucNang;
            if (_eh != null)
                _eh(this, e);
        }

        //Quản lý khách hàng
        private void btnKhacHang_Click(object sender, RoutedEventArgs e)
        {
            _ChucNang = 5;
            EventHandler _eh = _ChonChucNang;
            if (_eh != null)
                _eh(this, e);
        }

        //Nút sản phẩm
        private void btnSanPham_Click(object sender, RoutedEventArgs e)
        {
            _ChucNang = 6;
            EventHandler _eh = _ChonChucNang;
            if (_eh != null)
                _eh(this, e);
        }

        //Loaded
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            //Hiển thị teo quyền
            HienThiTheoQuyen();
        }

        //Hiển thi theo quyền
        private void HienThiTheoQuyen()
        {
            //Nút bán hàng 
            btnBanHang.IsEnabled = DangNhapBusiness.HienThiQuyen(_lstQuyen, "CN00001");

            //Nút nhập hàng trả
            btnHangTra.IsEnabled = DangNhapBusiness.HienThiQuyen(_lstQuyen, "CN00007");

            //Nút nhập mua
            btnNhanMua.IsEnabled = DangNhapBusiness.HienThiQuyen(_lstQuyen, "CN00006");

            //Nút tạo mã vạch
            btnMaVach.IsEnabled = DangNhapBusiness.HienThiQuyen(_lstQuyen, "CN00017");

            //Nút khách hàng
            btnKhacHang.IsEnabled = DangNhapBusiness.HienThiQuyen(_lstQuyen, "CN00022");

            //Nút sản phẩm
            btnSanPham.IsEnabled = DangNhapBusiness.HienThiQuyen(_lstQuyen, "CN00015");
        }
    }//End class
}

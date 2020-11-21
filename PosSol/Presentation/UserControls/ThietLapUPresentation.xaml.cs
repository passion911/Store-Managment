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
using Business;
using Public;

namespace Presentation.UserControls
{
    /// <summary>
    /// Interaction logic for ThietLapUPresentation.xaml
    /// </summary>
    public partial class ThietLapUPresentation : UserControl
    {
        //Khai báo
        public event EventHandler evChonChucNang;
        public string ChucNang; //Mã chức năng dc chọn
        public List<QuyenChucNangPublic> _lstQuyen;

        public ThietLapUPresentation()
        {
            InitializeComponent();
        }

        //NÚT NHÓM SẢN PHẨM - 2
        private void btnNhomSanPham_Click(object sender, RoutedEventArgs e)
        {
            ChucNang = "2";
            Action(sender, e);
        }

        //NÚT ĐƠN VỊ TÍNH - 3
        private void btnDonVi_Click(object sender, RoutedEventArgs e)
        {
            ChucNang = "3";
            Action(sender, e);
        }

        //NÚT NHÀ CUNG CẤP - 4
        private void btnNhaCungCap_Click(object sender, RoutedEventArgs e)
        {
            ChucNang = "4";
            Action(sender, e);
        }
        void Action(object sender, RoutedEventArgs e)
        {
            EventHandler eh = evChonChucNang;
            if (eh != null)
                eh(this, e);
        }

        //NÚT NHÂN VIÊN
        private void btnNhanVien_Click(object sender, RoutedEventArgs e)
        {
            ChucNang = "5";
            Action(sender, e);
        }

        //NÚT KHÁCH HÀNG
        private void btnKhachHang_Click(object sender, RoutedEventArgs e)
        {
            ChucNang = "6";
            Action(sender, e);
        }

        //NÚT NHÓM KHÁCH HÀNG
        private void btnNhomKhachHang_Click(object sender, RoutedEventArgs e)
        {
            ChucNang = "7";
            Action(sender, e);
        }

        //Nút sản phẩm
        private void btnSanPham_Click(object sender, RoutedEventArgs e)
        {
            ChucNang = "1";
            Action(sender, e);
        }

        //Tạo tem sản phẩm
        private void btnTaoTemSP_Click(object sender, RoutedEventArgs e)
        {
            ChucNang = "8";
            Action(sender, e);
        }

        //Nút mã giảm giá
        private void btnMaGiamGia_Click(object sender, RoutedEventArgs e)
        {
            ChucNang = "9";
            Action(sender, e);
        }

        //Nút quyền
        private void btnPhanQuyen_Click(object sender, RoutedEventArgs e)
        {
            ChucNang = "10";
            Action(sender, e);
        }

        //Nút thiết lâp cấu hình
        private void btnCauHinh_Click(object sender, RoutedEventArgs e)
        {
            ChucNang = "11";
            Action(sender, e);
        }

        //Nút đổi mật khẩu
        private void btnDoiMatKhau_Click(object sender, RoutedEventArgs e)
        {
            ChucNang = "12";
            Action(sender, e);
        }

        //wpf loaded
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            //Hiển thị theo quyền
            HienThiChucNangTheoQuyen();
        }

        //hiên thị chức năng theo quyền
        private void HienThiChucNangTheoQuyen()
        {
            //Nút quản lý sản phẩm
            btnSanPham.IsEnabled = DangNhapBusiness.HienThiQuyen(_lstQuyen, "CN00015");

            //Nút quản lý nhóm sản phẩm
            btnNhomSanPham.IsEnabled = DangNhapBusiness.HienThiQuyen(_lstQuyen, "CN00016");

            //Nút in tem sản phẩm
            btnTaoTemSP.IsEnabled = DangNhapBusiness.HienThiQuyen(_lstQuyen, "CN00017");

            //Nút quản lý nhà cugn cấp
            btnNhaCungCap.IsEnabled = DangNhapBusiness.HienThiQuyen(_lstQuyen, "CN00018");

            //Nút quản lý đơn vị tính
            btnDonVi.IsEnabled = DangNhapBusiness.HienThiQuyen(_lstQuyen, "CN00019");

            //Nút tạo mã giảm giá
            btnMaGiamGia.IsEnabled = DangNhapBusiness.HienThiQuyen(_lstQuyen, "CN00020");

            //Nút quản lý nhân viên
            btnNhanVien.IsEnabled = DangNhapBusiness.HienThiQuyen(_lstQuyen, "CN00021");

            //Nút khách hàng
            btnKhachHang.IsEnabled = DangNhapBusiness.HienThiQuyen(_lstQuyen, "CN00022");

            //Nút nhóm khách hàng
            btnNhomKhachHang.IsEnabled = DangNhapBusiness.HienThiQuyen(_lstQuyen, "CN00023");

            //Nút thiết lập hệ thống
            btnCauHinh.IsEnabled = DangNhapBusiness.HienThiQuyen(_lstQuyen, "CN00024");

            //Nút quản lý nhóm quyền 
            btnPhanQuyen.IsEnabled = DangNhapBusiness.HienThiQuyen(_lstQuyen, "CN00025");

            //Nút đổi mật khẩu
            btnDoiMatKhau.IsEnabled = DangNhapBusiness.HienThiQuyen(_lstQuyen, "CN00026");

        }
    }//End class
}

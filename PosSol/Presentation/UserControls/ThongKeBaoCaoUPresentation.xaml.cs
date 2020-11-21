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
    /// Interaction logic for ThongKeBaoCaoUPresentation.xaml
    /// </summary>
    public partial class ThongKeBaoCaoUPresentation : UserControl
    {
        //Khai báo
        public event EventHandler _ChonChucNang;
        public int _ChucNang;
        public NhanVienPublic _NhanVien;
        public List<QuyenChucNangPublic> _lstQuyen;

        public ThongKeBaoCaoUPresentation()
        {
            InitializeComponent();
        }

        //Nút hóa đơn
        private void btnHoaDon_Click(object sender, RoutedEventArgs e)
        {
            _ChucNang = 1;
            EventHandler _eh = _ChonChucNang;
            if (_eh != null)
                _eh(this, e);
        }

        //Lịch sử bán hàng
        private void btnLichSuBanHang_Click(object sender, RoutedEventArgs e)
        {
            _ChucNang = 2;
            EventHandler _eh = _ChonChucNang;
            if (_eh != null)
                _eh(this, e);
        }

        //Nút doanh thu theo sản phẩm
        private void btnThongKeTheoSP_Click(object sender, RoutedEventArgs e)
        {
            _ChucNang = 3;
            EventHandler _eh = _ChonChucNang;
            if (_eh != null)
                _eh(this, e);
        }

        //Thông ke theo nhân viên
        private void btnThongKeTheoNV_Click(object sender, RoutedEventArgs e)
        {
            _ChucNang = 4;
            EventHandler _eh = _ChonChucNang;
            if (_eh != null)
                _eh(this, e);
        }

        //Nút phiểu nhập
        private void btnPhieuNhap_Click(object sender, RoutedEventArgs e)
        {
            _ChucNang = 5;
            EventHandler _eh = _ChonChucNang;
            if (_eh != null)
                _eh(this, e);
        }

        //Nút thống kê theo khách hàng
        private void btnThongKeTheoKH_Click(object sender, RoutedEventArgs e)
        {
            _ChucNang = 6;
            EventHandler _eh = _ChonChucNang;
            if (_eh != null)
                _eh(this, e);
        }

        //wpf loaded
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            //Hiên thị theo quyền
            HienThiTheoQuyen();
        }

        //Hiển thị theo quyền
        private void HienThiTheoQuyen()
        {
            //Nút hóa đơn
            btnHoaDon.IsEnabled = DangNhapBusiness.HienThiQuyen(_lstQuyen, "CN00009");

            //Nút doanh thu theo sản phẩm
            btnThongKeTheoSP.IsEnabled = DangNhapBusiness.HienThiQuyen(_lstQuyen, "CN00010");

            //Nút xem lịch sử bán hàng
            btnLichSuBanHang.IsEnabled = DangNhapBusiness.HienThiQuyen(_lstQuyen, "CN00011");

            //Nút xem doanh thu theo nhân viên
            btnThongKeTheoNV.IsEnabled = DangNhapBusiness.HienThiQuyen(_lstQuyen, "CN00012");

            //Nút xem phiếu nhập
            btnPhieuNhap.IsEnabled = DangNhapBusiness.HienThiQuyen(_lstQuyen, "CN00013");

            //Nút thống kê theo khách hàng
            btnThongKeTheoKH.IsEnabled = DangNhapBusiness.HienThiQuyen(_lstQuyen, "CN00014");
        }
    }//End class
}

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
using System.Windows.Shapes;
using System.Data;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using Public;
using System.ComponentModel;
using Business;

namespace Presentation.Report
{
    /// <summary>
    /// Interaction logic for HoaDonBanLe_UPresentation.xaml
    /// </summary>
    public partial class HoaDonBanLe_UPresentation : Window
    {
        //Khai báo
        public DataTable _dtHoaDon = new DataTable();
        public HoaDonPublic _hoaDon = new HoaDonPublic();
        BackgroundWorker _worker;
        ReportDocument _report;
        ThietLapHeThongPublic _thietLap;
        public HoaDonBanLe_UPresentation()
        {
            InitializeComponent();
            bdProgress.Visibility = System.Windows.Visibility.Hidden;
        }
        public string _status_para = "";

        //wpf loaded
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //Hiển thị tiến trình
            bdProgress.Visibility = System.Windows.Visibility.Visible;

            //Gọi tiến trình xử lý
            _worker = new BackgroundWorker();
            _worker.DoWork += (obj, ex) => Loaded_dowork();
            _worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(Loaded_complete);
            _worker.RunWorkerAsync();
        }

        //Loaded dowork
        private void Loaded_dowork()
        {
            //Lấy thông tin in hóa đơn
            _report = new ReportDocument();
            _report.Load("../../Report/HoaDonBanLe_rpt.rpt");

            //Thông tin cửa hàng
            _thietLap = ThietLapHeThongBusiness.LayThietLapHeThong();

            //Thông tin hàng mua
            _report.Database.Tables["tbl_HOADON"].SetDataSource(_dtHoaDon);

            //Thông tin cửa hàng
            _report.SetParameterValue("TenCuaHang_para", _thietLap.TenCuaHang);
            _report.SetParameterValue("DiaChi_para", _thietLap.DiaChi);
            _report.SetParameterValue("SDT_para", _thietLap.SDT);

            //Thông tin hóa đơn
            _report.SetParameterValue("SoHD_Para", _hoaDon.SoHD_HD);
            _report.SetParameterValue("NhanVien_Para", _hoaDon.NguoiLap_HD.MaNV_NV);
            _report.SetParameterValue("Ngay_Para", _hoaDon.NgayLap_HD.ToString("dd/MM/yyyy [HH:mm tt]"));
            _report.SetParameterValue("_status_para", _status_para);

            _report.SetParameterValue("TongSoLuong_para", _hoaDon.TongSoLuongSP);
            _report.SetParameterValue("TongTien_para", UntilitiesBusiness.ThemDauPhay(_hoaDon.TongTien_HD.ToString()));

            _report.SetParameterValue("TongCKSP_para", UntilitiesBusiness.ThemDauPhay(_hoaDon.TongCKSanPham.ToString()));
            _report.SetParameterValue("TongCKHD_para", UntilitiesBusiness.ThemDauPhay(_hoaDon.TongCKHoaDon.ToString()));
            _report.SetParameterValue("Voucher_para", UntilitiesBusiness.ThemDauPhay(_hoaDon.VouCher_HD.ToString()));
            _report.SetParameterValue("MaGiamGia_para", UntilitiesBusiness.ThemDauPhay(_hoaDon.TienMaGiamGia.ToString()));

            _report.SetParameterValue("ThanhTien_para", UntilitiesBusiness.ThemDauPhay(_hoaDon.TienConLaiPhaiTra.ToString()));

            _report.SetParameterValue("TienKhachTra_para", UntilitiesBusiness.ThemDauPhay(_hoaDon.TienKhachTra_HD.ToString()));
            _report.SetParameterValue("TienThuaTraKhach_para", UntilitiesBusiness.ThemDauPhay(_hoaDon.TienThuaTraLaiKhach.ToString()));
            _report.SetParameterValue("TienBangChu_para", UntilitiesBusiness.ChuyenSoThanhChu(_hoaDon.TienConLaiPhaiTra.ToString()));

            //Thông tin khách hàng
            int _DiemTichLuyHoaDon = _hoaDon.TongTien_HD / _thietLap.MucQuyDoiDiem;
            if (String.IsNullOrEmpty(_hoaDon.KhachHang_HD.MaKH_KH))
            {
                _hoaDon.KhachHang_HD.MaKH_KH = "";
                _hoaDon.KhachHang_HD.DiemTichLuy_KH = 0;
                _hoaDon.KhachHang_HD.NHK_KH.TenNKH_NKH = "";
                _DiemTichLuyHoaDon = 0;
            }
            else
            {
                //Lấy tên nhóm khách hàng
                DataTable _dtKhachHang = BanHangBusiness.LayKhTheoMa(_hoaDon.KhachHang_HD.MaKH_KH).Tables[0];
                _hoaDon.KhachHang_HD.DiemTichLuy_KH = (int)_dtKhachHang.Rows[0]["DiemTichLuy_KH"];
                _hoaDon.KhachHang_HD.NHK_KH.TenNKH_NKH = _dtKhachHang.Rows[0]["TenNKH_NKH"].ToString();
            }

            _report.SetParameterValue("MaKhachHang_para", _hoaDon.KhachHang_HD.MaKH_KH);
            _report.SetParameterValue("DiemTichLuy_para", _hoaDon.KhachHang_HD.DiemTichLuy_KH);
            _report.SetParameterValue("TichLuyDonHang_para", _DiemTichLuyHoaDon.ToString());
            _report.SetParameterValue("TenNhomKhachHang_para", _hoaDon.KhachHang_HD.NHK_KH.TenNKH_NKH);
        }

        //Loaded complete
        private void Loaded_complete(object sender, RunWorkerCompletedEventArgs e)
        {
            //crvHoaDonBanLe.ViewerCore.ReportSource = _report;

            //Ẩn tiến trình
            bdProgress.Visibility = System.Windows.Visibility.Hidden;
        }

    }//End class
}

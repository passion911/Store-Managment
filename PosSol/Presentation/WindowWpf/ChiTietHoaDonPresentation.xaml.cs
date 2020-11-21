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
using Public;
using Business;
using Presentation.Dataset;
using System.Data;
using Presentation.Report;

namespace Presentation.WindowWpf
{
    /// <summary>
    /// Interaction logic for ChiTietHoaDonPresentation.xaml
    /// </summary>
    public partial class ChiTietHoaDonPresentation : Window
    {
        //Khai báo
        public string _soHD;
        HoaDonPublic _hoadon;
        List<HangMuaPubLic> _lstHangMua;

        public ChiTietHoaDonPresentation()
        {
            InitializeComponent();
        }

        //Hiển thị thông tin
        private void HienThiHoaDon()
        {
            //Hiển thị thông tin hóa đơn
            _hoadon = ThongKeBusiness.TinhTien1HoaDon(_soHD);

            if (_hoadon == null)
                return;

            lbSoHD.Content = _hoadon.SoHD_HD;
            lbNgayLap.Content = _hoadon.NgayLap_HD.ToString("dd/MM/yyyy HH:mm");
            lbNguoiLap.Content = _hoadon.NguoiLap_HD.MaNV_NV;
            if (String.IsNullOrEmpty(_hoadon.KhachHang_HD.MaKH_KH))
                lbKhachHang.Content = "Khách vãng lai";
            else
                lbKhachHang.Content = _hoadon.KhachHang_HD.MaKH_KH;

            lbTongTien.Content = UntilitiesBusiness.ThemDauPhay(_hoadon.TongTien_HD.ToString());
            lbTongCKSP.Content = UntilitiesBusiness.ThemDauPhay(_hoadon.TongCKSanPham.ToString());
            lbTongCKHD.Content = UntilitiesBusiness.ThemDauPhay(_hoadon.TongCKHoaDon.ToString());
            lbVoucher.Content = UntilitiesBusiness.ThemDauPhay(_hoadon.VouCher_HD.ToString());
            lbTienMaGiamGia.Content = UntilitiesBusiness.ThemDauPhay(_hoadon.TienMaGiamGia.ToString());
            lbThanhTien.Content = UntilitiesBusiness.ThemDauPhay(_hoadon.ThanhTien.ToString());

            //Hiển thị thông tin hàng mua
            _lstHangMua = ThongKeBusiness.LayHangMua(_soHD);
            dgDsHangMua.ItemsSource = _lstHangMua;
        }

        //Datagrid loading row
        private void dgDsHangMua_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = (e.Row.GetIndex() + 1).ToString();
        }

        //wpf loaded
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            HienThiHoaDon();
        }

        //Nút OK
        private void btnThemMoi_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        protected override void OnPreviewKeyDown(KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
                this.Close();
            base.OnPreviewKeyDown(e);
        }

        //Nút In
        private void btnInHD_Click(object sender, RoutedEventArgs e)
        {
            if (_lstHangMua.Count == 0)
                return;

            //Chuẩn bị dữ liệu
            Pos_ds _Pos_ds = new Pos_ds();
            DataTable _dtHoaDonBanHang = _Pos_ds.tbl_HOADON;
            DataRow _drHoaDonBanHang;

            foreach (HangMuaPubLic _hm in _lstHangMua)
            {
                _drHoaDonBanHang = _dtHoaDonBanHang.NewRow();
                _drHoaDonBanHang["MaSP_SP"] = _hm.SanPham.MaSP_SP;
                _drHoaDonBanHang["TenSP_SP"] = _hm.SanPham.TenSP_SP;
                _drHoaDonBanHang["GiaBan_SP"] = _hm.GiaBan_HM;
                _drHoaDonBanHang["DVT_SP"] = _hm.SanPham.DVT_SP.TenDVT_DVT;
                _drHoaDonBanHang["SoLuong_SP"] = _hm.SoLuong;
                _drHoaDonBanHang["ChietKhau_SP"] = _hm.ChietKhauTienMat;
                _drHoaDonBanHang["ThanhTien_SP"] = _hm.ThanhTien;

                _dtHoaDonBanHang.Rows.Add(_drHoaDonBanHang);
            }
            _hoadon.TongSoLuongSP = _lstHangMua.Sum(item => item.SoLuong);

            HoaDonBanLe_UPresentation wpf_HoaDon = new HoaDonBanLe_UPresentation();
            wpf_HoaDon._status_para = "Bản sao [" + DateTime.Today.ToString("ddMMyy") + "]";
            wpf_HoaDon._dtHoaDon = _dtHoaDonBanHang;
            wpf_HoaDon._hoaDon = _hoadon;
            wpf_HoaDon.ShowDialog();

        }
    }//End class
}

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
using System.ComponentModel;

namespace Presentation.UserControls
{
    /// <summary>
    /// Interaction logic for ThietLapHeThongUPresentation.xaml
    /// </summary>
    public partial class ThietLapHeThongUPresentation : UserControl
    {
        //Khai báo
        BackgroundWorker _worker;
        ThietLapHeThongPublic _thietLap;
        public event EventHandler _CapNhatHienThi;

        public ThietLapHeThongUPresentation()
        {
            InitializeComponent();
        }

        //Loaded
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            HienThi();
        }

        //Hiển thị
        private void HienThi()
        {
            bdProgress.Visibility = System.Windows.Visibility.Visible;

            _worker = new BackgroundWorker();
            _worker.DoWork += (obj, ea) => HienThi_dowor();
            _worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(HienThi_complete);
            _worker.RunWorkerAsync();
        }

        private void HienThi_dowor()
        {
            _thietLap = ThietLapHeThongBusiness.LayThietLapHeThong();
        }

        private void HienThi_complete(object sender, RunWorkerCompletedEventArgs e)
        {
            bdProgress.Visibility = System.Windows.Visibility.Hidden;

            //Hiển thị
            txtTenCuaHang.Text = _thietLap.TenCuaHang;
            txtDiaChi.Text = _thietLap.DiaChi;
            txtSDT.Text = _thietLap.SDT;
            txtMucQuyDoi.Text = _thietLap.MucQuyDoiDiem.ToString();

            btnVoucher.IsChecked = _thietLap.Voucher;
            btnMaGiaGia.IsChecked = _thietLap.MaGiamGia;
            btnTichDiem.IsChecked = _thietLap.CongDiemKhachHang;
            btnCkHoaDon.IsChecked = _thietLap.ChietKhauHoaDon;
            btnCkSanPham.IsChecked = _thietLap.ChietKhauSanPham;
            btnKiemTraGiaNhap.IsChecked = _thietLap.KiemTraGiaNhap;
        }

        //Nút Lưu
        private void btnLuu_Click(object sender, RoutedEventArgs e)
        {
            //Kiểm tra dữ liệu
            if (!KiemTraDuLieu())
                return;

            //Cập nhật
            ThietLapHeThongPublic _SuaThietLap = new ThietLapHeThongPublic();
            _SuaThietLap.TenCuaHang = txtTenCuaHang.Text.Trim();
            _SuaThietLap.SDT = txtSDT.Text.Trim();
            _SuaThietLap.DiaChi = txtDiaChi.Text.Trim();
            _SuaThietLap.Voucher = btnVoucher.IsChecked.Value;
            _SuaThietLap.MaGiamGia = btnMaGiaGia.IsChecked.Value;
            _SuaThietLap.MucQuyDoiDiem = Convert.ToInt32(txtMucQuyDoi.Text.Trim());
            _SuaThietLap.CongDiemKhachHang = btnTichDiem.IsChecked.Value;
            _SuaThietLap.ChietKhauHoaDon = btnCkHoaDon.IsChecked.Value;
            _SuaThietLap.ChietKhauSanPham = btnCkSanPham.IsChecked.Value;
            _SuaThietLap.KiemTraGiaNhap = btnKiemTraGiaNhap.IsChecked.Value;

            ThietLapHeThongBusiness.CapNhatThietLapHeThong(_SuaThietLap);
            _thietLap = ThietLapHeThongBusiness.LayThietLapHeThong();
            HienThi();

            MessageBox.Show("Lưu thiết lập thành công.");

            EventHandler _eh = _CapNhatHienThi;
            if (_eh != null)
                _eh(this, e);
        }

        //Kiểm tra dữ liệu
        private bool KiemTraDuLieu()
        {
            //Tên cửa hàng
            string _tenCuaHang = txtTenCuaHang.Text.Trim();
            if (String.IsNullOrEmpty(_tenCuaHang))
            {
                lbWarning.Visibility = System.Windows.Visibility.Visible;
                lbWarning.Content = "Tên cửa hàng không trống.";
                txtTenCuaHang.Focus();
                return false;
            }

            if (_tenCuaHang.Length > 100)
            {
                lbWarning.Visibility = System.Windows.Visibility.Visible;
                lbWarning.Content = "Tên cửa hàng không quá 100 ký tự.";
                txtTenCuaHang.Focus();
                txtTenCuaHang.SelectAll();
                return false;
            }

            //Địa chỉ
            string _diaChi = txtDiaChi.Text.Trim();
            if (String.IsNullOrEmpty(_diaChi))
            {
                lbWarning.Visibility = System.Windows.Visibility.Visible;
                lbWarning.Content = "Địa chỉ không để trống.";
                txtDiaChi.Focus();
                return false;
            }

            if (_diaChi.Length > 200)
            {
                lbWarning.Visibility = System.Windows.Visibility.Visible;
                lbWarning.Content = "Địa chỉ không quá 200 ký tự.";
                txtDiaChi.Focus();
                txtDiaChi.SelectAll();
                return false;
            }

            //Số điện thoại
            string _sdt = txtSDT.Text;
            if (String.IsNullOrEmpty(_sdt))
            {
                lbWarning.Visibility = System.Windows.Visibility.Visible;
                lbWarning.Content = "Nhập số điện thoại.";
                txtSDT.Focus();
                return false;
            }

            string _strKiemTraSDT = @"^([0-9.]{1,11})$";
            if (!System.Text.RegularExpressions.Regex.IsMatch(_sdt, _strKiemTraSDT))
            {
                lbWarning.Visibility = System.Windows.Visibility.Visible;
                lbWarning.Content = "Số điện thoại không hợp lệ.";
                txtSDT.Focus();
                txtSDT.SelectAll();
                return false;
            }

            //Quy đổi điểm
            string _quyDoiDiem = txtMucQuyDoi.Text.Trim();
            if (String.IsNullOrEmpty(_quyDoiDiem))
            {
                lbWarning.Visibility = System.Windows.Visibility.Visible;
                lbWarning.Content = "Nhập mức quy đổi điểm!";
                txtMucQuyDoi.Focus();
                return false;
            }

            lbWarning.Visibility = System.Windows.Visibility.Hidden;
            return true;
        }

        //Nhấn phím F1 - lưu
        protected override void OnPreviewKeyDown(KeyEventArgs e)
        {
            if (e.Key == Key.F1)
                btnLuu_Click(this, e);
            base.OnPreviewKeyDown(e);
        }

        //Nút đóng
        private void btnDong_Click(object sender, RoutedEventArgs e)
        {

        }

    }//End class
}

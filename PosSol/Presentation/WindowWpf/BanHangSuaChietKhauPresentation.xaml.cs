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

namespace Presentation.WindowWpf
{
    /// <summary>
    /// Interaction logic for BanHangSuaChietKhauPresentation.xaml
    /// </summary>
    public partial class BanHangSuaChietKhauPresentation : Window
    {
        //Khai báo
        public HoaDonPublic _hoaDon;
        public event EventHandler _SuaChietKhau;
        ThietLapHeThongPublic _thietLap = ThietLapHeThongBusiness.LayThietLapHeThong();

        public BanHangSuaChietKhauPresentation()
        {
            InitializeComponent();
            lbWarning.Visibility = System.Windows.Visibility.Hidden;
        }

        //wpf loaded
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                //Hiển thị thông tin
                if (String.IsNullOrEmpty(_hoaDon.KhachHang_HD.HoTen_KH))
                    lbTenKH.Content = "KHÁCH VÃNG LAI";
                else
                {
                    string _strPic = "../../Image/NhomKhachhang/" + _hoaDon.KhachHang_HD.NHK_KH.Anh_NKH;
                    if (System.IO.File.Exists(_strPic))
                    {
                        _strPic = System.IO.Path.GetFullPath(_strPic);
                        BitmapImage _bit = new BitmapImage(new Uri(_strPic));
                        picAnhNKH.Source = _bit;
                        picAnhNKH.ToolTip = _hoaDon.KhachHang_HD.NHK_KH.TenNKH_NKH + ": Chiết khấu " + _hoaDon.KhachHang_HD.NHK_KH.ChietKhau_NKH.ToString() + "% / Tổng hóa đơn.";
                    }
                    lbTenKH.Content = _hoaDon.KhachHang_HD.HoTen_KH;
                }

                lbTongTien.Content = UntilitiesBusiness.ThemDauPhay(_hoaDon.TongTien_HD.ToString());
                lbCkSP.Content = UntilitiesBusiness.ThemDauPhay(_hoaDon.TongCKSanPham.ToString());
                txtCkHoaDon.Text = UntilitiesBusiness.ThemDauPhay(_hoaDon.TongCKHoaDon.ToString());
                lbThanhTien.Content = UntilitiesBusiness.ThemDauPhay(_hoaDon.ThanhTien.ToString());

                txtCkHoaDon.Focus();
                txtCkHoaDon.SelectAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi:" + ex.Message);
            }
        }

        //txt chiết khấu textchanged
        private void txtCkHoaDon_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (KiemTraChietKhauHD())
                    TongTien();
            }
            catch (Exception)
            {
                return;
            }
        }
        //Kiểm tra chiết khấu hóa đơn nhập vào
        private bool KiemTraChietKhauHD()
        {
            string _strCkHoaDon = txtCkHoaDon.Text.Trim();
            if (String.IsNullOrEmpty(_strCkHoaDon))
            {
                txtCkHoaDon.Text = "0";
                txtCkHoaDon.Focus();
                txtCkHoaDon.SelectAll();
                return false;
            }

            string _strKiemTraCkHD = @"^([0-9]+[0-9,]*)$";
            if (!System.Text.RegularExpressions.Regex.IsMatch(_strCkHoaDon, _strKiemTraCkHD))
            {
                lbWarning.Visibility = System.Windows.Visibility.Visible;
                lbWarning.Content = "Nhập sai định dạng!";
                txtCkHoaDon.Focus();
                txtCkHoaDon.SelectAll();
                return false;
            }

            if (_strCkHoaDon.Length >= 2 && _strCkHoaDon.StartsWith("0"))
            {
                _strCkHoaDon = _strCkHoaDon.Remove(0, 1);
                txtCkHoaDon.Text = _strCkHoaDon;
                txtCkHoaDon.Focus();
                txtCkHoaDon.SelectionStart = txtCkHoaDon.Text.Length;
            }

            //Kiểm tra lượng chiết khấu có vượt mức không?
            int _TongTien = _hoaDon.TongTien_HD;
            int _TongCkSP = _hoaDon.TongCKSanPham;
            int _TongCKHD = Convert.ToInt32(UntilitiesBusiness.BoDauPhay(_strCkHoaDon));
            int _TongTienNhap = _hoaDon.TongTienNhap;

            if (_thietLap.KiemTraGiaNhap)
                if ((_TongTien - _TongCkSP - _TongCKHD) <= _TongTienNhap)
                {
                    lbWarning.Visibility = System.Windows.Visibility.Visible;
                    lbWarning.Content = "Vượt mức chiết khấu cho phép";
                    txtCkHoaDon.Text = UntilitiesBusiness.ThemDauPhay(_strCkHoaDon);
                    txtCkHoaDon.Focus();
                    txtCkHoaDon.SelectAll();
                    TongTien();
                    return false;
                }

            txtCkHoaDon.Text = UntilitiesBusiness.ThemDauPhay(_strCkHoaDon);
            txtCkHoaDon.SelectionStart = txtCkHoaDon.Text.Length;
            lbWarning.Visibility = System.Windows.Visibility.Hidden;
            return true;
        }
        //Tính tổng tiền
        private void TongTien()
        {
            int _tongTien = _hoaDon.TongTien_HD;
            int _tongCKSP = _hoaDon.TongCKSanPham;
            int _tongCkHD = Convert.ToInt32(UntilitiesBusiness.BoDauPhay(txtCkHoaDon.Text.Trim()));
            int _thanhTien = _tongTien - _tongCKSP - _tongCkHD;
            if (_thanhTien < 0)
            {
                _thanhTien = 0;
                txtCkHoaDon.Text = UntilitiesBusiness.ThemDauPhay((_tongTien - _tongCKSP).ToString());
            }

            lbThanhTien.Content = UntilitiesBusiness.ThemDauPhay(_thanhTien.ToString());
        }

        //txt chiết khấu keyup
        private void txtCkHoaDon_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                if (KiemTraChietKhauHD())
                    btnOk_Click(sender, e);
        }

        //Nút OK
        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            //Kiểm tra chiết khấu nhập vào
            if (!KiemTraChietKhauHD())
                return;
            //Lấy thông tin chiết khấu hóa đơn(Chiết khấu hóa đơn)
            _hoaDon.TongCKHoaDon = Convert.ToInt32(UntilitiesBusiness.BoDauPhay(txtCkHoaDon.Text.Trim()));

            //Gọi phương thức sửa
            EventHandler _eh = _SuaChietKhau;
            if (_eh != null)
                _eh(this, e);

            this.Close();
        }

        //Nút hủy
        private void btnHuy_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }//End class
}

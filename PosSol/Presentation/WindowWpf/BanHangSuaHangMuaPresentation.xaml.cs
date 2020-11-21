using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Public;
using Business;
using System.Data;


namespace Presentation.WindowWpf
{
    /// <summary>
    /// Interaction logic for BanHangSuaHangMuaPresentation.xaml
    /// </summary>
    public partial class BanHangSuaHangMuaPresentation : Window
    {
        //Khai báo
        public SanPhamPublic _sp;
        public event EventHandler _SuaSanPham;
        DataTable _dtSPSua;
        ThietLapHeThongPublic _thietLap = ThietLapHeThongBusiness.LayThietLapHeThong();

        public BanHangSuaHangMuaPresentation()
        {
            InitializeComponent();
            lbWarning.Visibility = System.Windows.Visibility.Hidden;
        }

        //wpf loaded
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //Lấy thông tin sp trong hệ thống
            _dtSPSua = BanHangBusiness.LaySpTheoMa(_sp.MaSP_SP).Tables[0];
            if (_dtSPSua.Rows.Count == 0)
            {
                MessageBox.Show("Lỗi: Không tìm thấy sp trong hệ thống!");
                this.Close();
            }

            //Hiển thị
            lbTenSP.Content = _sp.TenSP_SP;
            lbGiaBan.Content = _sp.GiaBan;
            lbDonVi.Content = _sp.DVT_SP.TenDVT_DVT;
            txtSoLuong.Text = _sp.SoLuong_SP.ToString();
            txtCKTienMat.Text = _sp.CKTienMat;
            txtSoLuong.Focus();
            txtSoLuong.SelectAll();

            //Bật tắt chiết khấu sản phẩm
            ThietLapHeThongPublic _thietLap = ThietLapHeThongBusiness.LayThietLapHeThong();
            txtCKTienMat.IsEnabled = _thietLap.ChietKhauSanPham;

            TongTien();
        }

        //Tổng tiền
        private void TongTien()
        {
            if (_sp == null)
                return;

            int _giaBan = Convert.ToInt32(UntilitiesBusiness.BoDauPhay(_sp.GiaBan));
            int _soLuong = Convert.ToInt32(txtSoLuong.Text.Trim());
            int _ckTienMat = Convert.ToInt32(UntilitiesBusiness.BoDauPhay(txtCKTienMat.Text.Trim()));

            int _TongTien = _giaBan * _soLuong;
            int _thanhTien = _TongTien - _ckTienMat;

            if (_thanhTien < 0)
            {
                _thanhTien = 0;
                txtCKTienMat.Text = UntilitiesBusiness.ThemDauPhay(_giaBan.ToString());
            }

            lbTongTien.Content = UntilitiesBusiness.ThemDauPhay(_TongTien.ToString());
            lbThanhTien.Content = UntilitiesBusiness.ThemDauPhay(_thanhTien.ToString());
        }

        //Số lượng textchange
        private void txtSoLuong_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtSoLuong == null || _sp == null)
                return;

            if (KiemTraSoLuong())
            {
                if (lbWarning != null)
                    lbWarning.Visibility = System.Windows.Visibility.Hidden;

                //Tính lại chiết khấu
                int _chietKhauTienMat = (int)(Convert.ToInt32(txtSoLuong.Text.Trim()) * (_sp.CKPhanTram_SP * Convert.ToInt32(UntilitiesBusiness.BoDauPhay(_sp.GiaBan)) / 100));
                txtCKTienMat.Text = UntilitiesBusiness.ThemDauPhay(_chietKhauTienMat.ToString());

                //Tính tổng
                TongTien();
            }
        }

        //Kiểm tra số lượng
        private bool KiemTraSoLuong()
        {
            if (_sp == null)
                return true;

            string _soLuong = txtSoLuong.Text.Trim();

            //Kiểm tra chính tả
            if (String.IsNullOrEmpty(_soLuong))
            {
                txtSoLuong.Text = "1";
                txtSoLuong.Focus();
                txtSoLuong.SelectAll();
                lbWarning.Visibility = System.Windows.Visibility.Hidden;
                return false;
            }

            //Số lượng bắt buộc lớn hơn 0


            string _strKiemTraSoLuong = @"^([1-9]{1}[0-9]{0,5})$";
            if (!System.Text.RegularExpressions.Regex.IsMatch(_soLuong.ToString(), _strKiemTraSoLuong))
            {
                lbWarning.Visibility = System.Windows.Visibility.Visible;
                lbWarning.Content = "Số lượng chỉ gồm số từ 1 - 99999";
                txtSoLuong.Focus();
                txtSoLuong.SelectAll();
                return false;
            }

            //Kiểm tra số lượng trong kho
            int _soLuongCon = Convert.ToInt32(_dtSPSua.Rows[0]["SoLuong_SP"].ToString());
            if (Convert.ToInt32(_soLuong) > _soLuongCon)
            {
                lbWarning.Visibility = System.Windows.Visibility.Visible;
                lbWarning.Content = "Trong kho chỉ còn: " + _soLuongCon.ToString() + " sản phẩm.";
                // txtSoLuong.Text = _soLuongCon.ToString();
                txtSoLuong.Focus();
                txtSoLuong.SelectAll();
                return false;
            }

            return true;
        }

        //txt số lượng KeyUp
        private void txtSoLuong_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                if (KiemTraSoLuong())
                {
                    txtCKTienMat.Focus();
                    txtCKTienMat.SelectAll();
                }
        }

        //txt chiết khấu tiền mặt textchange
        private void txtCKTienMat_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (_sp == null || lbWarning == null)
                return;

            //Kiểm tra chiết khấu nhập vào
            if (!KiemTraChietKhau())
                return;

            //Tính tiền
            TongTien();
        }

        //Kiểm tra chiết khấu nhập vào
        private bool KiemTraChietKhau()
        {
            string _chietKhauTienMat = txtCKTienMat.Text.Trim();

            if (String.IsNullOrEmpty(_chietKhauTienMat))
            {
                txtCKTienMat.Text = "0";
                txtCKTienMat.Focus();
                txtCKTienMat.SelectAll();
                return false;
            }
            string _kiemTrCKTienMat = @"^([0-9]+[0-9,]*)$";
            if (!System.Text.RegularExpressions.Regex.IsMatch(_chietKhauTienMat, _kiemTrCKTienMat))
            {
                lbWarning.Visibility = System.Windows.Visibility.Visible;
                lbWarning.Content = "Nhập sai định dạng!";
                txtCKTienMat.Focus();
                txtCKTienMat.SelectAll();
                return false;
            }

            if (_chietKhauTienMat.Length >= 2 && _chietKhauTienMat.StartsWith("0"))
            {
                _chietKhauTienMat = _chietKhauTienMat.Remove(0, 1);
                txtCKTienMat.Text = _chietKhauTienMat;
                txtCKTienMat.Focus();
                txtCKTienMat.SelectionStart = txtCKTienMat.Text.Length;
            }

            //So sánh với giá nhập
            int _giaBan = Convert.ToInt32(UntilitiesBusiness.BoDauPhay(_sp.GiaBan));
            int _giaNhap = Convert.ToInt32(UntilitiesBusiness.BoDauPhay(_sp.GiaNhap_SP));
            int _soLuong = Convert.ToInt32(txtSoLuong.Text.Trim());
            if (_thietLap.KiemTraGiaNhap)
                if (Convert.ToInt32(UntilitiesBusiness.BoDauPhay(_chietKhauTienMat)) > (_giaBan - _giaNhap) * _soLuong)
                {
                    lbWarning.Visibility = System.Windows.Visibility.Visible;
                    lbWarning.Content = "Vượt mức chiết khấu cho phép!";
                    txtCKTienMat.Text = UntilitiesBusiness.ThemDauPhay(_chietKhauTienMat);
                    txtCKTienMat.Focus();
                    txtCKTienMat.SelectAll();
                    TongTien();
                    return false;
                }

            txtCKTienMat.Text = UntilitiesBusiness.ThemDauPhay(_chietKhauTienMat);
            txtCKTienMat.SelectionStart = txtCKTienMat.Text.Length;
            lbWarning.Visibility = System.Windows.Visibility.Hidden;
            return true;
        }

        //txt chiết khấu tiền mặt keyup
        private void txtCKTienMat_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                if (KiemTraChietKhau())
                    btnOk_Click(sender, e);
        }

        //Nút hủy
        private void btnHuy_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        //Nút Ok
        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            //Kiểm tra số lượng
            if (!KiemTraSoLuong())
                return;
            //Kiểm tra chiết khấu tiền mặt
            if (!KiemTraChietKhau())
                return;
            //Lấy thông tin sửa mặt hàng(số lượng, chiết khấu tiền mặt)
            _sp.SoLuong_SP = Convert.ToInt32(txtSoLuong.Text.Trim());
            _sp.CKTienMat = txtCKTienMat.Text.Trim();

            //Gọi phương thức sửa 
            EventHandler _eh = _SuaSanPham;
            if (_eh != null)
                _eh(this, e);

            this.Close();
        }
    }//End class
}

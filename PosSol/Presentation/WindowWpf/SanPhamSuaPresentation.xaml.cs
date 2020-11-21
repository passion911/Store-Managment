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
using System.Data;
using Microsoft.Win32;

namespace Presentation.WindowWpf
{
    /// <summary>
    /// Interaction logic for SanPhamSuaPresentation.xaml
    /// </summary>
    public partial class SanPhamSuaPresentation : Window
    {
        //Khai báo
        public event EventHandler _SuaSanPham;
        public SanPhamPublic _sp = new SanPhamPublic();

        public SanPhamSuaPresentation()
        {
            InitializeComponent();
        }

        //Wpf loaded
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cboNCC.ItemsSource = SanPhamBusiness.LayNCC();
            cboDonVi.ItemsSource = SanPhamBusiness.LayDVT();
            cboNhomSP.ItemsSource = SanPhamBusiness.LayNSP();

            //Hiển thị
            txtMaSP.IsEnabled = false;
            txtMaSP.Text = _sp.MaSP_SP;
            txtTenSP.Text = _sp.TenSP_SP;
            cboNhomSP.SelectedValue = _sp.NSP_SP.MaNSP_NSP;
            cboNCC.SelectedValue = _sp.NCC_SP.MaNCC_NCC;
            txtGiaNhap.Text = UntilitiesBusiness.ThemDauPhay(_sp.GiaNhap_SP);
            txtGiaBanLe.Text = UntilitiesBusiness.ThemDauPhay(_sp.GiaBanLe_SP);
            txtGiaBanSi.Text = UntilitiesBusiness.ThemDauPhay(_sp.GiaBanSi_SP);
            cboDonVi.SelectedValue = _sp.DVT_SP.MaDVT_DVT;
            txtChietKhau.Text = _sp.CKPhanTram_SP.ToString();

            FlowDocument fDoc = new FlowDocument();
            fDoc.Blocks.Add(new Paragraph(new Run(_sp.GhiChu_SP)));
            rtxtGhiChu.Document = fDoc;

            if (System.IO.File.Exists(_sp.Anh_SP))
            {
                BitmapImage _bit = new BitmapImage(new Uri(_sp.Anh_SP));
                picSP.Source = _bit;
            }
        }

        //Nút hủy
        private void btnHuy_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        //Nút lưu
        private void btnLuu_Click(object sender, RoutedEventArgs e)
        {
            #region 1.Kiểm tra thông tin nhập vào
            if (!KiemTraGiaNhap())
                return;
            if (!KiemTraGiaBanLe())
                return;
            if (!KiemTraGiaBanSi())
                return;
            if (!KiemTraChietKhau())
                return;
            #endregion

            #region 2. Lấy thông tin
            // _sp.MaSP_SP = txtMaSP.Text.Trim();
            _sp.TenSP_SP = txtTenSP.Text.Trim().ToUpper();
            _sp.NSP_SP.MaNSP_NSP = cboNhomSP.SelectedValue.ToString();
            _sp.NCC_SP.MaNCC_NCC = cboNCC.SelectedValue.ToString();
            _sp.DVT_SP.MaDVT_DVT = cboDonVi.SelectedValue.ToString();
            _sp.GiaNhap_SP = txtGiaNhap.Text.Trim();
            _sp.GiaBanLe_SP = txtGiaBanLe.Text.Trim();
            _sp.GiaBanSi_SP = txtGiaBanSi.Text.Trim();
            _sp.CKPhanTram_SP = Convert.ToInt32(txtChietKhau.Text.Trim());
            rtxtGhiChu.SelectAll();
            _sp.GhiChu_SP = rtxtGhiChu.Selection.Text.Trim();
            #endregion

            #region 3. Gọi phương thức thêm mới sản phẩm
            EventHandler _eh = _SuaSanPham;
            if (_eh != null)
                _eh(this, e);
            this.Close();
            #endregion
        }

        //Nút chọn ảnh
        private void btnChonAnhSP_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog _open = new OpenFileDialog();
            _open.Filter = "Image files (*.png;*.jpeg;*.jpg)|*.png;*.jpeg;*.jpg|All files (*.*)|*.*";
            _open.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyComputer);
            if (_open.ShowDialog() == true)
            {
                _sp.Anh_SP = _open.FileName;
                BitmapImage bit = new BitmapImage(new Uri(_sp.Anh_SP));
                picSP.Source = bit;
            }
        }

        //Textchange
        private void txtGiaNhap_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                KiemTraGiaNhap();
            }
            catch (Exception)
            {
                return;
            }
        }

        //Kiểm tra giá nhập
        private bool KiemTraGiaNhap()
        {
            string _giaNhap = txtGiaNhap.Text.Trim();

            if (String.IsNullOrEmpty(_giaNhap))
            {
                txtGiaNhap.Text = "0";
                txtGiaNhap.Focus();
                txtGiaNhap.SelectAll();
                return false;
            }

            if (_giaNhap.Length > 13)
            {
                txtGiaNhap.Text = "0";
                txtGiaNhap.Focus();
                txtGiaNhap.SelectAll();
                return false;
            }

            string _strKiemTraGiaNhap = @"^([0-9]+[0-9,]*)$";
            if (!System.Text.RegularExpressions.Regex.IsMatch(_giaNhap, _strKiemTraGiaNhap))
            {
                lbWarning.Visibility = System.Windows.Visibility.Visible;
                lbWarning.Content = "Giá nhập sai định dạng!";
                txtGiaNhap.Focus();
                txtGiaNhap.SelectAll();
                return false;
            }

            if (_giaNhap.Length >= 2 && _giaNhap.StartsWith("0"))
            {
                _giaNhap = _giaNhap.Remove(0, 1);
                txtGiaNhap.Text = _giaNhap;
                txtGiaNhap.Focus();
                txtGiaNhap.SelectionStart = txtGiaNhap.Text.Length;
            }


            txtGiaNhap.Text = UntilitiesBusiness.ThemDauPhay(_giaNhap);
            txtGiaNhap.SelectionStart = txtGiaNhap.Text.Length;
            lbWarning.Visibility = System.Windows.Visibility.Hidden;
            return true;
        }

        private void txtGiaBanLe_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                KiemTraGiaBanLe();
            }
            catch (Exception)
            {
                return;
            }
        }

        //Kiểm tra giá bán lẻ
        private bool KiemTraGiaBanLe()
        {
            string _giaBanLe = txtGiaBanLe.Text.Trim();

            if (String.IsNullOrEmpty(_giaBanLe))
            {
                txtGiaBanLe.Text = "0";
                txtGiaBanLe.Focus();
                txtGiaBanLe.SelectAll();
                return false;
            }

            if (_giaBanLe.Length > 13)
            {
                txtGiaBanLe.Text = "0";
                txtGiaBanLe.Focus();
                txtGiaBanLe.SelectAll();
                return false;
            }

            string _strKiemTraGiaBanLe = @"^([0-9]+[0-9,]*)$";
            if (!System.Text.RegularExpressions.Regex.IsMatch(_giaBanLe, _strKiemTraGiaBanLe))
            {
                lbWarning.Visibility = System.Windows.Visibility.Visible;
                lbWarning.Content = "Giá bán lẻ sai định dạng!";
                txtGiaBanLe.Focus();
                txtGiaBanLe.SelectAll();
                return false;
            }

            if (_giaBanLe.Length >= 2 && _giaBanLe.StartsWith("0"))
            {
                _giaBanLe = _giaBanLe.Remove(0, 1);
                txtGiaBanLe.Text = _giaBanLe;
                txtGiaBanLe.Focus();
                txtGiaBanLe.SelectionStart = txtGiaBanLe.Text.Length;
            }


            txtGiaBanLe.Text = UntilitiesBusiness.ThemDauPhay(_giaBanLe);
            txtGiaBanLe.SelectionStart = txtGiaBanLe.Text.Length;
            lbWarning.Visibility = System.Windows.Visibility.Hidden;
            return true;
        }
        private void txtGiaBanSi_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                KiemTraGiaBanSi();
            }
            catch (Exception)
            {

                return;
            }
        }

        //Kiểm tra giá bán sỉ
        private bool KiemTraGiaBanSi()
        {
            string _giaBanSi = txtGiaBanSi.Text.Trim();

            if (String.IsNullOrEmpty(_giaBanSi))
            {
                txtGiaBanSi.Text = "0";
                txtGiaBanSi.Focus();
                txtGiaBanSi.SelectAll();
                return false;
            }

            if (_giaBanSi.Length > 13)
            {
                txtGiaBanSi.Text = "0";
                txtGiaBanSi.Focus();
                txtGiaBanSi.SelectAll();
                return false;
            }

            string _strKiemTraGiaBanSi = @"^([0-9]+[0-9,]*)$";
            if (!System.Text.RegularExpressions.Regex.IsMatch(_giaBanSi, _strKiemTraGiaBanSi))
            {
                lbWarning.Visibility = System.Windows.Visibility.Visible;
                lbWarning.Content = "Giá bán lẻ sai định dạng!";
                txtGiaBanSi.Focus();
                txtGiaBanSi.SelectAll();
                return false;
            }

            if (_giaBanSi.Length >= 2 && _giaBanSi.StartsWith("0"))
            {
                _giaBanSi = _giaBanSi.Remove(0, 1);
                txtGiaBanSi.Text = _giaBanSi;
                txtGiaBanSi.Focus();
                txtGiaBanSi.SelectionStart = txtGiaBanSi.Text.Length;
            }


            txtGiaBanSi.Text = UntilitiesBusiness.ThemDauPhay(_giaBanSi);
            txtGiaBanSi.SelectionStart = txtGiaBanSi.Text.Length;
            lbWarning.Visibility = System.Windows.Visibility.Hidden;
            return true;
        }

        //Kiểm tra chiết khấu
        private bool KiemTraChietKhau()
        {
            string _chietKhau = txtChietKhau.Text.Trim();
            if (String.IsNullOrEmpty(_chietKhau))
            {
                lbWarning.Visibility = System.Windows.Visibility.Visible;
                lbWarning.Content = "Nhập chiết khấu.";
                txtChietKhau.Focus();
                return false;
            }
            string _strKiemTraGiaChietKhau = @"^([0-9]*)$";
            if (!System.Text.RegularExpressions.Regex.IsMatch(_chietKhau, _strKiemTraGiaChietKhau))
            {
                lbWarning.Visibility = System.Windows.Visibility.Visible;
                lbWarning.Content = "Chiết khấu sai định dạng.";
                txtChietKhau.Focus();
                txtChietKhau.SelectAll();
                return false;
            }

            if (Convert.ToInt32(_chietKhau) > 100)
            {
                lbWarning.Visibility = System.Windows.Visibility.Visible;
                lbWarning.Content = "Chiết khấu không quá 100%";
                txtChietKhau.Focus();
                txtChietKhau.SelectAll();
                return false;
            }

            lbWarning.Visibility = System.Windows.Visibility.Hidden;
            return true;
        }
    }//End class
}

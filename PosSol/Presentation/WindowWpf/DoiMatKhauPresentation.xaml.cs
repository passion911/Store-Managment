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
    /// Interaction logic for DoiMatKhauPresentation.xaml
    /// </summary>
    public partial class DoiMatKhauPresentation : Window
    {
        //Khai báo
        public NhanVienPublic _nhanvien = new NhanVienPublic();

        public DoiMatKhauPresentation()
        {
            InitializeComponent();
        }

        //Nút lưu
        private void btnLuu_Click(object sender, RoutedEventArgs e)
        {
            //Kiểm tra dữ liệu
            if (!KiemTraDuLieu())
                return;
            string _matKhauMoi = UntilitiesBusiness.MaHoaMD5(txtMatKhauMoi.Password.Trim());
            if (DangNhapBusiness.DoiMatKhau(_nhanvien.MaNV_NV, _matKhauMoi))
            {
                MessageBox.Show("Đổi mật khẩu thành công.");
                this.Close();
            }
            else
            {
                lbWarning.Visibility = System.Windows.Visibility.Visible;
                lbWarning.Content = "Đổi mật khẩu thất bại.";
            }
        }

        //Kiểm tra 
        private bool KiemTraDuLieu()
        {
            string _matKhauCu = txtMatKhauCu.Password;
            string _matKhauMoi = txtMatKhauMoi.Password;
            string _nhaplaiMatKhauMoi = txtNhapLaiMatKhau.Password;

            if (String.IsNullOrEmpty(_matKhauCu))
            {
                lbWarning.Visibility = System.Windows.Visibility.Visible;
                lbWarning.Content = "Nhập mật khẩu cũ";
                txtMatKhauCu.Focus();
                return false;
            }

            if (String.IsNullOrEmpty(_matKhauMoi))
            {
                lbWarning.Visibility = System.Windows.Visibility.Visible;
                lbWarning.Content = "Nhập mật khẩu mới";
                txtMatKhauMoi.Focus();
                return false;
            }

            if (_matKhauMoi.Length < 6)
            {
                lbWarning.Visibility = System.Windows.Visibility.Visible;
                lbWarning.Content = "Độ dài tối thiểu 6 ký tự";
                txtMatKhauMoi.Focus();
                txtMatKhauMoi.SelectAll();
                return false;
            }

            if (String.IsNullOrEmpty(_nhaplaiMatKhauMoi))
            {
                lbWarning.Visibility = System.Windows.Visibility.Visible;
                lbWarning.Content = "Nhập lại mật khẩu mới.";
                txtNhapLaiMatKhau.Focus();
                return false;
            }

            if (!_matKhauMoi.Equals(_nhaplaiMatKhauMoi))
            {
                lbWarning.Visibility = System.Windows.Visibility.Visible;
                lbWarning.Content = "Xác nhận mật khẩu mới không khớp!";
                txtNhapLaiMatKhau.Focus();
                return false;
            }

            //kiểm tra có trùng mật khẩu cũ không
            if (!UntilitiesBusiness.MaHoaMD5(_matKhauCu).Equals(_nhanvien.MatKhau_NV))
            {
                lbWarning.Visibility = System.Windows.Visibility.Visible;
                lbWarning.Content = "Sai mật khẩu cũ.";
                txtMatKhauCu.Focus();
                return false;
            }

            lbWarning.Visibility = System.Windows.Visibility.Hidden;
            return true;
        }

        //Phím
        protected override void OnPreviewKeyDown(KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.F1:
                    btnLuu_Click(this, e);
                    break;
                case Key.Enter:
                    btnLuu_Click(this, e);
                    break;
                case Key.Escape:
                    btnHuy_Click(this, e);
                    break;
            }
            base.OnPreviewKeyDown(e);
        }

        //Loaded
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            txtMatKhauCu.Focus();
            lbWarning.Visibility = System.Windows.Visibility.Hidden;
        }

        //Nút hủy
        private void btnHuy_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }//End class
}

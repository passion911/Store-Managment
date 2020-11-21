using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Business;
using Presentation.WindowWpf;
using Public;
using DataAccess;

namespace Presentation.UserControls
{
    /// <summary>
    /// Interaction logic for DangNhapUPresentation.xaml
    /// </summary>
    public partial class DangNhapUPresentation : UserControl
    {
        //Khai báo
        public NhanVienPublic Nv;
        public event EventHandler DangNhap;
        
        public DangNhapUPresentation()
        {
            InitializeComponent();
            lbWarning.Visibility = Visibility.Hidden;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {

            txtTaiKhoan.Focus();
        }

        //txtTài khoản got focus
        private void txtTaiKhoan_GotFocus(object sender, RoutedEventArgs e)
        {
            //if (txtTaiKhoan.Text.Equals("Nhập mã...", StringComparison.OrdinalIgnoreCase))
            //{
            //    txtTaiKhoan.Text = string.Empty;
            //}
        }

        //txt Tài khoản lost focus
        private void txtTaiKhoan_LostFocus(object sender, RoutedEventArgs e)
        {
            //if (string.IsNullOrEmpty(txtTaiKhoan.Text))
            //{
            //    txtTaiKhoan.Text = "Nhập mã ...";
            //}
        }

        //Preview keydown Tài khoản
        private void txtTaiKhoan_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                txtMatKhau.Focus();
                txtMatKhau.SelectAll();
            }
        }

        //Preview keydown mật khẩu
        private void txtMatKhau_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                btnThemSP_Click(sender, e);
            }
        }

        //Nút đăng nhập
        private void btnThemSP_Click(object sender, RoutedEventArgs e)
        {
            //Kiểm tra mã nhân viên nhập vào
            if (!KiemTraMaNv())
                return;
            //Kiểm tra mật khẩu
            if (string.IsNullOrEmpty(txtMatKhau.Password))
            {
                lbWarning.Visibility = Visibility.Visible;
                lbWarning.Content = "Nhập mật khẩu...";
                txtMatKhau.Focus();
                return;
            }

            var maNv = txtTaiKhoan.Text;
            var matKhau = txtMatKhau.Password;
            //Kiểm tra đăng nhập
            var dtDangNhap = DangNhapBusiness.DangNhap(maNv, matKhau).Tables[0];
            if (dtDangNhap.Rows.Count > 0)//Đăng nhập thành công
            {
                //Lấy thông tin nhân viên
                Nv = new NhanVienPublic
                {
                    MaNV_NV = dtDangNhap.Rows[0]["EmpCode"].ToString(),
                    HoTen_NV = dtDangNhap.Rows[0]["FullName"].ToString(),
                    NgaySinh_NV = Convert.ToDateTime(dtDangNhap.Rows[0]["BirthDay"].ToString()),
                    GioiTinh_NV = dtDangNhap.Rows[0]["Gender"].ToString(),
                    DiaChi_NV = dtDangNhap.Rows[0]["AddressEmp"].ToString(),
                    SDT_NV = dtDangNhap.Rows[0]["PhoneNum"].ToString(),
                    //Anh_NV = dtDangNhap.Rows[0]["Anh_NV"].ToString(),
                    ID_Q = dtDangNhap.Rows[0]["ID_Q"].ToString(),
                    MatKhau_NV = dtDangNhap.Rows[0]["Password_Emp"].ToString()
                };


                //Gọi phương thức đăng nhập
                var eh = DangNhap;
                if (eh != null)
                    eh(this, e);
            }
            else//Sai mật khẩu
            {
                lbWarning.Visibility = Visibility.Visible;
                lbWarning.Content = "Sai mật khẩu";
            }

        }
        //Kiểm tra mã nhân viên
        private bool KiemTraMaNv()
        {
            var maNv = txtTaiKhoan.Text.Trim();
            if (string.IsNullOrEmpty(maNv))
            {
                lbWarning.Visibility = Visibility.Visible;
                lbWarning.Content = "Nhập vào mã nhân viên...";
                txtTaiKhoan.Focus();
                return false;
            }

            const string strKiemTraMaNv = @"^([a-zA-Z0-9._]*)$";
            if (!Regex.IsMatch(maNv, strKiemTraMaNv))
            {
                lbWarning.Visibility = Visibility.Visible;
                lbWarning.Content = "Mã nhân viên sai định dạng...";
                txtTaiKhoan.Focus();
                txtTaiKhoan.SelectAll();
                return false;
            }

            //Kiểm tra có mã nhân viên này không?
            if (!UntilitiesBusiness.CheckEist("Employee", "EmpCode", maNv))
            {
                lbWarning.Visibility = Visibility.Visible;
                lbWarning.Content = "Mã nhân viên không tồn tại...";
                txtTaiKhoan.Focus();
                txtTaiKhoan.SelectAll();
                return false;
            }

            lbWarning.Visibility = Visibility.Hidden;
            return true;
        }

        //textchange tài khoản
        private void txtTaiKhoan_TextChanged(object sender, TextChangedEventArgs e)
        {
            txtTaiKhoan.Text = txtTaiKhoan.Text.ToUpper();
            txtTaiKhoan.Focus();
            txtTaiKhoan.SelectionStart = txtTaiKhoan.Text.Length;
        }

        //Cấu hình kết nối
        private void btnCauHinhKetNoi_Click(object sender, RoutedEventArgs e)
        {
            KetnoiPresentation wpf = new KetnoiPresentation();
            wpf.ShowDialog();
        }
    }//End class
}

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
    /// Interaction logic for NhomKhachHangThemPresentation.xaml
    /// </summary>
    public partial class NhomKhachHangThemPresentation : Window
    {
        //KHAI BÁO
        public event EventHandler _ThemNhomKhachHang;
        public NhomKhachHangPublic _nkh = new NhomKhachHangPublic();
        public NhomKhachHangThemPresentation()
        {
            InitializeComponent();
            lbWarning.Visibility = System.Windows.Visibility.Hidden;
        }

        //LOADED
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _nkh.MaNKH_NKH = UntilitiesBusiness.GetNextID("tbl_NHOMKHACHHANG", "MaNKH_NKH", "NKH.", 3);
            _nkh.Diem_NKH = 0;
            _nkh.ChietKhau_NKH = 0;
            txtMaNKH.Text = _nkh.MaNKH_NKH;
            txtTenNKH.Focus();
            txtDiem.Text = _nkh.Diem_NKH.ToString();
            txtChietKhau.Text = _nkh.ChietKhau_NKH.ToString();
            cboIcon.ItemsSource = NhomKhachHangBusiness.LayAnhNKH();
        }

        //NÚT HỦY
        private void btnHuy_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        //NÚT LƯU
        private void btnLuu_Click(object sender, RoutedEventArgs e)
        {
            #region 1. Kiểm tra thông tin nhập vào
            if (!CheckInValidate())
                return;
            #endregion

            #region 2. Lấy thông tin
            _nkh.TenNKH_NKH = txtTenNKH.Text.Trim().ToUpper();
            _nkh.Diem_NKH = Convert.ToInt32(txtDiem.Text.Trim());
            _nkh.ChietKhau_NKH = Convert.ToInt32(txtChietKhau.Text.Trim());
            _nkh.Anh_NKH = cboIcon.SelectedValue.ToString();
            _nkh.DangDung_NKH = ckDangDung.IsChecked == true ? true : false;
            #endregion

            #region 3. Gọi phương thức thêm nhóm khách hàng
            EventHandler _eh = _ThemNhomKhachHang;
            if (_eh != null)
                _eh(this, e);
            this.Close();
            #endregion
        }

        //Kiểm tra thông tin
        private bool CheckInValidate()
        {
            //Tên nhóm khách hàng
            string _strTenNKH = txtTenNKH.Text.Trim();
            if (String.IsNullOrEmpty(_strTenNKH))
            {
                lbWarning.Visibility = System.Windows.Visibility.Visible;
                lbWarning.Content = "Nhập vào tên nhóm khách hàng";
                txtTenNKH.Focus();
                return false;
            }
            if (_strTenNKH.Length > 50)
            {
                lbWarning.Visibility = System.Windows.Visibility.Visible;
                lbWarning.Content = "Tên nhóm khách hàng không dài quá 50 kí tự";
                txtTenNKH.Focus();
                txtTenNKH.SelectAll();
                return false;
            }

            string _strChietKhau = txtChietKhau.Text.Trim();
            if (String.IsNullOrEmpty(_strTenNKH))
            {
                lbWarning.Visibility = System.Windows.Visibility.Visible;
                lbWarning.Content = "Nhập chiết khấu % cho nhóm khách hàng!";
                txtChietKhau.Focus();
                return false;
            }

            string _strKiemTraChietKhau = @"^([0-9]*)$";
            if (!System.Text.RegularExpressions.Regex.IsMatch(_strChietKhau, _strKiemTraChietKhau))
            {
                lbWarning.Visibility = System.Windows.Visibility.Visible;
                lbWarning.Content = "Nhập chiết khấu sai định dạng!";
                txtChietKhau.Focus();
                txtChietKhau.SelectAll();
                return false;
            }

            string _strDiem = txtDiem.Text.Trim();
            if (String.IsNullOrEmpty(_strDiem))
            {
                lbWarning.Visibility = System.Windows.Visibility.Visible;
                lbWarning.Content = "Nhập vào điểm cần lên nhóm!";
                txtDiem.Focus();
                return false;
            }

            string _strKiemTraDiem = @"^([0-9]*)$";
            if (!System.Text.RegularExpressions.Regex.IsMatch(_strDiem, _strKiemTraDiem))
            {
                lbWarning.Visibility = System.Windows.Visibility.Visible;
                lbWarning.Content = "Nhập điểm nhóm sai định dạng!";
                txtDiem.Focus();
                txtDiem.SelectAll();
                return false;
            }


            lbWarning.Visibility = System.Windows.Visibility.Hidden;
            return true;
        }


    }//End class
}

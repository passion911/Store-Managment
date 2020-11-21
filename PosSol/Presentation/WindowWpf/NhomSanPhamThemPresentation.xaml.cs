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

namespace Presentation.WindowWpf
{
    /// <summary>
    /// Interaction logic for NhomSanPhamThemPresentation.xaml
    /// </summary>
    public partial class NhomSanPhamThemPresentation : Window
    {
        //Khai bao
        public event EventHandler ThemNhomSanPham;
        public NhomSanPhamPublic nhomsanpham = new NhomSanPhamPublic();
        DataTable _dt = NhomSanPhamBusiness.DanhSachNhomSanPham().Tables[0];
        public NhomSanPhamThemPresentation()
        {
            InitializeComponent();
        }

        //Nút lưu - gọi phương thức thêm mới nhóm sản phẩm tại frm cha
        private void btnLuu_Click(object sender, RoutedEventArgs e)
        {
            #region 1. Kiểm tra thông tin nhập vào
            if (!CheckValid())
                return;
            #endregion

            #region 2. Lấy thông tin nhập vào
            nhomsanpham.MaNSP_NSP = txtMaNhom.Text.Trim();
            nhomsanpham.TenNSP_NSP = txtTenNhom.Text.Trim();
            nhomsanpham.DangDung_NSP = ckDangDung.IsChecked.Value;
            rtxtGhiChu.SelectAll();
            nhomsanpham.GhiChu_NSP = rtxtGhiChu.Selection.Text.Trim();
            #endregion

            #region 3. Chạy sự kiện thêm nhóm sp
            EventHandler eh = ThemNhomSanPham;
            if (eh != null)
                eh(this, e);
            this.Close();
            #endregion

        }

        //Check dữ liệu nhập vào
        private bool CheckValid()
        {
            string _strTen = txtTenNhom.Text.Trim();
            string _strMaNhom = txtMaNhom.Text.Trim();
            //Tên không rỗng
            if (_strTen.Equals(""))
            {
                lbWarning.Visibility = System.Windows.Visibility.Visible;
                lbWarning.Content = "Tên nhóm không để trống!";
                txtTenNhom.Focus();
                return false;
            }

            //Kiểm tra chính tả
            string _strKiemTra = @"^([^!@#%']*)$";
            if (!System.Text.RegularExpressions.Regex.IsMatch(txtTenNhom.Text.Trim(), _strKiemTra))
            {
                lbWarning.Visibility = System.Windows.Visibility.Visible;
                lbWarning.Content = "Tên nhóm sản phẩm không chứa ký tự đặc biệt";
                txtTenNhom.Focus();
                txtTenNhom.SelectAll();
                return false;
            }

            //Mã không rỗng
            if (_strMaNhom.Equals(""))
            {
                lbWarning.Visibility = System.Windows.Visibility.Visible;
                lbWarning.Content = "Mã nhóm không để trống!";
                txtMaNhom.Focus();
                return false;
            }

            //Check mã tồn tại
            if (UntilitiesBusiness.CheckEist("tbl_NHOMSANPHAM", "MaNSP_NSP", _strMaNhom))
            {
                lbWarning.Visibility = System.Windows.Visibility.Visible;
                lbWarning.Content = "Mã nhóm đã tồn tại!";
                txtMaNhom.SelectAll();
                txtMaNhom.SelectionStart = txtMaNhom.Text.Length;
                return false;
            }
            string _strKiemTraMa = @"^([a-zA-Z0-9._]*)$";
            if (!System.Text.RegularExpressions.Regex.IsMatch(_strMaNhom, _strKiemTraMa))
            {
                lbWarning.Visibility = System.Windows.Visibility.Visible;
                lbWarning.Content = "Mã nhóm không chưa ký tự đặc biệt.";
                txtMaNhom.SelectAll();
                txtMaNhom.SelectionStart = txtMaNhom.Text.Length;
                return false;
            }

            lbWarning.Visibility = System.Windows.Visibility.Hidden;
            return true;
        }
        private void btnHuy_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        //WPF loaded
        private void wpfThemNhomSanPham_Loaded(object sender, RoutedEventArgs e)
        {
            txtTenNhom.Focus();
            lbWarning.Visibility = System.Windows.Visibility.Hidden;
        }

        //Text change of txtTên
        private void txtTenNhom_TextChanged(object sender, TextChangedEventArgs e)
        {
            //Sinh mã
            if (!txtTenNhom.Text.Equals(""))
            {
                //Kiểm tra chính tả
                string _strKiemTra = @"^([^!@#%']*)$";
                if (!System.Text.RegularExpressions.Regex.IsMatch(txtTenNhom.Text.Trim(), _strKiemTra))
                {
                    lbWarning.Visibility = System.Windows.Visibility.Visible;
                    lbWarning.Content = "Tên nhóm sản phẩm không chứa ký tự đặc biệt";
                    txtTenNhom.Focus();
                    txtTenNhom.SelectAll();
                    return;
                }

                //Sinh mã
                txtMaNhom.Text = NhomSanPhamBusiness.AutoGenerateIDinInputString(_dt, txtTenNhom.Text.Trim());
            }
            else
                txtMaNhom.Text = "";
        }
    }//end class
}

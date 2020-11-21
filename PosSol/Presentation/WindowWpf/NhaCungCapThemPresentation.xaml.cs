using System;
using System.Windows;
using Public;
using Business;

namespace Presentation.WindowWpf
{
    /// <summary>
    /// Interaction logic for NhaCungCapThemPresentation.xaml
    /// </summary>
    public partial class NhaCungCapThemPresentation : Window
    {
        //KHAI BÁO
        public event EventHandler _ThemNCC;
        public NhaCungCapPublic _NCC = new NhaCungCapPublic();

        public NhaCungCapThemPresentation()
        {
            InitializeComponent();
        }

        //NÚT LƯU
        private void btnLuu_Click(object sender, RoutedEventArgs e)
        {
            #region 1. Kiểm tra thông tin nhập vào
            if (!KiemTra())
                return;
            #endregion

            #region 2. Lấy thông tin
            _NCC.MaNCC_NCC = txtMaNCC.Text.Trim();
            _NCC.TenNCC_NCC = txtTenNCC.Text.Trim();
            rtxtGhiChu.SelectAll();
            _NCC.GhiChu_NCC = rtxtGhiChu.Selection.Text.Trim();
            #endregion

            #region 3. Gọi phương thức thêm nhà cung cấp
            EventHandler eh = _ThemNCC;
            if (eh != null)
                eh(this, e);
            this.Close();
            #endregion
        }

        //Loaded
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            txtMaNCC.Focus();
        }

        //Kiểm tra dữ liệu
        private bool KiemTra()
        {
            string _strMa = txtMaNCC.Text.Trim();
            if (String.IsNullOrEmpty(_strMa))
            {
                txtMaNCC.Focus();
                MessageBox.Show("Nhập mã nhà cung cấp");
                return false;
            }

            string _strKiemTraMa = @"^([a-zA-Z0-9.]*)$";
            if (!System.Text.RegularExpressions.Regex.IsMatch(_strMa, _strKiemTraMa))
            {
                txtMaNCC.Focus();
                MessageBox.Show("Mã nhà cung cấp không chứa kí tự đặc biệt.");
                txtMaNCC.SelectAll();
                return false;
            }

            string _strTen = txtTenNCC.Text.Trim();
            if (String.IsNullOrEmpty(_strTen))
            {
                MessageBox.Show("Nhập tên nhà cung cấp.");
                txtTenNCC.Focus();
                return false;
            }

            return true;
        }
    }//END CLASS
}

using System;
using System.Windows;
using Public;
using Business;

namespace Presentation.WindowWpf
{
    /// <summary>
    /// Interaction logic for DonViTinhThemPresentation.xaml
    /// </summary>
    public partial class DonViTinhThemPresentation : Window
    {
        //KHAI BÁO
        public event EventHandler _ThemDonViTinh;
        public DonViTinhPublic _dvt = new DonViTinhPublic();

        public DonViTinhThemPresentation()
        {
            InitializeComponent();
        }

        //NÚT THÊM (LƯU)
        private void btnThem_Click(object sender, RoutedEventArgs e)
        {
            #region 1. Kiểm tra thông tin
            if (!KiemTra())
                return;
            #endregion

            #region 2. Lấy thông tin
            _dvt.MaDVT_DVT = txtMaDVT.Text;
            _dvt.TenDVT_DVT = txtTenDVT.Text;
            _dvt.DangDung_DVT = ckDangDung.IsChecked == true ? true : false;
            #endregion

            #region 3. Gọi phương thức thêm đơn vị tính
            EventHandler _eh = _ThemDonViTinh;
            if (_eh != null)
                _eh(this, e);
            this.Close();
            #endregion
        }

        //Kiểm tra thông tin
        private bool KiemTra()
        {
            string _strMa = txtMaDVT.Text.Trim();
            if (String.IsNullOrEmpty(_strMa))
            {
                MessageBox.Show("Nhập mã đơn vị tính.");
                txtMaDVT.Focus();
                return false;
            }
            string _strKiemTraMa = @"^([A-Za-z0-9.]*)$";
            if (!System.Text.RegularExpressions.Regex.IsMatch(_strMa, _strKiemTraMa))
            {
                MessageBox.Show("Mã đơn vị tính không chứa kí tự đặc biệt.");
                txtMaDVT.Focus();
                txtMaDVT.SelectAll();
                return false;
            }

            if (UntilitiesBusiness.CheckEist("tbl_DONVITINH", "MaDVT_DVT", _strMa))
            {
                MessageBox.Show("Mã đơn vị tính đã tồn tại.");
                txtMaDVT.Focus();
                txtMaDVT.SelectAll();
                return false;
            }

            string _strTenDVT = txtTenDVT.Text.Trim();
            if (String.IsNullOrEmpty(_strTenDVT))
            {
                MessageBox.Show("Nhập tên đơn vị tính.");
                txtTenDVT.Focus();
                return false;
            }
            return true;
        }

        //wpf loaded
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            txtMaDVT.Focus();
        }

        //Nút hủy
        private void btnHuy_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


    }//End class
}

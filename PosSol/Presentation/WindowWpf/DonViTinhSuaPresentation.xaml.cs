using System;
using System.Windows;
using Public;

namespace Presentation.WindowWpf
{
    /// <summary>
    /// Interaction logic for DonViTinhSuaPresentation.xaml
    /// </summary>
    public partial class DonViTinhSuaPresentation : Window
    {
        //KHAI BÁO
        public event EventHandler _SuaDonViTinh;
        public DonViTinhPublic _dvt = new DonViTinhPublic();

        public DonViTinhSuaPresentation()
        {
            InitializeComponent();
        }

        //PHƯƠNG THỨC HIỂN THỊ THÔNG TIN LÊN CÁC CONTROL
        void HienThi()
        {
            txtMaDVT.Text = _dvt.MaDVT_DVT;
            txtTenDVT.Text = _dvt.TenDVT_DVT;
            ckDangDung.IsChecked = _dvt.DangDung_DVT;
        }

        //NÚT SỬA
        private void btnThem_Click(object sender, RoutedEventArgs e)
        {
            #region 1. Kiểm tra thông tin nhập vào
            if (String.IsNullOrEmpty(txtTenDVT.Text.Trim()))
            {
                txtTenDVT.Focus();
                MessageBox.Show("Tên đơn vị tính không để trống.");
                return;
            }
            #endregion

            #region 2. Lấy thông tin vừa nhập vào
            //_dvt.MaDVT_DVT = txtMaDVT.Text;
            _dvt.TenDVT_DVT = txtTenDVT.Text;
            _dvt.DangDung_DVT = ckDangDung.IsChecked == true ? true : false;
            #endregion

            #region 3. Gọi phương thức sửa đơn vị tính
            EventHandler _eh = _SuaDonViTinh;
            if (_eh != null)
                _eh(this, e);
            this.Close();
            #endregion
        }

        //LOADED
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            HienThi();
            txtTenDVT.SelectAll();
            txtTenDVT.Focus();
        }

        //Nút hủy
        private void btnHuy_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }//END CLASS
}

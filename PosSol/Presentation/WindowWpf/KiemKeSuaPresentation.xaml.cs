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

namespace Presentation.WindowWpf
{
    /// <summary>
    /// Interaction logic for KiemKeSuaPresentation.xaml
    /// </summary>
    public partial class KiemKeSuaPresentation : Window
    {
        //Khai báo
        public SanPhamPublic _sp;
        public event EventHandler _SuaSoLuong;
        public KiemKeSuaPresentation()
        {
            InitializeComponent();
        }

        //Nút hủy
        private void btnHuy_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        //wpf loaded
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //Hiển thị thông tin sản phẩm
            lbMaSP.Content = _sp.MaSP_SP;
            lbTenSP.Content = _sp.TenSP_SP;
            lbSoLuong.Content = _sp.SoLuong_SP;
            txtSoLuong.Focus();
        }

        //Sự kiện phím
        protected override void OnPreviewKeyDown(KeyEventArgs e)
        {
            if (e.Key == Key.F1)
            {
                btnLuu_Click(this, e);
            }
            if (e.Key == Key.Escape)
                btnHuy_Click(this, e);
            base.OnPreviewKeyDown(e);
        }

        //Nút lưu
        private void btnLuu_Click(object sender, RoutedEventArgs e)
        {
            //Kiểm tra số lượng nhập vào
            if (!KiemTraSoLuong())
                return;

            //Lấy thông tin
            _sp.SoLuong_SP = Convert.ToInt32(txtSoLuong.Text.Trim());

            //Gọi phương thức sửa số lượng
            EventHandler _eh = _SuaSoLuong;
            if (_eh != null)
                _eh(this, e);
            this.Close();
        }
        //Kiểm tra số lượng
        private bool KiemTraSoLuong()
        {
            string _soLuong = txtSoLuong.Text.Trim();
            if (String.IsNullOrEmpty(_soLuong))
            {
                MessageBox.Show("Nhập vào số lượng sản phẩm muốn sửa!");
                txtSoLuong.Focus();
                return false;
            }
            string _strKiemTraSoLuong = @"^([0-9]*)$";
            if (!System.Text.RegularExpressions.Regex.IsMatch(_soLuong, _strKiemTraSoLuong))
            {
                MessageBox.Show("Chỉ nhập số!");
                txtSoLuong.Focus();
                txtSoLuong.SelectAll();
                return false;
            }

            return true;
        }

        //txt preview key down
        private void txtSoLuong_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                btnLuu_Click(this, e);
        }
    }//End class
}

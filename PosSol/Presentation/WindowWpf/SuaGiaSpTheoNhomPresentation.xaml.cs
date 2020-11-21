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
using Business;

namespace Presentation.WindowWpf
{
    /// <summary>
    /// Interaction logic for SuaGiaSpTheoNhomPresentation.xaml
    /// </summary>
    public partial class SuaGiaSpTheoNhomPresentation : Window
    {

        //Khai báo
        public string _MaNSP;
        public string _TenNSP;
        public event EventHandler _SuaGia;
        public string _gia;

        public SuaGiaSpTheoNhomPresentation()
        {
            InitializeComponent();
        }

        //loaded
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            lbTenNhomSanPham.Content = _TenNSP;
            lbTenNhomSanPham.ToolTip = _TenNSP;
            txtSuaGia.Focus();
        }

        //txt textchange
        private void txtSuaGia_TextChanged(object sender, TextChangedEventArgs e)
        {
            string _gia = txtSuaGia.Text;
            if (String.IsNullOrEmpty(_gia))
            {
                txtSuaGia.Text = "0";
                txtSuaGia.SelectAll();
                return;
            }

            if (_gia.Length > 15)
            {
                txtSuaGia.Text = "0";
                txtSuaGia.SelectAll();
                return;
            }

            txtSuaGia.Text = UntilitiesBusiness.ThemDauPhay(_gia);
            txtSuaGia.Focus();
            txtSuaGia.SelectionStart = txtSuaGia.Text.Length;
        }

        //Nút hủy
        private void btnHuy_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        //Nút sửa giá
        private void btnSuaGia_Click(object sender, RoutedEventArgs e)
        {
            //Kiểm tra giá bán
            string _giaban = txtSuaGia.Text;
            if (String.IsNullOrEmpty(_giaban))
            {
                lbWarning.Visibility = System.Windows.Visibility.Visible;
                lbWarning.Content = "Nhập giá bán.";
                txtSuaGia.Focus();
                return;
            }

            string _strKiemTra = @"^([0-9,]*)$";
            if (!System.Text.RegularExpressions.Regex.IsMatch(_giaban, _strKiemTra))
            {
                lbWarning.Visibility = System.Windows.Visibility.Visible;
                lbWarning.Content = "Giá bán sai định dạng.";
                txtSuaGia.Focus();
                txtSuaGia.SelectAll();
                return;
            }

            _gia = _giaban;
            EventHandler _eh = _SuaGia;
            if (_eh != null)
                _eh(this, e);
            this.Close();
        }

        //txt preiew keydown
        private void txtSuaGia_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                btnSuaGia_Click(sender, e);
        }

    }//End class
}

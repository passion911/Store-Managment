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
    /// Interaction logic for NhomSanPhamSuaPresentation.xaml
    /// </summary>
    public partial class NhomSanPhamSuaPresentation : Window
    {
        public NhomSanPhamPublic nhomsanpham = new NhomSanPhamPublic();
        public event EventHandler SuaNhomSanPham;

        public NhomSanPhamSuaPresentation()
        {
            InitializeComponent();
            lbWarning.Visibility = System.Windows.Visibility.Hidden;
        }

        //Nút lưu
        private void btnLuu_Click(object sender, RoutedEventArgs e)
        {
            //Kiểm tra chuỗi 
            if (!Validate())
                return;

            //Lấy thông tin
            nhomsanpham.TenNSP_NSP = txtTenNhom.Text;
            nhomsanpham.DangDung_NSP = (ckDangDung.IsChecked == true) ? true : false;
            rtxtGhiChu.SelectAll();
            nhomsanpham.GhiChu_NSP = rtxtGhiChu.Selection.Text.Trim();

            EventHandler eh = SuaNhomSanPham;
            if (eh != null)
                eh(this, e);
            this.Close();
        }

        //Check validate
        private bool Validate()
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

            lbWarning.Visibility = System.Windows.Visibility.Hidden;
            return true;
        }

        //Load dữ liệu
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            txtTenNhom.Text = nhomsanpham.TenNSP_NSP;
            txtTenNhom.Focus();
            txtTenNhom.SelectionStart = txtTenNhom.Text.Length;
            ckDangDung.IsChecked = nhomsanpham.DangDung_NSP;

            txtMaNhom.Text = nhomsanpham.MaNSP_NSP;
            txtMaNhom.IsEnabled = false;

            FlowDocument fDoc = new FlowDocument();
            fDoc.Blocks.Add(new Paragraph(new Run(nhomsanpham.GhiChu_NSP.Trim())));
            rtxtGhiChu.Document = fDoc;
        }

        //Nút hủy
        private void btnHuy_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }//end class
}

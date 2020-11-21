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
    /// Interaction logic for KhachHangSuaPresentation.xaml
    /// </summary>
    public partial class KhachHangSuaPresentation : Window
    {
        //KHAI BÁO
        public event EventHandler _SuaKhachhang;
        public KhachHangPublic _kh = new KhachHangPublic();

        public KhachHangSuaPresentation()
        {
            InitializeComponent();
        }

        //Nút lưu
        private void btnLuu_Click(object sender, RoutedEventArgs e)
        {
            #region 1. Kiểm tra thông tin nhập vào
            if (!KiemTraThongTin())
                return;
            #endregion

            #region 2. Lấy thông tin
            _kh.HoTen_KH = txtTenKH.Text.Trim().ToUpper();
            _kh.GioiTinh_KH = rdNam.IsChecked == true ? "NAM" : "NỮ";
            _kh.NgaySinh_KH = dtNgaySinh.SelectedDate.Value;
            _kh.Email_KH = txtEmail.Text.Trim();
            _kh.NHK_KH.MaNKH_NKH = cboNhomKH.SelectedValue.ToString();
            _kh.DiemTichLuy_KH = Convert.ToInt32(txtDiemTichLuy.Text);
            _kh.SoLanMuaHang_KH = Convert.ToInt32(txtSoLanMua.Text);
            _kh.SDT_KH = txtSDT.Text.Trim();
            rtxtGhiChu.SelectAll();
            _kh.GhiChu = rtxtGhiChu.Selection.Text.Trim();
            _kh.TuDongLenNhom_KH = ckLenNhomTuDong.IsChecked.Value;
            _kh.DangDung_KH = ckDangDung.IsChecked.Value;
            #endregion

            #region 3. Gọi phương thức thêm mới khách hàng
            EventHandler _eh = _SuaKhachhang;
            if (_eh != null)
                _eh(this, e);
            this.Close();
            #endregion
        }

        //Kiểm tra thông tin nhập vào
        private bool KiemTraThongTin()
        {
            string _TenKH = txtTenKH.Text.Trim();
            if (String.IsNullOrEmpty(_TenKH))
            {
                MessageBox.Show("Nhập tên khách hàng");
                txtTenKH.Focus();
                return false;
            }

            if (_TenKH.Length > 35)
            {
                MessageBox.Show("Tên khách hàng không quá 35 kí tự");
                txtTenKH.Focus();
                txtTenKH.SelectionStart = txtTenKH.Text.Length;
                return false;
            }

            return true;
        }
        //Nút hủy
        private void btnHuy_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        //WPF loaded
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //Hiển thị
            txtbMaKH.Text = _kh.MaKH_KH;
            txtTenKH.Text = _kh.HoTen_KH;
            
            rdNam.IsChecked = _kh.GioiTinh_KH == "NAM" ? true : false;
            rdNu.IsChecked = !rdNam.IsChecked;

            dtNgaySinh.SelectedDate = _kh.NgaySinh_KH;
            txtEmail.Text = _kh.Email_KH;

            cboNhomKH.ItemsSource = KhachHangBusiness.LayNhomKhachHang();
            cboNhomKH.SelectedValue = _kh.NHK_KH.MaNKH_NKH;
            txtSDT.Text = _kh.SDT_KH;

            FlowDocument fDoc = new FlowDocument();
            fDoc.Blocks.Add(new Paragraph(new Run(_kh.GhiChu.Trim())));
            rtxtGhiChu.Document = fDoc;

            txtSoLanMua.Text = _kh.SoLanMuaHang_KH.ToString();
            txtDiemTichLuy.Text = _kh.DiemTichLuy_KH.ToString();
            ckLenNhomTuDong.IsChecked = _kh.TuDongLenNhom_KH;
            ckDangDung.IsChecked = _kh.DangDung_KH;
        }
    }//End class
}

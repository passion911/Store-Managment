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
    /// Interaction logic for KhachHangThemPresentation.xaml
    /// </summary>
    public partial class KhachHangThemPresentation : Window
    {
        //KHAI BÁO
        public event EventHandler _ThemKhachHang;
        public KhachHangPublic _kh = new KhachHangPublic();

        public KhachHangThemPresentation()
        {
            InitializeComponent();
        }

        //WPF LOADED
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _kh.MaKH_KH = UntilitiesBusiness.GetNextID("tbl_KHACHHANG", "MaKH_KH", "KH.", 5);
            _kh.DiemTichLuy_KH = 0;
            _kh.TuDongLenNhom_KH = true;

            //Hiển thị
            txtbMaKH.Text = _kh.MaKH_KH;
            txtTenKH.Focus();

            List<NhomKhachHangPublic> _lstNKH = KhachHangBusiness.LayNhomKhachHang();
            if (_lstNKH == null)
            {
                MessageBox.Show("Chưa có nhóm khách hàng nào. Hãy tạo nhóm khách hàng!");
                this.Close();
            }
            if (_lstNKH.Count==0)
            {
                MessageBox.Show("Chưa có nhóm khách hàng nào. Hãy tạo nhóm khách hàng!");
                this.Close();
            }
            cboNhomKH.ItemsSource = _lstNKH;
        }

        //Nút hủy
        private void btnHuy_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
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
            EventHandler _eh = _ThemKhachHang;
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
                lbWarning.Visibility = System.Windows.Visibility.Visible;
                lbWarning.Content = "Nhập tên khách hàng.";
                txtTenKH.Focus();
                return false;
            }

            if (_TenKH.Length > 35)
            {
                lbWarning.Visibility = System.Windows.Visibility.Visible;
                lbWarning.Content = "Tên khách hàng không quá 35 kí tự.";
                txtTenKH.Focus();
                txtTenKH.SelectionStart = txtTenKH.Text.Length;
                return false;
            }

            lbWarning.Visibility = System.Windows.Visibility.Hidden;
            return true;
        }
    }//End class
}

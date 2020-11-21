using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Business;
using System.Data;
using Public;
using Presentation.WindowWpf;
using Presentation.Report;

namespace Presentation.UserControls
{
    /// <summary>
    /// Interaction logic for KhachHangUPresentation.xaml
    /// </summary>
    public partial class KhachHangUPresentation : UserControl
    {
        //Khai báo
        DataTable _dtKhachHang;
        DataView _dvKhachHang;

        public KhachHangUPresentation()
        {
            InitializeComponent();
        }

        //UC LOADED
        private void ucKhachHang_Loaded(object sender, RoutedEventArgs e)
        {
            LoadDataToDataGrid();
        }

        //LOAD DATATO DATAGRID
        void LoadDataToDataGrid()
        {
            //cbo nhóm khách hàng
            cboNhomKhachHang.ItemsSource = KhachHangBusiness.LayNhomKhachHang2();
            cboNhomKhachHang.SelectedIndex = 0;

            //dg khách hàng
            DataTable _DtKH = KhachHangBusiness.DsKhachHang().Tables[0];
            for (int i = 0; i < _DtKH.Rows.Count; i++)
            {
                string _tenAnh = _DtKH.Rows[i]["Anh_NKH"].ToString();
                _DtKH.Rows[i]["Anh_NKH"] = LayAnhNhomKhachHang(_tenAnh);
            }

            _dtKhachHang = _DtKH;
            _dvKhachHang = new DataView(_dtKhachHang);
            dgKhachHang.ItemsSource = _dvKhachHang;
        }

        //Lấy đường dẫn ảnh nhóm khách hàng
        string LayAnhNhomKhachHang(string _tenAnh)
        {
            string _relativeImgPath = "../../Image/NhomKhachHang/" + _tenAnh;
            if (System.IO.File.Exists(_relativeImgPath))
                return System.IO.Path.GetFullPath("../../Image/NhomKhachHang/" + _tenAnh);
            return "no-image.jpg";
        }

        //Mouse double click
        private void dgNhomSanPham_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (dgKhachHang.RowDetailsVisibilityMode == DataGridRowDetailsVisibilityMode.Collapsed)
                dgKhachHang.RowDetailsVisibilityMode = DataGridRowDetailsVisibilityMode.VisibleWhenSelected;
            else
                dgKhachHang.RowDetailsVisibilityMode = DataGridRowDetailsVisibilityMode.Collapsed;
        }

        //Datagrid loading row
        private void dgKhachHang_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = (e.Row.GetIndex() + 1).ToString();
        }

        //Nút đóng
        private void btnDong_Click(object sender, RoutedEventArgs e)
        {
            (this.Parent as Grid).Children.Remove(this);
        }

        // Nút thêm 
        private void btnThemMoi_Click(object sender, RoutedEventArgs e)
        {
            KhachHangThemPresentation wpf = new KhachHangThemPresentation();
            wpf._ThemKhachHang += new EventHandler(ThemKhachHang);
            wpf.ShowDialog();
        }

        //Phương thức thêm khách hàng
        void ThemKhachHang(object sender, EventArgs e)
        {
            #region 1. Lấy thông tin
            KhachHangThemPresentation wpf = (KhachHangThemPresentation)sender;
            KhachHangPublic _kh = wpf._kh;
            #endregion

            #region 2. Lưu vào csdl
            if (KhachHangBusiness.ThemKhachHang(_kh))
                LoadDataToDataGrid();
            else
                MessageBox.Show("Thêm mới khách hàng thất bại");
            #endregion
        }

        //Nút sửa
        private void btnSua_Click(object sender, RoutedEventArgs e)
        {
            #region 1. Lấy thông tin
            DataRowView _drv = (DataRowView)dgKhachHang.SelectedItem;
            KhachHangPublic _kh = new KhachHangPublic();
            _kh.MaKH_KH = _drv["MaKH_KH"].ToString();
            _kh.HoTen_KH = _drv["HoTen_KH"].ToString();
            _kh.GioiTinh_KH = _drv["GioiTinh_KH"].ToString();
            _kh.NgaySinh_KH = Convert.ToDateTime(_drv["NgaySinh_KH"].ToString());
            _kh.Email_KH = _drv["Email_KH"].ToString();
            _kh.NHK_KH.MaNKH_NKH = _drv["Ma_NHK_KH"].ToString();
            _kh.DiemTichLuy_KH = Convert.ToInt32(_drv["DiemTichLuy_KH"].ToString());
            _kh.SoLanMuaHang_KH = Convert.ToInt32(_drv["SoLanMuaHang_KH"].ToString());
            _kh.SDT_KH = _drv["SDT_KH"].ToString();
            _kh.GhiChu = _drv["GhiChu_KH"].ToString();
            _kh.TuDongLenNhom_KH = (bool)_drv["TuDongLenNhom_KH"];
            _kh.DangDung_KH = (bool)_drv["DangDung_KH"];
            #endregion

            #region 2. Hiển thị wpf sửa
            KhachHangSuaPresentation wpf = new KhachHangSuaPresentation();
            wpf._kh = _kh;
            wpf._SuaKhachhang += new EventHandler(SuaKhachHang);
            wpf.ShowDialog();
            #endregion
        }

        //Phương thức sửa khách hàng
        void SuaKhachHang(object sender, EventArgs e)
        {
            #region 1. Lấy thông tin
            KhachHangSuaPresentation wpf = (KhachHangSuaPresentation)sender;
            KhachHangPublic _kh = wpf._kh;
            #endregion

            #region 2. Lưu vào csdl
            if (KhachHangBusiness.SuaKhachHang(_kh))
                LoadDataToDataGrid();
            else
                MessageBox.Show("Sửa thông tin khách hàng thất bại");
            #endregion
        }

        //Xóa sản phẩm
        private void btnXoa_Click(object sender, RoutedEventArgs e)
        {
            DataRowView _drv = (DataRowView)dgKhachHang.SelectedItem;
            string _MaKH = _drv["MaKH_KH"].ToString();

            if (KhachHangBusiness.XoaKhachHang(_MaKH))
                LoadDataToDataGrid();
            else
                MessageBox.Show("Thông tin khách hàng liên quan tới thông tin hóa đơn. Không thể xóa");
        }

        //cboNhomkhachhang selection change
        private void cboNhomKhachHang_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                _dvKhachHang.Sort = "MaKH_KH DESC";
                string _strFilter;
                if (cboNhomKhachHang.SelectedValue.ToString() != "")
                    _strFilter = "Ma_NHK_KH = '" + cboNhomKhachHang.SelectedValue.ToString() + "'";
                else
                    _strFilter = "Ma_NHK_KH LIKE '*'";
                _dvKhachHang.RowFilter = _strFilter;

                dgKhachHang.ItemsSource = _dvKhachHang;
            }
            catch (Exception)
            {
                return;
            }

        }

        //Nút tìm
        private void btnTimKiem_Click(object sender, RoutedEventArgs e)
        {
            //Kiểm tra dữ liệu nhập vào
            if (!KiemTraTimKiem())
                return;
            //Lọc theo giá trị tìm kiếm
            string _strFilter = "(MaKH_KH LIKE '%" + txtTimKiem.Text.Trim() + "%' OR HoTen_KH LIKE '%" + txtTimKiem.Text.Trim() + "%') AND Ma_NHK_KH LIKE '%" + cboNhomKhachHang.SelectedValue.ToString() + "%'";

            // string _strFilter = "MaKH_KH LIKE '%" + txtTimKiem.Text.Trim() + "%'";
            // _dvKhachHang = new DataView(_dtKhachHang, _strFilter, "MaKH_KH DESC", DataViewRowState.CurrentRows);
            _dvKhachHang.RowFilter = _strFilter;
            dgKhachHang.ItemsSource = _dvKhachHang;
        }

        //Kiểm tra tìm kiếm
        private bool KiemTraTimKiem()
        {
            string _strTimKiem = txtTimKiem.Text.Trim();
            if (String.IsNullOrEmpty(_strTimKiem))
            {
                lbWarning.Visibility = System.Windows.Visibility.Visible;
                lbWarning.Content = "Nhập vào mã hoặc tên khách hàng để tìm kiếm.";
                txtTimKiem.Focus();
                return false;
            }

            string _strKiemTraTimKiem = @"^([^'!*@#$%,]*)$";
            if (!System.Text.RegularExpressions.Regex.IsMatch(_strTimKiem, _strKiemTraTimKiem))
            {
                lbWarning.Visibility = System.Windows.Visibility.Visible;
                lbWarning.Content = "Giá trị tìm kiếm không chứa các kí tự đặc biệt.";
                txtTimKiem.Focus();
                txtTimKiem.SelectAll();
                return false;
            }

            lbWarning.Visibility = System.Windows.Visibility.Hidden;
            return true;
        }

        //Nút reset
        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            ucKhachHang_Loaded(sender, e);
        }

        //Nút in thẻ
        private void btnInThe_Click(object sender, RoutedEventArgs e)
        {
            DataRowView _drv = (DataRowView)dgKhachHang.SelectedItem;
            if(_drv == null)
            {
                MessageBox.Show("Chọn khách hàng.");
                return;
            }

            TheKhachHang_Presentation wpf = new TheKhachHang_Presentation();
            wpf._MaKH = _drv["MaKH_KH"].ToString();
            wpf.Show();
        }
    }//END CLASS
}

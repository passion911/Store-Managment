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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;
using Business;
using Public;
using System.IO;
using Presentation.WindowWpf;

namespace Presentation.UserControls
{
    /// <summary>
    /// Interaction logic for NhomKhachHangUPresentation.xaml
    /// </summary>
    public partial class NhomKhachHangUPresentation : UserControl
    {
        public NhomKhachHangUPresentation()
        {
            InitializeComponent();
        }

        //Loading row datagrid
        private void dgNhomKhachHang_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = (e.Row.GetIndex() + 1).ToString();
        }

        //Load datato datagrid
        void LoadDataToDataGrid()
        {
            DataTable _DtNKH = NhomKhachHangBusiness.DsNhomKhachHang().Tables[0];
            for (int i = 0; i < _DtNKH.Rows.Count; i++)
            {
                string _tenAnh = _DtNKH.Rows[i]["Anh_NKH"].ToString();
                _DtNKH.Rows[i]["Anh_NKH"] = LayAnhNhomKhachHang(_tenAnh);
            }
            dgNhomKhachHang.ItemsSource = _DtNKH.DefaultView;
        }

        //Lấy đường dẫn ảnh nhóm khách hàng
        string LayAnhNhomKhachHang(string _tenAnh)
        {
            string _relativeImgPath = "../../Image/NhomKhachHang/" + _tenAnh;
            if (File.Exists(_relativeImgPath))
                return System.IO.Path.GetFullPath("../../Image/NhomKhachHang/" + _tenAnh);
            return _tenAnh;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            LoadDataToDataGrid();
        }

        //NÚT ĐÓNG
        private void btnDong_Click(object sender, RoutedEventArgs e)
        {
            (this.Parent as Grid).Children.Remove(this);
        }

        //NÚT THÊM
        private void btnThemMoi_Click(object sender, RoutedEventArgs e)
        {
            NhomKhachHangThemPresentation wpf = new NhomKhachHangThemPresentation();
            wpf._ThemNhomKhachHang += new EventHandler(ThemNhomKhachHang);
            wpf.ShowDialog();
        }

        //Phương thức thêm nhóm khách hàng
        void ThemNhomKhachHang(object sender, EventArgs e)
        {
            #region 1. Lấy thông tin
            NhomKhachHangThemPresentation wpf = (NhomKhachHangThemPresentation)sender;
            NhomKhachHangPublic _nkh = wpf._nkh;
            #endregion

            #region 2. Lưu vào csdl
            if (NhomKhachHangBusiness.ThemNhomKhachHang(_nkh))
                LoadDataToDataGrid();
            else
                MessageBox.Show("Thêm mới thất bại");
            #endregion
        }

        //NÚT SỬA
        private void btnSua_Click(object sender, RoutedEventArgs e)
        {
            #region 1. Lấy thông tin nhóm khách hàng
            DataRowView _drv = (DataRowView)dgNhomKhachHang.SelectedItem;
            NhomKhachHangPublic _nkh = new NhomKhachHangPublic();
            _nkh.MaNKH_NKH = _drv["MaNKH_NKH"].ToString();
            _nkh.TenNKH_NKH = _drv["TenNKH_NKH"].ToString();
            _nkh.ChietKhau_NKH = Convert.ToInt32(_drv["ChietKhau_NKH"].ToString());
            _nkh.Diem_NKH = Convert.ToInt32(_drv["Diem_NKH"].ToString());
            _nkh.Anh_NKH = _drv["Anh_NKH"].ToString();
            _nkh.DangDung_NKH = (bool)_drv["DangDung_NKH"];
            #endregion

            #region 2. Hiển thị wpf sửa
            NhomKhachHangSuaPresentation wpf = new NhomKhachHangSuaPresentation();
            wpf._SuaNhomKhachHang += new EventHandler(SuaNhomKhachHang);
            wpf._nkh = _nkh;
            wpf.ShowDialog();
            #endregion
        }

        //Phương thức sửa nhóm khách hàng
        void SuaNhomKhachHang(object sender, EventArgs e)
        {
            #region 1. Lấy thông tin
            NhomKhachHangSuaPresentation wpf = (NhomKhachHangSuaPresentation)sender;
            NhomKhachHangPublic _nkh = wpf._nkh;
            #endregion

            #region 2.Update CSDl
            if (NhomKhachHangBusiness.SuaNhomKhachHang(_nkh))
                LoadDataToDataGrid();
            else
                MessageBox.Show("Sửa thông tin nhóm sản phẩm thất bại");
            #endregion
        }

        //Nút xóa
        private void btnXoa_Click(object sender, RoutedEventArgs e)
        {
            DataRowView _drv = (DataRowView)dgNhomKhachHang.SelectedItem;
            string _MaNKH = _drv["MaNKH_NKH"].ToString();
            if (NhomKhachHangBusiness.XoaNhomKhachHang(_MaNKH))
                LoadDataToDataGrid();
            else
                MessageBox.Show("Hiện đang có khách hàng thuộc nhóm khách hàng này. Không thể xóa.");
        }
    }//End class
}

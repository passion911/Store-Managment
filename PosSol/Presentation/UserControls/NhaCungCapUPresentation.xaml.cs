using System;
using System.Windows;
using System.Windows.Controls;
using System.Data;
using Public;
using Business;
using Presentation.WindowWpf;

namespace Presentation.UserControls
{
    /// <summary>
    /// Interaction logic for NhaCungCapUPresentation.xaml
    /// </summary>
    public partial class NhaCungCapUPresentation : UserControl
    {
        public NhaCungCapUPresentation()
        {
            InitializeComponent();
        }

        //LOAD DATA TO DATAGRID
        void LoadDataToDataGrid()
        {
            dgNhaCungCap.ItemsSource = NhaCungCapBusiness.DsNhaCungCap().Tables[0].DefaultView;
        }

        //NÚT ĐÓNG
        private void btnDong_Click(object sender, RoutedEventArgs e)
        {
            (this.Parent as Grid).Children.Remove(this);
        }

        //DataGrid Loaded
        private void dgNhaCungCap_Loaded(object sender, RoutedEventArgs e)
        {
            LoadDataToDataGrid();
        }

        //NÚT THÊM
        private void btnThem_Click(object sender, RoutedEventArgs e)
        {
            NhaCungCapThemPresentation wpf = new NhaCungCapThemPresentation();
            wpf._ThemNCC += new EventHandler(ThemNhaCungCap);
            wpf.ShowDialog();
        }

        //PHƯƠNG THỨC THÊM MỚI NHÀ CUNG CẤP
        void ThemNhaCungCap(object sender, EventArgs e)
        {
            #region 1. Lấy thông tin
            NhaCungCapThemPresentation wpf = (NhaCungCapThemPresentation)sender;
            NhaCungCapPublic _ncc = wpf._NCC;
            #endregion

            #region 2. Thêm vào csdl
            if (NhaCungCapBusiness.ThemNhaCungCap(_ncc))
                LoadDataToDataGrid();
            else
                MessageBox.Show("Thêm mới nhà cung cấp thất bại");
            #endregion
        }

        //NÚT SỬA
        private void btnSua_Click(object sender, RoutedEventArgs e)
        {
            #region 1. Lấy bản ghi được chọn
            NhaCungCapPublic _ncc = new NhaCungCapPublic();
            DataRowView _drv = (DataRowView)dgNhaCungCap.SelectedItem;
            _ncc.MaNCC_NCC = _drv["MaNCC_NCC"].ToString();
            _ncc.TenNCC_NCC = _drv["TenNCC_NCC"].ToString();
            _ncc.GhiChu_NCC = _drv["GhiChu_NCC"].ToString();
            #endregion

            #region Hiển thị wpf con
            NhaCungCapSuaPresentation wpf = new NhaCungCapSuaPresentation();
            wpf._ncc = _ncc;
            wpf._SuaNhaCungCap += new EventHandler(SuaNhaCungCap);
            wpf.ShowDialog();
            #endregion
        }

        //PHƯƠNG THỨC SỬA THÔNG TIN NHÀ CUNG CẤP
        void SuaNhaCungCap(object sender, EventArgs e)
        {
            #region 1. Lấy thông tin nhà cung cấp
            NhaCungCapSuaPresentation wpf = (NhaCungCapSuaPresentation)sender;
            NhaCungCapPublic _ncc = wpf._ncc;
            #endregion

            #region 2.Update vào csdl
            if (NhaCungCapBusiness.SuaNhaCungCap(_ncc))
                LoadDataToDataGrid();
            else
                MessageBox.Show("Sửa thông tninh nhà cung cấp thất bại");
            #endregion
        }

        // dg loadding row
        private void dgNhaCungCap_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = (e.Row.GetIndex() + 1).ToString();
        }

        //Nút xóa
        private void btnXoa_Click(object sender, RoutedEventArgs e)
        {
            DataRowView _drv = (DataRowView)dgNhaCungCap.SelectedItem;
            string _strMaNCC = _drv["MaNCC_NCC"].ToString();

            if (MessageBox.Show("Bạn có chắc  muốn xóa nhà cung cấp này?", "Xác nhân xóa", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                if (NhaCungCapBusiness.XoaNhaCungCap(_strMaNCC))
                    LoadDataToDataGrid();
                else
                    MessageBox.Show("Nhà cung cấp đang được sử dụng, không thể xóa.");
        }
    }//END CLASS
}

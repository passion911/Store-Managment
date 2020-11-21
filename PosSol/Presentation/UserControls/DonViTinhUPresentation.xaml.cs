using System;
using System.Windows;
using System.Windows.Controls;
using Public;
using System.Data;
using Business;
using Presentation.WindowWpf;

namespace Presentation.UserControls
{
    /// <summary>
    /// Interaction logic for DonViTinhUPresentation.xaml
    /// </summary>
    public partial class DonViTinhUPresentation : UserControl
    {
        public DonViTinhUPresentation()
        {
            InitializeComponent();
        }

        //Hiển thị danh sách Đơn vị tính lên datagrid
        void LoadDataToDataGrid()
        {
            dgDonViTinh.ItemsSource = DonViTinhBusiness.DanhSachDonViTinh().Tables[0].DefaultView;
        }

        //Loaded UC
        private void dgDonViTinh_Loaded(object sender, RoutedEventArgs e)
        {
            LoadDataToDataGrid();
        }

        //ĐÁNH SỐ THỨ TỰ
        private void dgDonViTinh_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = (e.Row.GetIndex() + 1).ToString();
        }

        //NÚT ĐÓNG
        private void btnDong_Click(object sender, RoutedEventArgs e)
        {
            (this.Parent as Grid).Children.Remove(this);
        }

        //NÚT THÊM
        private void btnThemMoi_Click(object sender, RoutedEventArgs e)
        {
            DonViTinhThemPresentation wpf = new DonViTinhThemPresentation();
            wpf._ThemDonViTinh += new EventHandler(ThemDonViTinh);
            wpf.ShowDialog();
        }

        //PHƯƠNG THỨC THÊM ĐƠN VỊ TÍNH
        void ThemDonViTinh(object sender, EventArgs e)
        {
            #region 1. Lấy thông tin
            DonViTinhThemPresentation wpf = (DonViTinhThemPresentation)sender;
            DonViTinhPublic _dvt = wpf._dvt;
            #endregion

            #region 2. Lưu vào csdl
            if (DonViTinhBusiness.ThemDonViTinh(_dvt))
                LoadDataToDataGrid();
            else
                MessageBox.Show("Thêm mới Đơn vị tính thất bại");
            #endregion
        }

        //NÚT SỬA
        private void btnSua_Click(object sender, RoutedEventArgs e)
        {
            #region 1. Lấy thông tin bản ghi dc chọn
            DataRowView _drv = (DataRowView)dgDonViTinh.SelectedItem;

            DonViTinhPublic _dvt = new DonViTinhPublic();
            _dvt.MaDVT_DVT = _drv["MaDVT_DVT"].ToString();
            _dvt.TenDVT_DVT = _drv["TenDVT_DVT"].ToString();
            _dvt.DangDung_DVT = _drv["DangDung_DVT"].ToString() == "True" ? true : false;
            #endregion

            #region 2. Hiển thị wpf con
            DonViTinhSuaPresentation wpf = new DonViTinhSuaPresentation();
            wpf._dvt = _dvt;
            wpf._SuaDonViTinh += new EventHandler(SuaDonViTinh);
            wpf.ShowDialog();
            #endregion
        }

        //PHƯƠNG THỨC SỬA THÔNG TIN ĐƠN VỊ TÍNH
        void SuaDonViTinh(object sender, EventArgs e)
        {
            #region 1. Lấy thông tin
            DonViTinhSuaPresentation wpf = (DonViTinhSuaPresentation)sender;
            DonViTinhPublic _dvt = wpf._dvt;
            #endregion

            #region 2. Thực hiện update vào csdl
            if (DonViTinhBusiness.SuaDonViTinh(_dvt))
                LoadDataToDataGrid();
            else
                MessageBox.Show("Sửa thông tin không thành công");
            #endregion
        }

        //NÚT XÓA
        private void btnXoa_Click(object sender, RoutedEventArgs e)
        {
            DataRowView _drv = (DataRowView)dgDonViTinh.SelectedItem;

            string _MaDVT = _drv["MaDVT_DVT"].ToString();
            if (MessageBox.Show("Bạn có chắc muốn xóa?", "Xác nhận xóa", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                if (DonViTinhBusiness.XoaDonViTinh(_MaDVT))
                    LoadDataToDataGrid();
                else
                    MessageBox.Show("Đơn vị tính đang được sử dụng, không thể xóa.");
        }

    }//End class
}


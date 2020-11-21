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
using Presentation.WindowWpf;
using Public;
using Business;
using Microsoft.Win32;
using System.IO;

namespace Presentation.UserControls
{
    /// <summary>
    /// Interaction logic for NhanVienUPresentation.xaml
    /// </summary>
    public partial class NhanVienUPresentation : UserControl
    {
        //Khai báo
        DataTable _dtNV;
        public event EventHandler _CapNhatHienThi;

        public NhanVienUPresentation()
        {
            InitializeComponent();
            lbWarning.Visibility = System.Windows.Visibility.Hidden;
        }

        //LOADING ROW
        private void dgNhomSanPham_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = (e.Row.GetIndex() + 1).ToString();
        }

        //LOAD DATA TO DATAGRID
        void LoadDataToDataGrid()
        {
            _dtNV = NhanVienBusiness.DsNhanVien().Tables[0];
            for (int i = 0; i < _dtNV.Rows.Count; i++)
            {
                //Get path Img
                string _imgName = _dtNV.Rows[i]["Anh_NV"].ToString();
                if (!String.IsNullOrEmpty(_imgName))
                    _dtNV.Rows[i]["Anh_NV"] = GetPathImageStaff(_imgName);
            }

            dgNhanVien.ItemsSource = _dtNV.DefaultView;
        }

        //GET PATH IMAGE STALLFF
        string GetPathImageStaff(string _imgName)
        {
            string _relativeImgPath = "../../Image/Staff/" + _imgName;
            if (File.Exists(_relativeImgPath))
                return System.IO.Path.GetFullPath("../../Image/Staff/" + _imgName);
            return _imgName;
        }

        //UC LOADED
        private void ucNhanVien_Loaded(object sender, RoutedEventArgs e)
        {
            LoadDataToDataGrid();
            txtTimKiem.Focus();
        }

        //NÚT ĐÓNG
        private void btnDong_Click(object sender, RoutedEventArgs e)
        {
            (this.Parent as Grid).Children.Remove(this);
        }

        //NÚT THÊM
        private void btnThemMoi_Click(object sender, RoutedEventArgs e)
        {
            NhanVienThemPresentation wpf = new NhanVienThemPresentation();
            wpf._ThemNhanVien += new EventHandler(ThemNhanVien);
            wpf.ShowDialog();
        }

        //PHƯƠNG THỨC THÊM MỚI
        void ThemNhanVien(object sender, EventArgs e)
        {
            #region 1. Lấy thông tin
            NhanVienThemPresentation wpf = (NhanVienThemPresentation)sender;
            NhanVienPublic _nv = wpf._nv;
            _nv.Anh_NV = CoppyAnhNV(_nv.Anh_NV, _nv.MaNV_NV);
            #endregion

            #region 2. Lưu vào csdl
            if (NhanVienBusiness.ThemNhanVien(_nv))
                LoadDataToDataGrid();
            else
                MessageBox.Show("Thêm nhân viên thất bại");
            #endregion
        }

        //COPPY ảnh nhân viên
        string CoppyAnhNV(string _anhNguon, string _tenAnh)
        {
            if (String.IsNullOrEmpty(_anhNguon))
                return "";

            try
            {
                string _FileName = System.IO.Path.GetFileName(_anhNguon);
                string _FileType = "";
                while (_FileName.IndexOf(".") != -1)
                {
                    _FileType = _FileName.Substring(_FileName.IndexOf(".") + 1);
                    _FileName = _FileName.Substring(_FileName.IndexOf(".") + 1);
                }


                //Kiểm tra trong thu mục ảnh có anh này chưa - nếu có tăng đổi tên thêm số vào cuối - chưa có giải pháp ghi đè 
                if (System.IO.File.Exists("../../Image/Staff/" + _tenAnh + "." + _FileType))
                {
                    _tenAnh = _tenAnh + "_";
                    bool t = true;
                    int i = 1;
                    while (t)
                    {
                        if (!System.IO.File.Exists("../../Image/Staff/" + _tenAnh + i.ToString() + "." + _FileType))
                        {
                            _tenAnh = _tenAnh + i.ToString() + "." + _FileType;
                            t = false;
                        }
                        i++;
                    }
                }
                else
                    _tenAnh = _tenAnh + "." + _FileType;
                File.Copy(_anhNguon, "../../Image/Staff/" + _tenAnh, true);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message, "Error");
            }
            return _tenAnh;
        }

        //DOUBLE CLICK
        private void dgNhanVien_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (dgNhanVien.RowDetailsVisibilityMode == DataGridRowDetailsVisibilityMode.Collapsed)
                dgNhanVien.RowDetailsVisibilityMode = DataGridRowDetailsVisibilityMode.VisibleWhenSelected;
            else
                dgNhanVien.RowDetailsVisibilityMode = DataGridRowDetailsVisibilityMode.Collapsed;
        }

        private void Image_Loaded(object sender, RoutedEventArgs e)
        {

        }

        //BUTTON UPDATE CLICK
        private void btnSua_Click(object sender, RoutedEventArgs e)
        {
            #region 1. Get row staff infomation
            DataRowView _drv = (DataRowView)dgNhanVien.SelectedItem;
            NhanVienPublic _staff = new NhanVienPublic();
            _staff.MaNV_NV = _drv["MaNV_NV"].ToString();
            _staff.HoTen_NV = _drv["HoTen_NV"].ToString();
            _staff.NgaySinh_NV = Convert.ToDateTime(_drv["NgaySinh_NV"].ToString());
            _staff.GioiTinh_NV = _drv["GioiTinh_NV"].ToString();
            _staff.DiaChi_NV = _drv["DiaChi_NV"].ToString();
            _staff.SDT_NV = _drv["SDT_NV"].ToString();
            _staff.Anh_NV = _drv["Anh_NV"].ToString();
            _staff.ID_Q = _drv["ID_Q"].ToString();
            _staff.DangDung_NV = (bool)_drv["DangDung_NV"];
            #endregion

            #region 2. Display wpf update staff
            NhanVienSuaPresentation wpf = new NhanVienSuaPresentation();
            wpf._UpdateStaff += new EventHandler(UpdateStaff);
            wpf._staff = _staff;
            wpf.ShowDialog();
            #endregion
        }

        //METHOD UPDATE STAFF
        void UpdateStaff(object sender, EventArgs e)
        {
            #region 1. Get new staff
            NhanVienSuaPresentation wpf = (NhanVienSuaPresentation)sender;
            NhanVienPublic _staff = wpf._staff;
            _staff.Anh_NV = CoppyAnhNV(_staff.Anh_NV, _staff.MaNV_NV);
            #endregion

            #region 2. Update to database
            if (NhanVienBusiness.UpdateStaff(_staff))
            {
                LoadDataToDataGrid();
                EventHandler _eh = _CapNhatHienThi;
                if (_eh != null)
                    _eh(this, e);
            }
            else
                MessageBox.Show("Sửa thông tin nhân viên thất bại");
            #endregion
        }

        //Nút tìm kiếm
        private void btnTimKiem_Click(object sender, RoutedEventArgs e)
        {
            //Kiểm tra dữ liệu tìm kiếm
            if (!KiemTraTimKiem())
                return;

            //Tìm kiếm
            string _strFilter = "MaNV_NV LIKE '%" + txtTimKiem.Text.Trim() + "%' OR HoTen_NV LIKE '%" + txtTimKiem.Text.Trim() + "%'";
            DataView _dvNV = new DataView(_dtNV, _strFilter, "MaNV_NV", DataViewRowState.CurrentRows);

            dgNhanVien.ItemsSource = _dvNV;
            txtTimKiem.Focus();
        }

        //Kiểm tra giá trị tìm kiếm
        private bool KiemTraTimKiem()
        {
            string _strTimKiem = txtTimKiem.Text.Trim();
            if (String.IsNullOrEmpty(_strTimKiem))
            {
                lbWarning.Visibility = System.Windows.Visibility.Visible;
                lbWarning.Content = "Nhập vào giá trị tìm kiếm: Tên hoặc mã nhân viên";
                txtTimKiem.Focus();
                return false;
            }
            string _strKiemTraTimKiem = @"[^'!*@#$%,]";
            if (!System.Text.RegularExpressions.Regex.IsMatch(_strTimKiem, _strKiemTraTimKiem))
            {
                lbWarning.Visibility = System.Windows.Visibility.Visible;
                lbWarning.Content = "Tên và mã nhân viên không chứa các kí tự đặc biệt.";
                txtTimKiem.Focus();
                txtTimKiem.SelectionStart = txtTimKiem.Text.Length;
                return false;
            }

            lbWarning.Visibility = System.Windows.Visibility.Hidden;
            return true;
        }

        //Nút reset
        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            ucNhanVien_Loaded(sender, e);
            txtTimKiem.Focus();
            txtTimKiem.Text = "";
        }

        //Preview key down txttimkiem
        private void txtTimKiem_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                btnTimKiem_Click(sender, e);
        }

        //Phím tắt
        protected override void OnPreviewKeyDown(KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Escape:

                    break;
                case Key.F3:
                    btnThemMoi_Click(this, e);
                    break;
                case Key.F2:
                    btnReset_Click(this, e);
                    break;
            }
            base.OnPreviewKeyDown(e);
        }

        //Nút xóa
        private void btnXoa_Click(object sender, RoutedEventArgs e)
        {
            DataRowView _drv = (DataRowView)dgNhanVien.SelectedItem;
            string _MaNV = _drv["MaNV_NV"].ToString();
            string _TenNV = _drv["HoTen_NV"].ToString();
            if (NhanVienBusiness.DeleteStaff(_MaNV))
            {
                lbWarning.Visibility = System.Windows.Visibility.Visible;
                lbWarning.Content = "Xóa nhân viên " + _TenNV + " thành công!";
                ucNhanVien_Loaded(sender, e);
            }
            else
            {
                lbWarning.Visibility = System.Windows.Visibility.Visible;
                lbWarning.Content = "Xóa nhân viên thất bại. Không thể xóa nhân viên " + _TenNV;
            }
        }
    }//END CLASS
}

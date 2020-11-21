using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Business;
using Presentation.WindowWpf;
using Public;
using System.Data;
using System.ComponentModel;
using Microsoft.Win32;

namespace Presentation.UserControls
{
    /// <summary>
    /// Interaction logic for NhomSanPhamUPresentation.xaml
    /// </summary>
    public partial class NhomSanPhamUPresentation : UserControl
    {
        DataTable _DtNSP;
        BackgroundWorker worker;
        public NhomSanPhamUPresentation()
        {
            InitializeComponent();
            bdProgress.Visibility = System.Windows.Visibility.Hidden;
        }

        //Phương thức load form
        private void ucNhomSanPham_Loaded(object sender, RoutedEventArgs e)
        {
            LoadDataToDatagrid();//hiển thị danh sách nhóm sản phẩm
        }

        //Load dữ liệu cho data grid - sử dụng background worker
        private void LoadDataToDatagrid()
        {
            #region 1. Hiển thị progress
            bdProgress.Visibility = System.Windows.Visibility.Visible;
            #endregion

            #region 2. Khai báo background worker thực hiện
            worker = new BackgroundWorker();
            worker.DoWork += (obj, ea) => LoadDataToDatagrid_dowork();
            worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(LoadDataToDatagrid_complete);
            worker.RunWorkerAsync();
            #endregion
        }

        #region 3. Load data to datagrid worker
        void LoadDataToDatagrid_dowork()
        {
            _DtNSP = NhomSanPhamBusiness.DanhSachNhomSanPham().Tables[0];
        }

        void LoadDataToDatagrid_complete(object sender, RunWorkerCompletedEventArgs e)
        {
            bdProgress.Visibility = System.Windows.Visibility.Hidden;
            dgNhomSanPham.ItemsSource = _DtNSP.DefaultView;
        }
        #endregion

        //Load dữ liệu cho data grid - tham số truyền vào mã Nhóm sản phẩm
        private void LoadDataToDatagrid(string Ma_NSP)
        {
            dgNhomSanPham.ItemsSource = NhomSanPhamBusiness.DanhSachNhomSanPham().Tables[0].DefaultView;
            DataView dv = ((DataView)dgNhomSanPham.ItemsSource);
        }

        //Đánh số thứ tự cho dòng datagrid
        private void Datagrid_loadingrow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = (e.Row.GetIndex() + 1).ToString();
        }

        //Nút đóng
        private void btnDong_Click(object sender, RoutedEventArgs e)
        {
            (this.Parent as Grid).Children.Remove(this);
        }

        //Nút thêm mới sản phẩm click
        private void btnThemMoi_Click(object sender, RoutedEventArgs e)
        {
            NhomSanPhamThemPresentation wpfThemNsp = new NhomSanPhamThemPresentation();
            wpfThemNsp.ThemNhomSanPham += new EventHandler(ThemNhomSanPham);
            wpfThemNsp.ShowDialog();
        }

        //Sự kiện thêm nhóm sản phẩm
        public void ThemNhomSanPham(object sender, EventArgs e)
        {
            NhomSanPhamThemPresentation wpfThemNsp = (NhomSanPhamThemPresentation)sender;

            //Lấy thông tin từ form con
            NhomSanPhamPublic nhomsp = new NhomSanPhamPublic();
            nhomsp = wpfThemNsp.nhomsanpham;

            //lưu vào csdl
            if (NhomSanPhamBusiness.ThemNhomSanPham(nhomsp))
            {
                //Load lại datagrid
                LoadDataToDatagrid(nhomsp.MaNSP_NSP);
            }
            else
                MessageBox.Show("Thêm mới thất bại");
        }

        //Nút xóa
        private void btnXoa_Click(object sender, RoutedEventArgs e)
        {
            // Lấy mã nhóm sản phẩm
            int index = dgNhomSanPham.CurrentCell.Column.DisplayIndex;
            DataRowView dataRow = (DataRowView)dgNhomSanPham.SelectedItem;

            //Xác nhận xóa
            if (MessageBox.Show("Nhóm sản phẩm " + dataRow["TenNSP_NSP"].ToString().ToUpper() + " sẽ bị xóa ?", "Xác nhận xóa", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                //Xóa nhóm sản phẩm
                if (NhomSanPhamBusiness.XoaNhomSanPham(dataRow["MaNSP_NSP"].ToString()))
                {
                    LoadDataToDatagrid();
                }
                else
                    MessageBox.Show("Nhóm sản phẩm này đang được sử dụng. Không thể xóa.");
        }

        //Nút sửa
        private void btnSua_Click(object sender, RoutedEventArgs e)
        {
            DataRowView dataRow = (DataRowView)dgNhomSanPham.SelectedItem;

            NhomSanPhamPublic nsp = new NhomSanPhamPublic();
            nsp.MaNSP_NSP = dataRow["MaNSP_NSP"].ToString();
            nsp.TenNSP_NSP = dataRow["TenNSP_NSP"].ToString();
            nsp.DangDung_NSP = (dataRow["DangDung_NSP"].ToString() == "True") ? true : false;
            nsp.GhiChu_NSP = dataRow["GhiChu_NSP"].ToString();
            // nsp.DangDung_NSP = (bool)dataRow["DangDung_NKH"];

            NhomSanPhamSuaPresentation wpf = new NhomSanPhamSuaPresentation();
            wpf.nhomsanpham = nsp;
            wpf.SuaNhomSanPham += new EventHandler(SuaNhomSanPham);
            wpf.ShowDialog();
        }

        //Sự kiện sửa nhóm sản phẩm
        public void SuaNhomSanPham(object sender, EventArgs e)
        {
            NhomSanPhamSuaPresentation wpf = (NhomSanPhamSuaPresentation)sender;

            //Lấy thông tin từ wpf con
            NhomSanPhamPublic nsp = new NhomSanPhamPublic();
            nsp = wpf.nhomsanpham;

            //Thực hiện update
            if (NhomSanPhamBusiness.CapNhatNhomSanPham(nsp))
                LoadDataToDatagrid();
            else
                MessageBox.Show("Cập nhật nhóm sản phẩm thất bại");
        }

        //Nút nhập excel
        private void btnNhapExcel_Click(object sender, RoutedEventArgs e)
        {
            //Mở form nhập excel
            NhomSanPhamNhapExcelPresentation wpf = new NhomSanPhamNhapExcelPresentation();
            wpf.NhapExcel += new EventHandler(NhapExecel);
            wpf.ShowDialog();

        }

        //Sự kiện nhập từ exel - lấy file exel về nhập vào database(chua check file)

        int _TongBanGhi;
        int _ThanhCong = 0;
        int _ThatBai = 0;
        public void NhapExecel(object sender, EventArgs e)
        {
            //lấy file excel về
            NhomSanPhamNhapExcelPresentation wpf = (NhomSanPhamNhapExcelPresentation)sender;

            bdProgress.Visibility = System.Windows.Visibility.Visible;
            pbTienTrinh.Value = 0;
            worker = new BackgroundWorker();
            worker.WorkerReportsProgress = true;
            worker.DoWork += (obj, ea) => ImportDatabase(wpf.DuongDan);
            worker.ProgressChanged += new ProgressChangedEventHandler(progressbarReport);
            worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(workerComplete);
            worker.RunWorkerAsync();
        }

        //Worker complte
        void workerComplete(object sender, RunWorkerCompletedEventArgs e)
        {
            bdProgress.Visibility = System.Windows.Visibility.Hidden;
            LoadDataToDatagrid();

            //Hiển thị kết quả
            KetQuaImportPresentation wpf = new KetQuaImportPresentation();
            wpf._TongBanGhi = _TongBanGhi;
            wpf._ThanhCong = _ThanhCong;
            wpf._ThatBai = _ThatBai;
            wpf.ShowDialog();
        }

        //Worker report
        void progressbarReport(object sender, ProgressChangedEventArgs e)
        {
            pbTienTrinh.Value = e.ProgressPercentage;
            lbProgress.Content = "Đang xử lý..." + (e.ProgressPercentage * _TongBanGhi / 100).ToString() + @" / " + _TongBanGhi.ToString();
        }

        //Import database
        private void ImportDatabase(string path)
        {
            DataTable dt = new DataTable();
            dt = UntilitiesBusiness.ImportToDatatable(path);
            _TongBanGhi = dt.Rows.Count;
            int i = 0;
            foreach (DataRow rdt in dt.Rows)
            {
                #region 1.Kiểm tra từng bản ghi trong data table
                if (rdt["MANHOM"].ToString().Equals(""))
                { _ThatBai++; goto go; }
                if (UntilitiesBusiness.CheckEist("tbl_NHOMSANPHAM", "MaNSP_NSP", rdt["MANHOM"].ToString().Trim()))
                { _ThatBai++; goto go; }
                if (rdt["TENNHOM"].ToString().Equals(""))
                { _ThatBai++; goto go; }
                #endregion

                #region 2. Lấy thông tin
                NhomSanPhamPublic nsp = new NhomSanPhamPublic();
                nsp.MaNSP_NSP = rdt["MANHOM"].ToString();
                nsp.TenNSP_NSP = rdt["TENNHOM"].ToString();
                nsp.GhiChu_NSP = rdt["GHICHU"].ToString();
                nsp.DangDung_NSP = true;
                #endregion

                #region 3.Thêm vào csdl
                NhomSanPhamBusiness.ThemNhomSanPham(nsp);
                _ThanhCong++;
                #endregion

                #region 4. Cập nhật progressbar
            go:
                i++;
                worker.ReportProgress(i * 100 / dt.Rows.Count);
                #endregion
            }
        }

        //Xuất Excel
        private void btnXuatExcel_Click(object sender, RoutedEventArgs e)
        {
            #region 1. Tạo datatable xuất
            DataTable _dtXuat = new DataTable();
            _dtXuat.Columns.Add("Mã nhóm");
            _dtXuat.Columns.Add("Tên nhóm");
            _dtXuat.Columns.Add("Ghi chú");

            DataRow _drXuat;

            for (int i = 0; i < _DtNSP.Rows.Count; i++)
            {
                _drXuat = _dtXuat.NewRow();
                _drXuat["Mã nhóm"] = _DtNSP.Rows[i]["MaNSP_NSP"].ToString();
                _drXuat["Tên nhóm"] = _DtNSP.Rows[i]["TenNSP_NSP"].ToString();
                _drXuat["Ghi chú"] = _DtNSP.Rows[i]["GhiChu_NSP"].ToString();

                _dtXuat.Rows.Add(_drXuat);
            }
            #endregion

            #region 2.Lưu file
            SaveFileDialog _saveFile = new SaveFileDialog();
            _saveFile.InitialDirectory = "C:";
            _saveFile.Title = "Save as Excel Files";
            _saveFile.FileName = "San pham";
            _saveFile.DefaultExt = ".xls";
            _saveFile.Filter = "Excel Files(2003)|*xls|Excel Files(2007)|*.xlsx";
            if (_saveFile.ShowDialog() == true)
            {
                string _tenFile = _saveFile.FileName;

                //Cho chạy ngầm cho hết đơ
                bdProgress.Visibility = System.Windows.Visibility.Visible;
                pbTienTrinh.IsIndeterminate = true;
                lbProgress.Content = "Đang xử lý...";
                worker = new BackgroundWorker();
                // worker.WorkerReportsProgress = true;
                worker.DoWork += (obj, ea) => UntilitiesBusiness.XuatExcel(_dtXuat, _tenFile);
                worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(XuatExcelHoanThanh);
                worker.RunWorkerAsync();
            }
            #endregion
        }

        #region Xuất Excel bgworker
        private void XuatExcelHoanThanh(object sender, RunWorkerCompletedEventArgs e)
        {
            bdProgress.Visibility = System.Windows.Visibility.Hidden;
            pbTienTrinh.IsIndeterminate = false;
        }
        #endregion

        //Nút tìm kiếm
        private void btnTimKiem_Click(object sender, RoutedEventArgs e)
        {
            //Kiểm tra
            string _strTimKiem = txtTimKiem.Text.Trim();
            if (String.IsNullOrEmpty(_strTimKiem))
            {
                lbProgress.Visibility = System.Windows.Visibility.Visible;
                lbProgress.Content = "Nhập chuỗi tìm kiếm.";
                txtTimKiem.Focus();
                return;
            }

            string _strKiemTraTimKiem = @"^([^!'@#*`]*)$";
            if (!System.Text.RegularExpressions.Regex.IsMatch(_strTimKiem, _strKiemTraTimKiem))
            {
                lbProgress.Visibility = System.Windows.Visibility.Visible;
                lbProgress.Content = "Chuỗi tìm kiếm không chứa ký tự đặc biệt";
                txtTimKiem.Focus();
                return;
            }


            string _strFilter = "MaNSP_NSP LIKE '%" + _strTimKiem + "%' OR TenNSP_NSP LIKE '%" + _strTimKiem + "%'";
            DataView _dvNSP = new DataView(_DtNSP, _strFilter, "NgayTao_NSP DESC", DataViewRowState.CurrentRows);
            dgNhomSanPham.ItemsSource = _dvNSP;

            lbProgress.Visibility = System.Windows.Visibility.Hidden;
        }

        //Nút reset
        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            ucNhomSanPham_Loaded(sender, e);
        }

        //On preview keydown
        private void txtTimKiem_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                btnTimKiem_Click(sender, e);
        }

        //Onpreview keydow
        protected override void OnPreviewKeyDown(KeyEventArgs e)
        {
            if (e.Key == Key.F11)
                btnReset_Click(this, e);
            base.OnPreviewKeyDown(e);
        }
    }//End class
}

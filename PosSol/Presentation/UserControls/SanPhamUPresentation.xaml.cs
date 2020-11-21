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
using Presentation.WindowWpf;
using System.IO;
using System.ComponentModel;
using Microsoft.Win32;

namespace Presentation.UserControls
{
    /// <summary>
    /// Interaction logic for SanPhamUPresentation.xaml
    /// </summary>
    public partial class SanPhamUPresentation : UserControl
    {
        DataTable _DtSP;
        public SanPhamUPresentation()
        {
            InitializeComponent();
            bdProgress.Visibility = System.Windows.Visibility.Hidden;
        }

        //Load data to datagrid 
        void LoadDataToDataGrid()
        {
            //Sử dụng background worker để load dữ liệu cho datagrid
            bdProgress.Visibility = System.Windows.Visibility.Visible;
            pbTienTrinh.IsIndeterminate = true;
            worker = new BackgroundWorker();
            worker.DoWork += (obj, ea) => LoadDataToDataGrid_dowork();
            worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(LoadDataToDataGrid_complete);
            worker.RunWorkerAsync();
        }
        #region Sử dụng bgWorker để load dữ liệu cho datagrid
        void LoadDataToDataGrid_dowork()
        {
            _DtSP = SanPhamBusiness.DsSanPham().Tables[0];
            for (int i = 0; i < _DtSP.Rows.Count; i++)
            {
                //Ảnh sản phẩm
                string _tenAnh = _DtSP.Rows[i]["Anh_SP"].ToString();
                _DtSP.Rows[i]["Anh_SP"] = LayAnhSanPham(_tenAnh);

                //Định dạng tiền
                _DtSP.Rows[i]["GiaNhap_SP"] = UntilitiesBusiness.ThemDauPhay(_DtSP.Rows[i]["GiaNhap_SP"].ToString());
                _DtSP.Rows[i]["GiaBanLe_SP"] = UntilitiesBusiness.ThemDauPhay(_DtSP.Rows[i]["GiaBanLe_SP"].ToString());
                _DtSP.Rows[i]["GiaBanSi_SP"] = UntilitiesBusiness.ThemDauPhay(_DtSP.Rows[i]["GiaBanSi_SP"].ToString());
            }
        }

        void LoadDataToDataGrid_complete(object sender, RunWorkerCompletedEventArgs e)
        {
            lbWarning.Visibility = System.Windows.Visibility.Hidden;
            bdProgress.Visibility = System.Windows.Visibility.Hidden;
            pbTienTrinh.IsIndeterminate = false;
            dgSanPham.ItemsSource = _DtSP.DefaultView;

            cboNhomSanPham.ItemsSource = SanPhamBusiness.LayNSP2();
            cboNhomSanPham.SelectedIndex = 0;
        }
        #endregion

        //Lấy đường dẫn ảnh sản phẩm
        string LayAnhSanPham(string _tenAnh)
        {
            string _relativeImgPath = "../../Image/SanPham/" + _tenAnh;
            if (System.IO.File.Exists(_relativeImgPath))
                return System.IO.Path.GetFullPath("../../Image/SanPham/" + _tenAnh);
            return _tenAnh;
        }

        //wpf Loaded
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {

            LoadDataToDataGrid();
        }

        //Datagrid double click
        private void dgKhachHang_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (dgSanPham.RowDetailsVisibilityMode == DataGridRowDetailsVisibilityMode.Collapsed)
                dgSanPham.RowDetailsVisibilityMode = DataGridRowDetailsVisibilityMode.VisibleWhenSelected;
            else
                dgSanPham.RowDetailsVisibilityMode = DataGridRowDetailsVisibilityMode.Collapsed;
        }

        //Loading row
        private void dgSanPham_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = (e.Row.GetIndex() + 1).ToString();
        }

        //Nút thêm
        private void btnThem_Click(object sender, RoutedEventArgs e)
        {
            SanPhamThemPresentation wpf = new SanPhamThemPresentation();
            wpf._ThemSanPham += new EventHandler(ThemSanPham);
            wpf.ShowDialog();
        }

        //Phương thức thêm mới sản phẩm
        void ThemSanPham(object sender, EventArgs e)
        {
            #region 1. Lấy thông tin
            SanPhamThemPresentation wpf = (SanPhamThemPresentation)sender;
            SanPhamPublic _sp = wpf._sp;
            _sp.Anh_SP = CoppyAnhSP(_sp.Anh_SP, _sp.MaSP_SP);
            #endregion

            #region 2. Thêm vào csdl
            if (SanPhamBusiness.ThemSanPham(_sp))
                LoadDataToDataGrid();
            else
                MessageBox.Show("Thêm sản phẩm thất bại");
            #endregion
        }

        //COPPY ảnh sản phẩm
        string CoppyAnhSP(string _anhNguon, string _tenAnh)
        {
            if (String.IsNullOrEmpty(_anhNguon))
                return "";
            if (String.IsNullOrEmpty(_tenAnh))
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
                if (System.IO.File.Exists("../../Image/SanPham/" + _tenAnh + "." + _FileType))
                {
                    _tenAnh = _tenAnh + "_";
                    bool t = true;
                    int i = 1;
                    while (t)
                    {
                        if (!System.IO.File.Exists("../../Image/SanPham/" + _tenAnh + i.ToString() + "." + _FileType))
                        {
                            _tenAnh = _tenAnh + i.ToString() + "." + _FileType;
                            t = false;
                        }
                        i++;
                    }
                }
                else
                    _tenAnh = _tenAnh + "." + _FileType;
                File.Copy(_anhNguon, "../../Image/SanPham/" + _tenAnh, true);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không tìm thấy ảnh:" + _tenAnh, "Lỗi");
            }
            return _tenAnh;
        }

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
        //Nút sửa
        private void btnSua_Click(object sender, RoutedEventArgs e)
        {
            #region 1. Lấy thông tin
            DataRowView _drv = (DataRowView)dgSanPham.SelectedItem;
            SanPhamPublic _sp = new SanPhamPublic();
            _sp.MaSP_SP = _drv["MaSP_SP"].ToString();
            _sp.TenSP_SP = _drv["TenSP_SP"].ToString();
            _sp.NSP_SP.MaNSP_NSP = _drv["MaNSP_SP"].ToString();
            _sp.NCC_SP.MaNCC_NCC = _drv["MaNCC_SP"].ToString();
            _sp.GiaNhap_SP = _drv["GiaNhap_SP"].ToString();
            _sp.GiaBanLe_SP = _drv["GiaBanLe_SP"].ToString();
            _sp.GiaBanSi_SP = _drv["GiaBanSi_SP"].ToString();
            _sp.DVT_SP.MaDVT_DVT = _drv["MaDVT_SP"].ToString();
            _sp.CKPhanTram_SP = Convert.ToInt32(_drv["CKPhanTram_SP"].ToString());
            _sp.GhiChu_SP = _drv["GhiChu_SP"].ToString();
            _sp.Anh_SP = _drv["Anh_SP"].ToString();
            #endregion

            #region 2. Hiển thị wpf sửa
            SanPhamSuaPresentation wpf = new SanPhamSuaPresentation();
            wpf._SuaSanPham += new EventHandler(SuaSanPham);
            wpf._sp = _sp;
            wpf.ShowDialog();
            #endregion
        }

        //Phương thức sửa thông tin sản phấm
        void SuaSanPham(object sender, EventArgs e)
        {
            #region 1. Lấy thông tin
            SanPhamSuaPresentation wpf = (SanPhamSuaPresentation)sender;
            SanPhamPublic _sp = wpf._sp;
            _sp.Anh_SP = CoppyAnhSP(_sp.Anh_SP, _sp.MaSP_SP);
            #endregion

            #region 2. Thêm vào csdl
            if (SanPhamBusiness.SuaSanPham(_sp))
                LoadDataToDataGrid();
            else
                MessageBox.Show("Thêm sản phẩm thất bại");
            #endregion
        }

        //Import
        private void btnNhapExcel_Click(object sender, RoutedEventArgs e)
        {
            SanPhamNhapExcelPresentation wpf = new SanPhamNhapExcelPresentation();
            wpf._NhapExcel += new EventHandler(NhapExcel);
            wpf.ShowDialog();
        }

        //Phương thức nhập từ Excel
        BackgroundWorker worker;
        int _TongBanGhi;
        int _ThanhCong = 0;
        int _ThatBai = 0;
        void NhapExcel(object sender, EventArgs e)
        {
            //Lấy file excel
            SanPhamNhapExcelPresentation wpf = (SanPhamNhapExcelPresentation)sender;

            pbTienTrinh.Value = 0;
            bdProgress.Visibility = System.Windows.Visibility.Visible;
            worker = new BackgroundWorker();
            worker.WorkerReportsProgress = true;
            worker.DoWork += (obj, ea) => ImportDatabase(wpf._DuongDan);
            worker.ProgressChanged += new ProgressChangedEventHandler(progressbarReport);
            worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(workerComplete);
            worker.RunWorkerAsync();
        }

        //Worker complte
        void workerComplete(object sender, RunWorkerCompletedEventArgs e)
        {
            bdProgress.Visibility = System.Windows.Visibility.Hidden;
            LoadDataToDataGrid();

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

        //Import to database
        private void ImportDatabase(string _path)
        {
            DataTable _dt = new DataTable();

            _dt = SanPhamBusiness.ImportToDatatable(_path);
            if (_dt.Rows.Count == 0)
            {
                MessageBox.Show("Tập tin excel đang được mở hoặc không đúng cấu trúc");
                return;
            }

            _TongBanGhi = _dt.Rows.Count;
            int i = 0; //Tiến trình
            foreach (DataRow _dr in _dt.Rows)
            {
                #region 1.Kiểm tra từng bản ghi trong data table
                if (_dr["MASP"].ToString().Equals(""))//Mã không được rỗng
                { _ThatBai++; goto go; }

                //if (UntilitiesBusiness.CheckEist("tbl_SANPHAM", "MaSP_SP", _dr["MASP"].ToString().Trim()))//Mã đã có trong csdl chưa
                //{ _ThatBai++; goto go; }

                if (_dr["TENSP"].ToString().Equals(""))//Tên không được rỗng
                { _ThatBai++; goto go; }

                if (_dr["GIANHAP"].ToString().Equals("") || _dr["GIABANLE"].ToString().Equals("") || _dr["GIABANSI"].ToString().Equals(""))
                    goto go;

                if (_dr["MANCC"].ToString().Equals("") || _dr["GIABANLE"].ToString().Equals("") || _dr["GIABANSI"].ToString().Equals("") || _dr["GIABANSI"].ToString().Equals(""))
                { _ThatBai++; goto go; }
                #endregion

                #region 2. Lấy thông tin
                SanPhamPublic _sp = new SanPhamPublic();
                _sp.MaSP_SP = UntilitiesBusiness.GetNextID("tbl_SANPHAM", "MaSP_SP", "SP.", 5);
                _sp.TenSP_SP = _dr["TENSP"].ToString();
                _sp.GiaNhap_SP = _dr["GIANHAP"].ToString();
                _sp.GiaBanLe_SP = _dr["GIABANLE"].ToString();
                _sp.GiaBanSi_SP = _dr["GIABANSI"].ToString();
                _sp.NCC_SP.MaNCC_NCC = _dr["MANCC"].ToString();
                _sp.NSP_SP.MaNSP_NSP = _dr["MANSP"].ToString();
                _sp.DVT_SP.MaDVT_DVT = _dr["MADVT"].ToString();
                _sp.GhiChu_SP = _dr["GHICHU"].ToString();
                _sp.CKPhanTram_SP = Convert.ToInt32(_dr["CHIETKHAU"].ToString());
                _sp.Anh_SP = "";
                #endregion

                #region 3. Thêm vào csdl
                SanPhamBusiness.ThemSanPham(_sp);
                _ThanhCong++;
                #endregion

                #region 4.Cập nhật trạng thái progessbar
            go:
                i++;
                worker.ReportProgress(i * 100 / _dt.Rows.Count);
                #endregion
            }
        }

        //ĐÓNG
        private void btnDong_Click(object sender, RoutedEventArgs e)
        {
            (this.Parent as Grid).Children.Remove(this);
        }

        //Export to excel
        private void btnXuatExcel_Click(object sender, RoutedEventArgs e)
        {
            //Tạo datatable để xuất - có thể thêm chức năng tại đây
            DataTable _dt = new DataTable();
            _dt.Columns.Add("Mã SP");
            _dt.Columns.Add("Tên SP");
            _dt.Columns.Add("Giá nhập");
            _dt.Columns.Add("Giá bán lẻ");
            _dt.Columns.Add("Giá bán sỉ");
            _dt.Columns.Add("Mã nhà cung cấp");
            _dt.Columns.Add("Mã nhóm SP");
            _dt.Columns.Add("Mã đơn vị");
            _dt.Columns.Add("Ghi chú");
            _dt.Columns.Add("Chiết khấu SP");

            DataRow _dr;

            foreach (DataRow _drsp in _DtSP.Rows)
            {
                _dr = _dt.NewRow();
                _dr["Mã SP"] = _drsp["MaSP_SP"].ToString();
                _dr["Tên SP"] = _drsp["TenSP_SP"].ToString();
                _dr["Giá nhập"] = _drsp["GiaNhap_SP"].ToString();
                _dr["Giá bán lẻ"] = _drsp["GiaBanLe_SP"].ToString();
                _dr["Giá bán sỉ"] = _drsp["GiaBanSi_SP"].ToString();
                _dr["Mã nhà cung cấp"] = _drsp["MaNCC_SP"].ToString();
                _dr["Mã nhóm SP"] = _drsp["MaNSP_SP"].ToString();
                _dr["Mã đơn vị"] = _drsp["MaDVT_SP"].ToString();
                _dr["Ghi chú"] = _drsp["GhiChu_SP"].ToString();
                _dr["Chiết khấu SP"] = _drsp["CKPhanTram_SP"].ToString();

                _dt.Rows.Add(_dr);
            }

            //Lưu file
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
                worker.DoWork += (obj, ea) => SanPhamBusiness.XuatExcel(_dt, _tenFile);
                worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(XuatExcelHoanThanh);
                worker.RunWorkerAsync();
            }
        }

        private void XuatExcelHoanThanh(object sender, RunWorkerCompletedEventArgs e)
        {
            bdProgress.Visibility = System.Windows.Visibility.Hidden;
            pbTienTrinh.IsIndeterminate = false;
        }

        //cbo selection change
        private void cboNhomSanPham_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(cboNhomSanPham.SelectedValue.ToString()))
                    btnSuaGia.Visibility = System.Windows.Visibility.Visible;
                else
                    btnSuaGia.Visibility = System.Windows.Visibility.Collapsed;

                DataView _dvSP = new DataView(_DtSP);
                _dvSP.Sort = "NgayTao_SP DESC";
                string _MaNSP = cboNhomSanPham.SelectedValue.ToString();
                string _strFilter;
                if (String.IsNullOrEmpty(_MaNSP))
                    _strFilter = "MaNSP_SP LIKE '%'";
                else
                    _strFilter = "MaNSP_SP = '" + _MaNSP + "'";
                _dvSP.RowFilter = _strFilter;

                dgSanPham.ItemsSource = _dvSP;
            }
            catch (Exception)
            {
                return;
            }
        }

        //Nút tìm kiếm
        private void btnTimKiem_Click(object sender, RoutedEventArgs e)
        {
            //Kiểm tra giá trị tìm kiếm
            if (!KiemTraTimKiem())
                return;
            //Tìm kiếm

            string _MaNSP = cboNhomSanPham.SelectedValue.ToString();
            string _strTK = txtTimKiemMaHoacTen.Text.Trim();
            string _strFilter;
            if (String.IsNullOrEmpty(_MaNSP))
                _strFilter = "MaSP_SP LIKE '%" + _strTK + "%' OR TenSP_SP LIKE '%" + _strTK + "%'";
            else
                _strFilter = "(MaSP_SP LIKE '%" + _strTK + "%' OR TenSP_SP LIKE '%" + _strTK + "%') AND MaNSP_SP= '" + _MaNSP + "'";

            DataView _dvSP = new DataView(_DtSP);
            _dvSP.Sort = "NgayTao_SP DESC";
            _dvSP.RowFilter = _strFilter;
            dgSanPham.ItemsSource = _dvSP;
        }

        //Kiểm tra giá trị tìm kiếm
        private bool KiemTraTimKiem()
        {
            string _strTimKiem = txtTimKiemMaHoacTen.Text.Trim();
            if (String.IsNullOrEmpty(_strTimKiem))
            {
                lbWarning.Visibility = System.Windows.Visibility.Visible;
                lbWarning.Content = "Nhập vào giá trị tìm kiếm: Tên hoặc mã nhân viên";
                txtTimKiemMaHoacTen.Focus();
                return false;
            }
            string _strKiemTraTimKiem = @"[^'!*@#$%,]";
            if (!System.Text.RegularExpressions.Regex.IsMatch(_strTimKiem, _strKiemTraTimKiem))
            {
                lbWarning.Visibility = System.Windows.Visibility.Visible;
                lbWarning.Content = "Tên và mã sản phẩm không chứa các kí tự đặc biệt.";
                txtTimKiemMaHoacTen.Focus();
                txtTimKiemMaHoacTen.SelectionStart = txtTimKiemMaHoacTen.Text.Length;
                return false;
            }

            lbWarning.Visibility = System.Windows.Visibility.Hidden;
            return true;
        }

        //Nút reset
        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            UserControl_Loaded(sender, e);
        }

        //Nút xóa
        private void btnXoa_Click(object sender, RoutedEventArgs e)
        {
            DataRowView _drv = (DataRowView)dgSanPham.SelectedItem;
            string _MaSP = _drv["MaSP_SP"].ToString();
            if (MessageBox.Show("Nhóm sản phẩm " + _drv["TenSP_SP"].ToString().ToUpper() + " sẽ bị xóa ?", "Xác nhận xóa", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                if (SanPhamBusiness.XoaSanPham(_MaSP))
                    LoadDataToDataGrid();
                else
                {
                    lbWarning.Visibility = System.Windows.Visibility.Visible;
                    lbWarning.Content = "Sản phẩm đã được bán. Không thể xóa";
                }
            }
        }

        //Nút sửa giá theo nhóm sản phẩm
        private void btnSuaGia_Click(object sender, RoutedEventArgs e)
        {
            SuaGiaSpTheoNhomPresentation wpf = new SuaGiaSpTheoNhomPresentation();
            wpf._TenNSP = (cboNhomSanPham.SelectedItem as NhomSanPhamPublic).TenNSP_NSP;
            wpf._MaNSP = cboNhomSanPham.SelectedValue.ToString();
            wpf._SuaGia += new EventHandler(SuaGiaTheoNhomSP);
            wpf.ShowDialog();
        }

        //Phương thức sửa giá theo nhóm sản phẩm
        private void SuaGiaTheoNhomSP(object sender, EventArgs e)
        {
            //Lấy thông tin
            SuaGiaSpTheoNhomPresentation wpf = (SuaGiaSpTheoNhomPresentation)sender;
            string _MaNSP = wpf._MaNSP;
            string _giaban = wpf._gia;

            //Thực hiện update gia
            if (SanPhamBusiness.SuaGiaTheoNhom(_MaNSP, _giaban))
                LoadDataToDataGrid();
            else
                MessageBox.Show("Sửa giá thất bại.");
        }
    }//End class
}

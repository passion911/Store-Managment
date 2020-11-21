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
using Presentation.WindowWpf;
using Public;
using System.Data;
using Presentation.Dataset;
using System.ComponentModel;
using System.Windows.Threading;
using System.Threading;
using Business;

namespace Presentation.UserControls
{
    /// <summary>
    /// Interaction logic for NhapMuaUPresentation.xaml
    /// </summary>
    public partial class NhapMuaUPresentation : UserControl
    {
        //Khai báo
        // public NhanVienPublic _nhanvien;

        BackgroundWorker _worker;//Tiến trình xử lý
        public NhanVienPublic _nhanVien;//Người lập phiếu
        PhieuNhapPublic _phieuNhap;
        List<SanPhamPublic> _ListSpNhap;//List sản phẩm nhập

        public NhapMuaUPresentation()
        {
            InitializeComponent();
            bdProgress.Visibility = System.Windows.Visibility.Hidden;

        }
        #region Khởi tạo phiếu nhập mới
        void TaoPhieuNhap()
        {
            //PHIẾU NHẬP: Số phiếu, ngày nhập , người lập, ghi chú
            _phieuNhap = new PhieuNhapPublic();
            _phieuNhap.NguoiNhap_PN = _nhanVien;
            _phieuNhap.SoPhieu_PN = UntilitiesBusiness.GetNextID("tbl_PHIEUNHAP", "SoPhieu_PN", "PH.", 10);
            lbSoPhieu.Content = _phieuNhap.SoPhieu_PN;
            _phieuNhap.NgayNhap_PN = DateTime.Today;
            dtNgayNhap.SelectedDate = DateTime.Today;

            _phieuNhap.GhiChu_PN = "";
            rtxtGhiChu.Document.Blocks.Clear();

            //CHI TIẾT HÀNG NHẬP: Thông tin sản phẩm, số lượng, thành tiền
            _ListSpNhap = new List<SanPhamPublic>();
            _ListSpNhap.Clear();

            lbTongTien.Content = "0";
            lbTongSP.Content = "0";
        }
        #endregion

        //Nút tìm kiếm
        private void btnTimKiem_Click(object sender, RoutedEventArgs e)
        {
            NhapMua_TimKiemSPPresentation wpf = new NhapMua_TimKiemSPPresentation();
            wpf._TimKiemSP += new EventHandler(TimKiemSP);
            wpf.ShowDialog();
        }
        #region Phương thức tìm kiếm
        private void TimKiemSP(object sender, EventArgs e)
        {
            // 1. Hiển thị progress
            bdProgress.Visibility = System.Windows.Visibility.Visible;

            //Tạo tiến trình xử lý
            _worker = new BackgroundWorker();
            _worker.DoWork += (obj, ea) => TimKiemSP_dowork(sender, e);
            _worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(TimKiemSP_complete);
            _worker.RunWorkerAsync();

        }
        //Tìm kiếm sp dowork
        private void TimKiemSP_dowork(object sender, EventArgs e)
        {
            #region 1.Lấy danh sách sản phẩm dc chọn từ wpf tìm kiếm
            NhapMua_TimKiemSPPresentation wpf = (NhapMua_TimKiemSPPresentation)sender;
            List<SanPhamPublic> _ListSPChon = wpf._ListSPChon;
            #endregion

            #region 2. Thêm vào datable sp
            foreach (SanPhamPublic _sp in _ListSPChon)
            {
                //Kiểm tra sản phẩm này đã có trong bảng chưa?
                if (KiemTraTonTai(_sp.MaSP_SP))
                    continue;
                //Nếu chưa thì add vào list sản phẩm nhập
                _sp.GiaNhap_SP = UntilitiesBusiness.ThemDauPhay(_sp.GiaNhap_SP);
                int _SoLuongNhap = _sp.SoLuong_SP;
                int _GiaNhap = Convert.ToInt32(UntilitiesBusiness.BoDauPhay(_sp.GiaNhap_SP));
                int _ThanhTien = _SoLuongNhap * _GiaNhap;
                _sp.ThanhTien_SP = UntilitiesBusiness.ThemDauPhay(_ThanhTien.ToString());

                _ListSpNhap.Add(_sp);
            }
            #endregion
        }

        //Worker complete
        private void TimKiemSP_complete(object sender, RunWorkerCompletedEventArgs e)
        {
            //Hiển thị danh sách sản phẩm nhập mua
            dgSanPhamNhapMua.ItemsSource = _ListSpNhap;
            dgSanPhamNhapMua.Items.Refresh();
            //Ẩn progress
            bdProgress.Visibility = System.Windows.Visibility.Hidden;
        }
        #endregion

        //Kiểm tra mã sản phẩm đã có trong trong bảng sản phẩm chưa?
        private bool KiemTraTonTai(string Value)
        {
            if (_ListSpNhap.Count == 0)
                return false;
            foreach (SanPhamPublic _sp in _ListSpNhap)
                if (_sp.MaSP_SP == Value)
                    return true;
            return false;
        }

        //Nút sửa
        private void btnSua_Click(object sender, RoutedEventArgs e)
        {
            #region 1.Lấy thông tin sp
            SanPhamPublic _spSua = new SanPhamPublic(); //Chỉ truyền sang mã SP, Tên SP và số lượng
            _spSua.MaSP_SP = (dgSanPhamNhapMua.SelectedItem as SanPhamPublic).MaSP_SP;
            _spSua.TenSP_SP = (dgSanPhamNhapMua.SelectedItem as SanPhamPublic).TenSP_SP;
            _spSua.SoLuong_SP = (dgSanPhamNhapMua.SelectedItem as SanPhamPublic).SoLuong_SP;
            _spSua.GiaNhap_SP = (dgSanPhamNhapMua.SelectedItem as SanPhamPublic).GiaNhap_SP;
            #endregion

            #region 2.Hiển thị wpf sửa
            NhapMuaSuaPresentation wpf = new NhapMuaSuaPresentation();
            wpf._sp = _spSua;
            wpf._SuaSanPham += new EventHandler(SuaSanPham);
            wpf.ShowDialog();
            #endregion
        }

        //Sự kiện sửa số lượng
        private void SuaSanPham(object sender, EventArgs e)
        {
            #region 1.Lấy thông tin (thay đổi số lượng)
            NhapMuaSuaPresentation wpf = (NhapMuaSuaPresentation)sender;
            SanPhamPublic _sp = wpf._sp;
            #endregion

            #region 2. Cập nhật lại thông tin list hàng nhập
            int _SoLuongNhap = _sp.SoLuong_SP;
            int _GiaNhap = Convert.ToInt32(UntilitiesBusiness.BoDauPhay(_sp.GiaNhap_SP));
            int _ThanhTien = _SoLuongNhap * _GiaNhap;
            SanPhamPublic _result = _ListSpNhap.Find(item => item.MaSP_SP == _sp.MaSP_SP);
            if (_result != null)
            {
                _ListSpNhap.Where(item => item.MaSP_SP == _sp.MaSP_SP).First().SoLuong_SP = _sp.SoLuong_SP;
                _ListSpNhap.Where(u => u.MaSP_SP == _sp.MaSP_SP).First().ThanhTien_SP = UntilitiesBusiness.ThemDauPhay(_ThanhTien.ToString());
            }
            dgSanPhamNhapMua.ItemsSource = _ListSpNhap;
            dgSanPhamNhapMua.Items.Refresh();

            HienThiTongTien();
            #endregion
        }
        //Hiển thị tổng tiền
        private void HienThiTongTien()
        {
            if (_ListSpNhap.Count == 0)
                return;

            lbTongSP.Content = _ListSpNhap.Sum(item => item.SoLuong_SP).ToString();
            int _TongTienNhap = 0;
            for (int i = 0; i < _ListSpNhap.Count; i++)
            {
                _TongTienNhap = _TongTienNhap + Convert.ToInt32(UntilitiesBusiness.BoDauPhay(_ListSpNhap[i].ThanhTien_SP));
            }
            lbTongTien.Content = UntilitiesBusiness.ThemDauPhay(_TongTienNhap.ToString());
        }

        //Datagrid loadingrow
        private void dgSanPhamNhapMua_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = (e.Row.GetIndex() + 1).ToString();
        }

        //Nút lưu phiếu nhập
        private void btnLuu_Click(object sender, RoutedEventArgs e)
        {
            bool t = false;
            //Kiểm tra thông tin nhập vào
            for (int i = 0; i < _ListSpNhap.Count; i++)
            {
                if (_ListSpNhap[i].SoLuong_SP > 0)
                    t = true;
            }

            if (!t)
            {
                MessageBox.Show("Chưa có sản phẩm nào.");
                return;
            }

            //Lấy thông tin
            _phieuNhap.NgayNhap_PN = dtNgayNhap.SelectedDate.Value;
            rtxtGhiChu.SelectAll();
            _phieuNhap.GhiChu_PN = rtxtGhiChu.Selection.Text;

            //Thực hiện lưu phiếu nhập
            NhapMuaBusiness.NhapHang(_phieuNhap, _ListSpNhap);

            //Tạo đơn nhập mới
            TaoPhieuNhap();
            dgSanPhamNhapMua.ItemsSource = _ListSpNhap;
            dgSanPhamNhapMua.Items.Refresh();
        }

        //Nút hủy phiếu nhập
        private void btnHuy_Click(object sender, RoutedEventArgs e)
        {
            TaoPhieuNhap();
            dgSanPhamNhapMua.ItemsSource = _ListSpNhap;
            dgSanPhamNhapMua.Items.Refresh();
        }

        //Nút hủy sản phẩm
        private void btnXoa_Click(object sender, RoutedEventArgs e)
        {
            SanPhamPublic _sp = (SanPhamPublic)dgSanPhamNhapMua.SelectedItem;

            var _spRemove = _ListSpNhap.Single(r => r.MaSP_SP == _sp.MaSP_SP);
            _ListSpNhap.Remove(_spRemove);

            dgSanPhamNhapMua.ItemsSource = _ListSpNhap;
            dgSanPhamNhapMua.Items.Refresh();

            lbTongSP.Content = _ListSpNhap.Sum(item => item.SoLuong_SP).ToString();
            int _TongTienNhap = 0;
            for (int i = 0; i < _ListSpNhap.Count; i++)
            {
                _TongTienNhap = _TongTienNhap + Convert.ToInt32(UntilitiesBusiness.BoDauPhay(_ListSpNhap[i].ThanhTien_SP));
            }
            lbTongTien.Content = UntilitiesBusiness.ThemDauPhay(_TongTienNhap.ToString());
        }

        //Nút thêm từ excel
        private void btnNhapExcel_Click(object sender, RoutedEventArgs e)
        {
            NhapMua_NhapTuExcelPresentation wpf = new NhapMua_NhapTuExcelPresentation();
            wpf._NhapExcel += new EventHandler(NhapTuExcel);
            wpf.ShowDialog();
        }
        //Phương thức nhập từ Excel
        private void NhapTuExcel(object sender, EventArgs e)
        {
            //Lấy file Excel
            NhapMua_NhapTuExcelPresentation wpf = (NhapMua_NhapTuExcelPresentation)sender;

            bdProgress.Visibility = System.Windows.Visibility.Visible;
            _worker = new BackgroundWorker();
            _worker.DoWork += (obj, ea) => NhapExcel_dowork(wpf._Excel);
            _worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(NhapExcel_complete);
            _worker.RunWorkerAsync();
        }
        //Nhập excel Dowork
        private void NhapExcel_dowork(string _excel)
        {
            //Lấy dữ liệu trong Excel
            string _strSql = "SELECT [Mã sản phẩm] as MaSP_SP, [Số lượng nhập] as SoLuong_SP FROM [Sheet1$]";
            DataTable _dtExcel = UntilitiesBusiness.ExcelToDatatable(_excel, _strSql);

            if (_dtExcel.Rows.Count == 0)
            {
                MessageBox.Show("Tập tin Excel đang được mở hoặc bị sai cấu trúc.Vui lòng kiểm tra lại.");
                return;
            }

            //Lấy danh sách sản phẩm để kiểm tra
            DataTable _dtSP = NhapMuaBusiness.DsSanPham().Tables[0];

            //Duyệt từng bản ghi
            SanPhamPublic _sp;
            for (int i = 0; i < _dtExcel.Rows.Count; i++)
            {
                string _MaSP_SP = _dtExcel.Rows[i]["MaSP_SP"].ToString();
                string _SoLuong_SP = _dtExcel.Rows[i]["SoLuong_SP"].ToString();

                //Kiểm tra có rỗng ko?
                if (String.IsNullOrEmpty(_MaSP_SP) || String.IsNullOrEmpty(_SoLuong_SP))
                    continue;

                //Kiểm tra sp này có trong list sp chọn chưa?
                if (KiemTraTonTai(_MaSP_SP))
                    continue;

                //Kiểm tra số lượng có âm không?
                if (Convert.ToInt32(_SoLuong_SP) < 0)
                    continue;

                //Kiểm tra xem sp này có tồn tại trong hệ thống ko?
                DataView _dvSP = new DataView(_dtSP);
                _dvSP.Sort = "MaSP_SP";
                int _index = _dvSP.Find(_MaSP_SP);
                if (_index == -1)
                    continue;

                //Thêm vào list sản phẩm chọn
                _sp = new SanPhamPublic();
                _sp.MaSP_SP = _MaSP_SP;
                _sp.TenSP_SP = _dvSP[_index]["TenSP_SP"].ToString();
                _sp.GiaNhap_SP = UntilitiesBusiness.ThemDauPhay(_dvSP[_index]["GiaNhap_SP"].ToString());
                _sp.GiaBanLe_SP = UntilitiesBusiness.ThemDauPhay(_dvSP[_index]["GiaBanLe_SP"].ToString());
                _sp.GiaBanSi_SP = UntilitiesBusiness.ThemDauPhay(_dvSP[_index]["GiaBanSi_SP"].ToString());
                _sp.NCC_SP.MaNCC_NCC = _dvSP[_index]["MaNCC_SP"].ToString();
                _sp.NSP_SP.MaNSP_NSP = _dvSP[_index]["MaNSP_SP"].ToString();
                _sp.DVT_SP.MaDVT_DVT = _dvSP[_index]["MaDVT_SP"].ToString();
                _sp.GhiChu_SP = _dvSP[_index]["GhiChu_SP"].ToString();
                _sp.SoLuong_SP = Convert.ToInt32(_SoLuong_SP);
                _sp.CKPhanTram_SP = Convert.ToInt32(_dvSP[_index]["CKPhanTram_SP"].ToString());
                _sp.Anh_SP = _dvSP[_index]["Anh_SP"].ToString();
                _sp.NgayTao_SP = Convert.ToDateTime(_dvSP[_index]["NgayTao_SP"].ToString());

                _ListSpNhap.Add(_sp);

                //Tính tổng tiền
                int _SoLuongNhap = _sp.SoLuong_SP;
                int _GiaNhap = Convert.ToInt32(UntilitiesBusiness.BoDauPhay(_sp.GiaNhap_SP));
                int _ThanhTien = _SoLuongNhap * _GiaNhap;
                SanPhamPublic _spFind = _ListSpNhap.Find(item => item.MaSP_SP == _sp.MaSP_SP);
                if (_spFind != null)
                    _ListSpNhap.Where(u => u.MaSP_SP == _sp.MaSP_SP).First().ThanhTien_SP = UntilitiesBusiness.ThemDauPhay(_ThanhTien.ToString());
            }
        }

        //Nhập Excel complete
        private void NhapExcel_complete(object sender, RunWorkerCompletedEventArgs e)
        {
            //Hiển thị danh sách sản phẩm chọn lên datagrid
            dgSanPhamNhapMua.ItemsSource = _ListSpNhap;
            dgSanPhamNhapMua.Items.Refresh();

            //Hiển thị tổng tiền
            HienThiTongTien();

            //Ẩn thanh tiến trình
            bdProgress.Visibility = System.Windows.Visibility.Hidden;
        }

        private void btnTest_Click(object sender, RoutedEventArgs e)
        {
            SanPhamPublic _sp = new SanPhamPublic();
            _sp = _ListSpNhap[0];

            _sp.SoLuong_SP = 123456;
            dgSanPhamNhapMua.ItemsSource = _ListSpNhap;
            dgSanPhamNhapMua.Items.Refresh();
        }

        //loaded
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            TaoPhieuNhap();
        }
    }//End class
}

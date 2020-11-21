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
using Business;
using Public;
using System.Data;
using Presentation.WindowWpf;
using Presentation.Report.Dataset;
using Presentation.Report;
using System.ComponentModel;
using System.Text.RegularExpressions;
using Presentation.Dataset;

namespace Presentation.UserControls
{
    /// <summary>
    /// Interaction logic for BanHangUPresentation.xaml
    /// </summary>
    public partial class BanHangUPresentation : UserControl
    {
        //Khai báo
        ThietLapHeThongPublic _thietLap;
        public NhanVienPublic _NhanVien;//Người đăng nhập
        public HoaDonPublic _hoaDonCu;
        public List<SanPhamPublic> _lstSpTiepTucMua;

        HoaDonPublic _hoaDon;
        NhanVienPublic _nguoiLap;
        KhachHangPublic _khachHang;
        List<SanPhamPublic> _dsSPMua;
        BackgroundWorker _worker;

        public BanHangUPresentation()
        {
            InitializeComponent();
            bdProgress.Visibility = System.Windows.Visibility.Collapsed;
            lbWarning.Visibility = System.Windows.Visibility.Hidden;
        }

        //LOADED
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            KhoiTaoDuLieu();//Khởi tạo dữ liệu ban đầu
        }

        //HÀM KHỞI TẠO DỮ LIỆU
        void KhoiTaoDuLieu()
        {
            //Hiển thị nội dung 
            txtMaHang.Text = "";
            txtMaHang.Focus();
            txtKhachHang.Text = "";
            rdBanBuon.IsEnabled = true;
            rdBanLe.IsEnabled = true;

            btnThanhToan.IsEnabled = false;
            btnChietKhau.IsEnabled = false;
            btnHuy.IsEnabled = false;

            #region 3. Khởi tạo phần hiển thị Tổng giá
            //Hiển thị
            txtbTongTien.Text = "0";
            txtbCkMatHang.Text = "0";
            txtbThanhTien.Text = "0";
            txtbConPhaiTra.Text = "0";
            #endregion

            //Hiển thị progressbar
            lbProgress.Content = "Đang nạp dữ liệu. Vui lòng đợi...";
            bdProgress.Visibility = System.Windows.Visibility.Visible;

            //Chạy tiến trình mới
            _worker = new BackgroundWorker();
            _worker.DoWork += (obj, ea) => KhoiTao_dowork();
            _worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(KhoiTao_complete);
            _worker.RunWorkerAsync();
        }

        //Khởi tạo bán hàng  - dowork
        private void KhoiTao_dowork()
        {
            //Khởi tạo hóa đơn mới
            _hoaDon = new HoaDonPublic();
            _hoaDon.SoHD_HD = UntilitiesBusiness.GetNextID("tbl_HOADON", "SoHD_HD", "HD.", 10);

            _hoaDon.NgayLap_HD = DateTime.Now;

            _hoaDon.NguoiLap_HD = _NhanVien;

            _khachHang = new KhachHangPublic();
            _khachHang.MaKH_KH = null;
            _hoaDon.KhachHang_HD = _khachHang;
            _hoaDon.KhachHang_HD.NHK_KH.ChietKhau_NKH = 0;

            _hoaDon.BanLe_HD = true; // Chú ý: đặt lại giá trị khi thêm hàng vào giỏ

            _hoaDon.TongCKHoaDon = 0;
            _hoaDon.TongCKSanPham = 0;
            _hoaDon.TongTien_HD = 0;
            _hoaDon.TongTienNhap = 0;
            _hoaDon.TienKhachTra_HD = 0;
            _hoaDon.TienConLaiPhaiTra = 0;

            _hoaDon.VouCher_HD = 0;

            //Nếu có hóa đơn cũ truyền vào thì lấy thông tin từ hóa đơn cũ
            if (_hoaDonCu != null && _lstSpTiepTucMua != null)
            {
                _hoaDon.KhachHang_HD = _hoaDonCu.KhachHang_HD;

                _hoaDon.TongCKHoaDon = _hoaDonCu.TongCKHoaDon;
                _hoaDon.TongCKSanPham = _hoaDonCu.TongCKSanPham;
                _hoaDon.TongTien_HD = _hoaDonCu.TongTien_HD;
                _hoaDon.TongTienNhap = _hoaDonCu.TongTienNhap;
                _hoaDon.TienKhachTraTruoc = _hoaDonCu.TienKhachTraTruoc;
                _hoaDon.TienKhachTra_HD = 0;
                _hoaDon.TienConLaiPhaiTra = 0;

                _dsSPMua = new List<SanPhamPublic>();
                _dsSPMua = _lstSpTiepTucMua;

                ////Hủy dữ liệu cũ truyền sang
                _hoaDonCu = null;
                _lstSpTiepTucMua = null;
            }
            else
            {
                //Khởi tạo giỏ hàng- truwnowngf hợp ko có hóa đơn cũ tiếp tục mua hàng
                _dsSPMua = new List<SanPhamPublic>();
                _dsSPMua.Clear();
            }

            //Lấy thiết lập
            _thietLap = ThietLapHeThongBusiness.LayThietLapHeThong();
        }

        //Khởi tạo - complete
        private void KhoiTao_complete(object sender, RunWorkerCompletedEventArgs e)
        {
            //Ẩn progress
            bdProgress.Visibility = System.Windows.Visibility.Collapsed;
            dgDanhSachSanPham.ItemsSource = _dsSPMua;
            dgDanhSachSanPham.Items.Refresh();

            _hoaDon.BanLe_HD = rdBanLe.IsChecked == true ? true : false;
            rdBanBuon.IsEnabled = true;
            rdBanLe.IsEnabled = true;

            //Tính tổng tiền
            if (_dsSPMua.Count > 0)
                TongTien();
        }

        //NÚT THÊM HÀNG
        private void btnThemHang_Click(object sender, RoutedEventArgs e)
        {
            string _MaSp = txtMaHang.Text.Trim();
            if (_MaSp.StartsWith("."))
                _MaSp = _MaSp.Remove(0, 1);

            //Kiểm tra mã hàng nhập vào
            if (!KiemTraSP(_MaSp))
                return;

            //Thêm sản phẩm vào gio hàng
            ThemHangVaoDsHangMua(_MaSp);

            //Hiển thị giỏ hàng
            dgDanhSachSanPham.ItemsSource = _dsSPMua;
            dgDanhSachSanPham.Items.Refresh();

            //Tính tổng tiền hóa đơn
            TongTien();

            //Đặt con trỏ vào ô nhập mã hàng khác
            txtMaHang.Focus();
            txtMaHang.Text = "";

            btnThanhToan.IsEnabled = true;
            btnChietKhau.IsEnabled = _thietLap.ChietKhauHoaDon;
            btnHuy.IsEnabled = true;
        }

        //Thêm hàng vào danh sách hàng mua
        private void ThemHangVaoDsHangMua(string _MaSP)
        {
            //Lấy thông tin sp
            SanPhamPublic _sp = new SanPhamPublic();
            DataTable _dtSp = BanHangBusiness.LaySpTheoMa(_MaSP).Tables[0];

            DataView _dvSP = new DataView(_dtSp);
            _dvSP.Sort = "MaSP_SP";
            int _index = _dvSP.Find(_MaSP);
            if (_index == -1)
            {
                lbWarning.Visibility = System.Windows.Visibility.Visible;
                lbWarning.Text = "Mã sản phẩm không tồn tại. Vui lòng kiểm tra lại!";
                txtMaHang.Focus();
                txtMaHang.SelectAll();
                return;
            }
            int _soLuongConTrongKho = Convert.ToInt32(_dvSP[_index]["SoLuong_SP"].ToString());

            _sp.STT = _dsSPMua.Count + 1;
            _sp.MaSP_SP = _dvSP[_index]["MaSP_SP"].ToString();
            _sp.TenSP_SP = _dvSP[_index]["TenSP_SP"].ToString();
            _sp.GiaNhap_SP = _dvSP[_index]["GiaNhap_SP"].ToString();
            _sp.GiaBanLe_SP = _dvSP[_index]["GiaBanLe_SP"].ToString();
            _sp.GiaBanSi_SP = _dvSP[_index]["GiaBanSi_SP"].ToString();
            _sp.NCC_SP.MaNCC_NCC = _dvSP[_index]["MaNCC_SP"].ToString();
            _sp.NSP_SP.MaNSP_NSP = _dvSP[_index]["MaNSP_SP"].ToString();
            _sp.DVT_SP.MaDVT_DVT = _dvSP[_index]["MaDVT_SP"].ToString();
            _sp.DVT_SP.TenDVT_DVT = _dvSP[_index]["TenDVT_DVT"].ToString();
            _sp.GhiChu_SP = _dvSP[_index]["GhiChu_SP"].ToString();
            _sp.SoLuong_SP = 1;
            _sp.CKPhanTram_SP = Convert.ToInt32(_dvSP[_index]["CKPhanTram_SP"].ToString());
            _sp.Anh_SP = _dvSP[_index]["Anh_SP"].ToString();
            _sp.NgayTao_SP = Convert.ToDateTime(_dvSP[_index]["NgayTao_SP"].ToString());

            //Thêm hàng vào giỏ hàng
            if (_dsSPMua.Count == 0)//trong giỏ chưa có sp nào
            {
                //Tắt kiểu bán - 1 hóa đơn chỉ 1 kiểu bán
                rdBanLe.IsEnabled = false;
                rdBanBuon.IsEnabled = false;

                _hoaDon.BanLe_HD = rdBanLe.IsChecked == true ? true : false;

                //Tính thành tiền sp
                _sp.GiaBan = UntilitiesBusiness.ThemDauPhay(_hoaDon.BanLe_HD == true ? _sp.GiaBanLe_SP : _sp.GiaBanSi_SP);

                int _giaBan = Convert.ToInt32(UntilitiesBusiness.BoDauPhay(_sp.GiaBan));
                int _soLuong = _sp.SoLuong_SP;
                float _chietKhau = _sp.CKPhanTram_SP;
                int _chietKhauTienMat = (int)(_giaBan * _chietKhau) / 100;
                _sp.CKTienMat = UntilitiesBusiness.ThemDauPhay(_chietKhauTienMat.ToString());
                _sp.ThanhTien_SP = UntilitiesBusiness.ThemDauPhay(ThanhTien1Sp(_giaBan, _soLuong, _chietKhau).ToString());
                _dsSPMua.Add(_sp);
            }
            else
            {
                //Kiểm tra trong giỏ hàng có sp này chưa: có thì công số lượng, chưa thì thêm vào giỏ hàng
                SanPhamPublic _result = _dsSPMua.Find(item => item.MaSP_SP == _sp.MaSP_SP);
                if (_result != null)//Đã có trong giỏ hàng => cộng thêm số lượng
                {
                    //Kiểm tra số lượng sp trong kho
                    if (_result.SoLuong_SP == _soLuongConTrongKho)
                    {
                        lbWarning.Visibility = System.Windows.Visibility.Visible;
                        lbWarning.Text = "Chỉ còn " + _result.SoLuong_SP + " " + _result.TenSP_SP + "trong kho.";
                        txtMaHang.Focus();
                        txtMaHang.SelectAll();
                        return;
                    }

                    //Cộng số lượng
                    _result.SoLuong_SP = _result.SoLuong_SP + _sp.SoLuong_SP;

                    //Tính lại ck tiền mặt và thành tiền
                    int _giaBan = Convert.ToInt32(UntilitiesBusiness.BoDauPhay(_result.GiaBan));
                    int _soLuong = _dsSPMua.Where(item => item.MaSP_SP == _sp.MaSP_SP).First().SoLuong_SP;
                    float _chietKhau = _result.CKPhanTram_SP;
                    int _chietKhauTienMat = (int)(_soLuong * (_giaBan * _chietKhau) / 100);
                    _result.CKTienMat = UntilitiesBusiness.ThemDauPhay(_chietKhauTienMat.ToString());
                    _result.ThanhTien_SP = UntilitiesBusiness.ThemDauPhay(ThanhTien1Sp(_giaBan, _soLuong, _chietKhau).ToString());
                }
                else//Chưa có trong giỏ hàng
                {
                    //Tính thành tiền sp
                    _sp.GiaBan = UntilitiesBusiness.ThemDauPhay(_hoaDon.BanLe_HD == true ? _sp.GiaBanLe_SP : _sp.GiaBanSi_SP);

                    int _giaBan = Convert.ToInt32(UntilitiesBusiness.BoDauPhay(_sp.GiaBan));
                    int _soLuong = _sp.SoLuong_SP;
                    float _chietKhau = _sp.CKPhanTram_SP;
                    int _chietKhauTienMat = (int)(_giaBan * _chietKhau) / 100;
                    _sp.CKTienMat = UntilitiesBusiness.ThemDauPhay(_chietKhauTienMat.ToString());
                    _sp.ThanhTien_SP = UntilitiesBusiness.ThemDauPhay(ThanhTien1Sp(_giaBan, _soLuong, _chietKhau).ToString());
                    _dsSPMua.Add(_sp);
                }
            }
        }

        //Tính thành tiền 1 sp
        private int ThanhTien1Sp(int _giaBan, int _soLuong, float _chietKhau)
        {
            int _ThanhTien = 0;
            _ThanhTien = (int)((_giaBan * _soLuong) - _soLuong * (_giaBan * _chietKhau) / 100);
            return _ThanhTien;
        }

        //Kiểm tra mã hàng nhập vào
        private bool KiemTraSP(string _MaSp)
        {
            //Kiểm tra xem mã có hợp lệ không(Mã chỉ chứa chữ cái, dấu chấm và dấu gạch dưới)
            string _checkMaSp = @"^([a-zA-Z0-9._]+)$";
            if (!Regex.IsMatch(_MaSp, _checkMaSp))
            {
                lbWarning.Visibility = System.Windows.Visibility.Visible;
                lbWarning.Text = "Mã sản phẩm không hợp lệ!";
                txtMaHang.Focus();
                txtMaHang.SelectAll();
                return false;
            }

            //Kiểm tra xem trong hệ thống có sản phẩm này không?
            DataTable _dtSp = BanHangBusiness.LaySpTheoMa(_MaSp).Tables[0];//Chứa toàn bộ sản phẩm của hệ thống
            if (_dtSp.Rows.Count == 0)
            {
                lbWarning.Visibility = System.Windows.Visibility.Visible;
                lbWarning.Text = "Mã sản phẩm không tồn tại. Vui lòng kiểm tra lại!";
                txtMaHang.Focus();
                txtMaHang.SelectAll();
                return false;
            }
            //Kiểm tra số lượng hàng có đủ ko?
            int _SoLuongCon = Convert.ToInt32(_dtSp.Rows[0]["SoLuong_SP"].ToString());
            if (_SoLuongCon < 1)
            {
                lbWarning.Visibility = System.Windows.Visibility.Visible;
                lbWarning.Text = "Hết sản phẩm.";
                txtMaHang.Focus();
                txtMaHang.SelectAll();
                return false;
            }

            _dtSp.Dispose();
            lbWarning.Visibility = System.Windows.Visibility.Hidden;
            return true;
        }

        //Tính tổng tiền hóa đơn
        private void TongTien()
        {
            if (_dsSPMua.Count == 0)
            {
                _hoaDon.ThanhTien = 0;
                _hoaDon.TongCKHoaDon = 0;
                _hoaDon.TongCKSanPham = 0;
                _hoaDon.TongTien_HD = 0;
                _hoaDon.VouCher_HD = 0;
                _hoaDon.TienMaGiamGia = 0;

                //Hiển thị
                txtbTongTien.Text = UntilitiesBusiness.ThemDauPhay(_hoaDon.TongTien_HD.ToString());
                txtbCkMatHang.Text = UntilitiesBusiness.ThemDauPhay(_hoaDon.TongCKSanPham.ToString());
                txtbCkHoaDon.Text = UntilitiesBusiness.ThemDauPhay(_hoaDon.TongCKHoaDon.ToString());
                txtbThanhTien.Text = UntilitiesBusiness.ThemDauPhay(_hoaDon.ThanhTien.ToString());
                txtbConPhaiTra.Text = txtbThanhTien.Text;
            }
            else
            {
                //Dùng vòng lặp tính tổng tiền
                int _TongCong = 0;
                int _TongTienNhap = 0;
                int _TongCkMatHang = 0;
                int _TongCkHoaDon = 0;
                int _ThanhTien = 0;

                int _TienTraTruoc = _hoaDon.TienKhachTraTruoc;//Chú ý: Tiền khách đã trả trước(chưa làm) nếu làm cắm vô đây (và khi nhập khách hàng)
                int _TienConPhaiTra = 0;

                for (int i = 0; i < _dsSPMua.Count; i++)
                {
                    _TongTienNhap = _TongTienNhap + (Convert.ToInt32(UntilitiesBusiness.BoDauPhay(_dsSPMua[i].GiaNhap_SP)) * _dsSPMua[i].SoLuong_SP);
                    _TongCkMatHang = _TongCkMatHang + Convert.ToInt32(UntilitiesBusiness.BoDauPhay(_dsSPMua[i].CKTienMat));
                    _TongCong = _TongCong + Convert.ToInt32(UntilitiesBusiness.BoDauPhay(_dsSPMua[i].GiaBan)) * _dsSPMua[i].SoLuong_SP;
                }

                _ThanhTien = (_TongCong - _TongCkMatHang);
                _TongCkHoaDon = _TongCong * _hoaDon.KhachHang_HD.NHK_KH.ChietKhau_NKH / 100;
                _ThanhTien = _ThanhTien - _TongCkHoaDon;
                _TienConPhaiTra = _ThanhTien - _TienTraTruoc - _hoaDon.VouCher_HD - _hoaDon.TienMaGiamGia;


                _hoaDon.ThanhTien = _ThanhTien;
                _hoaDon.TongCKHoaDon = _TongCkHoaDon;
                _hoaDon.TongCKSanPham = _TongCkMatHang;
                _hoaDon.TongTien_HD = _TongCong;
                _hoaDon.TongTienNhap = _TongTienNhap;
                _hoaDon.TienConLaiPhaiTra = _TienConPhaiTra;

                //Hiển thị
                txtbTongTien.Text = UntilitiesBusiness.ThemDauPhay(_hoaDon.TongTien_HD.ToString());
                txtbCkMatHang.Text = UntilitiesBusiness.ThemDauPhay(_hoaDon.TongCKSanPham.ToString());
                txtbCkHoaDon.Text = UntilitiesBusiness.ThemDauPhay(_hoaDon.TongCKHoaDon.ToString());
                txtbTraTruoc.Text = UntilitiesBusiness.ThemDauPhay(_hoaDon.TienKhachTraTruoc.ToString());
                txtbThanhTien.Text = UntilitiesBusiness.ThemDauPhay(_hoaDon.ThanhTien.ToString());
                txtbConPhaiTra.Text = UntilitiesBusiness.ThemDauPhay(_TienConPhaiTra.ToString());
            }
        }

        //Sự kiện nhấn ENTER
        private void txtMaHang_KeyUp(object sender, KeyEventArgs e)
        {
            //if (e.Key.ToString() == "Return")
            //    btnThemHang_Click(sender, e);
        }

        //Nút hủy sản phẩm trong giỏ hàng
        private void btnHuySP_Click(object sender, RoutedEventArgs e)
        {
            //Xóa sản phẩm trong giỏ hàng
            string _MaSpHuy = (dgDanhSachSanPham.SelectedItem as SanPhamPublic).MaSP_SP;
            var _spRemove = _dsSPMua.Single(item => item.MaSP_SP == _MaSpHuy);
            _dsSPMua.Remove(_spRemove);


            //Hiển thị giỏ hàng
            dgDanhSachSanPham.ItemsSource = _dsSPMua;
            dgDanhSachSanPham.Items.Refresh();

            //Tính tổng tiền hóa đơn
            TongTien();

            if (_dsSPMua.Count == 0)
            {
                btnThanhToan.IsEnabled = false;
                btnChietKhau.IsEnabled = false;
                btnHuy.IsEnabled = false;

                rdBanLe.IsEnabled = true;
                rdBanBuon.IsEnabled = true;
            }
            txtMaHang.Focus();
        }

        #region ChangeRowValue funtion
        void ChangeRowValue()
        {
            ////
            //// 1. Cell thành tiền
            //DataRowView drv = (DataRowView)dgDanhSachSanPham.SelectedItem;
            //int _SoLuong = Convert.ToInt32(drv["SoLuong"]);
            //int _Gia = Convert.ToInt32(drv["Gia"]);
            //int _CKPhanTram = Convert.ToInt32(drv["CkPhanTram"]);
            //int _CKTienMat = Convert.ToInt32(drv["CkTienMat"]);
            //int _ThanhTien;

            //// 1.1 Update cell CK tiền mặt
            //if (dgDanhSachSanPham.CurrentColumn.Header.ToString() == "SL")
            //{
            //    _CKTienMat = _SoLuong * (_CKPhanTram * _Gia / 100);
            //    drv["CkTienMat"] = _CKTienMat;
            //}

            //// 1.2 update cell thành tiền
            //_ThanhTien = (_Gia * _SoLuong) - _CKTienMat;
            //drv["ThanhTien"] = _ThanhTien;

            //// 1.3 Update Tổng tiền
            //TongTien();
        }
        #endregion

        #region Sự kiện thảy đổi số lượng | chiết khấu
        // key UP - 
        private void dgDanhSachSanPham_KeyUp(object sender, KeyEventArgs e)
        {
            ChangeRowValue();
        }

        private void dgDanhSachSanPham_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            // ChangeRowValue();
        }
        #endregion

        private void dgDanhSachSanPham_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            //MessageBox.Show("SelectedCellsChanged");
            //ChangeRowValue();
        }

        private void dgDanhSachSanPham_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            // MessageBox.Show("DataContextChanged");
        }

        //NÚT HỦY PHIẾU
        private void btnHuy_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Bạn muốn hủy hóa đơn này", "Xác nhận", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                _dsSPMua.Clear();
                KhoiTaoDuLieu();
                TongTien();
                txtMaHang.Focus();
                gdKhachHang.Children.Clear();
            }
        }

        //NÚT THANH TOÁN
        private void btnThanhToan_Click(object sender, RoutedEventArgs e)
        {
            //Lấy dữ liệu (hóa đơn)
            BanHangThanhToanPresentation wpf = new BanHangThanhToanPresentation();
            wpf._hoaDon = _hoaDon;//(Hóa đơn gốc)
            wpf._ThanhToan += new EventHandler(ThanhToan);
            wpf.ShowDialog();
        }
        //Phương thức thanh toán
        void ThanhToan(object sender, EventArgs e)
        {

            //Lấy thông tin
            BanHangThanhToanPresentation wpf = (BanHangThanhToanPresentation)sender;
            _hoaDon.TienKhachTra_HD = wpf._hoaDon.TienKhachTra_HD;
            _hoaDon.VouCher_HD = wpf._hoaDon.VouCher_HD;
            _hoaDon.MaGiamGia = wpf._hoaDon.MaGiamGia;
            _hoaDon.TienMaGiamGia = wpf._hoaDon.TienMaGiamGia;
            _hoaDon.TienThuaTraLaiKhach = wpf._hoaDon.TienThuaTraLaiKhach;
            _hoaDon.DangDung_HD = true;

            //Tính lại tiền

            TongTien();

            //Lưu lại phiên bán hàng
            BanHangBusiness.BanHang(_hoaDon, _dsSPMua, true);

            //In hóa đơn
            bool _InHoaDon = wpf._InHoaDon;
            if (_InHoaDon)
            {
                //Chuẩn bị dữ liệu
                Pos_ds _Pos_ds = new Pos_ds();
                DataTable _dtHoaDonBanLe = _Pos_ds.tbl_HOADON;
                DataRow _drHoaDonBanLe;

                foreach (SanPhamPublic _spHoaDon in _dsSPMua)
                {
                    _drHoaDonBanLe = _dtHoaDonBanLe.NewRow();
                    _drHoaDonBanLe["MaSP_SP"] = _spHoaDon.MaSP_SP;
                    _drHoaDonBanLe["TenSP_SP"] = _spHoaDon.TenSP_SP;
                    _drHoaDonBanLe["GiaBan_SP"] = _spHoaDon.GiaBan;
                    _drHoaDonBanLe["DVT_SP"] = _spHoaDon.DVT_SP.TenDVT_DVT;
                    _drHoaDonBanLe["SoLuong_SP"] = _spHoaDon.SoLuong_SP;
                    _drHoaDonBanLe["ChietKhau_SP"] = _spHoaDon.CKTienMat;
                    _drHoaDonBanLe["ThanhTien_SP"] = _spHoaDon.ThanhTien_SP;

                    _dtHoaDonBanLe.Rows.Add(_drHoaDonBanLe);
                }
                _hoaDon.TongSoLuongSP = _dsSPMua.Sum(item => item.SoLuong_SP);

                HoaDonBanLe_UPresentation wpf_HoaDon = new HoaDonBanLe_UPresentation();
                wpf_HoaDon._status_para = "Bản gốc";
                wpf_HoaDon._dtHoaDon = _dtHoaDonBanLe;
                wpf_HoaDon._hoaDon = _hoaDon;
                wpf_HoaDon.ShowDialog();
            }

            //Khởi tạo lại dữ liệu
            _dsSPMua.Clear();
            KhoiTaoDuLieu();
            TongTien();
            txtMaHang.Focus();

            //Xóa thông tin khách hàng vừa mua
            gdKhachHang.Children.Clear();
        }

        //Nút khách hàng
        private void btnKhachHang_Click(object sender, RoutedEventArgs e)
        {
            //Kiểm tra mã khách hàng nhập vào
            string _MaKH = txtKhachHang.Text.Trim();
            if (String.IsNullOrEmpty(_MaKH))
            {
                MessageBox.Show("Vui lòng nhập vào mã khách hàng!");
                txtKhachHang.Focus();
                txtKhachHang.SelectAll();
                return;
            }

            string _checkMaKh = @"^([a-zA-Z0-9._]+)$";
            if (!Regex.IsMatch(_MaKH, _checkMaKh))
            {
                MessageBox.Show("Mã khách hàng không hợp lệ!");
                txtKhachHang.Focus();
                txtKhachHang.SelectAll();
                return;
            }

            DataTable _dtKhachHang = BanHangBusiness.LayKhTheoMa(_MaKH).Tables[0];
            if (_dtKhachHang.Rows.Count == 0)//Chưa có khách hàng này
            {
                //Thêm mới khách hàng
                KhachHangThemPresentation wpf_ThemKh = new KhachHangThemPresentation();
                wpf_ThemKh._ThemKhachHang += new EventHandler(ThemKhachHang);
                wpf_ThemKh.ShowDialog();
            }
            else //Đã có khách hàng
            {
                //Lấy thông tin khách hàng
                KhachHangPublic _kh = new KhachHangPublic();
                _kh.MaKH_KH = _dtKhachHang.Rows[0]["MaKH_KH"].ToString();
                _kh.HoTen_KH = _dtKhachHang.Rows[0]["HoTen_KH"].ToString();
                _kh.GioiTinh_KH = _dtKhachHang.Rows[0]["GioiTinh_KH"].ToString();
                _kh.NgaySinh_KH = Convert.ToDateTime(_dtKhachHang.Rows[0]["NgaySinh_KH"].ToString());
                _kh.Email_KH = _dtKhachHang.Rows[0]["Email_KH"].ToString();
                _kh.NHK_KH.MaNKH_NKH = _dtKhachHang.Rows[0]["Ma_NHK_KH"].ToString();
                _kh.NHK_KH.TenNKH_NKH = _dtKhachHang.Rows[0]["TenNKH_NKH"].ToString();
                _kh.NHK_KH.Anh_NKH = _dtKhachHang.Rows[0]["Anh_NKH"].ToString();
                _kh.NHK_KH.ChietKhau_NKH = Convert.ToInt32(_dtKhachHang.Rows[0]["ChietKhau_NKH"].ToString());
                _kh.DiemTichLuy_KH = Convert.ToInt32(_dtKhachHang.Rows[0]["DiemTichLuy_KH"].ToString());
                _kh.SoLanMuaHang_KH = Convert.ToInt32(_dtKhachHang.Rows[0]["SoLanMuaHang_KH"].ToString());
                _kh.LanMuaHangGanNhat_KH = Convert.ToDateTime(_dtKhachHang.Rows[0]["LanMuaHangGanNhat_KH"].ToString());
                _kh.SDT_KH = _dtKhachHang.Rows[0]["SDT_KH"].ToString();
                _kh.GhiChu = _dtKhachHang.Rows[0]["GhiChu_KH"].ToString();
                _kh.NgayTao_KH = Convert.ToDateTime(_dtKhachHang.Rows[0]["NgayTao_KH"].ToString());
                _kh.TuDongLenNhom_KH = _dtKhachHang.Rows[0]["TuDongLenNhom_KH"].ToString() == "True" ? true : false;

                //Hiển thị thông tin khách hàng
                BanHang_KH_UPresentation wpf = new BanHang_KH_UPresentation();
                wpf._XoaKH += new EventHandler(HuyKhahHang);
                wpf._kh = _kh;
                gdKhachHang.Children.Clear();
                gdKhachHang.Children.Add(wpf);

                //Lấy chiết khấu hóa đơn
                _hoaDon.KhachHang_HD = _kh;

                //Tính tổng tiền
                TongTien();
            }
        }
        //THêm khách hàng khi chưa có mã khách hàng đó
        private void ThemKhachHang(object sender, EventArgs e)
        {
            //Lấy thông tin khách hàng
            KhachHangThemPresentation wpf = (KhachHangThemPresentation)sender;
            KhachHangPublic _kh = wpf._kh;

            if (KhachHangBusiness.ThemKhachHang(_kh))
            {
                //Lấy nhóm khách hàng theo mã
                DataTable _dtNKH = BanHangBusiness.LayNKHTheoMa(_kh.NHK_KH.MaNKH_NKH).Tables[0];
                if (_dtNKH.Rows.Count > 0)
                {
                    _kh.NHK_KH.TenNKH_NKH = _dtNKH.Rows[0]["TenNKH_NKH"].ToString();
                    _kh.NHK_KH.ChietKhau_NKH = Convert.ToInt32(_dtNKH.Rows[0]["ChietKhau_NKH"].ToString());
                    _kh.NHK_KH.Diem_NKH = Convert.ToInt32(_dtNKH.Rows[0]["Diem_NKH"].ToString());
                    _kh.NHK_KH.Anh_NKH = _dtNKH.Rows[0]["Anh_NKH"].ToString();
                }


                //Hiển thị thông tin khách hàng
                BanHang_KH_UPresentation wpfKhachHang = new BanHang_KH_UPresentation();
                wpfKhachHang._kh = _kh;
                gdKhachHang.Children.Clear();
                gdKhachHang.Children.Add(wpfKhachHang);

                //Lấy chiết khấu hóa đơn
                _hoaDon.KhachHang_HD = _kh;

                //Tính tổng
                TongTien();
            }
            else
            {
                MessageBox.Show("Thêm khách hàng thất bại!");
            }
        }

        //Hủy khách hàng hiện thời
        private void HuyKhahHang(object sender, EventArgs e)
        {
            //Xóa khách hàng hiện thời trong hóa đơn
            _hoaDon.KhachHang_HD = new KhachHangPublic();

            //Tính lại tổng tiền
            TongTien();

            //Bỏ thông tin khách hàng đang hiển thị
            gdKhachHang.Children.Clear();
            txtKhachHang.Text = "";
            txtKhachHang.Focus();
        }

        //Nút sửa hàng mua
        private void btnSuaSP_Click(object sender, RoutedEventArgs e)
        {
            //Lấy thông tin sp
            SanPhamPublic _spTemp = (dgDanhSachSanPham.SelectedItem as SanPhamPublic);
            SanPhamPublic _sp = new SanPhamPublic();
            _sp.MaSP_SP = _spTemp.MaSP_SP;
            _sp.TenSP_SP = _spTemp.TenSP_SP;
            _sp.GiaNhap_SP = _spTemp.GiaNhap_SP;
            _sp.GiaBan = _spTemp.GiaBan;
            _sp.SoLuong_SP = _spTemp.SoLuong_SP;
            _sp.CKTienMat = _spTemp.CKTienMat;
            _sp.CKPhanTram_SP = _spTemp.CKPhanTram_SP;
            _sp.DVT_SP.TenDVT_DVT = _spTemp.DVT_SP.TenDVT_DVT;

            txtMaHang.Focus();
            //Hiển thị wpf sửa
            BanHangSuaHangMuaPresentation wpf = new BanHangSuaHangMuaPresentation();
            wpf._SuaSanPham += new EventHandler(SuaSPMua);
            wpf._sp = _sp;
            wpf.ShowDialog();
        }
        //Phương thức sửa hàng mua
        private void SuaSPMua(object sender, EventArgs e)
        {
            //Lấy thông tin sửa
            BanHangSuaHangMuaPresentation wpf = (BanHangSuaHangMuaPresentation)sender;
            SanPhamPublic _sp = wpf._sp;

            //Cập nhật lại thông tin trong giỏ hàng
            _dsSPMua.Where(item => item.MaSP_SP == _sp.MaSP_SP).First().SoLuong_SP = _sp.SoLuong_SP;
            _dsSPMua.Where(item => item.MaSP_SP == _sp.MaSP_SP).First().CKTienMat = _sp.CKTienMat;

            //Tính lại thành tiền vào tổng tiền
            int _giaBan = Convert.ToInt32(UntilitiesBusiness.BoDauPhay(_dsSPMua.Where(item => item.MaSP_SP == _sp.MaSP_SP).First().GiaBan));
            int _giaNhap = Convert.ToInt32(UntilitiesBusiness.BoDauPhay(_dsSPMua.Where(item => item.MaSP_SP == _sp.MaSP_SP).First().GiaNhap_SP));
            int _soLuong = _dsSPMua.Where(item => item.MaSP_SP == _sp.MaSP_SP).First().SoLuong_SP;

            int _TongTien = _giaBan * _soLuong;
            int _ckTienMat = Convert.ToInt32(UntilitiesBusiness.BoDauPhay(_dsSPMua.Where(item => item.MaSP_SP == _sp.MaSP_SP).First().CKTienMat));
            int _thanhTien = _TongTien - _ckTienMat;

            _dsSPMua.Where(item => item.MaSP_SP == _sp.MaSP_SP).First().ThanhTien_SP = UntilitiesBusiness.ThemDauPhay(_thanhTien.ToString());


            //Hiển thị giỏ hàng
            dgDanhSachSanPham.ItemsSource = _dsSPMua;
            dgDanhSachSanPham.Items.Refresh();

            //Tính tổng tiền
            TongTien();
        }

        //Nút chiết khấu
        private void btnChietKhau_Click(object sender, RoutedEventArgs e)
        {
            if (_dsSPMua.Count == 0)
            {
                MessageBox.Show("Chưa có sản phẩm nào trong giỏ hàng !");
                return;
            }

            //Lấy thông tin: hóa đơn | khách hàng
            HoaDonPublic _hdTemp = _hoaDon;

            BanHangSuaChietKhauPresentation wpf = new BanHangSuaChietKhauPresentation();
            wpf._hoaDon = _hdTemp;
            wpf._SuaChietKhau += new EventHandler(SuaChietKhauHD);
            wpf.ShowDialog();
        }

        //Phương thức sửa chiết khấu hóa đơn
        private void SuaChietKhauHD(object sender, EventArgs e)
        {
            //Lấy thông tin(Tổng chiết khấu hóa đơn)
            BanHangSuaChietKhauPresentation wpf = (BanHangSuaChietKhauPresentation)sender;
            HoaDonPublic _hdTemp = wpf._hoaDon;

            int _TongCkHD = _hdTemp.TongCKHoaDon;


            //Tính lại thành tiền
            _hoaDon.TongCKHoaDon = _TongCkHD;
            _hoaDon.ThanhTien = _hoaDon.TongTien_HD - _hoaDon.TongCKSanPham - _hoaDon.TongCKHoaDon;
            _hoaDon.TienConLaiPhaiTra = _hoaDon.ThanhTien;

            //Hiển thị
            txtbCkHoaDon.Text = UntilitiesBusiness.ThemDauPhay(_hoaDon.TongCKHoaDon.ToString());
            txtbThanhTien.Text = UntilitiesBusiness.ThemDauPhay(_hoaDon.ThanhTien.ToString());
            txtbConPhaiTra.Text = txtbThanhTien.Text;
        }

        //txt mã hàng text change
        private void txtMaHang_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtMaHang.Text.StartsWith("."))
                txtMaHang.Text = "";
        }

        //Bắt sự kiện phím
        protected override void OnPreviewKeyDown(KeyEventArgs e)
        {
            //MessageBox.Show(e.Key.ToString());
            if (e.Key == Key.F1)//txt mã hàng
            {
                txtMaHang.Focus();
                txtMaHang.SelectionStart = txtMaHang.Text.Length;
            }

            if (e.Key == Key.F2)
            {
                if (rdBanLe.IsEnabled == true)
                {
                    rdBanLe.IsChecked = !rdBanLe.IsChecked;
                    rdBanBuon.IsChecked = !rdBanLe.IsChecked;
                }
            }

            if (e.Key == Key.OemPeriod)
            {
                if (txtMaHang.IsFocused == false)
                {
                    if (txtKhachHang.IsFocused == true && txtKhachHang.Text.Length > 0)
                        return;
                    txtMaHang.Focus();
                }
            }

            if (e.Key == Key.F7)
            {
                txtKhachHang.Focus();
                txtKhachHang.SelectAll();
            }

            base.OnPreviewKeyDown(e);
        }
        private void Grid_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.F4)
                if (btnThanhToan.IsEnabled)
                    btnThanhToan_Click(sender, e);
            if (e.Key == Key.F5)
                if (btnChietKhau.IsEnabled)
                    btnChietKhau_Click(sender, e);
            if (e.Key == Key.F6)
                if (btnHuy.IsEnabled)
                    btnHuy_Click(sender, e);
        }

        //txtKhách hàng key up
        private void txtKhachHang_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                btnKhachHang_Click(sender, e);
        }

        //txt mã sản phẩm preview keydown
        private void txtMaHang_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                //Kiểm tra xem mã có hợp lệ không(Mã chỉ chứa chữ cái, dấu chấm và dấu gạch dưới)
                string _checkMaSp = @"^([a-zA-Z0-9._?]+)$";
                if (!Regex.IsMatch(txtMaHang.Text.Trim(), _checkMaSp))
                {
                    lbWarning.Visibility = System.Windows.Visibility.Visible;
                    lbWarning.Text = "Mã sản phẩm không hợp lệ!";
                    txtMaHang.Focus();
                    txtMaHang.SelectAll();
                    return;
                }

                if (txtMaHang.Text.Trim().EndsWith("?"))
                {
                    NhapMua_TimKiemSPPresentation wpf_tim = new NhapMua_TimKiemSPPresentation();
                    wpf_tim._strTim = txtMaHang.Text.Trim().Replace("?", "");
                    wpf_tim._TimKiemSP += new EventHandler(TimKiemSP);
                    wpf_tim.ShowDialog();
                }
                else
                    btnThemHang_Click(sender, e);
            }
        }
        //Timfm kiếm sản phẩm
        private void TimKiemSP(object sender, EventArgs e)
        {
            NhapMua_TimKiemSPPresentation wpf_tim = (NhapMua_TimKiemSPPresentation)sender;
            List<SanPhamPublic> _lstSPTim = wpf_tim._ListSPChon;
            if (_lstSPTim.Count > 0)
            {
                foreach (SanPhamPublic _sp in _lstSPTim)
                {
                    //Kiểm tra xem trong hệ thống có sản phẩm này không?
                    DataTable _dtSp = BanHangBusiness.LaySpTheoMa(_sp.MaSP_SP).Tables[0];//Chứa toàn bộ sản phẩm của hệ thống
                    if (_dtSp.Rows.Count == 0)
                    {
                        lbWarning.Visibility = System.Windows.Visibility.Visible;
                        lbWarning.Text = "Mã sản phẩm không tồn tại. Vui lòng kiểm tra lại!";
                        txtMaHang.Focus();
                        txtMaHang.SelectAll();
                        return;
                    }
                    //Kiểm tra số lượng hàng có đủ ko?
                    int _SoLuongCon = Convert.ToInt32(_dtSp.Rows[0]["SoLuong_SP"].ToString());
                    if (_SoLuongCon < 1)
                    {
                        lbWarning.Visibility = System.Windows.Visibility.Visible;
                        lbWarning.Text = "Hết sản phẩm.";
                        txtMaHang.Focus();
                        txtMaHang.SelectAll();
                        return;
                    }
                    _dtSp.Dispose();

                    ThemHangVaoDsHangMua(_sp.MaSP_SP);
                }

                //Hiển thị giỏ hàng
                dgDanhSachSanPham.ItemsSource = _dsSPMua;
                dgDanhSachSanPham.Items.Refresh();

                //Tính tổng tiền hóa đơn
                TongTien();

                //Đặt con trỏ vào ô nhập mã hàng khác
                txtMaHang.Focus();
                txtMaHang.Text = "";

                btnThanhToan.IsEnabled = true;
                btnChietKhau.IsEnabled = true;
                btnHuy.IsEnabled = true;
            }
        }

    }//End class
}

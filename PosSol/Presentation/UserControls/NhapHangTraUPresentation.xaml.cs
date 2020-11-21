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
using Public;
using Business;
using Presentation.WindowWpf;
using Presentation.Dataset;
using System.Data;
using Presentation.Report;


namespace Presentation.UserControls
{
    /// <summary>
    /// Chức năng trả hàng 
    /// Nếu hóa đơn trả tất cả hàng thì lưu sản phẩm vào kho, tính trả tiền khách
    /// Nếu trả một số sp thì hủy hóa đơn cũ, xuất hóa đơn mới
    /// Nếu trả một số rồi mua thếm sp khác thì hủy hóa đơn cũ và sang giao diện mua hàng
    /// </summary>
    public partial class NhapHangTraUPresentation : UserControl
    {

        //Khai báo
        public NhanVienPublic _NhanVien = new NhanVienPublic();//Người đăng nhập
        HoaDonPublic _hoaDon;//Lưu thông tin hóa đơn cần hủy
        public HoaDonPublic _hoaDonMoi = new HoaDonPublic();
        List<HangMuaPubLic> _lstHangMua;
        List<HangMuaPubLic> _lstHangTra;
        int _TienDaTra; //Tiền đã trả từ hóa đơn trước
        int _TienSauTraSp;
        public event EventHandler _TiepTucMua;
        public List<SanPhamPublic> _lstSpTiepTucMua;

        public NhapHangTraUPresentation()
        {
            InitializeComponent();
            //hiển thị ban đầu
            lbWarning.Visibility = System.Windows.Visibility.Hidden;
            lbSoHD.Content = "";
            lbNgayLap.Content = "";
            lbNhanVien.Content = "";
            lbKhachHang.Content = "";
            lbThanhTien.Content = "";
        }

        //wpf loaded
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            //Tắt nút
            //Tắt nút thanh toán
            btnThanhToan.IsEnabled = false;
            btnTiepTucMua.IsEnabled = false;
            txtSoHD.Text = "";
            txtSoHD.Focus();
        }

        //Nút nhập hóa đơn
        private void btnHoDon_Click(object sender, RoutedEventArgs e)
        {
            if (txtSoHD.Text.EndsWith("?"))
            {
                KiemKeTimHoaDonPresentation wpf = new KiemKeTimHoaDonPresentation();
                wpf._strTim = txtSoHD.Text.Replace("?", "");
                wpf._TimHoaDon += new EventHandler(TimHoaDon);
                wpf.ShowDialog();
                goto go;
            }

            //Kiểm tra số hóa đơn nhập vào
            if (!KiemTraSoHD())
                return;
        go:
            //Lấy hóa đơn và hàng mua
            string _soHD = txtSoHD.Text.Trim();
            List<HangMuaPubLic> _lst = TraHangBusiness.LayDsHangMua(_soHD);
            if (_lst != null)
            {
                _lstHangMua = _lst;
                _hoaDon = _lstHangMua[0].HoaDon;

                //Kiểm tra xem giá bán có thay đổi ko. nếu có thì ko cho mua tiếp trên hóa đơn này
                KiemTraGia();

                //Hiển thị thông tin
                dgHangMua.ItemsSource = _lstHangMua;

                lbSoHD.Content = _hoaDon.SoHD_HD;
                lbNgayLap.Content = _hoaDon.NgayLap_HD.ToString("dd/MM/yyyy HH:mm tt");
                lbNhanVien.Content = _hoaDon.NguoiLap_HD.MaNV_NV;

                //Khách hàng
                if (String.IsNullOrEmpty(_hoaDon.KhachHang_HD.MaKH_KH))
                    lbKhachHang.Content = "Khách vãng lai";
                else
                {
                    _hoaDon.KhachHang_HD = TraHangBusiness.LayKhachHang(_hoaDon.KhachHang_HD.MaKH_KH);
                    lbKhachHang.Content = _hoaDon.KhachHang_HD.HoTen_KH;
                }

                //Tính tổng tiền hóa đơn cũ
                _TienDaTra = TinhTien();
                _hoaDon.TongTien_HD = _hoaDonMoi.TongTien_HD;//Lấy tổng tiền (tính số điểm khách hàng để trừ khi hủy hóa đơn)

                //Tắt nút nhập
                txtSoHD.Text = "";
                btnHoDon.IsEnabled = false;
            }
            else
            {
                lbWarning.Visibility = System.Windows.Visibility.Visible;
                lbWarning.Content = "Lỗi hóa đơn, hóa đơn không chứa sản phẩm nào!";
                txtSoHD.Focus();
                txtSoHD.SelectAll();
            }
        }
        //Kiểm tra thay đổi giá
        private void KiemTraGia()
        {
            if (_lstHangMua == null)
                return;
            string _SPThayDoiGia = "";
            foreach (HangMuaPubLic _hm in _lstHangMua)
            {
                int _giaBanCu = Convert.ToInt32(UntilitiesBusiness.BoDauPhay(_hm.GiaBan_HM));
                int _giaBanMoi;
                if (_hm.HoaDon.BanLe_HD)
                    _giaBanMoi = Convert.ToInt32(UntilitiesBusiness.BoDauPhay(_hm.SanPham.GiaBanLe_SP));
                else
                    _giaBanMoi = Convert.ToInt32(UntilitiesBusiness.BoDauPhay(_hm.SanPham.GiaBanSi_SP));

                if (_giaBanMoi != _giaBanCu)
                {
                    _SPThayDoiGia = _SPThayDoiGia + " " + _hm.SanPham.MaSP_SP;
                }
            }
            if (_SPThayDoiGia != "")
            {
                lbWarning.Visibility = System.Windows.Visibility.Visible;
                lbWarning.Content = "Giá bán sản phẩm(" + _SPThayDoiGia + ") đã thay đổi.Chức năng tiếp tục mua trên hóa đơn bị tắt!";
                btnTiepTucMua.IsEnabled = false;
            }

            return;
        }

        //Tính tiền khách đã thanh toán ở hóa đơn cũ
        private int TinhTien()
        {
            if (_lstHangMua == null || _hoaDon == null)
                return 0;

            int _TongTien = 0;
            int _TongCkSP = 0;
            float _CkHD = 0;//Phần trăm
            int _TongCkHd = _hoaDon.TongCKHoaDon;//Tiền
            int _Voucher = _hoaDon.VouCher_HD;
            int _TienMaGiamGia = 0;//Tiền
            int _CkMaGiamGia = 0;//Phần trăm
            int _ThanhTien = 0;
            if (!String.IsNullOrEmpty(_hoaDon.MaGiamGia.MaThe_MGG))
                _CkMaGiamGia = TraHangBusiness.LayCKMaGiamGia(_hoaDon.MaGiamGia.MaThe_MGG);

            foreach (HangMuaPubLic _hm in _lstHangMua)
            {
                _TongTien = _TongTien + Convert.ToInt32(UntilitiesBusiness.BoDauPhay(_hm.GiaBan_HM)) * _hm.SoLuong;
                _TongCkSP = _TongCkSP + Convert.ToInt32(UntilitiesBusiness.BoDauPhay(_hm.ChietKhauTienMat));
            }

            //Tính tiền chiết khấu từ mã giảm giá
            _TienMaGiamGia = _TongTien * _CkMaGiamGia / 100;

            //Tiền triết khấu từ nhóm khách hàng
            _CkHD = _hoaDon.CKPhanTram_HD;
            _TongCkHd = (int)(_TongTien * _CkHD / 100);
            if (_TongCkHd.ToString().EndsWith("9"))
                _TongCkHd = _TongCkHd + 1;

            _ThanhTien = _TongTien - _TongCkSP - _TongCkHd - _Voucher - _TienMaGiamGia;

            if (_ThanhTien < 0)
                _ThanhTien = 0;

            //Hiển thị thành tiền
            lbTongTien.Content = UntilitiesBusiness.ThemDauPhay(_TongTien.ToString());
            lbTongCkSP.Content = UntilitiesBusiness.ThemDauPhay(_TongCkSP.ToString());
            lbTongCKHD.Content = UntilitiesBusiness.ThemDauPhay(_TongCkHd.ToString());
            lbVoucher.Content = UntilitiesBusiness.ThemDauPhay(_Voucher.ToString());
            lbMaGiamGia.Content = UntilitiesBusiness.ThemDauPhay(_TienMaGiamGia.ToString());
            lbThanhTien.Content = UntilitiesBusiness.ThemDauPhay(_ThanhTien.ToString());

            _TienSauTraSp = _ThanhTien;

            //Hóa đơn mới
            if (_hoaDonMoi == null)
                _hoaDonMoi = new HoaDonPublic();

            _hoaDonMoi.TongTien_HD = _TongTien;
            _hoaDonMoi.CKPhanTram_HD = _CkHD;
            _hoaDonMoi.TongCKHoaDon = _TongCkHd;
            _hoaDonMoi.TongCKSanPham = _TongCkSP;
            _hoaDonMoi.VouCher_HD = _Voucher;
            _hoaDonMoi.TienMaGiamGia = _TienMaGiamGia;
            _hoaDonMoi.TienKhachTra_HD = _ThanhTien;
            _hoaDonMoi.TienThuaTraLaiKhach = 0;
            _hoaDonMoi.ThanhTien = _ThanhTien;

            return _ThanhTien;
        }

        //Kiểm tra số hóa đơn nhập vào
        private bool KiemTraSoHD()
        {
            string _soHD = txtSoHD.Text.Trim();
            if (String.IsNullOrEmpty(_soHD))
            {
                lbWarning.Visibility = System.Windows.Visibility.Visible;
                lbWarning.Content = "Nhập vào số hóa đơn!";
                txtSoHD.Focus();
                return false;
            }


            string _strKiemTraSoHD = @"^([a-zA-Z0-9._-]*)$";
            if (!System.Text.RegularExpressions.Regex.IsMatch(_soHD, _strKiemTraSoHD))
            {
                lbWarning.Visibility = System.Windows.Visibility.Visible;
                lbWarning.Content = "Số hóa đơn sai định dạng!";
                txtSoHD.Focus();
                txtSoHD.SelectAll();
                return false;
            }

            //Kiểm tra có hóa đơn này ko?
            HoaDonPublic _hd = TraHangBusiness.LayHoaDon(_soHD);
            if (_hd == null)
            {
                lbWarning.Visibility = System.Windows.Visibility.Visible;
                lbWarning.Content = "Hóa đơn không tồn tại!";
                txtSoHD.Focus();
                txtSoHD.SelectAll();
                return false;
            }

            lbWarning.Visibility = System.Windows.Visibility.Hidden;
            return true;
        }

        //Phương thức tìm hóa đơn
        private void TimHoaDon(object sender, EventArgs e)
        {
            KiemKeTimHoaDonPresentation wpf = (KiemKeTimHoaDonPresentation)sender;
            string _soHD = wpf._soHD;
            txtSoHD.Text = _soHD;
        }

        //Nút trả từng sản phẩm
        private void btnTra_Click(object sender, RoutedEventArgs e)
        {
            #region Lấy thông tin hàng mua (Lấy chi tiết vì bị lỗi)
            HangMuaPubLic _hmTemp = (HangMuaPubLic)dgHangMua.SelectedItem;
            HangMuaPubLic _hm = new HangMuaPubLic();
            //Lấy thông tin sản phẩm
            _hm.SanPham.MaSP_SP = _hmTemp.SanPham.MaSP_SP;
            _hm.SanPham.TenSP_SP = _hmTemp.SanPham.TenSP_SP;
            _hm.SanPham.GiaNhap_SP = _hmTemp.SanPham.GiaNhap_SP;
            _hm.SanPham.GiaBanLe_SP = _hmTemp.SanPham.GiaBanLe_SP;
            _hm.SanPham.GiaBanSi_SP = _hmTemp.SanPham.GiaBanSi_SP;
            _hm.SanPham.NCC_SP.MaNCC_NCC = _hmTemp.SanPham.NCC_SP.MaNCC_NCC;
            _hm.SanPham.NSP_SP.MaNSP_NSP = _hmTemp.SanPham.NSP_SP.MaNSP_NSP;
            _hm.SanPham.DVT_SP.MaDVT_DVT = _hmTemp.SanPham.DVT_SP.MaDVT_DVT;
            _hm.SanPham.DVT_SP.TenDVT_DVT = _hmTemp.SanPham.DVT_SP.TenDVT_DVT;
            _hm.SanPham.GhiChu_SP = _hmTemp.SanPham.GhiChu_SP;
            _hm.SanPham.SoLuong_SP = _hmTemp.SanPham.SoLuong_SP;
            _hm.SanPham.CKPhanTram_SP = _hmTemp.SanPham.CKPhanTram_SP;
            _hm.SanPham.Anh_SP = _hmTemp.SanPham.Anh_SP;
            _hm.SanPham.NgayTao_SP = _hmTemp.SanPham.NgayTao_SP;

            //Thông tin hàng mua
            _hm.SoLuong = _hmTemp.SoLuong;
            _hm.ChietKhauPhanTram = _hmTemp.ChietKhauPhanTram;
            _hm.ChietKhauTienMat = _hmTemp.ChietKhauTienMat;
            _hm.GiaBan_HM = _hmTemp.GiaBan_HM;
            _hm.GiaNhap_HM = _hmTemp.GiaNhap_HM;

            //Lấy thông tin hóa đơn
            _hm.HoaDon.SoHD_HD = _hm.HoaDon.SoHD_HD;
            _hm.HoaDon.NgayLap_HD = _hm.HoaDon.NgayLap_HD;
            _hm.HoaDon.NguoiLap_HD = _hm.HoaDon.NguoiLap_HD;
            _hm.HoaDon.BanLe_HD = _hm.HoaDon.BanLe_HD;
            _hm.HoaDon.KhachHang_HD.MaKH_KH = _hm.HoaDon.KhachHang_HD.MaKH_KH;
            _hm.HoaDon.CKPhanTram_HD = _hm.HoaDon.CKPhanTram_HD;
            _hm.HoaDon.TienKhachTra_HD = _hm.HoaDon.TienKhachTra_HD;
            _hm.HoaDon.VouCher_HD = _hm.HoaDon.VouCher_HD;
            _hm.HoaDon.MaGiamGia.MaThe_MGG = _hm.HoaDon.MaGiamGia.MaThe_MGG;
            _hm.HoaDon.TongCKHoaDon = _hm.HoaDon.TongCKHoaDon;
            #endregion

            //Trừ số lượng trên list hàng mua
            _lstHangMua.Where(item => item.SanPham.MaSP_SP == _hm.SanPham.MaSP_SP).First().SoLuong--;

            //Nếu số lượng còn bằng  0 thì xóa luôn
            if (_lstHangMua.Where(item => item.SanPham.MaSP_SP == _hm.SanPham.MaSP_SP).First().SoLuong == 0)
            {
                var _hmRemove = _lstHangMua.Single(item => item.SanPham.MaSP_SP == _hm.SanPham.MaSP_SP);
                _lstHangMua.Remove(_hmRemove);
            }

            //Tính lại chiết khấu sản phẩm
            HangMuaPubLic _result = _lstHangMua.Find(item => item.SanPham.MaSP_SP == _hm.SanPham.MaSP_SP);
            if (_result != null)
            {
                float _CkSp = _result.ChietKhauPhanTram;
                int _GiaBan = Convert.ToInt32(UntilitiesBusiness.BoDauPhay(_result.GiaBan_HM));
                int _soLuong = _result.SoLuong;
                int _CkTienMatSp = (int)((_CkSp * _GiaBan / 100) * _soLuong);

                if (_CkTienMatSp.ToString().EndsWith("9"))
                    _CkTienMatSp++;


                int _TongTien = 0;
                int _ThanhTien = 0;

                _TongTien = _soLuong * _GiaBan;
                _ThanhTien = _TongTien - _CkTienMatSp;

                _lstHangMua.Where(item => item.SanPham.MaSP_SP == _hm.SanPham.MaSP_SP).First().ChietKhauTienMat = _CkTienMatSp.ToString();
                _lstHangMua.Where(item => item.SanPham.MaSP_SP == _hm.SanPham.MaSP_SP).First().ThanhTien = _ThanhTien;
                _lstHangMua.Where(item => item.SanPham.MaSP_SP == _hm.SanPham.MaSP_SP).First().TongTienSP = _TongTien;
            }

            //Thêm sp vào danh sách hàng trả
            if (_lstHangTra == null)
                _lstHangTra = new List<HangMuaPubLic>();
            if (_lstHangTra.Count == 0)
            {
                _hm.SoLuong = 1;
                _lstHangTra.Add(_hm);
            }
            else
            {
                HangMuaPubLic _rsHangTr = _lstHangTra.Find(item => item.SanPham.MaSP_SP == _hm.SanPham.MaSP_SP);
                if (_rsHangTr != null)
                    _lstHangTra.Where(item => item.SanPham.MaSP_SP == _hm.SanPham.MaSP_SP).First().SoLuong++;
                else
                {
                    _hm.SoLuong = 1;
                    _lstHangTra.Add(_hm);
                }
            }

            //Tính lại thành tiền
            TinhTien();

            //Hiển thị danh sách sp
            libHangTra.ItemsSource = _lstHangTra;
            libHangTra.Items.Refresh();

            dgHangMua.ItemsSource = _lstHangMua;
            dgHangMua.Items.Refresh();

            //Bật nút thanh toán
            btnThanhToan.IsEnabled = true;
            btnTiepTucMua.IsEnabled = true;
        }

        //Nút trả hàng tất cả
        private void btnTra_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            #region Lấy thông tin hàng mua (Lấy chi tiết vì bị lỗi)
            HangMuaPubLic _hmTemp = (HangMuaPubLic)dgHangMua.SelectedItem;
            if (_hmTemp == null)
                return;
            HangMuaPubLic _hm = new HangMuaPubLic();
            //Lấy thông tin sản phẩm
            _hm.SanPham.MaSP_SP = _hmTemp.SanPham.MaSP_SP;
            _hm.SanPham.TenSP_SP = _hmTemp.SanPham.TenSP_SP;
            _hm.SanPham.GiaNhap_SP = _hmTemp.SanPham.GiaNhap_SP;
            _hm.SanPham.GiaBanLe_SP = _hmTemp.SanPham.GiaBanLe_SP;
            _hm.SanPham.GiaBanSi_SP = _hmTemp.SanPham.GiaBanSi_SP;
            _hm.SanPham.NCC_SP.MaNCC_NCC = _hmTemp.SanPham.NCC_SP.MaNCC_NCC;
            _hm.SanPham.NSP_SP.MaNSP_NSP = _hmTemp.SanPham.NSP_SP.MaNSP_NSP;
            _hm.SanPham.DVT_SP.MaDVT_DVT = _hmTemp.SanPham.DVT_SP.MaDVT_DVT;
            _hm.SanPham.DVT_SP.TenDVT_DVT = _hmTemp.SanPham.DVT_SP.TenDVT_DVT;
            _hm.SanPham.GhiChu_SP = _hmTemp.SanPham.GhiChu_SP;
            _hm.SanPham.SoLuong_SP = _hmTemp.SanPham.SoLuong_SP;
            _hm.SanPham.CKPhanTram_SP = _hmTemp.SanPham.CKPhanTram_SP;
            _hm.SanPham.Anh_SP = _hmTemp.SanPham.Anh_SP;
            _hm.SanPham.NgayTao_SP = _hmTemp.SanPham.NgayTao_SP;

            //Thông tin hàng mua
            _hm.SoLuong = _hmTemp.SoLuong;
            _hm.ChietKhauPhanTram = _hmTemp.ChietKhauPhanTram;
            _hm.ChietKhauTienMat = _hmTemp.ChietKhauTienMat;
            _hm.GiaBan_HM = _hmTemp.GiaBan_HM;
            _hm.GiaNhap_HM = _hmTemp.GiaNhap_HM;

            //Lấy thông tin hóa đơn
            _hm.HoaDon.SoHD_HD = _hm.HoaDon.SoHD_HD;
            _hm.HoaDon.NgayLap_HD = _hm.HoaDon.NgayLap_HD;
            _hm.HoaDon.NguoiLap_HD = _hm.HoaDon.NguoiLap_HD;
            _hm.HoaDon.BanLe_HD = _hm.HoaDon.BanLe_HD;
            _hm.HoaDon.KhachHang_HD.MaKH_KH = _hm.HoaDon.KhachHang_HD.MaKH_KH;
            _hm.HoaDon.CKPhanTram_HD = _hm.HoaDon.CKPhanTram_HD;
            _hm.HoaDon.TienKhachTra_HD = _hm.HoaDon.TienKhachTra_HD;
            _hm.HoaDon.VouCher_HD = _hm.HoaDon.VouCher_HD;
            _hm.HoaDon.MaGiamGia.MaThe_MGG = _hm.HoaDon.MaGiamGia.MaThe_MGG;
            _hm.HoaDon.TongCKHoaDon = _hm.HoaDon.TongCKHoaDon;

            #endregion

            //Xóa khỏi danh sách hàng mua
            var _hmRemove = _lstHangMua.Single(item => item.SanPham.MaSP_SP == _hm.SanPham.MaSP_SP);
            _lstHangMua.Remove(_hmRemove);

            //Thêm sp vào danh sách hàng trả
            if (_lstHangTra == null)
                _lstHangTra = new List<HangMuaPubLic>();
            if (_lstHangTra.Count == 0)
            {
                _lstHangTra.Add(_hm);
            }
            else
            {
                HangMuaPubLic _rsHangTr = _lstHangTra.Find(item => item.SanPham.MaSP_SP == _hm.SanPham.MaSP_SP);
                if (_rsHangTr != null)
                    _lstHangTra.Where(item => item.SanPham.MaSP_SP == _hm.SanPham.MaSP_SP).First().SoLuong += _hm.SoLuong;
                else
                    _lstHangTra.Add(_hm);
            }

            //Tính lại thành tiền
            TinhTien();

            //Hiển thị danh sách sp
            libHangTra.ItemsSource = _lstHangTra;
            libHangTra.Items.Refresh();

            dgHangMua.ItemsSource = _lstHangMua;
            dgHangMua.Items.Refresh();

            //Bật nút thanh toán
            btnThanhToan.IsEnabled = true;
            btnTiepTucMua.IsEnabled = true;
        }

        private void ItemOnPreviewMouseDown(object sender, MouseButtonEventArgs e)
        {

        }
        //Nút khôi phục
        private void btnKhoiPhuc_Click(object sender, RoutedEventArgs e)
        {
            //Lấy chỉ số dòng chọn // ko chơi dc kiểu như datagrid
            Button _button = sender as Button;
            int _index = libHangTra.Items.IndexOf(_button.DataContext);

            #region Lấy thông tin hàng trả muốn khôi phục lại
            HangMuaPubLic _hmTemp = _lstHangTra[_index];
            HangMuaPubLic _hm = new HangMuaPubLic();
            //Lấy thông tin sản phẩm
            _hm.SanPham.MaSP_SP = _hmTemp.SanPham.MaSP_SP;
            _hm.SanPham.TenSP_SP = _hmTemp.SanPham.TenSP_SP;
            _hm.SanPham.GiaNhap_SP = _hmTemp.SanPham.GiaNhap_SP;
            _hm.SanPham.GiaBanLe_SP = _hmTemp.SanPham.GiaBanLe_SP;
            _hm.SanPham.GiaBanSi_SP = _hmTemp.SanPham.GiaBanSi_SP;
            _hm.SanPham.NCC_SP.MaNCC_NCC = _hmTemp.SanPham.NCC_SP.MaNCC_NCC;
            _hm.SanPham.NSP_SP.MaNSP_NSP = _hmTemp.SanPham.NSP_SP.MaNSP_NSP;
            _hm.SanPham.DVT_SP.MaDVT_DVT = _hmTemp.SanPham.DVT_SP.MaDVT_DVT;
            _hm.SanPham.DVT_SP.TenDVT_DVT = _hmTemp.SanPham.DVT_SP.TenDVT_DVT;
            _hm.SanPham.GhiChu_SP = _hmTemp.SanPham.GhiChu_SP;
            _hm.SanPham.SoLuong_SP = _hmTemp.SanPham.SoLuong_SP;
            _hm.SanPham.CKPhanTram_SP = _hmTemp.SanPham.CKPhanTram_SP;
            _hm.SanPham.Anh_SP = _hmTemp.SanPham.Anh_SP;
            _hm.SanPham.NgayTao_SP = _hmTemp.SanPham.NgayTao_SP;

            //Thông tin hàng mua
            _hm.SoLuong = _hmTemp.SoLuong;
            _hm.ChietKhauPhanTram = _hmTemp.ChietKhauPhanTram;
            _hm.ChietKhauTienMat = _hmTemp.ChietKhauTienMat;
            _hm.GiaBan_HM = _hmTemp.GiaBan_HM;
            _hm.GiaNhap_HM = _hmTemp.GiaNhap_HM;

            //Lấy thông tin hóa đơn
            _hm.HoaDon.SoHD_HD = _hm.HoaDon.SoHD_HD;
            _hm.HoaDon.NgayLap_HD = _hm.HoaDon.NgayLap_HD;
            _hm.HoaDon.NguoiLap_HD = _hm.HoaDon.NguoiLap_HD;
            _hm.HoaDon.BanLe_HD = _hm.HoaDon.BanLe_HD;
            _hm.HoaDon.KhachHang_HD.MaKH_KH = _hm.HoaDon.KhachHang_HD.MaKH_KH;
            _hm.HoaDon.CKPhanTram_HD = _hm.HoaDon.CKPhanTram_HD;
            _hm.HoaDon.TienKhachTra_HD = _hm.HoaDon.TienKhachTra_HD;
            _hm.HoaDon.VouCher_HD = _hm.HoaDon.VouCher_HD;
            _hm.HoaDon.MaGiamGia.MaThe_MGG = _hm.HoaDon.MaGiamGia.MaThe_MGG;
            _hm.HoaDon.TongCKHoaDon = _hm.HoaDon.TongCKHoaDon;

            #endregion

            //Trừ số lượng -1
            _lstHangTra.Where(item => item.SanPham.MaSP_SP == _hm.SanPham.MaSP_SP).First().SoLuong--;

            //Nếu số lượng trong list hàng trả còn lại 0 thì xóa lun
            if (_lstHangTra.Where(item => item.SanPham.MaSP_SP == _hm.SanPham.MaSP_SP).First().SoLuong == 0)
            {
                var _hmRemove = _lstHangTra.Single(item => item.SanPham.MaSP_SP == _hm.SanPham.MaSP_SP);
                _lstHangTra.Remove(_hmRemove);
            }

            //Khôi phục lại sản phẩm ở ds hàng mua
            if (_lstHangMua == null)
                _lstHangMua = new List<HangMuaPubLic>();
            if (_lstHangMua.Count == 0)
            {
                _hm.SoLuong = 1;
                _lstHangMua.Add(_hm);
            }
            else
            {
                HangMuaPubLic _rsHangTr = _lstHangMua.Find(item => item.SanPham.MaSP_SP == _hm.SanPham.MaSP_SP);
                if (_rsHangTr != null)
                    _lstHangMua.Where(item => item.SanPham.MaSP_SP == _hm.SanPham.MaSP_SP).First().SoLuong++;
                else
                {
                    _hm.SoLuong = 1;
                    _lstHangMua.Add(_hm);
                }
            }


            //Tính lại chiết khấu sản phẩm
            HangMuaPubLic _result = _lstHangMua.Find(item => item.SanPham.MaSP_SP == _hm.SanPham.MaSP_SP);
            if (_result != null)
            {
                float _CkSp = _result.ChietKhauPhanTram;
                int _GiaBan = Convert.ToInt32(UntilitiesBusiness.BoDauPhay(_result.GiaBan_HM));
                int _soLuong = _result.SoLuong;
                int _CkTienMatSp = (int)((_CkSp * _GiaBan / 100) * _soLuong);

                if (_CkTienMatSp.ToString().EndsWith("9"))
                    _CkTienMatSp++;

                int _TongTien = 0;
                int _ThanhTien = 0;

                _TongTien = _soLuong * _GiaBan;
                _ThanhTien = _TongTien - _CkTienMatSp;

                _lstHangMua.Where(item => item.SanPham.MaSP_SP == _hm.SanPham.MaSP_SP).First().ChietKhauTienMat = _CkTienMatSp.ToString();
                _lstHangMua.Where(item => item.SanPham.MaSP_SP == _hm.SanPham.MaSP_SP).First().ThanhTien = _ThanhTien;
                _lstHangMua.Where(item => item.SanPham.MaSP_SP == _hm.SanPham.MaSP_SP).First().TongTienSP = _TongTien;
            }


            //Tính lại thành tiền
            TinhTien();

            //Hiển thị danh sách sp
            libHangTra.ItemsSource = _lstHangTra;
            libHangTra.Items.Refresh();

            dgHangMua.ItemsSource = _lstHangMua;
            dgHangMua.Items.Refresh();

            if (_lstHangTra.Count == 0)
            {
                //Tắt nút thanh toán
                btnThanhToan.IsEnabled = false;
                btnTiepTucMua.IsEnabled = false;
            }
        }

        //Khôi phục tất
        private void btnKhoiPhuc_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            //Lấy chỉ số dòng chọn // ko chơi dc kiểu như datagrid
            Button _button = sender as Button;
            int _index = libHangTra.Items.IndexOf(_button.DataContext);

            #region Lấy thông tin hàng trả muốn khôi phục lại
            HangMuaPubLic _hmTemp = _lstHangTra[_index];
            HangMuaPubLic _hm = new HangMuaPubLic();
            //Lấy thông tin sản phẩm
            _hm.SanPham.MaSP_SP = _hmTemp.SanPham.MaSP_SP;
            _hm.SanPham.TenSP_SP = _hmTemp.SanPham.TenSP_SP;
            _hm.SanPham.GiaNhap_SP = _hmTemp.SanPham.GiaNhap_SP;
            _hm.SanPham.GiaBanLe_SP = _hmTemp.SanPham.GiaBanLe_SP;
            _hm.SanPham.GiaBanSi_SP = _hmTemp.SanPham.GiaBanSi_SP;
            _hm.SanPham.NCC_SP.MaNCC_NCC = _hmTemp.SanPham.NCC_SP.MaNCC_NCC;
            _hm.SanPham.NSP_SP.MaNSP_NSP = _hmTemp.SanPham.NSP_SP.MaNSP_NSP;
            _hm.SanPham.DVT_SP.MaDVT_DVT = _hmTemp.SanPham.DVT_SP.MaDVT_DVT;
            _hm.SanPham.DVT_SP.TenDVT_DVT = _hmTemp.SanPham.DVT_SP.TenDVT_DVT;
            _hm.SanPham.GhiChu_SP = _hmTemp.SanPham.GhiChu_SP;
            _hm.SanPham.SoLuong_SP = _hmTemp.SanPham.SoLuong_SP;
            _hm.SanPham.CKPhanTram_SP = _hmTemp.SanPham.CKPhanTram_SP;
            _hm.SanPham.Anh_SP = _hmTemp.SanPham.Anh_SP;
            _hm.SanPham.NgayTao_SP = _hmTemp.SanPham.NgayTao_SP;

            //Thông tin hàng mua
            _hm.SoLuong = _hmTemp.SoLuong;
            _hm.ChietKhauPhanTram = _hmTemp.ChietKhauPhanTram;
            _hm.ChietKhauTienMat = _hmTemp.ChietKhauTienMat;
            _hm.GiaBan_HM = _hmTemp.GiaBan_HM;
            _hm.GiaNhap_HM = _hmTemp.GiaNhap_HM;

            //Lấy thông tin hóa đơn
            _hm.HoaDon.SoHD_HD = _hm.HoaDon.SoHD_HD;
            _hm.HoaDon.NgayLap_HD = _hm.HoaDon.NgayLap_HD;
            _hm.HoaDon.NguoiLap_HD = _hm.HoaDon.NguoiLap_HD;
            _hm.HoaDon.BanLe_HD = _hm.HoaDon.BanLe_HD;
            _hm.HoaDon.KhachHang_HD.MaKH_KH = _hm.HoaDon.KhachHang_HD.MaKH_KH;
            _hm.HoaDon.CKPhanTram_HD = _hm.HoaDon.CKPhanTram_HD;
            _hm.HoaDon.TienKhachTra_HD = _hm.HoaDon.TienKhachTra_HD;
            _hm.HoaDon.VouCher_HD = _hm.HoaDon.VouCher_HD;
            _hm.HoaDon.MaGiamGia.MaThe_MGG = _hm.HoaDon.MaGiamGia.MaThe_MGG;
            _hm.HoaDon.TongCKHoaDon = _hm.HoaDon.TongCKHoaDon;

            #endregion

            var _hmRemove = _lstHangTra.Single(item => item.SanPham.MaSP_SP == _hm.SanPham.MaSP_SP);
            _lstHangTra.Remove(_hmRemove);

            //Khôi phục lại sản phẩm ở ds hàng mua
            if (_lstHangMua == null)
                _lstHangMua = new List<HangMuaPubLic>();
            if (_lstHangMua.Count == 0)
                _lstHangMua.Add(_hm);
            else
            {
                HangMuaPubLic _rsHangTr = _lstHangMua.Find(item => item.SanPham.MaSP_SP == _hm.SanPham.MaSP_SP);
                if (_rsHangTr != null)
                    _lstHangMua.Where(item => item.SanPham.MaSP_SP == _hm.SanPham.MaSP_SP).First().SoLuong += _hm.SoLuong;
                else
                    _lstHangMua.Add(_hm);
            }

            //Tính lại chiết khấu sản phẩm
            HangMuaPubLic _result = _lstHangMua.Find(item => item.SanPham.MaSP_SP == _hm.SanPham.MaSP_SP);
            if (_result != null)
            {
                float _CkSp = _result.ChietKhauPhanTram;
                int _GiaBan = Convert.ToInt32(UntilitiesBusiness.BoDauPhay(_result.GiaBan_HM));
                int _soLuong = _result.SoLuong;
                int _CkTienMatSp = (int)((_CkSp * _GiaBan / 100) * _soLuong);

                if (_CkTienMatSp.ToString().EndsWith("9"))
                    _CkTienMatSp++;

                int _TongTien = 0;
                int _ThanhTien = 0;

                _TongTien = _soLuong * _GiaBan;
                _ThanhTien = _TongTien - _CkTienMatSp;

                _lstHangMua.Where(item => item.SanPham.MaSP_SP == _hm.SanPham.MaSP_SP).First().ChietKhauTienMat = _CkTienMatSp.ToString();
                _lstHangMua.Where(item => item.SanPham.MaSP_SP == _hm.SanPham.MaSP_SP).First().ThanhTien = _ThanhTien;
                _lstHangMua.Where(item => item.SanPham.MaSP_SP == _hm.SanPham.MaSP_SP).First().TongTienSP = _TongTien;
            }


            //Tính lại thành tiền
            TinhTien();

            //Hiển thị danh sách sp
            libHangTra.ItemsSource = _lstHangTra;
            libHangTra.Items.Refresh();

            dgHangMua.ItemsSource = _lstHangMua;
            dgHangMua.Items.Refresh();

            if (_lstHangTra.Count == 0)
            {
                //Tắt nút thanh toán
                btnThanhToan.IsEnabled = false;
                btnTiepTucMua.IsEnabled = false;
            }
        }

        //Nút thanh toán
        private void btnThanhToan_Click(object sender, RoutedEventArgs e)
        {
            //Kiểm tra có hàng trả hay chưa
            if (_lstHangTra == null)
            {
                MessageBox.Show("Chưa có hàng trả!");
                return;
            }
            if (_lstHangTra.Count == 0)
            {
                MessageBox.Show("Chưa có hàng trả - 0");
                return;
            }

            NhapHangTraThanhToanPresentation wpf = new NhapHangTraThanhToanPresentation();
            wpf._lstSPTraLai = _lstHangTra;
            wpf._TienKhachDaTra = _TienDaTra;
            wpf._TienSauTraSP = _TienSauTraSp;
            wpf._ThanhToanTraSp += new EventHandler(ThanhToanTraSp);
            wpf.ShowDialog();
        }

        //Phương thức thanh toán - trả sp
        private void ThanhToanTraSp(object sender, EventArgs e)
        {
            #region 1.Lấy thông tin

            #endregion

            #region 2. Hủy hóa đơn cũ
            if (_hoaDon != null)
                TraHangBusiness.HuyHoaDon(_hoaDon);
            else
                MessageBox.Show("Hóa đơn hủy rỗng!");
            #endregion

            #region 3.Lưu lịch sử bán hàng

            LichSuBanHangPublic _lsbh = new LichSuBanHangPublic();
            _lsbh.MaLSBH_LSBH = UntilitiesBusiness.GetNextID("tbl_LICHSUBANHANG", "MaLSBH_LSBH", "LS.", 10);
            _lsbh.NhanVienThucHien_LSBH = _NhanVien;
            _lsbh.SoHD_LSBH.SoHD_HD = _hoaDon.SoHD_HD;
            _lsbh.MoTa_LSBH = "Khách trả hàng";
            _lsbh.ThoiGian_LSBH = DateTime.Now;

            LichSuBanHangBusiness.ThemLichSuBanHang(_lsbh);
            #endregion

            #region 4.Tạo hóa đơn mới nếu còn hàng

            if (_lstHangMua == null)
                goto go;
            if (_lstHangMua.Count == 0)
                goto go;

            //Tạo hóa đơn mới
            _hoaDonMoi.SoHD_HD = UntilitiesBusiness.GetNextID("tbl_HOADON", "SoHD_HD", "HD.", 10);
            _hoaDonMoi.NgayLap_HD = DateTime.Now;
            _hoaDonMoi.KhachHang_HD = _hoaDon.KhachHang_HD;
            _hoaDonMoi.NguoiLap_HD = _NhanVien;
            _hoaDonMoi.MaGiamGia.MaThe_MGG = _hoaDon.MaGiamGia.MaThe_MGG;
            _hoaDonMoi.BanLe_HD = _hoaDon.BanLe_HD;
            _hoaDonMoi.DangDung_HD = true;

            ////Tạo danh sách hàng mua cho hóa đơn mới
            List<SanPhamPublic> _lstSpMua = new List<SanPhamPublic>();
            SanPhamPublic _sp;
            foreach (HangMuaPubLic _hm in _lstHangMua)
            {
                _sp = new SanPhamPublic();
                _sp.MaSP_SP = _hm.SanPham.MaSP_SP;
                _sp.TenSP_SP = _hm.SanPham.TenSP_SP;
                _sp.SoLuong_SP = _hm.SoLuong;
                _sp.CKPhanTram_SP = _hm.ChietKhauPhanTram;
                _sp.CKTienMat = _hm.ChietKhauTienMat;
                _sp.GiaNhap_SP = _hm.GiaNhap_HM;
                _sp.GiaBan = _hm.GiaBan_HM;
                _sp.DVT_SP.TenDVT_DVT = _hm.SanPham.DVT_SP.TenDVT_DVT;
                _sp.ThanhTien_SP = UntilitiesBusiness.ThemDauPhay(_hm.ThanhTien.ToString());

                _lstSpMua.Add(_sp);
            }

            ////Lưu hóa đơn mới
            BanHangBusiness.BanHang(_hoaDonMoi, _lstSpMua, false);

            ////Lưu lịch sử bán hàng
            //_lsbh = new LichSuBanHangPublic();
            //_lsbh.MaLSBH_LSBH = UntilitiesBusiness.GetNextID("tbl_LICHSUBANHANG", "MaLSBH_LSBH", "LS.", 10);
            //_lsbh.NhanVienThucHien_LSBH = _NhanVien;
            //_lsbh.SoHD_LSBH.SoHD_HD = _hoaDonMoi.SoHD_HD;
            //_lsbh.MoTa_LSBH = "Khách mua hàng";
            //_lsbh.ThoiGian_LSBH = DateTime.Now;

            //LichSuBanHangBusiness.ThemLichSuBanHang(_lsbh);

            //In hóa đơn mới nếu có
            //Chuẩn bị dữ liệu
            Pos_ds _Pos_ds = new Pos_ds();
            DataTable _dtHoaDonBanLe = _Pos_ds.tbl_HOADON;
            DataRow _drHoaDonBanLe;

            foreach (SanPhamPublic _spHoaDon in _lstSpMua)
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
            _hoaDonMoi.TongSoLuongSP = _lstSpMua.Sum(item => item.SoLuong_SP);

            HoaDonBanLe_UPresentation wpf_HoaDon = new HoaDonBanLe_UPresentation();
            wpf_HoaDon._dtHoaDon = _dtHoaDonBanLe;
            wpf_HoaDon._hoaDon = _hoaDonMoi;
            wpf_HoaDon.ShowDialog();

            #endregion

        go:
            #region 5.Khởi tạo lại dữ liệu: danh sách hàng trả hàng mua

            _lstHangMua.Clear();
            _lstHangTra.Clear();
            _hoaDon = null;
            _hoaDonMoi = null;

            //Hiển thị
            dgHangMua.ItemsSource = _lstHangMua;
            dgHangMua.Items.Refresh();
            libHangTra.ItemsSource = _lstHangTra;
            libHangTra.Items.Refresh();

            lbSoHD.Content = "";
            lbNgayLap.Content = "";
            lbNhanVien.Content = "";
            lbKhachHang.Content = "";

            lbTongTien.Content = "0";
            lbTongCkSP.Content = "0";
            lbTongCKHD.Content = "0";
            lbVoucher.Content = "0";
            lbMaGiamGia.Content = "0";
            lbThanhTien.Content = "0";

            btnThanhToan.IsEnabled = false;
            btnTiepTucMua.IsEnabled = false;

            btnHoDon.IsEnabled = true;

            txtSoHD.Focus();
            #endregion
        }

        //Nút mua hàng tiếp -- Bỏ chưa làm
        private void btnTiepTucMua_Click(object sender, RoutedEventArgs e)
        {
            #region 1.Lấy thông tin

            #endregion

            #region 2. Hủy hóa đơn cũ
            if (_hoaDon != null)
                TraHangBusiness.HuyHoaDon(_hoaDon);
            else
                MessageBox.Show("Hóa đơn hủy rỗng!");
            #endregion

            #region 3.Lưu lịch sử bán hàng

            LichSuBanHangPublic _lsbh = new LichSuBanHangPublic();
            _lsbh.MaLSBH_LSBH = UntilitiesBusiness.GetNextID("tbl_LICHSUBANHANG", "MaLSBH_LSBH", "LS.", 10);
            _lsbh.NhanVienThucHien_LSBH.MaNV_NV = "NV00001";
            _lsbh.SoHD_LSBH.SoHD_HD = _hoaDon.SoHD_HD;
            _lsbh.MoTa_LSBH = "Khách trả hàng";
            _lsbh.ThoiGian_LSBH = DateTime.Now;

            LichSuBanHangBusiness.ThemLichSuBanHang(_lsbh);
            #endregion

            #region 4.Chuyển sang giao diện bán hàng
            //Chuẩn bị thông tin truyền sang
            //Tạo hóa đơn mới
            _hoaDonMoi.SoHD_HD = UntilitiesBusiness.GetNextID("tbl_HOADON", "SoHD_HD", "HD.", 10);
            _hoaDonMoi.NgayLap_HD = DateTime.Now;
            _hoaDonMoi.KhachHang_HD = _hoaDon.KhachHang_HD;
            _hoaDonMoi.NguoiLap_HD.MaNV_NV = _hoaDon.NguoiLap_HD.MaNV_NV;
            _hoaDonMoi.MaGiamGia.MaThe_MGG = _hoaDon.MaGiamGia.MaThe_MGG;
            _hoaDonMoi.BanLe_HD = _hoaDon.BanLe_HD;
            _hoaDonMoi.DangDung_HD = true;
            _hoaDonMoi.TienKhachTraTruoc = _TienDaTra;

            _lstSpTiepTucMua = new List<SanPhamPublic>();
            SanPhamPublic _sp;
            foreach (HangMuaPubLic _hm in _lstHangMua)
            {
                _sp = new SanPhamPublic();
                _sp.STT = _lstSpTiepTucMua.Count + 1;
                _sp.MaSP_SP = _hm.SanPham.MaSP_SP;
                _sp.TenSP_SP = _hm.SanPham.TenSP_SP;
                _sp.SoLuong_SP = _hm.SoLuong;
                _sp.CKPhanTram_SP = _hm.ChietKhauPhanTram;
                _sp.CKTienMat = _hm.ChietKhauTienMat;
                _sp.GiaNhap_SP = _hm.GiaNhap_HM;
                _sp.GiaBan = _hm.GiaBan_HM;
                _sp.DVT_SP.TenDVT_DVT = _hm.SanPham.DVT_SP.TenDVT_DVT;
                _sp.ThanhTien_SP = UntilitiesBusiness.ThemDauPhay(_hm.ThanhTien.ToString());

                _lstSpTiepTucMua.Add(_sp);
            }

            EventHandler _eh = _TiepTucMua;
            if (_eh != null)
                _eh(this, e);
            #endregion
        }

        //txt tim preview key down
        private void txtSoHD_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                btnHoDon_Click(sender, e);
        }

        //loadding row
        private void dgHangMua_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = (e.Row.GetIndex() + 1).ToString();
        }

    }//End class
}

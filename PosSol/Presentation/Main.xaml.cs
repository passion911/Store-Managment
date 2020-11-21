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
using System.Windows.Shapes;
using Presentation.UserControls;
using System.ComponentModel;
using Public;
using Business;
using System.IO;
using Presentation.WindowWpf;

namespace Presentation
{
    /// <summary>
    /// Interaction logic for Main.xaml
    /// </summary>
    public partial class Main : Window
    {
        //Khái báo
        ThietLapHeThongPublic _thietLap;
        bool _DangNhap = false;
        NhanVienPublic _NhanVien;
        List<QuyenChucNangPublic> _lstQuyen;
        int _menu = 0;

        public Main()
        {
            InitializeComponent();
            bdProgress.Visibility = System.Windows.Visibility.Hidden;
        }

        #region MyRegion
        private void PART_TITLEBAR_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void PART_CLOSE_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void PART_MAXIMIZE_RESTORE_Click(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == System.Windows.WindowState.Normal)
            {
                this.WindowState = System.Windows.WindowState.Maximized;
            }
            else
            {
                this.WindowState = System.Windows.WindowState.Normal;
            }
        }

        private void PART_MINIMIZE_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = System.Windows.WindowState.Minimized;
        }
        #endregion

        //NÚT BÁN HÀNG
        BanHangUPresentation frm;
        private void btnBanHang_Click(object sender, RoutedEventArgs e)
        {
            frm = new BanHangUPresentation();
            frm._NhanVien = _NhanVien;
            gdContentMain.Children.Clear();
            gdContentMain.Children.Add(frm);

            FocusButon(2);
            lbTitle.Visibility = System.Windows.Visibility.Visible;
            lbTitle.Content = "LẬP HÓA ĐƠN BÁN HÀNG";
            btnBack.Visibility = System.Windows.Visibility.Collapsed;
        }

        //NÚT THIẾT LẬP
        private void btnThietLap_Click(object sender, RoutedEventArgs e)
        {
            FocusButon(6);
            ThietLapUPresentation frm = new ThietLapUPresentation();
            frm._lstQuyen = _lstQuyen;
            frm.evChonChucNang += new EventHandler(evMoChucNang);
            gdContentMain.Children.Clear();
            gdContentMain.Children.Add(frm);

            _menu = 4;
            btnBack.Visibility = System.Windows.Visibility.Collapsed;
            lbTitle.Visibility = System.Windows.Visibility.Collapsed;
        }

        //SỰ KIỆN MỞ FOMR CHỨC NĂNG - THIẾT LẬP
        void evMoChucNang(object sender, EventArgs e)
        {
            ThietLapUPresentation frm = (ThietLapUPresentation)sender;
            string ChucNang = frm.ChucNang;

            switch (ChucNang)
            {
                case "1"://Sản phẩm
                    SanPhamUPresentation sp = new SanPhamUPresentation();
                    gdContentMain.Children.Clear();
                    gdContentMain.Children.Add(sp);

                    lbTitle.Content = "QUẢN LÝ SẢN PHẨM";
                    break;
                case "2"://Nhóm sản phẩm
                    NhomSanPhamUPresentation nsp = new NhomSanPhamUPresentation();
                    gdContentMain.Children.Clear();
                    gdContentMain.Children.Add(nsp);

                    lbTitle.Content = "QUẢN LÝ NHÓM SẢN PHẨM";
                    break;
                case "3"://Đơn vị tính
                    DonViTinhUPresentation dvt = new DonViTinhUPresentation();
                    gdContentMain.Children.Clear();
                    gdContentMain.Children.Add(dvt);

                    lbTitle.Content = "QUẢN LÝ ĐƠN VỊ TÍNH";
                    break;
                case "4"://Nhà cung cấp
                    NhaCungCapUPresentation ncc = new NhaCungCapUPresentation();
                    gdContentMain.Children.Clear();
                    gdContentMain.Children.Add(ncc);

                    lbTitle.Content = "QUẢN LÝ NHÀ CUNG CẤP";
                    break;
                case "5"://Nhân viên
                    NhanVienUPresentation nv = new NhanVienUPresentation();
                    nv._CapNhatHienThi += new EventHandler(CapNhatSuaNV_TL);
                    gdContentMain.Children.Clear();
                    gdContentMain.Children.Add(nv);

                    lbTitle.Content = "QUẢN LÝ NHÂN VIÊN";
                    break;
                case "6"://Khách hàng
                    KhachHangUPresentation kh = new KhachHangUPresentation();

                    gdContentMain.Children.Clear();
                    gdContentMain.Children.Add(kh);

                    lbTitle.Content = "QUẢN LÝ KHÁCH HÀNG";
                    break;
                case "7"://Nhóm khách hàng
                    NhomKhachHangUPresentation nhk = new NhomKhachHangUPresentation();
                    gdContentMain.Children.Clear();
                    gdContentMain.Children.Add(nhk);

                    lbTitle.Content = "QUẢN LÝ NHÓM KHÁCH HÀNG";
                    break;
                case "8"://Tạo mã vạch
                    TaoMaVachUPresentation tmv = new TaoMaVachUPresentation();
                    gdContentMain.Children.Clear();
                    gdContentMain.Children.Add(tmv);

                    lbTitle.Content = "TẠO MÃ VẠCH SẢN PHẨM";
                    break;
                case "9":
                    MaGiamGiaUPresentation mgg = new MaGiamGiaUPresentation();
                    gdContentMain.Children.Clear();
                    gdContentMain.Children.Add(mgg);

                    lbTitle.Content = "TẠO MÃ GIẢM GIÁ";
                    break;
                case "10":
                    PhanQuyenUPresentation pq = new PhanQuyenUPresentation();
                    pq._nhanVien = _NhanVien;
                    gdContentMain.Children.Clear();
                    gdContentMain.Children.Add(pq);

                    lbTitle.Content = "QUẢN LÝ NHÓM QUYỀN";
                    break;
                case "11":
                    ThietLapHeThongUPresentation tl = new ThietLapHeThongUPresentation();
                    tl._CapNhatHienThi += new EventHandler(CapNhatSuaNV_TL);
                    gdContentMain.Children.Clear();
                    gdContentMain.Children.Add(tl);

                    lbTitle.Content = "THIẾT LẬP HỆ THỐNG";
                    break;
                case "12":
                    DoiMatKhauPresentation dmk = new DoiMatKhauPresentation();
                    dmk._nhanvien = _NhanVien;
                    dmk.ShowDialog();
                    UpdateThongTin();

                    break;
                default:
                    break;
            }//end switch
            btnBack.Visibility = System.Windows.Visibility.Visible;
            lbTitle.Visibility = System.Windows.Visibility.Visible;
        }

        //Cập nhật lại hiển thị nhân viên vào thông tin cửa hàng sau khi sửa
        private void CapNhatSuaNV_TL(object sender, EventArgs e)
        {
            UpdateThongTin();
        }

        //Nút kho
        private void btnKho_Click(object sender, RoutedEventArgs e)
        {
            KhoUPresentation wpf_Kho = new KhoUPresentation();
            wpf_Kho._lstQuyen = _lstQuyen;
            wpf_Kho._ChonChucNang += new EventHandler(ChonChucNang_KHO);
            gdContentMain.Children.Clear();
            gdContentMain.Children.Add(wpf_Kho);
            FocusButon(3);

            _menu = 2;
            btnBack.Visibility = System.Windows.Visibility.Collapsed;
            lbTitle.Visibility = System.Windows.Visibility.Collapsed;
        }

        //Phương thức chọn chức năng - KHO
        private void ChonChucNang_KHO(object sender, EventArgs e)
        {
            KhoUPresentation wpf_KHO = (KhoUPresentation)sender;
            int _ChucNang = wpf_KHO._ChucNang;

            switch (_ChucNang)
            {
                case 1://Nhập mua
                    NhapMuaUPresentation wpf_nhapmua = new NhapMuaUPresentation();
                    wpf_nhapmua._nhanVien = _NhanVien;
                    gdContentMain.Children.Clear();
                    gdContentMain.Children.Add(wpf_nhapmua);

                    lbTitle.Content = "NHẬP MUA";
                    break;
                case 2:
                    KiemKeUPresentation wpf_KiemKe = new KiemKeUPresentation();
                    gdContentMain.Children.Clear();
                    gdContentMain.Children.Add(wpf_KiemKe);

                    lbTitle.Content = "KIỂM KÊ SẢN PHẨM";
                    break;
                case 3:
                    NhapHangTraUPresentation wpf_NhapHangTra = new NhapHangTraUPresentation();
                    wpf_NhapHangTra._NhanVien = _NhanVien;
                    gdContentMain.Children.Clear();
                    gdContentMain.Children.Add(wpf_NhapHangTra);

                    lbTitle.Content = "NHẬP HÀNG TRẢ LẠI";
                    break;
                default:
                    break;
            }

            lbTitle.Visibility = System.Windows.Visibility.Visible;
            btnBack.Visibility = System.Windows.Visibility.Visible;
        }

        //LOADED
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //Hiển thị tên cửa hàng
           // _thietLap = ThietLapHeThongBusiness.LayThietLapHeThong();
            //HienThiCuaHang();

            //Hiển thị wpf bắt đầu khi vào chương trình
            BatDauUPresentation wpf = new BatDauUPresentation();
            wpf._DangNhap = _DangNhap;
            wpf._ChonChucNang += new EventHandler(ChonChucNang_WPFBatDau);

            gdContentMain.Children.Clear();
            gdContentMain.Children.Add(wpf);

            //Chưa đăng nhập
            gdMenu.IsEnabled = _DangNhap;
        }

        //Phương thức chọn chức năng - Wpf bắt đầu
        private void ChonChucNang_WPFBatDau(object sender, EventArgs e)
        {
            //Lấy thông tin
            BatDauUPresentation _wpfBatDau = (BatDauUPresentation)sender;
            int _ChucNang = _wpfBatDau._ChucNang;

            switch (_ChucNang)
            {
                case 1://Đăng nhập
                    btnBack.Visibility = System.Windows.Visibility.Visible;
                    _menu = 0;

                    DangNhapUPresentation wpf_DangNhap = new DangNhapUPresentation();
                    wpf_DangNhap.DangNhap += new EventHandler(DangNhap);
                    gdContentMain.Children.Clear();
                    gdContentMain.Children.Add(wpf_DangNhap);
                    break;

                case 2://Đăng xuất

                    _NhanVien = null;
                    _lstQuyen = null;
                    gdMenu.IsEnabled = false;
                    _DangNhap = false;
                    BatDauUPresentation wpf_bd = new BatDauUPresentation();
                    wpf_bd._DangNhap = _DangNhap;
                    wpf_bd._ChonChucNang += new EventHandler(ChonChucNang_WPFBatDau);

                    gdContentMain.Children.Clear();
                    gdContentMain.Children.Add(wpf_bd);

                    HienThiNhanVien();

                    break;

                default:
                    break;
            }
        }

        //PHƯƠNG THỨC ĐĂNG NHẬP
        private void DangNhap(object sender, EventArgs e)
        {
            //Chuyển sang trạng thái đã đăng nhập
            _DangNhap = true;

            //Lấy thông tin nhân viên
            DangNhapUPresentation wpf_DangNhap = (DangNhapUPresentation)sender;
            _NhanVien = wpf_DangNhap.Nv;

            //Lấy quyền truy nhập
            _lstQuyen = PhanQuyenBusiness.LayQuyenChucNangTheoQuyen(_NhanVien.ID_Q);
            HienThiTheoQuyen();

            gdContentMain.Children.Clear();

            //Hiển thị trang chủ
            TrangChuUPresentation wpf_Home = new TrangChuUPresentation();
            wpf_Home._lstQuyen = _lstQuyen;
            wpf_Home._ChonChucNang += new EventHandler(ChonChucNang_TrangChu);
            gdContentMain.Children.Clear();
            gdContentMain.Children.Add(wpf_Home);

            btnBack.Visibility = System.Windows.Visibility.Collapsed;
            FocusButon(1);

            //Hiển thị thông tin nhân viên đăng nhập
            HienThiNhanVien();
        }

        //Hiển thị theo quyền
        private void HienThiTheoQuyen()
        {
            gdMenu.IsEnabled = true;

            //Nút bán hàng 
            btnBanHang.IsEnabled = DangNhapBusiness.HienThiQuyen(_lstQuyen, "CN00001");
        }

        //On preview key downs
        protected override void OnPreviewKeyDown(KeyEventArgs e)
        {
            //if (e.Key == Key.B)
            //{
            //    btnBanHang_Click(this, e);
            //}
            base.OnPreviewKeyDown(e);
        }

        //NÚT HOME
        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            TrangChuUPresentation wpf_TrangChu = new TrangChuUPresentation();
            wpf_TrangChu._ChonChucNang += new EventHandler(ChonChucNang_TrangChu);
            wpf_TrangChu._lstQuyen = _lstQuyen;

            gdContentMain.Children.Clear();
            gdContentMain.Children.Add(wpf_TrangChu);
            FocusButon(1);
            _menu = 1;
            btnBack.Visibility = System.Windows.Visibility.Collapsed;
            lbTitle.Visibility = System.Windows.Visibility.Collapsed;
        }

        //CHỌN CHỨC NĂNG TRANG CHỦ
        private void ChonChucNang_TrangChu(object sender, EventArgs e)
        {
            TrangChuUPresentation wpf = (TrangChuUPresentation)sender;
            int _ChucNang = wpf._ChucNang;

            switch (_ChucNang)
            {
                case 1:
                    BanHangUPresentation _bh = new BanHangUPresentation();
                    _bh._NhanVien = _NhanVien;
                    gdContentMain.Children.Clear();
                    gdContentMain.Children.Add(_bh);

                    lbTitle.Content = "LẬP HÓA ĐƠN BÁN HÀNG";
                    break;
                case 2:
                    NhapHangTraUPresentation _nht = new NhapHangTraUPresentation();
                    gdContentMain.Children.Clear();
                    gdContentMain.Children.Add(_nht);

                    lbTitle.Content = "NHẬP HÀNG TRẢ";
                    break;

                case 3:
                    NhapMuaUPresentation _nm = new NhapMuaUPresentation();
                    gdContentMain.Children.Clear();
                    gdContentMain.Children.Add(_nm);

                    lbTitle.Content = "NHẬP MUA";
                    break;

                case 4:
                    TaoMaVachUPresentation _tmv = new TaoMaVachUPresentation();
                    gdContentMain.Children.Clear();
                    gdContentMain.Children.Add(_tmv);

                    lbTitle.Content = "TẠO MÃ VẠCH SẢN PHẨM";
                    break;
                case 5:
                    KhachHangUPresentation _kh = new KhachHangUPresentation();
                    gdContentMain.Children.Clear();
                    gdContentMain.Children.Add(_kh);

                    lbTitle.Content = "QUẢN LÝ KHÁCH HÀNG";
                    break;

                case 6:
                    SanPhamUPresentation _sp = new SanPhamUPresentation();
                    gdContentMain.Children.Clear();
                    gdContentMain.Children.Add(_sp);

                    lbTitle.Content = "QUẢN LÝ SẢN PHẨM";
                    break;
            }
            lbTitle.Visibility = System.Windows.Visibility.Visible;
            btnBack.Visibility = System.Windows.Visibility.Visible;
            _menu = 1;
        }

        //Focus buton
        private void FocusButon(int _idButton)
        {
            double _i = 0.3;
            switch (_idButton)
            {

                case 1://Nút home
                    btnHome.Opacity = _i;
                    btnBanHang.Opacity = 1;
                    btnKho.Opacity = 1;
                    btnTien.Opacity = 1;
                    btnThietLap.Opacity = 1;
                    btnBaoCao.Opacity = 1;

                    break;
                case 2://Nút Bán hàng
                    btnHome.Opacity = 1;
                    btnBanHang.Opacity = _i;
                    btnKho.Opacity = 1;
                    btnTien.Opacity = 1;
                    btnThietLap.Opacity = 1;
                    btnBaoCao.Opacity = 1;
                    break;

                case 3://Kho
                    btnHome.Opacity = 1;
                    btnBanHang.Opacity = 1;
                    btnKho.Opacity = _i;
                    btnTien.Opacity = 1;
                    btnThietLap.Opacity = 1;
                    btnBaoCao.Opacity = 1;
                    break;

                case 4://Tiền
                    btnHome.Opacity = 1;
                    btnBanHang.Opacity = 1;
                    btnKho.Opacity = 1;
                    btnTien.Opacity = _i;
                    btnThietLap.Opacity = 1;
                    btnBaoCao.Opacity = 1;
                    break;
                case 5://Báo cáo
                    btnHome.Opacity = 1;
                    btnBanHang.Opacity = 1;
                    btnKho.Opacity = 1;
                    btnTien.Opacity = 1;
                    btnThietLap.Opacity = 1;
                    btnBaoCao.Opacity = _i;
                    break;
                case 6://THiết lập
                    btnHome.Opacity = 1;
                    btnBanHang.Opacity = 1;
                    btnKho.Opacity = 1;
                    btnTien.Opacity = 1;
                    btnThietLap.Opacity = _i;
                    btnBaoCao.Opacity = 1;
                    break;

            }
        }

        //Hiển thị thông tin nhân viên
        private void HienThiNhanVien()
        {
            if (_DangNhap == true)
            {
                //Hiển thị thông tin nhân viên
                if (_NhanVien != null)
                {
                    spThongTinNV.Visibility = System.Windows.Visibility.Visible;
                    lbTenNV.Content = _NhanVien.HoTen_NV;

                    if (!String.IsNullOrEmpty(_NhanVien.Anh_NV))
                    {
                        string _path = "../../Image/Staff/" + _NhanVien.Anh_NV;
                        if (File.Exists(_path))
                        {
                            _path = System.IO.Path.GetFullPath(_path);

                            var _bit = new BitmapImage();
                            var _stream = File.OpenRead(_path);
                            _bit.BeginInit();
                            _bit.CacheOption = BitmapCacheOption.OnLoad;
                            _bit.StreamSource = _stream;
                            _bit.EndInit();
                            _stream.Close();
                            _stream.Dispose();

                            picNV.Source = _bit;
                        }
                    }
                    else
                    {
                        spThongTinNV.Visibility = System.Windows.Visibility.Hidden;
                    }

                    //Hiển thị tên nhóm quyền của nhân viên
                    if (_lstQuyen != null)
                        lbTenQuyen.Content = _lstQuyen[0].Quyen.TenQuyen_Q;
                }
            }
            else//Nếu chưa đăng nhập thì ẩn thông tin nhân viên
            {
                spThongTinNV.Visibility = System.Windows.Visibility.Hidden;
            }
        }

        //Nút Thống kê
        private void btnBaoCao_Click(object sender, RoutedEventArgs e)
        {
            FocusButon(5);
            gdContentMain.Children.Clear();
            ThongKeBaoCaoUPresentation wpf = new ThongKeBaoCaoUPresentation();
            wpf._lstQuyen = _lstQuyen;
            wpf._ChonChucNang += new EventHandler(ChonChucNang_ThongKeBaoCao);
            gdContentMain.Children.Add(wpf);

            _menu = 3;
            btnBack.Visibility = System.Windows.Visibility.Collapsed;
            lbTitle.Visibility = System.Windows.Visibility.Collapsed;
        }

        //Phương thức chọn chức năng kho
        private void ChonChucNang_ThongKeBaoCao(object sender, EventArgs e)
        {
            ThongKeBaoCaoUPresentation wpf = (ThongKeBaoCaoUPresentation)sender;
            int _ChucNang = wpf._ChucNang;

            switch (_ChucNang)
            {
                case 1://Chức năng hóa đơn
                    ThongKeTheoHoaDon wpf_hoaDon = new ThongKeTheoHoaDon();
                    gdContentMain.Children.Clear();
                    gdContentMain.Children.Add(wpf_hoaDon);

                    lbTitle.Content = "HÓA ĐƠN";
                    break;
                case 2://Lịch sử bán hàng
                    LichSuBanHangUPresentation wpf_lichsubanhang = new LichSuBanHangUPresentation();
                    gdContentMain.Children.Clear();
                    gdContentMain.Children.Add(wpf_lichsubanhang);

                    lbTitle.Content = "LỊCH SỬ BÁN HÀNG";
                    break;
                case 3://doanh thu theo sản phẩm
                    ThongKeTheoSpUPresentation wpf_thongketheosanpham = new ThongKeTheoSpUPresentation();
                    gdContentMain.Children.Clear();
                    gdContentMain.Children.Add(wpf_thongketheosanpham);

                    lbTitle.Content = "THỐNG KÊ THEO SẢN PHẨM";
                    break;
                case 4://thông kê theo nhân viên
                    ThongKeTheoNhanVienUPresentation wpf_thongketheonhanvien = new ThongKeTheoNhanVienUPresentation();
                    gdContentMain.Children.Clear();
                    gdContentMain.Children.Add(wpf_thongketheonhanvien);

                    lbTitle.Content = "THỐNG KÊ THEO NHÂN VIÊN";
                    break;
                case 5:
                    PhieuNhapKhoUPresentation wpf_phieuNhap = new PhieuNhapKhoUPresentation();
                    gdContentMain.Children.Clear();
                    gdContentMain.Children.Add(wpf_phieuNhap);

                    lbTitle.Content = "PHIẾU NHẬP";
                    break;
                case 6:
                    ThongKeTheoKhachHangUPresentation wpf_tkTheoKH = new ThongKeTheoKhachHangUPresentation();
                    gdContentMain.Children.Clear();
                    gdContentMain.Children.Add(wpf_tkTheoKH);

                    lbTitle.Content = "THỐNG KÊ THEO KHÁCH HÀNG";
                    break;
            }
            btnBack.Visibility = System.Windows.Visibility.Visible;
            lbTitle.Visibility = System.Windows.Visibility.Visible;
        }

        //Update thông tin thiết lập, thông tin nhân viên hiển thị trên giao diện main
        private void UpdateThongTin()
        {
            //Update thông tin nhân viên
            _NhanVien = NhanVienBusiness.Lay1NhanVien(_NhanVien.MaNV_NV);
            HienThiNhanVien();

            //Update thông tin thiết lập hiển thị
            _thietLap = ThietLapHeThongBusiness.LayThietLapHeThong();
            HienThiCuaHang();
        }

        //Hiển thị thông tin cửa hàng
        private void HienThiCuaHang()
        {
            if (_thietLap != null)
            {
                txtbTenCuaHang.Text = _thietLap.TenCuaHang;
                txtbDiaChi.Text = _thietLap.DiaChi;
                lbSdt.Content = _thietLap.SDT;
            }
        }

        //Nút back
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            switch (_menu)
            {
                case 0://Giao diện bắt đầu
                    BatDauUPresentation _wpfBatdau = new BatDauUPresentation();
                    _wpfBatdau._ChonChucNang += new EventHandler(ChonChucNang_WPFBatDau);
                    gdContentMain.Children.Clear();
                    gdContentMain.Children.Add(_wpfBatdau);
                    break;

                case 1: //Trang chủ
                    TrangChuUPresentation wpf_Home = new TrangChuUPresentation();
                    wpf_Home._lstQuyen = _lstQuyen;
                    wpf_Home._ChonChucNang += new EventHandler(ChonChucNang_TrangChu);
                    gdContentMain.Children.Clear();
                    gdContentMain.Children.Add(wpf_Home);
                    break;

                case 2://Kho
                    KhoUPresentation wpf_kho = new KhoUPresentation();
                    wpf_kho._lstQuyen = _lstQuyen;
                    wpf_kho._ChonChucNang += new EventHandler(ChonChucNang_KHO);
                    gdContentMain.Children.Clear();
                    gdContentMain.Children.Add(wpf_kho);
                    break;

                case 3://Báo cáo
                    ThongKeBaoCaoUPresentation wpf_baocao = new ThongKeBaoCaoUPresentation();
                    wpf_baocao._lstQuyen = _lstQuyen;
                    wpf_baocao._ChonChucNang += new EventHandler(ChonChucNang_ThongKeBaoCao);
                    gdContentMain.Children.Clear();
                    gdContentMain.Children.Add(wpf_baocao);
                    break;

                case 4://Thiết lập
                    ThietLapUPresentation wpf_thietlap = new ThietLapUPresentation();
                    wpf_thietlap._lstQuyen = _lstQuyen;
                    wpf_thietlap.evChonChucNang += new EventHandler(evMoChucNang);
                    gdContentMain.Children.Clear();
                    gdContentMain.Children.Add(wpf_thietlap);
                    break;
            }
            lbTitle.Visibility = System.Windows.Visibility.Collapsed;
            btnBack.Visibility = System.Windows.Visibility.Collapsed;
        }

        //Nút đóng
        private void btnThoat_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Bạn muốn thoát chương trình?", "Xác nhận thoát", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                this.Close();
            }
        }

        //Nút đăng xuất
        private void btnDangXuat_Click(object sender, RoutedEventArgs e)
        {
            BatDauUPresentation _bd = new BatDauUPresentation();
            _bd._DangNhap = _DangNhap;
            _bd._ChonChucNang += new EventHandler(ChonChucNang_WPFBatDau);
            gdContentMain.Children.Clear();
            gdContentMain.Children.Add(_bd);
            btnBack.Visibility = System.Windows.Visibility.Collapsed;
            lbTitle.Visibility = System.Windows.Visibility.Collapsed;
        }
    }//End class
}

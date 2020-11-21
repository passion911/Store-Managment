using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Public;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess
{
    public class ThongKeDataAccess
    {
        static ConnectionDataAccess conn = new ConnectionDataAccess();

        //Tính tiền cho một hóa đơn
        public static HoaDonPublic TinhTien1HoaDon(string _soHD)
        {

            HoaDonPublic _hoaDon = new HoaDonPublic();

            #region 1.Lấy thông tin hóa đơn
            _hoaDon = LayHoaDon(_soHD);
            if (_hoaDon == null)
                return null;
            #endregion

            #region 2.Tính tiền cho hóa đơn

            //Lấy danh sách hàng mua
            DataTable _dtHM;
            SqlCommand _cmd = new SqlCommand();
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.CommandText = "[Lấy danh sách hàng mua]";
            _cmd.Parameters.AddWithValue("@SoHD_HM", _soHD);

            _dtHM = conn.GetDataSet2(_cmd).Tables[0];

            int _TongGia = 0;
            int _TongCkTienMatSP = 0;
            int _TongTienNhap = 0;
            int _soLuong;
            int _giaBan;

            HangMuaPubLic _hm;
            if (_dtHM.Rows.Count > 0)
                for (int i = 0; i < _dtHM.Rows.Count; i++)
                {
                    _hm = new HangMuaPubLic();
                    _hm.SoLuong = (int)_dtHM.Rows[i]["SoLuong_HM"];
                    _hm.ChietKhauTienMat = _dtHM.Rows[i]["CKTienMat_HM"].ToString();
                    _hm.GiaNhap_HM = _dtHM.Rows[i]["GiaNhap_HM"].ToString();
                    _hm.GiaBan_HM = _dtHM.Rows[i]["GiaBan_HM"].ToString();

                    _soLuong = _hm.SoLuong;
                    _giaBan = Convert.ToInt32(UntilitiesDataAccess.BoDauPhay(_hm.GiaBan_HM));

                    _TongTienNhap = _TongTienNhap + Convert.ToInt32(UntilitiesDataAccess.BoDauPhay(_hm.GiaNhap_HM));
                    _TongCkTienMatSP = _TongCkTienMatSP + Convert.ToInt32(UntilitiesDataAccess.BoDauPhay(_hm.ChietKhauTienMat));
                    _TongGia = _TongGia + (_soLuong * _giaBan);
                }

            int _ckMaGiamGia = 0;
            if (!String.IsNullOrEmpty(_hoaDon.MaGiamGia.MaThe_MGG))
            {
                //Lấy tiền mã giảm giá
                DataTable _dtMaGiamGia = BanHangDataAccess.LayMaGiamGiaTheoMa(_hoaDon.MaGiamGia.MaThe_MGG).Tables[0];
                _ckMaGiamGia = Convert.ToInt32(UntilitiesDataAccess.BoDauPhay(_dtMaGiamGia.Rows[0]["ChietKhau_MGG"].ToString()));
            }

            _hoaDon.TienMaGiamGia = _TongGia * _ckMaGiamGia / 100;
            _hoaDon.TongTienNhap = _TongTienNhap;
            _hoaDon.TongCKSanPham = _TongCkTienMatSP;
            _hoaDon.TongTien_HD = _TongGia;

            _hoaDon.ThanhTien = _hoaDon.TongTien_HD - _hoaDon.TongCKSanPham - _hoaDon.TongCKHoaDon;
            _hoaDon.TienConLaiPhaiTra = _hoaDon.ThanhTien - _hoaDon.VouCher_HD - _hoaDon.TienMaGiamGia;
            _hoaDon.TienThuaTraLaiKhach = _hoaDon.TienKhachTra_HD - _hoaDon.TienConLaiPhaiTra;
            #endregion

            return _hoaDon;
        }

        //Lấy hóa đơn theo số hóa đơn - lấy tất
        private static HoaDonPublic LayHoaDon(string _soHD)
        {
            HoaDonPublic _hd = null;

            SqlCommand _cmd = new SqlCommand();
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.CommandText = "[Lấy hóa đơn theo sohd]";
            _cmd.Parameters.AddWithValue("@SoHD_HD", _soHD);

            DataTable _dtHd = conn.GetDataSet2(_cmd).Tables[0];
            //Lấy thông tin
            if (_dtHd.Rows.Count > 0)
            {
                _hd = new HoaDonPublic();

                _hd.SoHD_HD = _dtHd.Rows[0]["SoHD_HD"].ToString();
                _hd.NgayLap_HD = (DateTime)_dtHd.Rows[0]["NgayLap_HD"];
                _hd.NguoiLap_HD.MaNV_NV = _dtHd.Rows[0]["NguoiLap_HD"].ToString();
                _hd.KhachHang_HD.MaKH_KH = _dtHd.Rows[0]["MaKH_HD"].ToString();
                _hd.BanLe_HD = (bool)_dtHd.Rows[0]["BanLe_HD"];
                _hd.CKPhanTram_HD = float.Parse(_dtHd.Rows[0]["CKPhanTram_HD"].ToString());
                _hd.TongCKHoaDon = Convert.ToInt32(_dtHd.Rows[0]["ChietKhauTienMat_HD"].ToString());
                _hd.TienKhachTra_HD = Convert.ToInt32(_dtHd.Rows[0]["TienKhachTra_HD"].ToString());
                _hd.VouCher_HD = Convert.ToInt32(_dtHd.Rows[0]["VouCher_HD"].ToString());
                _hd.MaGiamGia.MaThe_MGG = _dtHd.Rows[0]["MaGiamGia_HD"].ToString();
                _hd.DangDung_HD = (bool)_dtHd.Rows[0]["DangDung_HD"];
                return _hd;
            }

            return _hd;
        }

        //Lấy danh sách hàng mua
        public static List<HangMuaPubLic> LayHangMua(string _soHD)
        {
            return TraHangDataAccess.LayDsHangMua(_soHD);
        }


        //THỐNG KÊ THEO SẢN PHẨM
        public static List<ThongKeTheoSanPham> ThongKeTheoSanPham(string _MaNhomSP, DateTime _dtTuNgay, DateTime _dtDenNgay)
        {
            #region 1.Lấy thông tin sản phẩm, hàng mua
            DateTime _dtNgayBatDau = new DateTime(_dtTuNgay.Year, _dtTuNgay.Month, _dtTuNgay.Day, 0, 0, 0);
            DateTime _dtNgayKetThuc = new DateTime(_dtDenNgay.Year, _dtDenNgay.Month, _dtDenNgay.Day, 23, 59, 59);

            SqlCommand _cmd = new SqlCommand();
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.CommandText = "[Thống kê theo sản phẩm]";
            _cmd.Parameters.AddWithValue("@TuNgay", _dtNgayBatDau);
            _cmd.Parameters.AddWithValue("@DenNgay", _dtNgayKetThuc);

            DataSet _dsThongKeTheoSP = conn.GetDataSet2(_cmd);
            _cmd.Dispose();

            DataTable _dtSanPham = _dsThongKeTheoSP.Tables[0];
            DataTable _dtHangMua = _dsThongKeTheoSP.Tables[1];
            #endregion

            #region 2. Lọc thông tin theo điều kiện

            DataTable _dtSanPham_loc = new DataTable();

            //Lọc sản phẩm theo nhóm sản phẩm
            if (String.IsNullOrEmpty(_MaNhomSP))
                _dtSanPham_loc = _dtSanPham;
            else
            {
                string _strFilterSP = "MaNSP_SP = '" + _MaNhomSP + "'";
                DataView _dvSanPhamloc = new DataView(_dtSanPham);
                _dvSanPhamloc.Sort = "MaSP_SP";
                _dvSanPhamloc.RowFilter = _strFilterSP;

                _dtSanPham_loc = _dvSanPhamloc.ToTable();
            }

            #endregion

            #region 3.Tính giá trị thống kê theo sản phẩm

            if (_dtSanPham_loc.Rows.Count == 0)
                return null;

            List<ThongKeTheoSanPham> _lstKetQuaThongKeTheoSP = new List<ThongKeTheoSanPham>();
            ThongKeTheoSanPham _thongKeTheoSP;

            for (int i = 0; i < _dtSanPham_loc.Rows.Count; i++)
            {
                _thongKeTheoSP = new ThongKeTheoSanPham();

                //Lấy thông tin sản phẩm
                SanPhamPublic _sp = new SanPhamPublic();

                _sp.MaSP_SP = _dtSanPham_loc.Rows[i]["MaSP_SP"].ToString();
                _sp.TenSP_SP = _dtSanPham_loc.Rows[i]["TenSP_SP"].ToString();
                _sp.GiaNhap_SP = _dtSanPham_loc.Rows[i]["GiaNhap_SP"].ToString();
                _sp.GiaBanLe_SP = _dtSanPham_loc.Rows[i]["GiaBanLe_SP"].ToString();
                _sp.GiaBanSi_SP = _dtSanPham_loc.Rows[i]["GiaBanSi_SP"].ToString();
                _sp.NCC_SP.MaNCC_NCC = _dtSanPham_loc.Rows[i]["MaNCC_SP"].ToString();
                _sp.NSP_SP.MaNSP_NSP = _dtSanPham_loc.Rows[i]["MaNSP_SP"].ToString();
                _sp.DVT_SP.MaDVT_DVT = _dtSanPham_loc.Rows[i]["MaDVT_SP"].ToString();
                _sp.GhiChu_SP = _dtSanPham_loc.Rows[i]["GhiChu_SP"].ToString();
                _sp.SoLuong_SP = (int)_dtSanPham_loc.Rows[i]["SoLuong_SP"];
                _sp.CKPhanTram_SP = float.Parse(_dtSanPham_loc.Rows[i]["CKPhanTram_SP"].ToString());
                _sp.Anh_SP = _dtSanPham_loc.Rows[i]["Anh_SP"].ToString();
                _sp.NgayTao_SP = Convert.ToDateTime(_dtSanPham_loc.Rows[i]["NgayTao_SP"].ToString());

                _thongKeTheoSP.Sanpham = _sp;

                //Tính thu - lãi theo danh sách hàng mua
                int _TongThu = 0;
                int _TongLai = 0;
                int _TongSoLuongBan = 0;
                int _TongTienNhap = 0;
                string _strFilterHangMua = "MaSP_HM = '" + _thongKeTheoSP.Sanpham.MaSP_SP + "'";
                DataView _dvHangMua = new DataView(_dtHangMua, _strFilterHangMua, "MaSP_HM", DataViewRowState.CurrentRows);

                if (_dvHangMua.Count > 0)
                {
                    for (int j = 0; j < _dvHangMua.Count; j++)
                    {
                        int _soLuong = Convert.ToInt32(_dvHangMua[j]["SoLuong_HM"].ToString());
                        int _giaBan = Convert.ToInt32(UntilitiesDataAccess.BoDauPhay(_dvHangMua[j]["GiaBan_HM"].ToString()));
                        int _giaNhap = Convert.ToInt32(UntilitiesDataAccess.BoDauPhay(_dvHangMua[j]["GiaNhap_HM"].ToString()));
                        int _TienCKSP = Convert.ToInt32(UntilitiesDataAccess.BoDauPhay(_dvHangMua[j]["CKTienMat_HM"].ToString()));

                        _TongTienNhap = _TongTienNhap + _giaNhap;
                        _TongSoLuongBan = _TongSoLuongBan + _soLuong;
                        _TongThu = _TongThu + (_soLuong * _giaBan - _TienCKSP);
                    }
                    _TongLai = _TongThu - _TongTienNhap;
                }

                _thongKeTheoSP.TongThu = UntilitiesDataAccess.ThemDauPhay(_TongThu.ToString());
                _thongKeTheoSP.TongLai = UntilitiesDataAccess.ThemDauPhay(_TongLai.ToString());
                _thongKeTheoSP.TongNhap = UntilitiesDataAccess.ThemDauPhay(_TongTienNhap.ToString());
                _thongKeTheoSP.TongSoLuongBan = _TongSoLuongBan;

                _lstKetQuaThongKeTheoSP.Add(_thongKeTheoSP);
            }

            #endregion

            return _lstKetQuaThongKeTheoSP;
        }

        //THỐNG KÊ THEO HÓA ĐƠN
        public static List<ThongKeTheoHoaDonPublic> ThongKeTheoHoaDon(DateTime _dtTuNgay, DateTime _dtDenNgay)
        {
            List<ThongKeTheoHoaDonPublic> _lstKqThongKeTheoHoaDon = new List<ThongKeTheoHoaDonPublic>();

            #region 1.Lấy hóa đơn, hàng mua trong khoảng thời gian
            DateTime _dtNgayBatDau = new DateTime(_dtTuNgay.Year, _dtTuNgay.Month, _dtTuNgay.Day, 0, 0, 0);
            DateTime _dtNgayKetThuc = new DateTime(_dtDenNgay.Year, _dtDenNgay.Month, _dtDenNgay.Day, 23, 59, 59);

            SqlCommand _cmd = new SqlCommand();
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.CommandText = "[Thống kê theo hóa đơn]";
            _cmd.Parameters.AddWithValue("@TuNgay", _dtNgayBatDau);
            _cmd.Parameters.AddWithValue("@DenNgay", _dtNgayKetThuc);

            DataSet _dsThongKeTheoHoaDon = conn.GetDataSet2(_cmd);
            _cmd.Dispose();

            DataTable _dtHoaDon = _dsThongKeTheoHoaDon.Tables[0];
            DataTable _dtHangMua = _dsThongKeTheoHoaDon.Tables[1];
            #endregion

            #region 2.Tính thống kê tổng thu, tổng lợi nhuận từng hóa đơn
            if (_dtHoaDon.Rows.Count > 0)

                for (int i = 0; i < _dtHoaDon.Rows.Count; i++)
                {
                    ThongKeTheoHoaDonPublic _thongKeTheoHoaDon = new ThongKeTheoHoaDonPublic();

                    ////Lấy thông tin hóa đơn 
                    //HoaDonPublic _hoaDon = new HoaDonPublic();
                    //_hoaDon.SoHD_HD = _dtHoaDon.Rows[i]["SoHD_HD"].ToString();
                    //_hoaDon.NgayLap_HD = Convert.ToDateTime(_dtHoaDon.Rows[i]["NgayLap_HD"].ToString());
                    //_hoaDon.NguoiLap_HD.MaNV_NV = _dtHoaDon.Rows[i]["NguoiLap_HD"].ToString();
                    //_hoaDon.KhachHang_HD.MaKH_KH = _dtHoaDon.Rows[i]["MaKH_HD"].ToString();
                    //_hoaDon.BanLe_HD = (bool)_dtHoaDon.Rows[i]["BanLe_HD"];
                    //_hoaDon.TongCKHoaDon = Convert.ToInt32(UntilitiesDataAccess.BoDauPhay(_dtHoaDon.Rows[i]["ChietKhauTienMat_HD"].ToString()));
                    //_hoaDon.TienKhachTra_HD = Convert.ToInt32(UntilitiesDataAccess.BoDauPhay(_dtHoaDon.Rows[i]["TienKhachTra_HD"].ToString()));
                    //_hoaDon.VouCher_HD = Convert.ToInt32(UntilitiesDataAccess.BoDauPhay(_dtHoaDon.Rows[i]["VouCher_HD"].ToString()));
                    //_hoaDon.MaGiamGia.MaThe_MGG = _dtHoaDon.Rows[i]["MaGiamGia_HD"].ToString();
                    //_hoaDon.CKPhanTram_HD = float.Parse(_dtHoaDon.Rows[i]["CKPhanTram_HD"].ToString());
                    //_hoaDon.TraHang_HD = (bool)_dtHoaDon.Rows[i]["TraHang_HD"];
                    //_hoaDon.DangDung_HD = (bool)_dtHoaDon.Rows[i]["DangDung_HD"];

                    //_thongKeTheoHoaDon.HoaDon = _hoaDon;

                    ////Tính tiền cho từng hóa đơn
                    //int _TongThu = 0;
                    //int _TongLai = 0;
                    //int _TongSoLuongBan = 0;
                    //int _TongTienNhap = 0;
                    //string _strFilterHangMua = "SoHD_HM = '" + _thongKeTheoHoaDon.HoaDon.SoHD_HD + "'";
                    //DataView _dvHangMua = new DataView(_dtHangMua, _strFilterHangMua, "SoHD_HM", DataViewRowState.CurrentRows);

                    //if (_dvHangMua.Count > 0)
                    //{
                    //    for (int j = 0; j < _dvHangMua.Count; j++)
                    //    {
                    //        int _soLuong = Convert.ToInt32(_dvHangMua[j]["SoLuong_HM"].ToString());
                    //        int _giaBan = Convert.ToInt32(UntilitiesDataAccess.BoDauPhay(_dvHangMua[j]["GiaBan_HM"].ToString()));
                    //        int _giaNhap = Convert.ToInt32(UntilitiesDataAccess.BoDauPhay(_dvHangMua[j]["GiaNhap_HM"].ToString()));
                    //        int _TienCKSP = Convert.ToInt32(UntilitiesDataAccess.BoDauPhay(_dvHangMua[j]["CKTienMat_HM"].ToString()));

                    //        _TongTienNhap = _TongTienNhap + _giaNhap;
                    //        _TongSoLuongBan = _TongSoLuongBan + _soLuong;
                    //        _TongThu = _TongThu + (_soLuong * _giaBan - _TienCKSP);
                    //    }
                    //    _TongLai = _TongThu - _TongTienNhap;
                    //}


                    HoaDonPublic _hd = TinhTien1HoaDon(_dtHoaDon.Rows[i]["SoHD_HD"].ToString());
                    _thongKeTheoHoaDon.HoaDon = _hd;
                    int _TongLoiNhuan = _hd.ThanhTien - _hd.TongTienNhap;

                    _thongKeTheoHoaDon.TongThu = UntilitiesDataAccess.ThemDauPhay(_hd.ThanhTien.ToString());
                    _thongKeTheoHoaDon.TongLoiNhuan = UntilitiesDataAccess.ThemDauPhay(_TongLoiNhuan.ToString());

                    _lstKqThongKeTheoHoaDon.Add(_thongKeTheoHoaDon);
                }

            #endregion

            return _lstKqThongKeTheoHoaDon;
        }

        //THỐNG KÊ THEO NHÂN VIÊN
        public static List<ThongKeTheoNhanVienPublic> ThongKeTheoNhanVien(DateTime _dtTuNgay, DateTime _dtDenNgay)
        {
            List<ThongKeTheoNhanVienPublic> _lstKQThongkeTheoNV = new List<ThongKeTheoNhanVienPublic>();

            #region 1.Lấy thông tin nhân viên, hóa đơn
            DateTime _dtNgayBatDau = new DateTime(_dtTuNgay.Year, _dtTuNgay.Month, _dtTuNgay.Day, 0, 0, 0);
            DateTime _dtNgayKetThuc = new DateTime(_dtDenNgay.Year, _dtDenNgay.Month, _dtDenNgay.Day, 23, 59, 59);

            SqlCommand _cmd = new SqlCommand();
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.CommandText = "[Thống kê theo nhân viên]";
            _cmd.Parameters.AddWithValue("@TuNgay", _dtNgayBatDau);
            _cmd.Parameters.AddWithValue("@DenNgay", _dtNgayKetThuc);

            DataSet _dsThongKeTheoNV = conn.GetDataSet2(_cmd);
            _cmd.Dispose();

            DataTable _dtNhanVien = _dsThongKeTheoNV.Tables[0];
            DataTable _dtHoaDon = _dsThongKeTheoNV.Tables[1];
            #endregion

            #region 2.Tính tổng thu, tổng lợi nhuận theo tưng nhân viên

            if (_dtNhanVien.Rows.Count == 0)
                return null;

            ThongKeTheoNhanVienPublic _thongkeTheoNV;
            for (int i = 0; i < _dtNhanVien.Rows.Count; i++)
            {
                //Lấy thông tin nhân viên
                _thongkeTheoNV = new ThongKeTheoNhanVienPublic();
                NhanVienPublic _nv = new NhanVienPublic();

                _nv.MaNV_NV = _dtNhanVien.Rows[i]["MaNV_NV"].ToString();
                _nv.HoTen_NV = _dtNhanVien.Rows[i]["HoTen_NV"].ToString();
                _nv.NgaySinh_NV = Convert.ToDateTime(_dtNhanVien.Rows[i]["NgaySinh_NV"].ToString());
                _nv.GioiTinh_NV = _dtNhanVien.Rows[i]["GioiTinh_NV"].ToString();
                _nv.DiaChi_NV = _dtNhanVien.Rows[i]["DiaChi_NV"].ToString();
                _nv.SDT_NV = _dtNhanVien.Rows[i]["SDT_NV"].ToString();
                _nv.Anh_NV = _dtNhanVien.Rows[i]["Anh_NV"].ToString();
                _nv.DangDung_NV = (bool)_dtNhanVien.Rows[i]["DangDung_NV"];

                _thongkeTheoNV.NhanVien = _nv;


                //Tính tiền các hóa đơn do nhân viên này lập từ ngày - đến ngày
                int _TongThu = 0;
                int _TongLai = 0;
                int _TongSoLuongHD = 0;
                int _TongTienNhap = 0;
                string _strFilterHoaDon = "NguoiLap_HD = '" + _thongkeTheoNV.NhanVien.MaNV_NV + "'";
                DataView _dvHD = new DataView(_dtHoaDon, _strFilterHoaDon, "SoHD_HD", DataViewRowState.CurrentRows);

                if (_dvHD.Count > 0)
                {
                    //Tính tiền từng hóa đơn
                    for (int j = 0; j < _dvHD.Count; j++)
                    {
                        HoaDonPublic _hd = TinhTien1HoaDon(_dvHD[j]["SoHD_HD"].ToString());

                        _TongThu = _TongThu + _hd.ThanhTien;
                        _TongTienNhap = _TongTienNhap + _hd.TongTienNhap;
                        _TongSoLuongHD++;
                    }
                    _TongLai = _TongThu - _TongTienNhap;
                }

                _thongkeTheoNV.TongLoiNhuan = UntilitiesDataAccess.ThemDauPhay(_TongLai.ToString());
                _thongkeTheoNV.TongThu = UntilitiesDataAccess.ThemDauPhay(_TongThu.ToString());
                _thongkeTheoNV.TongSoHDBanDuoc = _TongSoLuongHD;

                _lstKQThongkeTheoNV.Add(_thongkeTheoNV);
            }
            #endregion

            return _lstKQThongkeTheoNV;
        }

        //THỐNG KÊ THEO NHÂN VIÊN CHI TIẾT
        public static List<ThongKeTheoHoaDonPublic> ThongKeTheoNhanVienChiTiet(string _MaNV, DateTime _dtTuNgay, DateTime _dtDenNgay)
        {
            List<ThongKeTheoHoaDonPublic> _lstKqThongKeTheoNhanVien = new List<ThongKeTheoHoaDonPublic>();

            DateTime _dtNgayBatDau = new DateTime(_dtTuNgay.Year, _dtTuNgay.Month, _dtTuNgay.Day, 0, 0, 0);
            DateTime _dtNgayKetThuc = new DateTime(_dtDenNgay.Year, _dtDenNgay.Month, _dtDenNgay.Day, 23, 59, 59);

            //Lấy danh sách hóa đơn theo nhân viên
            SqlCommand _cmd = new SqlCommand();
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.CommandText = "[Lấy danh sách hóa đơn theo nhân viên]";
            _cmd.Parameters.AddWithValue("@Ma_NV", _MaNV);
            _cmd.Parameters.AddWithValue("@TuNgay", _dtNgayBatDau);
            _cmd.Parameters.AddWithValue("@DenNgay", _dtNgayKetThuc);

            DataTable _dtHoaDon = conn.GetDataSet2(_cmd).Tables[0];
            ThongKeTheoHoaDonPublic _thongKeTheoHoaDon;

            //Tính chi tiết hóa đơn
            if (_dtHoaDon.Rows.Count > 0)
            {
                for (int i = 0; i < _dtHoaDon.Rows.Count; i++)
                {
                    int _TongThu = 0;
                    int _TongLoiNhuan = 0;
                    int _TongTienNhap = 0;
                    _thongKeTheoHoaDon = new ThongKeTheoHoaDonPublic();
                    HoaDonPublic _hd = new HoaDonPublic();
                    _hd = TinhTien1HoaDon(_dtHoaDon.Rows[i]["SoHD_HD"].ToString());

                    _TongThu += _hd.ThanhTien;
                    _TongTienNhap += _hd.TongTienNhap;
                    _TongLoiNhuan = _TongThu - _TongTienNhap;

                    _thongKeTheoHoaDon.HoaDon = _hd;
                    _thongKeTheoHoaDon.TongThu = UntilitiesDataAccess.ThemDauPhay(_TongThu.ToString());
                    _thongKeTheoHoaDon.TongLoiNhuan = UntilitiesDataAccess.ThemDauPhay(_TongLoiNhuan.ToString());
                    _lstKqThongKeTheoNhanVien.Add(_thongKeTheoHoaDon);
                }
            }
            return _lstKqThongKeTheoNhanVien;
        }


        //PHIẾU NHẬP
        public static List<PhieuNhapPublic> LayPhieuNhapTheoNgay(DateTime _dtTuNgay, DateTime _dtDenNgay)
        {
            DateTime _dtNgayBatDau = new DateTime(_dtTuNgay.Year, _dtTuNgay.Month, _dtTuNgay.Day, 0, 0, 0);
            DateTime _dtNgayKetThuc = new DateTime(_dtDenNgay.Year, _dtDenNgay.Month, _dtDenNgay.Day, 23, 59, 59);

            //Lấy danh sách phiếu nhập trong khoảng thời gian
            List<PhieuNhapPublic> _lstPhieuNhap = new List<PhieuNhapPublic>();
            PhieuNhapPublic _phieuNhap;
            SqlCommand _cmd = new SqlCommand();
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.CommandText = "[Lấy danh sách phiếu nhập]";
            _cmd.Parameters.AddWithValue("@TuNgay", _dtNgayBatDau);
            _cmd.Parameters.AddWithValue("@DenNgay", _dtNgayKetThuc);

            DataTable _dtPhieuNhap = conn.GetDataSet2(_cmd).Tables[0];

            if (_dtPhieuNhap.Rows.Count > 0)
            {
                for (int i = 0; i < _dtPhieuNhap.Rows.Count; i++)
                {
                    _phieuNhap = new PhieuNhapPublic();

                    _phieuNhap.SoPhieu_PN = _dtPhieuNhap.Rows[i]["SoPhieu_PN"].ToString();
                    _phieuNhap.NgayNhap_PN = Convert.ToDateTime(_dtPhieuNhap.Rows[i]["NgayNhap_PN"].ToString());
                    _phieuNhap.NguoiNhap_PN.MaNV_NV = _dtPhieuNhap.Rows[i]["NguoiNhap_PN"].ToString();
                    _phieuNhap.NguoiNhap_PN.HoTen_NV = _dtPhieuNhap.Rows[i]["HoTen_NV"].ToString();
                    _phieuNhap.GhiChu_PN = _dtPhieuNhap.Rows[i]["GhiChu_PN"].ToString();

                    _lstPhieuNhap.Add(_phieuNhap);
                }
            }


            return _lstPhieuNhap;
        }

        //LẤY DANH SÁCH THÁNG TRONG NĂM
        public static List<Thang> DsThang()
        {
            List<Thang> _lstThang = new List<Thang>();
            Thang _thang;
            _thang = new Thang();
            _thang.Name = "Xem theo tháng";
            _thang.Value = "";
            _lstThang.Add(_thang);

            for (int i = 1; i <= 12; i++)
            {
                _thang = new Thang();
                _thang.Name = "Tháng " + i.ToString();
                _thang.Value = i.ToString();
                _lstThang.Add(_thang);
            }

            return _lstThang;
        }

    }//End class

    //Chứa thông tin cho wpf Thống kê theo sản phẩm
    public class ThongKeTheoSanPham
    {
        //Chứa thông tin sản phẩm
        private SanPhamPublic _Sanpham = new SanPhamPublic();
        public SanPhamPublic Sanpham
        {
            get { return _Sanpham; }
            set { _Sanpham = value; }
        }

        //Tổng tiền nhập của của toàn bộ 
        private string _TongNhap;
        public string TongNhap
        {
            get { return _TongNhap; }
            set { _TongNhap = value; }
        }

        //Tổng thu
        private string _TongThu;
        public string TongThu
        {
            get { return _TongThu; }
            set { _TongThu = value; }
        }

        //Tổng lãi
        private string _TongLai;
        public string TongLai
        {
            get { return _TongLai; }
            set { _TongLai = value; }
        }

        //Tổng số lượng bán ra
        private int _TongSoLuongBan;
        public int TongSoLuongBan
        {
            get { return _TongSoLuongBan; }
            set { _TongSoLuongBan = value; }
        }

    }//End class

    //Chứa thông tin thống kê theo hóa đơn
    public class ThongKeTheoHoaDonPublic
    {
        private HoaDonPublic _HoaDon = new HoaDonPublic();
        public HoaDonPublic HoaDon
        {
            get { return _HoaDon; }
            set { _HoaDon = value; }
        }

        private string _TongThu;
        public string TongThu
        {
            get { return _TongThu; }
            set { _TongThu = value; }
        }

        private string _TongLoiNhuan;
        public string TongLoiNhuan
        {
            get { return _TongLoiNhuan; }
            set { _TongLoiNhuan = value; }
        }
    }

    //CHỨA THÔNG TIN THỐNG KÊ NHÂN VIÊN
    public class ThongKeTheoNhanVienPublic
    {
        private NhanVienPublic _NhanVien;

        public NhanVienPublic NhanVien
        {
            get { return _NhanVien; }
            set { _NhanVien = value; }
        }

        private int _TongSoHDBanDuoc;
        public int TongSoHDBanDuoc
        {
            get { return _TongSoHDBanDuoc; }
            set { _TongSoHDBanDuoc = value; }
        }

        private string _TongThu;
        public string TongThu
        {
            get { return _TongThu; }
            set { _TongThu = value; }
        }

        private string _TongLoiNhuan;
        public string TongLoiNhuan
        {
            get { return _TongLoiNhuan; }
            set { _TongLoiNhuan = value; }
        }
    }

    //DANH SÁCH THÁNG TRONG NĂM - DÙNG CHO CBO
    public class Thang
    {
        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private string _value;
        public string Value
        {
            get { return _value; }
            set { _value = value; }
        }
    }
}

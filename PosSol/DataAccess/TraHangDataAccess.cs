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
    public class TraHangDataAccess
    {
        static ConnectionDataAccess conn = new ConnectionDataAccess();

        //Lấy hóa đơn theo số hóa đơn
        public static HoaDonPublic LayHoaDon(string _soHD)
        {
            HoaDonPublic _hd = null;

            SqlCommand _cmd = new SqlCommand();
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.CommandText = "[Lấy hóa đơn theo sohd - trả hàng]";
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

                return _hd;
            }

            return _hd;
        }

        //Lấy danh sách hàng mua
        public static List<HangMuaPubLic> LayDsHangMua(string _soHD)
        {
            List<HangMuaPubLic> _lstHangMua = null;
            HangMuaPubLic _hangMua;

            DataTable _dtHM;
            SqlCommand _cmd = new SqlCommand();
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.CommandText = "[Lấy danh sách hàng mua]";
            _cmd.Parameters.AddWithValue("@SoHD_HM", _soHD);

            _dtHM = conn.GetDataSet2(_cmd).Tables[0];

            if (_dtHM.Rows.Count > 0)
            {
                _lstHangMua = new List<HangMuaPubLic>();
                for (int i = 0; i < _dtHM.Rows.Count; i++)
                {
                    //Lấy thông tin sản phẩm
                    _hangMua = new HangMuaPubLic();

                    _hangMua.SanPham.MaSP_SP = _dtHM.Rows[i]["MaSP_SP"].ToString();
                    _hangMua.SanPham.TenSP_SP = _dtHM.Rows[i]["TenSP_SP"].ToString();
                    _hangMua.SanPham.GiaNhap_SP = _dtHM.Rows[i]["GiaNhap_SP"].ToString();
                    _hangMua.SanPham.GiaBanLe_SP = _dtHM.Rows[i]["GiaBanLe_SP"].ToString();
                    _hangMua.SanPham.GiaBanSi_SP = _dtHM.Rows[i]["GiaBanSi_SP"].ToString();
                    _hangMua.SanPham.NCC_SP.MaNCC_NCC = _dtHM.Rows[i]["MaNCC_SP"].ToString();
                    _hangMua.SanPham.NSP_SP.MaNSP_NSP = _dtHM.Rows[i]["MaNSP_SP"].ToString();
                    _hangMua.SanPham.DVT_SP.MaDVT_DVT = _dtHM.Rows[i]["MaDVT_SP"].ToString();
                    _hangMua.SanPham.GhiChu_SP = _dtHM.Rows[i]["GhiChu_SP"].ToString();
                    _hangMua.SanPham.SoLuong_SP = (int)_dtHM.Rows[i]["SoLuong_SP"];
                    _hangMua.SanPham.CKPhanTram_SP = float.Parse(_dtHM.Rows[i]["CKPhanTram_SP"].ToString());
                    _hangMua.SanPham.Anh_SP = _dtHM.Rows[i]["Anh_SP"].ToString();
                    _hangMua.SanPham.NgayTao_SP = (DateTime)_dtHM.Rows[i]["NgayTao_SP"];
                    _hangMua.SanPham.DVT_SP.TenDVT_DVT = _dtHM.Rows[i]["TenDVT_DVT"].ToString();

                    //Thông tin hàng mua
                    _hangMua.SoLuong = (int)_dtHM.Rows[i]["SoLuong_HM"];
                    _hangMua.ChietKhauPhanTram = float.Parse(_dtHM.Rows[i]["CKPhanTram_HM"].ToString());
                    _hangMua.ChietKhauTienMat = _dtHM.Rows[i]["CKTienMat_HM"].ToString();
                    _hangMua.GiaNhap_HM = _dtHM.Rows[i]["GiaNhap_HM"].ToString();
                    _hangMua.GiaBan_HM = _dtHM.Rows[i]["GiaBan_HM"].ToString();

                    //lấy thông tin hóa đơn
                    _hangMua.HoaDon.SoHD_HD = _dtHM.Rows[0]["SoHD_HD"].ToString();
                    _hangMua.HoaDon.NgayLap_HD = (DateTime)_dtHM.Rows[0]["NgayLap_HD"];
                    _hangMua.HoaDon.NguoiLap_HD.MaNV_NV = _dtHM.Rows[0]["NguoiLap_HD"].ToString();
                    _hangMua.HoaDon.BanLe_HD = (bool)_dtHM.Rows[0]["BanLe_HD"];
                    _hangMua.HoaDon.KhachHang_HD.MaKH_KH = _dtHM.Rows[0]["MaKH_HD"].ToString();
                    _hangMua.HoaDon.CKPhanTram_HD = float.Parse(_dtHM.Rows[0]["CKPhanTram_HD"].ToString());
                    _hangMua.HoaDon.TongCKHoaDon = Convert.ToInt32(_dtHM.Rows[0]["ChietKhauTienMat_HD"].ToString());
                    _hangMua.HoaDon.TienKhachTra_HD = Convert.ToInt32(_dtHM.Rows[0]["TienKhachTra_HD"].ToString());
                    _hangMua.HoaDon.VouCher_HD = Convert.ToInt32(_dtHM.Rows[0]["VouCher_HD"].ToString());
                    _hangMua.HoaDon.MaGiamGia.MaThe_MGG = _dtHM.Rows[0]["MaGiamGia_HD"].ToString();

                    //Tính thành tiền cho hàng mua (đang dùng ở thống kê báo cáo)
                    int _TienckSP = Convert.ToInt32(UntilitiesDataAccess.BoDauPhay(_hangMua.ChietKhauTienMat));

                    //Tính tiền cho sản phẩm

                    float _CkPhanTram = _hangMua.ChietKhauPhanTram;
                    int _giaBan = Convert.ToInt32(UntilitiesDataAccess.BoDauPhay(_hangMua.GiaBan_HM));
                    int _soLuong = _hangMua.SoLuong;

                    int _TongCKSanPham = (int)((_CkPhanTram * _giaBan / 100) * _soLuong);
                    int _TongTien = _soLuong * _giaBan;
                    int _ThanhTien = _TongTien - _TongCKSanPham;

                    _hangMua.TongTienSP = _TongTien;
                    _hangMua.ThanhTien = _ThanhTien;

                    _hangMua.SanPham.ThanhTien_SP = UntilitiesDataAccess.ThemDauPhay((_hangMua.TongTienSP - _TienckSP).ToString());

                    _lstHangMua.Add(_hangMua);
                }
            }

            return _lstHangMua;
        }

        //Lấy khách hàng theo mã
        public static KhachHangPublic LayKhachHang(string _maKH)
        {
            KhachHangPublic _kh = null;

            SqlCommand _cmd = new SqlCommand();
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.CommandText = "[Lấy khách hàng theo mã - bán hàng]";
            _cmd.Parameters.AddWithValue("@MaKH_KH", _maKH);

            DataTable _dtKH = conn.GetDataSet2(_cmd).Tables[0];
            if (_dtKH.Rows.Count > 0)
            {
                _kh = new KhachHangPublic();

                //Thông tin khách hàng
                _kh.MaKH_KH = _dtKH.Rows[0]["MaKH_KH"].ToString();
                _kh.HoTen_KH = _dtKH.Rows[0]["HoTen_KH"].ToString();
                _kh.GioiTinh_KH = _dtKH.Rows[0]["GioiTinh_KH"].ToString();
                _kh.NgaySinh_KH = (DateTime)_dtKH.Rows[0]["NgaySinh_KH"];
                _kh.Email_KH = _dtKH.Rows[0]["Email_KH"].ToString();
                _kh.NHK_KH.MaNKH_NKH = _dtKH.Rows[0]["Ma_NHK_KH"].ToString();
                _kh.DiemTichLuy_KH = (int)_dtKH.Rows[0]["DiemTichLuy_KH"];
                _kh.SoLanMuaHang_KH = (int)_dtKH.Rows[0]["SoLanMuaHang_KH"];
                _kh.LanMuaHangGanNhat_KH = (DateTime)_dtKH.Rows[0]["LanMuaHangGanNhat_KH"];
                _kh.SDT_KH = _dtKH.Rows[0]["SDT_KH"].ToString();
                _kh.GhiChu = _dtKH.Rows[0]["GhiChu_KH"].ToString();
                _kh.NgayTao_KH = (DateTime)_dtKH.Rows[0]["NgayTao_KH"];
                _kh.TuDongLenNhom_KH = (bool)_dtKH.Rows[0]["TuDongLenNhom_KH"];

                //nhóm khach hàng
                _kh.NHK_KH.TenNKH_NKH = _dtKH.Rows[0]["TenNKH_NKH"].ToString();
                _kh.NHK_KH.ChietKhau_NKH = (int)_dtKH.Rows[0]["ChietKhau_NKH"];
            }

            return _kh;
        }

        //Lấy tiền mã giảm giá
        public static int LayCKMaGiamGia(string _MaGiamGia)
        {
            int _CKMaGiamGia = 0;

            SqlCommand _cmd = new SqlCommand();
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.CommandText = "[Lấy mã giảm giá theo mã - bán hàng]";
            _cmd.Parameters.AddWithValue("@MaGG_MGG", _MaGiamGia);

            DataTable _dtMGG = conn.GetDataSet2(_cmd).Tables[0];
            if (_dtMGG.Rows.Count > 0)
                _CKMaGiamGia = (int)_dtMGG.Rows[0]["ChietKhau_MGG"];

            return _CKMaGiamGia;
        }

        //Nhập sản phẩm vào kho
        public static bool NhapSPVaoKho(string _maSp, int _soLuong, string _ghiChu)
        {
            SqlCommand _cmd = new SqlCommand();
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.CommandText = "[Nhập sản phẩm trả vào kho]";
            _cmd.Parameters.AddWithValue("@MaSP_SP", _maSp);
            _cmd.Parameters.AddWithValue("@SoLuong_SP", _soLuong);
            _cmd.Parameters.AddWithValue("@GhiChu_SP", _ghiChu);

            return conn.Execute(_cmd);
        }

        //Hủy hóa đơn
        public static void HuyHoaDon(HoaDonPublic _hoaDon)
        {
            //Đổi trạng thái hóa đơn
            SqlCommand _cmd = new SqlCommand();
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.CommandText = "[Hủy hóa đơn]";
            _cmd.Parameters.AddWithValue("@SoHD_HD", _hoaDon.SoHD_HD);
            conn.Execute(_cmd);
            _cmd.Dispose();

            if (_hoaDon.KhachHang_HD.MaKH_KH != null)
            {
                //Trừ điểm khách hàng
                ThietLapHeThongPublic _thietLap = ThietLapHeThongDataAccess.LayThietLapHeThong();
                int _diemTru = _hoaDon.TongTien_HD / _thietLap.MucQuyDoiDiem;

                TruDiemKhachHang(_hoaDon.KhachHang_HD.MaKH_KH, _diemTru);

                //Chỉnh nhóm khách hàng
                XetNhomKhacHang(_hoaDon.KhachHang_HD);
            }

        }

        //Trừ điểm khách hàng
        private static void TruDiemKhachHang(string _maKH, int _diemTru)
        {
            SqlCommand _cmd = new SqlCommand();
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.CommandText = "[Trừ điểm khách hàng]";
            _cmd.Parameters.AddWithValue("@MaKH_KH", _maKH);
            _cmd.Parameters.AddWithValue("@DiemTichLuy_KH", _diemTru);
            conn.Execute(_cmd);
        }

        //Chỉnh nhóm khách hàng
        private static void XetNhomKhacHang(KhachHangPublic _kh)
        {
            if (String.IsNullOrEmpty(_kh.MaKH_KH))
                return;

            if (!_kh.TuDongLenNhom_KH)
                return;

            //Lấy nhóm khách hàng điểm thấp hơn gần nhất
            SqlCommand _cmd = new SqlCommand();
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.CommandText = "[lẤY NHÓM KHÁCH HÀNG THEO ĐIỂM]";
            _cmd.Parameters.AddWithValue("@Diem_NKH", _kh.DiemTichLuy_KH);

            DataTable _dtNKH = conn.GetDataSet2(_cmd).Tables[0];
            if (_dtNKH.Rows.Count > 0)
            {
                //Update nhóm khách hàng cho khách hàng
                _cmd = new SqlCommand();
                _cmd.CommandType = CommandType.StoredProcedure;
                _cmd.CommandText = "[Xét nhóm khách hàng cho khách hàng]";
                _cmd.Parameters.AddWithValue("@MaKH_KH", _kh.MaKH_KH);
                _cmd.Parameters.AddWithValue("@Ma_NHK_KH", _dtNKH.Rows[0]["MaNKH_NKH"].ToString());

                conn.Execute(_cmd);
            }
        }

        //Danh sách hóa đơn
        public static DataTable DanhSachHoaDon()
        {
            return conn.GetDataSet("[Danh sách hóa đơn]").Tables[0];
        }
    }//End class
}

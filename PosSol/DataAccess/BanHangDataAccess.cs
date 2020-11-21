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
    public class BanHangDataAccess
    {
        static ConnectionDataAccess conn = new ConnectionDataAccess();
        static ThietLapHeThongPublic _thietLap = ThietLapHeThongDataAccess.LayThietLapHeThong();

        //Lấy danh sách sản phẩm
        public static DataSet DsSanPham()
        {
            string _storeprodureName = "[Lấy ds sản phẩm - bán hàng]";
            return conn.GetDataSet(_storeprodureName);
        }

        //Lấy sản phẩm theo mã
        public static DataSet LaySpTheoMa(string _MaSp)
        {
            SqlCommand _cmd = new SqlCommand();
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.CommandText = "[Lấy SP theo mã - bán hàng]";
            _cmd.Parameters.AddWithValue("@MaSP_SP", _MaSp);

            return conn.GetDataSet2(_cmd);
        }

        //Lấy khách hàng theo mã
        public static DataSet LayKhTheoMa(string _MaKh)
        {
            SqlCommand _cmd = new SqlCommand();
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.CommandText = "[Lấy khách hàng theo mã - bán hàng]";
            _cmd.Parameters.AddWithValue("@MaKH_KH", _MaKh);

            return conn.GetDataSet2(_cmd);
        }

        //Lấy nhóm khách hàng theo mã
        public static DataSet LayNKHTheoMa(string _MaNKH)
        {
            SqlCommand _cmd = new SqlCommand();
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.CommandText = "[Lấy nhóm khách hàng theo mã - bán hàng]";
            _cmd.Parameters.AddWithValue("@MaNKH_NKH", _MaNKH);

            return conn.GetDataSet2(_cmd);
        }

        //Lấy danh sách kho
        public static List<KhoPublic> LayDSKho()
        {
            List<KhoPublic> DsKho = new List<KhoPublic>();
            DataSet ds = new DataSet();
            string StoreProdureName = "LayDSKho";
            DataTable dt = new DataTable();
            KhoPublic Kho;
            dt = conn.GetDataSet(StoreProdureName).Tables[0];
            foreach (DataRow row in dt.Rows)
            {
                Kho = new KhoPublic();
                //Kho.Ma_Kho = row["Ma_Kho"].ToString();
                //Kho.TenKho = row["TenKho"].ToString();
                DsKho.Add(Kho);
            }
            return DsKho;
        }

        //Nhập vào mã hàng,Kho, số lượng, lẻ|buôn - trả về một đối tượng chứa mọi thông tin hàng
        public static HangMuaPubLic LayHangMua(string MaSP_SP, bool KieuBan, int SoLuong)// kiểu bán lẻ hoặc sỉ true = bán lẻ | false =  bán sỉ
        {
            HangMuaPubLic hm = new HangMuaPubLic();

            //Lấy ra thông tin sản phẩm
            string StoreprodureName = "LaySPTheoMa_BanHang";
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = StoreprodureName;
            cmd.Parameters.AddWithValue("@MaSP_SP", MaSP_SP);

            DataSet ds = conn.GetDataSet2(cmd);
            SanPhamPublic sp = new SanPhamPublic();//Chứa thông tin sản phẩm cần lấy ra
            if (ds.Tables[0].Rows.Count > 0)
            {
                //Lấy thông tin
                DataRow dr = ds.Tables[0].Rows[0];
                sp.MaSP_SP = dr["MaSP_SP"].ToString();
                sp.TenSP_SP = dr["TenSP_SP"].ToString();
                sp.GiaNhap_SP = UntilitiesDataAccess.BoDauPhay(dr["GiaNhap_SP"].ToString());
                sp.GiaBanLe_SP = UntilitiesDataAccess.BoDauPhay(dr["GiaBanLe_SP"].ToString());
                sp.GiaBanSi_SP = UntilitiesDataAccess.BoDauPhay(dr["GiaBanSi_SP"].ToString());

                sp.NCC_SP.MaNCC_NCC = dr["MaNCC_NCC"].ToString();
                sp.NCC_SP.TenNCC_NCC = dr["TenNCC_NCC"].ToString();
                sp.NCC_SP.GhiChu_NCC = dr["GhiChu_NCC"].ToString();

                sp.NSP_SP.MaNSP_NSP = dr["MaNSP_NSP"].ToString();
                sp.NSP_SP.TenNSP_NSP = dr["TenNSP_NSP"].ToString();
                sp.NSP_SP.GhiChu_NSP = dr["GhiChu_NSP"].ToString();
                sp.NSP_SP.DangDung_NSP = dr["DangDung_NSP"].ToString() == "true" ? true : false;
                sp.NSP_SP.NgayTao_NSP = Convert.ToDateTime(dr["NgayTao_NSP"].ToString());

                sp.DVT_SP.MaDVT_DVT = dr["MaDVT_DVT"].ToString();
                sp.DVT_SP.TenDVT_DVT = dr["TenDVT_DVT"].ToString();
                sp.DVT_SP.DangDung_DVT = dr["DangDung_DVT"].ToString() == "true" ? true : false;

                sp.GhiChu_SP = dr["GhiChu_SP"].ToString();
                sp.SoLuong_SP = Convert.ToInt32(dr["SoLuong_SP"].ToString());
                sp.CKPhanTram_SP = Convert.ToInt32(dr["CKPhanTram_SP"].ToString());
            }
            else
                return hm = null; // Trả về null nếu không có sản phẩm nào


            //Tính toán giá tiền sản phẩm - có thể viết một hàm tính tiền riêng để áp dụng chính sách khác nhau
            #region Tính toán giá tiền cho sản phẩm này
            hm.SanPham = sp;
            hm.ChietKhauPhanTram = hm.SanPham.CKPhanTram_SP;
            hm.SoLuong = SoLuong; // Số lượng mặc định ban đầu khi mua là 1 sp
            if (KieuBan == true)//Bán lẻ
            {
                //hm.ChietKhauTienMat = hm.SoLuong * (Convert.ToInt32(hm.ChietKhauPhanTram) * Convert.ToInt32(hm.SanPham.GiaBanLe_SP)) / 100;
                //hm.TongTienSP = hm.SoLuong * Convert.ToInt32(hm.SanPham.GiaBanLe_SP);
                //hm.ThanhTien = hm.TongTienSP - hm.ChietKhauTienMat;//Thành tiền gia bán lẻ
            }
            else//Bán sỉ
            {
                //hm.ChietKhauTienMat = hm.SoLuong * (Convert.ToInt32(hm.ChietKhauPhanTram) * Convert.ToInt32(hm.SanPham.GiaBanSi_SP)) / 100;
                //hm.TongTienSP = Convert.ToInt32(hm.SanPham.GiaBanSi_SP) * hm.SoLuong;
                //hm.ThanhTien = hm.TongTienSP - hm.ChietKhauTienMat; // Thành tiền giá bán sỉ
            }
            #endregion
            return hm;
        }

        //Bán hàng
        public static void BanHang(HoaDonPublic _hoaDon, List<SanPhamPublic> _gioHang, bool _truSoLuong)
        {
            #region 1.Thêm mới hóa đơn
            //Lưu hóa đơn mới
            ThemMoiHoaDon(_hoaDon);

            //Tắt mã giảm giá nếu có
            if (!String.IsNullOrEmpty(_hoaDon.MaGiamGia.MaThe_MGG))
                TatMaGiamGia(_hoaDon.MaGiamGia.MaThe_MGG);
            #endregion

            #region 2.Lưu hàng mua

            HangMuaPubLic _hangMua = new HangMuaPubLic();
            _hangMua.HoaDon.SoHD_HD = _hoaDon.SoHD_HD;
            foreach (SanPhamPublic _sp in _gioHang)
            {
                //Lấy thông tin hàng mua
                _hangMua.SanPham.MaSP_SP = _sp.MaSP_SP;
                _hangMua.SoLuong = _sp.SoLuong_SP;
                _hangMua.ChietKhauPhanTram = _sp.CKPhanTram_SP;
                _hangMua.ChietKhauTienMat = _sp.CKTienMat;
                _hangMua.GiaNhap_HM = _sp.GiaNhap_SP;
                _hangMua.GiaBan_HM = _sp.GiaBan;

                //Thêm hàng mua
                ThemHangMua(_hangMua);

                //Trừ hàng trong kho
                if (_truSoLuong)
                    TruSoLuongSPTrongKho(_hangMua.SanPham.MaSP_SP, _hangMua.SoLuong);
            }

            #endregion

            #region 3.Cập nhật thông tin mua hàng cho khác

            //Cộng điểm tích lũy cho khách hàng
            if (!String.IsNullOrEmpty(_hoaDon.KhachHang_HD.MaKH_KH))
            {
                bool _CongDiem = _thietLap.CongDiemKhachHang; //(Cấu  hình bật tắt chức năng)
                if (_CongDiem)
                    CongDiemTichLuy(_hoaDon.KhachHang_HD.MaKH_KH, _hoaDon.TongTien_HD);

                //Cập nhật số lần mua hàng và ngày mua hàng gần nhất
                CapNhatSoLanMuaChoKhach(_hoaDon.KhachHang_HD.MaKH_KH);

                //Xét nhóm khách hàng cho khách hàng
                XetNhomKhacHang(_hoaDon.KhachHang_HD);
            }
            #endregion

            #region 4.Lưu lịch sử bán hàng

            LichSuBanHangPublic _lsbh = new LichSuBanHangPublic();
            _lsbh.MaLSBH_LSBH = UntilitiesDataAccess.GetNextID("tbl_LICHSUBANHANG", "MaLSBH_LSBH", "LS.", 10);
            _lsbh.NhanVienThucHien_LSBH.MaNV_NV = _hoaDon.NguoiLap_HD.MaNV_NV;
            _lsbh.SoHD_LSBH.SoHD_HD = _hoaDon.SoHD_HD;
            _lsbh.MoTa_LSBH = "Khách mua hàng";
            _lsbh.ThoiGian_LSBH = DateTime.Now;

            LichSuBanHangDataAccess.ThemLichSuBanHang(_lsbh);
            #endregion
        }
        //Tắt mã giảm giá
        private static bool TatMaGiamGia(string _maGiamGia)
        {
            SqlCommand _cmd = new SqlCommand();
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.CommandText = "[Sử dụng mã giảm giá]";
            _cmd.Parameters.AddWithValue("@MaGG_MGG", _maGiamGia);

            return conn.Execute(_cmd);
        }

        //Thêm mới hóa đơn
        private static void ThemMoiHoaDon(HoaDonPublic _hoaDon)
        {
            //Tính lại % chiết khấu hóa đơn để khi trả sp có giá để tính
            _hoaDon.CKPhanTram_HD = ((float)_hoaDon.TongCKHoaDon / (float)_hoaDon.TongTien_HD) * 100;


            SqlCommand _cmd = new SqlCommand();
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.CommandText = "[Thêm hóa đơn - bán hàng]";
            _cmd.Parameters.AddWithValue("@SoHD_HD", _hoaDon.SoHD_HD);
            _cmd.Parameters.AddWithValue("@NgayLap_HD", _hoaDon.NgayLap_HD);
            _cmd.Parameters.AddWithValue("@NguoiLap_HD", _hoaDon.NguoiLap_HD.MaNV_NV);
            _cmd.Parameters.AddWithValue("@MaKH_HD", _hoaDon.KhachHang_HD.MaKH_KH == null ? "" : _hoaDon.KhachHang_HD.MaKH_KH);
            _cmd.Parameters.AddWithValue("@BanLe_HD", _hoaDon.BanLe_HD);
            _cmd.Parameters.AddWithValue("@ChietKhauTienMat_HD", _hoaDon.TongCKHoaDon);
            _cmd.Parameters.AddWithValue("@TienKhachTra_HD", _hoaDon.TienKhachTra_HD);
            _cmd.Parameters.AddWithValue("@VouCher_HD", _hoaDon.VouCher_HD);
            _cmd.Parameters.AddWithValue("@MaGiamGia_HD", _hoaDon.MaGiamGia.MaThe_MGG == null ? "" : _hoaDon.MaGiamGia.MaThe_MGG);
            _cmd.Parameters.AddWithValue("@CKPhanTram_HD", _hoaDon.CKPhanTram_HD);
            _cmd.Parameters.AddWithValue("@DangDung_HD", _hoaDon.DangDung_HD);
            conn.Execute(_cmd);
        }

        //Thêm mới chi tiết hàng mua
        private static void ThemHangMua(HangMuaPubLic _hangMua)
        {
            //Tính lại chiết khấu phần trăm
            int _TongTien = _hangMua.SoLuong * Convert.ToInt32(UntilitiesDataAccess.BoDauPhay(_hangMua.GiaBan_HM));
            int _CkTienMat = Convert.ToInt32(UntilitiesDataAccess.BoDauPhay(_hangMua.ChietKhauTienMat));
            _hangMua.ChietKhauPhanTram = ((float)_CkTienMat / (float)_TongTien) * 100;

            SqlCommand _cmd = new SqlCommand();
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.CommandText = "[Thêm chi tiết hàng mua - bán hàng]";
            _cmd.Parameters.AddWithValue("@SoHD_HM", _hangMua.HoaDon.SoHD_HD);
            _cmd.Parameters.AddWithValue("@MaSP_HM", _hangMua.SanPham.MaSP_SP);
            _cmd.Parameters.AddWithValue("@SoLuong_HM", _hangMua.SoLuong);
            _cmd.Parameters.AddWithValue("@CKTienMat_HM", _hangMua.ChietKhauTienMat);
            _cmd.Parameters.AddWithValue("@GiaNhap_HM", _hangMua.GiaNhap_HM);
            _cmd.Parameters.AddWithValue("@GiaBan_HM", _hangMua.GiaBan_HM);
            _cmd.Parameters.AddWithValue("@CKPhanTram_HM", _hangMua.ChietKhauPhanTram);
            conn.Execute(_cmd);
        }

        //Trừ số lượng hàng trong kho
        private static void TruSoLuongSPTrongKho(string _maSP, int _soLuongTru)
        {
            SqlCommand _cmd = new SqlCommand();
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.CommandText = "[Trừ hàng trong kho - bán hàng]";
            _cmd.Parameters.AddWithValue("@MaSP_SP", _maSP);
            _cmd.Parameters.AddWithValue("@SoLuong_SP", _soLuongTru);

            conn.Execute(_cmd);
        }

        //Cộng điểm tích lũy
        private static void CongDiemTichLuy(string _maKH, int _TongTien)
        {
            //Lấy mức đổi điểm (nghìn đồng / 1 điểm)
            int _mucQuyDoi = _thietLap.MucQuyDoiDiem;

            int _diemCongThem = _TongTien / _mucQuyDoi;
            SqlCommand _cmd = new SqlCommand();
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.CommandText = "[Cộng điểm tích lũy - bán hàng]";
            _cmd.Parameters.AddWithValue("@MaKH_KH", _maKH);
            _cmd.Parameters.AddWithValue("@DiemTichLuy_KH", _diemCongThem);

            conn.Execute(_cmd);
        }

        //Cập nhất số lần mua hàng và lượt mua gần nhất cho khách hàng
        private static void CapNhatSoLanMuaChoKhach(string _maKH)
        {
            SqlCommand _cmd = new SqlCommand();
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.CommandText = "[Cập nhật mua hàng cho khách hàng]";
            _cmd.Parameters.AddWithValue("@MaKH_KH", _maKH);

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

        //Lấy mã giảm giá the mã
        public static DataSet LayMaGiamGiaTheoMa(string _MaGG)
        {
            SqlCommand _cmd = new SqlCommand();
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.CommandText = "[Lấy mã giảm giá theo mã - bán hàng]";
            _cmd.Parameters.AddWithValue("@MaGG_MGG", _MaGG);
            return conn.GetDataSet2(_cmd);
        }
    }//End class
}

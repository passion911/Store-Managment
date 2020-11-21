using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Public;
using System.Data.SqlClient;

namespace DataAccess
{
    public class KhachHangDataAccess
    {
        static ConnectionDataAccess conn = new ConnectionDataAccess();

        //DANH SÁCH KHÁCH HÀNG
        public static DataSet DsKhachHang()
        {
            string StoreprodureName = "[Danh sách khách hàng]";
            return conn.GetDataSet(StoreprodureName);
        }

        //Thêm khách hàng
        public static bool ThemKhachHang(KhachHangPublic _kh)
        {
            SqlCommand _cmd = new SqlCommand();
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.CommandText = "[Thêm mới khách hàng]";
            _cmd.Parameters.AddWithValue("@MaKH_KH", _kh.MaKH_KH);
            _cmd.Parameters.AddWithValue("@HoTen_KH", _kh.HoTen_KH);
            _cmd.Parameters.AddWithValue("@GioiTinh_KH", _kh.GioiTinh_KH);
            _cmd.Parameters.AddWithValue("@NgaySinh_KH", _kh.NgaySinh_KH);
            _cmd.Parameters.AddWithValue("@Email_KH", _kh.Email_KH);
            _cmd.Parameters.AddWithValue("@Ma_NHK_KH", _kh.NHK_KH.MaNKH_NKH);
            _cmd.Parameters.AddWithValue("@DiemTichLuy_KH", _kh.DiemTichLuy_KH);
            _cmd.Parameters.AddWithValue("@SoLanMuaHang_KH", _kh.SoLanMuaHang_KH);
            _cmd.Parameters.AddWithValue("@SDT_KH", _kh.SDT_KH);
            _cmd.Parameters.AddWithValue("@GhiChu_KH", _kh.GhiChu);
            _cmd.Parameters.AddWithValue("@TuDongLenNhom_KH", _kh.TuDongLenNhom_KH == true ? "1" : "0");
            _cmd.Parameters.AddWithValue("@DangDung_KH", _kh.DangDung_KH == true ? "1" : "0");
            return conn.Execute(_cmd);
        }

        //Sửa thông tin khách hàng
        public static bool SuaKhachHang(KhachHangPublic _kh)
        {
            SqlCommand _cmd = new SqlCommand();
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.CommandText = "[Sửa khách hàng]";
            _cmd.Parameters.AddWithValue("@MaKH_KH", _kh.MaKH_KH);
            _cmd.Parameters.AddWithValue("@HoTen_KH", _kh.HoTen_KH);
            _cmd.Parameters.AddWithValue("@GioiTinh_KH", _kh.GioiTinh_KH);
            _cmd.Parameters.AddWithValue("@NgaySinh_KH", _kh.NgaySinh_KH);
            _cmd.Parameters.AddWithValue("@Email_KH", _kh.Email_KH);
            _cmd.Parameters.AddWithValue("@Ma_NHK_KH", _kh.NHK_KH.MaNKH_NKH);
            _cmd.Parameters.AddWithValue("@DiemTichLuy_KH", _kh.DiemTichLuy_KH);
            _cmd.Parameters.AddWithValue("@SoLanMuaHang_KH", _kh.SoLanMuaHang_KH);
            _cmd.Parameters.AddWithValue("@SDT_KH", _kh.SDT_KH);
            _cmd.Parameters.AddWithValue("@GhiChu_KH", _kh.GhiChu);
            _cmd.Parameters.AddWithValue("@TuDongLenNhom_KH", _kh.TuDongLenNhom_KH);
            _cmd.Parameters.AddWithValue("@DangDung_KH", _kh.DangDung_KH == true ? "1" : "0");

            return conn.Execute(_cmd);
        }

        //Xóa khách hàng
        public static bool XoaKhachHang(string _MaKH)
        {
            if (UntilitiesDataAccess.CheckExist("tbl_HOADON", "MaKH_HD", _MaKH))
                return false;

            SqlCommand _cmd = new SqlCommand();
            _cmd.CommandText = "[Xóa khách hàng]";
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@MaKH", _MaKH);

            return conn.Execute(_cmd);
        }

        //Lấy nhóm khách hàng - cbo
        public static List<NhomKhachHangPublic> LayNhomKhachHang()
        {
            List<NhomKhachHangPublic> _ListNhomKhachHang = new List<NhomKhachHangPublic>();
            NhomKhachHangPublic _nkh;
            DataTable _DtNKH = conn.GetDataSet("[Danh sách nhóm khách hàng - cbo]").Tables[0];
            foreach (DataRow _dr in _DtNKH.Rows)
            {
                _nkh = new NhomKhachHangPublic();
                _nkh.DangDung_NKH = (bool)_dr["DangDung_NKH"];
                if (!_nkh.DangDung_NKH)
                    continue;
                _nkh.MaNKH_NKH = _dr["MaNKH_NKH"].ToString();
                _nkh.TenNKH_NKH = _dr["TenNKH_NKH"].ToString();
                _nkh.Anh_NKH = System.IO.Path.GetFullPath("../../Image/NhomKhachHang/" + _dr["Anh_NKH"].ToString());
                _ListNhomKhachHang.Add(_nkh);
            }
            return _ListNhomKhachHang;
        }

        //Lấy nhóm khách hàng 2 - dùng ở trang quản lý khách hàng
        public static List<NhomKhachHangPublic> LayNhomKhachHang2()
        {
            List<NhomKhachHangPublic> _ListNhomKhachHang = new List<NhomKhachHangPublic>();
            NhomKhachHangPublic _nkh;
            DataTable _DtNKH = conn.GetDataSet("[Danh sách nhóm khách hàng - cbo]").Tables[0];
            _nkh = new NhomKhachHangPublic();
            _nkh.MaNKH_NKH = "";
            _nkh.TenNKH_NKH = "---Tất cả---";
            _ListNhomKhachHang.Add(_nkh);

            foreach (DataRow _dr in _DtNKH.Rows)
            {
                _nkh = new NhomKhachHangPublic();
                _nkh.MaNKH_NKH = _dr["MaNKH_NKH"].ToString();
                _nkh.TenNKH_NKH = _dr["TenNKH_NKH"].ToString();
                _nkh.Anh_NKH = System.IO.Path.GetFullPath("../../Image/NhomKhachHang/" + _dr["Anh_NKH"].ToString());
                _nkh.DangDung_NKH = (bool)_dr["DangDung_NKH"];
                if (!_nkh.DangDung_NKH)
                    _nkh.TenNKH_NKH += " (Đã bị tắt)";
                _ListNhomKhachHang.Add(_nkh);
            }
            return _ListNhomKhachHang;
        }
    }//END CLASS
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Public;
using DataAccess;

namespace Business
{
    public class KhachHangBusiness
    {
        //DANH SÁCH KHÁCH HÀNG
        public static DataSet DsKhachHang()
        {
            return KhachHangDataAccess.DsKhachHang();
        }

        //Thêm khách hàng
        public static bool ThemKhachHang(KhachHangPublic _kh)
        {
            return KhachHangDataAccess.ThemKhachHang(_kh);
        }

        //Sửa thông tin khách hàng
        public static bool SuaKhachHang(KhachHangPublic _kh)
        {
            return KhachHangDataAccess.SuaKhachHang(_kh);
        }

        //Xóa khách hàng
        public static bool XoaKhachHang(string _MaKH)
        {
            return KhachHangDataAccess.XoaKhachHang(_MaKH);
        }

        //Lấy nhóm khách hàng - cbo
        public static List<NhomKhachHangPublic> LayNhomKhachHang()
        {
            return KhachHangDataAccess.LayNhomKhachHang();
        }

        //Lấy nhóm khách hàng 2 - dùng ở trang quản lý khách hàng
        public static List<NhomKhachHangPublic> LayNhomKhachHang2()
        {
            return KhachHangDataAccess.LayNhomKhachHang2();
        }

    }//END CLASS
}

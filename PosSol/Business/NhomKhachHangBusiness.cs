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
    public class NhomKhachHangBusiness
    {
        //Danh sách nhóm khách hàng
        public static DataSet DsNhomKhachHang()
        {
            return NhomKhachHangDataAccess.DsNhomKhachHang();
        }

        //Lấy anh nhóm khách hàng
        public static List<AnhNhomKhachhang> LayAnhNKH()
        {
            return NhomKhachHangDataAccess.LayAnhNKH();
        }

        //Thêm nhóm khách hàng
        public static bool ThemNhomKhachHang(NhomKhachHangPublic _nkh)
        {
            return NhomKhachHangDataAccess.ThemNhomKhachHang(_nkh);
        }

        //Sửa thông tin nhóm khách hàng
        public static bool SuaNhomKhachHang(NhomKhachHangPublic _nkh)
        {
            return NhomKhachHangDataAccess.SuaNhomKhachHang(_nkh);
        }

        //Xóa nhóm khách hàng
        public static bool XoaNhomKhachHang(string _MaNKH)
        {
            return NhomKhachHangDataAccess.XoaNhomKhachHang(_MaNKH);
        }
    }//end class
}

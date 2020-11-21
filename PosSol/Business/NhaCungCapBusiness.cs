using System.Data;
using Public;
using DataAccess;

namespace Business
{
    public class NhaCungCapBusiness
    {
        //DANH SÁCH NHAC CUNG CẤP
        public static DataSet DsNhaCungCap()
        {
            return NhaCungCapDataAccess.DsNhaCungCap();
        }

        //THÊM MỚI NHÀ CUNG CẤP
        public static bool ThemNhaCungCap(NhaCungCapPublic _ncc)
        {
            return NhaCungCapDataAccess.ThemNhaCungCap(_ncc);
        }

        //SỬA NHÀ CUNG CẤP
        public static bool SuaNhaCungCap(NhaCungCapPublic _ncc)
        {
            return NhaCungCapDataAccess.SuaNhaCungCap(_ncc);
        }

        //XÓA NHÀ CUNG CẤP
        public static bool XoaNhaCungCap(string _MaNCC)
        {
            return NhaCungCapDataAccess.XoaNhaCungCap(_MaNCC);
        }
    }//END CLASS
}

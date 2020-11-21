using System.Data;
using Public;
using System.Data.SqlClient;

namespace DataAccess
{
    public class NhaCungCapDataAccess
    {
        static ConnectionDataAccess conn = new ConnectionDataAccess();
        //DANH SÁCH NHÀ CUNG CẤP
        public static DataSet DsNhaCungCap()
        {
            string StoreprodureName = "DsNhaCungCap";
            return conn.GetDataSet(StoreprodureName);
        }

        //THÊM MỚI NHÀ CUNG CẤP
        public static bool ThemNhaCungCap(NhaCungCapPublic _ncc)
        {
            SqlCommand _cmd = new SqlCommand();
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.CommandText = "ThemNhaCungCap";
            _cmd.Parameters.AddWithValue("@MaNCC_NCC", _ncc.MaNCC_NCC);
            _cmd.Parameters.AddWithValue("@TenNCC_NCC", _ncc.TenNCC_NCC);
            _cmd.Parameters.AddWithValue("@GhiChu_NCC", _ncc.GhiChu_NCC);
            return conn.Execute(_cmd);
        }

        //SỬA THÔNG TIN NHÀ CUNG CẤP
        public static bool SuaNhaCungCap(NhaCungCapPublic _ncc)
        {
            SqlCommand _cmd = new SqlCommand();
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.CommandText = "SuaNhaCungCap";
            _cmd.Parameters.AddWithValue("@MaNCC_NCC", _ncc.MaNCC_NCC);
            _cmd.Parameters.AddWithValue("@TenNCC_NCC", _ncc.TenNCC_NCC);
            _cmd.Parameters.AddWithValue("@GhiChu_NCC", _ncc.GhiChu_NCC);
            return conn.Execute(_cmd);
        }

        //XÓA NHÀ CUNG CẤP
        public static bool XoaNhaCungCap(string _MaNCC)
        {
            if (UntilitiesDataAccess.CheckExist("tbl_SANPHAM", "MaNCC_SP", _MaNCC))
                return false;

            SqlCommand _cmd = new SqlCommand();
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.CommandText = "[Xóa nhà cung cấp]";
            _cmd.Parameters.AddWithValue("@MaNCC_NCC", _MaNCC);
            return conn.Execute(_cmd);
        }
    }//END CLASS
}

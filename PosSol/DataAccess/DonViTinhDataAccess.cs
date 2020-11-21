using System.Data;
using Public;
using System.Data.SqlClient;

namespace DataAccess
{
    public class DonViTinhDataAccess
    {
        static ConnectionDataAccess conn = new ConnectionDataAccess();

        //Danh sách đơn vị tính
        public static DataSet DanhSachDonViTinh()
        {
            DataSet ds = new DataSet();
            string StoreprodureName = "DsDonViTinh";
            return conn.GetDataSet(StoreprodureName);
        }

        //THÊM ĐƠN VỊ TÍNH
        public static bool ThemDonViTinh(DonViTinhPublic _dvt)
        {
            SqlCommand _cmd = new SqlCommand();
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.CommandText = "ThemDonViTinh";
            _cmd.Parameters.AddWithValue("@MaDVT_DVT", _dvt.MaDVT_DVT);
            _cmd.Parameters.AddWithValue("@TenDVT_DVT", _dvt.TenDVT_DVT);
            _cmd.Parameters.AddWithValue("@DangDung_DVT", _dvt.DangDung_DVT == true ? "1" : "0");
            return conn.Execute(_cmd);
        }

        //SỬA ĐƠN VỊ TÍNH
        public static bool SuaDonViTinh(DonViTinhPublic _dvt)
        {
            SqlCommand _cmd = new SqlCommand();
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.CommandText = "SuaDonViTinh";
            _cmd.Parameters.AddWithValue("@MaDVT_DVT", _dvt.MaDVT_DVT);
            _cmd.Parameters.AddWithValue("@TenDVT_DVT", _dvt.TenDVT_DVT);
            _cmd.Parameters.AddWithValue("@DangDung_DVT", _dvt.DangDung_DVT == true ? "1" : "0");
            return conn.Execute(_cmd);
        }

        //XÓA ĐƠN VỊ TÍNH
        public static bool XoaDonViTinh(string _MaDVT)
        {
            if (UntilitiesDataAccess.CheckExist("tbl_SANPHAM", "MaDVT_SP", _MaDVT))
                return false;

            SqlCommand _cmd = new SqlCommand();
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.CommandText = "[Xóa đơn vị tính]";
            _cmd.Parameters.AddWithValue("@MaDVT_DVT", _MaDVT);
            return conn.Execute(_cmd);
        }
    }//End class
}

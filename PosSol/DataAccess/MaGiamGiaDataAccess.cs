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
    public class MaGiamGiaDataAccess
    {
        static ConnectionDataAccess conn = new ConnectionDataAccess();

        //Danh sách mã giảm giá
        public static DataTable DsMaGiamGia()
        {
            return conn.GetDataSet("[Lấy danh sách mã giảm giá]").Tables[0];
        }

        //THêm mới mã giảm giá
        public static void TaoMaGiamGia(int _chietKhau, DateTime _ngayHetHan, int _soLuong)
        {
            MaGiamGiaPublic _maGiamGia = new MaGiamGiaPublic();
            _maGiamGia.ChietKhau_MGG = _chietKhau;
            _maGiamGia.NgayHetHan_MGG = _ngayHetHan;
            _maGiamGia.GhiChu_MGG = "Chưa sử dụng";
            _maGiamGia.TrangThai_MGG = true;

            for (int i = 0; i < _soLuong; i++)
            {
                bool t = true;
                while (t)
                {
                    _maGiamGia.MaThe_MGG = RandomNumber(100000000, 999999999).ToString();
                    if (!UntilitiesDataAccess.CheckExist("tbl_MAGIAMGIA", "MaGG_MGG", _maGiamGia.MaThe_MGG))
                        t = false;
                }
                Them1MaGiamGia(_maGiamGia);
            }
        }


        //Xóa mã giảm giá
        public static bool XoaMaGiamGia(string _MaGiaGia)
        {
            SqlCommand _cmd = new SqlCommand();
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.CommandText = "[Xóa mã giảm giá]";
            _cmd.Parameters.AddWithValue("@MaGG_MGG", _MaGiaGia);

            return conn.Execute(_cmd);

        }

        static private int RandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }
        static private string RandomString(int size, bool lowerCase)
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }
            if (lowerCase)
                return builder.ToString().ToLower();
            return builder.ToString();
        }

        private static bool Them1MaGiamGia(MaGiamGiaPublic _maGiamGia)
        {
            DateTime _dtNgayHetHan = new DateTime(_maGiamGia.NgayHetHan_MGG.Year, _maGiamGia.NgayHetHan_MGG.Month, _maGiamGia.NgayHetHan_MGG.Day, 23, 59, 59);

            SqlCommand _cmd = new SqlCommand();
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.CommandText = "[Thêm mã giảm giá]";
            _cmd.Parameters.AddWithValue("@MaGG_MGG", _maGiamGia.MaThe_MGG);
            _cmd.Parameters.AddWithValue("@ChietKhau_MGG", _maGiamGia.ChietKhau_MGG);
            _cmd.Parameters.AddWithValue("@NgayHetHan_MGG", _dtNgayHetHan);
            _cmd.Parameters.AddWithValue("@TrangThai_MGG", _maGiamGia.TrangThai_MGG);
            _cmd.Parameters.AddWithValue("@GhiChu_MGG", _maGiamGia.GhiChu_MGG);

            return conn.Execute(_cmd);
        }
    }//End class
}

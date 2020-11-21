using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Public;
using System.Data;
using System.IO;
using System.Data.SqlClient;

namespace DataAccess
{
    public class NhomKhachHangDataAccess
    {
        static ConnectionDataAccess conn = new ConnectionDataAccess();

        //Danh sách nhóm khách hàng
        public static DataSet DsNhomKhachHang()
        {
            string _Storeprodurename = "[Lấy ds nhóm khách hàng]";
            return conn.GetDataSet(_Storeprodurename);
        }

        //Lấy danh sách ảnh
        public static List<AnhNhomKhachhang> LayAnhNKH()
        {
            List<AnhNhomKhachhang> _ListAnhNKH = new List<AnhNhomKhachhang>();
            AnhNhomKhachhang _AnhNKH;
            string[] _DuongDan = Directory.GetFiles("../../Image/NhomKhachHang/");
            foreach (string _TenAnh in _DuongDan)
            {
                if (_TenAnh.IndexOf(".jpg") > -1 || _TenAnh.IndexOf(".png") > -1)
                {
                    _AnhNKH = new AnhNhomKhachhang();
                    _AnhNKH.DuongDanAnh = System.IO.Path.GetFullPath(_TenAnh);
                    _AnhNKH.TenAnh = System.IO.Path.GetFileName(_TenAnh);
                    _ListAnhNKH.Add(_AnhNKH);
                }

            }
            return _ListAnhNKH;
        }

        //Thêm nhóm khách hàng
        public static bool ThemNhomKhachHang(NhomKhachHangPublic _nkh)
        {
            SqlCommand _cmd = new SqlCommand();
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.CommandText = "[Thêm nhóm khách hàng]";
            _cmd.Parameters.AddWithValue("@MaNKH_NKH", _nkh.MaNKH_NKH);
            _cmd.Parameters.AddWithValue("@TenNKH_NKH", _nkh.TenNKH_NKH);
            _cmd.Parameters.AddWithValue("@ChietKhau_NKH", _nkh.ChietKhau_NKH);
            _cmd.Parameters.AddWithValue("@Diem_NKH", _nkh.Diem_NKH);
            _cmd.Parameters.AddWithValue("@Anh_NKH", _nkh.Anh_NKH);
            _cmd.Parameters.AddWithValue("@DangDung_NKH", _nkh.DangDung_NKH);
            return conn.Execute(_cmd);
        }

        //Sửa thông tin nhóm khách hàng
        public static bool SuaNhomKhachHang(NhomKhachHangPublic _nkh)
        {
            SqlCommand _cmd = new SqlCommand();
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.CommandText = "[Sửa nhóm khách hàng]";
            _cmd.Parameters.AddWithValue("@MaNKH_NKH", _nkh.MaNKH_NKH);
            _cmd.Parameters.AddWithValue("@TenNKH_NKH", _nkh.TenNKH_NKH);
            _cmd.Parameters.AddWithValue("@ChietKhau_NKH", _nkh.ChietKhau_NKH);
            _cmd.Parameters.AddWithValue("@Diem_NKH", _nkh.Diem_NKH);
            _cmd.Parameters.AddWithValue("@Anh_NKH", _nkh.Anh_NKH);
            _cmd.Parameters.AddWithValue("@DangDung_NKH", _nkh.DangDung_NKH);
            return conn.Execute(_cmd);
        }

        //Xóa nhóm khách hàng
        public static bool XoaNhomKhachHang(string _MaNKH)
        {
            if (UntilitiesDataAccess.CheckExist("tbl_KHACHHANG", "Ma_NHK_KH", _MaNKH))
                return false;

            SqlCommand _cmd = new SqlCommand();
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.CommandText = "[Xóa nhóm khách hàng]";
            _cmd.Parameters.AddWithValue("@MaNKH_NKH", _MaNKH);
            return conn.Execute(_cmd);
        }

    }//end class
    public class AnhNhomKhachhang
    {
        private string _DuongDanAnh;
        public string DuongDanAnh
        {
            get { return _DuongDanAnh; }
            set { _DuongDanAnh = value; }
        }


        private string _TenAnh;
        public string TenAnh
        {
            get { return _TenAnh; }
            set { _TenAnh = value; }
        }
    }
}

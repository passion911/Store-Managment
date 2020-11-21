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
    public class NhomSanPhamDataAccess
    {
        static ConnectionDataAccess conn = new ConnectionDataAccess();

        //Trả về danh sách nhóm sản phẩm
        public static DataSet DanhSachNhomSanPham()
        {
            string storeProdureName = "DsNhomSanPham";
            return conn.GetDataSet(storeProdureName);
        }//end DanhSachNhomSanPham

        //Thêm mới một nhóm sản phẩm
        public static bool ThemNhomSanPham(NhomSanPhamPublic nhomsanpham)
        {
            //ConnectionDataAccess conn = new ConnectionDataAccess();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ThemNhomSanPham";
            cmd.Parameters.AddWithValue("@MaNSP_NSP", nhomsanpham.MaNSP_NSP);
            cmd.Parameters.AddWithValue("@TenNSP_NSP", nhomsanpham.TenNSP_NSP);
            cmd.Parameters.AddWithValue("@DangDung_NSP", nhomsanpham.DangDung_NSP == true ? "1" : "0");
            cmd.Parameters.AddWithValue("@GhiChu_NSP", nhomsanpham.GhiChu_NSP);
            return conn.Execute(cmd);
        }

        //Xóa một nhóm sản phẩm
        public static bool XoaNhomSanPham(string Ma_NSP)
        {
            // ConnectionDataAccess conn = new ConnectionDataAccess();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "XoaNhomSanPham";
            cmd.Parameters.AddWithValue("@MaNSP_NSP", Ma_NSP);
            return conn.Execute(cmd);
        }

        //Cập nhật thông tin nhóm sản phẩm
        public static bool CapNhatSanPham(NhomSanPhamPublic nhomsanpham)
        {
            //ConnectionDataAccess conn = new ConnectionDataAccess();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "CapNhatNhomSanPham";
            cmd.Parameters.AddWithValue("@MaNSP_NSP", nhomsanpham.MaNSP_NSP);
            cmd.Parameters.AddWithValue("@TenNSP_NSP", nhomsanpham.TenNSP_NSP);
            cmd.Parameters.AddWithValue("@DangDung_NSP", (nhomsanpham.DangDung_NSP == true) ? "1" : "0");
            cmd.Parameters.AddWithValue("@GhiChu_NSP", nhomsanpham.GhiChu_NSP);
            return conn.Execute(cmd);
        }

        //Sinh mã theo tên nhập vào
        public static string AutoGenerateIDinInputString(DataTable _dt, string _strIn)
        {
            int _length = 4;//độ dài

            _strIn = UntilitiesDataAccess.RemoveSign4VietnameseString(_strIn.Trim());
            string _strOut = "";

            string[] _strSplit = _strIn.Split(' ');
            if (_strSplit.Length == 1)
            {
                _strOut = _strIn.ToUpper();

                //Nếu độ dài vượt quá thì cắt
                if (_strOut.Length > 4)
                    _strOut = _strOut.Remove(_length);

                //Kiểm tra trong csdl
                int i = 1;
                while (CheckExistWithDatatable(_dt, "MaNSP_NSP", _strOut + ((i == 1) ? "" : i.ToString())))
                    i++;
                _strOut = _strOut + ((i == 1) ? "" : i.ToString());
            }
            else
            {
                //Lấy kí tự đầu mỗi từ
                foreach (string _str in _strSplit)
                    _strOut = _strOut + _str[0];

                //Nếu độ dài vượt quá thì cắt
                if (_strOut.Length > 4)
                    _strOut = _strOut.Remove(_length);

                //Kiểm tra trong csdl
                int i = 1;
                while (CheckExistWithDatatable(_dt, "MaNSP_NSP", _strOut + ((i == 1) ? "" : i.ToString())))
                    i++;
                _strOut = _strOut + ((i == 1) ? "" : i.ToString());
            }
            return _strOut.ToUpper();
        }
        //Check Exist with datatable
        static bool CheckExistWithDatatable(DataTable _dt, string _columnName, string _Value)
        {
            DataView _dv = new DataView(_dt);
            _dv.Sort = _columnName;
            int _index = _dv.Find(_Value);
            if (_index != -1)
                return true;
            return false;
        }
    }//end class
}

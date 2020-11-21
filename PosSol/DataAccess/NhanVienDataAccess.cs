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
    public class NhanVienDataAccess
    {
        static ConnectionDataAccess conn = new ConnectionDataAccess();

        // DANH SÁCH NHÂN VIÊN
        public static DataSet DsNhanVien()
        {
            string Storeprodure = "DsNhanVien";
            return conn.GetDataSet(Storeprodure);
        }

        //Create staff
        public static bool ThemNhanVien(NhanVienPublic _nv)
        {
            SqlCommand _cmd = new SqlCommand();
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.CommandText = "[Thêm nhân viên]";
            _cmd.Parameters.AddWithValue("@MaNV_NV", _nv.MaNV_NV);
            _cmd.Parameters.AddWithValue("@HoTen_NV", _nv.HoTen_NV);
            _cmd.Parameters.AddWithValue("@NgaySinh_NV", _nv.NgaySinh_NV);
            _cmd.Parameters.AddWithValue("@GioiTinh_NV", _nv.GioiTinh_NV);
            _cmd.Parameters.AddWithValue("@DiaChi_NV", _nv.DiaChi_NV);
            _cmd.Parameters.AddWithValue("@SDT_NV", _nv.SDT_NV);
            _cmd.Parameters.AddWithValue("@Anh_NV", _nv.Anh_NV);
            _cmd.Parameters.AddWithValue("@MatKhau_NV", _nv.MatKhau_NV);
            _cmd.Parameters.AddWithValue("@ID_Q", _nv.ID_Q);
            _cmd.Parameters.AddWithValue("@DangDung_NV", _nv.DangDung_NV);

            return conn.Execute(_cmd);
        }

        //Update staff
        public static bool UpdateStaff(NhanVienPublic _staff)
        {
            SqlCommand _cmd = new SqlCommand();
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.CommandText = "[Update Nhân viên]";
            _cmd.Parameters.AddWithValue("@MaNV_NV", _staff.MaNV_NV);
            _cmd.Parameters.AddWithValue("@HoTen_NV", _staff.HoTen_NV);
            _cmd.Parameters.AddWithValue("@NgaySinh_NV", _staff.NgaySinh_NV);
            _cmd.Parameters.AddWithValue("@GioiTinh_NV", _staff.GioiTinh_NV);
            _cmd.Parameters.AddWithValue("@DiaChi_NV", _staff.DiaChi_NV);
            _cmd.Parameters.AddWithValue("@SDT_NV", _staff.SDT_NV);
            _cmd.Parameters.AddWithValue("@Anh_NV", _staff.Anh_NV);
            _cmd.Parameters.AddWithValue("@ID_Q", _staff.ID_Q);
            _cmd.Parameters.AddWithValue("@DangDung_NV", _staff.DangDung_NV);

            return conn.Execute(_cmd);
        }

        //Delete Staff
        public static bool DeleteStaff(string _MaNV)
        {
            //Check esxit
            if (UntilitiesDataAccess.CheckExist("tbl_HOADON", "NguoiLap_HD", _MaNV))
                return false;

            if (UntilitiesDataAccess.CheckExist("tbl_LICHSUBANHANG", "NhanVienThucHien_LSBH", _MaNV))
                return false;

            if (UntilitiesDataAccess.CheckExist("tbl_PHIEUNHAP", "NguoiNhap_PN", _MaNV))
                return false;

            SqlCommand _cmd = new SqlCommand();
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.CommandText = "[Xóa nhân viên]";
            _cmd.Parameters.AddWithValue("@MaNV_NV", _MaNV);

            return conn.Execute(_cmd);
        }

        //Lấy thông tin 1 nhân viên
        public static NhanVienPublic Lay1NhanVien(string _maNV)
        {
            NhanVienPublic _nv = new NhanVienPublic();
            SqlCommand _cmd = new SqlCommand();
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.CommandText = "[Lấy 1 nhân viên]";
            _cmd.Parameters.AddWithValue("@MaNV_NV", _maNV);

            DataTable _dtnv = conn.GetDataSet2(_cmd).Tables[0];

            if (_dtnv.Rows.Count > 0)
            {
                _nv.MaNV_NV = _dtnv.Rows[0]["MaNV_NV"].ToString();
                _nv.HoTen_NV = _dtnv.Rows[0]["HoTen_NV"].ToString();
                _nv.NgaySinh_NV = Convert.ToDateTime(_dtnv.Rows[0]["NgaySinh_NV"].ToString());
                _nv.GioiTinh_NV = _dtnv.Rows[0]["GioiTinh_NV"].ToString();
                _nv.DiaChi_NV = _dtnv.Rows[0]["DiaChi_NV"].ToString();
                _nv.SDT_NV = _dtnv.Rows[0]["SDT_NV"].ToString();
                _nv.NgayTao_NV = Convert.ToDateTime(_dtnv.Rows[0]["NgayTao_NV"].ToString());
                _nv.Anh_NV = _dtnv.Rows[0]["Anh_NV"].ToString();
                _nv.MatKhau_NV = _dtnv.Rows[0]["MatKhau_NV"].ToString();
                _nv.ID_Q = _dtnv.Rows[0]["ID_Q"].ToString();
                _nv.DangDung_NV = (bool)_dtnv.Rows[0]["DangDung_NV"];
            }
                
            return _nv;
        }
    }//END ClASS
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Public;

namespace DataAccess
{
    public class DangNhapDataAccess
    {
        static ConnectionDataAccess conn = new ConnectionDataAccess();

        //Đăng nhập
        public static DataSet DangNhap(string _MaNV, string _MatKhau)
        {
            SqlCommand _cmd = new SqlCommand();
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.CommandText = "[GetUserLoginAccount]";
            _cmd.Parameters.AddWithValue("@EmpCode", _MaNV);
            _cmd.Parameters.AddWithValue("@Password_Emp", _MatKhau);

            return conn.GetDataSet2(_cmd);
        }

        //Lấy quyền
        public static bool HienThiQuyen(List<QuyenChucNangPublic> _lstQcn, string _IDChucNang)
        {
            bool t = false;
            QuyenChucNangPublic _qcn = _lstQcn.Find(item => item.ChucNang.ID_CN == _IDChucNang);
            if (_qcn != null && ThietLapHeThongDataAccess.CheckLastDate())
                return t = _qcn.DuocSuDung_QCN;
            return t;
        }

        //Đổi mật khẩu
        public static bool DoiMatKhau(string _MaNV, string _matKhauMoi)
        {
            SqlCommand _cmd = new SqlCommand();
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.CommandText = "[Đổi mật khẩu]";
            _cmd.Parameters.AddWithValue("@MaNV_NV", _MaNV);
            _cmd.Parameters.AddWithValue("@MatKhau_NV", _matKhauMoi);
            return conn.Execute(_cmd);
        }

    }//End class
}

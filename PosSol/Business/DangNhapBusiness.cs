using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DataAccess;
using Public;

namespace Business
{
    public class DangNhapBusiness
    {
        //Đăng nhập
        public static DataSet DangNhap(string _MaNV, string _MatKhau)
        {
            return DangNhapDataAccess.DangNhap(_MaNV, _MatKhau);
        }

        //Lấy quyền
        public static bool HienThiQuyen(List<QuyenChucNangPublic> _lstQcn, string _IDChucNang)
        {
            return DangNhapDataAccess.HienThiQuyen(_lstQcn, _IDChucNang);
        }

        //Đổi mật khẩu
        public static bool DoiMatKhau(string maNv, string matKhauMoi)
        {
            return DangNhapDataAccess.DoiMatKhau(maNv, matKhauMoi);
        }

    }//End class
}

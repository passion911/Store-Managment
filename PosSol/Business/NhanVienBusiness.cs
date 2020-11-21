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
    public class NhanVienBusiness
    {
        //DANH SÁCH NHÂN VIÊN
        public static DataSet DsNhanVien()
        {
            return NhanVienDataAccess.DsNhanVien();
        }

        //Create staff
        public static bool ThemNhanVien(NhanVienPublic _nv)
        {
            return NhanVienDataAccess.ThemNhanVien(_nv);
        }

        //Update staff
        public static bool UpdateStaff(NhanVienPublic _staff)
        {
            return NhanVienDataAccess.UpdateStaff(_staff);
        }

        //Delete Staff
        public static bool DeleteStaff(string _MaNV)
        {
            return NhanVienDataAccess.DeleteStaff(_MaNV);
        }

        //Lấy thông tin 1 nhân viên
        public static NhanVienPublic Lay1NhanVien(string _maNV)
        {
            return NhanVienDataAccess.Lay1NhanVien(_maNV);
        }
    }//END CLASS
}

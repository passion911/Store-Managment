using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using Public;
namespace Business
{
    public class PhanQuyenBusiness
    {
        //Lấy danh sách quyền
        public static List<QuyenPublic> DanhSachQuyen()
        {
            return PhanQuyenDataAccess.DanhSachQuyen();
        }

        //Lấy Quyền chức năng theo Quyền
        public static List<QuyenChucNangPublic> LayQuyenChucNangTheoQuyen(string _IDQuyen)
        {
            return PhanQuyenDataAccess.LayQuyenChucNangTheoQuyen(_IDQuyen);
        }

        //Thêm quyền(Thêm cả quyền và quyền chức năng)
        public static void ThemQuyen(QuyenPublic _quyen)
        {
            PhanQuyenDataAccess.ThemQuyen(_quyen);
        }

        //Cập nhật quyền
        public static void CapNhatQuyenChucNang(List<QuyenChucNangPublic> _QuyenChucNang)
        {
            PhanQuyenDataAccess.CapNhatQuyenChucNang(_QuyenChucNang);
        }

        //Xóa quyền
        public static bool XoaQuyen(string _ID_Q)
        {
            return PhanQuyenDataAccess.XoaQuyen(_ID_Q);
        }
    }//End class
}

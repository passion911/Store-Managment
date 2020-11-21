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
    public class NhomSanPhamBusiness
    {
        //Danh sách nhóm sản phẩm
        public static DataSet DanhSachNhomSanPham()
        {
            return NhomSanPhamDataAccess.DanhSachNhomSanPham();
        }

        //Thêm mới một nhóm sản phẩm
        public static bool ThemNhomSanPham(NhomSanPhamPublic nhomsanpham)
        {
            return NhomSanPhamDataAccess.ThemNhomSanPham(nhomsanpham);
        }

        //Xóa một nhóm sản phẩm
        public static bool XoaNhomSanPham(string Ma_NSP)
        {
            return NhomSanPhamDataAccess.XoaNhomSanPham(Ma_NSP);
        }

        //Cập nhật nhóm sản phẩm
        public static bool CapNhatNhomSanPham(NhomSanPhamPublic nhomsanpham)
        {
            return NhomSanPhamDataAccess.CapNhatSanPham(nhomsanpham);
        }

        //Tự sinh mã theo tên nhập vào
        public static string AutoGenerateIDinInputString(DataTable _dt, string _strIn)
        {
            return NhomSanPhamDataAccess.AutoGenerateIDinInputString(_dt, _strIn);
        }
    }//end class
}

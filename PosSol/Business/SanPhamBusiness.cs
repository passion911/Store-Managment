using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DataAccess;
using Public;
using DataAccessd;

namespace Business
{
    public class SanPhamBusiness
    {
        //Danh sách sản phẩm
        public static DataSet DsSanPham()
        {
            return SanPhamDataAccess.DsSanPham();
        }

        //Thêm mới sản phẩm
        public static bool ThemSanPham(SanPhamPublic _sp)
        {
            return SanPhamDataAccess.ThemSanPham(_sp);
        }

        //Lấy nhóm sản phẩm cbo
        public static List<NhomSanPhamPublic> LayNSP()
        {
            return SanPhamDataAccess.LayNSP();
        }

        //Lấy nhóm sản phẩm 2
        public static List<NhomSanPhamPublic> LayNSP2()
        {
            return SanPhamDataAccess.LayNSP2();
        }

        //Xóa sản phẩm
        public static bool XoaSanPham(string _MaSP)
        {
            return SanPhamDataAccess.XoaSanPham(_MaSP);
        }

        //Lấy đơn vị tính cbo
        public static List<DonViTinhPublic> LayDVT()
        {
            return SanPhamDataAccess.LayDVT();
        }

        //Lấy nhà cung cấp
        public static List<NhaCungCapPublic> LayNCC()
        {
            return SanPhamDataAccess.LayNCC();
        }

        //Sửa thông tin sản phẩm
        public static bool SuaSanPham(SanPhamPublic _sp)
        {
            return SanPhamDataAccess.SuaSanPham(_sp);
        }

        //Import data to Datatable
        public static DataTable ImportToDatatable(string _path)
        {
            return SanPhamDataAccess.ImportToDatatable(_path);
        }

        public static void XuatExcel(DataTable _dt, string _Ten)
        {
            SanPhamDataAccess.XuatExcel(_dt, _Ten);
        }

        //Sửa giá bán lẻ theo nhóm sản phẩm
        public static bool SuaGiaTheoNhom(string _MaNSP, string _GiaBan)
        {
            return SanPhamDataAccess.SuaGiaTheoNhom(_MaNSP, _GiaBan);
        }
    }//End class
}

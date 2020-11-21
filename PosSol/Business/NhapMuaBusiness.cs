using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Public;
using DataAccess;
using System.Data;

namespace Business
{
    public class NhapMuaBusiness
    {
        //Ds sản phẩm
        public static DataSet DsSanPham()
        {
            return NhapMuaDataAccess.DsSanPham();
        }

        //Lấy danh sách nhóm sản phẩm - cbo
        public static List<NhomSanPhamPublic> ListNSP()
        {
            return NhapMuaDataAccess.ListNSP();
        }

        //Nhập Hàng 
        public static void NhapHang(PhieuNhapPublic _phieunhap, List<SanPhamPublic> _ListSPNhap)
        {
            NhapMuaDataAccess.NhapHang(_phieunhap, _ListSPNhap);
        }


        //Lấy danh sách hàng nhập theo phiếu nhập
        public static DataTable LayHangNhap(string _soPhieu)
        {
            return NhapMuaDataAccess.LayHangNhap(_soPhieu);
        }
    }//End class
}

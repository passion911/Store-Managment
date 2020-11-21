using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using Public;

namespace Business
{
    public class KiemKeBusiness
    {
        //Lấy nhóm sản phẩm cbo
        public static List<NhomSanPhamPublic> LayNSP()
        {
            return KiemKeDataAccess.LayNSP();
        }

        //Lấy sản phẩm theo mã
        public static List<SanPhamPublic> LaySPTheoNhom(string _maNSP)
        {
            return KiemKeDataAccess.LaySPTheoNhom(_maNSP);
        }

        //Cập nhật số lượng
        public static bool CapNhatSoLuong(string _MaSP, int _SoLuong)
        {
            return KiemKeDataAccess.CapNhatSoLuong(_MaSP, _SoLuong);
        }
    }//End class
}

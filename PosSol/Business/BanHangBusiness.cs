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
    public class BanHangBusiness
    {

        //Lấy danh sách sản phẩm
        public static DataSet DsSanPham()
        {
            return BanHangDataAccess.DsSanPham();
        }

        //Lấy sản phẩm theo mã
        public static DataSet LaySpTheoMa(string _MaSp)
        {
            return BanHangDataAccess.LaySpTheoMa(_MaSp);
        }

        //Lấy khách hàng theo mã
        public static DataSet LayKhTheoMa(string _MaKh)
        {
            return BanHangDataAccess.LayKhTheoMa(_MaKh);
        }

        //Lấy nhóm khách hàng theo mã
        public static DataSet LayNKHTheoMa(string _MaNKH)
        {
            return BanHangDataAccess.LayNKHTheoMa(_MaNKH);
        }

        //Lấy danh sách kho
        public static List<KhoPublic> LayDSKho()
        {
            return BanHangDataAccess.LayDSKho();
        }

        //Lấy hàng mua
        public static HangMuaPubLic LayHangMua(string MaSP_SP, bool _KieuBan, int _SoLuong)
        {
            return BanHangDataAccess.LayHangMua(MaSP_SP, _KieuBan, _SoLuong);
        }

        //Bán hàng
        public static void BanHang(HoaDonPublic _hoaDon, List<SanPhamPublic> _gioHang, bool _truSoLuong)
        {
            BanHangDataAccess.BanHang(_hoaDon, _gioHang, _truSoLuong);
        }

        //Lấy mã giảm giá the mã
        public static DataSet LayMaGiamGiaTheoMa(string _MaGG)
        {
            return BanHangDataAccess.LayMaGiamGiaTheoMa(_MaGG);
        }
    }//End Class
}

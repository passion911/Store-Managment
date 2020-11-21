using System.Collections.Generic;
using Public;
using DataAccess;
using System.Data;

namespace Business
{
    public class TraHangBusiness
    {
        //Lấy danh sách hàng mua
        public static List<HangMuaPubLic> LayDsHangMua(string _soHD)
        {
            return TraHangDataAccess.LayDsHangMua(_soHD);
        }

        //Lấy khách hàng theo mã
        public static KhachHangPublic LayKhachHang(string _maKH)
        {
            return TraHangDataAccess.LayKhachHang(_maKH);
        }

        //Lấy tiền mã giảm giá
        public static int LayCKMaGiamGia(string _MaGiamGia)
        {
            return TraHangDataAccess.LayCKMaGiamGia(_MaGiamGia);
        }

        //Nhập sản phẩm vào kho
        public static bool NhapSPVaoKho(string _maSp, int _soLuong, string _ghiChu)
        {
            return TraHangDataAccess.NhapSPVaoKho(_maSp, _soLuong, _ghiChu);
        }

        //Hủy hóa đơn
        public static void HuyHoaDon(HoaDonPublic _hoaDon)
        {
            TraHangDataAccess.HuyHoaDon(_hoaDon);
        }

        //Lấy hóa đơn theo số hóa đơn - chưa dùng
        public static HoaDonPublic LayHoaDon(string _soHD)
        {
            return TraHangDataAccess.LayHoaDon(_soHD);
        }

        //Danh sách hóa đơn
        public static DataTable DanhSachHoaDon()
        {
            return TraHangDataAccess.DanhSachHoaDon();
        }
    }//End class
}

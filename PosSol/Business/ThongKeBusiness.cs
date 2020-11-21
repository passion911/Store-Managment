using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Public;
using DataAccess;

namespace Business
{
    public class ThongKeBusiness
    {
        //Tính tiền cho một hóa đơn
        public static HoaDonPublic TinhTien1HoaDon(string _soHD)
        {
            return ThongKeDataAccess.TinhTien1HoaDon(_soHD);
        }

        //Lấy danh sách hàng mua
        public static List<HangMuaPubLic> LayHangMua(string _soHD)
        {
            return ThongKeDataAccess.LayHangMua(_soHD);
        }

        //THỐNG KÊ THEO SẢN PHẨM
        public static List<ThongKeTheoSanPham> ThongKeTheoSanPham(string _MaNhomSP, DateTime _dtTuNgay, DateTime _dtDenNgay)
        {
            return ThongKeDataAccess.ThongKeTheoSanPham(_MaNhomSP, _dtTuNgay, _dtDenNgay);
        }

        //THỐNG KÊ THEO HÓA ĐƠN
        public static List<ThongKeTheoHoaDonPublic> ThongKeTheoHoaDon(DateTime _dtTuNgay, DateTime _dtDenNgay)
        {
            return ThongKeDataAccess.ThongKeTheoHoaDon(_dtTuNgay, _dtDenNgay);
        }

        //THỐNG KÊ THEO NHÂN VIÊN
        public static List<ThongKeTheoNhanVienPublic> ThongKeTheoNhanVien(DateTime _dtTuNgay, DateTime _dtDenNgay)
        {
            return ThongKeDataAccess.ThongKeTheoNhanVien(_dtTuNgay, _dtDenNgay);
        }

        //THỐNG KÊ THEO NHÂN VIÊN CHI TIẾT
        public static List<ThongKeTheoHoaDonPublic> ThongKeTheoNhanVienChiTiet(string _MaNV, DateTime _dtTuNgay, DateTime _dtDenNgay)
        {
            return ThongKeDataAccess.ThongKeTheoNhanVienChiTiet(_MaNV, _dtTuNgay, _dtDenNgay);
        }

        //PHIẾU NHẬP
        public static List<PhieuNhapPublic> LayPhieuNhapTheoNgay(DateTime _dtTuNgay, DateTime _dtDenNgay)
        {
            return ThongKeDataAccess.LayPhieuNhapTheoNgay(_dtTuNgay, _dtDenNgay);
        }

        //LẤY DANH SÁCH THÁNG TRONG NĂM
        public static List<Thang> DsThang()
        {
            return ThongKeDataAccess.DsThang();
        }
    }//End 
}

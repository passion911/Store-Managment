using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using System.Data;

namespace Business
{
    public class MaGiamGiaBusiness
    {
        //Danh sách mã giảm giá
        public static DataTable DsMaGiamGia()
        {
            return MaGiamGiaDataAccess.DsMaGiamGia();
        }

        //THêm mới mã giảm giá
        public static void TaoMaGiamGia(int _chietKhau, DateTime _ngayHetHan, int _soLuong)
        {
            MaGiamGiaDataAccess.TaoMaGiamGia(_chietKhau, _ngayHetHan, _soLuong);
        }

        //Xóa mã giảm giá
        public static bool XoaMaGiamGia(string _MaGiaGia)
        {
            return MaGiamGiaDataAccess.XoaMaGiamGia(_MaGiaGia);
        }
    }//End class
}

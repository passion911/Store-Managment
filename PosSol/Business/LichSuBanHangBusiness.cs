using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using Public;
using System.Data;

namespace Business
{
    public class LichSuBanHangBusiness
    {
        //Thêm lịch sử bán hàng
        public static bool ThemLichSuBanHang(LichSuBanHangPublic _lsbh)
        {
            return LichSuBanHangDataAccess.ThemLichSuBanHang(_lsbh);
        }

        //Lấy lịch sử bán hàng
        public static DataSet LayLichSuBanHang()
        {
            return LichSuBanHangDataAccess.LayLichSuBanHang();
        }

        //Lấy lịch sử bán hàng theo ngày
        public static List<LichSuBanHangPublic> LayLSBHTheoNgay(DateTime _tuNgay, DateTime _denNgay)
        {
            return LichSuBanHangDataAccess.LayLSBHTheoNgay(_tuNgay, _denNgay);
        }
    }//End class
}

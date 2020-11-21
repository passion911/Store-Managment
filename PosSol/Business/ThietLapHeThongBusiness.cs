using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using Public;

namespace Business
{
    public class ThietLapHeThongBusiness
    {
        public static ThietLapHeThongPublic LayThietLapHeThong()
        {
            return ThietLapHeThongDataAccess.LayThietLapHeThong();
        }

        //Cập nhật thiết lập hệ thống
        public static void CapNhatThietLapHeThong(ThietLapHeThongPublic _thietLap)
        {
            ThietLapHeThongDataAccess.CapNhatThietLapHeThong(_thietLap);
        }
    }//End class
}

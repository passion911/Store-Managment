using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using System.Data;
namespace Business
{
    public class TaoMaVachSPBusiness
    {
        //Danh sách sản phẩm
        public static DataSet DsSanPham()
        {
            return TaoMaVachSPDataAccess.DsSanPham();
        }
    }//End class
}

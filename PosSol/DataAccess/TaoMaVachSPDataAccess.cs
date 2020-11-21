using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace DataAccess
{
    public class TaoMaVachSPDataAccess
    {
        static ConnectionDataAccess conn = new ConnectionDataAccess();
        //Danh sách sản phẩm
        public static DataSet DsSanPham()
        {
            string StoreprocedureName = "[Danh sách sản phẩm]";
            return conn.GetDataSet(StoreprocedureName);
        }

    }//End class
}

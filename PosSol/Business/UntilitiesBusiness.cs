using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using System.Data;

namespace Business
{
    public class UntilitiesBusiness
    {
        //Kiểm tra tồn tại
        public static bool CheckEist(string TableName, string ColumnName, string Value)
        {
            return UntilitiesDataAccess.CheckExist(TableName, ColumnName, Value);
        }

        //Lấy dữ liệu từ excel--> table
        public static DataTable ImportToDatatable(string path)
        {
            return UntilitiesDataAccess.ImportToDatatable(path);
        }

        //THÊM DẤU PHẨY
        public static string ThemDauPhay(string str)
        {
            return UntilitiesDataAccess.ThemDauPhay(str);
        }

        //BỎ PHẨY
        public static string BoDauPhay(string str)
        {
            return UntilitiesDataAccess.BoDauPhay(str);
        }

        //GET Next ID
        public static string GetNextID(string _tableName, string _columnName, string _prefixID, int _length)
        {
            return UntilitiesDataAccess.GetNextID(_tableName, _columnName, _prefixID, _length);
        }

        //Xuất excel
        public static void XuatExcel(DataTable _dt, string _Ten)
        {
            UntilitiesDataAccess.XuatExcel(_dt, _Ten);
        }

        //Excel to datatable
        public static DataTable ExcelToDatatable(string _excelPath, string _strSql)
        {
            return UntilitiesDataAccess.ExcelToDatatable(_excelPath, _strSql);
        }

        //Mã hóa md5
        public static string MaHoaMD5(string text)
        {
            return UntilitiesDataAccess.MaHoaMD5(text);
        }

        //Chuyển số thành chữ
        public static string ChuyenSoThanhChu(string _number)
        {
            return UntilitiesDataAccess.ChuyenSoThanhChu(_number);
        }
    }//end class
}

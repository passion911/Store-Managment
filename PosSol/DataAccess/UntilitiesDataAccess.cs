using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using System.Data.SqlClient;
using System.Data;
using System.Data.OleDb;
using System.Windows;
using System.Security.Cryptography;

namespace DataAccess
{
    public class UntilitiesDataAccess
    {
        static ConnectionDataAccess conn = new ConnectionDataAccess();
        //Kiểm tra mã tồn tại
        public static bool CheckExist(string TableName, string ColumnName, string Value)
        {
            try
            {
                string str = "SELECT " + ColumnName + " FROM " + TableName + " WHERE " + ColumnName + " = '" + Value + "'";
                SqlDataAdapter adt = new SqlDataAdapter(str, conn.GetConn());
                DataTable dt = new DataTable();
                adt.Fill(dt);
                if (dt.Rows.Count > 0)
                    return true;
            }
            catch (Exception)
            {
                throw;
            }
            return false;
        }

        //Lấy dữ liệu từ excel
        public static DataTable ImportToDatatable(string path)
        {
            DataTable dt = new DataTable();

            //Lấy dữ liệu từ excel
            OleDbConnection OleDbcon = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + ";Extended Properties=Excel 12.0;");
            OleDbCommand cmd = new OleDbCommand("SELECT [Mã nhóm] as MANHOM,[Tên nhóm] as TENNHOM,[Ghi chú] as GHICHU FROM [Sheet1$]", OleDbcon);
            OleDbDataAdapter objAdapter = new OleDbDataAdapter(cmd);

            DataSet ds = new DataSet();
            objAdapter.Fill(ds);
            dt = ds.Tables[0];

            return dt;
        }

        //Excel to datatable
        public static DataTable ExcelToDatatable(string _excelPath, string _strSql)
        {
            DataTable _dtExcel = new DataTable();

            //Lấy dữ liệu từ file excel
            try
            {
                OleDbConnection _OleDbcon = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + _excelPath + ";Extended Properties=Excel 12.0;");
                OleDbCommand _cmd = new OleDbCommand(_strSql, _OleDbcon);
                OleDbDataAdapter _objAdapter = new OleDbDataAdapter(_cmd);

                _objAdapter.Fill(_dtExcel);
            }
            catch (Exception)
            {
                return _dtExcel;
            }

            return _dtExcel;
        }

        //TÁCH SỐ THÊM DẤU PHẨY TIỀN TỆ
        public static string ThemDauPhay(string str)
        {
            string _dauam = "";
            if (str.StartsWith("-"))
            {
                str = str.Substring(1);
                _dauam = "-";
            }

            string txt, txt1;
            txt1 = str.Replace(",", "");
            txt = "";
            int n = txt1.Length;
            int dem = 0;
            for (int i = n - 1; i >= 0; i--)
            {
                if (dem == 2 && i != 0)
                {
                    txt = "," + txt1.Substring(i, 1) + txt;
                    dem = 0;
                }
                else
                {
                    txt = txt1.Substring(i, 1) + txt;
                    dem += 1;
                }
            }
            str = txt;

            return str = _dauam + str;
        }

        //BỎ DẨU PHẨY
        public static string BoDauPhay(string str)
        {
            if (String.IsNullOrEmpty(str))
            {
                return str;
            }
            str = str.Replace(",", "");
            return str;
        }

        //LẤY ID TIẾP THEO (ÁP DỤNG VỚI MÃ CÓ ĐỘ DÀI CỐ ĐỊNH)
        public static string GetNextID(string _tableName, string _columnName, string _prefixID, int _length)
        {
            string _LastID;
            string _sqlstr = "SELECT TOP 1 " + _columnName + " FROM " + _tableName + "  ORDER BY " + _columnName + " DESC";
            SqlDataAdapter _adt = new SqlDataAdapter(_sqlstr, conn.GetConn());
            DataTable _dt = new DataTable();
            _adt.Fill(_dt);
            if (_dt.Rows.Count > 0)
                _LastID = _dt.Rows[0][_columnName].ToString();
            else
                _LastID = "";

            if (_LastID == "")
            {
                string _str = "";
                for (int i = 0; i < _length - 1; i++)
                {
                    _str = _str + "0";
                }
                _str = _str + "1";
                return _prefixID + _str;  // fixwidth default
            }

            int nextID = int.Parse(_LastID.Remove(0, _prefixID.Length)) + 1;
            int lengthNumerID = _LastID.Length - _prefixID.Length;
            string zeroNumber = "";
            for (int i = 1; i <= lengthNumerID; i++)
            {
                if (nextID < Math.Pow(10, i))
                {
                    for (int j = 1; j <= lengthNumerID - i; i++)
                    {
                        zeroNumber += "0";
                    }
                    return _prefixID + zeroNumber + nextID.ToString();
                }
            }
            return _prefixID + nextID;
        }

        //Xuất Excel
        public static void XuatExcel(DataTable _dt, string _Ten)
        {
            Microsoft.Office.Interop.Excel.Application _Excell = new Microsoft.Office.Interop.Excel.Application();
            _Excell.Application.Workbooks.Add(Type.Missing);

            //Thay đổi định dang cho file excel
            _Excell.Columns.ColumnWidth = 20;

            //Tạo dòng header
            for (int i = 1; i <= _dt.Columns.Count; i++)
            {
                _Excell.Cells[1, i] = _dt.Columns[i - 1].ColumnName;
            }

            for (int i = 0; i < _dt.Rows.Count; i++)
            {
                for (int j = 0; j < _dt.Columns.Count; j++)
                {
                    _Excell.Cells[i + 2, j + 1] = _dt.Rows[i][j].ToString();
                }
            }

            //Lưu
            _Excell.ActiveWorkbook.SaveCopyAs(_Ten);
            _Excell.ActiveWorkbook.Saved = true;
            _Excell.Quit();
        }

        //Chuyển số thành chữ
        public static string ChuyenSoThanhChu(string number)
        {
            string[] dv = { "", "mươi", "trăm", "nghìn", "triệu", "tỉ" };
            string[] cs = { "không", "một", "hai", "ba", "bốn", "năm", "sáu", "bảy", "tám", "chín" };
            string doc;
            int i, j, k, n, len, found, ddv, rd;

            len = number.Length;
            number += "ss";
            doc = "";
            found = 0;
            ddv = 0;
            rd = 0;

            i = 0;
            while (i < len)
            {
                //So chu so o hang dang duyet
                n = (len - i + 2) % 3 + 1;

                //Kiem tra so 0
                found = 0;
                for (j = 0; j < n; j++)
                {
                    if (number[i + j] != '0')
                    {
                        found = 1;
                        break;
                    }
                }

                //Duyet n chu so
                if (found == 1)
                {
                    rd = 1;
                    for (j = 0; j < n; j++)
                    {
                        ddv = 1;
                        switch (number[i + j])
                        {
                            case '0':
                                if (n - j == 3) doc += cs[0] + " ";
                                if (n - j == 2)
                                {
                                    if (number[i + j + 1] != '0') doc += "lẻ ";
                                    ddv = 0;
                                }
                                break;
                            case '1':
                                if (n - j == 3) doc += cs[1] + " ";
                                if (n - j == 2)
                                {
                                    doc += "mười ";
                                    ddv = 0;
                                }
                                if (n - j == 1)
                                {
                                    if (i + j == 0) k = 0;
                                    else k = i + j - 1;

                                    if (number[k] != '1' && number[k] != '0')
                                        doc += "mốt ";
                                    else
                                        doc += cs[1] + " ";
                                }
                                break;
                            case '5':
                                if (i + j == len - 1)
                                    doc += "lăm ";
                                else
                                    doc += cs[5] + " ";
                                break;
                            default:
                                doc += cs[(int)number[i + j] - 48] + " ";
                                break;
                        }

                        //Doc don vi nho
                        if (ddv == 1)
                        {
                            doc += dv[n - j - 1] + " ";
                        }
                    }
                }

                //Doc don vi lon
                if (len - i - n > 0)
                {
                    if ((len - i - n) % 9 == 0)
                    {
                        if (rd == 1)
                            for (k = 0; k < (len - i - n) / 9; k++)
                                doc += "tỉ ";
                        rd = 0;
                    }
                    else
                        if (found != 0) doc += dv[((len - i - n + 1) % 9) / 3 + 2] + " ";
                }

                i += n;
            }

            if (len == 1)
                if (number[0] == '0' || number[0] == '5') return cs[(int)number[0] - 48];

            return doc;
        }

        #region Mã hóa MD5
        public static string MaHoaMD5(string text)
        {
            MD5CryptoServiceProvider _md5Hasher = new MD5CryptoServiceProvider();
            byte[] bs = Encoding.UTF8.GetBytes(text);
            bs = _md5Hasher.ComputeHash(bs);
            StringBuilder s = new StringBuilder();
            foreach (byte b in bs)
            {
                s.Append(b.ToString("x2"));
            }
            return s.ToString();
        }
        #endregion

        //Bỏ dấu tiếng việt
        #region Bỏ dấu tiếng việt
        public static string RemoveSign4VietnameseString(string str)
        {
            //Tiến hành thay thế , lọc bỏ dấu cho chuỗi
            for (int i = 1; i < VietnameseSigns.Length; i++)
            {

                for (int j = 0; j < VietnameseSigns[i].Length; j++)

                    str = str.Replace(VietnameseSigns[i][j], VietnameseSigns[0][i - 1]);
            }
            return str;
        }
        private static readonly string[] VietnameseSigns = new string[]
        {

        "aAeEoOuUiIdDyY",

        "áàạảãâấầậẩẫăắằặẳẵ",

        "ÁÀẠẢÃÂẤẦẬẨẪĂẮẰẶẲẴ",

        "éèẹẻẽêếềệểễ",

        "ÉÈẸẺẼÊẾỀỆỂỄ",

        "óòọỏõôốồộổỗơớờợởỡ",

        "ÓÒỌỎÕÔỐỒỘỔỖƠỚỜỢỞỠ",

        "úùụủũưứừựửữ",

        "ÚÙỤỦŨƯỨỪỰỬỮ",

        "íìịỉĩ",

        "ÍÌỊỈĨ",

        "đ",

         "Đ",

            "ýỳỵỷỹ",

            "ÝỲỴỶỸ"
        };
        #endregion
    }//end class
}

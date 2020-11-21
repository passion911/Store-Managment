using System;
using System.Collections.Generic;
using Public;
using System.Data;
using System.Data.SqlClient;
using System.Data.OleDb;
using DataAccess;

namespace DataAccessd
{
    public class SanPhamDataAccess
    {
        static readonly ConnectionDataAccess Conn = new ConnectionDataAccess();

        //Danh sách sản phẩm
        public static DataSet DsSanPham()
        {
            string StoreprocedureName = "[Danh sách sản phẩm]";
            return Conn.GetDataSet(StoreprocedureName);
        }

        //Thêm mới sản phẩm
        public static bool ThemSanPham(SanPhamPublic _sp)
        {
            SqlCommand _cmd = new SqlCommand();
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.CommandText = "[Thêm mới sản phẩm]";
            _cmd.Parameters.AddWithValue("@MaSP_SP", _sp.MaSP_SP);
            _cmd.Parameters.AddWithValue("@TenSP_SP", _sp.TenSP_SP);
            _cmd.Parameters.AddWithValue("@GiaNhap_SP", _sp.GiaNhap_SP);
            _cmd.Parameters.AddWithValue("@GiaBanLe_SP", _sp.GiaBanLe_SP);
            _cmd.Parameters.AddWithValue("@GiaBanSi_SP", _sp.GiaBanSi_SP);
            _cmd.Parameters.AddWithValue("@MaNCC_SP", _sp.NCC_SP.MaNCC_NCC);
            _cmd.Parameters.AddWithValue("@MaNSP_SP", _sp.NSP_SP.MaNSP_NSP);
            _cmd.Parameters.AddWithValue("@MaDVT_SP", _sp.DVT_SP.MaDVT_DVT);
            _cmd.Parameters.AddWithValue("@GhiChu_SP", _sp.GhiChu_SP);
            _cmd.Parameters.AddWithValue("@CKPhanTram_SP", _sp.CKPhanTram_SP);
            _cmd.Parameters.AddWithValue("@Anh_SP", _sp.Anh_SP);

            return Conn.Execute(_cmd);
        }

        //Xóa sản phẩm
        public static bool XoaSanPham(string _MaSP)
        {
            SqlCommand _cmd = new SqlCommand();
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.CommandText = "[Xóa sản phẩm]";
            _cmd.Parameters.AddWithValue("@MaSP_SP", _MaSP);
            return Conn.Execute(_cmd);
        }


        //Lấy nhóm sản phẩm cbo
        public static List<NhomSanPhamPublic> LayNSP()
        {
            List<NhomSanPhamPublic> _ListNSP = new List<NhomSanPhamPublic>();
            NhomSanPhamPublic _nsp;
            DataTable _dt = Conn.GetDataSet("[Lấy nhóm sản phẩm - sản phẩm]").Tables[0];
            foreach (DataRow _dr in _dt.Rows)
            {
                _nsp = new NhomSanPhamPublic();
                _nsp.MaNSP_NSP = _dr["MaNSP_NSP"].ToString();
                _nsp.TenNSP_NSP = _dr["TenNSP_NSP"].ToString();
                _nsp.DangDung_NSP = (bool)_dr["DangDung_NSP"];
                if (!_nsp.DangDung_NSP)
                    continue;
                _ListNSP.Add(_nsp);
            }

            return _ListNSP;
        }

        //Lấy nhóm sản phẩm 2
        public static List<NhomSanPhamPublic> LayNSP2()
        {
            List<NhomSanPhamPublic> _ListNSP = new List<NhomSanPhamPublic>();
            NhomSanPhamPublic _nsp;
            DataTable _dt = Conn.GetDataSet("[Lấy nhóm sản phẩm - sản phẩm]").Tables[0];
            _nsp = new NhomSanPhamPublic();
            _nsp.MaNSP_NSP = "";
            _nsp.TenNSP_NSP = "---Tất cả---";
            _ListNSP.Add(_nsp);

            foreach (DataRow _dr in _dt.Rows)
            {
                _nsp = new NhomSanPhamPublic();
                _nsp.MaNSP_NSP = _dr["MaNSP_NSP"].ToString();
                _nsp.TenNSP_NSP = _dr["TenNSP_NSP"].ToString();

                _ListNSP.Add(_nsp);
            }

            return _ListNSP;
        }

        //Lấy đơn vị tính cbo
        public static List<DonViTinhPublic> LayDVT()
        {
            List<DonViTinhPublic> _ListDVT = new List<DonViTinhPublic>();
            DonViTinhPublic _dvt;
            DataTable _dt = Conn.GetDataSet("[Lấy đơn vị tính - sản phẩm]").Tables[0];
            foreach (DataRow _dr in _dt.Rows)
            {
                _dvt = new DonViTinhPublic();
                _dvt.MaDVT_DVT = _dr["MaDVT_DVT"].ToString();
                _dvt.TenDVT_DVT = _dr["TenDVT_DVT"].ToString();

                _ListDVT.Add(_dvt);
            }

            return _ListDVT;
        }

        //Lấy nhà cung cấp
        public static List<NhaCungCapPublic> LayNCC()
        {
            List<NhaCungCapPublic> _ListNCC = new List<NhaCungCapPublic>();
            NhaCungCapPublic _ncc;

            DataTable _dt = Conn.GetDataSet("[Lấy nhà cung cấp - sản phẩm]").Tables[0];
            foreach (DataRow _dr in _dt.Rows)
            {
                _ncc = new NhaCungCapPublic();
                _ncc.MaNCC_NCC = _dr["MaNCC_NCC"].ToString();
                _ncc.TenNCC_NCC = _dr["TenNCC_NCC"].ToString();

                _ListNCC.Add(_ncc);
            }
            return _ListNCC;
        }

        //Sửa thông tin sản phẩm
        public static bool SuaSanPham(SanPhamPublic _sp)
        {
            SqlCommand _cmd = new SqlCommand();
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.CommandText = "[Sửa sản phẩm]";
            _cmd.Parameters.AddWithValue("@MaSP_SP", _sp.MaSP_SP);
            _cmd.Parameters.AddWithValue("@TenSP_SP", _sp.TenSP_SP);
            _cmd.Parameters.AddWithValue("@GiaNhap_SP", _sp.GiaNhap_SP);
            _cmd.Parameters.AddWithValue("@GiaBanLe_SP", _sp.GiaBanLe_SP);
            _cmd.Parameters.AddWithValue("@GiaBanSi_SP", _sp.GiaBanSi_SP);
            _cmd.Parameters.AddWithValue("@MaNCC_SP", _sp.NCC_SP.MaNCC_NCC);
            _cmd.Parameters.AddWithValue("@MaNSP_SP", _sp.NSP_SP.MaNSP_NSP);
            _cmd.Parameters.AddWithValue("@MaDVT_SP", _sp.DVT_SP.MaDVT_DVT);
            _cmd.Parameters.AddWithValue("@GhiChu_SP", _sp.GhiChu_SP);
            _cmd.Parameters.AddWithValue("@CKPhanTram_SP", _sp.CKPhanTram_SP);
            _cmd.Parameters.AddWithValue("@Anh_SP", _sp.Anh_SP);

            return Conn.Execute(_cmd);
        }

        //Import data to Datatable
        public static DataTable ImportToDatatable(string _path)
        {
            DataTable _dt = new DataTable();

            //Lấy dữ liệu từ Excel
            try
            {
                string Sqlstr = @"SELECT [Mã SP] as MASP, [Tên SP] as TENSP,[Giá nhập] as GIANHAP, [Giá bán lẻ] as GIABANLE, [Giá bán sỉ] as GIABANSI, [Mã nhà cung cấp] as MANCC,[Mã nhóm SP] as MANSP,[Mã đơn vị]  as MADVT,[Ghi chú] as GHICHU,[Chiết khấu SP] as CHIETKHAU FROM [Sheet1$]";
                OleDbConnection OleDbcon = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + _path + ";Extended Properties=Excel 12.0;");
                OleDbCommand _cmd = new OleDbCommand(Sqlstr, OleDbcon);
                OleDbDataAdapter objAdapter = new OleDbDataAdapter(_cmd);

                objAdapter.Fill(_dt);
            }
            catch (Exception)
            {
                return _dt;
            }
            return _dt;
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


        //Sửa giá bán lẻ theo nhóm sản phẩm
        public static bool SuaGiaTheoNhom(string _MaNSP, string _GiaBan)
        {
            SqlCommand _cmd = new SqlCommand();
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.CommandText = "[Sửa giá theo nhóm]";

            _cmd.Parameters.AddWithValue("@GianBan", _GiaBan);
            _cmd.Parameters.AddWithValue("@MaNSP", _MaNSP);
            return Conn.Execute(_cmd);
        }

        //check exist
        public static bool CheckExist(string maSp)
        {
            var sql = string.Format("SELECT * FROM tbl_SANPHAM WHERE MaSP_SP = '{0}'", maSp);
            var dt = Conn.GetDataSetSqlQuery(sql).Tables[0];
            return dt.Rows.Count > 0;
        }
    }//END CLASS
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Public;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess
{
    public class PhanQuyenDataAccess
    {
        static ConnectionDataAccess conn = new ConnectionDataAccess();

        //Lấy danh sách quyền
        public static List<QuyenPublic> DanhSachQuyen()
        {
            List<QuyenPublic> _ListQuyen = new List<QuyenPublic>();
            QuyenPublic _quyen;
            DataTable _dtQuyen = conn.GetDataSet("[Lấy danh sách quyền - Phân quyền]").Tables[0];

            for (int i = 0; i < _dtQuyen.Rows.Count; i++)
            {
                _quyen = new QuyenPublic();
                _quyen.ID_Q = _dtQuyen.Rows[i]["ID_Q"].ToString();
                _quyen.TenQuyen_Q = _dtQuyen.Rows[i]["TenQuyen_Q"].ToString();
                _ListQuyen.Add(_quyen);
            }
            return _ListQuyen;
        }

        //Lấy Quyền chức năng theo Quyền
        public static List<QuyenChucNangPublic> LayQuyenChucNangTheoQuyen(string _IDQuyen)
        {
            List<QuyenChucNangPublic> _ListQCN = new List<QuyenChucNangPublic>();
            QuyenChucNangPublic _QCN;

            SqlCommand _cmd = new SqlCommand();
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.CommandText = "[Lấy danh sách Quyền - Chức năng]";
            _cmd.Parameters.AddWithValue("@ID_Q", _IDQuyen);
            DataTable _dtQCN = conn.GetDataSet2(_cmd).Tables[0];
            for (int i = 0; i < _dtQCN.Rows.Count; i++)
            {
                _QCN = new QuyenChucNangPublic();
                _QCN.Quyen.ID_Q = _dtQCN.Rows[i]["ID_Q"].ToString();
                _QCN.Quyen.TenQuyen_Q = _dtQCN.Rows[i]["TenQuyen_Q"].ToString();
                _QCN.ChucNang.ID_CN = _dtQCN.Rows[i]["ID_CN"].ToString();
                _QCN.ChucNang.TenChucNang_CN = _dtQCN.Rows[i]["TenChucNang_CN"].ToString();
                _QCN.DuocSuDung_QCN = (bool)_dtQCN.Rows[i]["DuocSuDung_QCN"];

                _ListQCN.Add(_QCN);
            }
            return _ListQCN;
        }

        //Thêm quyền(Thêm cả quyền và quyền chức năng)
        public static void ThemQuyen(QuyenPublic _quyen)
        {
            try
            {
                //Thêm mới quyền
                ThemMoiQuyen(_quyen);

                //Thêm mới Quyền - Chức năng
                QuyenChucNangPublic _QuyenChucNang;
                DataTable _dtChucNang = conn.GetDataSet("[Danh sách chức năng]").Tables[0];
                for (int i = 0; i < _dtChucNang.Rows.Count; i++)
                {
                    _QuyenChucNang = new QuyenChucNangPublic();
                    _QuyenChucNang.Quyen = _quyen;
                    _QuyenChucNang.ChucNang.ID_CN = _dtChucNang.Rows[i]["ID_CN"].ToString();
                    _QuyenChucNang.DuocSuDung_QCN = false;

                    ThemMoiQuyenChucNang(_QuyenChucNang);
                }
            }
            catch (Exception)
            {
                throw;
            }

        }

        //Thêm mới quyền
        private static void ThemMoiQuyen(QuyenPublic _quyen)
        {
            SqlCommand _cmd = new SqlCommand();
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.CommandText = "[Thêm quyền]";
            _cmd.Parameters.AddWithValue("@ID_Q", _quyen.ID_Q);
            _cmd.Parameters.AddWithValue("@TenQuyen_Q", _quyen.TenQuyen_Q);

            conn.Execute(_cmd);
        }

        //Thêm mới Quyền - Chức năng
        private static void ThemMoiQuyenChucNang(QuyenChucNangPublic _QuyenChucNang)
        {
            SqlCommand _cmd = new SqlCommand();
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.CommandText = "[Thêm Quyền - Chức năng]";
            _cmd.Parameters.AddWithValue("@IDQ_QCN", _QuyenChucNang.Quyen.ID_Q);
            _cmd.Parameters.AddWithValue("@IDCN_QCN", _QuyenChucNang.ChucNang.ID_CN);
            _cmd.Parameters.AddWithValue("@DuocSuDung_QCN", _QuyenChucNang.DuocSuDung_QCN);
            conn.Execute(_cmd);
        }

        //Cập nhật quyền
        public static void CapNhatQuyenChucNang(List<QuyenChucNangPublic> _QuyenChucNang)
        {
            foreach (QuyenChucNangPublic _qcn in _QuyenChucNang)
            {

                SqlCommand _cmd = new SqlCommand();
                _cmd.CommandType = CommandType.StoredProcedure;
                _cmd.CommandText = "[Cập nhật Quyền - Chức năng]";
                _cmd.Parameters.AddWithValue("@IDQ_QCN", _qcn.Quyen.ID_Q);
                _cmd.Parameters.AddWithValue("@IDCN_QCN", _qcn.ChucNang.ID_CN);
                _cmd.Parameters.AddWithValue("@DuocSuDung_QNV", _qcn.DuocSuDung_QCN);

                conn.Execute(_cmd);
            }
        }

        //Xóa quyền
        public static bool XoaQuyen(string _ID_Q)
        {
            //Check
            if (UntilitiesDataAccess.CheckExist("tbl_NHANVIEN", "ID_Q", _ID_Q))
                return false;

            //Xóa
            SqlCommand _cmd = new SqlCommand();
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.CommandText = "[Xóa quyền]";
            _cmd.Parameters.AddWithValue("@ID_Q", _ID_Q);

            return conn.Execute(_cmd);
        }
    }//End class
}

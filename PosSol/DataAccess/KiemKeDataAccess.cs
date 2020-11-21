using System;
using System.Collections.Generic;
using Public;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess
{
    public class KiemKeDataAccess
    {
        static ConnectionDataAccess conn = new ConnectionDataAccess();

        //Lấy nhóm sản phẩm cbo
        public static List<NhomSanPhamPublic> LayNSP()
        {
            List<NhomSanPhamPublic> _ListNSP = new List<NhomSanPhamPublic>();
            NhomSanPhamPublic _nsp;
            DataTable _dt = conn.GetDataSet("[Lấy nhóm sản phẩm - sản phẩm]").Tables[0];

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

        //Lấy sản phẩm theo mã
        public static List<SanPhamPublic> LaySPTheoNhom(string _maNSP)
        {
            List<SanPhamPublic> _ListSP = new List<SanPhamPublic>();
            SanPhamPublic _sp;
            DataTable _dtSP;
            if (_maNSP == "")
            {
                //Lấy toàn bộ sản phẩm
                _dtSP = conn.GetDataSet("[Danh sách sản phẩm]").Tables[0];

                for (int i = 0; i < _dtSP.Rows.Count; i++)
                {
                    _sp = new SanPhamPublic();
                    _sp.MaSP_SP = _dtSP.Rows[i]["MaSP_SP"].ToString();
                    _sp.TenSP_SP = _dtSP.Rows[i]["TenSP_SP"].ToString();
                    _sp.NSP_SP.TenNSP_NSP = _dtSP.Rows[i]["TenNSP_NSP"].ToString();
                    _sp.SoLuong_SP = Convert.ToInt32(_dtSP.Rows[i]["SoLuong_SP"].ToString());
                    _ListSP.Add(_sp);
                }
                return _ListSP;
            }
            else
            {
                //Lấy sản phẩm theo mã
                SqlCommand _cmd = new SqlCommand();
                _cmd.CommandType = CommandType.StoredProcedure;
                _cmd.CommandText = "[Lấy sản phẩm theo nhóm - kiểm kê]";
                _cmd.Parameters.AddWithValue("@MaNSP_NSP", _maNSP);

                _dtSP = conn.GetDataSet2(_cmd).Tables[0];
                for (int i = 0; i < _dtSP.Rows.Count; i++)
                {
                    _sp = new SanPhamPublic();
                    _sp.MaSP_SP = _dtSP.Rows[i]["MaSP_SP"].ToString();
                    _sp.TenSP_SP = _dtSP.Rows[i]["TenSP_SP"].ToString();
                    _sp.NSP_SP.TenNSP_NSP = _dtSP.Rows[i]["TenNSP_NSP"].ToString();
                    _sp.SoLuong_SP = Convert.ToInt32(_dtSP.Rows[i]["SoLuong_SP"].ToString());
                    _ListSP.Add(_sp);
                }
            }
            return _ListSP;
        }

        //Cập nhật số lượng
        public static bool CapNhatSoLuong(string _MaSP, int _SoLuong)
        {
            SqlCommand _cmd = new SqlCommand();
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.CommandText = "[Cập nhật số lượng - kiểm kê]";
            _cmd.Parameters.AddWithValue("@MaSP_SP", _MaSP);
            _cmd.Parameters.AddWithValue("@SoLuong_SP", _SoLuong);

            return conn.Execute(_cmd);
        }

    }//end class
}

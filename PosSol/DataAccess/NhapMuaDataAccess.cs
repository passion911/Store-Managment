using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Public;
using System.Data.SqlClient;

namespace DataAccess
{
    public class NhapMuaDataAccess
    {
        //Khai báo
        static ConnectionDataAccess conn = new ConnectionDataAccess();

        //Ds sản phẩm
        public static DataSet DsSanPham()
        {
            string _storeprodureName = "[Nhập mua - Danh sách sản phẩm]";
            return conn.GetDataSet(_storeprodureName);
        }

        //Lấy nhóm sản phẩm
        public static List<NhomSanPhamPublic> ListNSP()
        {
            List<NhomSanPhamPublic> _ListNSP = new List<NhomSanPhamPublic>();
            NhomSanPhamPublic _nsp;
            DataTable _dtNsp = conn.GetDataSet("[Lấy nhóm sản phẩm - nhập mua]").Tables[0];
            _nsp = new NhomSanPhamPublic();
            _nsp.MaNSP_NSP = "";
            _nsp.TenNSP_NSP = "...Tất cả...";
            _ListNSP.Add(_nsp);
            foreach (DataRow _dr in _dtNsp.Rows)
            {
                _nsp = new NhomSanPhamPublic();

                _nsp.MaNSP_NSP = _dr["MaNSP_NSP"].ToString();
                _nsp.TenNSP_NSP = _dr["TenNSP_NSP"].ToString();

                _ListNSP.Add(_nsp);
            }
            return _ListNSP;
        }

        //Nhập Hàng 
        public static void NhapHang(PhieuNhapPublic _phieunhap, List<SanPhamPublic> _ListSPNhap)
        {
            //Thêm phiếu nhập
            ThemPhieuNhap(_phieunhap);
            //Thêm chi tiết hàng nhập
            HangNhapPublic _hangNhap = new HangNhapPublic();
            _hangNhap.PhieuNhap_HN.SoPhieu_PN = _phieunhap.SoPhieu_PN;
            foreach (SanPhamPublic _spNhap in _ListSPNhap)
            {
                if (_spNhap.SoLuong_SP <= 0)
                    continue;

                _hangNhap.SanPham_HN.MaSP_SP = _spNhap.MaSP_SP;
                _hangNhap.SoLuong_HN = _spNhap.SoLuong_SP;

                ThemHangNhap(_hangNhap);
                ThemSoLuongSPVaoKho(_spNhap);
            }
        }

        //Thêm phiếu nhập hàng mới
        private static void ThemPhieuNhap(PhieuNhapPublic _phieunhap)
        {
            SqlCommand _cmd = new SqlCommand();
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.CommandText = "[Thêm phiếu nhập hàng]";
            _cmd.Parameters.AddWithValue("@SoPhieu_PN", _phieunhap.SoPhieu_PN);
            _cmd.Parameters.AddWithValue("@NgayNhap_PN", _phieunhap.NgayNhap_PN);
            _cmd.Parameters.AddWithValue("@NguoiNhap_PN", _phieunhap.NguoiNhap_PN.MaNV_NV);
            _cmd.Parameters.AddWithValue("@GhiChu_PN", _phieunhap.GhiChu_PN);

            conn.Execute(_cmd);
        }

        //Thêm chi tiết hàng nhập
        private static void ThemHangNhap(HangNhapPublic _hangNhap)
        {
            SqlCommand _cmd = new SqlCommand();
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.CommandText = "[Thêm hàng nhập]";

            _cmd.Parameters.AddWithValue("@SoPhieu_HN", _hangNhap.PhieuNhap_HN.SoPhieu_PN);
            _cmd.Parameters.AddWithValue("@MaSP_HN", _hangNhap.SanPham_HN.MaSP_SP);
            _cmd.Parameters.AddWithValue("@SoLuong_HN", _hangNhap.SoLuong_HN);

            conn.Execute(_cmd);
        }

        //Thêm số lượng sản phẩm trong kho
        private static void ThemSoLuongSPVaoKho(SanPhamPublic _sp)
        {
            SqlCommand _cmd = new SqlCommand();
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.CommandText = "[Thêm sô lượng SP trong kho]";
            _cmd.Parameters.AddWithValue("@MaSP_SP", _sp.MaSP_SP);
            _cmd.Parameters.AddWithValue("@SoLuongThem", _sp.SoLuong_SP);

            conn.Execute(_cmd);
        }


        //Lấy danh sách hàng nhập theo phiếu nhập
        public static DataTable LayHangNhap(string _soPhieu)
        {
            DataTable _dtHangNhap = new DataTable();
            SqlCommand _cmd = new SqlCommand();
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.CommandText = "[Lấy danh sách hàng nhập ]";
            _cmd.Parameters.AddWithValue("@SoPhieu_PN", _soPhieu);
            _dtHangNhap = conn.GetDataSet2(_cmd).Tables[0];

            return _dtHangNhap;
        }

    }//End class
}

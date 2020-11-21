using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Public;
using System.Data.SqlClient;
using System.Data;

namespace DataAccess
{
    public class LichSuBanHangDataAccess
    {
        static ConnectionDataAccess conn = new ConnectionDataAccess();

        //Thêm lịch sử bán hàng
        public static bool ThemLichSuBanHang(LichSuBanHangPublic _lsbh)
        {
            SqlCommand _cmd = new SqlCommand();
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.CommandText = "[Thêm lịch sử bán hàng]";
            _cmd.Parameters.AddWithValue("@MaLSBH_LSBH", _lsbh.MaLSBH_LSBH);
            _cmd.Parameters.AddWithValue("@NhanVienThucHien_LSBH", _lsbh.NhanVienThucHien_LSBH.MaNV_NV);
            _cmd.Parameters.AddWithValue("@SoHD_LSBH", _lsbh.SoHD_LSBH.SoHD_HD);
            _cmd.Parameters.AddWithValue("@MoTa_LSBH", _lsbh.MoTa_LSBH);
            _cmd.Parameters.AddWithValue("@ThoiGian_LSBH", _lsbh.ThoiGian_LSBH);

            return conn.Execute(_cmd);
        }

        //Lấy lịch sử bán hàng
        public static DataSet LayLichSuBanHang()
        {
            return conn.GetDataSet("[Lấy lịch sử bán hàng]");
        }

        //Lấy lịch sử bán hàng theo ngày
        public static List<LichSuBanHangPublic> LayLSBHTheoNgay(DateTime _tuNgay, DateTime _denNgay)
        {
            List<LichSuBanHangPublic> _lstLSBH = new List<LichSuBanHangPublic>();
            DateTime _dtTuNgay = new DateTime(_tuNgay.Year, _tuNgay.Month, _tuNgay.Day, 0, 0, 0);
            DateTime _dtDenNgay = new DateTime(_denNgay.Year, _denNgay.Month, _denNgay.Day, 23, 59, 59);

            SqlCommand _cmd = new SqlCommand();
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.CommandText = "[Lấy lịch sử bán hàng - theo ngày]";
            _cmd.Parameters.AddWithValue("@TuNgay", _dtTuNgay);
            _cmd.Parameters.AddWithValue("@DenNgay", _dtDenNgay);

            //Lấy danh sách lịch sử bán hàng
            DataTable _dtLSBH = conn.GetDataSet2(_cmd).Tables[0];
            LichSuBanHangPublic _lichsuBH;
            if (_dtLSBH.Rows.Count > 0)
            {
                for (int i = 0; i < _dtLSBH.Rows.Count; i++)
                {
                    _lichsuBH = new LichSuBanHangPublic();
                    _lichsuBH.MaLSBH_LSBH = _dtLSBH.Rows[i]["MaLSBH_LSBH"].ToString();
                    _lichsuBH.NhanVienThucHien_LSBH.MaNV_NV = _dtLSBH.Rows[i]["NhanVienThucHien_LSBH"].ToString();
                    _lichsuBH.SoHD_LSBH.SoHD_HD = _dtLSBH.Rows[i]["SoHD_LSBH"].ToString();
                    _lichsuBH.MoTa_LSBH = _dtLSBH.Rows[i]["MoTa_LSBH"].ToString();
                    _lichsuBH.ThoiGian_LSBH = Convert.ToDateTime(_dtLSBH.Rows[i]["ThoiGian_LSBH"].ToString());

                    _lichsuBH.SoHD_LSBH = ThongKeDataAccess.TinhTien1HoaDon(_lichsuBH.SoHD_LSBH.SoHD_HD);

                    _lstLSBH.Add(_lichsuBH);
                }
            }
            return _lstLSBH;
        }

    }//End class
}

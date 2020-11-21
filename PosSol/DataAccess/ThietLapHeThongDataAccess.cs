using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Public;
using System.Data;
using System.Data.SqlClient;
using System.Xml;

namespace DataAccess
{
    public class ThietLapHeThongDataAccess
    {
        static ConnectionDataAccess conn = new ConnectionDataAccess();

        //Lấy thiết lập hệ thống
        public static ThietLapHeThongPublic LayThietLapHeThong()
        {
            DataTable _dtThietLap = conn.GetDataSet("[Lấy thiết lập]").Tables[0];
            ThietLapHeThongPublic _thietLapHT = new ThietLapHeThongPublic();

            //Voucher
            _thietLapHT.Voucher = _dtThietLap.Rows[0][2].ToString().Trim() == "1" ? true : false;

            //Mã giảm giá
            _thietLapHT.MaGiamGia = _dtThietLap.Rows[1][2].ToString().Trim() == "1" ? true : false;

            //Tên cửa hàng
            _thietLapHT.TenCuaHang = _dtThietLap.Rows[2][2].ToString().Trim();

            //Địa chỉ
            _thietLapHT.DiaChi = _dtThietLap.Rows[3][2].ToString().Trim();

            //SĐT
            _thietLapHT.SDT = _dtThietLap.Rows[4][2].ToString().Trim();

            //Mức đổi điểm
            _thietLapHT.MucQuyDoiDiem = Convert.ToInt32(_dtThietLap.Rows[5][2].ToString());

            //Bật tắt cộng điểm cho khách hàng khi mua hàng
            _thietLapHT.CongDiemKhachHang = _dtThietLap.Rows[6][2].ToString().Trim() == "1" ? true : false;

            //Bật tắt chiết khấu hóa đơn
            _thietLapHT.ChietKhauHoaDon = _dtThietLap.Rows[7][2].ToString() == "1" ? true : false;

            //Bật tắ chiết khấu sản phẩm
            _thietLapHT.ChietKhauSanPham = _dtThietLap.Rows[8][2].ToString() == "1" ? true : false;

            //Bật tắt kiểm tra giá nhập
            _thietLapHT.KiemTraGiaNhap = _dtThietLap.Rows[9][2].ToString() == "1" ? true : false;
            return _thietLapHT;
        }

        //Cập nhật thiết lập hệ thống
        public static void CapNhatThietLapHeThong(ThietLapHeThongPublic _thietLap)
        {
            SqlCommand _cmd = new SqlCommand();
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.CommandText = "[Sửa thiết lập hệ thống]";

            //Cập nhật Tên cửa hàng
            _cmd.Parameters.AddWithValue("@MaThietLap_TL", "TL.00002");
            _cmd.Parameters.AddWithValue("@GiaTri_TL", _thietLap.TenCuaHang);
            conn.Execute(_cmd);

            //Cập nhật địa chỉ
            _cmd.Parameters.Clear();
            _cmd.Parameters.AddWithValue("@MaThietLap_TL", "TL.00003");
            _cmd.Parameters.AddWithValue("@GiaTri_TL", _thietLap.DiaChi);
            conn.Execute(_cmd);

            //cập nhật số điện thoại
            _cmd.Parameters.Clear();
            _cmd.Parameters.AddWithValue("@MaThietLap_TL", "TL.00004");
            _cmd.Parameters.AddWithValue("@GiaTri_TL", _thietLap.SDT);
            conn.Execute(_cmd);

            //Mức quy đổi điểm
            _cmd.Parameters.Clear();
            _cmd.Parameters.AddWithValue("@MaThietLap_TL", "TL.00005");
            _cmd.Parameters.AddWithValue("@GiaTri_TL", _thietLap.MucQuyDoiDiem);
            conn.Execute(_cmd);

            //Voucher
            _cmd.Parameters.Clear();
            _cmd.Parameters.AddWithValue("@MaThietLap_TL", "TL.00000");
            _cmd.Parameters.AddWithValue("@GiaTri_TL", _thietLap.Voucher == true ? "1" : "0");
            conn.Execute(_cmd);

            //Mã giảm giá
            _cmd.Parameters.Clear();
            _cmd.Parameters.AddWithValue("@MaThietLap_TL", "TL.00001");
            _cmd.Parameters.AddWithValue("@GiaTri_TL", _thietLap.MaGiamGia == true ? "1" : "0");
            conn.Execute(_cmd);


            ////Cộng điểm tích lũy
            //_cmd.Parameters.Clear();
            //_cmd.Parameters.AddWithValue("@MaThietLap_TL", "TL.00006");
            //_cmd.Parameters.AddWithValue("@GiaTri_TL", _thietLap.CongDiemKhachHang == true ? "1" : "0");
            //conn.Execute(_cmd);

            //Chiết khấu hóa đơn
            _cmd.Parameters.Clear();
            _cmd.Parameters.AddWithValue("@MaThietLap_TL", "TL.00007");
            _cmd.Parameters.AddWithValue("@GiaTri_TL", _thietLap.ChietKhauHoaDon == true ? "1" : "0");
            conn.Execute(_cmd);


            //Chiết khấu sản phẩm
            _cmd.Parameters.Clear();
            _cmd.Parameters.AddWithValue("@MaThietLap_TL", "TL.00008");
            _cmd.Parameters.AddWithValue("@GiaTri_TL", _thietLap.ChietKhauSanPham == true ? "1" : "0");
            conn.Execute(_cmd);

            //Kiểm tra giá nhập
            _cmd.Parameters.Clear();
            _cmd.Parameters.AddWithValue("@MaThietLap_TL", "TL.00009");
            _cmd.Parameters.AddWithValue("@GiaTri_TL", _thietLap.ChietKhauSanPham == true ? "1" : "0");
            conn.Execute(_cmd);
        }

        public static bool CheckLastDate()
        {
            
            var xml = new XmlDocument();
            xml.Load("Connection.xml");
            var xmlElement = xml.DocumentElement;
            if (xmlElement != null)
            {
                var node = xmlElement.SelectSingleNode("lastdate");
                if (node != null)
                {
                    var lastDate = node.InnerText;
                    if (DateTime.Compare(Convert.ToDateTime(lastDate), DateTime.Now) < 0)
                        return false;
                }
            }
            return true;
        }
    }//End class
}

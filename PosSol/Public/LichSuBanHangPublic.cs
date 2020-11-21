using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Public
{
    public class LichSuBanHangPublic
    {
        private string _MaLSBH_LSBH;
        public string MaLSBH_LSBH
        {
            get { return _MaLSBH_LSBH; }
            set { _MaLSBH_LSBH = value; }
        }

        private NhanVienPublic _NhanVienThucHien_LSBH = new NhanVienPublic();
        public NhanVienPublic NhanVienThucHien_LSBH
        {
            get { return _NhanVienThucHien_LSBH; }
            set { _NhanVienThucHien_LSBH = value; }
        }

        private HoaDonPublic _SoHD_LSBH = new HoaDonPublic();
        public HoaDonPublic SoHD_LSBH
        {
            get { return _SoHD_LSBH; }
            set { _SoHD_LSBH = value; }
        }

        private string _MoTa_LSBH;
        public string MoTa_LSBH
        {
            get { return _MoTa_LSBH; }
            set { _MoTa_LSBH = value; }
        }

        private DateTime _ThoiGian_LSBH;
        public DateTime ThoiGian_LSBH
        {
            get { return _ThoiGian_LSBH; }
            set { _ThoiGian_LSBH = value; }
        }
    }//End class
}

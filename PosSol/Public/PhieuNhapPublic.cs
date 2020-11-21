using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Public
{
    public class PhieuNhapPublic
    {
        private string _SoPhieu_PN;
        public string SoPhieu_PN
        {
            get { return _SoPhieu_PN; }
            set { _SoPhieu_PN = value; }
        }

        private DateTime _NgayNhap_PN;
        public DateTime NgayNhap_PN
        {
            get { return _NgayNhap_PN; }
            set { _NgayNhap_PN = value; }
        }

        private NhanVienPublic _NguoiNhap_PN = new NhanVienPublic();
        public NhanVienPublic NguoiNhap_PN
        {
            get { return _NguoiNhap_PN; }
            set { _NguoiNhap_PN = value; }
        }

        private string _GhiChu_PN;
        public string GhiChu_PN
        {
            get { return _GhiChu_PN; }
            set { _GhiChu_PN = value; }
        }
    }//End class
}

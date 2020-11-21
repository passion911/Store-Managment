using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Public
{
    public class HangNhapPublic
    {
        private PhieuNhapPublic _PhieuNhap_HN = new PhieuNhapPublic();
        public PhieuNhapPublic PhieuNhap_HN
        {
            get { return _PhieuNhap_HN; }
            set { _PhieuNhap_HN = value; }
        }

        private SanPhamPublic _SanPham_HN = new SanPhamPublic();
        public SanPhamPublic SanPham_HN
        {
            get { return _SanPham_HN; }
            set { _SanPham_HN = value; }
        }

        private int _SoLuong_HN;
        public int SoLuong_HN
        {
            get { return _SoLuong_HN; }
            set { _SoLuong_HN = value; }
        }
    }//End class
}

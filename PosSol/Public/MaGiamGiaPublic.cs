using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Public
{
    public class MaGiamGiaPublic
    {
        private string _MaThe_MGG;
        public string MaThe_MGG
        {
            get { return _MaThe_MGG; }
            set { _MaThe_MGG = value; }
        }

        private int _ChietKhau_MGG;
        public int ChietKhau_MGG
        {
            get { return _ChietKhau_MGG; }
            set { _ChietKhau_MGG = value; }
        }

        private DateTime _NgayHetHan_MGG;
        public DateTime NgayHetHan_MGG
        {
            get { return _NgayHetHan_MGG; }
            set { _NgayHetHan_MGG = value; }
        }


        private bool _TrangThai_MGG;
        public bool TrangThai_MGG
        {
            get { return _TrangThai_MGG; }
            set { _TrangThai_MGG = value; }
        }

        private string _GhiChu_MGG;
        public string GhiChu_MGG
        {
            get { return _GhiChu_MGG; }
            set { _GhiChu_MGG = value; }
        }
    }//End Class
}

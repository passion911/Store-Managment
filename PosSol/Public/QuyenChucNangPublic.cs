using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Public
{
    public class QuyenChucNangPublic
    {
        private QuyenPublic _Quyen=new QuyenPublic();
        public QuyenPublic Quyen
        {
            get { return _Quyen; }
            set { _Quyen = value; }
        }

        private ChucNangPublic _ChucNang = new ChucNangPublic();
        public ChucNangPublic ChucNang
        {
            get { return _ChucNang; }
            set { _ChucNang = value; }
        }

        private bool _DuocSuDung_QCN;
        public bool DuocSuDung_QCN
        {
            get { return _DuocSuDung_QCN; }
            set { _DuocSuDung_QCN = value; }
        }

    }//End class
}

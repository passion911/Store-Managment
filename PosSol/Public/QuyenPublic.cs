using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Public
{
    public class QuyenPublic
    {
        private string _ID_Q;
        public string ID_Q
        {
            get { return _ID_Q; }
            set { _ID_Q = value; }
        }

        private string _TenQuyen_Q;
        public string TenQuyen_Q
        {
            get { return _TenQuyen_Q; }
            set { _TenQuyen_Q = value; }
        }
    }//End class
}

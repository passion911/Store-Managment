using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Public
{
    public class DonViTinhPublic
    {
        // Mã đơn vị tính
        private string _MaDVT_DVT;
        public string MaDVT_DVT
        {
            get { return _MaDVT_DVT; }
            set { _MaDVT_DVT = value; }
        }

        //Tên đơn vị tính
        private string _TenDVT_DVT;
        public string TenDVT_DVT
        {
            get { return _TenDVT_DVT; }
            set { _TenDVT_DVT = value; }
        }

        //Trạng thái đang dùng
        private bool _DangDung_DVT;
        public bool DangDung_DVT
        {
            get { return _DangDung_DVT; }
            set { _DangDung_DVT = value; }
        }

    }//End class
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Public
{
    public class NhaCungCapPublic
    {
        //mã nhà cung cấp
        public string _MaNCC_NCC;
        public string MaNCC_NCC
        {
            get { return _MaNCC_NCC; }
            set { _MaNCC_NCC = value; }
        }
        //Tên nhà cung cấp
        private string _TenNCC_NCC;
        public string TenNCC_NCC
        {
            get { return _TenNCC_NCC; }
            set { _TenNCC_NCC = value; }
        }
        //GHi chú
        private string _GhiChu_NCC;
        public string GhiChu_NCC
        {
            get { return _GhiChu_NCC; }
            set { _GhiChu_NCC = value; }
        }

    }//End class
}

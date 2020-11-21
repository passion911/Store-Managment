using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Public
{
    public class NhomSanPhamPublic
    {
        //Mã nhóm sản phẩm
        private string _MaNSP_NSP;
        public string MaNSP_NSP
        {
            get { return _MaNSP_NSP; }
            set { _MaNSP_NSP = value; }
        }

        //Tên nhóm sản phẩm
        private string _TenNSP_NSP;
        public string TenNSP_NSP
        {
            get { return _TenNSP_NSP; }
            set { _TenNSP_NSP = value; }
        }

        //Trạng thái đang dùng
        private bool _DangDung_NSP;
        public bool DangDung_NSP
        {
            get { return _DangDung_NSP; }
            set { _DangDung_NSP = value; }
        }

        //Ghi chú nhóm sản phẩm
        private string _GhiChu_NSP;
        public string GhiChu_NSP
        {
            get { return _GhiChu_NSP; }
            set { _GhiChu_NSP = value; }
        }

        //Ngày tạo
        private DateTime _NgayTao_NSP;
        public DateTime NgayTao_NSP
        {
            get { return _NgayTao_NSP; }
            set { _NgayTao_NSP = value; }
        }
    }//End class
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Public
{
    public class NhomKhachHangPublic
    {
        //mã nhóm khách hàng
        private string _MaNKH_NKH;
        public string MaNKH_NKH
        {
            get { return _MaNKH_NKH; }
            set { _MaNKH_NKH = value; }
        }

        //Tên nhóm khách hàng
        private string _TenNKH_NKH;
        public string TenNKH_NKH
        {
            get { return _TenNKH_NKH; }
            set { _TenNKH_NKH = value; }
        }

        //Phần trăm chiết khấu của nhóm khách hàng này
        private int _ChietKhau_NKH;
        public int ChietKhau_NKH
        {
            get { return _ChietKhau_NKH; }
            set { _ChietKhau_NKH = value; }
        }

        //Điểm để lên được nhóm KH này
        private int _Diem_NKH;
        public int Diem_NKH
        {
            get { return _Diem_NKH; }
            set { _Diem_NKH = value; }
        }

        //Ảnh đại diện cho nhóm khách hàng
        private string _Anh_NKH;
        public string Anh_NKH
        {
            get { return _Anh_NKH; }
            set { _Anh_NKH = value; }
        }

        //Ngày tạo
        private DateTime _NgayTao_NKH;
        public DateTime NgayTao_NKH
        {
            get { return _NgayTao_NKH; }
            set { _NgayTao_NKH = value; }
        }

        //Đang dùng
        private bool _DangDung_NKH;
        public bool DangDung_NKH
        {
            get { return _DangDung_NKH; }
            set { _DangDung_NKH = value; }
        }
    }//End class
}

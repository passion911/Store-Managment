using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Public
{
    public class KhachHangPublic
    {
        //Mã khách hàng
        private string _MaKH_KH;
        public string MaKH_KH
        {
            get { return _MaKH_KH; }
            set { _MaKH_KH = value; }
        }

        //Tên khách hàng
        private string _HoTen_KH;
        public string HoTen_KH
        {
            get { return _HoTen_KH; }
            set { _HoTen_KH = value; }
        }

        //Giới tính
        private string _GioiTinh_KH;
        public string GioiTinh_KH
        {
            get { return _GioiTinh_KH; }
            set { _GioiTinh_KH = value; }
        }

        //Ngày sinh
        private DateTime _NgaySinh_KH;
        public DateTime NgaySinh_KH
        {
            get { return _NgaySinh_KH; }
            set { _NgaySinh_KH = value; }
        }

        //Email
        private string _Email_KH;
        public string Email_KH
        {
            get { return _Email_KH; }
            set { _Email_KH = value; }
        }

        //Thuộc nhóm khách hàng nào
        private NhomKhachHangPublic _NHK_KH = new NhomKhachHangPublic();
        public NhomKhachHangPublic NHK_KH
        {
            get { return _NHK_KH; }
            set { _NHK_KH = value; }
        }


        //Số điểm tích lũy dc
        private int _DiemTichLuy_KH;
        public int DiemTichLuy_KH
        {
            get { return _DiemTichLuy_KH; }
            set { _DiemTichLuy_KH = value; }
        }

        //Số lần mua hàng tại cửa hàng
        private int _SoLanMuaHang_KH;
        public int SoLanMuaHang_KH
        {
            get { return _SoLanMuaHang_KH; }
            set { _SoLanMuaHang_KH = value; }
        }

        //Lần mua hàng gần đây nhất
        private DateTime _LanMuaHangGanNhat_KH;
        public DateTime LanMuaHangGanNhat_KH
        {
            get { return _LanMuaHangGanNhat_KH; }
            set { _LanMuaHangGanNhat_KH = value; }
        }

        //Số điện thoại
        private string _SDT_KH;
        public string SDT_KH
        {
            get { return _SDT_KH; }
            set { _SDT_KH = value; }
        }

        //Ghi chú
        private string _GhiChu;
        public string GhiChu
        {
            get { return _GhiChu; }
            set { _GhiChu = value; }
        }

        //Tự động lên nhóm theo điểm tích lũy
        private bool _TuDongLenNhom_KH;
        public bool TuDongLenNhom_KH
        {
            get { return _TuDongLenNhom_KH; }
            set { _TuDongLenNhom_KH = value; }
        }

        //Ngày tạo
        private DateTime _NgayTao_KH;
        public DateTime NgayTao_KH
        {
            get { return _NgayTao_KH; }
            set { _NgayTao_KH = value; }
        }

        //Đang dùng
        private bool _DangDung_KH;
        public bool DangDung_KH
        {
            get { return _DangDung_KH; }
            set { _DangDung_KH = value; }
        }

    }//Endclass
}

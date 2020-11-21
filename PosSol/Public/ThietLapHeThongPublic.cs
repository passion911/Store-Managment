using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Public
{
    public class ThietLapHeThongPublic
    {
        private string _MaThietLap_TL;
        public string MaThietLap_TL
        {
            get { return _MaThietLap_TL; }
            set { _MaThietLap_TL = value; }
        }

        private string _ChucNang_TL;
        public string ChucNang_TL
        {
            get { return _ChucNang_TL; }
            set { _ChucNang_TL = value; }
        }

        private string _GiaTri_TL;
        public string GiaTri_TL
        {
            get { return _GiaTri_TL; }
            set { _GiaTri_TL = value; }
        }

        private string _GhiChu_TL;
        public string GhiChu_TL
        {
            get { return _GhiChu_TL; }
            set { _GhiChu_TL = value; }
        }

        //Voucher: tính năng nhập vorcher khi thanh toán
        private bool _Voucher;
        public bool Voucher
        {
            get { return _Voucher; }
            set { _Voucher = value; }
        }

        //Mã giảm giá
        private bool _MaGiamGia;
        public bool MaGiamGia
        {
            get { return _MaGiamGia; }
            set { _MaGiamGia = value; }
        }

        //Tên cửa hàng
        private string _TenCuaHang;
        public string TenCuaHang
        {
            get { return _TenCuaHang; }
            set { _TenCuaHang = value; }
        }

        //Địa chỉ cửa hàng
        private string _DiaChi;
        public string DiaChi
        {
            get { return _DiaChi; }
            set { _DiaChi = value; }
        }

        //SĐT
        private string _SDT;
        public string SDT
        {
            get { return _SDT; }
            set { _SDT = value; }
        }

        //Mức quy đổi tiền ra điểm
        private int _MucQuyDoiDiem;
        public int MucQuyDoiDiem
        {
            get { return _MucQuyDoiDiem; }
            set { _MucQuyDoiDiem = value; }
        }

        //Bật tắt cộng điểm khi mua hàng
        private bool _CongDiemKhachHang;
        public bool CongDiemKhachHang
        {
            get { return _CongDiemKhachHang; }
            set { _CongDiemKhachHang = value; }
        }

        //Chiết khấu hóa đơn
        private bool _ChietKhauHoaDon;
        public bool ChietKhauHoaDon
        {
            get { return _ChietKhauHoaDon; }
            set { _ChietKhauHoaDon = value; }
        }

        //Chiết khấu sản phẩm
        private bool _ChietKhauSanPham;
        public bool ChietKhauSanPham
        {
            get { return _ChietKhauSanPham; }
            set { _ChietKhauSanPham = value; }
        }

        //Kiểm tra giá nhập khi bán hàng
        private bool _KiemTraGiaNhap;
        public bool KiemTraGiaNhap
        {
            get { return _KiemTraGiaNhap; }
            set { _KiemTraGiaNhap = value; }
        }

    }//EndClass
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Public
{
    public class HoaDonPublic
    {
        //Số hóa đơn
        private string _SoHD_HD;

        public string SoHD_HD
        {
            get { return _SoHD_HD; }
            set { _SoHD_HD = value; }
        }

        //Ngày lập
        private DateTime _NgayLap_HD;
        public DateTime NgayLap_HD
        {
            get { return _NgayLap_HD; }
            set { _NgayLap_HD = value; }
        }

        //Người lập
        private NhanVienPublic _NguoiLap_HD = new NhanVienPublic();
        public NhanVienPublic NguoiLap_HD
        {
            get { return _NguoiLap_HD; }
            set { _NguoiLap_HD = value; }
        }

        //Khách hàng
        private KhachHangPublic _KhachHang_HD = new KhachHangPublic();
        public KhachHangPublic KhachHang_HD
        {
            get { return _KhachHang_HD; }
            set { _KhachHang_HD = value; }
        }

        //Bán lẻ - bán buôn: xác định kiểu bán
        private bool _BanLe_HD;
        public bool BanLe_HD
        {
            get { return _BanLe_HD; }
            set { _BanLe_HD = value; }
        }

        //Tổng tiền nhập
        private int _TongTienNhap;
        public int TongTienNhap
        {
            get { return _TongTienNhap; }
            set { _TongTienNhap = value; }
        }

        //Tổng tiền hóa đơn
        private int _TongTien_HD;
        public int TongTien_HD
        {
            get { return _TongTien_HD; }
            set { _TongTien_HD = value; }
        }

        //Tổng tiền chiết khấu sản phẩm
        private int _TongCKSanPham;
        public int TongCKSanPham
        {
            get { return _TongCKSanPham; }
            set { _TongCKSanPham = value; }
        }

        //Chiết khấu phần trăm hóa đơn
        private float _CKPhanTram_HD;
        public float CKPhanTram_HD
        {
            get { return _CKPhanTram_HD; }
            set { _CKPhanTram_HD = value; }
        }

        //Tiền chiết khấu hóa đơn
        private int _TongCKHoaDon;
        public int TongCKHoaDon
        {
            get { return _TongCKHoaDon; }
            set { _TongCKHoaDon = value; }
        }

        //Tiền mã giảm giá
        private int _TienMaGiamGia;
        public int TienMaGiamGia
        {
            get { return _TienMaGiamGia; }
            set { _TienMaGiamGia = value; }
        }

        //Thành tiền
        private int _ThanhTien;
        public int ThanhTien
        {
            get { return _ThanhTien; }
            set { _ThanhTien = value; }
        }

        //Tiền khách trả
        private int _TienKhachTra_HD;
        public int TienKhachTra_HD
        {
            get { return _TienKhachTra_HD; }
            set { _TienKhachTra_HD = value; }
        }

        //Tiền khách hàng trả trước
        private int _TienKhachTraTruoc;
        public int TienKhachTraTruoc
        {
            get { return _TienKhachTraTruoc; }
            set { _TienKhachTraTruoc = value; }
        }

        //Tiền còn phải trả
        private int _TienConLaiPhaiTra;
        public int TienConLaiPhaiTra
        {
            get { return _TienConLaiPhaiTra; }
            set { _TienConLaiPhaiTra = value; }
        }

        //Tiền thừa trả lại khách
        private int _TienThuaTraLaiKhach;
        public int TienThuaTraLaiKhach
        {
            get { return _TienThuaTraLaiKhach; }
            set { _TienThuaTraLaiKhach = value; }
        }

        //Voucher 
        private int _VouCher_HD;
        public int VouCher_HD
        {
            get { return _VouCher_HD; }
            set { _VouCher_HD = value; }
        }

        //Mã giảm giá
        private MaGiamGiaPublic _MaGiamGia = new MaGiamGiaPublic();
        public MaGiamGiaPublic MaGiamGia
        {
            get { return _MaGiamGia; }
            set { _MaGiamGia = value; }
        }

        //Tổng số lượng sản phẩm
        private int _TongSoLuongSP;
        public int TongSoLuongSP
        {
            get { return _TongSoLuongSP; }
            set { _TongSoLuongSP = value; }
        }

        //Dang dùng
        private bool _DangDung_HD;
        public bool DangDung_HD
        {
            get { return _DangDung_HD; }
            set { _DangDung_HD = value; }
        }

        //Trả hàng 
        private bool _TraHang_HD;
        public bool TraHang_HD
        {
            get { return _TraHang_HD; }
            set { _TraHang_HD = value; }
        }
    }//end class
}

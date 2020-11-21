using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Public
{
    public class HangMuaPubLic
    {
        //Thông tin hóa đơn 
        private HoaDonPublic _HoaDon = new HoaDonPublic();
        public HoaDonPublic HoaDon
        {
            get { return _HoaDon; }
            set { _HoaDon = value; }
        }

        //Thông tin sản phẩm
        private SanPhamPublic _SanPham = new SanPhamPublic();
        public SanPhamPublic SanPham
        {
            get { return _SanPham; }
            set { _SanPham = value; }
        }

        //Số lượng mua
        private int _SoLuong;
        public int SoLuong
        {
            get { return _SoLuong; }
            set { _SoLuong = value; }
        }

        //Chiết khấu phần trăm của một mặt hàng
        private float _ChietKhauPhanTram;
        public float ChietKhauPhanTram
        {
            get { return _ChietKhauPhanTram; }
            set { _ChietKhauPhanTram = value; }
        }

        //Chiết khấu tiền mặt của một mặt hàng  
        private string _ChietKhauTienMat;
        public string ChietKhauTienMat
        {
            get { return _ChietKhauTienMat; }
            set { _ChietKhauTienMat = value; }
        }


        //Thành tiền 1 sản phẩm 
        private int _ThanhTien;
        public int ThanhTien
        {
            get { return _ThanhTien; }
            set { _ThanhTien = value; }
        }

        //Tổng tiền chưa trừ CK
        private int _TongTienSP;
        public int TongTienSP
        {
            get { return _TongTienSP; }
            set { _TongTienSP = value; }
        }

        //Giá nhập sản phẩm
        private string _GiaNhap_HM;
        public string GiaNhap_HM
        {
            get { return _GiaNhap_HM; }
            set { _GiaNhap_HM = value; }
        }

        //Giá bán
        private string _GiaBan_HM;
        public string GiaBan_HM
        {
            get { return _GiaBan_HM; }
            set { _GiaBan_HM = value; }
        }



    }//End Class
}

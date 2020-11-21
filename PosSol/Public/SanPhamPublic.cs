using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Public
{
    public class SanPhamPublic
    {
        //Số thứ tự
        private int _STT;
        public int STT
        {
            get { return _STT; }
            set { _STT = value; }
        }

        //Mã sản phẩm
        private string _MaSP_SP;
        public string MaSP_SP
        {
            get { return _MaSP_SP; }
            set { _MaSP_SP = value; }
        }

        //Tên sản phẩm
        private string _TenSP_SP;
        public string TenSP_SP
        {
            get { return _TenSP_SP; }
            set { _TenSP_SP = value; }
        }

        //Giá nhập
        private string _GiaNhap_SP;
        public string GiaNhap_SP
        {
            get { return _GiaNhap_SP; }
            set { _GiaNhap_SP = value; }
        }


        //Giá bán lẻ
        private string _GiaBanLe_SP;
        public string GiaBanLe_SP
        {
            get { return _GiaBanLe_SP; }
            set { _GiaBanLe_SP = value; }
        }

        // Giá bán sỉ
        private string _GiaBanSi_SP;
        public string GiaBanSi_SP
        {
            get { return _GiaBanSi_SP; }
            set { _GiaBanSi_SP = value; }
        }

        //Giá bán - chỉ dùng tại wpf bán hàng
        private string _GiaBan;
        public string GiaBan
        {
            get { return _GiaBan; }
            set { _GiaBan = value; }
        }

        //Nhà cung cấp
        public NhaCungCapPublic _NCC_SP = new NhaCungCapPublic();
        public NhaCungCapPublic NCC_SP
        {
            get { return _NCC_SP; }
            set { _NCC_SP = value; }
        }

        //Nhóm sản phẩm
        private NhomSanPhamPublic _NSP_SP = new NhomSanPhamPublic();
        public NhomSanPhamPublic NSP_SP
        {
            get { return _NSP_SP; }
            set { _NSP_SP = value; }
        }


        //Đơn vị tính
        private DonViTinhPublic _DVT_SP = new DonViTinhPublic();
        public DonViTinhPublic DVT_SP
        {
            get { return _DVT_SP; }
            set { _DVT_SP = value; }
        }

        //Ghi chú
        private string _GhiChu_SP;
        public string GhiChu_SP
        {
            get { return _GhiChu_SP; }
            set { _GhiChu_SP = value; }
        }

        //Số lượng
        private int _SoLuong_SP;
        public int SoLuong_SP
        {
            get { return _SoLuong_SP; }
            set { _SoLuong_SP = value; }
        }

        //Chiết khấu phần trăm của sản phẩm
        private float _CKPhanTram_SP;
        public float CKPhanTram_SP
        {
            get { return _CKPhanTram_SP; }
            set { _CKPhanTram_SP = value; }
        }

        //Chiết khấu tiền mặt - chỉ dùng tại wpf bán hàng
        private string _CKTienMat;
        public string CKTienMat
        {
            get { return _CKTienMat; }
            set { _CKTienMat = value; }
        }

        //Ảnh sản phẩm
        private string _Anh_SP;
        public string Anh_SP
        {
            get { return _Anh_SP; }
            set { _Anh_SP = value; }
        }

        //Ngày tạo
        private DateTime _NgayTao_SP;
        public DateTime NgayTao_SP
        {
            get { return _NgayTao_SP; }
            set { _NgayTao_SP = value; }
        }

        //Thành tiền - dùng tại hóa đơn và nhập hàng
        private string _ThanhTien_SP;
        public string ThanhTien_SP
        {
            get { return _ThanhTien_SP; }
            set { _ThanhTien_SP = value; }
        }

    }//End class
}

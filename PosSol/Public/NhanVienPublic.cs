using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Public
{
    public class NhanVienPublic
    {
        //Mã nhân viên
        private string _MaNV_NV;
        public string MaNV_NV
        {
            get { return _MaNV_NV; }
            set { _MaNV_NV = value; }
        }

        //Họ tên
        private string _HoTen_NV;
        public string HoTen_NV
        {
            get { return _HoTen_NV; }
            set { _HoTen_NV = value; }
        }

        //Ngày sinh
        private DateTime _NgaySinh_NV;
        public DateTime NgaySinh_NV
        {
            get { return _NgaySinh_NV; }
            set { _NgaySinh_NV = value; }
        }

        //Giới tính
        private string _GioiTinh_NV;
        public string GioiTinh_NV
        {
            get { return _GioiTinh_NV; }
            set { _GioiTinh_NV = value; }
        }

        //Địa chỉ
        private string _DiaChi_NV;
        public string DiaChi_NV
        {
            get { return _DiaChi_NV; }
            set { _DiaChi_NV = value; }
        }

        //Số điện thoại
        private string _SDT_NV;
        public string SDT_NV
        {
            get { return _SDT_NV; }
            set { _SDT_NV = value; }
        }

        //Ảnh nhân viên
        private string _Anh_NV;
        public string Anh_NV
        {
            get { return _Anh_NV; }
            set { _Anh_NV = value; }
        }

        //Ngày tạo
        private DateTime _NgayTao_NV;
        public DateTime NgayTao_NV
        {
            get { return _NgayTao_NV; }
            set { _NgayTao_NV = value; }
        }

        //Mật khẩu
        private string _MatKhau_NV;
        public string MatKhau_NV
        {
            get { return _MatKhau_NV; }
            set { _MatKhau_NV = value; }
        }


        //Đang dùng
        private bool _DangDung_NV;
        public bool DangDung_NV
        {
            get { return _DangDung_NV; }
            set { _DangDung_NV = value; }
        }

        //Nhóm quyền
        private string _ID_Q;
        public string ID_Q
        {
            get { return _ID_Q; }
            set { _ID_Q = value; }
        }
    }//End class
}

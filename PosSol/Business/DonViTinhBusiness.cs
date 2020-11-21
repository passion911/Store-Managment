using DataAccess;
using System.Data;
using Public;

namespace Business
{
    public class DonViTinhBusiness
    {
        //DANH SÁCH ĐƠN VỊ TÍNH
        public static DataSet DanhSachDonViTinh()
        {
            return DonViTinhDataAccess.DanhSachDonViTinh();
        }

        //THÊM MỚI ĐƠN VỊ TÍNH
        public static bool ThemDonViTinh(DonViTinhPublic _dvt)
        {
            return DonViTinhDataAccess.ThemDonViTinh(_dvt);
        }

        //SỬA THÔNG TIN ĐƠN VỊ TÍNH
        public static bool SuaDonViTinh(DonViTinhPublic _dvt)
        {
            return DonViTinhDataAccess.SuaDonViTinh(_dvt);
        }

        //XÓA ĐƠN VỊ TÍNH
        public static bool XoaDonViTinh(string _MaDVT)
        {
            return DonViTinhDataAccess.XoaDonViTinh(_MaDVT);
        }
    }//End class
}

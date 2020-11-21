using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.IO;
using Presentation.Report;
using Presentation.UserControls;
using Public;
using Presentation.WindowWpf;

namespace Presentation
{
    /// <summary>
    /// Interaction logic for Test.xaml
    /// </summary>
    public partial class Test : Window
    {
        string str;
        public Test()
        {
            InitializeComponent();
            // str = System.IO.Path.GetFullPath(@"../../Image/NhanVien/nv2.jpg");
            // MessageBox.Show(str);
        }

        private void img_test_Loaded(object sender, RoutedEventArgs e)
        {
            // BitmapImage _bImg = new BitmapImage(new Uri(str));
            //  img_test.Source = _bImg;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Form1 frm = new Form1();
            //frm.Show();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            gdContentMain.Children.Clear();
            //NhapHangTraUPresentation wpf = new NhapHangTraUPresentation();
            //wpf._TiepTucMua += new EventHandler(TiepTucMua);

            //LichSuBanHangUPresentation wpf_ls = new LichSuBanHangUPresentation();
            //gdContentMain.Children.Add(wpf_ls);

            //ThongKeTheoHoaDon wpf = new ThongKeTheoHoaDon();
            //ThongKeTheoNhanVienUPresentation wpf = new ThongKeTheoNhanVienUPresentation();
            //ThietLapHeThongUPresentation wpf = new ThietLapHeThongUPresentation();
            //PhanQuyenUPresentation wpf = new PhanQuyenUPresentation();
            //NhanVienUPresentation wpf = new NhanVienUPresentation();
            //NhomKhachHangUPresentation wpf = new NhomKhachHangUPresentation();
            //KhachHangUPresentation wpf = new KhachHangUPresentation();
            //NhomSanPhamUPresentation wpf = new NhomSanPhamUPresentation();
            //TaoMaVachUPresentation wpf = new TaoMaVachUPresentation();
            //SanPhamUPresentation wpf = new SanPhamUPresentation();
            //BanHangUPresentation wpf = new BanHangUPresentation();
            //PhieuNhapKhoUPresentation wpf = new PhieuNhapKhoUPresentation();
            //ThongKeTheoKhachHangUPresentation wpf = new ThongKeTheoKhachHangUPresentation();
            //MaGiamGiaUPresentation wpf = new MaGiamGiaUPresentation();

            //ThietLapHeThongUPresentation wpf = new ThietLapHeThongUPresentation();
            //ThongKeTheoSpUPresentation wpf = new ThongKeTheoSpUPresentation();
            //LichSuBanHangUPresentation wpf = new LichSuBanHangUPresentation();
            //SanPhamUPresentation wpf = new SanPhamUPresentation();
            //DonViTinhUPresentation wpf = new DonViTinhUPresentation();
            NhaCungCapUPresentation wpf = new NhaCungCapUPresentation();
            gdContentMain.Children.Add(wpf);
        }

        //Phương thức tiếp tục mua
        private void TiepTucMua(object sender, EventArgs e)
        {
            //Lấy danh sách hàng tiếp tục mua
            NhapHangTraUPresentation wpf_nhapHangTra = (NhapHangTraUPresentation)sender;
            List<SanPhamPublic> _LstSpTiepTucMua = wpf_nhapHangTra._lstSpTiepTucMua;
            HoaDonPublic _hoaDonCu = wpf_nhapHangTra._hoaDonMoi;

            BanHangUPresentation wpf_bh = new BanHangUPresentation();
            wpf_bh._hoaDonCu = _hoaDonCu;
            wpf_bh._lstSpTiepTucMua = _LstSpTiepTucMua;

            gdContentMain.Children.Clear();
            gdContentMain.Children.Add(wpf_bh);
        }

    }//End class
}

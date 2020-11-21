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
using Public;
using Business;

namespace Presentation.WindowWpf
{
    /// <summary>
    /// Interaction logic for ChiTietPhieuNhapPresentation.xaml
    /// </summary>
    public partial class ChiTietPhieuNhapPresentation : Window
    {
        //Khai báo
        public PhieuNhapPublic _phieuNhap;
        public ChiTietPhieuNhapPresentation()
        {
            InitializeComponent();
        }

        //Loaded
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            lbSoPhieu.Content = _phieuNhap.SoPhieu_PN;
            lbNgayNhap.Content = _phieuNhap.NgayNhap_PN.ToString("dd-MM-yyyy");
            lbNguoiNhap.Content = _phieuNhap.NguoiNhap_PN.HoTen_NV;
            lbNguoiNhap.ToolTip = _phieuNhap.NguoiNhap_PN.MaNV_NV;

            dgDsHangNhap.ItemsSource = NhapMuaBusiness.LayHangNhap(_phieuNhap.SoPhieu_PN).DefaultView;
        }

        //Nút Đóng
        private void btnDong_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        protected override void OnPreviewKeyDown(KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
                this.Close();
            base.OnPreviewKeyDown(e);
        }
    }//End class
}

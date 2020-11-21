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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Business;
using Public;
using System.ComponentModel;
using Presentation.WindowWpf;

namespace Presentation.UserControls
{
    /// <summary>
    /// Interaction logic for PhieuNhapKhoUPresentation.xaml
    /// </summary>
    public partial class PhieuNhapKhoUPresentation : UserControl
    {
        //Khai báo
        BackgroundWorker _worker;
        List<PhieuNhapPublic> _lstPhieuNhap;
        public PhieuNhapKhoUPresentation()
        {
            InitializeComponent();
        }

        //Loaded
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            DateTime _dtToDay = DateTime.Today;
            DateTime _dtTuNgay = new DateTime(_dtToDay.Year, _dtToDay.Month, 1, 0, 0, 0);
            DateTime _dtDenNgay = new DateTime(_dtToDay.Year, _dtToDay.Month, _dtToDay.Day, 0, 0, 0);
            dateTuNgay.SelectedDate = _dtTuNgay;
            dateDenNgay.SelectedDate = _dtDenNgay;

            HienThi(dateTuNgay.SelectedDate.Value, dateDenNgay.SelectedDate.Value);
        }
        private void HienThi(DateTime _dtTuNgay, DateTime _dtDenNgay)
        {
            //Hiển thị progress
            bdProgress.Visibility = System.Windows.Visibility.Visible;

            //Tiến trình xử lý
            _worker = new BackgroundWorker();
            _worker.DoWork += (obj, ea) => HienThi_dowork(_dtTuNgay, _dtDenNgay);
            _worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(HienThi_complete);
            _worker.RunWorkerAsync();
        }

        //Hiển thị worker do work
        private void HienThi_dowork(DateTime _TuNgay, DateTime _DenNgay)
        {
            //Lấy dữ liệu
            _lstPhieuNhap = ThongKeBusiness.LayPhieuNhapTheoNgay(_TuNgay, _DenNgay);
        }

        //Hiển thị worker complete
        private void HienThi_complete(object sender, RunWorkerCompletedEventArgs e)
        {
            //Hiển thị
            dgDsPhieuNhap.ItemsSource = _lstPhieuNhap;
            dgDsPhieuNhap.Items.Refresh();

            lbStatus.Content = "Danh sách phiếu nhập từ " + dateTuNgay.SelectedDate.Value.ToString("dd-MM-yyyy") + " đến " + dateDenNgay.SelectedDate.Value.ToString("dd-MM-yyyy");

            //Ẩn progress
            bdProgress.Visibility = System.Windows.Visibility.Collapsed;
        }

        //Nút xem
        private void btnXem_Click(object sender, RoutedEventArgs e)
        {
            HienThi(dateTuNgay.SelectedDate.Value, dateDenNgay.SelectedDate.Value);
        }

        //Nút reset
        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            UserControl_Loaded(sender, e);
        }

        //Chi tiết
        private void btnXemChiTiet_Click(object sender, RoutedEventArgs e)
        {
            PhieuNhapPublic _phieuNhap = (dgDsPhieuNhap.SelectedItem as PhieuNhapPublic);
            ChiTietPhieuNhapPresentation wpf = new ChiTietPhieuNhapPresentation();
            wpf._phieuNhap = _phieuNhap;
            wpf.ShowDialog();
        }
    }//End class
}
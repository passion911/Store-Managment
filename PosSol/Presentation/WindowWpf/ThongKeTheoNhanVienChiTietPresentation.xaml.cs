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
using DataAccess;
using Business;
using Public;
using System.ComponentModel;

namespace Presentation.WindowWpf
{
    /// <summary>
    /// Interaction logic for ThongKeTheoNhanVienChiTietPresentation.xaml
    /// </summary>
    public partial class ThongKeTheoNhanVienChiTietPresentation : Window
    {
        //Khai báo
        BackgroundWorker _worker;
        List<ThongKeTheoHoaDonPublic> _lstKqThongKeTheoNVChiTiet;
        public NhanVienPublic _NhanVien = new NhanVienPublic();

        public ThongKeTheoNhanVienChiTietPresentation()
        {
            InitializeComponent();
        }

        //wpf loaded
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DateTime _toDay = DateTime.Now;
            DateTime _TuNgay = new DateTime(_toDay.Year, _toDay.Month, 1, 0, 0, 0);
            DateTime _DenNgay = new DateTime(_toDay.Year, _toDay.Month, _toDay.Day, 23, 59, 59);

            dateTuNgay.SelectedDate = _TuNgay;
            dateDenNgay.SelectedDate = _DenNgay;

            string _MaNV = _NhanVien.MaNV_NV;
            HienThi(_MaNV, dateTuNgay.SelectedDate.Value, dateDenNgay.SelectedDate.Value);

        }
        private void HienThi(string _MaNV, DateTime _dtTuNgay, DateTime _dtDenNgay)
        {
            //Hiển thị progress
            bdProgress.Visibility = System.Windows.Visibility.Visible;

            //Tiến trình xử lý
            _worker = new BackgroundWorker();
            _worker.DoWork += (obj, ea) => HienThi_dowork(_MaNV, _dtTuNgay, _dtDenNgay);
            _worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(HienThi_complete);
            _worker.RunWorkerAsync();
        }
        //Hiển thị worker do work
        private void HienThi_dowork(string _MaNV, DateTime _TuNgay, DateTime _DenNgay)
        {
            //Lấy dữ liệu
            _lstKqThongKeTheoNVChiTiet = ThongKeBusiness.ThongKeTheoNhanVienChiTiet(_MaNV, _TuNgay, _DenNgay);
        }

        //Hiển thị worker complete
        private void HienThi_complete(object sender, RunWorkerCompletedEventArgs e)
        {
            string _TenNV = _NhanVien.HoTen_NV;

            //Hiển thị
            dgDsHoaDon.ItemsSource = _lstKqThongKeTheoNVChiTiet;
            dgDsHoaDon.Items.Refresh();

            lbStatus.Content = "Danh sách hóa đơn do " + _TenNV + "  thực hiện từ " + dateTuNgay.SelectedDate.Value.ToString("dd-MM-yyyy") + " đến " + dateDenNgay.SelectedDate.Value.ToString("dd-MM-yyyy");

            //Tính tổng thu - tổng lãi
            int _TongThu = 0;
            int _TongLai = 0;
            if (_lstKqThongKeTheoNVChiTiet != null)
                for (int i = 0; i < _lstKqThongKeTheoNVChiTiet.Count; i++)
                {
                    _TongThu = _TongThu + Convert.ToInt32(UntilitiesBusiness.BoDauPhay(_lstKqThongKeTheoNVChiTiet[i].TongThu));
                    _TongLai = _TongLai + Convert.ToInt32(UntilitiesBusiness.BoDauPhay(_lstKqThongKeTheoNVChiTiet[i].TongLoiNhuan));
                }

            lbTongThu.Content = UntilitiesBusiness.ThemDauPhay(_TongThu.ToString());
            lbTongLai.Content = UntilitiesBusiness.ThemDauPhay(_TongLai.ToString());

            //Ẩn progress
            bdProgress.Visibility = System.Windows.Visibility.Collapsed;
        }

        //dg loadingrow
        private void dgDsHoaDon_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = (e.Row.GetIndex() + 1).ToString();
        }

        //Nút xem
        private void btnXem_Click(object sender, RoutedEventArgs e)
        {
            string _MaNV = _NhanVien.MaNV_NV;
            HienThi(_MaNV, dateTuNgay.SelectedDate.Value, dateDenNgay.SelectedDate.Value);
        }

        //Nút reset
        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            Window_Loaded(sender, e);
        }

        //Xem chi tiết hóa đơn
        private void btnXemChiTiet_Click(object sender, RoutedEventArgs e)
        {
            string _soHD = (dgDsHoaDon.SelectedItem as ThongKeTheoHoaDonPublic).HoaDon.SoHD_HD;

            ChiTietHoaDonPresentation wpf = new ChiTietHoaDonPresentation();
            wpf._soHD = _soHD;
            wpf.ShowDialog();
        }

    }//End class
}

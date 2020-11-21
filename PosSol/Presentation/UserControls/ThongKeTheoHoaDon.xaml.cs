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
using DataAccess;
using Business;
using Public;
using System.ComponentModel;
using Presentation.WindowWpf;
using Presentation.Report;
using Presentation.Dataset;
using System.Data;

namespace Presentation.UserControls
{
    /// <summary>
    /// Interaction logic for ThongKeTheoHoaDon.xaml
    /// </summary>
    public partial class ThongKeTheoHoaDon : UserControl
    {
        //Khai báo
        BackgroundWorker _worker;
        List<ThongKeTheoHoaDonPublic> _lstKetQuaThongKe;

        public ThongKeTheoHoaDon()
        {
            InitializeComponent();
            //cbo tháng
            cboThang.ItemsSource = ThongKeBusiness.DsThang();
        }

        //Wpf loaded
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            DateTime _toDay = DateTime.Now;
            DateTime _TuNgay = new DateTime(_toDay.Year, _toDay.Month, 1, 0, 0, 0);
            DateTime _DenNgay = new DateTime(_toDay.Year, _toDay.Month, _toDay.Day, 23, 59, 59);

            dateTuNgay.SelectedDate = _TuNgay;
            dateDenNgay.SelectedDate = _DenNgay;

            HienThi(dateTuNgay.SelectedDate.Value, dateDenNgay.SelectedDate.Value);
            lbStatus.Content = "Danh sách hóa đơn từ " + dateTuNgay.SelectedDate.Value.ToString("dd-MM-yyyy") + " đến " + dateDenNgay.SelectedDate.Value.ToString("dd-MM-yyyy");
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
            _lstKetQuaThongKe = ThongKeBusiness.ThongKeTheoHoaDon(_TuNgay, _DenNgay);
        }

        //Hiển thị worker complete
        private void HienThi_complete(object sender, RunWorkerCompletedEventArgs e)
        {
            //Hiển thị
            dgDsHoaDon.ItemsSource = _lstKetQuaThongKe;
            dgDsHoaDon.Items.Refresh();


            //Tính tổng thu - tổng lãi
            int _TongThu = 0;
            int _TongLai = 0;
            if (_lstKetQuaThongKe != null)
                for (int i = 0; i < _lstKetQuaThongKe.Count; i++)
                {
                    _TongThu = _TongThu + Convert.ToInt32(UntilitiesBusiness.BoDauPhay(_lstKetQuaThongKe[i].TongThu));
                    _TongLai = _TongLai + Convert.ToInt32(UntilitiesBusiness.BoDauPhay(_lstKetQuaThongKe[i].TongLoiNhuan));
                }
            lbSoHoaDon.Content = _lstKetQuaThongKe.Count.ToString();
            lbTongThu.Content = UntilitiesBusiness.ThemDauPhay(_TongThu.ToString());
            lbTongLai.Content = UntilitiesBusiness.ThemDauPhay(_TongLai.ToString());

            //Ẩn progress
            bdProgress.Visibility = System.Windows.Visibility.Collapsed;
        }

        //Nút xem
        private void btnXem_Click(object sender, RoutedEventArgs e)
        {
            HienThi(dateTuNgay.SelectedDate.Value, dateDenNgay.SelectedDate.Value);
            lbStatus.Content = "Danh sách hóa đơn từ " + dateTuNgay.SelectedDate.Value.ToString("dd-MM-yyyy") + " đến " + dateDenNgay.SelectedDate.Value.ToString("dd-MM-yyyy");
            cboThang.SelectedIndex = 0;
        }

        //dg loading row
        private void dgDsHoaDon_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = (e.Row.GetIndex() + 1).ToString();
        }

        //Nút reset
        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            UserControl_Loaded(sender, e);
        }

        //Nút chi tiết
        private void btnXemChiTiet_Click(object sender, RoutedEventArgs e)
        {
            string _soHD = (dgDsHoaDon.SelectedItem as ThongKeTheoHoaDonPublic).HoaDon.SoHD_HD;

            ChiTietHoaDonPresentation wpf = new ChiTietHoaDonPresentation();
            wpf._soHD = _soHD;
            wpf.ShowDialog();
        }

        //Nút in
        private void btnIn_Click(object sender, RoutedEventArgs e)
        {
            if (_lstKetQuaThongKe == null)
            {
                MessageBox.Show("Không có hóa đơn nào!");
                return;
            }
            if (_lstKetQuaThongKe.Count == 0)
            {
                MessageBox.Show("Không có hóa đơn nào!");
                return;
            }

            //Chuẩn bị database
            Pos_ds _PosDs = new Pos_ds();
            DataTable _dtThongKeHD = _PosDs.tbl_THONGKETHEOHOADON;
            DataRow _drThongKeHD;

            foreach (ThongKeTheoHoaDonPublic _thongkeHD in _lstKetQuaThongKe)
            {
                _drThongKeHD = _dtThongKeHD.NewRow();

                _drThongKeHD["SoHD"] = _thongkeHD.HoaDon.SoHD_HD;
                _drThongKeHD["NgayLap"] = _thongkeHD.HoaDon.NgayLap_HD.ToString("dd-MM-yyyy HH:mm");
                _drThongKeHD["TongThu"] = _thongkeHD.TongThu;
                _drThongKeHD["TongLoiNhuan"] = _thongkeHD.TongLoiNhuan;

                _dtThongKeHD.Rows.Add(_drThongKeHD);
            }

            //Hiển thị report
            ThongKeTheoHoaDon_Presentation wpf = new ThongKeTheoHoaDon_Presentation();
            wpf._dtThongKeHD = _dtThongKeHD;
            wpf._status_para = lbStatus.Content.ToString();
            wpf._TongThu = lbTongThu.Content.ToString();
            wpf._TongLoiNhuan = lbTongLai.Content.ToString();
            wpf.ShowDialog();
        }

        //Nút xóa
        private void btnXoa_Click(object sender, RoutedEventArgs e)
        {
            HoaDonPublic _hoaDon = (dgDsHoaDon.SelectedItem as ThongKeTheoHoaDonPublic).HoaDon; ;
            if (MessageBox.Show("Hóa đơn không thể khôi phục lại sau khi xóa bạn có chắc muốn xóa hóa đơn này?", "Xác nhận xóa", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                TraHangBusiness.HuyHoaDon(_hoaDon);
                UserControl_Loaded(sender, e);
            }
        }

        //Nút Hôm nay
        private void btnHomNay_Click(object sender, RoutedEventArgs e)
        {
            HienThi(DateTime.Today, DateTime.Today);
            lbStatus.Content = "Danh sách hóa đơn bán hàng ngày " + DateTime.Today.ToString("dd-MM-yyyy") + ".";
            cboThang.SelectedIndex = 0;
        }

        //Cbo tháng selected
        private void cboThang_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string _thang = cboThang.SelectedValue.ToString();
            if (!_thang.Equals(""))
            {
                DateTime _dtToDay = DateTime.Today;
                int _year = _dtToDay.Year;
                int _month = Convert.ToInt16(_thang);

                DateTime _dtNgayDauThang = new DateTime(_year, _month, 1, 0, 0, 0);
                DateTime _dtNgayCuoiThang = NgaycuoiThang(_year, _month);
                HienThi(_dtNgayDauThang, _dtNgayCuoiThang);
                lbStatus.Content = "Danh sách hóa đơn trong tháng " + _thang + "/" + _year + ".";
            }
        }

        //Lấy ngày cuối tháng
        public DateTime NgaycuoiThang(int _year, int _month)
        {
            return new DateTime(_year, _month, DateTime.DaysInMonth(_year, _month), 23, 59, 59);
        }
    }//End class
}

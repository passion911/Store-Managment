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
    /// Interaction logic for ThongKeTheoNhanVienUPresentation.xaml
    /// </summary>
    public partial class ThongKeTheoNhanVienUPresentation : UserControl
    {

        //Khai báo
        BackgroundWorker _worker;
        List<ThongKeTheoNhanVienPublic> _lstKqThongKeNV;

        public ThongKeTheoNhanVienUPresentation()
        {
            InitializeComponent();
            cboThang.ItemsSource = ThongKeBusiness.DsThang();
        }

        //wpf loaded
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            DateTime _toDay = DateTime.Now;
            DateTime _TuNgay = new DateTime(_toDay.Year, _toDay.Month, 1, 0, 0, 0);
            DateTime _DenNgay = new DateTime(_toDay.Year, _toDay.Month, _toDay.Day, 23, 59, 59);

            dateTuNgay.SelectedDate = _TuNgay;
            dateDenNgay.SelectedDate = _DenNgay;

            HienThi(dateTuNgay.SelectedDate.Value, dateDenNgay.SelectedDate.Value);
            lbStatus.Content = "Doanh thu theo từng nhân viên từ " + dateTuNgay.SelectedDate.Value.ToString("dd-MM-yyyy") + " đến " + dateDenNgay.SelectedDate.Value.ToString("dd-MM-yyyy");
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
            _lstKqThongKeNV = ThongKeBusiness.ThongKeTheoNhanVien(_TuNgay, _DenNgay);
        }

        //Hiển thị worker complete
        private void HienThi_complete(object sender, RunWorkerCompletedEventArgs e)
        {
            //Hiển thị
            dgDsNhanVien.ItemsSource = _lstKqThongKeNV;
            dgDsNhanVien.Items.Refresh();


            //Tính tổng thu - tổng lãi
            int _TongThu = 0;
            int _TongLai = 0;
            if (_lstKqThongKeNV != null)
                for (int i = 0; i < _lstKqThongKeNV.Count; i++)
                {
                    _TongThu = _TongThu + Convert.ToInt32(UntilitiesBusiness.BoDauPhay(_lstKqThongKeNV[i].TongThu));
                    _TongLai = _TongLai + Convert.ToInt32(UntilitiesBusiness.BoDauPhay(_lstKqThongKeNV[i].TongLoiNhuan));
                }

            lbTongThu.Content = UntilitiesBusiness.ThemDauPhay(_TongThu.ToString());
            lbTongLai.Content = UntilitiesBusiness.ThemDauPhay(_TongLai.ToString());

            //Ẩn progress
            bdProgress.Visibility = System.Windows.Visibility.Collapsed;
        }

        //dg loading row
        private void dgDsNhanVien_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = (e.Row.GetIndex() + 1).ToString();
        }

        //Nút xem
        private void btnXem_Click(object sender, RoutedEventArgs e)
        {
            HienThi(dateTuNgay.SelectedDate.Value, dateDenNgay.SelectedDate.Value);
            lbStatus.Content = "Doanh thu theo từng nhân viên từ " + dateTuNgay.SelectedDate.Value.ToString("dd-MM-yyyy") + " đến " + dateDenNgay.SelectedDate.Value.ToString("dd-MM-yyyy");
        }

        //Nút reset
        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            UserControl_Loaded(sender, e);
        }

        //Nút In
        private void btnIn_Click(object sender, RoutedEventArgs e)
        {
            if (_lstKqThongKeNV == null)
            {
                MessageBox.Show("Không có nhân viên nào!");
                return;
            }
            if (_lstKqThongKeNV.Count == 0)
            {
                MessageBox.Show("Không có nhân viên nào!");
                return;
            }

            //Chuẩn bị database
            Pos_ds _PosDs = new Pos_ds();
            DataTable _dtThongKeNV = _PosDs.tbl_THONGKETHEONHANVIEN;
            DataRow _drThongKeNV;

            foreach (ThongKeTheoNhanVienPublic _thongkeHD in _lstKqThongKeNV)
            {
                _drThongKeNV = _dtThongKeNV.NewRow();

                _drThongKeNV["MaNV"] = _thongkeHD.NhanVien.MaNV_NV;
                _drThongKeNV["TenNV"] = _thongkeHD.NhanVien.HoTen_NV;
                _drThongKeNV["SoHDBanDuoc"] = _thongkeHD.TongSoHDBanDuoc;
                _drThongKeNV["TongThu"] = _thongkeHD.TongThu;
                _drThongKeNV["TongLoiNhuan"] = _thongkeHD.TongLoiNhuan;

                _dtThongKeNV.Rows.Add(_drThongKeNV);
            }

            //Hiển thị report
            ThongKeTheoNhanVien_Presentation wpf = new ThongKeTheoNhanVien_Presentation();
            wpf._dtThongKeNV = _dtThongKeNV;
            wpf._status_para = lbStatus.Content.ToString();
            wpf.ShowDialog();
        }

        //Nút xem chi tiết
        private void btnXemChiTiet_Click(object sender, RoutedEventArgs e)
        {
            NhanVienPublic _NhanVien = (dgDsNhanVien.SelectedItem as ThongKeTheoNhanVienPublic).NhanVien;
            ThongKeTheoNhanVienChiTietPresentation wpf = new ThongKeTheoNhanVienChiTietPresentation();
            wpf._NhanVien = _NhanVien;
            wpf.ShowDialog();
        }

        //Nút hôm nay
        private void btnHomNay_Click(object sender, RoutedEventArgs e)
        {
            DateTime _dtToDay = DateTime.Today;
            HienThi(_dtToDay, _dtToDay);
            lbStatus.Content = "Doanh thu theo nhân viên ngày " + _dtToDay.ToString("dd-MM-yyyy");
        }

        //Cbo tháng selection change
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
                lbStatus.Content = "Doanh thu theo nhân viên tháng " + _thang + "/" + _year + ".";
            }
        }
        //Lấy ngày cuối tháng
        public DateTime NgaycuoiThang(int _year, int _month)
        {
            return new DateTime(_year, _month, DateTime.DaysInMonth(_year, _month), 23, 59, 59);
        }
    }//end class
}

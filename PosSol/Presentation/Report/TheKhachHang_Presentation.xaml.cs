using System.Windows;
using CrystalDecisions.CrystalReports.Engine;
using Public;
using Business;
using System.ComponentModel;

namespace Presentation.Report
{
    /// <summary>
    /// Interaction logic for TheKhachHang_Presentation.xaml
    /// </summary>
    public partial class TheKhachHang_Presentation : Window
    {
        //Khai báo
        public ThietLapHeThongPublic _thietLap = ThietLapHeThongBusiness.LayThietLapHeThong();
        public string _MaKH;
        BackgroundWorker _worker;
        ReportDocument _report;

        public TheKhachHang_Presentation()
        {
            InitializeComponent();
        }

        //wpf loaded
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //Hiển thị tiến trình
            bdProgress.Visibility = System.Windows.Visibility.Visible;

            //Gọi tiến trình xử lý
            _worker = new BackgroundWorker();
            _worker.DoWork += (obj, ex) => Loaded_dowork();
            _worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(Loaded_complete);
            _worker.RunWorkerAsync();
        }
        private void Loaded_dowork()
        {
            //Lấy thông tin in hóa đơn
            _report = new ReportDocument();
            _report.Load("../../Report/TheKhachHang_rpt.rpt");

            _report.SetParameterValue("MaKH_para", _MaKH);
            _report.SetParameterValue("TenCuaHang_para", _thietLap.TenCuaHang);
            _report.SetParameterValue("DiaChi_para", _thietLap.DiaChi);
            _report.SetParameterValue("SDT_para", _thietLap.SDT);
        }
        //Loaded complete
        private void Loaded_complete(object sender, RunWorkerCompletedEventArgs e)
        {
            //crvTheKhachHang.ViewerCore.ReportSource = _report;

            //Ẩn tiến trình
            bdProgress.Visibility = System.Windows.Visibility.Hidden;
        }
    }//End class
}

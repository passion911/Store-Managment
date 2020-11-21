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
using System.Data;
using System.ComponentModel;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace Presentation.Report
{
    /// <summary>
    /// Interaction logic for ThongKeTheoSanPham_Presentation.xaml
    /// </summary>
    public partial class ThongKeTheoSanPham_Presentation : Window
    {
        //Khai báo
        public DataTable _dtThongKeSP;
        BackgroundWorker _worker;
        ReportDocument _report;
        public string _status_para;
        public ThongKeTheoSanPham_Presentation()
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
        //Loaded dowork
        private void Loaded_dowork()
        {
            //Lấy thông tin in hóa đơn
            _report = new ReportDocument();
            _report.Load("../../Report/ThongKeTheoSanPham_rpt.rpt");

            _report.Database.Tables["tbl_THONGKETHEOSANPHAM"].SetDataSource(_dtThongKeSP);
            _report.SetParameterValue("status_para", _status_para);
        }
        //Loaded complete
        private void Loaded_complete(object sender, RunWorkerCompletedEventArgs e)
        {
            //Hiển thị dữ liệu sản phẩm
            //crvThongKeTheoSP.ViewerCore.ReportSource = _report;

            //Ẩn tiến trình
            bdProgress.Visibility = System.Windows.Visibility.Hidden;
        }


    }//End class
}

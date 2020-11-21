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
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using Presentation.Report.Dataset;

namespace Presentation.Report
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        private readonly object crystalReportsViewer1;

        //Khai báo
        public DataTable _dt;
        public Window1()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //ReportViewerDemo.Reset();

            //ReportDataSource ds = new ReportDataSource("DataSet1",_dt);
            //ReportViewerDemo.LocalReport.DataSources.Add(ds);
            //ReportViewerDemo.LocalReport.ReportEmbeddedResource = "Presentation.Report.Report1.rdlc";
            //ReportViewerDemo.RefreshReport();


            ReportDocument report = new ReportDocument();
            report.Load("../../Report/CrystalReport1.rpt");

            Barcode barcodedetail = new Barcode();
            DataTable _dt = barcodedetail._Barcode;

            CrystalReport1 _report = new CrystalReport1();
            int blank_labels = 0;
            int numberofLabels = 6;
            for (int i = 0; i < numberofLabels; i++)
            {
                DataRow drow = _dt.NewRow();
                string P_name = "DETAIL" + i.ToString();
                if (blank_labels <= i)
                {
                    drow["Barcode"] = "*";
                    drow["Barcode"] += P_name;
                    drow["Barcode"] += "*";

                    drow["ProductId"] = P_name;
                    drow["ProductName"] = "Details of " + i.ToString();
                    drow["Cost"] = "Rs 110" + i.ToString() + "/-";
                    drow["Code"] = "ABCDE" + i.ToString();
                    drow["ShopName"] = "Shop Name";
                }
                _dt.Rows.Add(drow);
            }
          //  MessageBox.Show(_dt.Rows.Count.ToString());
            report.Database.Tables["Barcode"].SetDataSource(_dt);

            //crystalReportsViewer1.ViewerCore.ReportSource = report;
        }
    }
}

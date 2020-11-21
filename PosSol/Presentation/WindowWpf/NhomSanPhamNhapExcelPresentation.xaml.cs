using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
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

namespace Presentation.WindowWpf
{
    /// <summary>
    /// Interaction logic for NhomSanPhamNhapExcelPresentation.xaml
    /// </summary>
    public partial class NhomSanPhamNhapExcelPresentation : Window
    {
        public event EventHandler NhapExcel;
        public string DuongDan;

        public NhomSanPhamNhapExcelPresentation()
        {
            InitializeComponent();
        }

        //Chọn file excel
        private void btnChonFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Excel Files(2003)|*xls|Excel Files(2007)|*.xlsx";
            open.Title = "Chọn file Excel";

            if (open.ShowDialog() == true)
            {
                txtDuongDan.Text = open.FileName;
                DuongDan = open.FileName;
            }
        }

        //Nút Nhập
        private void btnNhap_Click(object sender, RoutedEventArgs e)
        {
            EventHandler eh = NhapExcel;
            if (eh != null)
                eh(this, e);
            this.Close();
        }

        //Hủy
        private void btnHuy_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }//end class
}

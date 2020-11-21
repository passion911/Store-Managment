using Microsoft.Win32;
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

namespace Presentation.WindowWpf
{
    /// <summary>
    /// Interaction logic for SanPhamNhapExcelPresentation.xaml
    /// </summary>
    public partial class SanPhamNhapExcelPresentation : Window
    {
        //Khai báo
        public event EventHandler _NhapExcel;
        public string _DuongDan;

        public SanPhamNhapExcelPresentation()
        {
            InitializeComponent();
        }

        //Chọn file
        private void btnChonDuongDan_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Excel Files(2003)|*xls|Excel Files(2007)|*.xlsx";
            open.Title = "Chọn file Excel";

            if (open.ShowDialog() == true)
            {
                txtDuongDan.Text = open.FileName;
                _DuongDan = open.FileName;
            }
        }

        //Nút Ok
        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            EventHandler _eh = _NhapExcel;
            if (_eh != null)
                _eh(this, e);
            this.Close();
        }

        //Hủy
        private void btnHuy_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }//End class
}

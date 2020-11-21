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
    /// Interaction logic for NhapMua_NhapTuExcelPresentation.xaml
    /// </summary>
    public partial class NhapMua_NhapTuExcelPresentation : Window
    {
        //Khai báo
        public event EventHandler _NhapExcel;
        public string _Excel;

        public NhapMua_NhapTuExcelPresentation()
        {
            InitializeComponent();
        }

        //Nút hủy
        private void btnHuy_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        //Chọn file excel
        private void btnChonFileExcel_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Excel Files(2003)|*xls|Excel Files(2007)|*.xlsx";
            open.Title = "Chọn file Excel";
            
            if (open.ShowDialog() == true)
            {
                txtDuongDan.Text = open.FileName;
                _Excel = open.FileName;
            }
        }

        //Nút OK
        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            //Kiểm tra file excel
            if(!System.IO.File.Exists(_Excel))
            {
                MessageBox.Show("File Excel không tồn tại. Vui lòng chọn lại file Excel");
                return;
            }

            //Gọi phương thức nhập từ excel
            EventHandler _eh = _NhapExcel;
            if (_eh != null)
                _eh(this, e);
            this.Close();
        }
    }//End class
}

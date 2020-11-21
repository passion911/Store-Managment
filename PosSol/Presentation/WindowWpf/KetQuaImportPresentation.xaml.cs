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
namespace Presentation.WindowWpf
{
    /// <summary>
    /// Interaction logic for KetQuaImportPresentation.xaml
    /// </summary>
    public partial class KetQuaImportPresentation : Window
    {
        //Khai báo
        public int _TongBanGhi;
        public int _ThanhCong;
        public int _ThatBai;
        public KetQuaImportPresentation()
        {
            InitializeComponent();
        }

        //OK
        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            txtbTongBanGhi.Text = _TongBanGhi.ToString();
            txtbSoBanGhiThanhCong.Text = _ThanhCong.ToString();
            txtbSoBanGhiThatBai.Text = _ThatBai.ToString();
        }
    }//End class
}

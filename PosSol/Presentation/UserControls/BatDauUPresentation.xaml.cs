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
using System.Windows.Threading;

namespace Presentation.UserControls
{
    /// <summary>
    /// Interaction logic for BatDauUPresentation.xaml
    /// </summary>
    /// 
    public partial class BatDauUPresentation : UserControl
    {
        //Khai báo
        public bool _DangNhap;
        public int _ChucNang;
        public event EventHandler _ChonChucNang;

        public BatDauUPresentation()
        {
            InitializeComponent();
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_Tick;
            timer.Start();
        }
        //Timer hiển thị thời gian
        void timer_Tick(object sender, EventArgs e)
        {
            lbNgay.Content = DateTime.Now.ToString("dd-MM-yyyy");
            lbGio.Content = DateTime.Now.ToString("HH:mm:ss tt");
        }

        //WPF loaded
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            btnDangNhap.IsEnabled = !_DangNhap;
            btnDangXuat.IsEnabled = !btnDangNhap.IsEnabled;
        }

        //Đăng nhập 
        private void btnDangNhap_Click(object sender, RoutedEventArgs e)
        {
            //Gọi phương thức chọn chức năng
            _ChucNang = 1;
            EventHandler _eh = _ChonChucNang;
            if (_eh != null)
                _eh(this, e);
        }

        private void btnDangXuat_Click(object sender, RoutedEventArgs e)
        {
            //Gọi phương thức chọn chức năng
            _ChucNang = 2;
            EventHandler _eh = _ChonChucNang;
            if (_eh != null)
                _eh(this, e);
        }
    }//End class
}

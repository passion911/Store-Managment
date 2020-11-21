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
using Public;
using System.Windows.Threading;


namespace Presentation.UserControls
{
    /// <summary>
    /// Interaction logic for BanHang_KH_UPresentation.xaml
    /// </summary>
    public partial class BanHang_KH_UPresentation : UserControl
    {
        //Khai báo
        public KhachHangPublic _kh = new KhachHangPublic();
        TimePublic _time;
        DispatcherTimer timer;
        public event EventHandler _XoaKH;

        public BanHang_KH_UPresentation()
        {
            InitializeComponent();
        }
        //Loaded
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            string _strPic = "../../Image/NhomKhachhang/" + _kh.NHK_KH.Anh_NKH;
            if (System.IO.File.Exists(_strPic))
            {
                _strPic = System.IO.Path.GetFullPath(_strPic);
                BitmapImage _bit = new BitmapImage(new Uri(_strPic));
                picNKH.Source = _bit;
                picNKH.ToolTip = _kh.NHK_KH.TenNKH_NKH + ": Chiết khấu " + _kh.NHK_KH.ChietKhau_NKH.ToString() + "% / Tổng hóa đơn.";
            }

            txtbTen.Text = _kh.HoTen_KH;
            txtDiemTichLuy.Text = _kh.DiemTichLuy_KH.ToString();
            txtbSoLanMuaHang.Text = _kh.SoLanMuaHang_KH.ToString();

            if (_kh.SoLanMuaHang_KH == 0)
                txtbLanMuaGanNhat.Text = "--/--/--";
            else
                txtbLanMuaGanNhat.Text = _kh.LanMuaHangGanNhat_KH.ToString("dd-MM-yyyy");

            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_Tick;
            timer.Start();

            DateTime _dtSN = new DateTime(DateTime.Now.Year, _kh.NgaySinh_KH.Month, _kh.NgaySinh_KH.Day, 0, 0, 0);
            _time = TimePublic.GetTimeRemaining(_dtSN);
            if (_time.Hour < 0)
            {
                _dtSN = new DateTime(DateTime.Now.Year + 1, _kh.NgaySinh_KH.Month, _kh.NgaySinh_KH.Day, 0, 0, 0);
                _time = TimePublic.GetTimeRemaining(_dtSN);
            }
        }

        void timer_Tick(object sender, EventArgs e)
        {
            txtbThongBao.Text = "Còn " + _time.Day.ToString() + " ngày, " + _time.Hour.ToString() + " : " + _time.Minute.ToString() + " : " + _time.Second.ToString() + " đến sinh nhật";

            if (_time.Hour > 0)
            {
                if (_time.Minute > 0)
                {
                    if (_time.Second > 0)
                    {
                        _time.Second--;
                    }
                    else
                    {
                        _time.Second = 59;
                        _time.Minute--;
                    }
                }
                else
                {
                    _time.Minute = 59;
                    _time.Hour--;
                }

            }
            else
                if (_time.Hour == 0)
                {
                    if (_time.Minute > 0)
                    {
                        if (_time.Second > 0)
                        {
                            _time.Second--;
                        }
                        else
                        {
                            _time.Second = 59;
                            _time.Minute--;
                        }
                    }
                    else
                    {
                        _time.Second--;
                    }

                }

            if (_time.Hour == 0 && _time.Minute == 0 && _time.Second == 0)
            {
                timer.Stop();
            }

        }

        //Hủy click
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            EventHandler _eh = _XoaKH;
            if (_eh != null)
                _eh(this, e);
        }
    }//End class
}

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
using Business;
using System.ComponentModel;
using DataAccess;
using Presentation.Dataset;
using Presentation.Report;
using Public;
using System.Data;

namespace Presentation.UserControls
{
    /// <summary>
    /// Interaction logic for ThongKeTheoSpUPresentation.xaml
    /// </summary>
    public partial class ThongKeTheoSpUPresentation : UserControl
    {
        //Khai báo
        BackgroundWorker _worker;
        List<ThongKeTheoSanPham> _lstKetQuaThongKe;

        public ThongKeTheoSpUPresentation()
        {
            InitializeComponent();
            cboThang.ItemsSource = ThongKeBusiness.DsThang();
        }

        //wpf loaded
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            DateTime _toDay = DateTime.Today;
            dateTuNgay.SelectedDate = new DateTime(_toDay.Year, _toDay.Month, 1, 0, 0, 0);
            dateDenNgay.SelectedDate = _toDay;

            //Hiển thị cbo
            List<NhomSanPhamPublic> _lstNhomSP = KiemKeBusiness.LayNSP();
            cboNhomSanPham.ItemsSource = _lstNhomSP;
            cboNhomSanPham.SelectedIndex = 0;
            HienThi(cboNhomSanPham.SelectedValue.ToString(), dateTuNgay.SelectedDate.Value, dateDenNgay.SelectedDate.Value);
            string _str;
            if (cboNhomSanPham.SelectedValue.ToString() != "")
                _str = "Doanh thu theo sản phẩm từ " + dateTuNgay.SelectedDate.Value.ToString("dd-MM-yy") + " đến " + dateDenNgay.SelectedDate.Value.ToString("dd-MM-yy") + "( Nhóm sản phẩm: " + (cboNhomSanPham.SelectedItem as NhomSanPhamPublic).TenNSP_NSP + " )";
            else
                _str = "Doanh thu theo sản phẩm từ " + dateTuNgay.SelectedDate.Value.ToString("dd-MM-yy") + " đến " + dateDenNgay.SelectedDate.Value.ToString("dd-MM-yy") + "( Tất cả sản phẩm )";
            lbStatus.Content = _str;
        }

        //Hiển thị dữ liệu
        private void HienThi(string _MaNSP, DateTime _TuNgay, DateTime _DenNgay)
        {
            //Hiển thị progress
            bdProgress.Visibility = System.Windows.Visibility.Visible;

            //Tiến trình xử lý
            _worker = new BackgroundWorker();
            _worker.DoWork += (obj, ea) => HienThi_dowork(_MaNSP, _TuNgay, _DenNgay);
            _worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(HienThi_complete);
            _worker.RunWorkerAsync();
        }

        //Hiển thị worker do work
        private void HienThi_dowork(string _MaNSP, DateTime _TuNgay, DateTime _DenNgay)
        {
            //Lấy dữ liệu
            _lstKetQuaThongKe = ThongKeBusiness.ThongKeTheoSanPham(_MaNSP, _TuNgay, _DenNgay);
        }

        //Hiển thị worker complete
        private void HienThi_complete(object sender, RunWorkerCompletedEventArgs e)
        {
            //Hiển thị
            dgDSSP.ItemsSource = _lstKetQuaThongKe;
            dgDSSP.Items.Refresh();

            //Tính tổng thu - tổng lãi
            int _TongThu = 0;
            int _TongLai = 0;
            if (_lstKetQuaThongKe != null)
                for (int i = 0; i < _lstKetQuaThongKe.Count; i++)
                {
                    _TongThu = _TongThu + Convert.ToInt32(UntilitiesBusiness.BoDauPhay(_lstKetQuaThongKe[i].TongThu));
                    _TongLai = _TongLai + Convert.ToInt32(UntilitiesBusiness.BoDauPhay(_lstKetQuaThongKe[i].TongLai));
                }
            lbSoSpBan.Content = _lstKetQuaThongKe.Sum(item => item.TongSoLuongBan).ToString();
            lbTongThu.Content = UntilitiesBusiness.ThemDauPhay(_TongThu.ToString());
            lbTongLai.Content = UntilitiesBusiness.ThemDauPhay(_TongLai.ToString());

            //Ẩn progress
            bdProgress.Visibility = System.Windows.Visibility.Collapsed;
        }

        //Nút xem
        private void btnXem_Click(object sender, RoutedEventArgs e)
        {
            HienThi(cboNhomSanPham.SelectedValue.ToString(), dateTuNgay.SelectedDate.Value, dateDenNgay.SelectedDate.Value);
            string _str;
            if (cboNhomSanPham.SelectedValue.ToString() != "")
                _str = "Doanh thu theo sản phẩm từ " + dateTuNgay.SelectedDate.Value.ToString("dd-MM-yy") + " đến " + dateDenNgay.SelectedDate.Value.ToString("dd-MM-yy") + "( Nhóm sản phẩm: " + (cboNhomSanPham.SelectedItem as NhomSanPhamPublic).TenNSP_NSP + " )";
            else
                _str = "Doanh thu theo sản phẩm từ " + dateTuNgay.SelectedDate.Value.ToString("dd-MM-yy") + " đến " + dateDenNgay.SelectedDate.Value.ToString("dd-MM-yy") + "( Tất cả sản phẩm )";
            lbStatus.Content = _str;
            cboThang.SelectedIndex = 0;
        }

        //Nút reset
        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            UserControl_Loaded(sender, e);
        }

        //Nút in
        private void btnIn_Click(object sender, RoutedEventArgs e)
        {
            //Chuẩn bị database
            Pos_ds _PosDs = new Pos_ds();
            DataTable _dtThongKeSP = _PosDs.tbl_THONGKETHEOSANPHAM;
            DataRow _drThongKeSP;

            foreach (ThongKeTheoSanPham _thongkeSp in _lstKetQuaThongKe)
            {
                _drThongKeSP = _dtThongKeSP.NewRow();

                _drThongKeSP["MaSP"] = _thongkeSp.Sanpham.MaSP_SP;
                _drThongKeSP["TenSP"] = _thongkeSp.Sanpham.TenSP_SP;
                _drThongKeSP["SoLuongBan"] = _thongkeSp.TongSoLuongBan;
                _drThongKeSP["TongThu"] = _thongkeSp.TongThu;
                _drThongKeSP["TongLai"] = _thongkeSp.TongLai;

                _dtThongKeSP.Rows.Add(_drThongKeSP);
            }

            //Hiển thị report
            ThongKeTheoSanPham_Presentation wpf = new ThongKeTheoSanPham_Presentation();
            wpf._dtThongKeSP = _dtThongKeSP;
            wpf._status_para = lbStatus.Content.ToString();
            wpf.ShowDialog();
        }

        //datagrid Loadding rows
        private void dgDSSP_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = (e.Row.GetIndex() + 1).ToString();
        }

        //Nút hôm nay
        private void btnHomNay_Click(object sender, RoutedEventArgs e)
        {
            DateTime _dtToday = DateTime.Today;
            HienThi(cboNhomSanPham.SelectedValue.ToString(), _dtToday, _dtToday);

            string _str;
            if (cboNhomSanPham.SelectedValue.ToString() != "")
                _str = "Doanh thu theo sản phẩm ngày " + _dtToday.ToString("dd-MM-yy") + " ( Nhóm sản phẩm: " + (cboNhomSanPham.SelectedItem as NhomSanPhamPublic).TenNSP_NSP + " )";
            else
                _str = "Doanh thu theo sản phẩm ngày " + _dtToday.ToString("dd-MM-yy") + " ( Tất cả sản phẩm )";
            lbStatus.Content = _str;
            cboThang.SelectedIndex = 0;
        }

        //cbo tháng selecttion change
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

                HienThi(cboNhomSanPham.SelectedValue.ToString(), _dtNgayDauThang, _dtNgayCuoiThang);

                string _str;
                if (cboNhomSanPham.SelectedValue.ToString() != "")
                    _str = "Doanh thu theo sản phẩm trong tháng " + _thang + "/" + _year.ToString() + " ( Nhóm sản phẩm: " + (cboNhomSanPham.SelectedItem as NhomSanPhamPublic).TenNSP_NSP + " )";
                else
                    _str = "Doanh thu theo sản phẩm trong tháng " + _thang + "/" + _year.ToString() + " ( Tất cả sản phẩm )";
                lbStatus.Content = _str;

            }
        }

        //Lấy ngày cuối tháng
        public DateTime NgaycuoiThang(int _year, int _month)
        {
            return new DateTime(_year, _month, DateTime.DaysInMonth(_year, _month), 23, 59, 59);
        }

    }//End class
}

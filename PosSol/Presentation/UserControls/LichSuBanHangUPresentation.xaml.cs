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
using Public;
using System.ComponentModel;
using Presentation.WindowWpf;

namespace Presentation.UserControls
{
    /// <summary>
    /// Interaction logic for LichSuBanHangUPresentation.xaml
    /// </summary>
    public partial class LichSuBanHangUPresentation : UserControl
    {
        //Khai báo
        BackgroundWorker _worker;
        List<LichSuBanHangPublic> _lstLSBH;

        public LichSuBanHangUPresentation()
        {
            InitializeComponent();
        }

        //Loaded
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            //Hiển thị trên datePicker ngày hiên thời và trước đó 1 tháng
            DateTime _toDay = DateTime.Today;
            dateTuNgay.SelectedDate = new DateTime(_toDay.Year, _toDay.Month, 1, 0, 0, 0);
            dateDenNgay.SelectedDate = _toDay;

            dateTuNgay.DisplayDateEnd = _toDay;
            dateDenNgay.DisplayDateEnd = _toDay;

            LayDuLieu(dateTuNgay.SelectedDate.Value, dateDenNgay.SelectedDate.Value);
            lbStatus.Content = "Lịch sử bán hàng từ ngày " + dateTuNgay.SelectedDate.Value.ToString("dd-MM-yyyy") + " đến " + dateDenNgay.SelectedDate.Value.ToString("dd-MM-yyyy") + ".";
        }

        private void LayDuLieu(DateTime _dtTuNgay, DateTime _dtDenNgay)
        {
            //Hiển thị progress
            bdProgress.Visibility = System.Windows.Visibility.Visible;

            //Tiến trình xử lý
            _worker = new BackgroundWorker();
            _worker.DoWork += (obj, ea) => LayDuLieu_dowork(_dtTuNgay, _dtDenNgay);
            _worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(LayDuLieu_complete);
            _worker.RunWorkerAsync();
        }
        //LayDuLieu worker dowork
        private void LayDuLieu_dowork(DateTime _dtTuNgay, DateTime _dtDenNgay)
        {
            if (_lstLSBH == null)
                _lstLSBH = new List<LichSuBanHangPublic>();
            _lstLSBH = LichSuBanHangBusiness.LayLSBHTheoNgay(_dtTuNgay, _dtDenNgay);
        }

        //LayDuLieu worker complete
        private void LayDuLieu_complete(object sender, RunWorkerCompletedEventArgs e)
        {
            //Ẩn progress
            bdProgress.Visibility = System.Windows.Visibility.Collapsed;

            //Hiển thị thông tin

            dgLichSuBanHang.ItemsSource = _lstLSBH;
            dgLichSuBanHang.Items.Refresh();

            //Hiển thị tổng thu - tổng lãi

            int _TongThu = 0;
            int _TongLai = 0;
            int _TongNhap = 0;
            for (int i = 0; i < _lstLSBH.Count; i++)
            {
                if (!_lstLSBH[i].SoHD_LSBH.DangDung_HD)//Nếu hóa đơn trả (Dang dùng = false) thì bỏ qua ko tính vào tổng tiền
                    continue;
                _TongThu = _TongThu + _lstLSBH[i].SoHD_LSBH.TongTien_HD - _lstLSBH[i].SoHD_LSBH.TongCKHoaDon - _lstLSBH[i].SoHD_LSBH.TongCKSanPham - _lstLSBH[i].SoHD_LSBH.VouCher_HD - _lstLSBH[i].SoHD_LSBH.TienMaGiamGia;
                _TongNhap = _TongNhap + _lstLSBH[i].SoHD_LSBH.TongTienNhap;
            }
            _TongLai = _TongThu - _TongNhap;

            lbTongThu.Content = UntilitiesBusiness.ThemDauPhay(_TongThu.ToString());
            lbTongLai.Content = UntilitiesBusiness.ThemDauPhay(_TongLai.ToString());
        }

        //Nút xem
        private void btnXem_Click(object sender, RoutedEventArgs e)
        {
            LayDuLieu(dateTuNgay.SelectedDate.Value, dateDenNgay.SelectedDate.Value);
            lbStatus.Content = "Lịch sử bán hàng từ ngày " + dateTuNgay.SelectedDate.Value.ToString("dd-MM-yyyy") + " đến " + dateDenNgay.SelectedDate.Value.ToString("dd-MM-yyyy") + ".";
        }

        //Nút reset
        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            UserControl_Loaded(sender, e);
        }

        //Nút xem chi tiết
        private void btnXemChiTiet_Click(object sender, RoutedEventArgs e)
        {
            string _soHD = (dgLichSuBanHang.SelectedItem as LichSuBanHangPublic).SoHD_LSBH.SoHD_HD;

            ChiTietHoaDonPresentation wpf = new ChiTietHoaDonPresentation();
            wpf._soHD = _soHD;
            wpf.ShowDialog();
        }

        //datagrid loadding row
        private void dgLichSuBanHang_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = (e.Row.GetIndex() + 1).ToString();
        }

    }//End class
}

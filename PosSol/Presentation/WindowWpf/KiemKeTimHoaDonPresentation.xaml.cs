using System.Windows;
using Business;
using System.Data;
using System;
using System.Windows.Input;

namespace Presentation.WindowWpf
{
    /// <summary>
    /// Interaction logic for KiemKeTimHoaDonPresentation.xaml
    /// </summary>
    public partial class KiemKeTimHoaDonPresentation : Window
    {
        //Khai báo
        DataTable _dtHoaDon;
        public string _strTim;
        public event EventHandler _TimHoaDon;
        public string _soHD;

        public KiemKeTimHoaDonPresentation()
        {
            InitializeComponent();
        }

        //wpf loaded
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dateNgayLap.SelectedDate = DateTime.Today;

            _dtHoaDon = TraHangBusiness.DanhSachHoaDon();
            dgHoaDon.ItemsSource = _dtHoaDon.DefaultView;

            if (!String.IsNullOrEmpty(_strTim))
            {
                txtTimKiem.Text = _strTim;
                btnTim_Click(sender, e);
                txtTimKiem.SelectAll();
                txtTimKiem.Focus();
            }
        }

        //DG loadingrow
        private void dgHoaDon_LoadingRow(object sender, System.Windows.Controls.DataGridRowEventArgs e)
        {
            e.Row.Header = (e.Row.GetIndex() + 1).ToString();
        }

        //Nút reset
        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            _dtHoaDon = TraHangBusiness.DanhSachHoaDon();
            dgHoaDon.ItemsSource = _dtHoaDon.DefaultView;
            txtTimKiem.Text = "";
            dateNgayLap.SelectedDate = DateTime.Today;
        }

        //Nút tìm
        private void btnTim_Click(object sender, RoutedEventArgs e)
        {
            //Kiểm tra chuỗi tìm kiếm
            string _strTimKiem = txtTimKiem.Text.Trim();
            if (String.IsNullOrEmpty(_strTimKiem))
            {
                MessageBox.Show("Nhập chuỗi tìm kiếm.");
                txtTimKiem.Focus();
                return;
            }

            string _strKiemTra = @"^([a-zA-Z0-9.]*)$";
            if (!System.Text.RegularExpressions.Regex.IsMatch(_strTimKiem, _strKiemTra))
            {
                MessageBox.Show("Chuỗi tìm kiếm không chứa kí tự đặc biệt.");
                txtTimKiem.Focus();
                txtTimKiem.SelectAll();
                return;
            }

            DateTime _dtBatdau = new DateTime(dateNgayLap.SelectedDate.Value.Year, dateNgayLap.SelectedDate.Value.Month, dateNgayLap.SelectedDate.Value.Day, 0, 0, 0);
            DateTime _dtKetThuc = new DateTime(dateNgayLap.SelectedDate.Value.Year, dateNgayLap.SelectedDate.Value.Month, dateNgayLap.SelectedDate.Value.Day, 23, 59, 59);

            string _strFilter = "(SoHD_HD LIKE '%" + _strTimKiem + "%' OR NguoiLap_HD LIKE '%" + _strTimKiem + "%') OR ( NgayLap_HD >= #" + _dtBatdau.ToString() + "# AND NgayLap_HD <= #" + _dtKetThuc.ToString() + "#)";
            DataView _dv = new DataView(_dtHoaDon, _strFilter, "SoHD_HD", DataViewRowState.CurrentRows);
            dgHoaDon.ItemsSource = _dv;
        }

        //preview key down
        private void txtTimKiem_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                btnTim_Click(sender, e);
        }

        protected override void OnPreviewKeyDown(KeyEventArgs e)
        {
            if (e.Key == Key.F1)
                btnReset_Click(this, e);
            base.OnPreviewKeyDown(e);
        }

        //Nút hủy
        private void btnHuy_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        //Nút chọn
        private void btnChon_Click(object sender, RoutedEventArgs e)
        {
            DataRowView _drv = (DataRowView)dgHoaDon.SelectedItem;

            if (_drv == null)
            {
                MessageBox.Show("Chọn hóa đơn.");
                return;
            }
            _soHD = _drv["SoHD_HD"].ToString();

            EventHandler _eh = _TimHoaDon;
            if (_eh != null)
                _eh(this, e);
            this.Close();
        }
    }//End class
}

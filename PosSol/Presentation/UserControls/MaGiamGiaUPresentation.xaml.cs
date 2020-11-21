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
using System.Data;
using Business;
using System.ComponentModel;

namespace Presentation.UserControls
{
    /// <summary>
    /// Interaction logic for MaGiamGiaUPresentation.xaml
    /// </summary>
    public partial class MaGiamGiaUPresentation : UserControl
    {
        //Khai báo
        BackgroundWorker _worker;
        DataTable _dtMaGiamGia;

        public MaGiamGiaUPresentation()
        {
            InitializeComponent();
            lbwarning.Visibility = System.Windows.Visibility.Hidden;
            bdProgress.Visibility = System.Windows.Visibility.Hidden;
        }

        //Loaded
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            dateNgayHetHan.DisplayDateStart = DateTime.Today;
            HienThi();
        }

        //Hiển thị
        private void HienThi()
        {
            //hiển thị progress
            bdProgress.Visibility = System.Windows.Visibility.Visible;

            //tiến trình xử lý
            _worker = new BackgroundWorker();
            _worker.DoWork += (obj, ea) => HienThi_dowork();
            _worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(HienThi_complete);
            _worker.RunWorkerAsync();

        }
        //hiển thị dowork
        private void HienThi_dowork()
        {
            _dtMaGiamGia = MaGiamGiaBusiness.DsMaGiamGia();
        }
        //hiển thị complete
        private void HienThi_complete(object sender, RunWorkerCompletedEventArgs e)
        {
            //Ẩn tiến trình
            bdProgress.Visibility = System.Windows.Visibility.Hidden;

            //Hiển thị
            dgMaGiamGia.ItemsSource = _dtMaGiamGia.DefaultView;
        }


        //Loadding rows
        private void dgMaGiamGia_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = (e.Row.GetIndex() + 1).ToString();
        }

        //Nút tạo mã
        private void btnTao_Click(object sender, RoutedEventArgs e)
        {
            //Kiểm tra thông tin nhập vào
            if (!KiemTraDuLieu())
                return;
            //Tạo mã
            int _chietKhau = Convert.ToInt32(txtChietKhau.Text.Trim());
            int _soLuong = Convert.ToInt32(txtSoLuong.Text.Trim());
            DateTime _dtNgayHetHan = dateNgayHetHan.SelectedDate.Value;
            TaoMa(_chietKhau,_dtNgayHetHan,_soLuong);
            //HienThi();
        }


        //Tạo mã
        private void TaoMa(int _chietKhau, DateTime _dtNgayhethan, int _soLuong)
        {

            bdProgress.Visibility = System.Windows.Visibility.Visible;

            _worker = new BackgroundWorker();
            _worker.DoWork += (obj, ea) => TaoMa_dowork(_chietKhau, _dtNgayhethan, _soLuong);
            _worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(TaoMa_complete);
            _worker.RunWorkerAsync();
        }
        //Tạo mã dowork
        private void TaoMa_dowork(int _chietKhau, DateTime _dtNgayhethan, int _soLuong)
        {
            MaGiamGiaBusiness.TaoMaGiamGia(_chietKhau, _dtNgayhethan, _soLuong);
        }

        //Tạo mã complte
        private void TaoMa_complete(object sender, RunWorkerCompletedEventArgs e)
        {
            bdProgress.Visibility = System.Windows.Visibility.Hidden;
            _dtMaGiamGia = MaGiamGiaBusiness.DsMaGiamGia();
            dgMaGiamGia.ItemsSource = _dtMaGiamGia.DefaultView;
        }

        //Kiểm tra dữ liệu
        private bool KiemTraDuLieu()
        {
            string _chietKhau = txtChietKhau.Text.Trim();
            if (String.IsNullOrEmpty(_chietKhau))
            {
                lbwarning.Visibility = System.Windows.Visibility.Visible;
                lbwarning.Content = "Nhập chiết khấu.";
                txtChietKhau.Focus();
                return false;
            }

            string _strKiemTraChietKhau = @"^([0-9]*)$";
            if (!System.Text.RegularExpressions.Regex.IsMatch(_chietKhau, _strKiemTraChietKhau))
            {
                lbwarning.Visibility = System.Windows.Visibility.Visible;
                lbwarning.Content = "Sai đinh dạng chiết khấu.";
                txtChietKhau.Focus();
                txtChietKhau.SelectAll();
                return false;
            }

            string _soLuong = txtSoLuong.Text.Trim();
            if (String.IsNullOrEmpty(_soLuong))
            {
                lbwarning.Visibility = System.Windows.Visibility.Visible;
                lbwarning.Content = "Nhập số lượng mã muốn tạo.";
                txtSoLuong.Focus();
                return false;
            }

            string _strKiemTraSoLuong = @"^([0-9]*)$";
            if (!System.Text.RegularExpressions.Regex.IsMatch(_soLuong, _strKiemTraSoLuong))
            {
                lbwarning.Visibility = System.Windows.Visibility.Visible;
                lbwarning.Content = "Nhập số lượng mã muốn tạo.";
                txtSoLuong.Focus();
                txtSoLuong.SelectAll();
                return false;
            }

            if (dateNgayHetHan.SelectedDate == null)
            {
                lbwarning.Visibility = System.Windows.Visibility.Visible;
                lbwarning.Content = "Chọn ngày hết hạn.";
                dateNgayHetHan.Focus();
                return false;
            }

            lbwarning.Visibility = System.Windows.Visibility.Hidden;
            return true;
        }

        //Nút xóa
        private void btnXoa_Click(object sender, RoutedEventArgs e)
        {
            DataRowView _drv = (DataRowView)dgMaGiamGia.SelectedItem;

            string _maGianGia = _drv["MaGG_MGG"].ToString();
            if (MaGiamGiaBusiness.XoaMaGiamGia(_maGianGia))
            {
                lbwarning.Visibility = System.Windows.Visibility.Visible;
                lbwarning.Content = "Xóa thành công!";
                HienThi();
            }
            else
            {
                lbwarning.Visibility = System.Windows.Visibility.Visible;
                lbwarning.Content = "Thao tác thất bại!";
            }
        }
    }//end class
}

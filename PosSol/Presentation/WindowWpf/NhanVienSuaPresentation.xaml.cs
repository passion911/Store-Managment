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
using Public;
using System.IO;
using Microsoft.Win32;
using Business;

namespace Presentation.WindowWpf
{
    /// <summary>
    /// Interaction logic for NhanVienSuaPresentation.xaml
    /// </summary>
    public partial class NhanVienSuaPresentation : Window
    {
        //Include
        public event EventHandler _UpdateStaff;
        public NhanVienPublic _staff = new NhanVienPublic();

        public NhanVienSuaPresentation()
        {
            InitializeComponent();
            lbWarning.Visibility = System.Windows.Visibility.Hidden;
            cboNhomQuyen.ItemsSource = PhanQuyenBusiness.DanhSachQuyen();
        }

        //WPF LOADED
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //Display staff infomation
            txtMaNV.Text = _staff.MaNV_NV;
            txtHoTen.Text = _staff.HoTen_NV;
            txtSdt.Text = _staff.SDT_NV;
            dtNgaySinh.SelectedDate = _staff.NgaySinh_NV;
            rdNam.IsChecked = _staff.GioiTinh_NV == "NAM" ? true : false;
            rdNu.IsChecked = !rdNam.IsChecked;

            FlowDocument fDoc = new FlowDocument();
            fDoc.Blocks.Add(new Paragraph(new Run(_staff.DiaChi_NV)));
            rtxtDiaChi.Document = fDoc;

            cboNhomQuyen.SelectedValue = _staff.ID_Q;
            ckDangDung.IsChecked = _staff.DangDung_NV;

            if (!String.IsNullOrEmpty(_staff.Anh_NV))
                if (System.IO.File.Exists(_staff.Anh_NV))
                {
                    var _bit = new BitmapImage();
                    var _stream = File.OpenRead(_staff.Anh_NV);
                    _bit.BeginInit();
                    _bit.CacheOption = BitmapCacheOption.OnLoad;
                    _bit.StreamSource = _stream;
                    _bit.EndInit();
                    _stream.Close();
                    _stream.Dispose();

                    picNV.Source = _bit;
                }
        }

        //Button chose img click
        private void btnAnh_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog _open = new OpenFileDialog();
            _open.Filter = "Image files (*.png;*.jpeg;*.jpg)|*.png;*.jpeg;*.jpg|All files (*.*)|*.*";
            _open.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyComputer);
            if (_open.ShowDialog() == true)
            {
                _staff.Anh_NV = _open.FileName;
                BitmapImage bit = new BitmapImage(new Uri(_staff.Anh_NV));
                picNV.Source = bit;
            }
        }

        //Button cancel click
        private void btnHuy_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        //Buttin save click
        private void btnLuu_Click(object sender, RoutedEventArgs e)
        {
            #region 1. Check input data
            if (!KiemTraDuLieu())
                return;
            #endregion

            #region 2. Get data
            _staff.MaNV_NV = txtMaNV.Text.Trim().ToUpper();
            _staff.HoTen_NV = txtHoTen.Text.Trim().ToUpper();
            _staff.GioiTinh_NV = rdNam.IsChecked == true ? "NAM" : "NỮ";
            _staff.NgaySinh_NV = dtNgaySinh.SelectedDate.Value;
            _staff.SDT_NV = txtSdt.Text.Trim().ToUpper();
            rtxtDiaChi.SelectAll();
            _staff.DiaChi_NV = rtxtDiaChi.Selection.Text.Trim().ToUpper();

            _staff.ID_Q = cboNhomQuyen.SelectedValue.ToString();
            _staff.DangDung_NV = ckDangDung.IsChecked==true?true:false;
            #endregion

            #region 3. Call update_staff method
            EventHandler _eh = _UpdateStaff;
            if (_eh != null)
                _eh(this, e);
            this.Close();
            #endregion
        }
        //Kiểm tra dữ liệu nhập vào
        private bool KiemTraDuLieu()
        {
            //Kiểm tra họ tên
            string _HoTen = txtHoTen.Text.Trim();
            if (String.IsNullOrEmpty(_HoTen))
            {
                lbWarning.Visibility = System.Windows.Visibility.Visible;
                lbWarning.Content = "Nhập họ tên!";
                txtHoTen.Focus();
                return false;
            }

            if (_HoTen.Length > 35)
            {
                lbWarning.Visibility = System.Windows.Visibility.Visible;
                lbWarning.Content = "Họ tên chỉ dưới 35 kí tự";
                txtHoTen.Focus();
                txtHoTen.SelectionStart = txtHoTen.Text.Length;
                return false;
            }

            lbWarning.Visibility = System.Windows.Visibility.Hidden;
            return true;
        }
    }//END CLASS
}

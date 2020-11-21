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
using System.IO;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Public;
using Business;
using Microsoft.Win32;

namespace Presentation.WindowWpf
{
    /// <summary>
    /// Interaction logic for NhanVienThemPresentation.xaml
    /// </summary>
    public partial class NhanVienThemPresentation : Window
    {
        //KHAI BÁO
        public event EventHandler _ThemNhanVien;
        public NhanVienPublic _nv = new NhanVienPublic();
        public NhanVienThemPresentation()
        {
            InitializeComponent();
            lbWarning.Visibility = System.Windows.Visibility.Hidden;
            cboNhomQuyen.ItemsSource = PhanQuyenBusiness.DanhSachQuyen();
        }

        //NÚT LƯU
        private void btnLuu_Click(object sender, RoutedEventArgs e)
        {
            #region 1. Kiểm tra thông tin nhập vào
            if (!KiemTraDuLieu())
                return;
            #endregion

            #region 2. Lấy thông tin

            _nv.MaNV_NV = txtMaNV.Text.ToUpper().Trim();
            _nv.HoTen_NV = txtHoTen.Text.ToUpper().Trim();
            _nv.NgaySinh_NV = dtNgaySinh.SelectedDate.Value;
            _nv.GioiTinh_NV = rdNam.IsChecked == true ? "NAM" : "NỮ";

            rtxtDiaChi.SelectAll();
            _nv.DiaChi_NV = rtxtDiaChi.Selection.Text.Trim();
            _nv.SDT_NV = txtSdt.Text.Trim();

            if (_nv.Anh_NV == null)
                _nv.Anh_NV = "";

            _nv.MatKhau_NV = UntilitiesBusiness.MaHoaMD5(txtPass.Password);

            _nv.ID_Q = cboNhomQuyen.SelectedValue.ToString();
            _nv.DangDung_NV = ckDangDung.IsChecked == true ? true : false;

            #endregion

            #region 3. Gọi phương thức thêm nhân viên
            EventHandler _eh = _ThemNhanVien;
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

            if (cboNhomQuyen.SelectedValue == null)
            {
                lbWarning.Visibility = System.Windows.Visibility.Visible;
                lbWarning.Content = "Chưa chọn nhóm quyền.";
                cboNhomQuyen.Focus();
                return false;
            }

            if (String.IsNullOrEmpty(txtPass.Password))
            {
                lbWarning.Visibility = System.Windows.Visibility.Visible;
                lbWarning.Content = "Nhập vào mật khẩu.";
                txtPass.Focus();
                return false;
            }

            lbWarning.Visibility = System.Windows.Visibility.Hidden;
            return true;
        }

        //LOADED
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _nv.MaNV_NV = UntilitiesBusiness.GetNextID("tbl_NHANVIEN", "MaNV_NV", "NV.", 3);//Tự sinh mã nhân viên

            //Hiển thị
            txtMaNV.Text = _nv.MaNV_NV;
            txtHoTen.Focus();
        }

        //NÚT CHỌN ẢNH
        private void btnAnh_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog _open = new OpenFileDialog();
            _open.Filter = "Image files (*.png;*.jpeg;*.jpg)|*.png;*.jpeg;*.jpg|All files (*.*)|*.*";
            _open.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyComputer);
            if (_open.ShowDialog() == true)
            {
                _nv.Anh_NV = _open.FileName;
                if (File.Exists(_nv.Anh_NV))
                {
                    var _bit = new BitmapImage();
                    var _stream = File.OpenRead(_nv.Anh_NV);
                    _bit.BeginInit();
                    _bit.CacheOption = BitmapCacheOption.OnLoad;
                    _bit.StreamSource = _stream;
                    _bit.EndInit();
                    _stream.Close();
                    _stream.Dispose();

                    picNV.Source = _bit;
                }
            }
        }

        //Nút hủy
        private void btnHuy_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }//END CLASS
}

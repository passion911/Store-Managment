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
using Business;
using System.ComponentModel;
using Presentation.Dataset;
using System.Data;
using Presentation.Report;
using Presentation.WindowWpf;

namespace Presentation.UserControls
{
    /// <summary>
    /// Interaction logic for KiemKeUPresentation.xaml
    /// </summary>
    public partial class KiemKeUPresentation : UserControl
    {
        //Khai báo
        BackgroundWorker _worker;
        List<NhomSanPhamPublic> _ListNhomSP;
        List<SanPhamPublic> _listSP;

        public KiemKeUPresentation()
        {
            InitializeComponent();
            bdProgress.Visibility = System.Windows.Visibility.Collapsed;
            lbWarning.Visibility = System.Windows.Visibility.Hidden;
        }

        //Loaded
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            //Hiển thị progress
            bdProgress.Visibility = System.Windows.Visibility.Visible;

            //Tiến trình xử lý
            _worker = new BackgroundWorker();
            _worker.DoWork += (obj, ea) => Loaded_dowork();
            _worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(Loaded_complete);
            _worker.RunWorkerAsync();
        }
        //Loaded worker dowork
        private void Loaded_dowork()
        {
            //Load dữ liệu cho combobox
            _ListNhomSP = KiemKeBusiness.LayNSP();
            _listSP = KiemKeBusiness.LaySPTheoNhom(_ListNhomSP[0].MaNSP_NSP);
        }

        //Loaded worker complete
        private void Loaded_complete(object sender, RunWorkerCompletedEventArgs e)
        {
            //Đổ dữ liệu vào combobox
            cboNhomSP.ItemsSource = _ListNhomSP;
            dgDsSanPham.ItemsSource = _listSP;
            dgDsSanPham.Items.Refresh();
            HienThiTongSP();

            //Ẩn progress
            bdProgress.Visibility = System.Windows.Visibility.Hidden;
        }

        //Cbo nhóm sản phẩm selection change
        private void cboNhomSP_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Hiển thị progress
            bdProgress.Visibility = System.Windows.Visibility.Visible;

            //Tiến trình xử lý
            string _maNSP = cboNhomSP.SelectedValue.ToString();
            _worker = new BackgroundWorker();
            _worker.DoWork += (obj, ea) => CboSelectionChange_dowork(_maNSP);
            _worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(Loaded_complete);
            _worker.RunWorkerAsync();
        }

        //CBO worker dowork
        private void CboSelectionChange_dowork(string _maNSP)
        {
            //Lấy danh sách sản phẩm theo nhóm
            _listSP.Clear();
            _listSP = KiemKeBusiness.LaySPTheoNhom(_maNSP);
        }
        //CBO worker complete
        private void CboSelectionChange_complete(object sender, RunWorkerCompletedEventArgs e)
        {
            dgDsSanPham.ItemsSource = _listSP;
            dgDsSanPham.Items.Refresh();
            HienThiTongSP();

            //Ẩn progress
            bdProgress.Visibility = System.Windows.Visibility.Hidden;
        }

        //Datagrid loading row
        private void dgDsSanPham_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = (e.Row.GetIndex() + 1).ToString();
        }

        //Hiển thị số lượng sản phẩm
        private void HienThiTongSP()
        {
            int _SoMatHang = _listSP.Count();
            int _TongSoSP = _listSP.Sum(item => item.SoLuong_SP);

            lbSoMatHang.Content = _SoMatHang.ToString();
            lbTongSoSP.Content = _TongSoSP.ToString();
        }

        //txt mã textchange
        private void txtMaTenSP_TextChanged(object sender, TextChangedEventArgs e)
        {
            string _maSP = txtMaTenSP.Text.Trim();
            txtMaTenSP.Text = _maSP.ToUpper();
            txtMaTenSP.SelectionStart = txtMaTenSP.Text.Length;
        }

        //Nút tìm
        private void btnTimKiem_Click(object sender, RoutedEventArgs e)
        {
            //Kiểm tra mã nhập vào
            if (!KiemTraMaSP())
                return;

            //Tìm kiếm sp
            string _MaSP = txtMaTenSP.Text.Trim();
            if (_listSP.Count <= 0)
                return;

            int _index = _listSP.FindIndex(item => item.MaSP_SP == _MaSP);
            if (_index == -1)
            {
                lbWarning.Visibility = System.Windows.Visibility.Visible;
                lbWarning.Content = "Mã SP không tồn tại!";
                txtMaTenSP.Focus();
                txtMaTenSP.SelectAll();
                return;
            }

            dgDsSanPham.SelectedIndex = _index;
            dgDsSanPham.ScrollIntoView(dgDsSanPham.SelectedItem);

            //Set focus txt mã
            txtMaTenSP.Focus();
            txtMaTenSP.SelectAll();
        }

        //Kiểm tra mã sp 
        private bool KiemTraMaSP()
        {
            string _strTim = txtMaTenSP.Text;
            if (_strTim.StartsWith(">"))
            {
                string _StrNumber = "^([0-9]*)$";
                string _strSoLuong = _strTim.Substring(1);
                if (System.Text.RegularExpressions.Regex.IsMatch(_strSoLuong, _StrNumber))
                {
                    int _sl = Convert.ToInt32(_strSoLuong);
                    _listSP = KiemKeBusiness.LaySPTheoNhom(cboNhomSP.SelectedValue.ToString());
                    _listSP.RemoveAll(item => item.SoLuong_SP < _sl);
                    dgDsSanPham.ItemsSource = _listSP;
                    dgDsSanPham.Items.Refresh();
                    return false;
                }
            }

            if (_strTim.StartsWith("<"))
            {
                string _StrNumber = "^([0-9]*)$";
                string _strSoLuong = _strTim.Substring(1);
                if (System.Text.RegularExpressions.Regex.IsMatch(_strSoLuong, _StrNumber))
                {
                    int _sl = Convert.ToInt32(_strSoLuong);
                    _listSP = KiemKeBusiness.LaySPTheoNhom(cboNhomSP.SelectedValue.ToString());
                    _listSP.RemoveAll(item => item.SoLuong_SP > _sl);
                    dgDsSanPham.ItemsSource = _listSP;
                    dgDsSanPham.Items.Refresh();
                    return false;
                }
            }

            string _maSP = txtMaTenSP.Text.Trim();
            if (String.IsNullOrEmpty(_maSP))
            {
                lbWarning.Visibility = System.Windows.Visibility.Visible;
                lbWarning.Content = "Nhập mã sản phẩm!";
                txtMaTenSP.Focus();
                txtMaTenSP.SelectAll();
                return false;
            }

            string _strKiemTraMaSP = @"^([a-zA-Z0-9.?-]*)$";
            if (!System.Text.RegularExpressions.Regex.IsMatch(_maSP, _strKiemTraMaSP))
            {
                lbWarning.Visibility = System.Windows.Visibility.Visible;
                lbWarning.Content = "Nhập sai định dạng.";
                txtMaTenSP.Focus();
                txtMaTenSP.SelectAll();
                return false;
            }

            lbWarning.Visibility = System.Windows.Visibility.Hidden;
            return true;
        }

        //txt mã preview key down
        private void txtMaTenSP_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                btnTimKiem_Click(sender, e);
        }

        //nút in
        private void btnIn_Click(object sender, RoutedEventArgs e)
        {
            //Chuẩn bị database
            Pos_ds _PosDs = new Pos_ds();
            DataTable _dtKiemKe = _PosDs.tbl_SANPHAM;
            DataRow _drKiemKe;
            foreach (SanPhamPublic _sp in _listSP)
            {
                _drKiemKe = _dtKiemKe.NewRow();
                _drKiemKe["MaSP_SP"] = _sp.MaSP_SP;
                _drKiemKe["TenSP_SP"] = _sp.TenSP_SP;
                _drKiemKe["TenNSP_NSP"] = _sp.NSP_SP.TenNSP_NSP;
                _drKiemKe["SoLuong_SP"] = _sp.SoLuong_SP;
                _dtKiemKe.Rows.Add(_drKiemKe);
            }

            //Hiển thị report
            KiemKe_Presentation wpf = new KiemKe_Presentation();
            wpf._dtKiemKe = _dtKiemKe;
            wpf.ShowDialog();
        }

        //Sự kiện phím
        protected override void OnPreviewKeyDown(KeyEventArgs e)
        {
            if (e.Key == Key.F1)
            {
                txtMaTenSP.Focus();
                txtMaTenSP.SelectAll();
            }
            base.OnPreviewKeyDown(e);
        }

        //Nút sửa số lượng
        private void btnSua_Click(object sender, RoutedEventArgs e)
        {
            //Lấy thông tin
            SanPhamPublic _spTemp = (dgDsSanPham.SelectedItem as SanPhamPublic);
            SanPhamPublic _sp = new SanPhamPublic();
            _sp.MaSP_SP = _spTemp.MaSP_SP;
            _sp.TenSP_SP = _spTemp.TenSP_SP;
            _sp.SoLuong_SP = _spTemp.SoLuong_SP;

            //Hiển thị sửa
            KiemKeSuaPresentation wpf = new KiemKeSuaPresentation();
            wpf._SuaSoLuong += new EventHandler(SuaSoLuong);
            wpf._sp = _sp;
            wpf.ShowDialog();

            dgDsSanPham.Focus();
        }

        //Phương thức sửa số lượng
        private void SuaSoLuong(object sender, EventArgs e)
        {
            //Lấy thông tin
            KiemKeSuaPresentation wpf = (KiemKeSuaPresentation)sender;
            SanPhamPublic _sp = wpf._sp;

            //Cập nhật số lượng
            if (KiemKeBusiness.CapNhatSoLuong(_sp.MaSP_SP, _sp.SoLuong_SP))
            {
                lbWarning.Visibility = System.Windows.Visibility.Visible;
                lbWarning.Content = "Cập nhật thành công sản phẩm: " + _sp.TenSP_SP + " số lượng: " + _sp.SoLuong_SP;

                //Cập nhật dữ liệu trên listSP
                _listSP.Where(item => item.MaSP_SP == _sp.MaSP_SP).First().SoLuong_SP = _sp.SoLuong_SP;
                dgDsSanPham.ItemsSource = _listSP;
                dgDsSanPham.Items.Refresh();

                int _index = _listSP.FindIndex(item => item.MaSP_SP == _sp.MaSP_SP);
                dgDsSanPham.SelectedIndex = _index;
                dgDsSanPham.ScrollIntoView(dgDsSanPham.SelectedItem);
                HienThiTongSP();
            }

            else
            {
                lbWarning.Visibility = System.Windows.Visibility.Visible;
                lbWarning.Content = "Thao tác cập nhật thất bại";
            }

        }

        //Nút reset
        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            _listSP.Clear();
            _listSP = KiemKeBusiness.LaySPTheoNhom(cboNhomSP.SelectedValue.ToString());
            dgDsSanPham.ItemsSource = _listSP;
            dgDsSanPham.Items.Refresh();
            txtMaTenSP.Clear();
        }
    }//End class
}

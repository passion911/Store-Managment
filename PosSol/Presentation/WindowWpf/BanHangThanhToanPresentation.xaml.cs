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
using Business;
using Presentation.Report;
using System.Data;
using Public;

namespace Presentation.WindowWpf
{
    /// <summary>
    /// Interaction logic for BanHangThanhToanPresentation.xaml
    /// </summary>
    public partial class BanHangThanhToanPresentation : Window
    {

        //Khai báo
        public event EventHandler _ThanhToan;
        public HoaDonPublic _hoaDon;
        public MaGiamGiaPublic _maGiamGia;

        public int _TienPhaiTra;
        public DataTable _dt;
        public bool _InHoaDon = true;

        public BanHangThanhToanPresentation()
        {
            InitializeComponent();
            lbWarning.Visibility = System.Windows.Visibility.Hidden;
            lbMaGiamGia.Visibility = System.Windows.Visibility.Collapsed;
        }

        //Loaded
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _hoaDon.TienKhachTra_HD = 0;
            _hoaDon.VouCher_HD = 0;
            _hoaDon.TienMaGiamGia = 0;

            //Hiển thị (Tiền phải trả)
            lbTienPhaiTra.Content = UntilitiesBusiness.ThemDauPhay(_hoaDon.TienConLaiPhaiTra.ToString());
            txtTienMat.Text = "0";
            txtVoucher.Text = "0";
            txtCode.Text = "";
            lbTraLaiKhach.Content = "0";
            lbMaGiamGia.Content = "0";

            txtTienMat.Focus();
            txtTienMat.SelectAll();

            //Hiển thị Voucher
            ThietLapHeThongPublic _thietLap = ThietLapHeThongBusiness.LayThietLapHeThong();
            if (_thietLap.Voucher)
                txtVoucher.IsEnabled = true;

            //Hiển thị Mã giảm giá
            if (_thietLap.MaGiamGia)
                txtCode.IsEnabled = true;

            TinhTien();
        }

        //EVENT TEXTCHANGE txt tiền mặt
        private void txtTienMat_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (KiemTraTienMat())
                    TinhTien();
            }
            catch (Exception ex)
            {
                return;
            }
        }

        //Tính tiền
        private void TinhTien()
        {
            int _TienPhaiTra = _hoaDon.TienConLaiPhaiTra;
            int _TienMat = Convert.ToInt32(UntilitiesBusiness.BoDauPhay(txtTienMat.Text));
            int _Voucher = Convert.ToInt32(UntilitiesBusiness.BoDauPhay(txtVoucher.Text));
            int _TienMaGiamGia = Convert.ToInt32(UntilitiesBusiness.BoDauPhay(lbMaGiamGia.Content.ToString()));
            int _TienTraLaiKhach = 0;

            _TienPhaiTra = _TienPhaiTra - _TienMaGiamGia;

            if (_Voucher < _TienPhaiTra)
                _TienTraLaiKhach = _TienMat + _Voucher - _TienPhaiTra;
            else
                _TienTraLaiKhach = _TienMat;

            if (_TienTraLaiKhach < 0)
                lbTraLaiKhach.Content = "-" + UntilitiesBusiness.ThemDauPhay(_TienTraLaiKhach.ToString().Remove(0, 1));
            else
                lbTraLaiKhach.Content = UntilitiesBusiness.ThemDauPhay(_TienTraLaiKhach.ToString());
        }

        //Kiểm tra tiền mặt
        private bool KiemTraTienMat()
        {
            string _TienMat = txtTienMat.Text.Trim();

            if (String.IsNullOrEmpty(_TienMat))
            {
                txtTienMat.Text = "0";
                txtTienMat.Focus();
                txtTienMat.SelectAll();
                return false;
            }

            if (_TienMat.Length >= 10)
            {
                txtTienMat.Text = "0";
                txtTienMat.Focus();
                txtTienMat.SelectAll();
                return false;
            }

            string _strKiemTraTienMat = @"^([0-9]+[0-9,]*)$";
            if (!System.Text.RegularExpressions.Regex.IsMatch(_TienMat, _strKiemTraTienMat))
            {
                lbWarning.Visibility = System.Windows.Visibility.Visible;
                lbWarning.Content = "Nhập sai định dạng!";
                txtTienMat.Focus();
                txtTienMat.SelectAll();
                return false;
            }

            if (_TienMat.Length >= 2 && _TienMat.StartsWith("0"))
            {
                _TienMat = _TienMat.Remove(0, 1);
                txtTienMat.Text = _TienMat;
                txtTienMat.Focus();
                txtTienMat.SelectionStart = txtTienMat.Text.Length;
            }

            txtTienMat.Text = UntilitiesBusiness.ThemDauPhay(_TienMat);
            txtTienMat.SelectionStart = txtTienMat.Text.Length;
            lbWarning.Visibility = System.Windows.Visibility.Hidden;
            return true;
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            //Kiểm tra tiền phải trả lại không dc âm
            int _TienTraLai = Convert.ToInt32(UntilitiesBusiness.BoDauPhay(lbTraLaiKhach.Content.ToString()));
            if (_TienTraLai < 0)
            {
                lbWarning.Visibility = System.Windows.Visibility.Visible;
                lbWarning.Content = "Tiền nhận của khách chưa đủ!";
                return;
            }
            else
            {
                lbWarning.Visibility = System.Windows.Visibility.Hidden;
                lbWarning.Content = "";
            }

            //Lấy thông tin
            _hoaDon.TienKhachTra_HD = Convert.ToInt32(UntilitiesBusiness.BoDauPhay(txtTienMat.Text));
            _hoaDon.TienThuaTraLaiKhach = Convert.ToInt32(UntilitiesBusiness.BoDauPhay(lbTraLaiKhach.Content.ToString()));
            if (txtVoucher.Text == "0" || txtVoucher.Text == "" || txtVoucher.IsEnabled == false)
                _hoaDon.VouCher_HD = 0;
            else
                _hoaDon.VouCher_HD = Convert.ToInt32(UntilitiesBusiness.BoDauPhay(txtVoucher.Text));

            if (lbMaGiamGia.Visibility == System.Windows.Visibility.Visible || _maGiamGia != null)
            {
                _hoaDon.MaGiamGia = _maGiamGia;
                _hoaDon.TienMaGiamGia = Convert.ToInt32(UntilitiesBusiness.BoDauPhay(lbMaGiamGia.Content.ToString()));
            }
            else
            {
                _hoaDon.MaGiamGia.MaThe_MGG = "";
                _hoaDon.TienMaGiamGia = 0;
            }

            _InHoaDon = ckInHoaDon.IsChecked == true ? true : false;

            //Gọi phương thức thanh toán
            EventHandler _eh = _ThanhToan;
            if (_eh != null)
                _eh(this, e);
            this.Close();
        }

        //txt tiền mặt keyup
        private void txtTienMat_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                if (txtVoucher.Visibility == System.Windows.Visibility.Visible)
                { txtVoucher.Focus(); txtVoucher.SelectAll(); }
                else
                    if (txtCode.Visibility == System.Windows.Visibility.Visible)
                    { txtCode.Focus(); txtCode.SelectAll(); }
                    else
                        btnOK_Click(sender, e);
        }

        //txt voucher textchange
        private void txtVoucher_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (KiemTraVoucher())
                    TinhTien();
            }
            catch (Exception ex)
            {
                return;
            }
        }

        //Kiểm tra voucher
        private bool KiemTraVoucher()
        {
            string _Voucher = txtVoucher.Text.Trim();

            if (String.IsNullOrEmpty(_Voucher))
            {
                txtVoucher.Text = "0";
                txtVoucher.Focus();
                txtVoucher.SelectAll();
                return false;
            }
            if (_Voucher.Length > 9)
            {
                txtVoucher.Text = "0";
                txtVoucher.Focus();
                txtVoucher.SelectAll();
                return false;
            }

            string _strKiemTraVoucher = @"^([0-9]+[0-9,]*)$";
            if (!System.Text.RegularExpressions.Regex.IsMatch(_Voucher, _strKiemTraVoucher))
            {
                lbWarning.Visibility = System.Windows.Visibility.Visible;
                lbWarning.Content = "Nhập sai định dạng  voucher!(chỉ gồm số)";
                txtVoucher.Focus();
                txtVoucher.SelectAll();
                return false;
            }

            if (_Voucher.Length >= 2 && _Voucher.StartsWith("0"))
            {
                _Voucher = _Voucher.Remove(0, 1);
                txtVoucher.Text = _Voucher;
                txtVoucher.Focus();
                txtVoucher.SelectionStart = txtVoucher.Text.Length;
            }

            txtVoucher.Text = UntilitiesBusiness.ThemDauPhay(_Voucher);
            txtVoucher.Focus();
            txtVoucher.SelectionStart = txtVoucher.Text.Length;
            lbWarning.Visibility = System.Windows.Visibility.Hidden;
            return true;
        }

        //txt voucher keyup
        private void txtVoucher_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                if (txtCode.Visibility == System.Windows.Visibility.Visible)
                {
                    txtCode.Focus();
                    txtCode.SelectAll();
                }
                else
                    btnOK_Click(sender, e);
        }

        //txt mã giảm giá textchange
        private void txtCode_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (KiemTraMaGiamGia())
                {
                    //Lấy mã giảm giá nhập vào
                    DataTable _dtMaGG = BanHangBusiness.LayMaGiamGiaTheoMa(txtCode.Text.Trim()).Tables[0];
                    if (_dtMaGG.Rows.Count > 0)
                    {
                        //Lấy thông tin mã giảm giá
                        _maGiamGia = new MaGiamGiaPublic();
                        _maGiamGia.MaThe_MGG = _dtMaGG.Rows[0]["MaGG_MGG"].ToString();
                        _maGiamGia.ChietKhau_MGG = Convert.ToInt32(_dtMaGG.Rows[0]["ChietKhau_MGG"].ToString());
                        _maGiamGia.NgayHetHan_MGG = Convert.ToDateTime(_dtMaGG.Rows[0]["NgayHetHan_MGG"].ToString());
                        _maGiamGia.TrangThai_MGG = _dtMaGG.Rows[0]["TrangThai_MGG"].ToString() == "True" ? true : false;
                        _maGiamGia.GhiChu_MGG = _dtMaGG.Rows[0]["GhiChu_MGG"].ToString();
                        //Kiểm tra trạng thái của mã
                        if (_maGiamGia.TrangThai_MGG)
                        {
                            TimeSpan _timespan = _maGiamGia.NgayHetHan_MGG - DateTime.Now;
                            if (_timespan.Seconds > 0)
                            {
                                //Hiển thị giá tiền
                                int _TienMaGiamGia = _maGiamGia.ChietKhau_MGG * _hoaDon.TongTien_HD / 100;
                                lbMaGiamGia.Visibility = System.Windows.Visibility.Visible;
                                lbMaGiamGia.Content = UntilitiesBusiness.ThemDauPhay(_TienMaGiamGia.ToString());
                                TinhTien();
                            }
                            else
                            {

                                //thông báo code đã hết hạn
                                lbMaGiamGia.Visibility = System.Windows.Visibility.Collapsed;
                                lbMaGiamGia.Content = "0";
                                lbWarning.Visibility = System.Windows.Visibility.Visible;
                                lbWarning.Content = "Mã đã hết hạn dùng! (" + _maGiamGia.NgayHetHan_MGG.ToString("dd-MM-yyyy") + ")";
                                TinhTien();
                                _maGiamGia = null;
                            }
                        }
                        else
                        {
                            //Thông báo mã ko sử dụng dc
                            lbMaGiamGia.Visibility = System.Windows.Visibility.Collapsed;
                            lbMaGiamGia.Content = "0";
                            lbWarning.Visibility = System.Windows.Visibility.Visible;
                            lbWarning.Content = _maGiamGia.GhiChu_MGG;
                            TinhTien();
                            _maGiamGia = null;
                        }
                    }
                    else
                    {
                        lbMaGiamGia.Visibility = System.Windows.Visibility.Collapsed;
                        lbMaGiamGia.Content = "0";
                        lbWarning.Visibility = System.Windows.Visibility.Hidden;
                        TinhTien();
                        _maGiamGia = null;
                    }
                }
            }
            catch (Exception ex)
            {

                return;
            }
        }

        //Kiểm tra mã giảm giá
        private bool KiemTraMaGiamGia()
        {
            string _MaGiamGia = txtCode.Text.Trim();

            string _strKiemTraMaGiamGia = @"^([0-9]*)$";
            if (!System.Text.RegularExpressions.Regex.IsMatch(_MaGiamGia, _strKiemTraMaGiamGia))
            {
                lbWarning.Visibility = System.Windows.Visibility.Visible;
                lbWarning.Content = "Mã giảm giá sai! (Chỉ gồm số)";
                txtCode.Focus();
                return false;
            }

            txtCode.SelectionStart = txtCode.Text.Length;
            lbWarning.Visibility = System.Windows.Visibility.Hidden;
            return true;
        }

        //txt mã giảm giá keyup
        private void txtCode_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                if (KiemTraMaGiamGia())
                    btnOK_Click(sender, e);
                else
                {
                    txtCode.Focus();
                    txtCode.SelectAll();
                }
        }
    }//End class
}

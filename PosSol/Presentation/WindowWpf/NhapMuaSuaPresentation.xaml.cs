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
using Public;
using System.Text.RegularExpressions;

namespace Presentation.WindowWpf
{
    /// <summary>
    /// Interaction logic for NhapMuaSuaPresentation.xaml
    /// </summary>
    public partial class NhapMuaSuaPresentation : Window
    {
        //Khai báo
        public SanPhamPublic _sp = new SanPhamPublic();
        public event EventHandler _SuaSanPham;
        public NhapMuaSuaPresentation()
        {
            InitializeComponent();
            lbWarning.Visibility = System.Windows.Visibility.Hidden;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            txtbTenSP.Text = _sp.TenSP_SP;
            txtSoLuong.Text = _sp.SoLuong_SP.ToString();
            lbGia.Content = UntilitiesBusiness.ThemDauPhay(_sp.GiaNhap_SP);
            txtSoLuong.Focus();
            txtSoLuong.SelectAll();
        }

        //Nút sửa
        private void btnLuu_Click(object sender, RoutedEventArgs e)
        {
            //Check valid
            if (!CheckValid())
                return;

            //Lấy số lượng
            _sp.SoLuong_SP = Convert.ToInt32(txtSoLuong.Text.Trim());

            //Gọi phương thức sửa
            EventHandler _eh = _SuaSanPham;
            if (_eh != null)
                _eh(this, e);
            this.Close();
        }

        //Check valid
        private bool CheckValid()
        {
            //Kiểm tra số lượng
            string _strCheckSL = @"^(\d{1,5})$";
            string _SoLuong = txtSoLuong.Text.Trim();
            if (!Regex.IsMatch(_SoLuong, _strCheckSL))
            {
                lbWarning.Visibility = System.Windows.Visibility.Visible;
                lbWarning.Content = "Chỉ nhập số.(0 - 99999)";
                txtSoLuong.Focus();
                txtSoLuong.SelectAll();
                return false;
            }
            return true;
        }

        private void txtSoLuong_TextChanged(object sender, TextChangedEventArgs e)
        {
            //check Valid
            if (CheckValid())
            {
                if (lbWarning != null)
                    lbWarning.Visibility = System.Windows.Visibility.Hidden;

                //Tính thành tiền
                if (!String.IsNullOrEmpty(_sp.MaSP_SP))
                {
                    int _SoLuongNhap = Convert.ToInt32(txtSoLuong.Text.Trim());
                    int _GiaNhap = Convert.ToInt32(UntilitiesBusiness.BoDauPhay(_sp.GiaNhap_SP));
                    float _ThanhTien = _SoLuongNhap * _GiaNhap;
                    txtbThanhTienNhap.Text = UntilitiesBusiness.ThemDauPhay(_ThanhTien.ToString("0"));
                }
            }
        }
    }//End class
}

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
using Business;

namespace Presentation.WindowWpf
{
    /// <summary>
    /// Làm nhiệm vụ hiển thị số tiền trả lại cho khách sau khi trả hàng
    /// Thêm sản phẩm trả lại vào kho
    /// </summary>
    public partial class NhapHangTraThanhToanPresentation : Window
    {
        //Khai báo
        public List<HangMuaPubLic> _lstSPTraLai;
        public event EventHandler _ThanhToanTraSp;
        public int _TienKhachDaTra = 0;
        public int _TienSauTraSP = 0;
        int _TienTraKhach = 0;

        public NhapHangTraThanhToanPresentation()
        {
            InitializeComponent();
        }

        //Wpf loaded
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (_lstSPTraLai == null)
                return;
            if (_lstSPTraLai.Count == 0)
                return;

            //Hiển thị
            List<HangMuaPubLic> _lstHangTraTemp = new List<HangMuaPubLic>();
            foreach (HangMuaPubLic _hmTemp in _lstSPTraLai)
            {
                HangMuaPubLic _hm = new HangMuaPubLic();

                //Lấy thêm thông tin nến muốn dùng
                _hm.SanPham.MaSP_SP = _hmTemp.SanPham.MaSP_SP;
                _hm.SanPham.TenSP_SP = _hmTemp.SanPham.TenSP_SP;
                _hm.SoLuong = _hmTemp.SoLuong;

                _lstHangTraTemp.Add(_hm);
            }

            dgHangTra.ItemsSource = _lstHangTraTemp;

            TinhTien();
        }

        //Tính tiền
        private void TinhTien()
        {
            _TienTraKhach = _TienKhachDaTra - _TienSauTraSP;

            //hiển thị
            lbTienKhachDaTra.Content = UntilitiesBusiness.ThemDauPhay(_TienKhachDaTra.ToString());
            lbTienSauKhiTra.Content = UntilitiesBusiness.ThemDauPhay(_TienSauTraSP.ToString());
            lbTienTraKhach.Content = UntilitiesBusiness.ThemDauPhay(_TienTraKhach.ToString());
        }

        //Nút hủy
        private void btnHuy_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        //Kiểm tra số lượng nhập kho
        private void btnThanhToan_Click(object sender, RoutedEventArgs e)
        {
            //Kiểm tra số lượng nhập vào

            if (!KiemTraSoLuongNhapKho())
                return;

            //Nhập sản phẩm trả vào kho
            for (int i = 0; i < dgHangTra.Items.Count; i++)
            {
                HangMuaPubLic _hm = (HangMuaPubLic)dgHangTra.Items[i];
                int _soSPLoi = _lstSPTraLai[i].SoLuong - _hm.SoLuong;
                string _ghiChu = ".[" + DateTime.Now.ToString("ddMMyy") + " Trả: " + _hm.SoLuong + " .Lỗi:" + _soSPLoi.ToString() + "]";
                TraHangBusiness.NhapSPVaoKho(_hm.SanPham.MaSP_SP, _hm.SoLuong, _ghiChu);
            }

            //Gọi phương thức thanh toán - trả hàng 
            EventHandler _eh = _ThanhToanTraSp;
            if (_eh != null)
                _eh(this, e);
            this.Close();
        }

        private bool KiemTraSoLuongNhapKho()
        {
            //Kiểm tra lỗi  trên datagrid
            var errors = (from c in
                              (from object i in dgHangTra.ItemsSource
                               select dgHangTra.ItemContainerGenerator.ContainerFromItem(i))
                          where c != null
                          select Validation.GetHasError(c))
             .FirstOrDefault(x => x);
            if (errors)
            {
                MessageBox.Show("Lỗi");
                return false;
            }

            for (int i = 0; i < dgHangTra.Items.Count; i++)
            {
                int _SoSpNhapKhoMAX = _lstSPTraLai[i].SoLuong;

                HangMuaPubLic _hm = (HangMuaPubLic)dgHangTra.Items[i];
                if (_hm.SoLuong < 0 || _hm.SoLuong > _SoSpNhapKhoMAX)
                {
                    MessageBox.Show("Số lượng lớn hơn 0 và nhỏ hơn số lượng khách trả");
                    return false;
                }
            }

            return true;
        }
    }//End class
}

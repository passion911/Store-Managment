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

namespace Presentation.UserControls
{
    /// <summary>
    /// Interaction logic for PhanQuyenUPresentation.xaml
    /// </summary>
    public partial class PhanQuyenUPresentation : UserControl
    {
        //Khai báo
        public NhanVienPublic _nhanVien;
        List<QuyenPublic> _ListQuyen;
        List<QuyenChucNangPublic> _ListQuyenChucNang;

        public PhanQuyenUPresentation()
        {
            InitializeComponent();
            bdProgress.Visibility = System.Windows.Visibility.Hidden;
            lbWarning.Visibility = System.Windows.Visibility.Hidden;
        }

        //WPF loaded
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            HienThiDuLieu();
        }

        //Load data
        private void HienThiDuLieu()
        {
            //lấy danh sách quyền
            _ListQuyen = PhanQuyenBusiness.DanhSachQuyen();

            //Hiển thị lên listbox
            lboxQuyen.ItemsSource = _ListQuyen;
            lboxQuyen.Items.Refresh();
            lboxQuyen.SelectedIndex = 0;

            //Không sửa quyền cho chính mình
            //if (_nhanVien.ID_Q == lboxQuyen.SelectedValue.ToString())
            //    dgChucNang.IsHitTestVisible = false;
            //else
            //    dgChucNang.IsHitTestVisible = true;

            lbChiTietQuyen.Content = "Chi tiết nhóm quyền: " + (lboxQuyen.SelectedItem as QuyenPublic).TenQuyen_Q;
            _ListQuyenChucNang = PhanQuyenBusiness.LayQuyenChucNangTheoQuyen(lboxQuyen.SelectedValue.ToString());
            dgChucNang.ItemsSource = _ListQuyenChucNang;
            dgChucNang.Items.Refresh();

            //Ẩn tiến trình
            bdProgress.Visibility = System.Windows.Visibility.Hidden;
        }

        //selection change 
        private void lboxQuyen_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                //Không sửa quyền cho chính mình
                //if (_nhanVien.ID_Q == lboxQuyen.SelectedValue.ToString())
                //    dgChucNang.IsHitTestVisible = false;
                //else
                //    dgChucNang.IsHitTestVisible = true;

                //Hiển thị lại danh sách quyền -  chức năng
                lbChiTietQuyen.Content = "Chi tiết nhóm quyền: " + (lboxQuyen.SelectedItem as QuyenPublic).TenQuyen_Q;
                _ListQuyenChucNang = PhanQuyenBusiness.LayQuyenChucNangTheoQuyen(lboxQuyen.SelectedValue.ToString());
                dgChucNang.ItemsSource = _ListQuyenChucNang;
                dgChucNang.Items.Refresh();
            }
            catch (Exception)
            {
                return;
            }
        }

        //Nút thêm quyền
        private void btnTaoMa_Click(object sender, RoutedEventArgs e)
        {
            //Kiểm tra tên quyền nhập vào
            if (!KiemTraTenQuyen())
                return;

            //Thêm quyền mới
            QuyenPublic _quyen = new QuyenPublic();
            _quyen.ID_Q = UntilitiesBusiness.GetNextID("tbl_QUYEN", "ID_Q", "Q", 5);
            _quyen.TenQuyen_Q = txtThemQuyen.Text.Trim();
            PhanQuyenBusiness.ThemQuyen(_quyen);

            //lấy danh sách quyền
            _ListQuyen = PhanQuyenBusiness.DanhSachQuyen();

            //Hiển thị lên listbox
            lboxQuyen.ItemsSource = _ListQuyen;
            int _index = _ListQuyen.FindIndex(item => item.ID_Q == _quyen.ID_Q);
            lboxQuyen.SelectedIndex = _index;

            //Hiển thị datagrid
            _ListQuyenChucNang = PhanQuyenBusiness.LayQuyenChucNangTheoQuyen(lboxQuyen.SelectedValue.ToString());
            dgChucNang.ItemsSource = _ListQuyenChucNang;
            dgChucNang.Items.Refresh();

            lboxQuyen.Focus();
            txtThemQuyen.Text = "";
        }

        //Kiểm tra tên quyền nhập vào
        private bool KiemTraTenQuyen()
        {
            string _TenQuyen = txtThemQuyen.Text.Trim();
            if (String.IsNullOrEmpty(_TenQuyen))
            {
                lbWarning.Visibility = System.Windows.Visibility.Visible;
                lbWarning.Text = "Nhập vào tên quyền!";
                txtThemQuyen.Focus();
                return false;
            }

            lbWarning.Visibility = System.Windows.Visibility.Hidden;
            return true;
        }

        //Nút cập nhật
        private void btnCapNhat_Click(object sender, RoutedEventArgs e)
        {
            PhanQuyenBusiness.CapNhatQuyenChucNang(_ListQuyenChucNang);
            MessageBox.Show("Cập nhật thành công!");
        }

        //Loading rows
        private void dgChucNang_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = (e.Row.GetIndex() + 1).ToString();
        }

        //Nút xóa quyền
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Lấy chỉ số dòng chọn
            Button _button = sender as Button;
            int _index = lboxQuyen.Items.IndexOf(_button.DataContext);

            string _ID_Q = _ListQuyen[_index].ID_Q;

            if (MessageBox.Show("Bạn muốn xóa nhóm quyền này?", "Xác nhận xóa", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                if (PhanQuyenBusiness.XoaQuyen(_ID_Q))
                {
                    HienThiDuLieu();
                    lbWarning.Visibility = System.Windows.Visibility.Hidden;
                }
                else
                {
                    lbWarning.Visibility = System.Windows.Visibility.Visible;
                    lbWarning.Text = "Hiện có nhân viên thuộc nhóm quyền này, không thể xóa nhóm quyền này.";
                }
        }

        //txt thêm quyền preview key down
        private void txtThemQuyen_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                btnTaoMa_Click(sender, e);
        }

        //Nút reset
        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Không sửa quyền cho chính mình
                if (_nhanVien.ID_Q == lboxQuyen.SelectedValue.ToString())
                    dgChucNang.IsHitTestVisible = false;
                else
                    dgChucNang.IsHitTestVisible = true;

                //Hiển thị lại danh sách quyền -  chức năng
                lbChiTietQuyen.Content = "Chi tiết nhóm quyền: " + (lboxQuyen.SelectedItem as QuyenPublic).TenQuyen_Q;
                _ListQuyenChucNang = PhanQuyenBusiness.LayQuyenChucNangTheoQuyen(lboxQuyen.SelectedValue.ToString());
                dgChucNang.ItemsSource = _ListQuyenChucNang;
                dgChucNang.Items.Refresh();
            }
            catch (Exception)
            {
                return;
            }
        }
    }//End class
}

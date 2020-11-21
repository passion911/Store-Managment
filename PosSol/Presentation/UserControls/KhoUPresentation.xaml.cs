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

namespace Presentation.UserControls
{
    /// <summary>
    /// Interaction logic for KhoUPresentation.xaml
    /// </summary>
    public partial class KhoUPresentation : UserControl
    {
        //Khai báo
        public int _ChucNang;
        public event EventHandler _ChonChucNang;
        public List<QuyenChucNangPublic> _lstQuyen;

        public KhoUPresentation()
        {
            InitializeComponent();
        }

        //Nút nhập mua
        private void btnNhapMua_Click(object sender, RoutedEventArgs e)
        {
            _ChucNang = 1;
            //Gọi phương thức Chọn chức năng
            EventHandler _eh = _ChonChucNang;
            if (_eh != null)
                _eh(this, e);
        }

        //Nút kiểm kê
        private void btnKiemKe_Click(object sender, RoutedEventArgs e)
        {
            _ChucNang = 2;
            //Gọi phương thức Chọn chức năng
            EventHandler _eh = _ChonChucNang;
            if (_eh != null)
                _eh(this, e);
        }

        //Nút trả sản phẩm
        private void btnDoiTraSP_Click(object sender, RoutedEventArgs e)
        {
            _ChucNang = 3;
            //Gọi phương thức Chọn chức năng
            EventHandler _eh = _ChonChucNang;
            if (_eh != null)
                _eh(this, e);
        }

        //wpf loaded
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            //Hiển thịt theo quyền
            HienThiTheoQuyen();
        }

        //Hiển thị theo quyền
        private void HienThiTheoQuyen()
        {
            //Nút nhập mua
            btnNhapMua.IsEnabled = DangNhapBusiness.HienThiQuyen(_lstQuyen, "CN00006");

            //Nút nhập hàng trả
            btnDoiTraSP.IsEnabled = DangNhapBusiness.HienThiQuyen(_lstQuyen, "CN00007");

            //Nút kiểm kê
            btnKiemKe.IsEnabled = DangNhapBusiness.HienThiQuyen(_lstQuyen, "CN00008");
        }
    }//End class
}

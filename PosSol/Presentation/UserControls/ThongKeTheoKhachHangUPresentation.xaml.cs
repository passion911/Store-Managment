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
using System.Data;

namespace Presentation.UserControls
{
    /// <summary>
    /// Interaction logic for ThongKeTheoKhachHangUPresentation.xaml
    /// </summary>
    public partial class ThongKeTheoKhachHangUPresentation : UserControl
    {
        //Khai báo
        DataTable _dtKhachHang;

        public ThongKeTheoKhachHangUPresentation()
        {
            InitializeComponent();
        }

        //Loaded
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            _dtKhachHang = KhachHangBusiness.DsKhachHang().Tables[0];
            dgKhachHang.ItemsSource = _dtKhachHang.DefaultView;
            cboNhomKhachHang.ItemsSource = KhachHangBusiness.LayNhomKhachHang2();
        }

        //cbo selection change
        private void cboNhomKhachHang_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (_dtKhachHang.Rows.Count > 0)
            {
                DataView _dvKhachHang = new DataView(_dtKhachHang);
                _dvKhachHang.Sort = "NgayTao_KH DESC";
                string _strFilter;
                if (String.IsNullOrEmpty(cboNhomKhachHang.SelectedValue.ToString()))
                    _strFilter = "Ma_NHK_KH LIKE '%'";
                else
                    _strFilter = "Ma_NHK_KH = '" + cboNhomKhachHang.SelectedValue.ToString() + "'";
                _dvKhachHang.RowFilter = _strFilter;

                dgKhachHang.ItemsSource = _dvKhachHang;
            }
        }
    }//end  
}

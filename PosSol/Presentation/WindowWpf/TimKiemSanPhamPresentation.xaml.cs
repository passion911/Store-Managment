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
using System.Data;
using System.Windows.Controls.Primitives;

namespace Presentation.WindowWpf
{
    /// <summary>
    /// Interaction logic for TimKiemSanPhamPresentation.xaml
    /// </summary>
    public partial class TimKiemSanPhamPresentation : Window
    {
        //Khai báo
        public string _MaSP;
        public System.Data.DataTable _dtSP;
        public event EventHandler _TimKiemSP;
        public TimKiemSanPhamPresentation()
        {
            InitializeComponent();
        }

        //wpf loaded
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (_MaSP != null)
            {
                //Nếu có dấu % thì để nguyên chuỗi
                if (_MaSP.IndexOf("%") > -1)
                {
                    DataView _dvSP = new DataView(_dtSP);
                    _dvSP.RowFilter = "MaSP_SP LIKE '" + _MaSP.Trim() + "'";
                    dgTimKiem.ItemsSource = _dvSP;
                }
                else
                {
                    //Thực hiện tìm kiếm
                    DataView _dvSP = new DataView(_dtSP);
                    _dvSP.RowFilter = "MaSP_SP LIKE '%" + _MaSP.Trim() + "%'";
                    dgTimKiem.ItemsSource = _dvSP;
                }
            }
        }

        //Ok button click
        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            #region 1.Lấy dữ liệu
            DataRowView _drv = (DataRowView)dgTimKiem.SelectedItem;
            if (_drv != null)
                _MaSP = _drv["MaSP_SP"].ToString();
            #endregion

            #region 2.Gọi phương thức tìm kiếm
            EventHandler _eh = _TimKiemSP;
            if (_eh != null)
                _eh(this, e);
            this.Close();
            #endregion
        }
    }//end class
}

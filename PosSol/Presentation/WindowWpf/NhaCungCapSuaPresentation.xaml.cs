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

namespace Presentation.WindowWpf
{
    /// <summary>
    /// Interaction logic for NhaCungCapSuaPresentation.xaml
    /// </summary>
    public partial class NhaCungCapSuaPresentation : Window
    {
        //KHAI BÁO
        public event EventHandler _SuaNhaCungCap;
        public NhaCungCapPublic _ncc = new NhaCungCapPublic();

        public NhaCungCapSuaPresentation()
        {
            InitializeComponent();
        }

        //NÚT LƯU
        private void btnLuu_Click(object sender, RoutedEventArgs e)
        {
            #region 1. Kiểm tra thông tin nhập vào
            if (String.IsNullOrEmpty(txtTenNCC.Text.Trim()))
            {
                MessageBox.Show("Nhập tên nhà cung cấp.");
                txtTenNCC.Focus();
                return;
            }
            #endregion

            #region 2. Lấy thông tin nhập vào
            _ncc.MaNCC_NCC = txtMaNCC.Text.Trim();
            _ncc.TenNCC_NCC = txtTenNCC.Text.Trim();
            rtxtGhiChu.SelectAll();
            _ncc.GhiChu_NCC = rtxtGhiChu.Selection.Text.Trim();
            #endregion

            #region 3. Gọi phương thức sửa thông tin nhà cung cấp
            EventHandler eh = _SuaNhaCungCap;
            if (eh != null)
                eh(this, e);
            this.Close();
            #endregion
        }

        //WPF LOADED
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            HienThi();
            txtTenNCC.Focus();
            txtTenNCC.SelectAll();
        }

        //HIỂN THỊ THÔNG TIN
        void HienThi()
        {
            txtMaNCC.Text = _ncc.MaNCC_NCC;
            txtTenNCC.Text = _ncc.TenNCC_NCC;
            FlowDocument fDoc = new FlowDocument();
            fDoc.Blocks.Add(new Paragraph(new Run(_ncc.GhiChu_NCC.Trim())));
            rtxtGhiChu.Document = fDoc;
        }
    }//END CLASS
}

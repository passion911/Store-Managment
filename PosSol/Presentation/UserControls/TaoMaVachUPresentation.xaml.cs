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
using Presentation.Report.Dataset;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.Data;
using Business;
using System.ComponentModel;
using System.Text.RegularExpressions;
using Presentation.WindowWpf;
using Public;

namespace Presentation.UserControls
{
    /// <summary>
    /// Interaction logic for TaoMaVachUPresentation.xaml
    /// </summary>
    public partial class TaoMaVachUPresentation : UserControl
    {
        //Khai báo
        List<SanPhamPublic> _dsSanPham = new List<SanPhamPublic>();
        DataTable _DtSP;
        BackgroundWorker worker;
        DataView _dv;
        ReportDocument _report;
        public TaoMaVachUPresentation()
        {
            InitializeComponent();
            bdProgress.Visibility = System.Windows.Visibility.Hidden;
        }

        //Nút tạo mã vạch
        private void btnTaoMa_Click(object sender, RoutedEventArgs e)
        {
            //Kiểm tra dữ liệu
            if (_dsSanPham.Count == 0)
            {
                txtbWarning.Visibility = System.Windows.Visibility.Visible;
                txtbWarning.Text = "Chưa có sản phẩm nào!";
                txtMaSP.Focus();
                txtMaSP.SelectAll();
                return;
            }

            int _SoLuong = _dsSanPham.Sum(item => item.SoLuong_SP);
            if (_SoLuong == 0)
            {
                txtbWarning.Visibility = System.Windows.Visibility.Visible;
                txtbWarning.Text = "Chưa nhập số lượng!";
                return;
            }


            //Hiển thị progress 
            bdProgress.Visibility = System.Windows.Visibility.Visible;

            //Gọi tiến trình xử lý
            worker = new BackgroundWorker();
            worker.DoWork += (obj, ea) => TaoMaVach_dowork();
            worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(TaoMaVach_complete);
            worker.RunWorkerAsync();
        }

        //Tạo mã vạch worker
        private void TaoMaVach_dowork()
        {
            //Khai báo report
            _report = new ReportDocument();
            _report.Load("../../Report/TaoMaVach_rpt.rpt");

            //Table dữ liệu cho report
            TaoMaVach_ds _dsTaoMaVach = new TaoMaVach_ds();
            DataTable _dtReport = _dsTaoMaVach.tbl_SANPHAM;
            DataRow _dr;

            foreach (SanPhamPublic _sp in _dsSanPham)
            {
                for (int i = 0; i < _sp.SoLuong_SP; i++)
                {
                    _dr = _dtReport.NewRow();
                    _dr["MaSP_SP"] = _sp.MaSP_SP;
                    _dr["TenSP_SP"] = _sp.TenSP_SP;
                    _dr["GiaBanLe_SP"] = UntilitiesBusiness.ThemDauPhay(_sp.GiaBanLe_SP);
                    _dr["TenShop"] = "Minh Thúy Shop";
                    _dr["Barcode"] = "*." + _sp.MaSP_SP + "*";

                    _dtReport.Rows.Add(_dr);
                }
            }
            _report.Database.Tables["tbl_SANPHAM"].SetDataSource(_dtReport);
        }
        //Tạo mã vạch complete
        private void TaoMaVach_complete(object sender, RunWorkerCompletedEventArgs e)
        {
            //crysReportTaoMaVach.ViewerCore.ReportSource = _report;

            //Ẩn  progress
            bdProgress.Visibility = System.Windows.Visibility.Hidden;
        }

        //Textchange
        private void txtMaSP_TextChanged(object sender, TextChangedEventArgs e)
        {
            string _MaSP = txtMaSP.Text.Trim();
            //Không cho nhập dấu chấm đầu tiên
            if (_MaSP.StartsWith("."))
            {
                _MaSP = "";
                txtMaSP.Text = _MaSP;
            }

            txtMaSP.Text = _MaSP.ToUpper();
            txtMaSP.Focus();
            txtMaSP.SelectionStart = txtMaSP.Text.Length;
            //TimMaSP();
        }

        //Loaded
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            bdProgress.Visibility = System.Windows.Visibility.Visible;
            worker = new BackgroundWorker();
            worker.DoWork += (obj, ea) => WpfLoad_dowork();
            worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(WpfLoad_complete);
            worker.RunWorkerAsync();
        }
        #region Bg wordker load datatable
        void WpfLoad_dowork()
        {
            _DtSP = TaoMaVachSPBusiness.DsSanPham().Tables[0];
        }
        void WpfLoad_complete(object sender, RunWorkerCompletedEventArgs e)
        {
            bdProgress.Visibility = System.Windows.Visibility.Hidden;
            txtMaSP.Focus();
        }
        #endregion

        //Key down
        private void txtMaSP_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {

                if (txtMaSP.Text.Trim().EndsWith("?"))
                {
                    NhapMua_TimKiemSPPresentation wpf_tim = new NhapMua_TimKiemSPPresentation();
                    wpf_tim._strTim = txtMaSP.Text.Trim().Replace("?", "");
                    wpf_tim._TimKiemSP += new EventHandler(TimKiemSP);
                    wpf_tim.ShowDialog();
                }
                else
                {
                    btnThemSP_Click(sender, e);
                }
            }
        }
        #region Phương thức Tìm kiếm sản phẩm
        private void TimKiemSP(object sender, EventArgs e)
        {
            NhapMua_TimKiemSPPresentation wpf_tim = (NhapMua_TimKiemSPPresentation)sender;
            List<SanPhamPublic> _lstSP = wpf_tim._ListSPChon;


            foreach (SanPhamPublic _sp in _lstSP)
            {
                //Kiểm tra nếu trong ds chưa có thì thêm
                SanPhamPublic _result = _dsSanPham.Find(item => item.MaSP_SP == txtMaSP.Text.Trim().ToUpper());

                if (_result == null)
                {
                    _dsSanPham.Add(_sp);

                }
            }
            dgDsSanPham.ItemsSource = _dsSanPham;
            dgDsSanPham.Items.Refresh();
            txtMaSP.Focus();
            txtMaSP.SelectAll();

        }
        #endregion

        //Check valid
        private bool CheckValid()
        {
            //Check Mã SP
            string _MaSP = txtMaSP.Text.Trim();
            string _CheckMaSP = @"^([%]*[a-zA-z0-9._]*[%]*[?]?)$"; //gồ chữ cái, chữ số, dấu ".", "_", "?", "%"
            if (String.IsNullOrEmpty(_MaSP))
            {
                txtMaSP.Focus();
                txtbWarning.Text = @"Mã SP không rỗng!";
                return false;
            }
            if (!Regex.IsMatch(_MaSP, _CheckMaSP))
            {
                txtMaSP.Focus();
                txtMaSP.SelectAll();
                txtMaSP.SelectionStart = txtMaSP.Text.Length;
                txtbWarning.Text = @"Mã sản phẩm chỉ chứa chữ cái, chữ số dấu '?', '.', '%', '_'";
                return false;
            }

            txtbWarning.Text = "";
            return true;
        }

        //Tìm theo mã sp, nếu có thì hiển thị 
        private void TimMaSP()
        {
            _dv = new DataView(_DtSP);
            _dv.Sort = "MaSP_SP";
            int _index = _dv.Find(txtMaSP.Text.Trim());
            txtbWarning.Text = @"";
            if (_index != -1)
            {
                gdSP.Visibility = System.Windows.Visibility.Visible;
                lbMa.Content = _dv[_index]["MaSP_SP"].ToString();
                txtbTen.Text = _dv[_index]["TenSP_SP"].ToString();
                lbGia.Content = _dv[_index]["GiaBanLe_SP"].ToString();
            }
            else
            {
                //Ẩn khung thông tin sp
                gdSP.Visibility = System.Windows.Visibility.Collapsed;
                lbMa.Content = "";
                txtbTen.Text = "";
                lbGia.Content = "";

                //Đặt con trỏ vào ô mã 
                txtMaSP.SelectAll();
                txtMaSP.Focus();
                txtMaSP.SelectionStart = txtMaSP.Text.Length;
                txtbWarning.Text = @"Không có mã sản phẩm này!";
            }
        }

        //Nút thêm
        private void btnThemSP_Click(object sender, RoutedEventArgs e)
        {
            //Kiểm tra mã nhập vào
            if (!KiemTraMaSP())
                return;
            //Kiểm tra xem có sản phẩm này không
            _dv = new DataView(_DtSP);
            _dv.Sort = "MaSP_SP";
            int _index = _dv.Find(txtMaSP.Text.Trim());
            if (_index != -1)
            {
                //Thêm vào danh sách
                SanPhamPublic _sp = new SanPhamPublic();
                _sp.MaSP_SP = _dv[_index]["MaSP_SP"].ToString();
                _sp.TenSP_SP = _dv[_index]["TenSP_SP"].ToString();
                _sp.GiaBanLe_SP = _dv[_index]["GiaBanLe_SP"].ToString();
                _sp.SoLuong_SP = 0;


                //Kiểm tra nếu trong ds chưa có thì thêm
                SanPhamPublic _result = _dsSanPham.Find(item => item.MaSP_SP == txtMaSP.Text.Trim().ToUpper());

                if (_result == null)
                {
                    _dsSanPham.Add(_sp);
                    dgDsSanPham.ItemsSource = _dsSanPham;
                    dgDsSanPham.Items.Refresh();
                    txtMaSP.Focus();
                    txtMaSP.SelectAll();
                }
                else
                {
                    txtbWarning.Visibility = System.Windows.Visibility.Visible;
                    txtbWarning.Text = "Sản phẩm đã có trong danh sách";
                    txtMaSP.Focus();
                    txtMaSP.SelectAll();
                }
            }
            else
            {
                txtbWarning.Visibility = System.Windows.Visibility.Visible;
                txtbWarning.Text = "Mã sản phẩm không tồn tại. Vui lòng kiểm tra lại!";
                txtMaSP.Focus();
                txtMaSP.SelectAll();
            }
        }

        //Kiểm tra mã nhập vào
        private bool KiemTraMaSP()
        {
            string _MaSP = txtMaSP.Text.Trim();
            if (String.IsNullOrEmpty(_MaSP))
            {
                txtbWarning.Visibility = System.Windows.Visibility.Visible;
                txtbWarning.Text = "Nhập mã sản phẩm!";
                txtMaSP.Focus();
                return false;
            }
            string _strKiemTraMaSP = @"^([a-zA-Z0-9.-]*)$";
            if (!System.Text.RegularExpressions.Regex.IsMatch(_MaSP, _strKiemTraMaSP))
            {
                txtbWarning.Visibility = System.Windows.Visibility.Visible;
                txtbWarning.Text = "Mã sản phẩm sai định dạng!";
                txtMaSP.Focus();
                txtMaSP.SelectAll();
                return false;
            }

            txtbWarning.Visibility = System.Windows.Visibility.Hidden;
            return true;
        }

        //Sự kiện phím của usercontrol
        protected override void OnPreviewKeyDown(KeyEventArgs e)
        {
            if (e.Key == Key.F1)
            {
                txtMaSP.Focus();
                txtMaSP.SelectAll();
            }

            if (e.Key == Key.F2)
                btnTaoMa_Click(this, e);

            base.OnPreviewKeyDown(e);
        }

        //Nút hủy sản phẩm
        private void btnXoa_Click(object sender, RoutedEventArgs e)
        {
            string _MaSpHuy = (dgDsSanPham.SelectedItem as SanPhamPublic).MaSP_SP;
            var _spRemove = _dsSanPham.Single(item => item.MaSP_SP == _MaSpHuy);
            _dsSanPham.Remove(_spRemove);

            dgDsSanPham.ItemsSource = _dsSanPham;
            dgDsSanPham.Items.Refresh();
        }
    }//End class
}

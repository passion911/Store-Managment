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
using Presentation.Dataset;
using System.Data;
using System.ComponentModel;
using Business;
using Public;

namespace Presentation.WindowWpf
{
    /// <summary>
    /// Interaction logic for NhapMua_TimKiemSPPresentation.xaml
    /// </summary>
    public partial class NhapMua_TimKiemSPPresentation : Window
    {
        //Khai báo
        public event EventHandler _TimKiemSP;
        public DataTable _dtSP;
        BackgroundWorker worker;
        List<NhomSanPhamPublic> _ListNSP;
        string _ErrorMessage = "";
        public List<SanPhamPublic> _ListSPChon;
        public string _strTim;

        public NhapMua_TimKiemSPPresentation()
        {
            InitializeComponent();
            bdProgress.Visibility = System.Windows.Visibility.Hidden;
            btnReset.IsEnabled = false;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //Hiển thị progress
            bdProgress.Visibility = System.Windows.Visibility.Visible;

            //Khai báo tiến trình làm việc
            worker = new BackgroundWorker();
            worker.DoWork += (obj, ea) => Loaded_dowork();
            worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(Loaded_conplete);
            worker.RunWorkerAsync();
        }
        #region Worker loaded
        void Loaded_dowork()
        {
            //Load datatable
            _dtSP = NhapMuaBusiness.DsSanPham().Tables[0];

            //Load cbo nhóm sản phẩm
            _ListNSP = NhapMuaBusiness.ListNSP();
        }
        private void Loaded_conplete(object sender, RunWorkerCompletedEventArgs e)
        {
            //CBO
            cboNhomSP.ItemsSource = _ListNSP;
            dgSP.ItemsSource = _dtSP.DefaultView;
            cboMaSP_AndOr.ItemsSource = _ListAndOr();
            cboNSP_AndOr.ItemsSource = _ListAndOr();
            cboNgayTao_AndOr.ItemsSource = _ListAndOr();

            //lb Warrning
            lbWarning.Content = _ErrorMessage;

            //lbTổng kết quả
            lbTongBanGhi.Content = _dtSP.Rows.Count.ToString() + " kết quả.";

            //DatePicker
            int _year = DateTime.Now.Year;
            int _month = DateTime.Now.Month;
            int _day = DateTime.Now.Day;
            dtTuNgay.SelectedDate = DateTime.Today;
            dtDenNgay.SelectedDate = DateTime.Today;


            //Ẩn progress
            bdProgress.Visibility = System.Windows.Visibility.Hidden;

            //focus Tên 
            txtTenSP.Focus();

            //
            if (!String.IsNullOrEmpty(_strTim))
            {
                txtMaSP.Text = _strTim;
                cboMaSP_AndOr.SelectedValue = "OR";
                TimSanPham();
            }
        }
        #endregion

        //AndOrCBo
        private List<AndOrCBO> _ListAndOr()
        {
            List<AndOrCBO> _List = new List<AndOrCBO>();
            AndOrCBO _andOr;

            _andOr = new AndOrCBO();
            _andOr.Name = "Không";
            _andOr.Value = "";
            _List.Add(_andOr);

            _andOr = new AndOrCBO();
            _andOr.Name = "Hoặc";
            _andOr.Value = "OR";
            _List.Add(_andOr);

            _andOr = new AndOrCBO();
            _andOr.Name = "Và";
            _andOr.Value = "AND";
            _List.Add(_andOr);

            return _List;
        }

        //Nút tìm
        private void btnTim_Click(object sender, RoutedEventArgs e)
        {
            TimSanPham();
            btnReset.IsEnabled = true;
        }
        #region Phương thức tìm sản phẩm
        private void TimSanPham()
        {
            //Sử dụng dataview filter
            DataView _dvSP = new DataView(_dtSP);

            string _strFilter = "";

            //Tạo chuỗi lọc
            string _TenSP = txtTenSP.Text.Trim();
            string _MaSP = txtMaSP.Text.Trim();

            //ĐK: Tên sản phẩm
            if (_TenSP != "")
                _strFilter = "TenSP_SP LIKE '%" + _TenSP + "%' ";

            //ĐK: Mã sản phẩm
            string _dkMaSP = cboMaSP_AndOr.SelectedValue.ToString();
            if (_dkMaSP != "")
                if (_MaSP != "")
                    if (_strFilter != "")
                        _strFilter = _strFilter + _dkMaSP + " MaSP_SP LIKE '%" + _MaSP + "%' ";
                    else
                        _strFilter = "MaSP_SP LIKE '%" + _MaSP + "%'";
            //ĐK: Nhóm sản phẩm
            string _dkNSP = cboNSP_AndOr.SelectedValue.ToString();
            if (_dkNSP != "")
                if (cboNhomSP.SelectedValue.ToString() != "")
                    if (_strFilter != "")
                        _strFilter = _strFilter + _dkNSP + " MaNSP_SP = '" + cboNhomSP.SelectedValue.ToString() + "' ";
                    else
                        _strFilter = "MaNSP_SP = '" + cboNhomSP.SelectedValue.ToString() + "' ";
            //ĐK: Ngày tạo
            string _dkNgayTao = cboNgayTao_AndOr.SelectedValue.ToString();
            if (_dkNgayTao != "")
            {
                DateTime _dtTuNgay = dtTuNgay.SelectedDate.Value;
                if (_strFilter != "")
                    _strFilter = _strFilter + _dkNgayTao + " NgayTao_SP > #" + _dtTuNgay.ToShortDateString() + "# ";
                else
                    _strFilter = "NgayTao_SP > #" + _dtTuNgay.ToShortDateString() + "# ";

                DateTime _dtDenNgay = dtDenNgay.SelectedDate.Value;
                if (_strFilter != "")
                    _strFilter = _strFilter + _dkNgayTao + " NgayTao_SP > #" + _dtDenNgay.ToShortDateString() + "# ";
                else
                    _strFilter = "NgayTao_SP > #" + _dtDenNgay.ToShortDateString() + "# ";
            }
            _dvSP.RowFilter = _strFilter;
            dgSP.ItemsSource = _dvSP;
            lbTongBanGhi.Content = _dvSP.Count.ToString() + " kết quả";
        }
        #endregion

        //Nút chọn
        private void btnChon_Click(object sender, RoutedEventArgs e)
        {
            #region 1.Lấy danh sách sp dc chọn
            _ListSPChon = new List<SanPhamPublic>();
            SanPhamPublic _sp;
            if (dgSP.SelectedItems.Count > 0)//Nếu có sp dc chọn
            {
                for (int i = 0; i < dgSP.SelectedItems.Count; i++)
                {
                    DataRowView _drvSp = (DataRowView)dgSP.SelectedItems[i];
                    _sp = new SanPhamPublic();
                    _sp.MaSP_SP = _drvSp["MaSP_SP"].ToString();
                    _sp.TenSP_SP = _drvSp["TenSP_SP"].ToString();
                    _sp.GiaNhap_SP = _drvSp["GiaNhap_SP"].ToString();
                    _sp.GiaBanLe_SP = _drvSp["GiaBanLe_SP"].ToString();
                    _sp.GiaBanSi_SP = _drvSp["GiaBanSi_SP"].ToString();
                    _sp.NCC_SP.MaNCC_NCC = _drvSp["MaNCC_SP"].ToString();
                    _sp.NSP_SP.MaNSP_NSP = _drvSp["MaNSP_SP"].ToString();
                    _sp.DVT_SP.MaDVT_DVT = _drvSp["MaDVT_SP"].ToString();
                    _sp.GhiChu_SP = _drvSp["GhiChu_SP"].ToString();
                    _sp.SoLuong_SP = 0; //Khởi tạo số lượng hàng nhập bằng 0
                    _sp.CKPhanTram_SP = Convert.ToInt32(_drvSp["CKPhanTram_SP"].ToString());
                    _sp.Anh_SP = _drvSp["Anh_SP"].ToString();
                    _sp.NgayTao_SP = Convert.ToDateTime(_drvSp["NgayTao_SP"].ToString());

                    _ListSPChon.Add(_sp);
                }
            }
            #endregion

            #region 2. Gọi phương thức thêm sp vào list hàng nhập
            EventHandler _eh = _TimKiemSP;
            if (_eh != null)
                _eh(this, e);
            this.Close();
            #endregion
        }

        //Nút hủy   
        private void btnHuy_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        //Nút reset
        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            //Reset control
            txtMaSP.Text = "";
            txtTenSP.Text = "";

            cboMaSP_AndOr.SelectedValue = "";
            cboNgayTao_AndOr.SelectedValue = "";
            cboNhomSP.SelectedValue = "";
            cboNSP_AndOr.SelectedValue = "";

            dtDenNgay.SelectedDate = DateTime.Today;
            dtTuNgay.SelectedDate = DateTime.Today;

            //Gọi tìm kiếm
            TimSanPham();

            //Tắt nút reset
            btnReset.IsEnabled = false;
        }

        //Loading row
        private void dgSP_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = (e.Row.GetIndex() + 1).ToString();
        }

    }//End class

    class AndOrCBO
    {
        private string _Name;
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        private string _Value;
        public string Value
        {
            get { return _Value; }
            set { _Value = value; }
        }
    }
}

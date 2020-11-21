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
using System.Xml;
using System.Data.SqlClient;
using System.Xml.Linq;

namespace Presentation.WindowWpf
{
    /// <summary>
    /// Interaction logic for KetnoiPresentation.xaml
    /// </summary>
    public partial class KetnoiPresentation : Window
    {
        public KetnoiPresentation()
        {
            InitializeComponent();
        }

        //Loaded
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            HienThi();
        }
        //hiển thị
        private void HienThi()
        {
            var xml = new XmlDocument();
            xml.Load("Connection.xml");
            var xmlelement = xml.DocumentElement;

            txtSever.Text = xmlelement.SelectSingleNode("server").InnerText;
            txtDatabase.Text = xmlelement.SelectSingleNode("database").InnerText;
            txtUsername.Text = xmlelement.SelectSingleNode("username").InnerText;
            txtPass.Password = xmlelement.SelectSingleNode("password").InnerText;
        }

        //nút Test
        private void btnTest_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection conn = new SqlConnection();
            bool t = true;
            try
            {
                string _sv = "";
                string _db = "";
                string _user = "";
                string _pass = "";
                string _conString = "";

                //Kiểm tra
                if (!KiemTraThongTin())
                    return;

                //Lấy thông tin
                _sv = txtSever.Text.Trim();
                _db = txtDatabase.Text.Trim();
                _user = txtUsername.Text.Trim();
                _pass = txtPass.Password;


                if (_user == "") // ko dung user - pass
                    _conString = @"Server = " + _sv + ";Database = " + _db + ";Trusted_Connection=True;";
                else
                    _conString = @"Data Source=" + _sv + ";Initial Catalog=" + _db + ";User Id=" + _user + ";Password=" +
                                 _pass + ";";

                //     string strConnect = "Data Source = .\\SQLEXPRESS; Initial Catalog= DATN_POS; Integrated Security= SSPI";
                conn = new SqlConnection(_conString);
                conn.Open();
            }
            catch (Exception)
            {
                t = false;
            }
            finally
            {
                conn.Close();
            }
            if (t)
            {
                lbWarning.Visibility = System.Windows.Visibility.Visible;
                lbWarning.Content = "Kết nối thành công!";
            }
            else
            {
                lbWarning.Visibility = System.Windows.Visibility.Visible;
                lbWarning.Content = "Kết nối thất bại!";
            }
        }
        //Kiểm tra thông tin
        private bool KiemTraThongTin()
        {
            if (string.IsNullOrEmpty(txtSever.Text.Trim()))
            {
                lbWarning.Visibility = System.Windows.Visibility.Visible;
                lbWarning.Content = "Nhập tên server.";
                txtSever.Focus();
                return false;
            }

            if (String.IsNullOrEmpty(txtDatabase.Text.Trim()))
            {
                lbWarning.Visibility = System.Windows.Visibility.Visible;
                lbWarning.Content = "Nhập tên database";
                txtDatabase.Focus();
                return false;
            }

            lbWarning.Visibility = System.Windows.Visibility.Hidden;
            return true;
        }

        //nút lưu
        private void btnLuu_Click(object sender, RoutedEventArgs e)
        {
            //kiểm tra
            var xdoc = new XDocument(
                new XElement("config",
                    new XElement("server", txtSever.Text),
                    new XElement("database", txtDatabase.Text),
                    new XElement("username", txtUsername.Text),
                    new XElement("password", txtPass.Password)));
            xdoc.Save("Connection.xml");
        }
    }//End class
}

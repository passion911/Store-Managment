using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Xml;
using MS.Win32;

namespace DataAccess
{
    class ConnectionDataAccess
    {
        static SqlConnection _conn;
        SqlDataAdapter _adt;

        public ConnectionDataAccess()
        {

            try
            {
                string _sv = "";
                string _db = "";
                string _user = "";
                string _pass = "";
                string _conString = "";

                var xmlread = new XmlDocument();
                xmlread.Load("Connection.xml");
                var xmlelement = xmlread.DocumentElement;
                if (xmlelement != null)
                {
                    var serverNode = xmlelement.SelectSingleNode("server");
                    if (serverNode != null)
                        _sv = serverNode.InnerText;

                    var databaseNode = xmlelement.SelectSingleNode("database");
                    if (databaseNode != null)
                        _db = databaseNode.InnerText;

                    var usernameNode = xmlelement.SelectSingleNode("username");
                    if (usernameNode != null)
                        _user = usernameNode.InnerText;

                    var passwordNode = xmlelement.SelectSingleNode("password");
                    if (passwordNode != null)
                        _pass = passwordNode.InnerText;
                }
                if (_user == "") // ko dung user - pass
                    _conString = @"Data Source = " + _sv + ";Initial Catalog = " + _db + ";Integrated Security=SSPI;";
                else
                    _conString = @"Data Source=" + _sv + ";Initial Catalog=" + _db + ";User Id=" + _user + ";Password=" +
                                 _pass + ";";

                //     string strConnect = "Data Source = .\\SQLEXPRESS; Initial Catalog= DATN_POS; Integrated Security= SSPI";
                _conn = new SqlConnection(_conString);
            }
            catch (Exception)
            {

                throw;
            }
        }//end ConnectionDataAccess
        public DataSet GetDataSet(string storeProdureName)
        {
            _conn.Open();
            SqlCommand cmd = new SqlCommand(storeProdureName, _conn);
            cmd.CommandType = CommandType.StoredProcedure;
            DataSet ds = new DataSet();
            _adt = new SqlDataAdapter(cmd);
            _adt.Fill(ds);
            _conn.Close();
            return ds;
        }//end Getdataset

        //Lấy dữ liệu có điều kiện
        public DataSet GetDataSet2(SqlCommand cmd)
        {
            _conn.Open();
            cmd.Connection = _conn;
            DataSet ds = new DataSet();
            _adt = new SqlDataAdapter(cmd);
            _adt.Fill(ds);
            _conn.Close();
            return ds;
        }

        public bool Execute(SqlCommand cmd)
        {
            try
            {
                _conn.Open();
                cmd.Connection = _conn;
                if (cmd.ExecuteNonQuery() >= 1)
                {
                    return true;
                }
            }
            catch (Exception e)
            {
                return false;
                //throw;
            }
            finally
            {
                _conn.Close();
            }
            return false;
        }

        public SqlConnection GetConn()
        {
            return _conn;
        }

        public void ExecuteSqlQuery(string sql)
        {
            try
            {
                _conn.Open();
                var cmd = new SqlCommand { CommandType = CommandType.Text, CommandText = sql };
                cmd.ExecuteNonQuery();
            }
            finally
            {
                _conn.Close();
            }
        }

        public DataSet GetDataSetSqlQuery(string sql)
        {
            try
            {
                _conn.Open();
                var cmd = new SqlCommand(sql, _conn) { CommandType = CommandType.Text };
                var ds = new DataSet();
                var adt = new SqlDataAdapter(cmd);
                adt.Fill(ds);
                return ds;
            }
            finally
            {
                _conn.Close();
            }
        }

        public static bool CheckConnect()
        {
            try
            {
                _conn.Open();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
    }//end class
}

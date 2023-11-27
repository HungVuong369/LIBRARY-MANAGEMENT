using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HungVuong_C5_Assignment
{
    public class DataProvider
    {
        private static readonly object Instancelock = new object();

        private static DataProvider _Instance;
        public static DataProvider Instance
        {
            get
            {
                lock (Instancelock)
                {
                    if (_Instance == null)
                    {
                        _Instance = new DataProvider();
                    }
                }
                return _Instance;
            }
        }

        public string connStr;

        public string ServerName1()
        {
            return System.Environment.MachineName + @"\SQLEXPRESS";
        }

        public string ServerName2()
        {
            return System.Environment.MachineName;
        }

        public string GetConnectionStr(string serverName)
        {
            return $@"Data Source={serverName};Initial Catalog=QuanLyThuVien;Trusted_Connection=True";
        }

        public string GetConnectionStr(string serverName, string catalog)
        {
            return $@"Data Source={serverName};Initial Catalog={catalog};Trusted_Connection=True";
        }

        public SqlConnection conn { get; set; }
        public SqlCommand cmd { get; set; }
        public SqlDataReader reader { get; set; }

        public string[] parameters { get; set; }
        public object[] values { get; set; }

        public void Connect()
        {
            try
            {
                if (conn == null)
                    conn = new SqlConnection(connStr);

                if (conn.State == ConnectionState.Open) {
                    
                }
                else
                    conn.Open();
            }
            catch (SqlException)
            {
               // MessageBox.Show("Connection Error!", "Notify", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void Disconnect()
        {
            if (conn.State == ConnectionState.Closed)
            {
            }
            else
            {
                conn.Close();
            }
        }

        public SqlCommand GetParameters(CommandType cmdType, string tSQL)
        {
            cmd = new SqlCommand(tSQL, conn);
            cmd.CommandType = cmdType;
            if (parameters != null && values != null)
            {
                int i = 0;
                foreach (var item in parameters)
                {
                    cmd.Parameters.AddWithValue("@" + parameters[i], values[i] ?? DBNull.Value);
                    i++;
                }
            }
            return cmd;
        }

        public object ExecuteScalar(CommandType cmdType, string tSQL)
        {
            object data = 0;
            try
            {
                Connect();
                cmd = new SqlCommand(tSQL, conn);
                cmd = GetParameters(cmdType, tSQL);
                data = cmd.ExecuteScalar();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error Generated. Details: " + ex.ToString());
            }
            finally
            {
                Disconnect();
            }
            return data;
        }

        public int ExcuteNonQuery(CommandType cmdType, string tSQL)
        {
            int nRow = -1;
            try
            {
                Connect();
                cmd = GetParameters(cmdType, tSQL);
                nRow = cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error Generated. Details: " + ex.ToString());
            }
            finally
            {
                Disconnect();
            }
            return nRow;
        }

        public SqlDataReader GetReader(CommandType cmdType, string tSQL)
        {
            try
            {
                Connect();
                cmd = GetParameters(cmdType, tSQL);
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                    return reader; // lấy 1 bảng  
            }
            catch (SqlException)
            {
               // MessageBox.Show("Error Data!", "Notify", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch(InvalidOperationException)
            {
                return null;
            }
            return null;
        }
    }
}

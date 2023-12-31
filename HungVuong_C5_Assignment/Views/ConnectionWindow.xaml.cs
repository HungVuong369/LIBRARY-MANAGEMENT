﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace HungVuong_C5_Assignment
{
    /// <summary>
    /// Interaction logic for ConnectionWindow.xaml
    /// </summary>
    public partial class ConnectionWindow : Window
    {
        Load load;
        private bool isLogined = false;
        private ParameterViewModel _ParameterVM;

        public ConnectionWindow(bool isLogined)
        {
            InitializeComponent();

            this.isLogined = isLogined;

            this.Loaded += ConnectionWindow_Loaded;
        }

        private void ConnectionWindow_Loaded(object sender, RoutedEventArgs e)
        {
            string xmlFilePath = "Data/ServerName.xml";
            string status = null;

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(xmlFilePath);

            XmlNode serverNode = xmlDoc.SelectSingleNode("/Server");

            if (serverNode != null)
            {
                status = serverNode.Attributes["Status"].Value;

                cbDataSource.Items.Add(serverNode.Attributes["Catalog"].Value);
                cbDataSource.SelectedIndex = 0;
                cbConnect.Items.Add(serverNode.Attributes["Datasource"].Value);
                cbConnect.SelectedIndex = 0;
            }
            else
            {
                Console.WriteLine("Không tìm thấy phần tử Server trong tập tin XML.");
            }
            ckAutoConnect.IsChecked = status == "false" ? false : true;

            if(isLogined == true)
            {
                return;
            }
            if (ckAutoConnect.IsChecked == true)
            {
                btnConnect_Click(new object(), new RoutedEventArgs());
            }
        }

        private void DoLoad()
        {
            load = new Load();

            load.Dispatcher.Invoke(() => load.ShowDialog());
        }

        private void btnConnect_Click(object sender, RoutedEventArgs e)
        {
            Thread loadThread = new Thread(new ThreadStart(DoLoad));

            loadThread.SetApartmentState(ApartmentState.STA);

            loadThread.Start();

            loadThread.Join(1000);

            try
            {
                using (QuanLyThuVienEntities db = new QuanLyThuVienEntities(ConfigurationManager.ConnectionStrings["QuanLyThuVienEntities"].ConnectionString.Replace("QuanLyThuVien", $"{txtDataSource.Text}").Replace("DESKTOP-IQBJA8G\\SQLEXPRESS", $"{txtConnect.Text}")))
                {
                    db.Configuration.LazyLoadingEnabled = false;
                    var items = db.Parameters.ToList();
                    DatabaseFirst.ConnectionStr = ConfigurationManager.ConnectionStrings["QuanLyThuVienEntities"].ConnectionString.Replace("QuanLyThuVien", $"{txtDataSource.Text}").Replace("DESKTOP-IQBJA8G\\SQLEXPRESS", $"{txtConnect.Text}");
                }
            }
            catch (System.Data.Entity.Core.EntityException)
            {
                load.Dispatcher.Invoke(() => load.Close());
                MessageBox.Show("Connection Error!", "Notify", MessageBoxButton.OK, MessageBoxImage.Error);
                loadThread.Abort();
                return;
            }

            _ParameterVM = new ParameterViewModel();

            WriterFile();

            Login login = new Login();

            load.Dispatcher.Invoke(() => load.Close());

            login.Show();

            login.Focus();

            this.Close();

            loadThread.Abort();
        }

        private void cbConnect_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            txtConnect.Text = cbConnect.SelectedItem.ToString();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void cbDataSource_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbDataSource.SelectedItem == null)
                return;
            txtDataSource.Text = cbDataSource.SelectedItem.ToString();
        }

        private void txtDataSource_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(txtDataSource.Text != cbDataSource.Items[0].ToString())
                cbDataSource.SelectedIndex = -1;
            else
                cbDataSource.SelectedIndex = 0;
        }

        private void WriterFile(string status = null)
        {
            string xmlFilePath = "Data/ServerName.xml";

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(xmlFilePath);

            XmlNode serverNode = xmlDoc.SelectSingleNode("/Server");

            if (serverNode != null)
            {
                if(status != null)
                {
                    serverNode.Attributes["Status"].Value = status;
                    xmlDoc.Save(xmlFilePath);
                    return;
                }
                serverNode.Attributes["Status"].Value = "true";
                serverNode.Attributes["Catalog"].Value = $"{txtDataSource.Text}";
                serverNode.Attributes["Datasource"].Value = $"{txtConnect.Text}";

                xmlDoc.Save(xmlFilePath);
            }
        }

        private void ckAutoConnect_Checked(object sender, RoutedEventArgs e)
        {
            WriterFile("true");
        }

        private void ckAutoConnect_Unchecked(object sender, RoutedEventArgs e)
        {
            WriterFile("false");
        }
    }
}

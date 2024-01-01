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

namespace HungVuong_C5_Assignment
{
    /// <summary>
    /// Interaction logic for ucConfirmDelete.xaml
    /// </summary>
    public partial class ucConfirmLock : UserControl
    {
        private WindowDefault _ParentWindow;
        private ReaderViewModel readerVM = new ReaderViewModel();
        public Child Child1 { get; set; }
        public Child Child2 { get; set; }
        public Reader ChildReader1 { get; set; }
        public Reader ChildReader2 { get; set; }

        public string FullNameChild1 { get; set; }
        public string FullNameChild2 { get; set; }

        public ucConfirmLock(WindowDefault parentWindow, Reader reader, Adult adult, string header, string contentButton, bool status)
        {
            InitializeComponent();

            this._ParentWindow = parentWindow;

            ucAdultInfo.FullName = reader.LName + " " + reader.FName;
            ucAdultInfo.Reader = reader;
            ucAdultInfo.Adult = adult;

            this.DataContext = this;

            Loaded += (sender, e) =>
            {
                ucAdultInfo.ucDataGrid.SetItemsSourceByAdultIdReader(ucAdultInfo.Adult.IdReader, status);

                if (ucAdultInfo.ucDataGrid.dgChildInfo.Items.Count == 0)
                    ucAdultInfo.ucDataGrid.Visibility = Visibility.Collapsed;

                ucAdultInfo.HideHeader();
            };

            lbHeader.Content = header;
            btnDelete.Content = contentButton;
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            this._ParentWindow.DialogResult = true;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this._ParentWindow.DialogResult = false;
            this._ParentWindow.Close();
        }

        private void ucAdultInfo_Loaded(object sender, RoutedEventArgs e)
        {
            
        }
    }
}

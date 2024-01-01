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
    /// Interaction logic for AdultInformation.xaml
    /// </summary>
    public partial class ucAdultInformation : UserControl
    {
        private ReaderViewModel readerVM = new ReaderViewModel();
        public Reader Reader { get; set; }
        public Adult Adult { get; set; }

        public string FullName { get; set; }

        public ucAdultInformation(Reader reader, Adult adult)
        {
            InitializeComponent();
            FullName = reader.LName + " " + reader.FName;
            this.Reader = reader;
            this.Adult = adult;

            ucDataGrid.SetItemsSourceByAdultIdReader(adult.IdReader, true);

            if (ucDataGrid.dgChildInfo.Items.Count == 0)
                ucDataGrid.Visibility = Visibility.Collapsed;

            this.DataContext = this;
        }

        public ucAdultInformation()
        {
            InitializeComponent();
            DataContext = this;
        }

        public void HideHeader()
        {
            lbHeader.Visibility = Visibility.Collapsed;
        }
    }
}

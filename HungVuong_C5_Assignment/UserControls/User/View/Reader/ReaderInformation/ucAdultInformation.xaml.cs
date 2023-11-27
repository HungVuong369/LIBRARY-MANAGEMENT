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
        public Child Child1 { get; set; }
        public Reader ChildReader1 { get; set; }
        public Child Child2 { get; set; }
        public Reader ChildReader2 { get; set; }

        public string FullName { get; set; }

        public ucAdultInformation(Reader reader, Adult adult, Child child1, Child child2)
        {
            InitializeComponent();
            FullName = reader.LName + " " + reader.FName;
            this.Reader = reader;
            this.Adult = adult;
            this.Child1 = child1;
            this.Child2 = child2;

            ucDataGrid.SetItemsSourceByAdultIdReader(adult.IdReader);

            if (ucDataGrid.dgChildInfo.Items.Count == 0)
                ucDataGrid.Visibility = Visibility.Collapsed;

            this.DataContext = this;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for ucSearchByIdentify.xaml
    /// </summary>
    public partial class ucSearchByIdentify : UserControl
    {
        private AdultViewModel _AdultVM = new AdultViewModel();
        private ChildViewModel _ChildVM = new ChildViewModel();
        private ReaderViewModel _ReaderVM = new ReaderViewModel();

        public ucSearchByIdentify()
        {
            InitializeComponent();
        }

        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            ucDataGrid.UpdateDataGridByIdentifyAndName(txtSearch.Text);
        }
    }
}

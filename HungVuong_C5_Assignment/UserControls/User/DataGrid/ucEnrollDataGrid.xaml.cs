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
    /// Interaction logic for ucEnrollDataGrid.xaml
    /// </summary>
    public partial class ucEnrollDataGrid : UserControl
    {
        private EnrolViewModel _EnrollVM = new EnrolViewModel();

        public ucEnrollDataGrid()
        {
            InitializeComponent();
            ReloadDataGrid();
        }

        public void ReloadDataGrid()
        {
            dgEnroll.ItemsSource = null;

            dgEnroll.ItemsSource = _EnrollVM.enrolRepo.Items;
        }
    }
}

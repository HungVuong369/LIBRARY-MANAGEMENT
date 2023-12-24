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
    /// Interaction logic for ucLoanDetailsDataGrid.xaml
    /// </summary>
    public partial class ucLoanDetailsDataGrid : UserControl
    {
        public ucLoanDetailsDataGrid()
        {
            InitializeComponent();
        }

        public void UpdateDataGridByReaderID(string readerID)
        {
            dgLoanDetails.ItemsSource = null;
            dgLoanDetails.ItemsSource = DatabaseFirst.Instance.db.LoanDetails.Where(i => i.LoanSlip.IdReader == readerID).ToList();
        }
    }
}

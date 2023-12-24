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
    /// Interaction logic for ucLoanDetailHistoryDataGrid.xaml
    /// </summary>
    public partial class ucLoanDetailHistoriesDataGrid : UserControl
    {
        public ucLoanDetailHistoriesDataGrid()
        {
            InitializeComponent();
        }

        public void UpdateDataGridByReaderID(string readerID)
        {
            dgLoanDetailHistories.ItemsSource = null;
            dgLoanDetailHistories.ItemsSource = DatabaseFirst.Instance.db.LoanDetailHistories.Where(i => i.LoanHistory.IdReader == readerID).ToList();
        }
    }
}

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
    /// Interaction logic for ucLoanHistoryDataGrid.xaml
    /// </summary>
    public partial class ucLoanHistoryDataGrid : UserControl
    {
        private ObservableCollection<LoanHistory> _StorageLstLoanHistory;
        private ObservableCollection<LoanHistory> _LstLoanHistory;

        public ucLoanHistoryDataGrid()
        {
            InitializeComponent();
        }

        public void Search(string search)
        {
            this._LstLoanHistory.Clear();

            foreach (var item in this._StorageLstLoanHistory)
            {
                if (item.Id.ToLower().Contains(search.ToLower()))
                    this._LstLoanHistory.Add(item);
                else if (item.IdReader.ToLower().Contains(search.ToLower()))
                    this._LstLoanHistory.Add(item);
                else if ((item.Reader.LName + " " + item.Reader.FName).ToLower().Contains(search.ToLower()))
                    this._LstLoanHistory.Add(item);
                else if(item.LoanDate.ToString("dd/MM/yyyy").Contains(search))
                    this._LstLoanHistory.Add(item);
                else if (item.ExpDate.ToString("dd/MM/yyyy").Contains(search))
                    this._LstLoanHistory.Add(item);
            }
            pagination.SetMaxPage<LoanHistory>(_LstLoanHistory.Count);
            pagination.CurrentPage = 1;
            pagination.LoadPage();
        }

        private void btnDetail_Click(object sender, RoutedEventArgs e)
        {
            WindowDefault window = new WindowDefault();
            window.Content = new ucDetailLoanHistory(dgLoanHistories.SelectedItem as LoanHistory);
            window.ShowDialog();
        }

        public void ReloadDataGrid()
        {
            dgLoanHistories.ItemsSource = null;
            dgLoanHistories.ItemsSource = _LstLoanHistory.Skip((pagination.CurrentPage - 1) * pagination.ItemPerPage).Take(pagination.ItemPerPage);
            pagination.ReloadShowing<LoanHistory>(_LstLoanHistory.Count);
        }

        public void ReloadStorage()
        {
            this._StorageLstLoanHistory = new ObservableCollection<LoanHistory>(DatabaseFirst.Instance.db.LoanHistories.ToList());

            this._LstLoanHistory = new ObservableCollection<LoanHistory>(this._StorageLstLoanHistory);

            pagination.SetMaxPage<LoanHistory>(_LstLoanHistory.Count);

            dgLoanHistories.ItemsSource = _LstLoanHistory.Skip((pagination.CurrentPage - 1) * pagination.ItemPerPage).Take(pagination.ItemPerPage);
        }

        public void ReloadStorageByReaderID(string readerID)
        {
            this._StorageLstLoanHistory = new ObservableCollection<LoanHistory>(DatabaseFirst.Instance.db.LoanHistories.Where(i => i.IdReader == readerID));

            this._LstLoanHistory = new ObservableCollection<LoanHistory>(this._StorageLstLoanHistory);

            pagination.SetMaxPage<LoanHistory>(_LstLoanHistory.Count);

            dgLoanHistories.ItemsSource = _LstLoanHistory.Skip((pagination.CurrentPage - 1) * pagination.ItemPerPage).Take(pagination.ItemPerPage);
        }
    }
}

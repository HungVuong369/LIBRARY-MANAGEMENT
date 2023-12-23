using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace HungVuong_C5_Assignment
{
    public class LoanDetailDataGridViewModel : BaseViewModel
    {
        private static LoanDetailDataGridViewModel _Instance;
        private static readonly object _LockObject = new object();
        public ObservableCollection<LoanDetail> LoanDetails { get; set; }
        public LoanDetail SelectedLoanDetail { get; set; }

        public static LoanDetailDataGridViewModel Instance
        {
            get
            {
                if(_Instance == null)
                {
                    lock(_LockObject)
                    {
                        _Instance = new LoanDetailDataGridViewModel();
                    }
                }
                return _Instance;
            }
        }

        public RelayCommand<object> ReturnLoanSlipCommand { get; set; }

        public LoanDetailDataGridViewModel()
        {
            LoanDetails = new ObservableCollection<LoanDetail>();
        }

        public void UpdateLoanDetailsByReaderID(string readerID, ucBorrowingBook borrowingBook = null)
        {
            LoanDetails.Clear();
            var reader = DatabaseFirst.Instance.db.Readers.FirstOrDefault(i => i.Id == readerID);
            if (reader == null)
                return;

            if(reader.ReaderType)
            {
                foreach (var item in reader.LoanSlips.SelectMany(i => i.LoanDetails))
                {
                    LoanDetails.Add(item);
                }
                foreach (var item in reader.Adult.Children.SelectMany(i => i.Reader.LoanSlips.SelectMany(item => item.LoanDetails)))
                {
                    LoanDetails.Add(item);
                }
            }
            else
            {
                var readerAdult = reader.Child.Adult.Reader;

                foreach (var item in readerAdult.LoanSlips.SelectMany(i => i.LoanDetails))
                {
                    LoanDetails.Add(item);
                }

                foreach (var item in readerAdult.Adult.Children.SelectMany(i => i.Reader.LoanSlips.SelectMany(item => item.LoanDetails)))
                {
                    LoanDetails.Add(item);
                }
            }

            ReturnLoanSlipCommand = new RelayCommand<object>(
                p => true,
                p => {
                    Grid grid = Utilities.FindParent<Grid>(borrowingBook);
                    Grid grid1 = Utilities.FindParent<Grid>(grid);
                    Grid grid2 = Utilities.FindParent<Grid>(grid1);
                    UserMenu userMenu = grid2.Parent as UserMenu;
                    userMenu.Animation();
                    userMenu.OpenFeature("F43");
                    LoanHistoryManagement loanHistoryManagement = (grid2.Children[1] as Grid).Children[1] as LoanHistoryManagement;
                    loanHistoryManagement.Loaded += LoanHistoryManagement_Loaded;
                }
            );
        }

        private void LoanHistoryManagement_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            LoanHistoryManagement loanHistoryManagement = sender as LoanHistoryManagement;
            loanHistoryManagement.lbTabMenu.SelectedIndex = 1;
            ucReturnBook returnBook = ((loanHistoryManagement.Content as Grid).Children[2] as Grid).Children[2] as ucReturnBook;

            returnBook.LoanHistoryVM.ReaderID = SelectedLoanDetail.LoanSlip.Reader.Id;
            returnBook.LoanHistoryVM.UpdateReaderID();

            LoanHistoryDataGrid.Instance.SelectedLoanSlip = LoanHistoryDataGrid.Instance.LoanSlips.FirstOrDefault(i => i.Id == SelectedLoanDetail.LoanSlip.Id);
            LoanHistoryDataGrid.Instance.SelectLoanSlip();
        }
    }
}

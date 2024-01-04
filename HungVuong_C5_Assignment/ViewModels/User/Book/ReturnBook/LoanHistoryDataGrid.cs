using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace HungVuong_C5_Assignment
{
    public class LoanHistoryDataGrid : BaseViewModel
    {
        private static readonly object _LockObject = new object();

        public ObservableCollection<LoanSlip> LoanSlips { get; set; }

        private LoanSlip _SelectedLoanSlip = null;
        public LoanSlip SelectedLoanSlip
        {
            get { return _SelectedLoanSlip; }
            set
            {
                _SelectedLoanSlip = value;
                OnPropertyChanged();
            }
        }

        private static LoanHistoryDataGrid _Instance;

        public static LoanHistoryDataGrid Instance
        {
            get
            {
                if (_Instance == null)
                {
                    lock (_LockObject)
                    {
                        _Instance = new LoanHistoryDataGrid();
                    }
                }
                return _Instance;
            }
        }

        public RelayCommand<object> SelectionChangedLoanSlipCommand { get; private set; }
        public RelayCommand<object> EditCommand { get; private set; }
        public LoanDetailHistory SelectedLoanDetailHistory { get; set; }

        public delegate void OnClickBook();
        public event OnClickBook ClickedBook;

        public delegate void UpdateLoanSlipView();
        public event UpdateLoanSlipView updateLoanSlipViewEvent;

        public LoanHistoryDataGrid()
        {
            LoanSlips = new ObservableCollection<LoanSlip>();

            EditCommand = new RelayCommand<object>(
                p => true,
                p => {
                    var selectedLoanBook = ShowBooksViewModel.Instance.SelectedLoanBook;
                    ShowBooksViewModel.Instance.SelectedLoanBook.fadeInOutStoryboard.Begin();

                    SelectedLoanDetailHistory = selectedLoanBook.Tag as LoanDetailHistory;
                    OnPropertyChanged(nameof(SelectedLoanDetailHistory));
                    ClickedBook?.Invoke();
                }
            );

            SelectionChangedLoanSlipCommand = new RelayCommand<object>(
                p => true,
                p => {
                    SelectLoanSlip();
                }
            );
        }

        public void UpdateLoanSlipsByReaderID(string readerID)
        {
            LoanSlips.Clear();

            foreach (var item in DatabaseFirst.Instance.db.LoanSlips.Where(i => i.IdReader == readerID))
            {
                LoanSlips.Add(item);
            }

            updateLoanSlipViewEvent?.Invoke();
        }

        public void SelectLoanSlip()
        {
            SelectedLoanDetailHistory = null;
            OnPropertyChanged(nameof(SelectedLoanDetailHistory));

            if (SelectedLoanSlip == null)
            {
                ShowBooksViewModel.Instance.ResetLoaningBook();
                return;
            }

            ShowBooksViewModel.Instance.LstLoaningBook.Clear();

            var lstLoanDetailByLoanID = DatabaseFirst.Instance.db.LoanDetails.Where(i => i.IdLoan == SelectedLoanSlip.Id);

            var count = 1;

            foreach (var i in lstLoanDetailByLoanID)
            {
                var bookInfo = new BookInformation()
                {
                    Id = i.Book.Id,
                    BookAuthor = i.Book.BookISBN.Author,
                    BookPublisher = i.Book.Publisher,
                    BookTranslator = i.Book.Translator,
                    Category = i.Book.BookISBN.BookTitle.Category.Name,
                    Name = i.Book.BookISBN.BookTitle.Name,
                    ISBN = i.Book.ISBN,
                    Language = i.Book.Language,
                    PublishDate = i.Book.PublishDate,
                    Quantity = -1,
                    Status = true,
                    UrlImage = i.Book.BookISBN.BookTitle.UrlImage
                };
                ucLoanBook ucLoanBook = new ucLoanBook(bookInfo);
                ucLoanBook.btnContainer.Command = EditCommand;

                ucLoanBook.Tag = new LoanDetailHistory()
                {
                    Id = LoanDetailHistoryRepository.GetNewID(count++),
                    IdBook = bookInfo.Id,
                    Book = DatabaseFirst.Instance.db.Books.FirstOrDefault(item => item.Id == bookInfo.Id),
                    ExpDate = i.ExpDate,
                    IdLoanHistory = LoanHistoryRepository.GetNewID()
                };
                ShowBooksViewModel.Instance.LstLoaningBook.Add(ucLoanBook);
            }
            ShowBooksViewModel.Instance.UpdateViewLoaningBook();
            updateLoanSlipViewEvent?.Invoke();
        }
    }
}

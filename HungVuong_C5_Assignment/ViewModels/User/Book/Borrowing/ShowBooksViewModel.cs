using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace HungVuong_C5_Assignment
{
    public class ShowBooksViewModel : BaseViewModel
    {
        private static readonly object _LockObject = new object();
        private static ShowBooksViewModel _Instance = null;
        public static ShowBooksViewModel Instance
        {
            get
            {
                if(_Instance == null)
                {
                    lock(_LockObject)
                    {
                        _Instance = new ShowBooksViewModel();
                    }
                }
                return _Instance;
            }
        }

        private bool _IsInputReader = true;
        public bool IsInputReader
        {
            get
            {
                return _IsInputReader;
            }
            set
            {
                _IsInputReader = value;
                OnPropertyChanged();
            }
        }

        private bool _IsCreateLoanSlip = true;
        public bool IsCreateLoanSlip
        {
            get
            {
                return _IsCreateLoanSlip;
            }
            set
            {
                _IsCreateLoanSlip = value;
                OnPropertyChanged();
            }
        }

        public Reader SelectedReader { get; set; }

        private List<BookISBN> StorageListBookISBN = DatabaseFirst.Instance.db.BookISBNs.Where(i => i.Status == true).ToList();

        public List<ucShowBook> LstShowBook { get; set; } = new List<ucShowBook>();
        public ucShowBook SelectedShowBook { get; set; }
        public ucLoanBook _SelectedLoanBook = null;
        public ucLoanBook SelectedLoanBook
        {
            get
            {
                return _SelectedLoanBook;
            }
            set
            {
                if(_SelectedLoanBook != null)
                {
                    SelectedLoanBook.fadeInOutStoryboard.Stop();
                }

                _SelectedLoanBook = value;
                OnPropertyChanged();
            }
        }
        public List<ucLoanBook> LstLoaningBook { get; private set; } = new List<ucLoanBook>();
        public RelayCommand<object> AddBookCommand { get; private set; }
        public RelayCommand<object> RemoveBookCommand { get; private set; }

        public ShowBooksViewModel()
        {
            AddBookCommand = new RelayCommand<object>(
                p => true,
                p => {
                    ParameterViewModel parameterVM = new ParameterViewModel();

                    BookISBN bookISBN = (SelectedShowBook as ucShowBook).BookISBN;
                    if(SelectedReader.ReaderType)
                    {
                        if (SelectedReader.LoanSlips.Any(ls => ls.LoanDetails.Any(ld => ld.Book.ISBN == bookISBN.ISBN)))
                        {
                            MessageBox.Show("Each Book ISBN can only loan 1 book!", "Notify", MessageBoxButton.OK, MessageBoxImage.Warning);
                            return;
                        }

                        bool isExisted = SelectedReader.Adult.Children.Select(i => i.Reader)
                                        .SelectMany(child => child.LoanSlips ?? Enumerable.Empty<LoanSlip>())
                                        .SelectMany(loanSlip => loanSlip.LoanDetails ?? Enumerable.Empty<LoanDetail>())
                                        .Any(loanDetail => loanDetail.Book?.ISBN == bookISBN.ISBN);

                        if (isExisted == true)
                        {
                            MessageBox.Show("Each Book ISBN can only loan 1 book!", "Notify", MessageBoxButton.OK, MessageBoxImage.Warning);
                            return;
                        }

                        int quantityLoanSlipAdult = SelectedReader.LoanSlips.Select(i => i.Quantity).Sum();
                        int quantityLoanSlipChild = SelectedReader.Adult.Children.Select(i => i.Reader.LoanSlips.Select(item => item.Quantity).Sum()).Sum();

                        if(quantityLoanSlipAdult + quantityLoanSlipChild + LstLoaningBook.Count >= int.Parse(parameterVM.GetValueByID("QD2").Split(':')[0]))
                        {
                            MessageBox.Show("Cannot loan more books!", "Notify", MessageBoxButton.OK, MessageBoxImage.Warning);
                            return;
                        }
                    }
                    else
                    {
                        bool isExisted = SelectedReader.Child.Adult.Reader.LoanSlips.SelectMany(i => i.LoanDetails).Any(item => item.Book.ISBN == bookISBN.ISBN);
                        if (isExisted)
                        {
                            MessageBox.Show("Each Book ISBN can only loan 1 book!", "Notify", MessageBoxButton.OK, MessageBoxImage.Warning);
                            return;
                        }

                        int quantity = SelectedReader.LoanSlips.Select(i => i.Quantity).Sum();

                        if (quantity + LstLoaningBook.Count >= int.Parse(parameterVM.GetValueByID("QD3")))
                        {
                            MessageBox.Show("Cannot loan more books!", "Notify", MessageBoxButton.OK, MessageBoxImage.Warning);
                            return;
                        }
                    }
                    WindowDefault window = new WindowDefault();
                    window.Content = new ucSelectBookByISBN(window, bookISBN.ISBN);
                    window.ShowDialog();

                    if(window.DialogResult == true)
                    {
                        var book = window.Tag as BookInformation;
                        LstLoaningBook.Add(new ucLoanBook(book));
                        LstLoaningBook = new List<ucLoanBook>(LstLoaningBook.Select(i => i));
                        OnPropertyChanged(nameof(LstLoaningBook));
                        UpdateViewBooks();
                        IsInputReader = false;
                        IsCreateLoanSlip = true;
                    }
                }    
            );

            RemoveBookCommand = new RelayCommand<object>(
               p => true,
               p => {
                   LstLoaningBook.Remove(SelectedLoanBook);
                   LstLoaningBook = new List<ucLoanBook>(LstLoaningBook.Select(i => i));
                   OnPropertyChanged(nameof(LstLoaningBook));
                   UpdateViewBooks();
                   if(LstLoaningBook.Count == 0)
                   {
                       IsInputReader = true;

                       IsCreateLoanSlip = false;
                   }
               }
           );
        }

        public void ReloadStorage()
        {
            StorageListBookISBN = DatabaseFirst.Instance.db.BookISBNs.Where(i => i.Status == true).ToList();
        }

        public void UpdateViewBooks(string categoryID, string authorID, string bookName)
        {
            LstShowBook.Clear();

            var filter = StorageListBookISBN.Where(i => i.Status == true);
            filter = filter.Where(i => i.BookTitle.Name.ToLower().Contains(bookName.ToLower()));

            if (categoryID != "None")
                filter = filter.Where(i => i.BookTitle.IdCategory == categoryID);
            if(authorID != "None")
                filter = filter.Where(i => i.IdAuthor == authorID);

            var lstShowBook = new List<ucShowBook>();
            foreach (var item in filter)
            {
                var subtractNumber = LstLoaningBook.Where(i => (i.BookInfo).ISBN == item.ISBN).Count();

                ucShowBook ucShowBook = new ucShowBook(item, subtractNumber);

                // Quantity Book Now
                if(subtractNumber >= 1)
                {
                    ucShowBook.Opacity = 0.5;
                    ucShowBook.IsHitTestVisible = false;
                }
                lstShowBook.Add(ucShowBook);
            }
            LstShowBook = lstShowBook;
            OnPropertyChanged(nameof(LstShowBook));
        }

        public void UpdateViewBooks()
        {
            LstShowBook.Clear();

            var lstShowBook = new List<ucShowBook>();
            foreach (var item in StorageListBookISBN)
            {
                var subtractNumber = LstLoaningBook.Where(i => (i.BookInfo).ISBN == item.ISBN).Count();

                ucShowBook ucShowBook = new ucShowBook(item, subtractNumber);

                if (subtractNumber >= 1)
                {
                    ucShowBook.Opacity = 0.5;
                    ucShowBook.IsHitTestVisible = false;
                }

                lstShowBook.Add(ucShowBook);
            }

            LstShowBook = lstShowBook;
            OnPropertyChanged(nameof(LstShowBook));
        }

        public void ResetLoaningBook()
        {
            LstLoaningBook.Clear();
            LstLoaningBook = new List<ucLoanBook>(LstLoaningBook.Select(i => i));
            OnPropertyChanged(nameof(LstLoaningBook));
        }

        public void UpdateViewLoaningBook()
        {
            LstLoaningBook = new List<ucLoanBook>(LstLoaningBook.Select(i => i));
            OnPropertyChanged(nameof(LstLoaningBook));
        }
    }
}

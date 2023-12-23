using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace HungVuong_C5_Assignment
{
    public class LoanSlipViewModel : INotifyPropertyChanged
    {
        private ParameterViewModel _ParameterVM = new ParameterViewModel();

        public Brush ForegroundQuantity { get; set; } = Brushes.Green;
        public string ISBN { get; set; } = "";
        public string ReaderID { get; set; } = "";
        public string ReaderName { get; set; } = "None";
        public string ReaderType { get; set; } = "None";
        public string Status { get; set; } = "None";
        public string Quantity { get; set; } = "None";

        private decimal _Opacity = 0.5m;
        public decimal Opacity
        {
            get
            {
                return _Opacity;
            }
            set
            {
                _Opacity = value;
                OnPropertyChanged();
            }
        }

        private bool _IsDropDownReaderID = false;
        public bool IsDropDownReaderID
        {
            get
            {
                return _IsDropDownReaderID;
            }
            set
            {
                _IsDropDownReaderID = value;
                OnPropertyChanged();
            }
        }

        private bool _IsAllowLoanBooks = false;
        public bool IsAllowLoanBooks
        {
            get
            {
                return _IsAllowLoanBooks;
            }
            set
            {
                _IsAllowLoanBooks = value;
                OnPropertyChanged();
            }
        }

        public ShowBooksViewModel ShowBookVM { get; set; } = ShowBooksViewModel.Instance;
        private Reader _SelectedReader = null;
        public Reader SelectedReader
        {
            get { return _SelectedReader; }
            set
            {
                _SelectedReader = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<Reader> _FilterReaders = null;
        public ObservableCollection<Reader> FilterReaders
        {
            get
            {
                return _FilterReaders;
            }
            set
            {
                _FilterReaders = value;
                OnPropertyChanged();
            }
        }

        private static readonly UnitOfWork unitOfWork = new UnitOfWork();
        public LoanSlipRepository loanSlipRepo;

        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<LoanDetailDto> LstLoanDetail { get; set; } = new ObservableCollection<LoanDetailDto>();

        public RelayCommand<object> AddBookISBNCommand { get; private set; }
        public RelayCommand<object> AddLoanSlipCommand { get; private set; }
        public RelayCommand<object> TextChangedReaderIDCommand { get; private set; }
        public RelayCommand<object> SelectionChangedReaderIDCommand { get; private set; }
        public RelayCommand<object> CreateLoanSlipCommand { get; private set; }
        public ucBorrowingBook borrowingBook;

        public LoanSlipViewModel()
        {
            this.loanSlipRepo = unitOfWork.Loanslips;
            ShowBookVM.IsInputReader = true;
            ShowBookVM.IsCreateLoanSlip = false;
            FilterReaders = new ObservableCollection<Reader>();
            TextChangedReaderIDCommand = new RelayCommand<object>(
                p => { return true; },
                p =>
                {
                    SelectedReader = null;

                    if (ReaderID == string.Empty)
                    {
                        IsDropDownReaderID = false;
                        SetValueReader("None", "None", "None", "None");
                        LoanDetailDataGridViewModel.Instance.UpdateLoanDetailsByReaderID(string.Empty);
                        IsAllowLoanBooks = false;
                        Opacity = 0.5m;
                        return;
                    }

                    FilterReaders.Clear();

                    foreach (var item in DatabaseFirst.Instance.db.Readers.Where(i => i.Status == true && i.Id.ToLower().Contains(ReaderID.ToLower())))
                    {
                        FilterReaders.Add(item);
                    }

                    if (FilterReaders.Count == 0)
                    {
                        IsDropDownReaderID = false;
                        SetValueReader("None", "None", "None", "None");
                        LoanDetailDataGridViewModel.Instance.UpdateLoanDetailsByReaderID(string.Empty);
                        IsAllowLoanBooks = false;
                        Opacity = 0.5m;
                        return;
                    }
                    else if (FilterReaders.Count == 1)
                    {
                        if (ReaderID.ToLower() != FilterReaders.FirstOrDefault().Id.ToLower())
                        {
                            return;
                        }

                        ShowBooksViewModel.Instance.SelectedReader = SelectedReader = FilterReaders.FirstOrDefault();

                        SetValueByReaderType();

                        LoanDetailDataGridViewModel.Instance.UpdateLoanDetailsByReaderID(SelectedReader.Id, borrowingBook);
                    }
                    else
                    {
                        SetValueReader("None", "None", "None", "None");
                        LoanDetailDataGridViewModel.Instance.UpdateLoanDetailsByReaderID(string.Empty);
                        IsAllowLoanBooks = false;
                        Opacity = 0.5m;
                    }

                    IsDropDownReaderID = true;
                }
            );

            SelectionChangedReaderIDCommand = new RelayCommand<object>(
                p => true,
                p =>
                {
                    if (SelectedReader == null)
                        return;
                    ReaderID = SelectedReader.Id;
                    OnPropertyChanged(nameof(ReaderID));
                }
            );

            CreateLoanSlipCommand = new RelayCommand<object>(
                p => true,
                p => {
                    decimal pricePerBook = decimal.Parse(_ParameterVM.GetValueByID("QD10"));
                    decimal depositPerBook = decimal.Parse(_ParameterVM.GetValueByID("QD11").Split('%').FirstOrDefault());

                    decimal loanPaid = ShowBookVM.LstLoaningBook.Count * pricePerBook;
                    decimal deposit = ShowBookVM.LstLoaningBook.Select(i => (depositPerBook * DatabaseFirst.Instance.db.Books.FirstOrDefault(item => item.Id == i.BookInfo.Id).PriceCurrent) / 100).Sum();

                    LoanSlip loanSlip = new LoanSlip()
                    {
                        LoanPaid = loanPaid,
                        Deposit = deposit,
                        ExpDate = DateTime.Now.AddDays(int.Parse(_ParameterVM.GetValueByID("QD9"))),
                        LoanDate = DateTime.Now,
                        Id = LoanSlipRepository.GetNewID(),
                        IdReader = SelectedReader.Id,
                        Quantity = ShowBookVM.LstLoaningBook.Count,
                        IdUser = DatabaseFirst.Instance.UserLoggedIn.Id
                    };

                    WindowDefault window = new WindowDefault();
                    window.Content = new ConfirmLoanBooks(window, loanSlip, ShowBookVM.LstLoaningBook.Select(i => DatabaseFirst.Instance.db.Books.FirstOrDefault(item => item.Id == i.BookInfo.Id)).ToList());
                    window.ShowDialog();

                    int count = 1;
                    foreach(var item in ShowBookVM.LstLoaningBook.Select(i => i.BookInfo))
                    {
                        var newLoanDetail = new LoanDetail()
                        {
                            Id = LoanDetailRepository.GetNewID(count++),
                            ExpDate = loanSlip.ExpDate,
                            IdBook = item.Id,
                            IdLoan = loanSlip.Id
                        };
                        loanSlip.LoanDetails.Add(newLoanDetail);
                    }

                    if (window.DialogResult == true)
                    {
                        LoanManagementRepository loanManagementRepo = new LoanManagementRepository();
                        loanManagementRepo.Add(loanSlip, loanSlip.LoanDetails.ToList());
                        MessageBox.Show("Add Loan Slip Successfully!", "Notify", MessageBoxButton.OK, MessageBoxImage.Information);

                        ShowBooksViewModel.Instance.ReloadStorage();

                        ReaderID = string.Empty;
                        OnPropertyChanged(nameof(ReaderID));

                        ShowBooksViewModel.Instance.ResetLoaningBook();

                        ShowBooksViewModel.Instance.UpdateViewBooks("None", "None", "");
                    }
                }
            );
        }

        private void SetValueByReaderType()
        {
            if (SelectedReader.ReaderType)
            {
                int quantityLoanSlipAdult = SelectedReader.LoanSlips.Select(i => i.Quantity).Sum();
                int quantityLoanSlipChild = SelectedReader.Adult.Children.Select(i => i.Reader.LoanSlips.Select(item => item.Quantity).Sum()).Sum();

                if ((quantityLoanSlipAdult + quantityLoanSlipChild) >= int.Parse(_ParameterVM.GetValueByID("QD2").Split(':')[0]))
                {
                    SetValueReader(SelectedReader.LName + " " + SelectedReader.FName, "Người lớn", DateTime.Now.Date > SelectedReader.Adult.ExpireDate ? "Unavailable" : "Available", (quantityLoanSlipAdult + quantityLoanSlipChild) + " (MAX)");
                    IsAllowLoanBooks = false;
                    Opacity = 0.5m;
                }
                else
                {
                    string check = DateTime.Now.Date > SelectedReader.Adult.ExpireDate ? "Unavailable" : "Available";
                    if (check == "Unavailable")
                    {
                        Opacity = 0.5m;
                        IsAllowLoanBooks = false;
                    }
                    else
                    {
                        Opacity = 1;
                        IsAllowLoanBooks = true;
                    }
                    SetValueReader(SelectedReader.LName + " " + SelectedReader.FName, "Người lớn", check, (quantityLoanSlipAdult + quantityLoanSlipChild).ToString());
                }

                var isCheck = SelectedReader.LoanSlips.FirstOrDefault(i => DateTime.Now.Date > i.ExpDate.Date);
                var ischeckChild = SelectedReader.Adult.Children.Select(i => i.Reader.LoanSlips.FirstOrDefault(item => DateTime.Now.Date > item.ExpDate.Date)).FirstOrDefault();

                if (isCheck != null || ischeckChild != null)
                {
                    Opacity = 0.5m;
                    IsAllowLoanBooks = false;
                    return;
                }
            }
            else
            {
                int quantity = SelectedReader.LoanSlips.Select(i => i.Quantity).Sum();
                int quantityBookChild = SelectedReader.Child.Adult.Children.Select(i => i.Reader.LoanSlips.Select(item => item.Quantity).Sum()).Sum();
                int quantityBookAdult = SelectedReader.Child.Adult.Reader.LoanSlips.Select(i => i.Quantity).Sum();

                if((quantityBookAdult + quantityBookChild) == int.Parse(_ParameterVM.GetValueByID("QD2").Split(':')[0]))
                {
                    SetValueReader(SelectedReader.LName + " " + SelectedReader.FName, "Trẻ em", DateTime.Now.Date > SelectedReader.Child.Adult.ExpireDate ? "Unavailable" : "Available", quantity + " (MAX)");
                    Opacity = 0.5m;
                    IsAllowLoanBooks = false;
                }
                else if (quantity == int.Parse(_ParameterVM.GetValueByID("QD3")))
                {
                    SetValueReader(SelectedReader.LName + " " + SelectedReader.FName, "Trẻ em", DateTime.Now.Date > SelectedReader.Child.Adult.ExpireDate ? "Unavailable" : "Available", quantity + " (MAX)");
                    Opacity = 0.5m;
                    IsAllowLoanBooks = false;
                }
                else
                {
                    var check = DateTime.Now.Date > SelectedReader.Child.Adult.ExpireDate ? "Unavailable" : "Available";
                    if(check == "Unavailable")
                    {
                        Opacity = 0.5m;
                        IsAllowLoanBooks = false;
                    }
                    else {
                        Opacity = 1;
                        IsAllowLoanBooks = true;
                    }

                    SetValueReader(SelectedReader.LName + " " + SelectedReader.FName, "Trẻ em", check, quantity.ToString());
                }

                var isCheck = SelectedReader.Child.Adult.Reader.LoanSlips.FirstOrDefault(i => DateTime.Now.Date > i.ExpDate.Date);
                var isCheckChild = SelectedReader.Child.Adult.Children.Select(i => i.Reader.LoanSlips.FirstOrDefault(item => DateTime.Now.Date > item.ExpDate.Date)).FirstOrDefault();
                if (isCheck != null || isCheckChild != null)
                {
                    Opacity = 0.5m;
                    IsAllowLoanBooks = false;
                    return;
                }
            }
        }

        private void SetValueReader(string name, string readerType, string status, string quantity)
        {
            this.ReaderName = name;
            this.ReaderType = readerType;
            this.Status = status;
            this.Quantity = quantity;

            if (quantity.Contains("MAX"))
                ForegroundQuantity = Brushes.Red;
            else
                ForegroundQuantity = Brushes.Green;

            OnPropertyChanged(nameof(ReaderName));
            OnPropertyChanged(nameof(ReaderType));
            OnPropertyChanged(nameof(Status));
            OnPropertyChanged(nameof(Quantity));
            OnPropertyChanged(nameof(ForegroundQuantity));
        }

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}

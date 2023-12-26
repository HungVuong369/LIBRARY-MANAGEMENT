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
    public class LoanHistoryViewModel : BaseViewModel
    {
        private static readonly UnitOfWork unitOfWork = new UnitOfWork();
        public LoanHistoryRepository loanHistoryRepo;

        public string ISBN { get; set; } = "";
        public string _ReaderID = "";
        public string ReaderID
        {
            get
            {
                return _ReaderID;
            }
            set
            {
                _ReaderID = value;
                OnPropertyChanged();
            }
        }
        public string ReaderName { get; set; } = "None";
        public string ReaderType { get; set; } = "None";
        public string Status { get; set; } = "None";
        public string Quantity { get; set; } = "None";

        public Brush ForegroundQuantity { get; set; } = Brushes.Green;

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

        private bool _IsEnabledPrice = false;
        public bool IsEnabledPrice
        {
            get
            {
                return _IsEnabledPrice;
            }
            set
            {
                _IsEnabledPrice = value;
                OnPropertyChanged();
            }
        }

        private bool _IsReturnBook = false;
        public bool IsReturnBook
        {
            get
            {
                return _IsReturnBook;
            }
            set
            {
                _IsReturnBook = value;
                OnPropertyChanged();
            }
        }

        private string _Price = "0,000";
        public string Price
        {
            get
            {
                return _Price;
            }
            set
            {
                _Price = value;
                OnPropertyChanged();
            }
        }

        private string _PreviousPrice = null;

        private ParameterViewModel _ParameterVM = new ParameterViewModel();

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

        public List<PenaltyReason> PenaltyReason { get; private set; } = new List<PenaltyReason>(DatabaseFirst.Instance.db.PenaltyReasons);
        private PenaltyReason _SelectedPenaltyReason = null;
        public PenaltyReason SelectedPenaltyReason
        {
            get
            {
                return _SelectedPenaltyReason;
            }
            set
            {
                _SelectedPenaltyReason = value;
                OnPropertyChanged();
            }
        }

        private LoanHistory _SelectedLoanHistory = null;
        public LoanHistory SelectedLoanHistory
        {
            get
            {
                return _SelectedLoanHistory;
            }
            set
            {
                _SelectedLoanHistory = value;
                OnPropertyChanged();
            }
        }

        private int _LoanPeriod = 0;
        public int LoanPeriod
        {
            get
            {
                return _LoanPeriod;
            }
            set
            {
                _LoanPeriod = value;
                OnPropertyChanged();
            }
        }

        private decimal _LateFee = 0;
        public decimal LateFee
        {
            get
            {
                return _LateFee;
            }
            set
            {
                _LateFee = value;
                OnPropertyChanged();
            }
        }

        private decimal _OtherFee = 0;
        public decimal OtherFee
        {
            get
            {
                return _OtherFee;
            }

            set
            {
                _OtherFee = value;
                OnPropertyChanged();
            }
        }

        private decimal _Payment = 0;
        public decimal Payment
        {
            get
            {
                return _Payment;
            }

            set
            {
                _Payment = value;
                OnPropertyChanged();
            }
        }

        public RelayCommand<object> TextChangedReaderIDCommand { get; private set; }
        public RelayCommand<object> SelectionChangedReaderIDCommand { get; private set; }
        public RelayCommand<object> ReasonSelectionChanged { get; private set; }
        public RelayCommand<object> ReturnBookCommand { get; private set; }
        public RelayCommand<object> PriceTextChangedCommand { get; private set; }

        public LoanHistoryViewModel()
        {
            loanHistoryRepo = unitOfWork.LoanHistories;

            LoanHistoryDataGrid.Instance.ClickedBook += Instance_ClickedBook;
            LoanHistoryDataGrid.Instance.updateLoanSlipViewEvent += Instance_updateLoanSlipViewEvent;

            LoanHistoryDataGrid.Instance.SelectedLoanDetailHistory = null;
            ShowBooksViewModel.Instance.SelectedLoanBook = null;
            OnPropertyChanged(nameof(LoanHistoryDataGrid.Instance.SelectedLoanDetailHistory));
            FilterReaders = new ObservableCollection<Reader>();

            SelectedPenaltyReason = PenaltyReason.FirstOrDefault();

            TextChangedReaderIDCommand = new RelayCommand<object>(
                p => { return true; },
                p =>
                {
                    UpdateReaderID();
                }
            );

            SelectionChangedReaderIDCommand = new RelayCommand<object>(
                p => true,
                p =>
                {
                    if (SelectedReader == null)
                        return;
                    ReaderID = SelectedReader.Id;
                }
            );

            ReturnBookCommand = new RelayCommand<object>(
                p => true,
                p =>
                {
                    if (MessageBox.Show("Do you want to save the loan history slip?", "Notify", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                    {
                        SelectedLoanHistory.Total = Payment;
                        SelectedLoanHistory.FineMoney = LateFee + OtherFee;
                        SelectedLoanHistory.IdUser = DatabaseFirst.Instance.UserLoggedIn.Id;

                        LoanHistoryManagementRepository loanHistoryManagementRepo = new LoanHistoryManagementRepository();
                        loanHistoryManagementRepo.Add(SelectedLoanHistory, SelectedLoanHistory.LoanDetailHistories.ToList(), LoanHistoryDataGrid.Instance.SelectedLoanSlip);
                        MessageBox.Show("Add Loan History Successfully!", "Notify", MessageBoxButton.OK, MessageBoxImage.Information);
                        ReaderID = string.Empty;
                    }
                }
            );

            PriceTextChangedCommand = new RelayCommand<object>(
                p => true,
                p =>
                {
                    if (Price == "0.000")
                        return;

                    var selectedLoanBook = ShowBooksViewModel.Instance.SelectedLoanBook;
                    var loanDetailHistory = selectedLoanBook.Tag as LoanDetailHistory;

                    if (_PreviousPrice != null)
                    {
                        if (loanDetailHistory.Note != null && loanDetailHistory.Note == "PR3")
                        {
                            UpdatePaymentAndOtherFee(loanDetailHistory.PaidMoney.ToString(), Price);
                        }
                        else
                        {
                            if (loanDetailHistory.Note != null)
                            {
                                UpdatePaymentAndOtherFee(_PreviousPrice, Price);
                            }
                            else
                            {
                                PlusPaymentAndOtherFee(Price);
                            }
                        }

                        loanDetailHistory.Note = SelectedPenaltyReason.Id;

                        loanDetailHistory.PaidMoney = decimal.Parse(Price.Replace(".", ",").Replace(",", "").Insert(Price.Replace(".", ",").Replace(",", "").Length - 3, "."));

                        selectedLoanBook.Tag = loanDetailHistory;
                    }

                    _PreviousPrice = Price;
                }
            );

            ReasonSelectionChanged = new RelayCommand<object>(
                p => true,
                p =>
                {
                    IsEnabledPrice = false;

                    var selectedLoanBook = ShowBooksViewModel.Instance.SelectedLoanBook;

                    if (selectedLoanBook == null)
                        return;

                    var loanDetailHistory = selectedLoanBook.Tag as LoanDetailHistory;

                    if (SelectedPenaltyReason == null)
                        return;

                    PriceTextChangedCommand.SetCanExecute(false);

                    if (SelectedPenaltyReason.Id == "PR2")
                    {
                        Price = loanDetailHistory.Book.Price.ToString();
                    }
                    else if (SelectedPenaltyReason.Id == "PR3")
                    {
                        IsEnabledPrice = true;

                        PriceTextChangedCommand.SetCanExecute(true);

                        if (loanDetailHistory.Note != null)
                        {
                            if (loanDetailHistory.Note == "PR3")
                            {
                                Price = loanDetailHistory.PaidMoney.ToString();
                            }
                            else
                                Price = SelectedPenaltyReason.Price.ToString();
                        }
                        else
                            Price = SelectedPenaltyReason.Price.ToString();

                        return;
                    }
                    else
                        Price = SelectedPenaltyReason.Price.ToString();

                    if (loanDetailHistory.Note != null)
                    {
                        UpdatePaymentAndOtherFee(loanDetailHistory.PaidMoney.ToString(), Price);
                    }
                    else
                    {
                        PlusPaymentAndOtherFee(Price);
                    }

                    loanDetailHistory.Note = SelectedPenaltyReason.Id;

                    loanDetailHistory.PaidMoney = decimal.Parse(Price);

                    selectedLoanBook.Tag = loanDetailHistory;

                    _PreviousPrice = decimal.Parse(Price).ToString();
                }
            );
        }

        private void UpdatePaymentAndOtherFee(string price, string newPrice)
        {
            Payment -= decimal.Parse(price.Replace(".", ",").Replace(",", "").Insert(price.Replace(".", ",").Replace(",", "").Length - 3, "."));
            Payment += decimal.Parse(newPrice.Replace(".", ",").Replace(",", "").Insert(newPrice.Replace(".", ",").Replace(",", "").Length - 3, "."));

            OtherFee -= decimal.Parse(price.Replace(".", ",").Replace(",", "").Insert(price.Replace(".", ",").Replace(",", "").Length - 3, "."));
            OtherFee += decimal.Parse(newPrice.Replace(".", ",").Replace(",", "").Insert(newPrice.Replace(".", ",").Replace(",", "").Length - 3, "."));
        }

        private void PlusPaymentAndOtherFee(string price)
        {
            Payment += decimal.Parse(price.Replace(".", ",").Replace(",", "").Insert(price.Replace(".", ",").Replace(",", "").Length - 3, "."));

            OtherFee += decimal.Parse(price.Replace(".", ",").Replace(",", "").Insert(price.Replace(".", ",").Replace(",", "").Length - 3, "."));
        }

        public void UpdateReaderID()
        {
            SelectedReader = null;

            if (ReaderID == string.Empty)
            {
                IsDropDownReaderID = false;
                SetValueReader("None", "None", "None", "None");
                LoanHistoryDataGrid.Instance.UpdateLoanSlipsByReaderID(string.Empty);
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
                LoanHistoryDataGrid.Instance.UpdateLoanSlipsByReaderID(string.Empty);
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
                LoanHistoryDataGrid.Instance.UpdateLoanSlipsByReaderID(SelectedReader.Id);
            }
            else
            {
                SetValueReader("None", "None", "None", "None");
                LoanHistoryDataGrid.Instance.UpdateLoanSlipsByReaderID(string.Empty);
            }

            IsDropDownReaderID = true;
        }

        public void Instance_updateLoanSlipViewEvent()
        {
            var selectedLoanSlip = LoanHistoryDataGrid.Instance.SelectedLoanSlip;

            if (selectedLoanSlip == null)
            {
                PriceTextChangedCommand.SetCanExecute(false);
                SelectedPenaltyReason = PenaltyReason.FirstOrDefault();

                LoanPeriod = 0;
                OtherFee = LateFee = Payment = 0;

                SelectedLoanHistory = null;
                IsReturnBook = false;
                return;
            }
            PriceTextChangedCommand.SetCanExecute(false);
            SelectedPenaltyReason = PenaltyReason.FirstOrDefault();
            OtherFee = 0;

            IsReturnBook = true;

            List<LoanDetailHistory> loanDetailHistories = new List<LoanDetailHistory>();
            loanDetailHistories = ShowBooksViewModel.Instance.LstLoaningBook.Select(i => i.Tag as LoanDetailHistory).ToList();

            SelectedLoanHistory = new LoanHistory()
            {
                Id = LoanHistoryRepository.GetNewID(),
                CreateAt = DateTime.Now,
                Deposit = selectedLoanSlip.Deposit,
                ExpDate = selectedLoanSlip.ExpDate,
                IdReader = selectedLoanSlip.IdReader,
                LoanDate = selectedLoanSlip.LoanDate,
                Quantity = selectedLoanSlip.Quantity,
                LoanPaid = selectedLoanSlip.LoanPaid,
                LoanDetailHistories = loanDetailHistories
            };

            Payment = SelectedLoanHistory.LoanPaid;

            var day = (DateTime.Now.Date - selectedLoanSlip.ExpDate.Date).Days;

            if (day < 0)
            {
                LateFee = 0;
                LoanPeriod = 0;
            }
            else
            {
                LoanPeriod = day;
                LateFee = decimal.Parse((SelectedLoanHistory.LoanDetailHistories.Count * (day * 5.000)).ToString("N3"));
                Payment += LateFee;
            }
        }

        private void Instance_ClickedBook()
        {
            var selectedLoanBook = ShowBooksViewModel.Instance.SelectedLoanBook;
            var selectedLoanDetailHistory = selectedLoanBook.Tag as LoanDetailHistory;

            if (selectedLoanDetailHistory.Note != null)
            {
                SelectedPenaltyReason = PenaltyReason.FirstOrDefault(i => i.Id == selectedLoanDetailHistory.Note);
                if (selectedLoanDetailHistory.Note == "PR3")
                {
                    PriceTextChangedCommand.SetCanExecute(true);
                    Price = selectedLoanDetailHistory.PaidMoney.ToString();
                }
                else
                    PriceTextChangedCommand.SetCanExecute(false);
            }
            else
            {
                SelectedPenaltyReason = PenaltyReason.FirstOrDefault();
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

        private void SetValueByReaderType()
        {
            if (SelectedReader.ReaderType)
            {
                int quantityLoanSlipAdult = SelectedReader.LoanSlips.Select(i => i.Quantity).Sum();
                int quantityLoanSlipChild = SelectedReader.Adult.Children.Select(i => i.Reader.LoanSlips.Select(item => item.Quantity).Sum()).Sum();

                if ((quantityLoanSlipAdult + quantityLoanSlipChild) >= int.Parse(_ParameterVM.GetValueByID("QD2")))
                {
                    SetValueReader(SelectedReader.LName + " " + SelectedReader.FName, "Người lớn", DateTime.Now.Date > SelectedReader.Adult.ExpireDate ? "Unavailable" : "Available", (quantityLoanSlipAdult + quantityLoanSlipChild) + " (MAX)");
                }
                else
                {
                    string check = DateTime.Now.Date > SelectedReader.Adult.ExpireDate ? "Unavailable" : "Available";

                    SetValueReader(SelectedReader.LName + " " + SelectedReader.FName, "Người lớn", check, (quantityLoanSlipAdult + quantityLoanSlipChild).ToString());
                }
            }
            else
            {
                int quantity = SelectedReader.LoanSlips.Select(i => i.Quantity).Sum();
                int quantityBookChild = SelectedReader.Child.Adult.Children.Select(i => i.Reader.LoanSlips.Select(item => item.Quantity).Sum()).Sum();
                int quantityBookAdult = SelectedReader.Child.Adult.Reader.LoanSlips.Select(i => i.Quantity).Sum();

                if ((quantityBookAdult + quantityBookChild) == int.Parse(_ParameterVM.GetValueByID("QD2")))
                {
                    SetValueReader(SelectedReader.LName + " " + SelectedReader.FName, "Trẻ em", DateTime.Now.Date > SelectedReader.Child.Adult.ExpireDate ? "Unavailable" : "Available", quantity + " (MAX)");
                }
                else if (quantity == int.Parse(_ParameterVM.GetValueByID("QD3")))
                {
                    SetValueReader(SelectedReader.LName + " " + SelectedReader.FName, "Trẻ em", DateTime.Now.Date > SelectedReader.Child.Adult.ExpireDate ? "Unavailable" : "Available", quantity + " (MAX)");
                }
                else
                {
                    var check = DateTime.Now.Date > SelectedReader.Child.Adult.ExpireDate ? "Unavailable" : "Available";

                    SetValueReader(SelectedReader.LName + " " + SelectedReader.FName, "Trẻ em", check, quantity.ToString());
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HungVuong_C5_Assignment
{
    public class BookViewModel
    {
        public string NewLoanSlipID;
        public int NewID { get; set; } = BookRepository.GetNewID();
        public string SelectedLanguage { get; set; }
        public string Quantity { get; set; }
        public string Price { get; set; }

        public bool IsEnabledAdd
        {
            get
            {
                if (SelectedBookISBN == null)
                    return false;
                if (SelectedPublisher == null)
                    return false;
                if (SelectedTranslator == null)
                    return false;
                try
                {
                    if (Price == null || decimal.Parse(Price.Replace(",", "").Insert(Price.Replace(",", "").Length - 3, "."), CultureInfo.InvariantCulture) == 0)
                        return false;
                }
                catch(Exception)
                {
                    if (Price == null || decimal.Parse(Price.Replace(",", "."), NumberStyles.AllowDecimalPoint) == 0)
                        return false;
                }
                
                if (Quantity == null || int.Parse(Quantity) == 0)
                    return false;
                return true;
            }
        }

        public List<string> LstLanguage { get; private set; }
        public DateTime SelectedPublishDate { get; set; }
        public WindowDefault Parent { get; set; }

        public ObservableCollection<Publisher> LstPublisher { get; private set; }
        public Publisher SelectedPublisher { get; set; }
        public ObservableCollection<Translator> LstTranslator { get; private set; }
        public Translator SelectedTranslator { get; set; }
        public BookISBNInformation SelectedBookISBN { get; set; }

        private static readonly UnitOfWork unitOfWork = new UnitOfWork();
        public BookRepository bookRepo;

        public RelayCommand<object> AddCommand { get; private set; }
        public RelayCommand<object> CancelCommand { get; private set; }

        public BookViewModel()
        {
            this.bookRepo = unitOfWork.Books;
        }

        public BookViewModel(WindowDefault parent, List<string> languages, List<Publisher> publishers, List<Translator> translators)
        {
            this.bookRepo = unitOfWork.Books;
            LstLanguage = languages;
            this.SelectedLanguage = languages[0];
            Parent = parent;

            LstPublisher = new ObservableCollection<Publisher>(publishers);

            LstTranslator = new ObservableCollection<Translator>(translators);

            SelectedPublishDate = DateTime.Now;

            AddCommand = new RelayCommand<object>(
                p => { return true; },
                p => {
                    BookManagementRepository bookManagementRepo = new BookManagementRepository();
                bool isCheck;
                    try
                    {
                        isCheck = bookManagementRepo.Add(SelectedBookISBN.ISBN, SelectedPublisher.Id, SelectedTranslator.Id, SelectedLanguage, SelectedPublishDate, decimal.Parse(Price.Replace(",", "").Insert(Price.Replace(",", "").Length - 3, "."), CultureInfo.InvariantCulture), int.Parse(Quantity));
                    }
                    catch(Exception)
                    {
                        isCheck = bookManagementRepo.Add(SelectedBookISBN.ISBN, SelectedPublisher.Id, SelectedTranslator.Id, SelectedLanguage, SelectedPublishDate, decimal.Parse(int.Parse(Price).ToString("0.000")), int.Parse(Quantity));
                    }

                    if (!isCheck)
                        return;

                    MessageBox.Show("Book successfully added!", "Notify", MessageBoxButton.OK, MessageBoxImage.Information);

                    Parent.DialogResult = true;
                    Parent.Close();
                }
            );

            CancelCommand = new RelayCommand<object>(
                p => { return true; },
                p => {
                    Parent.DialogResult = false;
                    Parent.Close();
                }
            );
        }

        public int GetQuantityBookByISBN(string isbn, bool status)
        {
            int quantity = 0;

            foreach(var item in bookRepo.Items)
            {
                if(status)
                {
                    if (item.ISBN == isbn && item.Status)
                        quantity++;
                }
                else
                {
                    if (item.ISBN == isbn && !item.Status)
                        quantity++;
                }
            }
            return quantity;
        }
    }
}

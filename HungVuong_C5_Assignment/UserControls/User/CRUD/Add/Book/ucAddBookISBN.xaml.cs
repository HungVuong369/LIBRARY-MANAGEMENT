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
    /// Interaction logic for ucAddBookISBN.xaml
    /// </summary>
    public partial class ucAddBookISBN : UserControl
    {
        private WindowDefault _Parent;
        private BookISBNManagementRepository _BookISBNManagementVM = new BookISBNManagementRepository();

        private CategoryViewModel _CategoryVM = new CategoryViewModel();
        private AuthorViewModel _AuthorVM = new AuthorViewModel();
        private BookTitleViewModel _BookTitleVM = new BookTitleViewModel();
        private PublisherViewModel _PublisherVM = new PublisherViewModel();

        private ObservableCollection<Author> _LstAuthor;
        private ObservableCollection<Author> _StorageAuthor;
        private ObservableCollection<BookTitleInformation> _StorageBookTitleInfo;
        private ObservableCollection<BookTitleInformation> _LstBookTitleInfo;

        public ucAddBookISBN(WindowDefault window)
        {
            InitializeComponent();

            _Parent = window;

            cbLanguage.ItemsSource = DataAccess.GetListLanguage();
            this._StorageAuthor = new ObservableCollection<Author>(this._AuthorVM.authorRepo.Items);
            this._LstAuthor = new ObservableCollection<Author>(this._StorageAuthor);
            this._StorageBookTitleInfo = new ObservableCollection<BookTitleInformation>(GetListBookTitleInformation());
            this._LstBookTitleInfo = new ObservableCollection<BookTitleInformation>(this._StorageBookTitleInfo);
            cbPublisher.ItemsSource = _PublisherVM.PublisherRepo.Items;
            cbPublisher.SelectedIndex = 0;
            dgBookTitleInfo.ItemsSource = this._LstBookTitleInfo;
            dgAuthor.ItemsSource = this._LstAuthor;
        }

        private void UpdateIsEnabled()
        {
            bool isCheck = true;

            if (dpPublishDate.SelectedDate == null)
                isCheck = false;

            if (dgAuthor.SelectedItem == null)
            {
                isCheck = false;
                tbSelectAuthor.Foreground = Brushes.Red;
            }
            else
                tbSelectAuthor.Foreground = Brushes.White;
            if (dgBookTitleInfo.SelectedItem == null)
            {
                isCheck = false;
                tbSelectBookTitle.Foreground = Brushes.Red;
            }
            else
                tbSelectBookTitle.Foreground = Brushes.White;
            if (txtPriceBook.Text == string.Empty)
                isCheck = false;

            btnAdd.IsEnabled = isCheck;
        }

        private List<BookTitleInformation> GetListBookTitleInformation()
        {
            List<BookTitleInformation> lstBookTitleInfo = new List<BookTitleInformation>();

            foreach (var item in this._BookTitleVM.bookTitleRepo.Items)
            {
                lstBookTitleInfo.Add(new BookTitleInformation(
                    item.Id,
                    this._CategoryVM.categoryRepo.GetById(item.IdCategory),
                    item.Name,
                    this._AuthorVM.authorRepo.GetById(item.IdAuthor),
                    item.Summary
                ));
            }

            return lstBookTitleInfo;
        }

        private void txtAuthorSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            this._LstAuthor.Clear();

            foreach(var item in this._StorageAuthor)
            {
                if(item.Name.ToLower().Contains(txtAuthorSearch.Text.ToLower()))
                {
                    this._LstAuthor.Add(item);
                }
                else if(item.Id.ToLower().Contains(txtAuthorSearch.Text.ToLower()))
                {
                    this._LstAuthor.Add(item);
                }
            }
            UpdateIsEnabled();
        }

        private void txtBookTitleSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            this._LstBookTitleInfo.Clear();

            foreach (var item in this._StorageBookTitleInfo)
            {
                if (item.Name.ToLower().Contains(txtBookTitleSearch.Text.ToLower()))
                {
                    this._LstBookTitleInfo.Add(item);
                }
                else if (item.Author.Name.ToLower().Contains(txtBookTitleSearch.Text.ToLower()))
                {
                    this._LstBookTitleInfo.Add(item);
                }
            }
            UpdateIsEnabled();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if(!_BookISBNManagementVM.Add(cbLanguage.SelectedValue.ToString(), (dgBookTitleInfo.SelectedItem as BookTitleInformation).Name, dpPublishDate.SelectedDate.Value, (dgAuthor.SelectedItem as Author).Id, (dgBookTitleInfo.SelectedItem as BookTitleInformation).Id, cbPublisher.SelectedValue.ToString(), decimal.Parse(txtPriceBook.Text.Replace(",", "."))))
            {
                return;
            }
            
            _Parent.DialogResult = true;

            _Parent.Close();
        }

        private void dgBookTitleInfo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateIsEnabled();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            _Parent.DialogResult = false;
            _Parent.Close();
        }

        private void txtPriceBook_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (e.Text != string.Empty && !char.IsDigit(e.Text[0]))
                e.Handled = true;
        }

        private void txtPriceBook_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtPriceBook.Text == string.Empty)
                return;
            txtPriceBook.Text = double.Parse(txtPriceBook.Text.Replace(",", "")).ToString("N0");
            txtPriceBook.SelectionStart = txtPriceBook.Text.Length;
            UpdateIsEnabled();
        }
    }
}

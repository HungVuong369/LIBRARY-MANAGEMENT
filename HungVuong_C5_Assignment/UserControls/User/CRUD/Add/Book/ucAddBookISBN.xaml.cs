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
        private BookISBNManagementRepository _BookISBNManagementVM = new BookISBNManagementRepository();

        private CategoryViewModel _CategoryVM = new CategoryViewModel();
        private AuthorViewModel _AuthorVM = new AuthorViewModel();
        private BookTitleViewModel _BookTitleVM = new BookTitleViewModel();

        private ObservableCollection<Author> _LstAuthor;
        private ObservableCollection<Author> _StorageAuthor;
        private ObservableCollection<BookTitleInformation> _StorageBookTitleInfo;
        private ObservableCollection<BookTitleInformation> _LstBookTitleInfo;

        public ucAddBookISBN(WindowDefault window)
        {
            InitializeComponent();

            this._StorageAuthor = new ObservableCollection<Author>(this._AuthorVM.authorRepo.Items);
            this._LstAuthor = new ObservableCollection<Author>(this._StorageAuthor);
            this._StorageBookTitleInfo = new ObservableCollection<BookTitleInformation>(GetListBookTitleInformation());
            this._LstBookTitleInfo = new ObservableCollection<BookTitleInformation>(this._StorageBookTitleInfo);

            dgBookTitleInfo.ItemsSource = this._LstBookTitleInfo;
            dgAuthor.ItemsSource = this._LstAuthor;
            BookISBNViewModel bookISBNVM = new BookISBNViewModel();
            bookISBNVM.Parent = window;
            this.DataContext = bookISBNVM;
        }

        private void UpdateIsEnabled()
        {
            bool isCheck = true;

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

            btnAdd.IsEnabled = isCheck;
        }

        private List<BookTitleInformation> GetListBookTitleInformation()
        {
            List<BookTitleInformation> lstBookTitleInfo = new List<BookTitleInformation>();

            foreach (var item in this._BookTitleVM.bookTitleRepo.Items)
            {
                lstBookTitleInfo.Add(new BookTitleInformation(
                    item.Id,
                    item.Category.Name,
                    item.Name,
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
                    this._LstAuthor.Add(item);
                else if(item.Id.ToLower().Contains(txtAuthorSearch.Text.ToLower()))
                    this._LstAuthor.Add(item);
                else if(item.boF.ToString("dd/MM/yyyy").Contains(txtAuthorSearch.Text))
                    this._LstAuthor.Add(item);
            }
            UpdateIsEnabled();
        }

        private void txtBookTitleSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            this._LstBookTitleInfo.Clear();

            foreach (var item in this._StorageBookTitleInfo)
            {
                if (item.Name.ToLower().Contains(txtBookTitleSearch.Text.ToLower()))
                    this._LstBookTitleInfo.Add(item);
                else if(item.Id.ToLower().Contains(txtBookTitleSearch.Text.ToLower()))
                    this._LstBookTitleInfo.Add(item);
                else if(item.Category.ToLower().Contains(txtBookTitleSearch.Text.ToLower()))
                    this._LstBookTitleInfo.Add(item);
            }
            UpdateIsEnabled();
        }

        private void dgBookTitleInfo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateIsEnabled();
        }
    }
}

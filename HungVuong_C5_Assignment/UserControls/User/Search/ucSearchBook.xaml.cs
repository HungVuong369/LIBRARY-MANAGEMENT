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
    /// Interaction logic for ucSearchBook.xaml
    /// </summary>
    public partial class ucSearchBook : UserControl
    {
        private ObservableCollection<BookInformation> _StorageBookInfo;
        private ObservableCollection<BookInformation> _LstBookInfo;

        private CategoryViewModel _CategoryVM = new CategoryViewModel();
        private BookISBNViewModel _BookISBNVM = new BookISBNViewModel();
        private BookTitleViewModel _BookTitleVM = new BookTitleViewModel();
        private AuthorViewModel _AuthorVM = new AuthorViewModel();
        private BookViewModel _BookVM = new BookViewModel();

        public ucSearchBook()
        {
            InitializeComponent();

            this._StorageBookInfo = new ObservableCollection<BookInformation>(this.GetListBookInfo());

            this._LstBookInfo = new ObservableCollection<BookInformation>(this._StorageBookInfo);

            SetMaxPage();

            dgBookInfo.ItemsSource = null;
            dgBookInfo.ItemsSource = _LstBookInfo.Take(pagination.ItemPerPage);

            pagination.LoadPage();

            dgBookInfo.ItemsSource = _LstBookInfo;
        }

        public void ReloadShowing()
        {
            if (pagination.MaxPage == 0)
                pagination.lblShowing.Content = $"Showing 0 to 0 entities";
            else if (pagination.MaxPage == pagination.CurrentPage && _LstBookInfo.Count() % pagination.ItemPerPage != 0)
                pagination.lblShowing.Content = $"Showing {(pagination.CurrentPage - 1) * pagination.ItemPerPage + 1} to {(pagination.CurrentPage - 1) * pagination.ItemPerPage + _LstBookInfo.Count % pagination.ItemPerPage} entities";
            else
                pagination.lblShowing.Content = $"Showing {(pagination.CurrentPage - 1) * pagination.ItemPerPage + 1} to {(pagination.CurrentPage) * pagination.ItemPerPage} entities";
        }

        public void ReloadDataGrid()
        {
            dgBookInfo.ItemsSource = null;
            dgBookInfo.ItemsSource = _LstBookInfo.Skip((pagination.CurrentPage - 1) * pagination.ItemPerPage).Take(pagination.ItemPerPage);
            ReloadShowing();
        }

        public void ReloadStorageInfo()
        {
            this._StorageBookInfo = new ObservableCollection<BookInformation>(this.GetListBookInfo());

            this._LstBookInfo = new ObservableCollection<BookInformation>(this._StorageBookInfo);

            SetMaxPage();

            dgBookInfo.ItemsSource = _LstBookInfo.Skip((pagination.CurrentPage - 1) * pagination.ItemPerPage).Take(pagination.ItemPerPage);
        }

        public void ReloadStorageAll()
        {
            this._StorageBookInfo = new ObservableCollection<BookInformation>(this.GetListBookInfoShowAll());

            this._LstBookInfo = new ObservableCollection<BookInformation>(this._StorageBookInfo);

            SetMaxPage();

            dgBookInfo.ItemsSource = _LstBookInfo.Skip((pagination.CurrentPage - 1) * pagination.ItemPerPage).Take(pagination.ItemPerPage);
        }

        private void SetMaxPage()
        {
            pagination.MaxPage = (_LstBookInfo.Count / pagination.ItemPerPage);

            if (_LstBookInfo.Count % pagination.ItemPerPage != 0)
            {
                pagination.MaxPage += 1;
            }
        }

        public void Search(string search)
        {
            this._LstBookInfo.Clear();

            foreach (var item in this._StorageBookInfo)
            {
                if (item.ISBN.ToLower().Contains(search.ToLower()))
                    this._LstBookInfo.Add(item);
                else if (item.Name.ToLower().Contains(search.ToLower()))
                    this._LstBookInfo.Add(item);
                else if(item.Category.ToLower().Contains(search.ToLower()))
                    this._LstBookInfo.Add(item);
                else if(item.Author.ToLower().Contains(search.ToLower()))
                    this._LstBookInfo.Add(item);
                else if(item.Language.ToLower().Contains(search.ToLower()))
                    this._LstBookInfo.Add(item);
                else if(item.Translator.ToLower().Contains(search.ToLower()))
                    this._LstBookInfo.Add(item);
                else if(item.PublishDate.ToString("dd/MM/yyyy").Contains(search)) 
                    this._LstBookInfo.Add(item);
                else if(item.Quantity.ToString().Contains(search))
                    this._LstBookInfo.Add(item);
            }
            SetMaxPage();
            pagination.CurrentPage = 1;
            pagination.LoadPage();
        }

        private List<BookInformation> GetListBookInfo()
        {
            List<BookInformation> lstBookInfo = new List<BookInformation>();

            foreach(var item in this._BookISBNVM.bookISBNRepo.Items)
            {
                BookTitle bookTitle = this._BookTitleVM.bookTitleRepo.GetById(item.IdBookTitle);
                Author author = this._AuthorVM.authorRepo.GetById(bookTitle.IdAuthor);
                Author translator = this._AuthorVM.authorRepo.GetById(item.IdAuthor);

                lstBookInfo.Add(new BookInformation(
                    item.ISBN,
                    bookTitle.Name,
                    this._CategoryVM.categoryRepo.GetById(bookTitle.IdCategory).Name,
                    author.Name,
                    item.Language,
                    translator.Name,
                    item.PublishDate,
                    this._BookVM.GetQuantityBookByISBN(item.ISBN, true),
                    item.Status
                ));
            }

            return lstBookInfo;
        }

        private List<BookInformation> GetListBookInfoShowAll()
        {
            List<BookInformation> lstBookInfo = new List<BookInformation>();
            
            foreach(var item in DatabaseFirst.Instance.db.Books.Include("BookISBN").Include("BookISBN.BookTitle").Include("BookISBN.BookTitle.Category").Include("BookISBN.BookTitle.Author"))
            {
                var bookInfo = new BookInformation(item.ISBN, item.BookISBN.BookTitle.Name, item.BookISBN.BookTitle.Category.Name, item.BookISBN.BookTitle.Author.Name, item.BookISBN.Language, item.BookISBN.BookTitle.Author.Name, item.BookISBN.PublishDate, -1, item.Status);
                lstBookInfo.Add(bookInfo);
            }

            return lstBookInfo;
        }
    }
}

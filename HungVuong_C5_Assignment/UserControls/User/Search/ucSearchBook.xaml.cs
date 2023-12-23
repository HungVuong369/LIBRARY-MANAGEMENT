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

            pagination.SetMaxPage<BookInformation>(_LstBookInfo.ToList());

            dgBookInfo.ItemsSource = null;
            dgBookInfo.ItemsSource = _LstBookInfo.Take(pagination.ItemPerPage);

            pagination.LoadPage();

            dgBookInfo.ItemsSource = _LstBookInfo;
        }

        public void ReloadDataGrid()
        {
            dgBookInfo.ItemsSource = null;
            dgBookInfo.ItemsSource = _LstBookInfo.Skip((pagination.CurrentPage - 1) * pagination.ItemPerPage).Take(pagination.ItemPerPage);
            pagination.ReloadShowing<BookInformation>(_LstBookInfo.ToList());
        }

        public void ReloadStorageInfo()
        {
            this._StorageBookInfo = new ObservableCollection<BookInformation>(this.GetListBookInfo());

            this._LstBookInfo = new ObservableCollection<BookInformation>(this._StorageBookInfo);

            pagination.SetMaxPage<BookInformation>(_LstBookInfo.ToList());

            dgBookInfo.ItemsSource = _LstBookInfo.Skip((pagination.CurrentPage - 1) * pagination.ItemPerPage).Take(pagination.ItemPerPage);
        }

        public void ReloadStorageAll()
        {
            this._StorageBookInfo = new ObservableCollection<BookInformation>(this.GetListBookInfoShowAll());

            this._LstBookInfo = new ObservableCollection<BookInformation>(this._StorageBookInfo);

            pagination.SetMaxPage<BookInformation>(_LstBookInfo.ToList());

            dgBookInfo.ItemsSource = _LstBookInfo.Skip((pagination.CurrentPage - 1) * pagination.ItemPerPage).Take(pagination.ItemPerPage);
        }

        public void ReloadStorageAllByISBN(string isbn)
        {
            this._StorageBookInfo = new ObservableCollection<BookInformation>(this.GetListBookInfoShowAll().Where(i => i.ISBN.ToLower() == isbn.ToLower() && i.Status == true));

            this._LstBookInfo = new ObservableCollection<BookInformation>(this._StorageBookInfo);

            pagination.SetMaxPage<BookInformation>(_LstBookInfo.ToList());

            dgBookInfo.ItemsSource = _LstBookInfo.Skip((pagination.CurrentPage - 1) * pagination.ItemPerPage).Take(pagination.ItemPerPage);
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
                else if(item.Language.ToLower().Contains(search.ToLower()))
                    this._LstBookInfo.Add(item);
                else if(item.PublishDate.ToString("dd/MM/yyyy").Contains(search)) 
                    this._LstBookInfo.Add(item);
                else if(item.Quantity.ToString().Contains(search))
                    this._LstBookInfo.Add(item);
                else if(item.BookAuthor.Name.ToLower().Contains(search.ToLower()))
                    this._LstBookInfo.Add(item);
                else if(item.BookPublisher.Name.ToLower().Contains(search.ToLower()))
                    this._LstBookInfo.Add(item);
                else if(item.BookTranslator.Name.ToLower().Contains(search.ToLower()))
                    this._LstBookInfo.Add(item);
                else if(item.Id.ToString().Contains(search))
                    this._LstBookInfo.Add(item);
            }

            pagination.SetMaxPage<BookInformation>(_LstBookInfo.ToList());

            pagination.CurrentPage = 1;
            pagination.LoadPage();
        }

        private List<BookInformation> GetListBookInfo()
        {
            List<BookInformation> lstBookInfo = new List<BookInformation>();

            foreach(var item in this._BookVM.bookRepo.Items)
            {
                if(lstBookInfo.Any(i => i.ISBN == item.ISBN))
                {
                    if (!item.Status)
                        continue;
                    lstBookInfo[lstBookInfo.FindIndex(i => i.ISBN == item.ISBN)].Quantity++;
                }
                else
                {
                    int quantity = 1;
                    if (!item.BookISBN.Status)
                    {
                        quantity = 0;
                    }
                    var newBookInfo = new BookInformation()
                    {
                        Id = item.Id,
                        BookAuthor = item.BookISBN.Author,
                        BookPublisher = item.Publisher,
                        PublishDate = item.PublishDate,
                        BookTranslator = item.Translator,
                        ISBN = item.ISBN,
                        Category = item.BookISBN.BookTitle.Category.Name,
                        Name = item.BookISBN.BookTitle.Name,
                        Language = item.Language,
                        Quantity = quantity,
                        Status = item.BookISBN.Status
                    };
                    lstBookInfo.Add(newBookInfo);
                }
            }

            return lstBookInfo;
        }

        private List<BookInformation> GetListBookInfoShowAll()
        {
            List<BookInformation> lstBookInfo = new List<BookInformation>();
            
            foreach(var item in DatabaseFirst.Instance.db.Books)
            {
                var newBookInfo = new BookInformation()
                {
                    Id = item.Id,
                    Quantity = -1,
                    BookAuthor = item.BookISBN.Author,
                    Name = item.BookISBN.BookTitle.Name,
                    BookPublisher = item.Publisher,
                    PublishDate = item.PublishDate,
                    BookTranslator = item.Translator,
                    Category = item.BookISBN.BookTitle.Category.Name,
                    ISBN = item.ISBN,
                    Language = item.Language,
                    Status = item.Status
                };

                lstBookInfo.Add(newBookInfo);
            }

            return lstBookInfo;
        }
    }
}

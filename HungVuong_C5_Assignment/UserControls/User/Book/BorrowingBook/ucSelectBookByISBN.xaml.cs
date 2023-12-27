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
    /// Interaction logic for ucSelectBookByISBN.xaml
    /// </summary>
    public partial class ucSelectBookByISBN : UserControl
    {
        private string ISBN;

        private WindowDefault _Parent;
        private ObservableCollection<BookInformation> _StorageBookInfo;
        private ObservableCollection<BookInformation> _LstBookInfo;

        public ucSelectBookByISBN(WindowDefault window, string isbn)
        {
            InitializeComponent();

            _Parent = window;

            this.ISBN = isbn;

            dgBookInfo.Columns[9].Visibility = Visibility.Collapsed;
            dgBookInfo.Columns[0].Visibility = Visibility.Visible;
            dgBookInfo.Columns[1].Visibility = Visibility.Collapsed;

            pagination.ChangedPageEvent += Pagination_ChangedPageEvent;
            pagination.SelectionChangedComboBoxEvent += Pagination_SelectionChangedComboBoxEvent;
            dgBookInfo.SelectionChanged += DgBookInfo_SelectionChanged;

            ReloadStorageAllByISBN(isbn);

            pagination.cbPage.SelectedIndex = 0;

            pagination.HideButton();
        }

        public void ReloadStorageAllByISBN(string isbn)
        {
            this._StorageBookInfo = new ObservableCollection<BookInformation>(GetListBookInfoShowAllByISBN(isbn));

            this._LstBookInfo = new ObservableCollection<BookInformation>(this._StorageBookInfo);

            pagination.SetMaxPage<BookInformation>(_LstBookInfo.Count);

            dgBookInfo.ItemsSource = _LstBookInfo.Skip((pagination.CurrentPage - 1) * pagination.ItemPerPage).Take(pagination.ItemPerPage);
        }

        private List<BookInformation> GetListBookInfoShowAllByISBN(string isbn)
        {
            List<BookInformation> lstBookInfo = new List<BookInformation>();

            var bookISBN = DatabaseFirst.Instance.db.BookISBNs.FirstOrDefault(i => i.ISBN.ToLower() == isbn.ToLower());

            foreach (var item in bookISBN.Books)
            {
                if (!item.Status)
                    continue;

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
                    Status = item.Status,
                    BookStatus = DatabaseFirst.Instance.db.BookStatus.FirstOrDefault(i => i.Id == item.IdBookStatus).Name
                };

                lstBookInfo.Add(newBookInfo);
            }

            return lstBookInfo;
        }

        private void DgBookInfo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btnConfirm.IsEnabled = true;
        }

        //private void ReloadAll()
        //{
        //    ReloadStorageAllByISBN(ISBN);
        //    txtSearch.Text = "";

        //    pagination.CurrentPage = 1;
        //    pagination.LoadPage();

        //    ReloadDataGrid();
        //}

        public void ReloadDataGrid()
        {
            dgBookInfo.ItemsSource = null;
            dgBookInfo.ItemsSource = _LstBookInfo.Skip((pagination.CurrentPage - 1) * pagination.ItemPerPage).Take(pagination.ItemPerPage);
            pagination.ReloadShowing<BookInformation>(_LstBookInfo.Count);
        }

        private void Pagination_SelectionChangedComboBoxEvent(object sender, SelectionChangedEventArgs e)
        {
            pagination.ItemPerPage = int.Parse((pagination.cbPage.SelectedItem as ComboBoxItem).Content.ToString());
            ReloadDataGrid();
        }

        private void Pagination_ChangedPageEvent(Pagination pagination)
        {
            ReloadDataGrid();
            btnConfirm.IsEnabled = false;
        }

        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            Search(txtSearch.Text);
            ReloadDataGrid();
            btnConfirm.IsEnabled = false;
        }

        private void btnConfirm_Click(object sender, RoutedEventArgs e)
        {
            _Parent.DialogResult = true;
            _Parent.Tag = (dgBookInfo.SelectedItem as BookInformation);
            _Parent.Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            _Parent.DialogResult = false;
            _Parent.Tag = null;
            _Parent.Close();
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
                else if (item.Category.ToLower().Contains(search.ToLower()))
                    this._LstBookInfo.Add(item);
                else if (item.Language.ToLower().Contains(search.ToLower()))
                    this._LstBookInfo.Add(item);
                else if (item.PublishDate.ToString("dd/MM/yyyy").Contains(search))
                    this._LstBookInfo.Add(item);
                else if (item.Quantity.ToString().Contains(search))
                    this._LstBookInfo.Add(item);
                else if (item.BookAuthor.Name.ToLower().Contains(search.ToLower()))
                    this._LstBookInfo.Add(item);
                else if (item.BookPublisher.Name.ToLower().Contains(search.ToLower()))
                    this._LstBookInfo.Add(item);
                else if (item.BookTranslator.Name.ToLower().Contains(search.ToLower()))
                    this._LstBookInfo.Add(item);
                else if (item.Id.ToString().Contains(search))
                    this._LstBookInfo.Add(item);
            }

            pagination.SetMaxPage<BookInformation>(_LstBookInfo.Count);

            pagination.CurrentPage = 1;
            pagination.LoadPage();
        }
    }
}

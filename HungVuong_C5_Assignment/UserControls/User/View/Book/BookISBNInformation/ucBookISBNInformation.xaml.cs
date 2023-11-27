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
    /// Interaction logic for ucBookISBNInformation.xaml
    /// </summary>
    public partial class ucBookISBNInformation : UserControl
    {
        private BookViewModel _BookVM = new BookViewModel();
        private ObservableCollection<BookISBNInformation> _StorageLstBookISBNInfo;
        private ObservableCollection<BookISBNInformation> _LstBookISBNInfo;

        public ucBookISBNInformation()
        {
            InitializeComponent();
            this._StorageLstBookISBNInfo = new ObservableCollection<BookISBNInformation>(DataAccess.GetListBookISBNInformation());

            this._LstBookISBNInfo = new ObservableCollection<BookISBNInformation>(this._StorageLstBookISBNInfo);

            SetMaxPage();

            dgBookISBN.ItemsSource = null;
            dgBookISBN.ItemsSource = _LstBookISBNInfo.Take(pagination.ItemPerPage);

            pagination.LoadPage();

            dgBookISBN.ItemsSource = _LstBookISBNInfo;
        }

        public void ReloadShowing()
        {
            if (pagination.MaxPage == 0)
                pagination.lblShowing.Content = $"Showing 0 to 0 entities";
            else if (pagination.MaxPage == pagination.CurrentPage && _LstBookISBNInfo.Count() % pagination.ItemPerPage != 0)
                pagination.lblShowing.Content = $"Showing {(pagination.CurrentPage - 1) * pagination.ItemPerPage + 1} to {(pagination.CurrentPage - 1) * pagination.ItemPerPage + _LstBookISBNInfo.Count % pagination.ItemPerPage} entities";
            else
                pagination.lblShowing.Content = $"Showing {(pagination.CurrentPage - 1) * pagination.ItemPerPage + 1} to {(pagination.CurrentPage) * pagination.ItemPerPage} entities";
        }

        public void ReloadDataGrid()
        {
            dgBookISBN.ItemsSource = null;
            dgBookISBN.ItemsSource = _LstBookISBNInfo.Skip((pagination.CurrentPage - 1) * pagination.ItemPerPage).Take(pagination.ItemPerPage);
            ReloadShowing();
        }

        public void ReloadStorage()
        {
            this._StorageLstBookISBNInfo = new ObservableCollection<BookISBNInformation>(DataAccess.GetListBookISBNInformation());

            this._LstBookISBNInfo = new ObservableCollection<BookISBNInformation>(this._StorageLstBookISBNInfo);

            SetMaxPage();

            dgBookISBN.ItemsSource = _LstBookISBNInfo.Skip((pagination.CurrentPage - 1) * pagination.ItemPerPage).Take(pagination.ItemPerPage);
        }

        private void SetMaxPage()
        {
            pagination.MaxPage = (_LstBookISBNInfo.Count / pagination.ItemPerPage);

            if (_LstBookISBNInfo.Count % pagination.ItemPerPage != 0)
            {
                pagination.MaxPage += 1;
            }
        }

        public void Search(string search)
        {
            this._LstBookISBNInfo.Clear();

            foreach (var item in this._StorageLstBookISBNInfo)
            {
                if (item.ISBN.ToLower().Contains(search.ToLower()))
                    this._LstBookISBNInfo.Add(item);
                else if(item.Language.ToLower().Contains(search.ToLower()))
                    this._LstBookISBNInfo.Add(item);
                else if(item.PublishDate.ToString("dd/MM/yyyy").Contains(search))
                    this._LstBookISBNInfo.Add(item);
                else if(item.AuthorName.ToLower().Contains(search.ToLower()))
                    this._LstBookISBNInfo.Add(item);
                else if(item.AuthorBoF.ToString("dd/MM/yyyy").Contains(search))
                    this._LstBookISBNInfo.Add(item);
            }
            SetMaxPage();
            pagination.CurrentPage = 1;
            pagination.LoadPage();
        }

        private void btnDetail_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;

            WindowDefault window = new WindowDefault();
            window.Content = new ucDetailBookISBN(button.Tag.ToString());
            window.ShowDialog();
        }
    }
}

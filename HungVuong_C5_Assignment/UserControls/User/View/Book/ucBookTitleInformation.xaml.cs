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
    /// Interaction logic for ucBookTitleInformation.xaml
    /// </summary>
    public partial class ucBookTitleInformation : UserControl
    {
        private ObservableCollection<BookTitleInformation> _StorageLstBookTitleInfo;
        private ObservableCollection<BookTitleInformation> _LstBookTitleInfo;

        private CategoryViewModel _CategoryVM = new CategoryViewModel();
        private AuthorViewModel _AuthorVM = new AuthorViewModel();
        private BookTitleViewModel _BookTitleVM = new BookTitleViewModel();

        public ucBookTitleInformation()
        {
            InitializeComponent();
            this._StorageLstBookTitleInfo = new ObservableCollection<BookTitleInformation>(this.GetListBookTitleInformation());

            this._LstBookTitleInfo = new ObservableCollection<BookTitleInformation>(this._StorageLstBookTitleInfo);

            SetMaxPage();

            dgBookTitleInfo.ItemsSource = null;
            dgBookTitleInfo.ItemsSource = _LstBookTitleInfo.Take(pagination.ItemPerPage);

            pagination.LoadPage();

            dgBookTitleInfo.ItemsSource = _LstBookTitleInfo;
        }

        public void ReloadShowing()
        {
            if (pagination.MaxPage == 0)
                pagination.lblShowing.Content = $"Showing 0 to 0 entities";
            else if (pagination.MaxPage == pagination.CurrentPage && _LstBookTitleInfo.Count() % pagination.ItemPerPage != 0)
                pagination.lblShowing.Content = $"Showing {(pagination.CurrentPage - 1) * pagination.ItemPerPage + 1} to {(pagination.CurrentPage - 1) * pagination.ItemPerPage + _LstBookTitleInfo.Count % pagination.ItemPerPage} entities";
            else
                pagination.lblShowing.Content = $"Showing {(pagination.CurrentPage - 1) * pagination.ItemPerPage + 1} to {(pagination.CurrentPage) * pagination.ItemPerPage} entities";
        }

        private void SetMaxPage()
        {
            pagination.MaxPage = (_LstBookTitleInfo.Count / pagination.ItemPerPage);

            if (_LstBookTitleInfo.Count % pagination.ItemPerPage != 0)
            {
                pagination.MaxPage += 1;
            }
        }

        public void Search(string search)
        {
            this._LstBookTitleInfo.Clear();

            foreach (var item in this._StorageLstBookTitleInfo)
            {
                if (item.Name.ToLower().Contains(search.ToLower()))
                    this._LstBookTitleInfo.Add(item);
                else if(item.Category.Name.ToLower().Contains(search.ToLower()))
                    this._LstBookTitleInfo.Add(item);
                else if(item.Author.Name.ToLower().Contains(search.ToLower()))
                    this._LstBookTitleInfo.Add(item);
                else if(item.Author.boF.ToString("dd/MM/yyyy").Contains(search.ToLower()))
                    this._LstBookTitleInfo.Add(item);
            }
            SetMaxPage();
            pagination.CurrentPage = 1;
            pagination.LoadPage();
        }

        public void ReloadDataGrid()
        {
            dgBookTitleInfo.ItemsSource = null;
            dgBookTitleInfo.ItemsSource = _LstBookTitleInfo.Skip((pagination.CurrentPage - 1) * pagination.ItemPerPage).Take(pagination.ItemPerPage);
            ReloadShowing();
        }

        public void ReloadStorage()
        {
            this._StorageLstBookTitleInfo = new ObservableCollection<BookTitleInformation>(this.GetListBookTitleInformation());

            this._LstBookTitleInfo = new ObservableCollection<BookTitleInformation>(this._StorageLstBookTitleInfo);

            SetMaxPage();

            dgBookTitleInfo.ItemsSource = _LstBookTitleInfo.Skip((pagination.CurrentPage - 1) * pagination.ItemPerPage).Take(pagination.ItemPerPage);
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
    }
}

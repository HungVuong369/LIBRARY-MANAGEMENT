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

        public ucBookTitleInformation()
        {
            InitializeComponent();
        }

        public void Search(string search)
        {
            this._LstBookTitleInfo.Clear();

            foreach (var item in this._StorageLstBookTitleInfo)
            {
                if (item.Name.ToLower().Contains(search.ToLower()))
                    this._LstBookTitleInfo.Add(item);
                else if(item.Category.ToLower().Contains(search.ToLower()))
                    this._LstBookTitleInfo.Add(item);
                else if(item.Id.ToLower().Contains(search.ToLower()))
                    this._LstBookTitleInfo.Add(item);
            }

            pagination.SetMaxPage<BookTitleInformation>(_LstBookTitleInfo.Count);
            pagination.CurrentPage = 1;
            pagination.LoadPage();
        }

        public void ReloadDataGrid()
        {
            dgBookTitleInfo.ItemsSource = null;
            dgBookTitleInfo.ItemsSource = _LstBookTitleInfo.Skip((pagination.CurrentPage - 1) * pagination.ItemPerPage).Take(pagination.ItemPerPage);
            pagination.ReloadShowing<BookTitleInformation>(_LstBookTitleInfo.Count);
        }

        public void ReloadStorage()
        {
            this._StorageLstBookTitleInfo = new ObservableCollection<BookTitleInformation>(this.GetListBookTitleInformation());

            this._LstBookTitleInfo = new ObservableCollection<BookTitleInformation>(this._StorageLstBookTitleInfo);

            pagination.SetMaxPage<BookTitleInformation>(_LstBookTitleInfo.Count);

            dgBookTitleInfo.ItemsSource = _LstBookTitleInfo.Skip((pagination.CurrentPage - 1) * pagination.ItemPerPage).Take(pagination.ItemPerPage);
        }

        private List<BookTitleInformation> GetListBookTitleInformation()
        {
            List<BookTitleInformation> lstBookTitleInfo = new List<BookTitleInformation>();

            foreach (var item in DatabaseFirst.Instance.db.BookTitles)
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
    }
}

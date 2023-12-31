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
    /// Interaction logic for ucReaderAndIdentifyDataGrid.xaml
    /// </summary>
    public partial class ucReaderAndIdentifyDataGrid : UserControl
    {
        public delegate void DeleteHandle(object sender, RoutedEventArgs e);
        public event DeleteHandle deleteEvent;

        public delegate void RestoreHandle(object sender, RoutedEventArgs e);
        public event RestoreHandle restoreEvent;

        private AdultViewModel _AdultVM = new AdultViewModel();
        private ChildViewModel _ChildVM = new ChildViewModel();
        private ReaderViewModel _ReaderVM = new ReaderViewModel();

        private ObservableCollection<AdultReader> _StorageLstAdultReader;
        private ObservableCollection<AdultReader> _LstAdultReader;

        public ucReaderAndIdentifyDataGrid()
        {
            InitializeComponent();

            this._StorageLstAdultReader = new ObservableCollection<AdultReader>(this.GetListAdultReader());

            this._LstAdultReader = new ObservableCollection<AdultReader>(this._StorageLstAdultReader);

            SetMaxPage();

            dgReader.ItemsSource = null;
            dgReader.ItemsSource = _LstAdultReader.Take(pagination.ItemPerPage);

            pagination.LoadPage();

            dgReader.ItemsSource = _LstAdultReader;
        }

        public void ReloadShowing()
        {
            if (pagination.MaxPage == 0)
                pagination.lblShowing.Content = $"Showing 0 to 0 entities";
            else if (pagination.MaxPage == pagination.CurrentPage && _LstAdultReader.Count() % pagination.ItemPerPage != 0)
                pagination.lblShowing.Content = $"Showing {(pagination.CurrentPage - 1) * pagination.ItemPerPage + 1} to {(pagination.CurrentPage - 1) * pagination.ItemPerPage + _LstAdultReader.Count % pagination.ItemPerPage} entities";
            else
                pagination.lblShowing.Content = $"Showing {(pagination.CurrentPage - 1) * pagination.ItemPerPage + 1} to {(pagination.CurrentPage) * pagination.ItemPerPage} entities";
        }

        public void ReloadDataGrid()
        {
            dgReader.ItemsSource = null;
            dgReader.ItemsSource = _LstAdultReader.Skip((pagination.CurrentPage - 1) * pagination.ItemPerPage).Take(pagination.ItemPerPage);
            ReloadShowing();
        }

        public void ReloadStorage()
        {
            this._StorageLstAdultReader = new ObservableCollection<AdultReader>(this.GetListAdultReader());

            this._LstAdultReader = new ObservableCollection<AdultReader>(this._StorageLstAdultReader);

            SetMaxPage();

            dgReader.ItemsSource = _LstAdultReader.Skip((pagination.CurrentPage - 1) * pagination.ItemPerPage).Take(pagination.ItemPerPage);
        }

        public void SetVisibilityButton(Visibility delete, Visibility restore, Visibility detail)
        {
            dgReader.Columns[7].Visibility = detail;
            dgReader.Columns[9].Visibility = restore;
            dgReader.Columns[8].Visibility = delete;
        }

        private void SetMaxPage()
        {
            pagination.MaxPage = (_LstAdultReader.Count / pagination.ItemPerPage);

            if (_LstAdultReader.Count % pagination.ItemPerPage != 0)
            {
                pagination.MaxPage += 1;
            }
        }

        public void UpdateDataGridByIdentifyAndName(string search)
        {
            this._LstAdultReader.Clear();

            foreach (var item in this._StorageLstAdultReader)
            {
                if (item.Identify.ToLower().Contains(search.ToLower()))
                {
                    this._LstAdultReader.Add(item);
                }
                else if (item.FullName.ToLower().Contains(search.ToLower()))
                {
                    this._LstAdultReader.Add(item);
                }
            }
        }

        private List<AdultReader> GetListAdultReader()
        {
            List<AdultReader> lstAdultReader = new List<AdultReader>();

            foreach (var item in this._ReaderVM.readerRepo.Items)
            {
                if (this._ReaderVM.isAdult(item.Id))
                {
                    lstAdultReader.Add(new AdultReader(
                        item.Id,
                        item.LName,
                        item.FName,
                        item.boF,
                        true,
                        item.Status,
                        item.CreatedAt,
                        item.ModifiedAt,
                        this._AdultVM.adultRepo.GetByIdReader(item.Id).Identify
                    ));
                }
                else
                {
                    lstAdultReader.Add(new AdultReader(
                        item.Id,
                        item.LName,
                        item.FName,
                        item.boF,
                        false,
                        item.Status,
                        item.CreatedAt,
                        item.ModifiedAt,
                        "None"
                    ));
                }
            }

            return lstAdultReader;
        }

        private void btnDetail_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;

            AdultReader reader = button.Tag as AdultReader;

            if (reader.Type == true)
            {
                Adult adult = _AdultVM.adultRepo.GetByIdReader(reader.Id);
                Child child1 = _ChildVM.GetByAdultID(reader.Id);
                Child child2 = _ChildVM.GetByAdultIDSecond(reader.Id);
                ucAdultInformation info = new ucAdultInformation(_ReaderVM.readerRepo.Items.FirstOrDefault(i => i.Id == reader.Id), adult, child1, child2);
                WindowDefault window = new WindowDefault();
                window.grdContainer.Children.Add(info);
                window.ShowDialog();
            }
            else
            {
                Child child = _ChildVM.childRepo.GetByIdReader(reader.Id);
                Adult adult = _AdultVM.adultRepo.GetByIdReader(child.IdAdult);
                Reader adultReader = _ReaderVM.readerRepo.GetById(adult.IdReader);

                ucChildInformation info = new ucChildInformation(adultReader, adult, _ReaderVM.readerRepo.Items.FirstOrDefault(i => i.Id == reader.Id), child);
                WindowDefault window = new WindowDefault();
                window.grdContainer.Children.Add(info);
                window.ShowDialog();
            }
        }

        private void btnRestore_Click(object sender, RoutedEventArgs e)
        {
            restoreEvent?.Invoke(sender, e);
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            deleteEvent?.Invoke(sender, e);
        }

        public void Search(string search)
        {
            this._LstAdultReader.Clear();

            foreach (var item in this._StorageLstAdultReader)
            {
                if (item.FullName.ToLower().Contains(search.ToLower()))
                {
                    this._LstAdultReader.Add(item);
                }
                else if (item.Identify.ToLower().Contains(search.ToLower()))
                    this._LstAdultReader.Add(item);
                else if(search.ToLower() == "người lớn" || search.ToLower() == "trẻ em")
                    this._LstAdultReader.Add(item);
            }
            SetMaxPage();
            pagination.CurrentPage = 1;
            pagination.LoadPage();
        }

        private void btnHistory_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;

            AdultReader reader = button.Tag as AdultReader;

            ucDetailLoanAndLoanHistory detail = new ucDetailLoanAndLoanHistory(DatabaseFirst.Instance.db.Readers.FirstOrDefault(i => i.Id == reader.Id));

            WindowDefault window = new WindowDefault();

            window.grdContainer.Children.Add(detail);

            window.ShowDialog();
        }
    }
}

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
    /// Interaction logic for ucFunctionDataGrid.xaml
    /// </summary>
    public partial class ucFunctionDataGrid : UserControl
    {
        private ObservableCollection<Function> _StorageLstFunction;
        private ObservableCollection<Function> _LstFunction;

        private FunctionViewModel _FunctionVM = new FunctionViewModel();

        public delegate void DeleteHandle(object sender, RoutedEventArgs e);
        public event DeleteHandle deleteEvent;

        public delegate void UpdateHandle(object sender, RoutedEventArgs e);
        public event UpdateHandle updateEvent;

        public delegate void RestoreHandle(object sender, RoutedEventArgs e);
        public event RestoreHandle restoreEvent;

        public delegate void SelectionChangedHandle(object sender, SelectionChangedEventArgs e);
        public event SelectionChangedHandle selectionChangedEvent;

        public ucFunctionDataGrid()
        {
            InitializeComponent();

            this._StorageLstFunction = new ObservableCollection<Function>(_FunctionVM.functionRepo.Items.Where(i => i.IsAdmin == false));

            this._LstFunction = new ObservableCollection<Function>(this._StorageLstFunction);

            SetMaxPage();

            dgFunction.ItemsSource = null;
            dgFunction.ItemsSource = _LstFunction.Take(pagination.ItemPerPage);

            pagination.LoadPage();
        }

        public void ReloadShowing()
        {
            if (pagination.MaxPage == 0)
                pagination.lblShowing.Content = $"Showing 0 to 0 entities";
            else if (pagination.MaxPage == pagination.CurrentPage && _LstFunction.Count() % pagination.ItemPerPage != 0)
                pagination.lblShowing.Content = $"Showing {(pagination.CurrentPage - 1) * pagination.ItemPerPage + 1} to {(pagination.CurrentPage - 1) * pagination.ItemPerPage + _LstFunction.Count % pagination.ItemPerPage} entities";
            else
                pagination.lblShowing.Content = $"Showing {(pagination.CurrentPage - 1) * pagination.ItemPerPage + 1} to {(pagination.CurrentPage) * pagination.ItemPerPage} entities";
        }

        private void SetMaxPage()
        {
            pagination.MaxPage = (_LstFunction.Count / pagination.ItemPerPage);

            if (_LstFunction.Count % pagination.ItemPerPage != 0)
            {
                pagination.MaxPage += 1;
            }
        }

        public void SetVisibilityButton(Visibility visibilityDelete, Visibility visibilityUpdate, Visibility visibilityRestore)
        {
            dgFunction.Columns[6].Visibility = visibilityDelete;
            dgFunction.Columns[7].Visibility = visibilityUpdate;
            dgFunction.Columns[8].Visibility = visibilityRestore;
        }

        public void ReloadDataGrid()
        {
            dgFunction.ItemsSource = null;
            dgFunction.ItemsSource = _LstFunction.Skip((pagination.CurrentPage - 1) * pagination.ItemPerPage).Take(pagination.ItemPerPage);
            ReloadShowing();
        }

        public void ReloadStorage()
        {
            this._StorageLstFunction = new ObservableCollection<Function>(_FunctionVM.functionRepo.Items.Where(i => i.IsAdmin == false));

            this._LstFunction = new ObservableCollection<Function>(this._StorageLstFunction);

            SetMaxPage();

            dgFunction.ItemsSource = _LstFunction.Skip((pagination.CurrentPage - 1) * pagination.ItemPerPage).Take(pagination.ItemPerPage);
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            deleteEvent?.Invoke(sender, e);
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            updateEvent?.Invoke(sender, e);
        }

        private void btnRestore_Click(object sender, RoutedEventArgs e)
        {
            restoreEvent?.Invoke(sender, e);
        }

        private void dgFunction_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectionChangedEvent?.Invoke(sender, e);
        }

        public void FilterById(string id)
        {
            dgFunction.ItemsSource = null;
            dgFunction.ItemsSource = _LstFunction.Where(i => i.Id != id).Skip((pagination.CurrentPage - 1) * pagination.ItemPerPage).Take(pagination.ItemPerPage);

            pagination.MaxPage = (_LstFunction.Where(i => i.Id != id).ToList().Count / pagination.ItemPerPage);

            if (_LstFunction.Where(i => i.Id != id).ToList().Count % pagination.ItemPerPage != 0)
            {
                pagination.MaxPage += 1;
            }

            pagination.LoadPage();

            if (pagination.MaxPage == 0)
                pagination.lblShowing.Content = $"Showing 0 to 0 entities";
            else if (pagination.MaxPage == pagination.CurrentPage && dgFunction.ItemsSource.Cast<Function>().Count() % pagination.ItemPerPage != 0)
                pagination.lblShowing.Content = $"Showing {(pagination.CurrentPage - 1) * pagination.ItemPerPage + 1} to {(pagination.CurrentPage - 1) * pagination.ItemPerPage + dgFunction.ItemsSource.Cast<Function>().Count() % pagination.ItemPerPage} entities";
            else
                pagination.lblShowing.Content = $"Showing {(pagination.CurrentPage - 1) * pagination.ItemPerPage + 1} to {(pagination.CurrentPage) * pagination.ItemPerPage} entities";
        }

        public void Search(string search)
        {
            this._LstFunction.Clear();

            foreach (var item in this._StorageLstFunction)
            {
                if (item.Id.ToLower().Contains(search.ToLower()))
                {
                    this._LstFunction.Add(item);
                }
                else if (item.Name.ToLower().Contains(search.ToLower()))
                {
                    this._LstFunction.Add(item);
                }
                else if (item.Description.ToLower().Contains(search.ToLower()))
                {
                    this._LstFunction.Add(item);
                }
                else if(_StorageLstFunction.FirstOrDefault(i => i.Id == item.IdParent) != null)
                {
                    if (_StorageLstFunction.FirstOrDefault(i => i.Id == item.IdParent).Name.ToLower().Contains(search.ToLower()))
                        this._LstFunction.Add(item);
                }
                else if (item.UrlImage.ToLower().Contains(search.ToLower()))
                {
                    this._LstFunction.Add(item);
                }
            }
            SetMaxPage();
            pagination.CurrentPage = 1;
            pagination.LoadPage();
        }
    }
}

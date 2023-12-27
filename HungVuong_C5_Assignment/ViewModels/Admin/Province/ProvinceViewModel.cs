using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace HungVuong_C5_Assignment
{
    public class ProvinceViewModel
    {
        // Pagination Code
        #region Pagination Code
        public string Search { get; set; } = string.Empty;
        public bool IsChecked { get; set; }

        public ucProvinceDataGrid ProvinceDataGrid { get; set; }
        private ObservableCollection<Province> _StorageLstProvince;
        private ObservableCollection<Province> _LstProvince;

        public RelayCommand<object> SearchTextChangedCommand { get; private set; }
        public RelayCommand<object> RestoreChecked { get; private set; }
        public RelayCommand<object> RestoreUnchecked { get; private set; }
        #endregion

        private static readonly UnitOfWork unitOfWork = new UnitOfWork();
        public ProvinceRepository ProvinceRepo;

        public Province SelectedProvince { get; set; }

        public RelayCommand<object> AddCommand { get; private set; }
        public RelayCommand<object> RestoreCommand { get; private set; }
        public RelayCommand<object> DeleteCommand { get; private set; }
        public RelayCommand<object> UpdateCommand { get; private set; }

        public ProvinceViewModel()
        {
            ProvinceRepo = unitOfWork.Provinces;
        }

        public ProvinceViewModel(ucProvinceDataGrid ucProvinces)
        {
            this.ProvinceDataGrid = ucProvinces;

            ProvinceRepo = unitOfWork.Provinces;

            ReloadStorage();
            ProvinceDataGrid.pagination.LoadPage();

            ProvinceDataGrid.pagination.ChangedPageEvent += Pagination_ChangedPageEvent;
            ProvinceDataGrid.pagination.SelectionChangedComboBoxEvent += Pagination_SelectionChangedComboBoxEvent;
            ProvinceDataGrid.pagination.cbPage.SelectedIndex = 1;
            ProvinceDataGrid.dgProvinces.DataContext = this;

            SearchTextChangedCommand = new RelayCommand<object>(
                p => true,
                p =>
                {
                    ReloadDataGridBySearch(Search);
                }
            );

            RestoreChecked = new RelayCommand<object>(
                p => true,
                p =>
                {
                    Reload();
                    SetVisibilityButton(Visibility.Collapsed, Visibility.Visible, Visibility.Collapsed);
                }
            );

            RestoreUnchecked = new RelayCommand<object>(
               p => true,
               p =>
               {
                   Reload();
                   SetVisibilityButton(Visibility.Visible, Visibility.Collapsed, Visibility.Visible);
               }
           );

            AddCommand = new RelayCommand<object>(
                p => true,
                p =>
                {
                    WindowDefault window = new WindowDefault();
                    window.Content = new ucAddProvince(window);
                    window.ShowDialog();

                    if (window.DialogResult == true)
                    {
                        Province newProvince = window.Tag as Province;

                        ProvinceRepo.Add(newProvince);

                        DatabaseFirst.Instance.SaveChanged();

                        ReloadStorage();

                        if (Search != string.Empty)
                            SearchByText(Search);

                        ReloadDataGrid();

                        ProvinceDataGrid.pagination.LoadPage();

                        MessageBox.Show($"Province '{newProvince.Name}' added successfully!", "Notify", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
            );

            DeleteCommand = new RelayCommand<object>(
               p => true,
               p =>
               {
                   if (MessageBox.Show($"Are you sure you want to delete Province '{SelectedProvince.Name}'", "Notify", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                   {
                       string name = SelectedProvince.Name;
                       ProvinceRepo.Remove(SelectedProvince);
                       DatabaseFirst.Instance.SaveChanged();

                       ReloadStorage();

                       if (ProvinceDataGrid.pagination.CurrentPage > ProvinceDataGrid.pagination.MaxPage)
                       {
                           ProvinceDataGrid.pagination.CurrentPage -= 1;
                           ReloadDataGrid();
                           ProvinceDataGrid.pagination.LoadPage();
                       }
                       else
                       {
                           ReloadDataGrid();
                           ProvinceDataGrid.pagination.LoadPage();
                       }

                       if (Search != string.Empty)
                           ReloadDataGridBySearch(Search);

                       MessageBox.Show($"Province '{name}' successfully deleted!", "Notify", MessageBoxButton.OK, MessageBoxImage.Information);
                   }
               }
           );

            RestoreCommand = new RelayCommand<object>(
               p => true,
               p =>
               {
                   if (MessageBox.Show($"Are you sure you want to restore Province '{SelectedProvince.Name}'", "Notify", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                   {
                       string name = SelectedProvince.Name;

                       ProvinceRepo.Restore(SelectedProvince);

                       DatabaseFirst.Instance.SaveChanged();

                       ReloadStorage();

                       if (ProvinceDataGrid.pagination.CurrentPage > ProvinceDataGrid.pagination.MaxPage)
                       {
                           ProvinceDataGrid.pagination.CurrentPage -= 1;
                           ReloadDataGrid();
                           ProvinceDataGrid.pagination.LoadPage();
                       }
                       else
                       {
                           ReloadDataGrid();
                           ProvinceDataGrid.pagination.LoadPage();
                       }

                       if (Search != string.Empty)
                           ReloadDataGridBySearch(Search);

                       MessageBox.Show($"Province '{name}' successfully restored!", "Notify", MessageBoxButton.OK, MessageBoxImage.Information);
                   }
               }
           );

            UpdateCommand = new RelayCommand<object>(
               p => true,
               p =>
               {
                   WindowDefault window = new WindowDefault();
                   ucUpdateProvince addCategory = new ucUpdateProvince(window, SelectedProvince);
                   window.Content = addCategory;
                   window.ShowDialog();

                   if (window.DialogResult == true)
                   {
                       Province newProvince = window.Tag as Province;

                       ProvinceRepo.Update(SelectedProvince, newProvince);

                       DatabaseFirst.Instance.SaveChanged();

                       ReloadStorage();

                       if (Search != string.Empty)
                           SearchByText(Search);

                       ReloadDataGrid();

                       ProvinceDataGrid.pagination.LoadPage();

                       MessageBox.Show($"Province update successful!", "Notify", MessageBoxButton.OK, MessageBoxImage.Information);
                   }
               }
           );
        }

        private void SetVisibilityButton(Visibility delete, Visibility restore, Visibility update)
        {
            ProvinceDataGrid.dgProvinces.Columns[3].Visibility = update;
            ProvinceDataGrid.dgProvinces.Columns[4].Visibility = delete;
            ProvinceDataGrid.dgProvinces.Columns[5].Visibility = restore;
        }

        private void ReloadDataGridBySearch(string search)
        {
            SearchByText(search);
            ReloadDataGrid();
        }

        private void Pagination_SelectionChangedComboBoxEvent(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            ProvinceDataGrid.pagination.ItemPerPage = int.Parse((ProvinceDataGrid.pagination.cbPage.SelectedItem as ComboBoxItem).Content.ToString());
            Reload();
        }

        private void Pagination_ChangedPageEvent(Pagination pagination)
        {
            ReloadDataGrid();
        }

        private void Reload()
        {
            ReloadStorage();
            Search = string.Empty;

            ProvinceDataGrid.pagination.CurrentPage = 1;
            ProvinceDataGrid.pagination.LoadPage();

            ReloadDataGrid();
        }

        private void ReloadDataGrid()
        {
            ProvinceDataGrid.dgProvinces.ItemsSource = null;
            ProvinceDataGrid.dgProvinces.ItemsSource = _LstProvince.Skip((ProvinceDataGrid.pagination.CurrentPage - 1) * ProvinceDataGrid.pagination.ItemPerPage).Take(ProvinceDataGrid.pagination.ItemPerPage);
            ProvinceDataGrid.pagination.ReloadShowing<Province>(_LstProvince.Count);
        }

        private void ReloadStorage()
        {
            this._StorageLstProvince = new ObservableCollection<Province>(DatabaseFirst.Instance.db.Provinces.Where(i => i.Status == !IsChecked));

            this._LstProvince = new ObservableCollection<Province>(this._StorageLstProvince);

            ProvinceDataGrid.pagination.SetMaxPage<Province>(_LstProvince.Count);

            ProvinceDataGrid.dgProvinces.ItemsSource = _LstProvince.Skip((ProvinceDataGrid.pagination.CurrentPage - 1) * ProvinceDataGrid.pagination.ItemPerPage).Take(ProvinceDataGrid.pagination.ItemPerPage);
        }

        private void SearchByText(string search)
        {
            this._LstProvince.Clear();

            foreach (var item in this._StorageLstProvince)
            {
                if (item.Id.ToString().Contains(search))
                {
                    this._LstProvince.Add(item);
                }
                else if (item.Name.ToLower().Contains(search.ToLower()))
                {
                    this._LstProvince.Add(item);
                }
            }

            ProvinceDataGrid.pagination.SetMaxPage<Province>(_LstProvince.Count);
            ProvinceDataGrid.pagination.CurrentPage = 1;
            ProvinceDataGrid.pagination.LoadPage();
        }
    }
}

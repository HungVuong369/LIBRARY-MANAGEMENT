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
    public class ParameterViewModel
    {
        // Pagination Code
        #region Pagination Code
        public string Search { get; set; } = string.Empty;
        public bool IsChecked { get; set; }

        public ucParameterDataGrid ParameterDataGrid { get; set; }
        private ObservableCollection<Parameter> _StorageLstParameter;
        private ObservableCollection<Parameter> _LstParameter;
        #endregion

        private static readonly UnitOfWork unitOfWork = new UnitOfWork();
        public ParameterRepository parameterRepo;

        public Parameter SelectedParameter { get; set; }

        public RelayCommand<object> SearchTextChangedCommand { get; private set; }
        public RelayCommand<object> RestoreChecked { get; private set; }
        public RelayCommand<object> RestoreUnchecked { get; private set; }

        public RelayCommand<object> AddCommand { get; private set; }

        public RelayCommand<object> RestoreCommand { get; private set; }
        public RelayCommand<object> DeleteCommand { get; private set; }
        public RelayCommand<object> UpdateCommand { get; private set; }

        public ParameterViewModel()
        {
            parameterRepo = unitOfWork.Parameters;
        }

        public ParameterViewModel(ucParameterDataGrid ucParameters)
        {
            this.ParameterDataGrid = ucParameters;

            parameterRepo = unitOfWork.Parameters;

            ReloadStorage();
            ParameterDataGrid.pagination.LoadPage();

            ParameterDataGrid.pagination.ChangedPageEvent += Pagination_ChangedPageEvent;
            ParameterDataGrid.pagination.SelectionChangedComboBoxEvent += Pagination_SelectionChangedComboBoxEvent;
            ParameterDataGrid.pagination.cbPage.SelectedIndex = 1;
            ParameterDataGrid.dgParameters.DataContext = this;

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
                    window.Content = new ucAddParameter(window);
                    window.ShowDialog();

                    if (window.DialogResult == true)
                    {
                        Parameter newParameter = window.Tag as Parameter;

                        parameterRepo.Add(newParameter);

                        DatabaseFirst.Instance.SaveChanged();

                        ReloadStorage();

                        if (Search != string.Empty)
                            SearchByText(Search);

                        ReloadDataGrid();

                        ParameterDataGrid.pagination.LoadPage();

                        MessageBox.Show($"Parameter '{newParameter.Name}' added successfully!", "Notify", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
            );

            DeleteCommand = new RelayCommand<object>(
               p => true,
               p =>
               {
                   if(int.Parse(SelectedParameter.Id.Substring(2)) <= 12 && int.Parse(SelectedParameter.Id.Substring(2)) != 5)
                   {
                       MessageBox.Show("Cannot delete default Parameters!", "Notify", MessageBoxButton.OK, MessageBoxImage.Warning);
                       return;
                   }
                   if (MessageBox.Show($"Are you sure you want to delete Parameter '{SelectedParameter.Name}'", "Notify", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                   {
                       string name = SelectedParameter.Name;
                       parameterRepo.Remove(SelectedParameter);
                       DatabaseFirst.Instance.SaveChanged();

                       ReloadStorage();

                       if (ParameterDataGrid.pagination.CurrentPage > ParameterDataGrid.pagination.MaxPage)
                       {
                           ParameterDataGrid.pagination.CurrentPage -= 1;
                           ReloadDataGrid();
                           ParameterDataGrid.pagination.LoadPage();
                       }
                       else
                       {
                           ReloadDataGrid();
                           ParameterDataGrid.pagination.LoadPage();
                       }

                       if (Search != string.Empty)
                           ReloadDataGridBySearch(Search);

                       MessageBox.Show($"Parameter '{name}' successfully deleted!", "Notify", MessageBoxButton.OK, MessageBoxImage.Information);
                   }
               }
           );

            RestoreCommand = new RelayCommand<object>(
               p => true,
               p =>
               {
                   if (MessageBox.Show($"Are you sure you want to restore Parameter '{SelectedParameter.Name}'", "Notify", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                   {
                       string name = SelectedParameter.Name;

                       parameterRepo.Restore(SelectedParameter);

                       DatabaseFirst.Instance.SaveChanged();

                       ReloadStorage();

                       if (ParameterDataGrid.pagination.CurrentPage > ParameterDataGrid.pagination.MaxPage)
                       {
                           ParameterDataGrid.pagination.CurrentPage -= 1;
                           ReloadDataGrid();
                           ParameterDataGrid.pagination.LoadPage();
                       }
                       else
                       {
                           ReloadDataGrid();
                           ParameterDataGrid.pagination.LoadPage();
                       }

                       if (Search != string.Empty)
                           ReloadDataGridBySearch(Search);

                       MessageBox.Show($"Parameter '{name}' successfully restored!", "Notify", MessageBoxButton.OK, MessageBoxImage.Information);
                   }
               }
           );

            UpdateCommand = new RelayCommand<object>(
               p => true,
               p =>
               {
                   WindowDefault window = new WindowDefault();
                   ucUpdateParameter addParameter = new ucUpdateParameter(window, SelectedParameter);
                   window.Content = addParameter;
                   window.ShowDialog();

                   if (window.DialogResult == true)
                   {
                       Parameter newParameter = window.Tag as Parameter;

                       parameterRepo.Update(SelectedParameter, newParameter);

                       DatabaseFirst.Instance.SaveChanged();

                       ReloadStorage();

                       if (Search != string.Empty)
                           SearchByText(Search);

                       ReloadDataGrid();

                       ParameterDataGrid.pagination.LoadPage();

                       MessageBox.Show($"Parameter update successful!", "Notify", MessageBoxButton.OK, MessageBoxImage.Information);
                   }
               }
           );
        }

        private void SetVisibilityButton(Visibility delete, Visibility restore, Visibility update)
        {
            ParameterDataGrid.dgParameters.Columns[ParameterDataGrid.dgParameters.Columns.Count - 3].Visibility = update;
            ParameterDataGrid.dgParameters.Columns[ParameterDataGrid.dgParameters.Columns.Count - 2].Visibility = delete;
            ParameterDataGrid.dgParameters.Columns[ParameterDataGrid.dgParameters.Columns.Count - 1].Visibility = restore;
        }

        private void ReloadDataGridBySearch(string search)
        {
            SearchByText(search);
            ReloadDataGrid();
        }

        private void Pagination_SelectionChangedComboBoxEvent(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            ParameterDataGrid.pagination.ItemPerPage = int.Parse((ParameterDataGrid.pagination.cbPage.SelectedItem as ComboBoxItem).Content.ToString());
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

            ParameterDataGrid.pagination.CurrentPage = 1;
            ParameterDataGrid.pagination.LoadPage();

            ReloadDataGrid();
        }

        private void ReloadDataGrid()
        {
            ParameterDataGrid.dgParameters.ItemsSource = null;
            ParameterDataGrid.dgParameters.ItemsSource = _LstParameter.Skip((ParameterDataGrid.pagination.CurrentPage - 1) * ParameterDataGrid.pagination.ItemPerPage).Take(ParameterDataGrid.pagination.ItemPerPage);
            ParameterDataGrid.pagination.ReloadShowing<Parameter>(_LstParameter.ToList());
        }

        private void ReloadStorage()
        {
            this._StorageLstParameter = new ObservableCollection<Parameter>(DatabaseFirst.Instance.db.Parameters.Where(i => i.Status == !IsChecked));

            this._LstParameter = new ObservableCollection<Parameter>(this._StorageLstParameter);

            ParameterDataGrid.pagination.SetMaxPage<Parameter>(_LstParameter.ToList());

            ParameterDataGrid.dgParameters.ItemsSource = _LstParameter.Skip((ParameterDataGrid.pagination.CurrentPage - 1) * ParameterDataGrid.pagination.ItemPerPage).Take(ParameterDataGrid.pagination.ItemPerPage);
        }

        private void SearchByText(string search)
        {
            this._LstParameter.Clear();

            foreach (var item in this._StorageLstParameter)
            {
                if (item.Id.ToLower().Contains(search.ToLower()))
                {
                    this._LstParameter.Add(item);
                }
                else if (item.Name.ToLower().Contains(search.ToLower()))
                {
                    this._LstParameter.Add(item);
                }
            }

            ParameterDataGrid.pagination.SetMaxPage<Parameter>(_LstParameter.ToList());
            ParameterDataGrid.pagination.CurrentPage = 1;
            ParameterDataGrid.pagination.LoadPage();
        }

        public string GetValueByID(string id)
        {
            foreach (var item in parameterRepo.Items)
            {
                if (item.Id == id)
                    return item.Value;
            }
            return null;
        }
    }
}

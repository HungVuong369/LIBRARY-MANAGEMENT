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
    public class TranslatorViewModel
    {
        public string Search { get; set; } = string.Empty;
        public bool IsChecked { get; set; }

        private static readonly UnitOfWork unitOfWork = new UnitOfWork();
        public TranslatorRepository translatorRepo { get; set; }

        private ObservableCollection<Translator> _StorageLstTranslator;
        private ObservableCollection<Translator> _LstTranslator;

        public Translator SelectedTranslator { get; set; }

        public ucTranslatorDataGrid TranslatorDataGrid { get; set; }

        public RelayCommand<object> SearchTextChangedCommand { get; private set; }
        public RelayCommand<object> RestoreChecked { get; private set; }
        public RelayCommand<object> RestoreUnchecked { get; private set; }

        public RelayCommand<object> AddCommand { get; private set; }

        public RelayCommand<object> RestoreCommand { get; private set; }
        public RelayCommand<object> DeleteCommand { get; private set; }
        public RelayCommand<object> UpdateCommand { get; private set; }

        public TranslatorViewModel()
        {
            translatorRepo = unitOfWork.Translators;
        }

        public TranslatorViewModel(ucTranslatorDataGrid ucTranslators)
        {
            this.TranslatorDataGrid = ucTranslators;

            translatorRepo = unitOfWork.Translators;

            ReloadStorage();
            TranslatorDataGrid.pagination.LoadPage();

            TranslatorDataGrid.pagination.ChangedPageEvent += Pagination_ChangedPageEvent;
            TranslatorDataGrid.pagination.SelectionChangedComboBoxEvent += Pagination_SelectionChangedComboBoxEvent;
            TranslatorDataGrid.pagination.cbPage.SelectedIndex = 1;
            TranslatorDataGrid.dgTranslators.DataContext = this;

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
                    window.Content = new ucAddTranslator(window);
                    window.ShowDialog();

                    if (window.DialogResult == true)
                    {
                        Translator newTranslator = window.Tag as Translator;

                        translatorRepo.Add(newTranslator);

                        DatabaseFirst.Instance.SaveChanged();

                        ReloadStorage();

                        if (Search != string.Empty)
                            SearchByText(Search);

                        ReloadDataGrid();

                        TranslatorDataGrid.pagination.LoadPage();

                        MessageBox.Show($"Translator '{newTranslator.Name}' added successfully!", "Notify", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
            );

            DeleteCommand = new RelayCommand<object>(
               p => true,
               p =>
               {
                   if (SelectedTranslator.Books.Count != 0)
                   {
                       MessageBox.Show($"Cannot delete translator '{SelectedTranslator.Name}'", "Notify", MessageBoxButton.OK, MessageBoxImage.Warning);
                       return;
                   }
                   if (MessageBox.Show($"Are you sure you want to delete translator '{SelectedTranslator.Name}'", "Notify", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                   {
                       string name = SelectedTranslator.Name;
                       translatorRepo.Remove(SelectedTranslator);
                       DatabaseFirst.Instance.SaveChanged();

                       ReloadStorage();

                       if (TranslatorDataGrid.pagination.CurrentPage > TranslatorDataGrid.pagination.MaxPage)
                       {
                           TranslatorDataGrid.pagination.CurrentPage -= 1;
                           ReloadDataGrid();
                           TranslatorDataGrid.pagination.LoadPage();
                       }
                       else
                       {
                           ReloadDataGrid();
                           TranslatorDataGrid.pagination.LoadPage();
                       }

                       if (Search != string.Empty)
                           ReloadDataGridBySearch(Search);

                       MessageBox.Show($"Translator '{name}' successfully deleted!", "Notify", MessageBoxButton.OK, MessageBoxImage.Information);
                   }
               }
           );

            RestoreCommand = new RelayCommand<object>(
               p => true,
               p =>
               {
                   if (MessageBox.Show($"Are you sure you want to restore translator '{SelectedTranslator.Name}'", "Notify", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                   {
                       string name = SelectedTranslator.Name;

                       translatorRepo.Restore(SelectedTranslator);

                       DatabaseFirst.Instance.SaveChanged();

                       ReloadStorage();

                       if (TranslatorDataGrid.pagination.CurrentPage > TranslatorDataGrid.pagination.MaxPage)
                       {
                           TranslatorDataGrid.pagination.CurrentPage -= 1;
                           ReloadDataGrid();
                           TranslatorDataGrid.pagination.LoadPage();
                       }
                       else
                       {
                           ReloadDataGrid();
                           TranslatorDataGrid.pagination.LoadPage();
                       }

                       if (Search != string.Empty)
                           ReloadDataGridBySearch(Search);

                       MessageBox.Show($"Translator '{name}' successfully restored!", "Notify", MessageBoxButton.OK, MessageBoxImage.Information);
                   }
               }
           );

            UpdateCommand = new RelayCommand<object>(
               p => true,
               p =>
               {
                   WindowDefault window = new WindowDefault();
                   ucUpdateTranslator updateTranslator = new ucUpdateTranslator(window, SelectedTranslator);
                   window.Content = updateTranslator;
                   window.ShowDialog();

                   if (window.DialogResult == true)
                   {
                       Translator newTranslator = window.Tag as Translator;

                       translatorRepo.Update(SelectedTranslator, newTranslator);

                       DatabaseFirst.Instance.SaveChanged();

                       ReloadStorage();

                       if (Search != string.Empty)
                           SearchByText(Search);

                       ReloadDataGrid();

                       TranslatorDataGrid.pagination.LoadPage();

                       MessageBox.Show($"Translator update successful!", "Notify", MessageBoxButton.OK, MessageBoxImage.Information);
                   }
               }
           );
        }

        private void SetVisibilityButton(Visibility delete, Visibility restore, Visibility update)
        {
            TranslatorDataGrid.dgTranslators.Columns[8].Visibility = update;
            TranslatorDataGrid.dgTranslators.Columns[9].Visibility = delete;
            TranslatorDataGrid.dgTranslators.Columns[10].Visibility = restore;
        }

        private void ReloadDataGridBySearch(string search)
        {
            SearchByText(search);
            ReloadDataGrid();
        }

        private void Pagination_SelectionChangedComboBoxEvent(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            TranslatorDataGrid.pagination.ItemPerPage = int.Parse((TranslatorDataGrid.pagination.cbPage.SelectedItem as ComboBoxItem).Content.ToString());
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

            TranslatorDataGrid.pagination.CurrentPage = 1;
            TranslatorDataGrid.pagination.LoadPage();

            ReloadDataGrid();
        }

        private void ReloadDataGrid()
        {
            TranslatorDataGrid.dgTranslators.ItemsSource = null;
            TranslatorDataGrid.dgTranslators.ItemsSource = _LstTranslator.Skip((TranslatorDataGrid.pagination.CurrentPage - 1) * TranslatorDataGrid.pagination.ItemPerPage).Take(TranslatorDataGrid.pagination.ItemPerPage);
            TranslatorDataGrid.pagination.ReloadShowing<Translator>(_LstTranslator.ToList());
        }

        private void ReloadStorage()
        {
            this._StorageLstTranslator = new ObservableCollection<Translator>(DatabaseFirst.Instance.db.Translators.Where(i => i.Status == !IsChecked));

            this._LstTranslator = new ObservableCollection<Translator>(this._StorageLstTranslator);

            TranslatorDataGrid.pagination.SetMaxPage<Translator>(_LstTranslator.ToList());

            TranslatorDataGrid.dgTranslators.ItemsSource = _LstTranslator.Skip((TranslatorDataGrid.pagination.CurrentPage - 1) * TranslatorDataGrid.pagination.ItemPerPage).Take(TranslatorDataGrid.pagination.ItemPerPage);
        }

        private void SearchByText(string search)
        {
            this._LstTranslator.Clear();

            foreach (var item in this._StorageLstTranslator)
            {
                if (item.Id.ToLower().Contains(search.ToLower()))
                {
                    this._LstTranslator.Add(item);
                }
                else if (item.Name.ToLower().Contains(search.ToLower()))
                {
                    this._LstTranslator.Add(item);
                }
                else if (item.boF.ToString("dd/MM/yyyy").Contains(search))
                {
                    this._LstTranslator.Add(item);
                }
                else if (item.CreatedAt.ToString("dd/MM/yyyy").Contains(search))
                {
                    this._LstTranslator.Add(item);
                }
                else if (item.ModifiedAt.ToString("dd/MM/yyyy").Contains(search))
                {
                    this._LstTranslator.Add(item);
                }
            }

            TranslatorDataGrid.pagination.SetMaxPage<Translator>(_LstTranslator.ToList());
            TranslatorDataGrid.pagination.CurrentPage = 1;
            TranslatorDataGrid.pagination.LoadPage();
        }
    }
}

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
    public class CategoryViewModel
    {
        // Pagination Code
        #region Pagination Code
        public string Search { get; set; } = string.Empty;
        public bool IsChecked { get; set; }

        public ucCategoryDataGrid CategoryDataGrid { get; set; }
        private ObservableCollection<Category> _StorageLstCategory;
        private ObservableCollection<Category> _LstCategory;
        #endregion

        private static readonly UnitOfWork unitOfWork = new UnitOfWork();
        public CategoryRepository categoryRepo;

        public Category SelectedCategory { get; set; }

        public RelayCommand<object> SearchTextChangedCommand { get; private set; }
        public RelayCommand<object> RestoreChecked { get; private set; }
        public RelayCommand<object> RestoreUnchecked { get; private set; }

        public RelayCommand<object> AddCommand { get; private set; }

        public RelayCommand<object> RestoreCommand { get; private set; }
        public RelayCommand<object> DeleteCommand { get; private set; }
        public RelayCommand<object> UpdateCommand { get; private set; }

        public CategoryViewModel()
        {
            categoryRepo = unitOfWork.Categories;
        }

        public CategoryViewModel(ucCategoryDataGrid ucCategories)
        {
            this.CategoryDataGrid = ucCategories;

            categoryRepo = unitOfWork.Categories;

            CategoryDataGrid.pagination.ChangedPageEvent += Pagination_ChangedPageEvent;
            CategoryDataGrid.pagination.SelectionChangedComboBoxEvent += Pagination_SelectionChangedComboBoxEvent;
            CategoryDataGrid.pagination.cbPage.SelectedIndex = 1;
            CategoryDataGrid.dgCategories.DataContext = this;

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
                    window.Content = new ucAddCategory(window);
                    window.ShowDialog();

                    if(window.DialogResult == true)
                    {
                        Category newCategory = window.Tag as Category;

                        categoryRepo.Add(newCategory);

                        DatabaseFirst.Instance.SaveChanged();

                        ReloadStorage();

                        if (Search != string.Empty)
                            SearchByText(Search);

                        ReloadDataGrid();

                        CategoryDataGrid.pagination.LoadPage();

                        MessageBox.Show($"Category '{newCategory.Name}' added successfully!", "Notify", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }    
            );

            DeleteCommand = new RelayCommand<object>(
               p => true,
               p =>
               {
                   if (SelectedCategory.BookTitles.Count != 0)
                   {
                       MessageBox.Show($"Cannot delete category '{SelectedCategory.Name}'", "Notify", MessageBoxButton.OK, MessageBoxImage.Warning);
                       return;
                   }
                   if (MessageBox.Show($"Are you sure you want to delete category '{SelectedCategory.Name}'", "Notify", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                   {
                       string name = SelectedCategory.Name;
                       categoryRepo.Remove(SelectedCategory);
                       DatabaseFirst.Instance.SaveChanged();

                       ReloadStorage();

                       if (CategoryDataGrid.pagination.CurrentPage > CategoryDataGrid.pagination.MaxPage)
                       {
                           CategoryDataGrid.pagination.CurrentPage -= 1;
                           ReloadDataGrid();
                           CategoryDataGrid.pagination.LoadPage();
                       }
                       else
                       {
                           ReloadDataGrid();
                           CategoryDataGrid.pagination.LoadPage();
                       }

                       if (Search != string.Empty)
                           ReloadDataGridBySearch(Search);

                       MessageBox.Show($"Category '{name}' successfully deleted!", "Notify", MessageBoxButton.OK, MessageBoxImage.Information);
                   }
               }
           );

            RestoreCommand = new RelayCommand<object>(
               p => true,
               p =>
               {
                   if (MessageBox.Show($"Are you sure you want to restore category '{SelectedCategory.Name}'", "Notify", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                   {
                       string name = SelectedCategory.Name;

                       categoryRepo.Restore(SelectedCategory);

                       DatabaseFirst.Instance.SaveChanged();

                       ReloadStorage();

                       if (CategoryDataGrid.pagination.CurrentPage > CategoryDataGrid.pagination.MaxPage)
                       {
                           CategoryDataGrid.pagination.CurrentPage -= 1;
                           ReloadDataGrid();
                           CategoryDataGrid.pagination.LoadPage();
                       }
                       else
                       {
                           ReloadDataGrid();
                           CategoryDataGrid.pagination.LoadPage();
                       }

                       if (Search != string.Empty)
                           ReloadDataGridBySearch(Search);

                       MessageBox.Show($"Category '{name}' successfully restored!", "Notify", MessageBoxButton.OK, MessageBoxImage.Information);
                   }
               }
           );

            UpdateCommand = new RelayCommand<object>(
               p => true,
               p =>
               {
                   WindowDefault window = new WindowDefault();
                   ucUpdateCategory addCategory = new ucUpdateCategory(window, SelectedCategory);
                   window.Content = addCategory;
                   window.ShowDialog();

                   if (window.DialogResult == true)
                   {
                       Category newCategory = window.Tag as Category;

                       categoryRepo.Update(SelectedCategory, newCategory);

                       DatabaseFirst.Instance.SaveChanged();

                       ReloadStorage();

                       if (Search != string.Empty)
                           SearchByText(Search);

                       ReloadDataGrid();

                       CategoryDataGrid.pagination.LoadPage();

                       MessageBox.Show($"Category update successful!", "Notify", MessageBoxButton.OK, MessageBoxImage.Information);
                   }
               }
           );
        }

        private void SetVisibilityButton(Visibility delete, Visibility restore, Visibility update)
        {
            CategoryDataGrid.dgCategories.Columns[5].Visibility = update;
            CategoryDataGrid.dgCategories.Columns[6].Visibility = delete;
            CategoryDataGrid.dgCategories.Columns[7].Visibility = restore;
        }

        private void ReloadDataGridBySearch(string search)
        {
            SearchByText(search);
            ReloadDataGrid();
        }

        private void Pagination_SelectionChangedComboBoxEvent(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            CategoryDataGrid.pagination.ItemPerPage = int.Parse((CategoryDataGrid.pagination.cbPage.SelectedItem as ComboBoxItem).Content.ToString());
            Reload();
        }

        private void Pagination_ChangedPageEvent(Pagination pagination)
        {
            ReloadDataGrid();
        }

        private void Reload()
        {
            CategoryDataGrid.pagination.CurrentPage = 1;

            ReloadStorage();

            Search = string.Empty;

            CategoryDataGrid.pagination.LoadPage();

            CategoryDataGrid.pagination.SetMaxPage<Category>(_LstCategory.Count);
        }

        private void ReloadDataGrid()
        {
            CategoryDataGrid.dgCategories.ItemsSource = null;
            CategoryDataGrid.dgCategories.ItemsSource = _LstCategory.Skip((CategoryDataGrid.pagination.CurrentPage - 1) * CategoryDataGrid.pagination.ItemPerPage).Take(CategoryDataGrid.pagination.ItemPerPage);
            CategoryDataGrid.pagination.ReloadShowing<Category>(_LstCategory.Count);
        }

        private void ReloadStorage()
        {
            this._StorageLstCategory = new ObservableCollection<Category>(DatabaseFirst.Instance.db.Categories.Where(i => i.Status == !IsChecked));

            this._LstCategory = new ObservableCollection<Category>(this._StorageLstCategory);

            CategoryDataGrid.pagination.SetMaxPage<Category>(_LstCategory.Count);

            CategoryDataGrid.dgCategories.ItemsSource = null;

            CategoryDataGrid.dgCategories.ItemsSource = _LstCategory.Skip((CategoryDataGrid.pagination.CurrentPage - 1) * CategoryDataGrid.pagination.ItemPerPage).Take(CategoryDataGrid.pagination.ItemPerPage);
        }

        private void SearchByText(string search)
        {
            this._LstCategory.Clear();

            foreach (var item in this._StorageLstCategory)
            {
                if (item.Id.ToLower().Contains(search.ToLower()))
                {
                    this._LstCategory.Add(item);
                }
                else if (item.Name.ToLower().Contains(search.ToLower()))
                {
                    this._LstCategory.Add(item);
                }
            }

            CategoryDataGrid.pagination.SetMaxPage<Category>(_LstCategory.Count);
            CategoryDataGrid.pagination.CurrentPage = 1;
            CategoryDataGrid.pagination.LoadPage();
        }

    }
}

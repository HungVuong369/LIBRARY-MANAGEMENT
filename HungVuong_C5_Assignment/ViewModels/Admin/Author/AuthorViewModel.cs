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
    public class AuthorViewModel
    {
        public string Search { get; set; } = string.Empty;
        public bool IsChecked { get; set; }

        private static readonly UnitOfWork unitOfWork = new UnitOfWork();
        public AuthorRepository authorRepo { get; set; }

        private ObservableCollection<Author> _StorageLstAuthor;
        private ObservableCollection<Author> _LstAuthor;

        public Author SelectedAuthor { get; set; }

        public ucAuthorDataGrid AuthorDataGrid { get; set; }

        public RelayCommand<object> SearchTextChangedCommand { get; private set; }
        public RelayCommand<object> RestoreChecked { get; private set; }
        public RelayCommand<object> RestoreUnchecked { get; private set; }

        public RelayCommand<object> AddCommand { get; private set; }

        public RelayCommand<object> RestoreCommand { get; private set; }
        public RelayCommand<object> DeleteCommand { get; private set; }
        public RelayCommand<object> UpdateCommand { get; private set; }

        public AuthorViewModel()
        {
            authorRepo = unitOfWork.Authors;
        }

        public AuthorViewModel(ucAuthorDataGrid ucAuthors)
        {
            this.AuthorDataGrid = ucAuthors;

            authorRepo = unitOfWork.Authors;

            ReloadStorage();
            AuthorDataGrid.pagination.LoadPage();

            AuthorDataGrid.pagination.ChangedPageEvent += Pagination_ChangedPageEvent;
            AuthorDataGrid.pagination.SelectionChangedComboBoxEvent += Pagination_SelectionChangedComboBoxEvent;
            AuthorDataGrid.pagination.cbPage.SelectedIndex = 1;
            AuthorDataGrid.dgAuthors.DataContext = this;

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
                    window.Content = new ucAddAuthor(window);
                    window.ShowDialog();

                    if (window.DialogResult == true)
                    {
                        Author newAuthor = window.Tag as Author;

                        authorRepo.Add(newAuthor);

                        DatabaseFirst.Instance.SaveChanged();

                        ReloadStorage();

                        if (Search != string.Empty)
                            SearchByText(Search);

                        ReloadDataGrid();

                        AuthorDataGrid.pagination.LoadPage();

                        MessageBox.Show($"Author '{newAuthor.Name}' added successfully!", "Notify", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
            );

            DeleteCommand = new RelayCommand<object>(
               p => true,
               p =>
               {
                   if (SelectedAuthor.BookISBNs.Count != 0)
                   {
                       MessageBox.Show($"Cannot delete author '{SelectedAuthor.Name}'", "Notify", MessageBoxButton.OK, MessageBoxImage.Warning);
                       return;
                   }
                   if (MessageBox.Show($"Are you sure you want to delete author '{SelectedAuthor.Name}'", "Notify", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                   {
                       string name = SelectedAuthor.Name;
                       authorRepo.Remove(SelectedAuthor);
                       DatabaseFirst.Instance.SaveChanged();

                       ReloadStorage();

                       if (AuthorDataGrid.pagination.CurrentPage > AuthorDataGrid.pagination.MaxPage)
                       {
                           AuthorDataGrid.pagination.CurrentPage -= 1;
                           ReloadDataGrid();
                           AuthorDataGrid.pagination.LoadPage();
                       }
                       else
                       {
                           ReloadDataGrid();
                           AuthorDataGrid.pagination.LoadPage();
                       }

                       if (Search != string.Empty)
                           ReloadDataGridBySearch(Search);

                       MessageBox.Show($"Author '{name}' successfully deleted!", "Notify", MessageBoxButton.OK, MessageBoxImage.Information);
                   }
               }
           );

            RestoreCommand = new RelayCommand<object>(
               p => true,
               p =>
               {
                   if (MessageBox.Show($"Are you sure you want to restore author '{SelectedAuthor.Name}'", "Notify", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                   {
                       string name = SelectedAuthor.Name;

                       authorRepo.Restore(SelectedAuthor);

                       DatabaseFirst.Instance.SaveChanged();

                       ReloadStorage();

                       if (AuthorDataGrid.pagination.CurrentPage > AuthorDataGrid.pagination.MaxPage)
                       {
                           AuthorDataGrid.pagination.CurrentPage -= 1;
                           ReloadDataGrid();
                           AuthorDataGrid.pagination.LoadPage();
                       }
                       else
                       {
                           ReloadDataGrid();
                           AuthorDataGrid.pagination.LoadPage();
                       }

                       if (Search != string.Empty)
                           ReloadDataGridBySearch(Search);

                       MessageBox.Show($"Author '{name}' successfully restored!", "Notify", MessageBoxButton.OK, MessageBoxImage.Information);
                   }
               }
           );

            UpdateCommand = new RelayCommand<object>(
               p => true,
               p =>
               {
                   WindowDefault window = new WindowDefault();
                   ucUpdateAuthor updateAuthor = new ucUpdateAuthor(window, SelectedAuthor);
                   window.Content = updateAuthor;
                   window.ShowDialog();

                   if (window.DialogResult == true)
                   {
                       Author newAuthor = window.Tag as Author;

                       authorRepo.Update(SelectedAuthor, newAuthor);

                       DatabaseFirst.Instance.SaveChanged();

                       ReloadStorage();

                       if (Search != string.Empty)
                           SearchByText(Search);

                       ReloadDataGrid();

                       AuthorDataGrid.pagination.LoadPage();

                       MessageBox.Show($"Author update successful!", "Notify", MessageBoxButton.OK, MessageBoxImage.Information);
                   }
               }
           );
        }

        private void SetVisibilityButton(Visibility delete, Visibility restore, Visibility update)
        {
            AuthorDataGrid.dgAuthors.Columns[8].Visibility = update;
            AuthorDataGrid.dgAuthors.Columns[9].Visibility = delete;
            AuthorDataGrid.dgAuthors.Columns[10].Visibility = restore;
        }

        private void ReloadDataGridBySearch(string search)
        {
            SearchByText(search);
            ReloadDataGrid();
        }

        private void Pagination_SelectionChangedComboBoxEvent(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            AuthorDataGrid.pagination.ItemPerPage = int.Parse((AuthorDataGrid.pagination.cbPage.SelectedItem as ComboBoxItem).Content.ToString());
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

            AuthorDataGrid.pagination.CurrentPage = 1;
            AuthorDataGrid.pagination.LoadPage();

            ReloadDataGrid();
        }

        private void ReloadDataGrid()
        {
            AuthorDataGrid.dgAuthors.ItemsSource = null;
            AuthorDataGrid.dgAuthors.ItemsSource = _LstAuthor.Skip((AuthorDataGrid.pagination.CurrentPage - 1) * AuthorDataGrid.pagination.ItemPerPage).Take(AuthorDataGrid.pagination.ItemPerPage);
            AuthorDataGrid.pagination.ReloadShowing<Author>(_LstAuthor.ToList());
        }

        private void ReloadStorage()
        {
            this._StorageLstAuthor = new ObservableCollection<Author>(DatabaseFirst.Instance.db.Authors.Where(i => i.Status == !IsChecked));

            this._LstAuthor = new ObservableCollection<Author>(this._StorageLstAuthor);

            AuthorDataGrid.pagination.SetMaxPage<Author>(_LstAuthor.ToList());

            AuthorDataGrid.dgAuthors.ItemsSource = _LstAuthor.Skip((AuthorDataGrid.pagination.CurrentPage - 1) * AuthorDataGrid.pagination.ItemPerPage).Take(AuthorDataGrid.pagination.ItemPerPage);
        }

        private void SearchByText(string search)
        {
            this._LstAuthor.Clear();

            foreach (var item in this._StorageLstAuthor)
            {
                if (item.Id.ToLower().Contains(search.ToLower()))
                {
                    this._LstAuthor.Add(item);
                }
                else if (item.Name.ToLower().Contains(search.ToLower()))
                {
                    this._LstAuthor.Add(item);
                }
                else if(item.boF.ToString("dd/MM/yyyy").Contains(search)) {
                    this._LstAuthor.Add(item);
                }
                else if(item.CreatedAt.ToString("dd/MM/yyyy").Contains(search)) {
                    this._LstAuthor.Add(item);
                }
                else if(item.ModifiedAt.ToString("dd/MM/yyyy").Contains(search)) {
                    this._LstAuthor.Add(item);
                }
            }

            AuthorDataGrid.pagination.SetMaxPage<Author>(_LstAuthor.ToList());
            AuthorDataGrid.pagination.CurrentPage = 1;
            AuthorDataGrid.pagination.LoadPage();
        }
    }
}

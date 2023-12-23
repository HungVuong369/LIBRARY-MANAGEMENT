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
    public class PublisherViewModel
    {
        public string Search { get; set; } = string.Empty;

        private static readonly UnitOfWork unitOfWork = new UnitOfWork();
        public PublisherRepository PublisherRepo { get; set; }

        private ObservableCollection<Publisher> _StorageLstPublisher;
        private ObservableCollection<Publisher> _LstPublisher;

        public Publisher SelectedPublisher { get; set; }

        public ucPublisherDataGrid PublisherDataGrid { get; set; }

        public RelayCommand<object> SearchTextChangedCommand { get; private set; }

        public RelayCommand<object> AddCommand { get; private set; }

        public RelayCommand<object> DeleteCommand { get; private set; }
        public RelayCommand<object> UpdateCommand { get; private set; }
        

        public PublisherViewModel()
        {
            PublisherRepo = unitOfWork.Publishers;
        }

        public PublisherViewModel(ucPublisherDataGrid ucPublisherDataGrid)
        {
            this.PublisherDataGrid = ucPublisherDataGrid;

            PublisherRepo = unitOfWork.Publishers;

            ReloadStorage();
            PublisherDataGrid.pagination.LoadPage();

            PublisherDataGrid.pagination.ChangedPageEvent += Pagination_ChangedPageEvent;
            PublisherDataGrid.pagination.SelectionChangedComboBoxEvent += Pagination_SelectionChangedComboBoxEvent;
            PublisherDataGrid.pagination.cbPage.SelectedIndex = 1;
            PublisherDataGrid.dgPublishers.DataContext = this;

            SearchTextChangedCommand = new RelayCommand<object>(
                p => true,
                p =>
                {
                    ReloadDataGridBySearch(Search);
                }
            );

            AddCommand = new RelayCommand<object>(
                p => true,
                p =>
                {
                    WindowDefault window = new WindowDefault();
                    window.Content = new ucAddPublisher(window);
                    window.ShowDialog();

                    if (window.DialogResult == true)
                    {
                        Publisher newPublisher = window.Tag as Publisher;

                        PublisherRepo.Add(newPublisher);

                        DatabaseFirst.Instance.SaveChanged();

                        ReloadStorage();

                        if (Search != string.Empty)
                            SearchByText(Search);

                        ReloadDataGrid();

                        PublisherDataGrid.pagination.LoadPage();

                        MessageBox.Show($"Publisher '{newPublisher.Name}' added successfully!", "Notify", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
            );

            DeleteCommand = new RelayCommand<object>(
               p => true,
               p =>
               {
                   if (SelectedPublisher.Books.Count != 0)
                   {
                       MessageBox.Show($"Cannot delete publisher '{SelectedPublisher.Name}'", "Notify", MessageBoxButton.OK, MessageBoxImage.Warning);
                       return;
                   }
                   if (MessageBox.Show($"Are you sure you want to delete publisher '{SelectedPublisher.Name}'", "Notify", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                   {
                       string name = SelectedPublisher.Name;
                       PublisherRepo.Remove(SelectedPublisher);
                       DatabaseFirst.Instance.SaveChanged();

                       ReloadStorage();

                       if (PublisherDataGrid.pagination.CurrentPage > PublisherDataGrid.pagination.MaxPage)
                       {
                           PublisherDataGrid.pagination.CurrentPage -= 1;
                           ReloadDataGrid();
                           PublisherDataGrid.pagination.LoadPage();
                       }
                       else
                       {
                           ReloadDataGrid();
                           PublisherDataGrid.pagination.LoadPage();
                       }

                       if (Search != string.Empty)
                           ReloadDataGridBySearch(Search);

                       MessageBox.Show($"Publisher '{name}' successfully deleted!", "Notify", MessageBoxButton.OK, MessageBoxImage.Information);
                   }
               }
           );

            UpdateCommand = new RelayCommand<object>(
               p => true,
               p =>
               {
                   WindowDefault window = new WindowDefault();
                   ucUpdatePublisher updatePublisher = new ucUpdatePublisher(window, SelectedPublisher);
                   window.Content = updatePublisher;
                   window.ShowDialog();

                   if (window.DialogResult == true)
                   {
                       Publisher newPublisher = window.Tag as Publisher;

                       PublisherRepo.Update(SelectedPublisher, newPublisher);

                       DatabaseFirst.Instance.SaveChanged();

                       ReloadStorage();

                       if (Search != string.Empty)
                           SearchByText(Search);

                       ReloadDataGrid();

                       PublisherDataGrid.pagination.LoadPage();

                       MessageBox.Show($"Publisher update successful!", "Notify", MessageBoxButton.OK, MessageBoxImage.Information);
                   }
               }
           );
        }

        private void ReloadDataGridBySearch(string search)
        {
            SearchByText(search);
            ReloadDataGrid();
        }

        private void Pagination_SelectionChangedComboBoxEvent(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            PublisherDataGrid.pagination.ItemPerPage = int.Parse((PublisherDataGrid.pagination.cbPage.SelectedItem as ComboBoxItem).Content.ToString());
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

            PublisherDataGrid.pagination.CurrentPage = 1;
            PublisherDataGrid.pagination.LoadPage();

            ReloadDataGrid();
        }

        private void ReloadDataGrid()
        {
            PublisherDataGrid.dgPublishers.ItemsSource = null;
            PublisherDataGrid.dgPublishers.ItemsSource = _LstPublisher.Skip((PublisherDataGrid.pagination.CurrentPage - 1) * PublisherDataGrid.pagination.ItemPerPage).Take(PublisherDataGrid.pagination.ItemPerPage);
            PublisherDataGrid.pagination.ReloadShowing<Publisher>(_LstPublisher.ToList());
        }

        private void ReloadStorage()
        {
            this._StorageLstPublisher = new ObservableCollection<Publisher>(DatabaseFirst.Instance.db.Publishers);

            this._LstPublisher = new ObservableCollection<Publisher>(this._StorageLstPublisher);

            PublisherDataGrid.pagination.SetMaxPage<Publisher>(_LstPublisher.ToList());

            PublisherDataGrid.dgPublishers.ItemsSource = _LstPublisher.Skip((PublisherDataGrid.pagination.CurrentPage - 1) * PublisherDataGrid.pagination.ItemPerPage).Take(PublisherDataGrid.pagination.ItemPerPage);
        }

        private void SearchByText(string search)
        {
            this._LstPublisher.Clear();

            foreach (var item in this._StorageLstPublisher)
            {
                if (item.Id.ToLower().Contains(search.ToLower()))
                {
                    this._LstPublisher.Add(item);
                }
                else if (item.Name.ToLower().Contains(search.ToLower()))
                {
                    this._LstPublisher.Add(item);
                }
                else if(item.Address.ToLower().Contains(search.ToLower()))
                    this._LstPublisher.Add(item);
                else if(item.Phone.Contains(search))
                    this._LstPublisher.Add(item);
            }

            PublisherDataGrid.pagination.SetMaxPage<Publisher>(_LstPublisher.ToList());
            PublisherDataGrid.pagination.CurrentPage = 1;
            PublisherDataGrid.pagination.LoadPage();
        }
    }
}

using System;
using System.Collections.Generic;
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
    /// Interaction logic for ReaderManagement.xaml
    /// </summary>
    public partial class ReaderManagement : UserControl
    {
        private ReaderManagementRepository _ReaderManagementRepo = new ReaderManagementRepository();
        private ReaderViewModel _ReaderVM = new ReaderViewModel();
        private AdultViewModel _AdultVM = new AdultViewModel();
        private ChildViewModel _ChildVM = new ChildViewModel();

        public ReaderManagement()
        {
            InitializeComponent();
            ucReader.pagination.ChangedPageEvent += Pagination_ChangedPageEvent;
            ucReader.pagination.SelectionChangedComboBoxEvent += Pagination_SelectionChangedComboBoxEvent;
            ucReader.pagination.cbPage.SelectedIndex = 1;
            ucReader.deleteEvent += UcReader_deleteEvent;
            ucReader.restoreEvent += UcReader_restoreEvent;
        }

        private void ReloadRestored()
        {
            ucReader.ReloadStorage();
            if (ucReader.pagination.CurrentPage > ucReader.pagination.MaxPage)
            {
                for (; ucReader.pagination.CurrentPage > ucReader.pagination.MaxPage; ucReader.pagination.CurrentPage--) { }

                ucReader.ReloadDataGrid();
                ucReader.pagination.LoadPage();
            }
            else
            {
                ucReader.ReloadDataGrid();
                ucReader.pagination.LoadPage();
            }

            if (txtSearch.Text != string.Empty)
            {
                ucReader.Search(txtSearch.Text);
                ucReader.ReloadDataGrid();
                ucReader.pagination.LoadPage();
            }
        }

        private void UcReader_restoreEvent(object sender, RoutedEventArgs e)
        {
            AdultReader adultReader = (sender as Button).Tag as AdultReader;
            _ReaderManagementRepo.RestoreReader(adultReader.Id);
            ReloadRestored();
        }

        private void UcReader_deleteEvent(object sender, RoutedEventArgs e)
        {
            AdultReader adultReader = (sender as Button).Tag as AdultReader;

            if (MessageBox.Show("Are you sure you want to delete?", "Notify", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                _ReaderManagementRepo.DeleteReader(adultReader.Id);

                ucReader.ReloadStorage();
                if (ucReader.pagination.CurrentPage > ucReader.pagination.MaxPage)
                {
                    ucReader.pagination.CurrentPage -= 1;
                    ucReader.ReloadDataGrid();
                    ucReader.pagination.LoadPage();
                }
                else
                {
                    ucReader.ReloadDataGrid();
                    ucReader.pagination.LoadPage();
                }

                if (txtSearch.Text != string.Empty)
                    ReloadDataGridBySearch(txtSearch.Text);
            }
        }

        private void ReloadDataGrid()
        {
            ucReader.ReloadStorage();
            txtSearch.Text = "";

            ucReader.pagination.CurrentPage = 1;
            ucReader.pagination.LoadPage();

            ucReader.ReloadDataGrid();
        }

        private void Pagination_SelectionChangedComboBoxEvent(object sender, SelectionChangedEventArgs e)
        {
            ucReader.pagination.ItemPerPage = int.Parse((ucReader.pagination.cbPage.SelectedItem as ComboBoxItem).Content.ToString());
            ReloadDataGrid();
        }

        private void Pagination_ChangedPageEvent(Pagination pagination)
        {
            ucReader.ReloadDataGrid();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            WindowDefault window = new WindowDefault();
            window.SizeToContent = SizeToContent.Height;

            window.grdContainer.Children.Add(new ucAddReader(window));
            window.ShowDialog();

            if(window.DialogResult == true)
            {
                ucReader.ReloadStorage();

                if (txtSearch.Text != string.Empty)
                    ucReader.Search(txtSearch.Text);

                ucReader.ReloadDataGrid();

                ucReader.pagination.LoadPage();
            }
        }

        private void btnTransitioningChild_Click(object sender, RoutedEventArgs e)
        {
            WindowDefault window = new WindowDefault();
            window.grdContainer.Children.Add(new ucTransitioningChild());
            window.ShowDialog();
        }

        private void ReloadDataGridBySearch(string search)
        {
            ucReader.Search(search);
            ucReader.ReloadDataGrid();
        }

        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            ReloadDataGridBySearch((sender as TextBox).Text);
        }

        private void toggleButton_Checked(object sender, RoutedEventArgs e)
        {
            _ReaderVM.readerRepo.Load(false);
            _AdultVM.adultRepo.Load(false);
            _ChildVM.childRepo.Load(false);
            ReloadDataGrid();
            ucReader.SetVisibilityButton(Visibility.Collapsed, Visibility.Visible, Visibility.Collapsed);
        }

        private void toggleButton_Unchecked(object sender, RoutedEventArgs e)
        {
            _ReaderVM.readerRepo.Load(true);
            _AdultVM.adultRepo.Load(true);
            _ChildVM.childRepo.Load(true);
            ReloadDataGrid();
            ucReader.SetVisibilityButton(Visibility.Visible, Visibility.Collapsed, Visibility.Visible);
        }
    }
}

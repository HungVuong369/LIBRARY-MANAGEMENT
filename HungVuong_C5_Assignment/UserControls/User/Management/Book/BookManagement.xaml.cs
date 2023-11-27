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
    /// Interaction logic for BookManagement.xaml
    /// </summary>
    public partial class BookManagement : UserControl
    {
        private BookManagementRepository _BookManagementRepo = new BookManagementRepository();

        public BookManagement()
        {
            InitializeComponent();
            ucBook.pagination.ChangedPageEvent += Pagination_ChangedPageEvent;
            ucBook.pagination.SelectionChangedComboBoxEvent += Pagination_SelectionChangedComboBoxEvent;
            ucBook.pagination.cbPage.SelectedIndex = 1;

            Loaded += BookManagement_Loaded;
        }

        private void BookManagement_Loaded(object sender, RoutedEventArgs e)
        {
            lbTabMenu.SelectedIndex = 0;
        }

        private void ReloadDataGrid()
        {
            if (toggleButton.IsChecked == true)
                ucBook.ReloadStorageAll();
            else
                ucBook.ReloadStorageInfo();
            txtSearch.Text = "";

            ucBook.pagination.CurrentPage = 1;
            ucBook.pagination.LoadPage();

            ucBook.ReloadDataGrid();
        }
        private void Pagination_SelectionChangedComboBoxEvent(object sender, SelectionChangedEventArgs e)
        {
            ucBook.pagination.ItemPerPage = int.Parse((ucBook.pagination.cbPage.SelectedItem as ComboBoxItem).Content.ToString());
            ReloadDataGrid();
        }

        private void Pagination_ChangedPageEvent(Pagination pagination)
        {
            ucBook.ReloadDataGrid();
        }

        private void ReloadDataGridBySearch(string search)
        {
            ucBook.Search(search);
            ucBook.ReloadDataGrid();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            WindowDefault window = new WindowDefault();
            window.Content = new ucAddBook(window);
            window.SizeToContent = SizeToContent.Manual;
            window.Height = 500;
            window.Width = 650;
            window.ShowDialog();

            if (window.DialogResult == true)
            {
                if (toggleButton.IsChecked == true)
                    ucBook.ReloadStorageAll();
                else
                    ucBook.ReloadStorageInfo();

                if (txtSearch.Text != string.Empty)
                    ucBook.Search(txtSearch.Text);

                ucBook.ReloadDataGrid();

                ucBook.pagination.LoadPage();

                ucLoanSlips.ReloadDataGrid();

                ucEnroll.ReloadDataGrid();
            }
        }

        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            ReloadDataGridBySearch((sender as TextBox).Text);
        }

        private void toggleButton_Unchecked(object sender, RoutedEventArgs e)
        {
            ucBook.ReloadStorageInfo();
            ReloadDataGrid();
            ucBook.dgBookInfo.Columns[7].Visibility = Visibility.Visible;
            ucBook.dgBookInfo.Columns[8].Visibility = Visibility.Collapsed;
        }

        private void toggleButton_Checked(object sender, RoutedEventArgs e)
        {
            ucBook.ReloadStorageAll();
            ReloadDataGrid();
            ucBook.dgBookInfo.Columns[7].Visibility = Visibility.Collapsed;
            ucBook.dgBookInfo.Columns[8].Visibility = Visibility.Visible;

        }

        private void btnBorrowingBook_Click(object sender, RoutedEventArgs e)
        {
            WindowDefault window = new WindowDefault();
            window.Content = new ucBorrowingBook(window);
            window.ShowDialog();

            if (window.DialogResult == true)
            {
                if (toggleButton.IsChecked == true)
                    ucBook.ReloadStorageAll();
                else
                    ucBook.ReloadStorageInfo();

                if (txtSearch.Text != string.Empty)
                    ucBook.Search(txtSearch.Text);

                ucBook.ReloadDataGrid();

                ucBook.pagination.LoadPage();

                ucLoanSlips.ReloadDataGrid();

                ucEnroll.ReloadDataGrid();
            }
        }

        private void lbTabMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string tab = (lbTabMenu.SelectedValue as ListBoxItem).Content.ToString();

            switch (tab)
            {
                case "Management":
                    ucLoanSlips.Visibility = Visibility.Collapsed;
                    ucEnroll.Visibility = Visibility.Collapsed;
                    grdTabMenuBookManagement.Visibility = Visibility.Visible;
                    ucBook.Visibility = Visibility.Visible;
                    break;
                case "View Loan Slips":
                    ucLoanSlips.Visibility = Visibility.Visible;
                    ucEnroll.Visibility = Visibility.Collapsed;
                    grdTabMenuBookManagement.Visibility = Visibility.Collapsed;
                    ucBook.Visibility = Visibility.Collapsed;
                    break;
                case "View Enrolls":
                    ucLoanSlips.Visibility = Visibility.Collapsed;
                    ucEnroll.Visibility = Visibility.Visible;
                    grdTabMenuBookManagement.Visibility = Visibility.Collapsed;
                    ucBook.Visibility = Visibility.Collapsed;
                    break;
            }
        }
    }
}

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
    /// Interaction logic for LoanHistoryManagement.xaml
    /// </summary>
    public partial class LoanHistoryManagement : UserControl
    {
        public LoanHistoryManagement()
        {
            InitializeComponent();
            Loaded += LoanHistoryManagement_Loaded;
            ucLoanHistory.pagination.ChangedPageEvent += Pagination_ChangedPageEvent;
            ucLoanHistory.pagination.SelectionChangedComboBoxEvent += Pagination_SelectionChangedComboBoxEvent;
            ucLoanHistory.pagination.cbPage.SelectedIndex = 1;
        }

        private void ReloadDataGrid()
        {
            ucLoanHistory.ReloadStorage();
            txtSearch.Text = "";

            ucLoanHistory.pagination.CurrentPage = 1;
            ucLoanHistory.pagination.LoadPage();

            ucLoanHistory.ReloadDataGrid();
        }

        private void Pagination_SelectionChangedComboBoxEvent(object sender, SelectionChangedEventArgs e)
        {
            ucLoanHistory.pagination.ItemPerPage = int.Parse((ucLoanHistory.pagination.cbPage.SelectedItem as ComboBoxItem).Content.ToString());
            ReloadDataGrid();
        }

        private void Pagination_ChangedPageEvent(Pagination pagination)
        {
            ucLoanHistory.ReloadDataGrid();
        }

        private void LoanHistoryManagement_Loaded(object sender, RoutedEventArgs e)
        {
            lbTabMenu.SelectedIndex = 0;
        }

        private void lbTabMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string tab = (lbTabMenu.SelectedValue as ListBoxItem).Content.ToString();

            switch (tab)
            {
                case "View":
                    ReloadDataGrid();
                    ucLoanHistory.Visibility = Visibility.Visible;
                    ucReturnBook.Visibility = Visibility.Collapsed;
                    break;
                case "Add Loan History":
                    ucLoanHistory.Visibility = Visibility.Collapsed;
                    ucReturnBook.Visibility = Visibility.Visible;
                    break;
            }
        }

        private void ReloadDataGridBySearch(string search)
        {
            ucLoanHistory.Search(search);
            ucLoanHistory.ReloadDataGrid();
        }

        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            ReloadDataGridBySearch(txtSearch.Text);
        }
    }
}

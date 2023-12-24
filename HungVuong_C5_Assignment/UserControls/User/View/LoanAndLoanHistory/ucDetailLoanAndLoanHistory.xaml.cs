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
    /// Interaction logic for ucDetailLoanAndLoanHistory.xaml
    /// </summary>
    public partial class ucDetailLoanAndLoanHistory : UserControl
    {
        private Reader Reader;

        public ucDetailLoanAndLoanHistory(Reader reader)
        {
            InitializeComponent();
            this.Reader = reader;

            DataContext = reader;

            ucLoanSlip.ReloadStorageByReaderID(reader.Id);
            ucLoanSlip.pagination.ChangedPageEvent += Pagination_ChangedPageEvent;
            ucLoanSlip.pagination.SelectionChangedComboBoxEvent += Pagination_SelectionChangedComboBoxEvent;
            ucLoanSlip.pagination.cbPage.SelectedIndex = 1;
            ucLoanSlip.pagination.HideButton();

            ucLoanHistory.ReloadStorageByReaderID(reader.Id);
            ucLoanHistory.pagination.ChangedPageEvent += Pagination_ChangedPageEvent;
            ucLoanHistory.pagination.SelectionChangedComboBoxEvent += Pagination_SelectionChangedComboBoxEvent;
            ucLoanHistory.pagination.cbPage.SelectedIndex = 1;
            ucLoanHistory.pagination.HideButton();

            ucLoanDetails.UpdateDataGridByReaderID(Reader.Id);
            ucLoanDetailHistories.UpdateDataGridByReaderID(Reader.Id);

            Loaded += UcDetailLoanAndLoanHistory_Loaded;
        }

        private void Pagination_SelectionChangedComboBoxEvent(object sender, SelectionChangedEventArgs e)
        {
            ucLoanSlip.pagination.ItemPerPage = int.Parse((ucLoanSlip.pagination.cbPage.SelectedItem as ComboBoxItem).Content.ToString());

            ucLoanSlip.pagination.CurrentPage = 1;

            ucLoanSlip.pagination.LoadPage();

            ucLoanSlip.ReloadDataGrid();

            try
            {
                ucLoanHistory.pagination.ItemPerPage = int.Parse((ucLoanHistory.pagination.cbPage.SelectedItem as ComboBoxItem).Content.ToString());

                ucLoanHistory.pagination.CurrentPage = 1;

                ucLoanHistory.pagination.LoadPage();

                ucLoanHistory.ReloadDataGrid();
            }
            catch
            {

            }
        }

        private void Pagination_ChangedPageEvent(Pagination pagination)
        {
            if (ucLoanSlip.Visibility == Visibility.Visible)
            {
                ucLoanSlip.ReloadDataGrid();
            }
            else
            {
                ucLoanHistory.ReloadDataGrid();
            }
        }

        private void UcDetailLoanAndLoanHistory_Loaded(object sender, RoutedEventArgs e)
        {
            lbTabMenu.SelectedIndex = 0;
        }

        private void lbTabMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string tab = (lbTabMenu.SelectedValue as ListBoxItem).Content.ToString();

            toggleButton.IsChecked = false;
            txtSearch.Text = string.Empty;

            switch (tab)
            {
                case "Loan":
                    ucLoanSlip.Visibility = Visibility.Visible;
                    ucLoanHistory.Visibility = Visibility.Collapsed;
                    break;
                case "Loan History":
                    ucLoanSlip.Visibility = Visibility.Collapsed;
                    ucLoanHistory.Visibility = Visibility.Visible;
                    break;
            }
        }

        private void ReloadDataGridBySearch(string search)
        {
            if(ucLoanSlip.Visibility == Visibility.Visible)
            {
                ucLoanSlip.Search(search);
                ucLoanSlip.ReloadDataGrid();
            }
            else if(ucLoanHistory.Visibility == Visibility.Visible)
            {
                ucLoanHistory.Search(search);
                ucLoanHistory.ReloadDataGrid();
            }
        }

        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            ReloadDataGridBySearch(txtSearch.Text);
        }

        private void toggleButton_Checked(object sender, RoutedEventArgs e)
        {
            txtSearch.Opacity = 0.6;
            txtSearch.IsReadOnly = true;

            if (ucLoanSlip.Visibility == Visibility.Visible)
            {
                ucLoanSlip.Visibility = Visibility.Collapsed;
                ucLoanDetails.Visibility = Visibility.Visible;
            }
            else if(ucLoanHistory.Visibility == Visibility.Visible)
            {
                ucLoanHistory.Visibility = Visibility.Collapsed;
                ucLoanDetailHistories.Visibility = Visibility.Visible;
            }
        }

        private void toggleButton_Unchecked(object sender, RoutedEventArgs e)
        {
            txtSearch.Opacity = 1;
            txtSearch.IsReadOnly = false;

            if (ucLoanDetails.Visibility == Visibility.Visible)
            {
                ucLoanSlip.Visibility = Visibility.Visible;
                ucLoanDetails.Visibility = Visibility.Collapsed;
            }
            else if (ucLoanDetailHistories.Visibility == Visibility.Visible)
            {
                ucLoanHistory.Visibility = Visibility.Visible;
                ucLoanDetailHistories.Visibility = Visibility.Collapsed;
            }
        }
    }
}

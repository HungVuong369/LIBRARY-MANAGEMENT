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
    /// Interaction logic for ucLoanSlipManagement.xaml
    /// </summary>
    public partial class ucLoanSlipManagement : UserControl
    {
        public ucLoanSlipManagement()
        {
            InitializeComponent();

            Loaded += UcLoanSlipManagement_Loaded;
            ucLoanSlip.pagination.ChangedPageEvent += Pagination_ChangedPageEvent;
            ucLoanSlip.pagination.SelectionChangedComboBoxEvent += Pagination_SelectionChangedComboBoxEvent;
            ucLoanSlip.pagination.cbPage.SelectedIndex = 1;
        }

        private void ReloadDataGrid()
        {
            ucLoanSlip.ReloadStorage();
            txtSearch.Text = "";

            ucLoanSlip.pagination.CurrentPage = 1;
            ucLoanSlip.pagination.LoadPage();

            ucLoanSlip.ReloadDataGrid();
        }

        private void Pagination_SelectionChangedComboBoxEvent(object sender, SelectionChangedEventArgs e)
        {
            ucLoanSlip.pagination.ItemPerPage = int.Parse((ucLoanSlip.pagination.cbPage.SelectedItem as ComboBoxItem).Content.ToString());
            ReloadDataGrid();
        }

        private void Pagination_ChangedPageEvent(Pagination pagination)
        {
            ucLoanSlip.ReloadDataGrid();
        }

        private void UcLoanSlipManagement_Loaded(object sender, RoutedEventArgs e)
        {
            lbTabMenu.SelectedIndex = 0;
        }

        private void ReloadDataGridBySearch(string search)
        {
            ucLoanSlip.Search(search);
            ucLoanSlip.ReloadDataGrid();
        }

        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            ReloadDataGridBySearch(txtSearch.Text);
        }

        private void lbTabMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string tab = (lbTabMenu.SelectedValue as ListBoxItem).Content.ToString();

            switch (tab)
            {
                case "View":
                    ReloadDataGrid();

                    grdContainView.Visibility = Visibility.Visible;
                    ucBorrowing.Visibility = Visibility.Collapsed;
                    break;
                case "Add Loan Slip":
                    grdContainView.Visibility = Visibility.Collapsed;
                    ucBorrowing.Visibility = Visibility.Visible;
                    break;
            }
        }
    }
}

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
    /// Interaction logic for BookISBN_Management.xaml
    /// </summary>
    public partial class BookISBN_Management : UserControl
    {
        public BookISBN_Management()
        {
            InitializeComponent();
            ucBookISBN.pagination.ChangedPageEvent += Pagination_ChangedPageEvent;
            ucBookISBN.pagination.SelectionChangedComboBoxEvent += Pagination_SelectionChangedComboBoxEvent;
            ucBookISBN.pagination.cbPage.SelectedIndex = 1;
        }

        private void ReloadDataGrid()
        {
            ucBookISBN.ReloadStorage();
            txtSearch.Text = "";

            ucBookISBN.pagination.CurrentPage = 1;
            ucBookISBN.pagination.LoadPage();

            ucBookISBN.ReloadDataGrid();
        }

        private void Pagination_SelectionChangedComboBoxEvent(object sender, SelectionChangedEventArgs e)
        {
            ucBookISBN.pagination.ItemPerPage = int.Parse((ucBookISBN.pagination.cbPage.SelectedItem as ComboBoxItem).Content.ToString());
            ReloadDataGrid();
        }

        private void Pagination_ChangedPageEvent(Pagination pagination)
        {
            ucBookISBN.ReloadDataGrid();
        }

        private void ReloadDataGridBySearch(string search)
        {
            ucBookISBN.Search(search);
            ucBookISBN.ReloadDataGrid();
        }

        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            ReloadDataGridBySearch((sender as TextBox).Text);
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            WindowDefault window = new WindowDefault();
            window.Content = new ucAddBookISBN(window);
            window.ShowDialog();

            if(window.DialogResult == true)
            {
                ucBookISBN.ReloadStorage();

                if (txtSearch.Text != string.Empty)
                    ucBookISBN.Search(txtSearch.Text);

                ucBookISBN.ReloadDataGrid();

                ucBookISBN.pagination.LoadPage();
            }
        }
    }
}

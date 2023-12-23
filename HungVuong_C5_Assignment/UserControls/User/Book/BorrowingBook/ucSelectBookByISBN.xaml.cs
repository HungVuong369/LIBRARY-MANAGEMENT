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
    /// Interaction logic for ucSelectBookByISBN.xaml
    /// </summary>
    public partial class ucSelectBookByISBN : UserControl
    {
        private string ISBN;

        private WindowDefault _Parent;

        public ucSelectBookByISBN(WindowDefault window, string isbn)
        {
            InitializeComponent();
            _Parent = window;

            this.ISBN = isbn;

            ucBook.dgBookInfo.Columns[9].Visibility = Visibility.Collapsed;
            ucBook.dgBookInfo.Columns[0].Visibility = Visibility.Visible;
            ucBook.dgBookInfo.Columns[1].Visibility = Visibility.Collapsed;

            ucBook.pagination.ChangedPageEvent += Pagination_ChangedPageEvent;
            ucBook.pagination.SelectionChangedComboBoxEvent += Pagination_SelectionChangedComboBoxEvent;
            ucBook.dgBookInfo.SelectionChanged += DgBookInfo_SelectionChanged;
            ucBook.ReloadStorageAllByISBN(isbn);

            ucBook.pagination.cbPage.SelectedIndex = 0;

            ucBook.pagination.HideButton();
        }

        private void DgBookInfo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btnConfirm.IsEnabled = true;
        }

        private void ReloadDataGrid()
        {
            ucBook.ReloadStorageAllByISBN(ISBN);
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
            btnConfirm.IsEnabled = false;
        }

        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            ucBook.Search(txtSearch.Text);
            ucBook.ReloadDataGrid();
            btnConfirm.IsEnabled = false;
        }

        private void btnConfirm_Click(object sender, RoutedEventArgs e)
        {
            _Parent.DialogResult = true;
            _Parent.Tag = (ucBook.dgBookInfo.SelectedItem as BookInformation);
            _Parent.Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            _Parent.DialogResult = false;
            _Parent.Tag = null;
            _Parent.Close();
        }
    }
}

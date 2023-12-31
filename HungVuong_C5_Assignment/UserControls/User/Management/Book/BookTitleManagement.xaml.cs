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
    /// Interaction logic for BookTitleManagement.xaml
    /// </summary>
    public partial class BookTitleManagement : UserControl
    {
        public BookTitleManagement()
        {
            InitializeComponent();
            ucBookTitle.pagination.ChangedPageEvent += Pagination_ChangedPageEvent;
            ucBookTitle.pagination.SelectionChangedComboBoxEvent += Pagination_SelectionChangedComboBoxEvent;
            ucBookTitle.pagination.cbPage.SelectedIndex = 1;
        }

        private void ReloadDataGrid()
        {
            ucBookTitle.ReloadStorage();
            txtSearch.Text = "";

            ucBookTitle.pagination.CurrentPage = 1;
            ucBookTitle.pagination.LoadPage();

            ucBookTitle.ReloadDataGrid();
        }

        private void Pagination_SelectionChangedComboBoxEvent(object sender, SelectionChangedEventArgs e)
        {
            ucBookTitle.pagination.ItemPerPage = int.Parse((ucBookTitle.pagination.cbPage.SelectedItem as ComboBoxItem).Content.ToString());
            ReloadDataGrid();
        }

        private void Pagination_ChangedPageEvent(Pagination pagination)
        {
            ucBookTitle.ReloadDataGrid();
        }

        private void ReloadDataGridBySearch(string search)
        {
            ucBookTitle.Search(search);
            ucBookTitle.ReloadDataGrid();
        }

        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            ReloadDataGridBySearch((sender as TextBox).Text);
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            WindowDefault window = new WindowDefault();
            window.grdContainer.Children.Add(new ucAddBookTitle(window));
            window.ShowDialog();

            if(window.DialogResult == true)
            {
                ucBookTitle.ReloadStorage();

                if (txtSearch.Text != string.Empty)
                    ucBookTitle.Search(txtSearch.Text);

                ucBookTitle.ReloadDataGrid();

                ucBookTitle.pagination.LoadPage();
            }
        }
    }
}

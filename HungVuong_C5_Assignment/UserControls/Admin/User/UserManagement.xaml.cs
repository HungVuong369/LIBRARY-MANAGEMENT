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
    /// Interaction logic for UserManagement.xaml
    /// </summary>
    public partial class UserManagement : UserControl
    {
        private FunctionViewModel _FunctionVM = new FunctionViewModel();

        private UserManagementRepository _UserManagementRepo = new UserManagementRepository();

        public UserManagement()
        {
            InitializeComponent();
            ucUserDataGrid.pagination.ChangedPageEvent += Pagination_ChangedPageEvent1;
            ucUserDataGrid.pagination.SelectionChangedComboBoxEvent += Pagination_SelectionChangedComboBoxEvent;

            ucUserDataGrid.deleteEvent += UcUserDataGrid_deleteEvent;
            ucUserDataGrid.updateEvent += UcUserDataGrid_updateEvent;
            ucUserDataGrid.dgUser.SelectionMode = DataGridSelectionMode.Extended;
            ucUserDataGrid.selectionChangedEvent += UcUserDataGrid_selectionChangedEvent;

            ucUserDataGrid.pagination.cbPage.SelectedIndex = 1;
        }

        private void Pagination_SelectionChangedComboBoxEvent(object sender, SelectionChangedEventArgs e)
        {
            ucUserDataGrid.pagination.ItemPerPage = int.Parse((ucUserDataGrid.pagination.cbPage.SelectedItem as ComboBoxItem).Content.ToString());
            ReloadDataGrid();
        }

        private void UcUserDataGrid_selectionChangedEvent(object sender, RoutedEventArgs e)
        {
            if(ucUserDataGrid.dgUser.SelectedItems.Count >= 2)
            {
                if(ucUserDataGrid.dgUser.SelectedItems.Cast<User>().FirstOrDefault(i => i.Id == "U1") == null)
                    btnDeleteAll.Visibility = Visibility.Visible;
                else
                    btnDeleteAll.Visibility = Visibility.Collapsed;
            }
            else
            {
                btnDeleteAll.Visibility = Visibility.Collapsed;
            }
        }

        private void Pagination_ChangedPageEvent1(Pagination pagination)
        {
            ucUserDataGrid.ReloadDataGrid();
        }

        private void ReloadDataGrid()
        {
            ucUserDataGrid.ReloadStorage();
            txtSearch.Text = "";

            ucUserDataGrid.pagination.CurrentPage = 1;
            ucUserDataGrid.pagination.LoadPage();

            ucUserDataGrid.ReloadDataGrid();
        }

        private void UcUserDataGrid_updateEvent(object sender, RoutedEventArgs e)
        {
            User user = (sender as Button).Tag as User;

            WindowDefault window = new WindowDefault();

            window.grdContainer.Children.Add(new ucUpdateUserView(window, user));

            window.ShowDialog();

            if (window.DialogResult == true)
            {
                ucUserDataGrid.ReloadStorage();
                ucUserDataGrid.ReloadDataGrid();
                ucUserDataGrid.pagination.LoadPage();

                if(txtSearch.Text != string.Empty)
                    ReloadDataGridByText();

                MessageBox.Show("Updated Successfully!", "Notify", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void UcUserDataGrid_deleteEvent(object sender, RoutedEventArgs e)
        {
            User user = (sender as Button).Tag as User;

            if (MessageBox.Show($"Are you sure you want to delete user: {user.Username}", "Notify", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                _UserManagementRepo.DeleteUser(user.Id);

                ucUserDataGrid.ReloadStorage();
                if (ucUserDataGrid.pagination.CurrentPage > ucUserDataGrid.pagination.MaxPage)
                {
                    ucUserDataGrid.pagination.CurrentPage -= 1;
                    ucUserDataGrid.ReloadDataGrid();
                    ucUserDataGrid.pagination.LoadPage();
                }
                else
                {
                    ucUserDataGrid.ReloadDataGrid();
                    ucUserDataGrid.pagination.LoadPage();
                }

                if(txtSearch.Text != string.Empty)
                    ReloadDataGridByText();

                MessageBox.Show("Deleted Successfully!", "Notify", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            WindowDefault window = new WindowDefault();
            ucAddUser addUser = new ucAddUser(window);
            window.grdContainer.Children.Add(addUser);
            window.ShowDialog();
            
            ucUserDataGrid.ReloadStorage();

            if(txtSearch.Text != string.Empty)
                ucUserDataGrid.Search(txtSearch.Text);

            ucUserDataGrid.ReloadDataGrid();

            ucUserDataGrid.pagination.LoadPage();
        }

        private void ReloadDataGridByText()
        {
            ucUserDataGrid.Search(txtSearch.Text);
            ucUserDataGrid.ReloadDataGrid();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            ReloadDataGridByText();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ucUserDataGrid.pagination.ItemPerPage = int.Parse((ucUserDataGrid.pagination.cbPage.SelectedItem as ComboBoxItem).Content.ToString());

            ReloadDataGrid();
        }

        private void btnDeleteAll_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show($"Are you sure you want to delete all the selected users?", "Notify", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                foreach(User user in ucUserDataGrid.dgUser.SelectedItems)
                {
                    if (user.Id == "U1")
                    {
                        continue;
                    }
                    _UserManagementRepo.DeleteUser(user.Id);
                }
               
                ucUserDataGrid.ReloadStorage();
                if (ucUserDataGrid.pagination.CurrentPage > ucUserDataGrid.pagination.MaxPage)
                {
                    ucUserDataGrid.pagination.CurrentPage -= 1;
                    ucUserDataGrid.ReloadDataGrid();
                    ucUserDataGrid.pagination.LoadPage();
                }
                else
                {
                    ucUserDataGrid.ReloadDataGrid();
                    ucUserDataGrid.pagination.LoadPage();
                }

                if (txtSearch.Text != string.Empty)
                    ReloadDataGridByText();

                MessageBox.Show("Deleted Successfully!", "Notify", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}

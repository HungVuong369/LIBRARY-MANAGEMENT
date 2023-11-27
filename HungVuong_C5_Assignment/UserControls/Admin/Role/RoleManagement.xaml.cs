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
    /// Interaction logic for RoleManagement.xaml
    /// </summary>
    public partial class RoleManagement : UserControl
    {
        private UserInfoViewModel _UserInfoVM = new UserInfoViewModel();
        private UserRoleViewModel _UserRoleVM = new UserRoleViewModel();
        private RoleViewModel _RoleVM = new RoleViewModel();
        private RoleManagementRepository _RoleManagementRepo = new RoleManagementRepository();
        private TreeViewItem _TreeViewItem = null;

        public RoleManagement()
        {
            InitializeComponent();
            ucUserRoleDataGrid.pagination.ChangedPageEvent += Pagination_ChangedPageEvent;
            ucUserRoleDataGrid.pagination.SelectionChangedComboBoxEvent += Pagination_SelectionChangedComboBoxEvent;

            ucUserRoleDataGrid.userAssignmentEvent += UcUserRoleDataGrid_userAssignmentEvent;

            ucUserRoleDataGrid.pagination.cbPage.SelectedIndex = 1;
        }

        private void Pagination_SelectionChangedComboBoxEvent(object sender, SelectionChangedEventArgs e)
        {
            ucUserRoleDataGrid.pagination.ItemPerPage = int.Parse((ucUserRoleDataGrid.pagination.cbPage.SelectedItem as ComboBoxItem).Content.ToString());
            ReloadDataGrid(toggleButton.IsChecked.ToString() == "True" ? false : true);
        }

        private void ReloadDataGrid(bool isModify)
        {
            ucUserRoleDataGrid.ReloadStorage(isModify);
            txtSearch.Text = "";

            ucUserRoleDataGrid.pagination.CurrentPage = 1;
            ucUserRoleDataGrid.pagination.LoadPage();

            ucUserRoleDataGrid.ReloadDataGrid();
        }

        private void UcUserRoleDataGrid_userAssignmentEvent(object sender, RoutedEventArgs e)
        {
            var userRoleDto = (sender as Button).Tag as UserRoleDto;
            UserInfo userInfo = this._UserInfoVM.UserInfoRepo.GetByID(userRoleDto.Id);

            WindowDefault window = new WindowDefault();

            ucUserAssignmentView userAssignmentView = new ucUserAssignmentView(window, new User() { Id = userRoleDto.Id, Username = userRoleDto.Username, Password = userRoleDto.Password, Status = userRoleDto.Status, CreatedAt = userRoleDto.CreatedAt, ModifiedAt = userRoleDto.ModifiedAt }, userInfo);
            window.Content = userAssignmentView;

            window.ShowDialog();

            if (window.DialogResult == true)
            {
                if (userAssignmentView.defaultIndex == -1)
                {
                    Role role = window.Tag as Role;
                    _RoleManagementRepo.UserAssignment(userRoleDto.Id, role.Id);
                    MessageBox.Show("User Assignment successfully!", "Notify", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    Role role = window.Tag as Role;
                    UserRole userRole = _UserRoleVM.userRoleRepo.GetByIdUser(userRoleDto.Id);
                    Role roleOld = _RoleVM.roleRepo.Items.FirstOrDefault(i => i.Id == userRole.IdRole);

                    _RoleManagementRepo.UpdateUserAssignment(userRoleDto.Id, roleOld.Id, role.Id);
                    MessageBox.Show("Modify user role successfully!", "Notify", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                if (toggleButton.IsChecked == true)
                {
                    ucUserRoleDataGrid.ReloadStorage(false);
                    if (ucUserRoleDataGrid.pagination.CurrentPage > ucUserRoleDataGrid.pagination.MaxPage)
                    {
                        ucUserRoleDataGrid.pagination.CurrentPage -= 1;
                        ucUserRoleDataGrid.ReloadDataGrid();
                        ucUserRoleDataGrid.pagination.LoadPage();
                    }
                    else
                    {
                        ucUserRoleDataGrid.ReloadDataGrid();
                        ucUserRoleDataGrid.pagination.LoadPage();
                    }
                }
                else
                {
                    ucUserRoleDataGrid.ReloadStorage(true);
                    ucUserRoleDataGrid.ReloadDataGrid();
                    ucUserRoleDataGrid.pagination.LoadPage();
                }

                if (txtSearch.Text != string.Empty)
                {
                    ucUserRoleDataGrid.Search(txtSearch.Text);
                    ucUserRoleDataGrid.ReloadDataGrid();
                }
            }
        }

        private void Pagination_ChangedPageEvent(Pagination pagination)
        {
            ucUserRoleDataGrid.ReloadDataGrid();
        }

        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            ucUserRoleDataGrid.Search((sender as TextBox).Text);
            ucUserRoleDataGrid.ReloadDataGrid();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            WindowDefault window = new WindowDefault();
            window.SizeToContent = SizeToContent.Manual;
            window.Width = 560;
            window.Height = 230;
            ucAddRole addRole = new ucAddRole(window);
            window.Content = addRole;
            window.ShowDialog();

            ucFeatureAssignment.Load();
            ucRoleDataGrid.ReloadDataGrid();
        }

        private void ckUserAssignment_Checked(object sender, RoutedEventArgs e)
        {
            ReloadDataGrid(false);
        }

        private void ckUserAssignment_Unchecked(object sender, RoutedEventArgs e)
        {
            ReloadDataGrid(true);
        }

        private void cbPage_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ucUserRoleDataGrid.pagination.ItemPerPage = int.Parse((ucUserRoleDataGrid.pagination.cbPage.SelectedItem as ComboBoxItem).Content.ToString());

            ReloadDataGrid(toggleButton.IsChecked == true ? false : true);
        }

        private void SetVisibility(Visibility VisibilityManagement, Visibility VisibilityViewRole, Visibility VisibilityFeatureAssignment)
        {
            if (this.IsLoaded == false)
                return;
            grdManagement.Visibility = VisibilityManagement;
            ucUserRoleDataGrid.Visibility = VisibilityManagement;

            ucRoleDataGrid.Visibility = VisibilityViewRole;
            ucFeatureAssignment.Visibility = VisibilityFeatureAssignment;
        }

        private void lbTabMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string tab = (lbTabMenu.SelectedValue as ListBoxItem).Content.ToString();

            switch (tab)
            {
                case "Management":
                    SetVisibility(Visibility.Visible, Visibility.Collapsed, Visibility.Collapsed);
                    if (_TreeViewItem != null)
                        _TreeViewItem.IsHitTestVisible = true;
                    break;
                case "Feature Assignment":
                    SetVisibility(Visibility.Collapsed, Visibility.Collapsed, Visibility.Visible);
                    break;
                case "View Role":
                    if (_TreeViewItem != null)
                        _TreeViewItem.IsHitTestVisible = true;
                    SetVisibility(Visibility.Collapsed, Visibility.Visible, Visibility.Collapsed);
                    break;
            }
        }
    }
}

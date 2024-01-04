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
using System.Windows.Shapes;

namespace HungVuong_C5_Assignment
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        private string password = "";

        private UserViewModel userVM = new UserViewModel();
        private UserRoleViewModel userRoleVM = new UserRoleViewModel();
        private RoleViewModel roleVM = new RoleViewModel();
        private UserInfoViewModel userInfoVM = new UserInfoViewModel();

        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            DatabaseFirst.Instance.UserLoggedIn = userVM.userRepo.GetByUsernameAndPassword(txtUsername.Text, password);

            if (DatabaseFirst.Instance.UserLoggedIn == null)
            {
                MessageBox.Show("Login failed!", "Notify", MessageBoxButton.OK, MessageBoxImage.Warning);
                txtUsername.Text = txtPassword.Text = string.Empty;
                txtUsername.Focus();
            }
            else
            {
                UserRole userRole = userRoleVM.userRoleRepo.GetByIdUser(DatabaseFirst.Instance.UserLoggedIn.Id);

                if(userRole == null)
                {
                    MessageBox.Show("Account role missing. Contact admin for help!", "Notify", MessageBoxButton.OK, MessageBoxImage.Warning);
                    txtUsername.Text = txtPassword.Text = string.Empty;
                    txtUsername.Focus();
                    return;
                }

                Role role = roleVM.roleRepo.GetByID(userRole.IdRole);

                if(role.Group == "librarian")
                {
                    UserMenu mainMenu = new UserMenu(role, userInfoVM.UserInfoRepo.Items.FirstOrDefault(i => i.IdUser == DatabaseFirst.Instance.UserLoggedIn.Id));
                    if (mainMenu.TreeView.Items.Count == 0)
                    {
                        mainMenu.Close();
                        MessageBox.Show("Current role does not have access to any features!", "Notify", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                    else
                    {
                        mainMenu.Show();
                        this.Close();
                    }
                }
                else if(role.Group == "administration")
                {
                    AdminMenu adminMenu = new AdminMenu(role, userInfoVM.UserInfoRepo.Items.FirstOrDefault(i => i.IdUser == DatabaseFirst.Instance.UserLoggedIn.Id));
                    adminMenu.Show();
                    this.Close();
                }
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            txtUsername.Focus();
        }

        private void txtPassword_TextChanged(object sender, TextChangedEventArgs e)
        {
            txtPassword.Text = txtPassword.Text.Trim();
            txtPassword.SelectionStart = txtPassword.Text.Length;

            if (password.Length != txtPassword.Text.Trim().Length)
            {
                password = password.Substring(0, password.Length - 1);
                txtPassword_TextChanged(sender, e);
            }
            else
                return;
        }

        private void txtPassword_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (e.Text == string.Empty)
                return;
            if(e.Text[0] == '\r')
            {
                e.Handled = true;
                btnLogin_Click(new object(), new RoutedEventArgs());
                return;
            }
            password = password + e.Text[0];
            e.Handled = true;
            var item = (txtPassword.Text + e.Text[0]).Select(c => '•').ToArray();
            txtPassword.Text = new string(item);
            txtPassword.SelectionStart = item.Length;
        }

        private void txtUsername_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (e.Text != string.Empty && e.Text[0] == '\r')
            {
                e.Handled = true;
                btnLogin_Click(new object(), new RoutedEventArgs());
                return;
            }
        }

        private void btnBackToConnect_Click(object sender, RoutedEventArgs e)
        {
            ConnectionWindow connectWindow = new ConnectionWindow(true);
            connectWindow.Show();
            this.Close();
        }

        private void txtPassword_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            // Ngăn chặn sự kiện paste
            if ((Keyboard.Modifiers & ModifierKeys.Control) == ModifierKeys.Control && e.Key == Key.V)
            {
                e.Handled = true;
            }
        }
    }
}

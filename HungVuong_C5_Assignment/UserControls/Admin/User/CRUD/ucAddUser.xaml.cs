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
    /// Interaction logic for ucAddUser.xaml
    /// </summary>
    public partial class ucAddUser : UserControl
    {
        public WindowDefault _Parent;
        public delegate void Added();
        public event Added addedEvent;

        private UserManagementRepository _UserManagementRepo = new UserManagementRepository();

        public ucAddUser(WindowDefault window)
        {
            InitializeComponent();
            this._Parent = window;
            ucInputUser.txtCreatedAt.Text = DateTime.Now.ToString("dd/MM/yyyy");
            ucInputUser.txtModifiedAt.Text = ucInputUser.txtCreatedAt.Text;
            ucInputUser.TextChangedEvent += txtUsername_TextChanged;
            DataContext = this;
        }

        private bool isCheckValidation()
        {
            bool isCheck = true;

            if (StaticValidation.GetValidationRule<InputOnlyPhoneAndNumber>(ucInputUser.txtUsername) == null)
            {
                isCheck = false;
            }
            else if (StaticValidation.GetValidationRule<InputTextAndNumber>(ucInputUser.txtPassword) == null)
            {
                isCheck = false;
            }
            else if (StaticValidation.GetValidationRule<InputTextRule>(ucInputUser.txtLName) == null)
            {
                isCheck = false;
            }
            else if (StaticValidation.GetValidationRule<InputTextRule>(ucInputUser.txtFName) == null)
            {
                isCheck = false;
            }
            else if (StaticValidation.GetValidationRule<InputOnlyPhoneAndNumber>(ucInputUser.txtAddress) == null)
            {
                isCheck = false;
            }
            else if (StaticValidation.GetValidationRule<InputPhoneRule>(ucInputUser.txtPhone) == null)
            {
                isCheck = false;
            }
            return isCheck;
        }

        private void txtUsername_TextChanged(object sender, TextChangedEventArgs e)
        {
            btnAdd.IsEnabled = isCheckValidation();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            bool isAdded = _UserManagementRepo.AddUser(new UserDto() {
                Address = ucInputUser.txtAddress.Text,
                FName = ucInputUser.txtFName.Text,
                LName = ucInputUser.txtLName.Text,
                Phone = ucInputUser.txtPhone.Text,
                Username = ucInputUser.txtUsername.Text,
                Password = ucInputUser.txtPassword.Text
            });

            if (isAdded == false)
                return;

            MessageBox.Show("Added Successfully!", "Notify", MessageBoxButton.OK, MessageBoxImage.Information);
            addedEvent?.Invoke();
            _Parent.Close();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            _Parent.Close();
        }
    }
}
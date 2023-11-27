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
    /// Interaction logic for ucUpdateUserView.xaml
    /// </summary>
    public partial class ucUpdateUserView : UserControl
    {
        private WindowDefault _ParentWindow;
        private UserInfoViewModel _UserInfoVM = new UserInfoViewModel();
        private UserViewModel _UserVM = new UserViewModel();
        private User _User;
        private UserInfo _UserInfo;

        private UserManagementRepository _UserManagementRepo = new UserManagementRepository();

        public string Username { get; set; }
        public string Password { get; set; }
        public string LName { get; set; }
        public string FName { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }

        public ucUpdateUserView(WindowDefault window, User user)
        {
            this._ParentWindow = window;
            InitializeComponent();
            this._User = user;

            UserInfo userInfo = _UserInfoVM.UserInfoRepo.Items.FirstOrDefault(i => i.IdUser == user.Id);

            this._UserInfo = userInfo;

            ucInputUser.SetData(user, userInfo);

            ucInputUser.TextChangedEvent += UcInputUser_TextChangedEvent;
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

        private void UcInputUser_TextChangedEvent(object sender, TextChangedEventArgs e)
        {
            btnUpdate.IsEnabled = isCheckValidation();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            bool isUpdated = _UserManagementRepo.UpdateUser(new UserDto() {
                Id = _User.Id,
                FName = ucInputUser.FName,
                Address = ucInputUser.Address,
                LName = ucInputUser.LName,
                Phone = ucInputUser.Phone,
                Username = ucInputUser.Username,
                Password = ucInputUser.Password
            }, _User.Username);

            if (!isUpdated)
                return;

            this._ParentWindow.DialogResult = true;

            this._ParentWindow.Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this._ParentWindow.DialogResult = false;
            this._ParentWindow.Close();
        }
    }
}

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
    /// Interaction logic for InputUser.xaml
    /// </summary>
    public partial class InputUser : UserControl
    {
        public delegate void TextChangedHandle(object sender, TextChangedEventArgs e);
        public event TextChangedHandle TextChangedEvent;

        public string Username { get; set; }
        public string Password { get; set; }
        public string LName { get; set; }
        public string FName { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }

        public InputUser()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void txtUsername_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox txt = sender as TextBox;

            if(txt.Name != null)
            {
                if (txt.Name == "txtPhone")
                {
                    if (txt.Text.Contains(" "))
                    {
                        txt.Text = txt.Text.Trim();
                        txt.SelectionStart = txt.Text.Length;
                    }
                }
            }
            
            TextChangedEvent?.Invoke(sender, e);
        }

        public void isEnabled(bool isEnabled)
        {
            txtAddress.IsEnabled = isEnabled;
            txtFName.IsEnabled = isEnabled;
            txtLName.IsEnabled = isEnabled;
            txtPassword.IsEnabled = isEnabled;
            txtPhone.IsEnabled = isEnabled;
            txtUsername.IsEnabled = isEnabled;
        }

        private void txtPhone_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (e.Text != string.Empty && !char.IsDigit(e.Text[0]))
            {
                e.Handled = true;
            }
        }

        public void SetData(User user, UserInfo userInfo)
        {
            Address = userInfo.Address;
            txtCreatedAt.Text = user.CreatedAt.ToString("dd/MM/yyyy");
            FName = userInfo.FName;
            LName = userInfo.LName;
            txtModifiedAt.Text = user.ModifiedAt.ToString("dd/MM/yyyy");
            Password = user.Password;
            Phone = userInfo.Phone;
            Username = user.Username;
        }
    }
}

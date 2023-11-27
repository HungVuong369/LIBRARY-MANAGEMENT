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
    /// Interaction logic for ucUpdateUser.xaml
    /// </summary>
    public partial class ucUpdateUser : UserControl
    {
        private UserInfoViewModel _UserInfoVM = new UserInfoViewModel();
        private UserViewModel _UserVM = new UserViewModel();

        public ucUpdateUser()
        {
            InitializeComponent();
            ucUserDataGrid.VisibilityButton(Visibility.Collapsed, Visibility.Collapsed, Visibility.Visible, Visibility.Collapsed);
            ucUserDataGrid.updateEvent += UcUserDataGrid_updateEvent;
        }

        private void UcUserDataGrid_updateEvent(object sender, RoutedEventArgs e)
        {
            
        }
    }
}

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
    /// Interaction logic for ucUserAssignment.xaml
    /// </summary>
    public partial class ucUserAssignment : UserControl
    {
        private UserViewModel _UserVM = new UserViewModel();
        private UserInfoViewModel _UserInfoVM = new UserInfoViewModel();
        private UserRoleViewModel _UserRoleVM = new UserRoleViewModel();

        public ucUserAssignment()
        {
            InitializeComponent();
            ucUserDataGrid.VisibilityButton(Visibility.Collapsed, Visibility.Collapsed, Visibility.Collapsed, Visibility.Visible);
            ucUserDataGrid.dgUser.ItemsSource = this._UserVM.userRepo.Items.Where(item => _UserRoleVM.userRoleRepo.GetByIdUser(item.Id) == null).ToList();
            ucUserDataGrid.userAssignmentEvent += UcUserDataGrid_userAssignmentEvent;
        }

        private void UcUserDataGrid_userAssignmentEvent(object sender, RoutedEventArgs e)
        {
            
        }
    }
}

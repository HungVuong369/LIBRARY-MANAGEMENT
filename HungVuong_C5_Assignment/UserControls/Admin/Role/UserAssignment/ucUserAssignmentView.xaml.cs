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
    /// Interaction logic for ucUserAssignmentView.xaml
    /// </summary>
    public partial class ucUserAssignmentView : UserControl
    {
        private WindowDefault _ParentWindow;
        private RoleViewModel _RoleVM = new RoleViewModel();
        private UserRoleViewModel _UserRoleVM = new UserRoleViewModel();
        public int defaultIndex = -1;

        public ucUserAssignmentView(WindowDefault window, User user, UserInfo userInfo)
        {
            InitializeComponent();
            ucInputUser.isEnabled(false);
            ucInputUser.SetData(user, userInfo);
            this._ParentWindow = window;
            cbRole.ItemsSource = _RoleVM.roleRepo.Items.Where(i => i.Id != "R1");

            Role role = null;

            try
            {
                role = _RoleVM.roleRepo.Items.FirstOrDefault(item => item.Id == _UserRoleVM.userRoleRepo.Items.FirstOrDefault(i => i.IdUser == user.Id).IdRole);
            }
            catch (NullReferenceException)
            {
                DataContext = this;
                return;
            }

            defaultIndex = _RoleVM.roleRepo.Items.Where(i => i.Id != "R1").Select((item, idx) => new { item, idx }).FirstOrDefault(x => x.item.Id == role.Id)?.idx ?? -1;

            cbRole.SelectedIndex = defaultIndex;

            DataContext = this;
        }

        private void cbRole_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbRole.SelectedIndex == -1)
                btnConfirm.IsEnabled = false;
            else
                btnConfirm.IsEnabled = true;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this._ParentWindow.DialogResult = false;
            this._ParentWindow.Close();
        }

        private void btnConfirm_Click(object sender, RoutedEventArgs e)
        {
            this._ParentWindow.DialogResult = true;
            this._ParentWindow.Tag = cbRole.SelectedItem;
            this._ParentWindow.Close();
        }
    }
}

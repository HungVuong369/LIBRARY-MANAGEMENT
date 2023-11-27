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
    /// Interaction logic for ucAddRole.xaml
    /// </summary>
    public partial class ucAddRole : UserControl
    {
        private RoleManagementRepository _RoleManagementRepo = new RoleManagementRepository();
        private RoleViewModel _RoleVM = new RoleViewModel();

        private WindowDefault _Parent;
        public string NameRole { get; set; }

        public ucAddRole(WindowDefault window)
        {
            InitializeComponent();
            _Parent = window;

            cbGroup.ItemsSource = _RoleVM.GetListGroup().Where(i => i != "administration");
            cbGroup.SelectedIndex = 0;
            DataContext = this;

            this.Loaded += UcAddRole_Loaded;
        }

        private void UcAddRole_Loaded(object sender, RoutedEventArgs e)
        {
            txtNameRole.Focus();
        }

        private bool isCheckValidation()
        {
            bool isCheck = true;

            if (StaticValidation.GetValidationRule<InputTextAndNumber>(txtNameRole) == null)
            {
                isCheck = false;
            }
            
            return isCheck;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            bool isAdded = _RoleManagementRepo.AddRole(txtNameRole.Text, cbGroup.SelectedValue as string);

            if (!isAdded)
            {
                txtNameRole.Focus();
                return;
            }
            
            MessageBox.Show("Added Successfully!", "Notify", MessageBoxButton.OK, MessageBoxImage.Information);

            _Parent.Close();
        }

        private void isEnabled()
        {
            bool isCheck = isCheckValidation();

            if (cbGroup.SelectedIndex == -1)
            {
                isCheck = false;
            }

            btnAdd.IsEnabled = isCheck;
        }

        private void txtNameRole_TextChanged(object sender, TextChangedEventArgs e)
        {
            isEnabled();
        }

        private void cbGroup_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            isEnabled();
        }

        private void txtNameRole_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                btnAdd_Click(new object(), new RoutedEventArgs());
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            _Parent.Close();
        }
    }
}

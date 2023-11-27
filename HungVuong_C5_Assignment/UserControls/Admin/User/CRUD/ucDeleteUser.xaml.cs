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
    /// Interaction logic for ucDeleteUser.xaml
    /// </summary>
    public partial class ucDeleteUser : UserControl
    {
        public ucDeleteUser()
        {
            InitializeComponent();
            ucUserDataGrid.VisibilityButton(Visibility.Visible, Visibility.Collapsed, Visibility.Collapsed, Visibility.Collapsed);
            ucUserDataGrid.deleteEvent += UcUserDataGrid_deleteEvent;

           // ucUserDataGrid.dgUser.ItemsSource = _UserVM.userRepo.Items.Where(i => i != _UserVM.userRepo.Items.FirstOrDefault(it => it.Status));
        }

        private void UcUserDataGrid_deleteEvent(object sender, RoutedEventArgs e)
        {
            
        }
    }
}

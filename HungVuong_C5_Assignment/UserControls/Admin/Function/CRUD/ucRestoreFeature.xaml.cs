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
    /// Interaction logic for ucRestoreFeature.xaml
    /// </summary>
    public partial class ucRestoreFeature : UserControl
    {
        private FunctionViewModel _FunctionVM = new FunctionViewModel();

        public ucRestoreFeature()
        {
            InitializeComponent();

            _FunctionVM.functionRepo.Load(false);

            ucFuntion.SetVisibilityButton(Visibility.Collapsed, Visibility.Collapsed, Visibility.Visible);
            ucFuntion.restoreEvent += UcFuntion_restoreEvent;

            ucFuntion.dgFunction.ItemsSource = null;
            ucFuntion.dgFunction.ItemsSource = _FunctionVM.functionRepo.Items;
        }

        private void UcFuntion_restoreEvent(object sender, RoutedEventArgs e)
        {
            
        }
    }
}

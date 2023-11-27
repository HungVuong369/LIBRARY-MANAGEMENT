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
    /// Interaction logic for ucConfirmRestoreFunction.xaml
    /// </summary>
    public partial class ucConfirmRestoreFunction : UserControl
    {
        private WindowDefault _Parent;
        private FunctionViewModel _FunctionVM = new FunctionViewModel();

        public ucConfirmRestoreFunction(WindowDefault parent, List<Function> functions)
        {
            InitializeComponent();
            _Parent = parent;

            ucFunctionDataGrid.dgFunction.ItemsSource = _FunctionVM.GetListFunctionRestore(functions);

            ucFunctionDataGrid.pagination.Visibility = Visibility.Collapsed;

            ucFunctionDataGrid.SetVisibilityButton(Visibility.Collapsed, Visibility.Collapsed, Visibility.Collapsed);
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            _Parent.DialogResult = false;
            _Parent.Close();
        }

        private void btnConfirm_Click(object sender, RoutedEventArgs e)
        {
            _Parent.DialogResult = true;
            _Parent.Close();
        }
    }
}

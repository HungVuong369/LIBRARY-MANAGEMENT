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
    /// Interaction logic for ucConfirmDeleteFeature.xaml
    /// </summary>
    public partial class ucConfirmDeleteFeature : UserControl
    {
        private FunctionViewModel _FunctionVM = new FunctionViewModel();
        private WindowDefault _Parent;
        public ucConfirmDeleteFeature(WindowDefault window, string IdFunction)
        {
            InitializeComponent();
            this._Parent = window;
            
            ucFunctionDataGrid.dgFunction.ItemsSource = _FunctionVM.GetListFunctionDelete(IdFunction);

            ucFunctionDataGrid.pagination.Visibility = Visibility.Collapsed;

            ucFunctionDataGrid.SetVisibilityButton(Visibility.Collapsed, Visibility.Collapsed, Visibility.Collapsed);
        }

        public ucConfirmDeleteFeature(WindowDefault window, List<Function> functions)
        {
            InitializeComponent();
            ucFunctionDataGrid.pagination.Visibility = Visibility.Collapsed;

            this._Parent = window;
           
            ucFunctionDataGrid.dgFunction.ItemsSource = _FunctionVM.GetListFunctionDelete(functions);

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

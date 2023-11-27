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
    /// Interaction logic for ucConfirmFeature.xaml
    /// </summary>
    public partial class ucConfirmFeature : UserControl
    {
        private int selectedIndex = -1;
        private WindowDefault _Parent;

        public ucConfirmFeature(WindowDefault parent)
        {
            InitializeComponent();
            ucFunction.selectionChangedEvent += UcFunction_selectionChangedEvent;
            ucFunction.pagination.grdShowEntities.Visibility = Visibility.Collapsed;
            ucFunction.pagination.ItemPerPage = 5;
            _Parent = parent;

            if(_Parent.Tag != null)
            {
                ucFunction.FilterById(_Parent.Tag.ToString());
                ucFunction.pagination.ChangedPageEvent += Pagination_ChangedPageEvent;
            }
            ucFunction.pagination.grdMain.ColumnDefinitions.RemoveAt(1);
        }

        private void Pagination_ChangedPageEvent(Pagination pagination)
        {
            if (_Parent.Tag == null)
            {
                ucFunction.FilterById("");
                return;
            }
            ucFunction.FilterById(_Parent.Tag.ToString());
        }

        private void UcFunction_selectionChangedEvent(object sender, SelectionChangedEventArgs e)
        {
            var dataGrid = sender as DataGrid;
            selectedIndex = dataGrid.SelectedIndex;
            _Parent.Tag = dataGrid.SelectedItem;
        }

        private void btnConfirm_Click(object sender, RoutedEventArgs e)
        {
            _Parent.DialogResult = true;
            _Parent.Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            _Parent.DialogResult = false;
            _Parent.Close();
        }

        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            ucFunction.Search((sender as TextBox).Text);
            ucFunction.ReloadDataGrid();
        }
    }
}

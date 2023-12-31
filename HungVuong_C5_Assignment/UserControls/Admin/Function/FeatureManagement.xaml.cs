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
using System.Windows.Threading;

namespace HungVuong_C5_Assignment
{
    /// <summary>
    /// Interaction logic for FeatureManagement.xaml
    /// </summary>
    public partial class FeatureManagement : UserControl
    {
        private FunctionViewModel _FunctionVM = new FunctionViewModel();
        private DispatcherTimer updateDataGrid = new DispatcherTimer();
        private FeatureManagementRepository _FeatureManagementRepo = new FeatureManagementRepository();

        public FeatureManagement()
        {
            InitializeComponent();
            ucFunctionDataGrid.pagination.ChangedPageEvent += Pagination_ChangedPageEvent1;
            ucFunctionDataGrid.pagination.SelectionChangedComboBoxEvent += Pagination_SelectionChangedComboBoxEvent;
            ucFunctionDataGrid.pagination.cbPage.SelectedIndex = 1;

            ucFunctionDataGrid.deleteEvent += UcFunctionDataGrid_deleteEvent;
            ucFunctionDataGrid.updateEvent += UcFunctionDataGrid_updateEvent;
            ucFunctionDataGrid.restoreEvent += UcFunctionDataGrid_restoreEvent;

            ucFunctionDataGrid.selectionChangedEvent += UcFunctionDataGrid_selectionChangedEvent;
            ucFunctionDataGrid.dgFunction.SelectionMode = DataGridSelectionMode.Extended;

            updateDataGrid.Tick += UpdateDataGrid_Tick;
            updateDataGrid.Interval = TimeSpan.FromSeconds(1);
        }

        private void Pagination_SelectionChangedComboBoxEvent(object sender, SelectionChangedEventArgs e)
        {
            ucFunctionDataGrid.pagination.ItemPerPage = int.Parse((ucFunctionDataGrid.pagination.cbPage.SelectedItem as ComboBoxItem).Content.ToString());
            ReloadDataGrid();
        }

        private void UpdateDataGrid_Tick(object sender, EventArgs e)
        {
            ucFunctionDataGrid.ReloadDataGrid();
        }

        private void UcFunctionDataGrid_selectionChangedEvent(object sender, SelectionChangedEventArgs e)
        {
            if (toggleButton.IsChecked == false)
            {
                btnRestoreAll.Visibility = Visibility.Collapsed;

                if (ucFunctionDataGrid.dgFunction.SelectedItems.Count >= 2)
                {
                    btnDeleteAll.Visibility = Visibility.Visible;
                }
                else
                {
                    btnDeleteAll.Visibility = Visibility.Collapsed;
                }
            }
            else
            {
                btnDeleteAll.Visibility = Visibility.Collapsed;

                if (ucFunctionDataGrid.dgFunction.SelectedItems.Count >= 2)
                {
                    btnRestoreAll.Visibility = Visibility.Visible;
                }
                else
                {
                    btnRestoreAll.Visibility = Visibility.Collapsed;
                }
            }
        }

        private void UcFunctionDataGrid_restoreEvent(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to restore this feature", "Notify", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                Function function = (sender as Button).Tag as Function;
                Function functionParent = _FunctionVM.functionRepo.Items.FirstOrDefault(i => i.Id == function.IdParent);
                if (functionParent != null)
                    _FeatureManagementRepo.Restore(functionParent);
                _FeatureManagementRepo.Restore(function);

                ReloadRestored();

                MessageBox.Show("Restore Successfully!", "Notify", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void ReloadDataGrid()
        {
            ucFunctionDataGrid.ReloadStorage();
            txtSearch.Text = "";

            ucFunctionDataGrid.pagination.CurrentPage = 1;
            ucFunctionDataGrid.pagination.LoadPage();

            ucFunctionDataGrid.ReloadDataGrid();
        }

        private void Pagination_ChangedPageEvent1(Pagination pagination)
        {
            ucFunctionDataGrid.ReloadDataGrid();
        }

        private void UcFunctionDataGrid_updateEvent(object sender, RoutedEventArgs e)
        {
            WindowDefault window = new WindowDefault();
            window.grdContainer.Children.Add(new ucUpdateFeatureView(window, ucFunctionDataGrid.dgFunction.SelectedItem as Function));
            window.ShowDialog();

            if (window.DialogResult == true)
            {
                ucFunctionDataGrid.ReloadStorage();
                ucFunctionDataGrid.ReloadDataGrid();
                ucFunctionDataGrid.pagination.LoadPage();

                if (txtSearch.Text != string.Empty)
                    ucFunctionDataGrid.Search(txtSearch.Text);

                MessageBox.Show("Updated Successfully!", "NOtify", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void ReloadRestored()
        {
            ucFunctionDataGrid.ReloadStorage();
            if (ucFunctionDataGrid.pagination.CurrentPage > ucFunctionDataGrid.pagination.MaxPage)
            {
                for (; ucFunctionDataGrid.pagination.CurrentPage > ucFunctionDataGrid.pagination.MaxPage; ucFunctionDataGrid.pagination.CurrentPage--) { }

                ucFunctionDataGrid.ReloadDataGrid();
                ucFunctionDataGrid.pagination.LoadPage();
            }
            else
            {
                ucFunctionDataGrid.ReloadDataGrid();
                ucFunctionDataGrid.pagination.LoadPage();
            }

            if (txtSearch.Text != string.Empty)
            {
                ucFunctionDataGrid.Search(txtSearch.Text);
                ucFunctionDataGrid.ReloadDataGrid();
                ucFunctionDataGrid.pagination.LoadPage();
            }
        }

        private void ReloadDeleted()
        {
            ucFunctionDataGrid.ReloadStorage();

            if (ucFunctionDataGrid.pagination.CurrentPage > ucFunctionDataGrid.pagination.MaxPage)
            {
                for (; ucFunctionDataGrid.pagination.CurrentPage > ucFunctionDataGrid.pagination.MaxPage; ucFunctionDataGrid.pagination.CurrentPage--) { }
                ucFunctionDataGrid.ReloadDataGrid();
                ucFunctionDataGrid.pagination.LoadPage();
            }
            else
            {
                ucFunctionDataGrid.ReloadDataGrid();
                ucFunctionDataGrid.pagination.LoadPage();
            }

            if (txtSearch.Text != string.Empty)
            {
                ucFunctionDataGrid.Search(txtSearch.Text);
                ucFunctionDataGrid.ReloadDataGrid();
                ucFunctionDataGrid.pagination.LoadPage();
            }
        }

        private void UcFunctionDataGrid_deleteEvent(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete this feature?", "Notify", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                Function function = (sender as Button).Tag as Function;
                if (_FunctionVM.functionRepo.Items.FirstOrDefault(i => i.IdParent == function.Id) == null)
                {
                    _FeatureManagementRepo.Delete(function);
                    MessageBox.Show("Deleted Successfully!", "Notify", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    WindowDefault window = new WindowDefault();
                    window.grdContainer.Children.Add(new ucConfirmDeleteFeature(window, function.Id));
                    window.ShowDialog();

                    if (window.DialogResult == true)
                    {
                        List<Function> lstFunctionChild = _FunctionVM.functionRepo.Items.Where(i => i.IdParent == function.Id).ToList();
                        for (int index = lstFunctionChild.Count - 1; index >= 0; index--)
                        {
                            Function item = lstFunctionChild[index];
                            _FeatureManagementRepo.Delete(item);
                        }
                        _FeatureManagementRepo.Delete(function);

                        MessageBox.Show("Deleted Successfully!", "Notify", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
                ReloadDeleted();
            }
        }

        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            ucFunctionDataGrid.Search((sender as TextBox).Text);
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            _FunctionVM.functionRepo.Load(false);
            ReloadDataGrid();
            ucFunctionDataGrid.SetVisibilityButton(Visibility.Collapsed, Visibility.Collapsed, Visibility.Visible);
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            _FunctionVM.functionRepo.Load(true);
            ReloadDataGrid();
            ucFunctionDataGrid.SetVisibilityButton(Visibility.Visible, Visibility.Visible, Visibility.Collapsed);
        }

        private void ReloadDataGridByText()
        {
            ucFunctionDataGrid.Search(txtSearch.Text);
            ucFunctionDataGrid.ReloadDataGrid();
        }

        private void btnDeleteAll_Click(object sender, RoutedEventArgs e)
        {
            WindowDefault window = new WindowDefault();
            List<Function> selectedFunctions = ucFunctionDataGrid.dgFunction.SelectedItems.Cast<Function>().ToList();

            window.grdContainer.Children.Add(new ucConfirmDeleteFeature(window, selectedFunctions));
            window.ShowDialog();

            if (window.DialogResult == true)
            {
                List<Function> lstFunction = _FunctionVM.GetListFunctionDelete(selectedFunctions);

                foreach (var item in lstFunction)
                {
                    _FeatureManagementRepo.Delete(item);
                }

                ReloadDeleted();

                MessageBox.Show("Delete Successfully!", "Notify", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void btnRestoreAll_Click(object sender, RoutedEventArgs e)
        {
            WindowDefault window = new WindowDefault();
            List<Function> selectedFunctions = ucFunctionDataGrid.dgFunction.SelectedItems.Cast<Function>().ToList();

            window.grdContainer.Children.Add(new ucConfirmRestoreFunction(window, selectedFunctions));
            window.ShowDialog();

            if (window.DialogResult == true)
            {
                List<Function> lstFunction = _FunctionVM.GetListFunctionRestore(selectedFunctions);

                foreach (var item in lstFunction)
                {
                    _FeatureManagementRepo.Restore(item);
                }

                ReloadRestored();

                MessageBox.Show("Restore Successfully!", "Notify", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void txtSearch_GotFocus(object sender, RoutedEventArgs e)
        {
            updateDataGrid.Start();
        }

        private void txtSearch_LostFocus(object sender, RoutedEventArgs e)
        {
            updateDataGrid.Stop();
        }
    }
}

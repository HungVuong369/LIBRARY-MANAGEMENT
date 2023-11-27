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
    /// Interaction logic for ucTransitioningChild.xaml
    /// </summary>
    public partial class ucTransitioningChild : UserControl
    {
        private ChildViewModel childVM = new ChildViewModel();
        private ReaderManagementRepository _ReaderManagementRepo = new ReaderManagementRepository();
        private ParameterViewModel _ParameterVM = new ParameterViewModel();

        public ucTransitioningChild()
        {
            InitializeComponent();

            ucAdultDataGrid1.UpdateDataGridByQuantityChild(int.Parse(_ParameterVM.GetValueByID("QD1")) + 1);
            ucAdultDataGrid1.RemoveGuardianByQuantityChild(0);

            ucAdultDataGrid1.dgAdult.SelectionChanged += DgAdult_SelectionChanged;
            ucAdultDataGrid2.dgAdult.SelectionChanged += DgAdult_SelectionChanged1;
            ucChildDataGrid2.dgChildInfo.IsHitTestVisible = false;
        }

        private void DgAdult_SelectionChanged1(object sender, SelectionChangedEventArgs e)
        {
            btnNext2.IsEnabled = true;
        }

        private void DgAdult_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btnNext1_Click(new object(), new RoutedEventArgs());
        }

        private void txtSearch1_TextChanged(object sender, TextChangedEventArgs e)
        {
            btnNext1.IsEnabled = false;
            ucAdultDataGrid1.UpdateDataGridByIdentify(txtSearch1.Text);
        }

        private void txtSearch2_TextChanged(object sender, TextChangedEventArgs e)
        {
            btnNext2.IsEnabled = false;
            ucAdultDataGrid2.UpdateDataGridByIdentify(txtSearch2.Text);
        }

        private void SetProperty(string page, Visibility adultVisibility, Visibility childVisibility, Brush brushesAdult, Brush brushesChild, bool isChanged)
        {
            lbPage1.Content = page;

            ucAdultDataGrid1.Visibility = adultVisibility;
            ucChildDataGrid1.Visibility = childVisibility;

            lbSelectAdult1.Foreground = brushesAdult;
            lbSelectChild.Foreground = brushesChild;
            btnBack1.IsEnabled = !isChanged;
            btnNext1.IsEnabled = isChanged;
            txtSearch1.IsEnabled = isChanged;
        }

        private void SetProperty(string page, Visibility adultVisibility, Visibility childVisibility, Brush brushesAdult, bool isChanged)
        {
            lbPage2.Content = page;

            ucAdultDataGrid2.Visibility = adultVisibility;
            ucChildDataGrid2.Visibility = childVisibility;

            lbSelectAdult2.Foreground = brushesAdult;
            btnBack2.IsEnabled = !isChanged;
            btnNext2.IsEnabled = isChanged;
            txtSearch2.IsEnabled = isChanged;
        }

        private void btnBack1_Click(object sender, RoutedEventArgs e)
        {
            SetProperty("1/2", Visibility.Visible, Visibility.Collapsed, Brushes.Black, Brushes.Transparent, true);
        }

        private void btnNext1_Click(object sender, RoutedEventArgs e)
        {
            if (ucAdultDataGrid1.dgAdult.SelectedItem == null)
                return;
            SetProperty("2/2", Visibility.Collapsed, Visibility.Visible, Brushes.Transparent, Brushes.Black, false);

            ucChildDataGrid1.SetItemsSourceByAdultIdReader((ucAdultDataGrid1.dgAdult.SelectedItem as Guardian).AdultID);
        }

        private void btnNext2_Click(object sender, RoutedEventArgs e)
        {
            if (ucAdultDataGrid2.dgAdult.SelectedItem == null)
                return;
            SetProperty("2/2", Visibility.Collapsed, Visibility.Visible, Brushes.Transparent, false);
            
            ucChildDataGrid2.SetItemsSourceByAdultIdReader((ucAdultDataGrid2.dgAdult.SelectedItem as Guardian).AdultID);
        }

        private void btnBack2_Click(object sender, RoutedEventArgs e)
        {
            SetProperty("1/2", Visibility.Visible, Visibility.Collapsed, Brushes.Black, true);
        }

        private void ResetDataGrid()
        {
            Guardian guardian1 = (ucAdultDataGrid1.dgAdult.SelectedItem as Guardian);
            Guardian guardian2 = (ucAdultDataGrid2.dgAdult.SelectedItem as Guardian);

            ucChildDataGrid1.SetItemsSourceByAdultIdReader(guardian1.AdultID);
            ucChildDataGrid2.SetItemsSourceByAdultIdReader(guardian2.AdultID);

            ucAdultDataGrid2.UpdateDataGridByQuantityChild(2);
            ucAdultDataGrid2.SelectedItemByIdentify(guardian2.Identify);
            if (ucAdultDataGrid2.dgAdult.SelectedItem == null)
            {
                btnBack2_Click(new object(), new RoutedEventArgs());
                btnNext2.IsEnabled = false;
            }

            ucAdultDataGrid1.UpdateDataGridByQuantityChild(3);
            ucAdultDataGrid1.RemoveGuardianByQuantityChild(0);
            ucAdultDataGrid1.SelectedItemByIdentify(guardian1.Identify);

            if (ucAdultDataGrid1.dgAdult.SelectedItem == null)
            {
                btnBack1_Click(new object(), new RoutedEventArgs());
                btnNext1.IsEnabled = false;
            }
        }

        private void btnTransition_Click(object sender, RoutedEventArgs e)
        {
            if (ucAdultDataGrid1.dgAdult.SelectedItem == null)
            {
                MessageBox.Show("Please select an adult", "Notify", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if (ucAdultDataGrid2.dgAdult.SelectedItem == null)
            {
                MessageBox.Show("Please select an adult", "Notify", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if (ucChildDataGrid1.dgChildInfo.SelectedItem == null)
            {
                MessageBox.Show("Please select a child", "Notify", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            _ReaderManagementRepo.TransitionChild((ucChildDataGrid1.dgChildInfo.SelectedItem as ChildInformation).IdReader, (ucAdultDataGrid2.dgAdult.SelectedItem as Guardian).AdultID);
            ResetDataGrid();
        }

        private void btnTransitionAll_Click(object sender, RoutedEventArgs e)
        {
            if (ucAdultDataGrid1.dgAdult.SelectedItem == null)
            {
                MessageBox.Show("Please select an adult", "Notify", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if (ucAdultDataGrid2.dgAdult.SelectedItem == null)
            {
                MessageBox.Show("Please select an adult", "Notify", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if((ucAdultDataGrid2.dgAdult.SelectedItem as Guardian).QuantityChild + ucChildDataGrid1.dgChildInfo.Items.Count >= 3)
            {
                MessageBox.Show("Can not transition all child", "Notify", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            foreach (ChildInformation child in ucChildDataGrid1.dgChildInfo.Items)
            {
                _ReaderManagementRepo.TransitionChild(child.IdReader, (ucAdultDataGrid2.dgAdult.SelectedItem as Guardian).AdultID);
            }
            ResetDataGrid();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
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
    /// Interaction logic for ucAddChildReader.xaml
    /// </summary>
    public partial class ucAddChildReader : UserControl, INotifyPropertyChanged
    {
        private ReaderManagementRepository _ReaderManagementRepo = new ReaderManagementRepository();

        public delegate void CancelHandle(object sender, RoutedEventArgs e);
        public event CancelHandle CancelEvent;

        public delegate void AddedHandle(object sender, RoutedEventArgs e);
        public event AddedHandle AddedEvent;

        private ChildViewModel childVM = new ChildViewModel();
        private ParameterViewModel parameterVM = new ParameterViewModel();
        private ReaderViewModel readerVM = new ReaderViewModel();

        public event PropertyChangedEventHandler PropertyChanged;

        public string LName { get; set; }
        public string FName { get; set; }

        private bool _IsEnable = false;

        public bool IsEnable
        {
            get
            {
                return _IsEnable;
            }
            set
            {
                _IsEnable = value;
                OnPropertyChanged();
            }
        }

        public ucAddChildReader()
        {
            InitializeComponent();

            ucDataGrid.dgAdult.SelectionChanged += dgAdult_SelectionChanged;

            DataContext = this;
        }

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private void dpBoF_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((sender as DatePicker).SelectedDate != null)
            {
                DateTime currentDate = DateTime.Now;

                DateTime selectedDate = (sender as DatePicker).SelectedDate.Value;

                lbBoF.Text = (sender as DatePicker).SelectedDate.Value.ToString().Split(' ')[0];

                int age = currentDate.Year - selectedDate.Year;

                int adultAge = int.Parse(parameterVM.parameterRepo.GetByID("QD7").Value);

                if (age >= adultAge)
                {
                    lbBoF.Text += " - over the age limit!";
                }
                this.IsEnable = isCheckValidation();
            }
        }

        private void Clear()
        {
            txtLName.Clear();

            txtFName.Clear();

            lbBoF.Text = null;

            dpBoF.SelectedDate = null;

            ucDataGrid.dgAdult.SelectedItem = null;

            txtLName.Focus();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if ((ucDataGrid.dgAdult.SelectedItem as Guardian).QuantityChild >= int.Parse(parameterVM.GetValueByID("QD1")))
                return;

            _ReaderManagementRepo.AddChild((ucDataGrid.dgAdult.SelectedItem as Guardian).AdultID, txtLName.Text, txtFName.Text, dpBoF.SelectedDate.Value);

            var guardian = ucDataGrid.dgAdult.SelectedItem as Guardian;

            if (++guardian.QuantityChild == int.Parse(parameterVM.GetValueByID("QD1")))
            {
                ucDataGrid.RemoveByGuardian(guardian);  
            }

            ucDataGrid.UpdateDataGrid();

            MessageBox.Show("Child reader successfully added!", "Notify", MessageBoxButton.OK, MessageBoxImage.Information);

            AddedEvent?.Invoke(sender, e);
        }

        private void txtIdentify_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if(e.Text != string.Empty && !char.IsDigit(e.Text[0]))
                e.Handled = true;
        }

        private void txtIdentify_TextChanged(object sender, TextChangedEventArgs e)
        {
            ucDataGrid.UpdateDataGridByIdentify(txtIdentify.Text);
        }

        private bool isCheckValidation()
        {
            bool isCheck = true;

            if (ucDataGrid.dgAdult.SelectedItem == null)
            {
                isCheck = false;
                tbDatagrid.Foreground = Brushes.Red;
            }
            if(ucDataGrid.dgAdult.SelectedItem != null)
            {
                tbDatagrid.Foreground = Brushes.White;
            }
            if (StaticValidation.GetValidationRule<InputTextRule>(txtLName) == null)
            {
                isCheck = false;
            }
            if (StaticValidation.GetValidationRule<InputTextRule>(txtFName) == null)
            {
                isCheck = false;
            }
            if (string.IsNullOrEmpty(lbBoF.Text))
            {
                isCheck = false;
            }
            if (lbBoF.Text.ToString().Contains(" - over the age limit!"))
            {
                isCheck = false;
            }

            return isCheck;
        }

        private void txtLName_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.IsEnable = isCheckValidation();
        }

        private void dgAdult_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.IsEnable = isCheckValidation();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            CancelEvent?.Invoke(sender, e);
        }
    }
}

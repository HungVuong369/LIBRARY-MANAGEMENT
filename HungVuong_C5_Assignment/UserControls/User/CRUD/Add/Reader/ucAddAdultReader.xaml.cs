using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
    /// Interaction logic for ucAddAdultReader.xaml
    /// </summary>
    public partial class ucAddAdultReader : UserControl, INotifyPropertyChanged
    {
        private ReaderManagementRepository _ReaderManagementRepo = new ReaderManagementRepository();

        public delegate void AddedHandle(object sender, RoutedEventArgs e);
        public event AddedHandle AddedEvent;

        public delegate void CancelHandle(object sender, RoutedEventArgs e);
        public event CancelHandle CancelEvent;

        private ReaderViewModel readerVM = new ReaderViewModel();
        private AdultViewModel adultVM = new AdultViewModel();
        private ParameterViewModel parameterVM = new ParameterViewModel();

        public event PropertyChangedEventHandler PropertyChanged;

        public string LName { get; set; }
        public string FName { get; set; }
        public string Identify { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }

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

        public ucAddAdultReader()
        {
            InitializeComponent();
            txtExpDate.Text = DateTime.Now.AddMonths(int.Parse(parameterVM.GetValueByID("QD8"))).ToString();
            cbProvince.ItemsSource = DataAccess.GetListProvince();
            DataContext = this;
        }

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
       
        private bool isCheckValidation()
        {
            bool isCheck = true;

            if(StaticValidation.GetValidationRule<InputTextRule>(txtLName) == null)
            {
                isCheck = false;
            }
            else if(StaticValidation.GetValidationRule<InputTextRule>(txtFName) == null)
            {
                isCheck = false;
            }
            else if (StaticValidation.GetValidationRule<InputIdentifyRule>(txtIdentify) == null)
            {
                isCheck = false;
            }
            else if (StaticValidation.GetValidationRule<InputTextAndNumber>(txtAddress) == null)
            {
                isCheck = false;
            }
            else if (StaticValidation.GetValidationRule<InputPhoneRule>(txtPhone) == null)
            {
                isCheck = false;
            }
            else if(string.IsNullOrEmpty(lbBoF.Text))
            {
                isCheck = false;
            }
            else if(lbBoF.Text.ToString().Contains(" - Not old enough!"))
            {
                isCheck = false;
            }
            else
            {
                isCheck = true;
            }

            return isCheck;
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

                if (age < adultAge)
                {
                    lbBoF.Text += " - Not old enough!";
                }

                this.IsEnable = isCheckValidation();
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            var adultReader = new AdultReader()
            {
                Address = txtAddress.Text,
                BoF = dpBoF.SelectedDate.Value,
                CreatedAt = DateTime.Now,
                ModifiedAt = DateTime.Now,
                ExpireDate = DateTime.Parse(txtExpDate.Text),
                FName = txtFName.Text,
                Lname = txtLName.Text,
                Identify = txtIdentify.Text,
                Phone = txtPhone.Text,
                Type = true,
                Province = cbProvince.Text,
                Status = true
            };

            _ReaderManagementRepo.AddAdult(adultReader);
            
            MessageBox.Show("Adult reader successfully added!", "Notify", MessageBoxButton.OK, MessageBoxImage.Information);

            AddedEvent?.Invoke(sender, e);
        }

        private void txtPhone_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (e.Text != null && !char.IsDigit(e.Text[0]))
            {
                e.Handled = true;
            }
        }

        private void txtLName_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.IsEnable = isCheckValidation();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            CancelEvent?.Invoke(sender, e);
        }
    }
}

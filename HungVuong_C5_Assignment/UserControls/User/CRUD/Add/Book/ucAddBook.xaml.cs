using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
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
    /// Interaction logic for ucAddBook.xaml
    /// </summary>
    public partial class ucAddBook : UserControl
    {
        private WindowDefault _Parent;
        private List<BookISBNInformation> _BookISBNInformation = DataAccess.GetListBookISBNInformation();
        private ObservableCollection<BookISBNInformation> _BookISBNTemp;

        private BookViewModel _BookVM = new BookViewModel();

        public ucAddBook(WindowDefault window)
        {
            InitializeComponent();

            _Parent = window;

            this._BookISBNTemp = new ObservableCollection<BookISBNInformation>(_BookISBNInformation);

            dgBookISBN.ItemsSource = _BookISBNTemp;
        }

        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            this._BookISBNTemp.Clear();

            foreach (var item in this._BookISBNInformation)
            {
                if (item.ISBN.ToLower().Contains(txtSearch.Text.ToLower()))
                {
                    this._BookISBNTemp.Add(item);
                }
            }
        }

        private void btnDetail_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;

            WindowDefault window = new WindowDefault();
            window.Content = new ucDetailBookISBN(button.Tag.ToString());
            window.ShowDialog();
        }

        private void UpdateIsEnabled()
        {
            bool isCheck = true;

            if(dgBookISBN.SelectedItem == null)
            {
                tbSelectBookISBN.Foreground = Brushes.Red;
                isCheck = false;
            }
            else
            {
                tbSelectBookISBN.Foreground = Brushes.White;
            }
            if (txtBookPrice.Text == string.Empty)
                isCheck = false;

            btnAdd.IsEnabled = isCheck;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            BookManagementRepository bookManagementRepo = new BookManagementRepository();

            bool isCheck = bookManagementRepo.Add(dgBookISBN.SelectedValue.ToString(), decimal.Parse(txtBookPrice.Text.Replace(",", ".")));

            if (!isCheck)
                return;

            MessageBox.Show("Book successfully added!", "Notify", MessageBoxButton.OK, MessageBoxImage.Information);

            _Parent.DialogResult = true;
            _Parent.Close();
        }

        private void dgBookISBN_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateIsEnabled();
            try
            {
                txtBookPrice.Text = (dgBookISBN.SelectedItem as BookISBNInformation).BookPrice.ToString().Replace(".", ",");
            }
            catch(Exception)
            {

            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            _Parent.DialogResult = false;
            _Parent.Close();
        }

        private void txtBookPrice_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (e.Text != string.Empty && !char.IsDigit(e.Text[0]))
                e.Handled = true;
        }

        private void txtBookPrice_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtBookPrice.Text == string.Empty)
                return;
            txtBookPrice.Text = double.Parse(txtBookPrice.Text.Replace(",", "")).ToString("N0");
            txtBookPrice.SelectionStart = txtBookPrice.Text.Length;
            UpdateIsEnabled();
        }
    }
}
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

        private BookViewModel _BookVM;

        public ucAddBook(WindowDefault window)
        {
            InitializeComponent();

            _Parent = window;

            this._BookISBNTemp = new ObservableCollection<BookISBNInformation>(_BookISBNInformation);
            dgBookISBN.ItemsSource = _BookISBNTemp;

            _BookVM = new BookViewModel(
                _Parent, 
                DataAccess.GetListLanguage().Select(i => i.Name).ToList(), 
                DatabaseFirst.Instance.db.Publishers.ToList(), 
                DatabaseFirst.Instance.db.Translators.Where(i => i.Status).ToList()
            );
            this.DataContext = _BookVM;
        }

        private void btnDetail_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;

            WindowDefault window = new WindowDefault();
            window.Content = new ucDetailBookISBN(button.Tag.ToString());
            window.ShowDialog();
        }

        private void dgBookISBN_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btnAdd.IsEnabled = _BookVM.IsEnabledAdd;
        }

        private void txtBookPrice_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (e.Text != string.Empty && !char.IsDigit(e.Text[0]))
                e.Handled = true;
        }

        private void txtBookPrice_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = sender as TextBox;

            if (textBox.Text == string.Empty)
                return;
            textBox.Text = double.Parse(textBox.Text.Replace(",", "")).ToString("N0");
            textBox.SelectionStart = textBox.Text.Length;

            btnAdd.IsEnabled = _BookVM.IsEnabledAdd;
        }

        private void txtSearchPublisher_TextChanged(object sender, TextChangedEventArgs e)
        {
            _BookVM.LstPublisher.Clear();

            if (txtSearchPublisher.Text == string.Empty)
            {
                foreach(var item in DatabaseFirst.Instance.db.Publishers.ToList())
                {
                    _BookVM.LstPublisher.Add(item);
                }
            }
            else
            {
                foreach (var item in DatabaseFirst.Instance.db.Publishers.ToList())
                {
                    if (item.Id.ToLower().Contains(txtSearchPublisher.Text.ToLower()))
                        _BookVM.LstPublisher.Add(item);
                    else if(item.Name.ToLower().Contains(txtSearchPublisher.Text.ToLower()))
                        _BookVM.LstPublisher.Add(item);
                }
            }
        }

        private void txtSearchTranslator_TextChanged(object sender, TextChangedEventArgs e)
        {
            _BookVM.LstTranslator.Clear();

            if (txtSearchTranslator.Text == string.Empty)
            {
                foreach (var item in DatabaseFirst.Instance.db.Translators.Where(i => i.Status).ToList())
                {
                    _BookVM.LstTranslator.Add(item);
                }
            }
            else
            {
                foreach (var item in DatabaseFirst.Instance.db.Translators.Where(i => i.Status).ToList())
                {
                    if (item.Id.ToLower().Contains(txtSearchTranslator.Text.ToLower()))
                        _BookVM.LstTranslator.Add(item);
                    else if (item.Name.ToLower().Contains(txtSearchTranslator.Text.ToLower()))
                        _BookVM.LstTranslator.Add(item);
                    else if(item.boF.ToString("dd/MM/yyyy").Contains(txtSearchTranslator.Text))
                        _BookVM.LstTranslator.Add(item);
                }
            }
        }

        private void txtSearchBookISBN_TextChanged(object sender, TextChangedEventArgs e)
        {
            this._BookISBNTemp.Clear();

            foreach (var item in this._BookISBNInformation)
            {
                if (item.ISBN.ToLower().Contains(txtSearchBookISBN.Text.ToLower()))
                {
                    this._BookISBNTemp.Add(item);
                }
                else if(item.Language.ToLower().Contains(txtSearchBookISBN.Text.ToLower()))
                    this._BookISBNTemp.Add(item);
                else if(item.AuthorName.ToLower().Contains(txtSearchBookISBN.Text.ToLower()))
                    this._BookISBNTemp.Add(item);
            }
        }

        private void txtQuantity_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = sender as TextBox;

            if (textBox.Text == string.Empty)
                return;
            textBox.Text = double.Parse(textBox.Text.Replace(",", "")).ToString("N0");
            textBox.SelectionStart = textBox.Text.Length;
            btnAdd.IsEnabled = _BookVM.IsEnabledAdd;
            string id = txtId.Text.Split('-')[0].Trim();
            id += " - " + (int.Parse(id) + int.Parse(textBox.Text.Replace(",", "")));
            txtId.Text = id;
        }
    }
}
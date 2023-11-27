using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
    /// Interaction logic for ucAddBookTitle.xaml
    /// </summary>
    public partial class ucAddBookTitle : UserControl, INotifyPropertyChanged
    {
        private WindowDefault _Parent;
        private BookTitleManagementRepository _BookTitleManagementRepo = new BookTitleManagementRepository();

        private CategoryViewModel _CategoryVM = new CategoryViewModel();
        private AuthorViewModel _AuthorVM = new AuthorViewModel();
        private BookTitleViewModel _BookTitleVM = new BookTitleViewModel();
        private ObservableCollection<Author> _LstAuthor;

        public event PropertyChangedEventHandler PropertyChanged;

        public string Name { get; set; }
        public string Summary { get; set; }

        private bool _IsEnabled = false;
        public bool isEnabled
        {
            get
            {
                return _IsEnabled;
            }
            set
            {
                _IsEnabled = value;
                OnPropertyChanged();
            }
        }

        public ucAddBookTitle(WindowDefault window)
        {
            InitializeComponent();

            _Parent = window;

            cbCategory.ItemsSource = _CategoryVM.categoryRepo.Items;

            _LstAuthor = new ObservableCollection<Author>(this._AuthorVM.authorRepo.Items);

            dgAuthor.ItemsSource = _LstAuthor;

            DataContext = this;
        }

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private bool IsCheckValidation()
        {
            bool isCheck = true;
            if (StaticValidation.GetValidationRule<InputTextAndNumber>(txtBookTitleName) == null)
                isCheck = false;
            if(StaticValidation.GetValidationRule<InputTextAndNumber>(txtSummary) == null)
                isCheck = false;
            if(dgAuthor.SelectedItem == null)
            {
                tbAuthor.Foreground = Brushes.Red;
                isCheck = false;
            }
            else
            {
                tbAuthor.Foreground = Brushes.White;
            }
            return isCheck;
        }

        private void txtBookTitleName_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (e.Text != string.Empty && char.IsDigit(e.Text[0]))
                e.Handled = true;
        }

        private bool isEmptyTextBox()
        {
            if (txtBookTitleName.Text == string.Empty)
            {
                txtBookTitleName.Focus();
                return true;
            }

            if (txtSummary.Text == string.Empty)
            {
                txtSummary.Focus();
                return true;
            }

            return false;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            //if (isEmptyTextBox())
            //{
            //    MessageBox.Show("Please the text box is not left empty!", "Notify", MessageBoxButton.OK, MessageBoxImage.Warning);
            //    return;
            //}
            //if (dgAuthor.SelectedItem == null)
            //{
            //    MessageBox.Show("Please select an author!", "Notify", MessageBoxButton.OK, MessageBoxImage.Warning);
            //    return;
            //}

            if(!_BookTitleManagementRepo.Add(txtBookTitleName.Text.Trim().ToLower(), (cbCategory.SelectedItem as Category).Id, txtSummary.Text.Trim().ToLower(), (dgAuthor.SelectedItem as Author).Id))
            {
                return;
            }

            _Parent.DialogResult = true;

            _Parent.Close();

            //if (_BookTitleVM.isExist(txtBookTitleName.Text.Trim().ToLower(), (cbCategory.SelectedItem as Category).Id, txtSummary.Text.Trim().ToLower(), (dgAuthor.SelectedItem as Author).Id))
            //{
            //    MessageBox.Show("Book title already exists!", "Notify", MessageBoxButton.OK, MessageBoxImage.Warning);
            //    return;
            //}

            //_BookTitleVM.bookTitleRepo.Add(
            //    (cbCategory.SelectedItem as Category).Id,
            //    txtBookTitleName.Text,
            //    (dgAuthor.SelectedItem as Author).Id,
            //    txtSummary.Text
            //);

            //MessageBox.Show("Book title successfully added!", "Notify", MessageBoxButton.OK, MessageBoxImage.Information);

        }

        private ObservableCollection<Author> GetListAuthorByIdAndName(string text)
        {
            this._LstAuthor.Clear();

            foreach (var item in _AuthorVM.authorRepo.Items)
            {
                if (item.Id.Contains(text.ToUpper()))
                {
                    this._LstAuthor.Add(item);
                }
                else if(item.Name.ToLower().Contains(text.ToLower()))
                {
                    this._LstAuthor.Add(item);
                }
            }

            return this._LstAuthor;
        }

        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            GetListAuthorByIdAndName(txtSearch.Text.Trim());
        }

        private void txtBookTitleName_TextChanged(object sender, TextChangedEventArgs e)
        {
            isEnabled = IsCheckValidation();
        }

        private void dgAuthor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            isEnabled = IsCheckValidation();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            _Parent.DialogResult = false;
            _Parent.Close();
        }
    }
}

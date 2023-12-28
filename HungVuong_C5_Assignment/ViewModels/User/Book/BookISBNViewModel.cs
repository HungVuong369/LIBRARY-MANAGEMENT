using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace HungVuong_C5_Assignment
{
    public class BookISBNViewModel : BaseViewModel
    {
        private bool _IsEnabledAdd = false;
        public bool IsEnabledAdd
        {
            get
            {
                return _IsEnabledAdd;
            }
            set
            {
                _IsEnabledAdd = value;
                OnPropertyChanged();
            }
        }
        public string SelectedLanguage { get; set; }
        public List<string> Languages { get; set; }

        public Author SelectedAuthor { get; set; }
        public BookTitle SelectedBookTitle { get; set; }
        public ObservableCollection<BookTitle> FilterBookTitles { get; private set; }
        public ObservableCollection<Author> FilterAuthors { get; private set; }

        private static readonly UnitOfWork unitOfWork = new UnitOfWork();
        public BookISBNRepository bookISBNRepo { get; set; }

        public RelayCommand<object> AddCommand { get; private set; }
        public RelayCommand<object> CancelCommand { get; private set; }

        public RelayCommand<object> ISBNTextChangedCommand { get; private set; }

        public RelayCommand<object> BookTitleTextChangedCommand { get; private set; }
        public RelayCommand<object> BookTitleSelectionChangedCommand { get; private set; }

        public RelayCommand<object> AuthorTextChangedCommand { get; private set; }
        public RelayCommand<object> AuthorSelectionChangedCommand { get; private set; }

        public WindowDefault Parent;

        public BookISBNViewModel()
        {
            bookISBNRepo = unitOfWork.BookISBNs;
        }

        public BookISBNViewModel(WindowDefault window, TextBox txtISBN, TextBox txtBookTitle, ComboBox cbBookTitle, TextBox txtAuthor, ComboBox cbAuthor)
        {
            Parent = window;

            txtISBN.PreviewTextInput += TxtISBN_PreviewTextInput;

            bookISBNRepo = unitOfWork.BookISBNs;

            Languages = new List<string>();

            Languages.AddRange(DataAccess.GetListLanguage().Select(i => i.Name));
            SelectedLanguage = Languages[0];

            FilterBookTitles = new ObservableCollection<BookTitle>(DatabaseFirst.Instance.db.BookTitles);
            FilterAuthors = new ObservableCollection<Author>(DatabaseFirst.Instance.db.Authors);

            AddCommand = new RelayCommand<object>(
                p => { return true; },
                p => {
                    BookISBNManagementRepository _BookISBNManagementVM = new BookISBNManagementRepository();

                    if (!_BookISBNManagementVM.Add(txtISBN.Text, SelectedLanguage, SelectedBookTitle.Name, SelectedAuthor.Id, SelectedBookTitle.Id))
                    {
                        return;
                    }

                    Parent.DialogResult = true;
                    Parent.Close();
                }
            );

            CancelCommand = new RelayCommand<object>(
                p => { return true; },
                p => {
                    Parent.DialogResult = false;
                    Parent.Close();
                }
            );

            ISBNTextChangedCommand = new RelayCommand<object>(
                p => true,
                p => 
                {
                    if(!txtISBN.Text.Contains("ISBN"))
                    {
                        if(!txtISBN.Text.Contains("I"))
                        {
                            txtISBN.Text = txtISBN.Text.Insert(0, "I");
                        }
                        if (!txtISBN.Text.Contains("S"))
                        {
                            txtISBN.Text = txtISBN.Text.Insert(1, "S");
                        }
                        if (!txtISBN.Text.Contains("B"))
                        {
                            txtISBN.Text = txtISBN.Text.Insert(2, "B");
                        }
                        if (!txtISBN.Text.Contains("N"))
                        {
                            txtISBN.Text = txtISBN.Text.Insert(3, "N");
                        }
                    }

                    txtISBN.SelectionStart = txtISBN.Text.Length;

                    IsEnabledAdd = IsCheckEnabledAdd(txtISBN.Text);
                }
            );

            BookTitleTextChangedCommand = new RelayCommand<object>(
                p => true,
                p =>
                {
                    SelectedBookTitle = null;

                    FilterBookTitles.Clear();

                    foreach(var item in DatabaseFirst.Instance.db.BookTitles.Where(i => i.Name.ToLower().Contains(txtBookTitle.Text.ToLower())))
                    {
                        FilterBookTitles.Add(item);
                    }

                    if(FilterBookTitles.Count == 0)
                    {
                        cbBookTitle.IsDropDownOpen = false;
                    }
                    else if(FilterBookTitles.Count == 1)
                    {
                        if (FilterBookTitles.FirstOrDefault().Name.ToLower() == txtBookTitle.Text.Trim().ToLower())
                        {
                            SelectedBookTitle = FilterBookTitles.FirstOrDefault();
                        }
                        cbBookTitle.IsDropDownOpen = true;
                    }
                    else if(FilterBookTitles.Count != 0)
                    {
                        cbBookTitle.IsDropDownOpen = true;
                    }

                    IsEnabledAdd = IsCheckEnabledAdd(txtISBN.Text);
                }
            );

            BookTitleSelectionChangedCommand = new RelayCommand<object>(
                p => true,
                p =>
                {
                    if (cbBookTitle.SelectedIndex == -1)
                    {
                        IsEnabledAdd = IsCheckEnabledAdd(txtISBN.Text);
                        return;
                    }

                    var bookTitle = cbBookTitle.SelectedItem as BookTitle;

                    txtBookTitle.Text = bookTitle.Name;

                    cbBookTitle.SelectedIndex = -1;

                    SelectedBookTitle = bookTitle;

                    IsEnabledAdd = IsCheckEnabledAdd(txtISBN.Text);
                }
            );

            AuthorTextChangedCommand = new RelayCommand<object>(
                p => true,
                p =>
                {
                    FilterAuthors.Clear();

                    SelectedAuthor = null;

                    foreach (var item in DatabaseFirst.Instance.db.Authors.Where(i => i.Name.ToLower().Contains(txtAuthor.Text.ToLower())))
                    {
                        FilterAuthors.Add(item);
                    }

                    if (FilterAuthors.Count == 0)
                    {
                        cbAuthor.IsDropDownOpen = false;
                    }
                    else if (FilterAuthors.Count == 1)
                    {
                        if(FilterAuthors.FirstOrDefault().Name.ToLower() == txtAuthor.Text.Trim().ToLower())
                        {
                            SelectedAuthor = FilterAuthors.FirstOrDefault();
                        }
                        cbAuthor.IsDropDownOpen = true;
                    }
                    else if (FilterAuthors.Count != 0)
                    {
                        cbAuthor.IsDropDownOpen = true;
                    }

                    IsEnabledAdd = IsCheckEnabledAdd(txtISBN.Text);
                }
            );

            AuthorSelectionChangedCommand = new RelayCommand<object>(
                p => true,
                p =>
                {
                    if (cbAuthor.SelectedIndex == -1)
                    {
                        IsEnabledAdd = IsCheckEnabledAdd(txtISBN.Text);
                        return;
                    }

                    var author = cbAuthor.SelectedItem as Author;

                    txtAuthor.Text = author.Name;

                    cbAuthor.SelectedIndex = -1;

                    SelectedAuthor = author;

                    IsEnabledAdd = IsCheckEnabledAdd(txtISBN.Text);
                }
            );
        }

        private bool IsCheckEnabledAdd(string isbn)
        {
            bool isEnabled = true;

            if(isbn == string.Empty)
            {
                isEnabled = false;
            }

            else if(SelectedAuthor == null)
            {
                isEnabled = false;
            }

            else if(SelectedBookTitle == null)
            {
                isEnabled = false;
            }

            return isEnabled;
        }

        private void TxtISBN_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            if (e.Text == string.Empty)
                return;

            TextBox txtISBN = sender as TextBox;

            if (txtISBN.Text.Contains("ISBN") && txtISBN.SelectionStart < 4)
                e.Handled = true;

            else if (!char.IsDigit(e.Text[0]) && e.Text[0] != '-')
                e.Handled = true;

            if (txtISBN.Text.LastOrDefault() == '-' && e.Text[0] == '-')
                e.Handled = true;
        }

        public bool isExist(string bookTitleName, string authorID)
        {
            BookTitleViewModel bookTitleVM = new BookTitleViewModel();
            AuthorViewModel authorVM = new AuthorViewModel();

            foreach (var item in this.bookISBNRepo.Items)
            {
                if (bookTitleVM.bookTitleRepo.GetById(item.IdBookTitle).Name == bookTitleName && item.IdAuthor.ToLower() == authorID.ToLower())
                    return true;
            }
            return false;
        }
    }
}

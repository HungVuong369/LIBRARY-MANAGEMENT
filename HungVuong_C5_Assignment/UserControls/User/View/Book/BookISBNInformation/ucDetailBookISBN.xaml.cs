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
    /// Interaction logic for ucDetailBookISBN.xaml
    /// </summary>
    public partial class ucDetailBookISBN : UserControl
    {
        private CategoryViewModel _CategoryVM = new CategoryViewModel();
        private BookISBNViewModel _BookIsbnVM = new BookISBNViewModel();
        private BookTitleViewModel _BookTitleVM = new BookTitleViewModel();
        private AuthorViewModel _AuthorVM = new AuthorViewModel();
        private BookViewModel _BookVM = new BookViewModel();

        public BookTitle BookTitle { get; set; }
        public Author Translator { get; set; }
        public Category Category { get; set; }
        public BookISBN BookISBN { get; set; }
        public int QuantityBook { get; set; }

        public ucDetailBookISBN(string isbn)
        {
            InitializeComponent();

            BookISBN = this._BookIsbnVM.bookISBNRepo.GetByISBN(isbn);

            this.BookTitle = BookISBN.BookTitle;

            this.Category = BookISBN.BookTitle.Category;

            this.Translator = BookISBN.Author;

            this.QuantityBook = _BookVM.GetQuantityBookByISBN(isbn, true);

            DataContext = this;
        }
    }
}

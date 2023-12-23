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
        private BookISBNViewModel _BookIsbnVM = new BookISBNViewModel();
        public BookISBN BookISBN { get; set; }

        public ucDetailBookISBN(string isbn)
        {
            InitializeComponent();

            BookISBN = _BookIsbnVM.bookISBNRepo.Items.FirstOrDefault(i => i.ISBN == isbn);

            // ISBN
            txtISBN.Text = BookISBN.ISBN;
            txtLanguage.Text = BookISBN.OriginLanguage;
            txtISBNStatus.Text = BookISBN.Status == true ? "Available" : "Unavailable";
            txtISBNStatus.Foreground = BookISBN.Status == true ? Brushes.Green : Brushes.Red;

            // Title
            txtBookTitleID.Text = BookISBN.BookTitle.Id;
            txtBookTitleName.Text = BookISBN.BookTitle.Name;
            txtCategory.Text = BookISBN.BookTitle.Category.Name;
            txtSummary.Text = BookISBN.BookTitle.Summary;

            // Author
            txtAuthorBoF.Text = BookISBN.Author.boF.ToString("dd/MM/yyyy");
            txtAuthorID.Text = BookISBN.Author.Id;
            txtAuthorName.Text = BookISBN.Author.Name;
            txtAuthorSummary.Text = BookISBN.Author.Summary;
            txtDescription.Text = BookISBN.Author.Description;
            txtAuthorStatus.Text = BookISBN.Author.Status == true ? "Available" : "Unavailable";
            txtAuthorStatus.Foreground = BookISBN.Author.Status == true ? Brushes.Green : Brushes.Red;
        }
    }
}

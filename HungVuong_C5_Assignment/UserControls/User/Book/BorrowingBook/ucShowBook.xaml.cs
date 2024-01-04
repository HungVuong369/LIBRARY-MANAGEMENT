using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
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
    /// Interaction logic for ucShowBook.xaml
    /// </summary>
    public partial class ucShowBook : UserControl, INotifyPropertyChanged
    {
        public BookISBN BookISBN;
        private Grid _Grid;

        private int _SubtractNumber = 0;

        public event PropertyChangedEventHandler PropertyChanged;

        private int _Quantity = 0;
        public int Quantity
        {
            get
            {
                return _Quantity;
            }
            set
            {
                _Quantity = value;
                OnPropertyChanged();
            }
        }

        private string _UrlImage;

        public ucShowBook(BookISBN bookISBN, int subtractNumber, string urlImage)
        {
            InitializeComponent();
            this._UrlImage = urlImage;
            this.BookISBN = bookISBN;
            this.DataContext = ShowBooksViewModel.Instance;
            this._SubtractNumber = subtractNumber;
            tbQuantity.DataContext = this;

            _Grid = grdContainer;

            gbContainer.Header = BookISBN.ISBN;

            Quantity = BookISBN.Books.Where(i => i.Status == true).Count() - _SubtractNumber;

            _Grid.DataContext = BookISBN;
        }

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private void GroupBox_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            gbContainer.Tag = this;
        }

        private void Image_Loaded(object sender, RoutedEventArgs e)
        {
            Image image = sender as Image;

            string projectDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;

            image.Source = new BitmapImage(new Uri(projectDirectory + _UrlImage.Replace(@"/", @"\"), UriKind.RelativeOrAbsolute));
        }
    }
}

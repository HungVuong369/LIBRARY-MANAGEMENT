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
    /// Interaction logic for ucStatusBookISBN.xaml
    /// </summary>
    public partial class ucStatusBookISBN : UserControl
    {
        // Not Used
        private BookViewModel _BookVM = new BookViewModel();
        private BookISBNViewModel _BookIsbnVM = new BookISBNViewModel();
        private List<BookISBNStatus> _BookISBNStatus = DataAccess.GetListBookISBNStatus();

        public ucStatusBookISBN()
        {
            InitializeComponent();
            dgBookISBN.ItemsSource = this._BookISBNStatus;
        }

        //private void btnUpdateStatus_Click(object sender, RoutedEventArgs e)
        //{
        //    string isbn = (sender as Button).Tag.ToString();

        //    var bookISBNStatus = dgBookISBN.SelectedItem as BookISBNStatus;

        //    if(bookISBNStatus.Status == "Yes")
        //    {
        //        int quantity = _BookVM.GetQuantityBookByISBN(isbn, true);

        //        if (MessageBox.Show($"You have '{quantity}' books with the ISBN '{isbn}'. Are you sure you want to update their status?", "Notify", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
        //        {
        //            _BookVM.bookRepo.UpdateStatusByISBN(0, isbn);
        //            _BookIsbnVM.bookISBNRepo.UpdateStatusByISBN(0, isbn);
        //            bookISBNStatus.Status = "No";
        //            MessageBox.Show("Update successful!", "Notify", MessageBoxButton.OK, MessageBoxImage.Information);
        //        }
        //    }
        //    else
        //    {
        //        int quantity = _BookVM.GetQuantityBookByISBN(isbn, false);

        //        if(quantity == 0)
        //        {
        //            MessageBox.Show("couldn't find the book!", "Notify", MessageBoxButton.OK, MessageBoxImage.Warning);
        //            return;
        //        }

        //        if (MessageBox.Show($"You have '{quantity}' books with the ISBN '{isbn}'. Are you sure you want to update their status?", "Notify", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
        //        {
        //            _BookVM.bookRepo.UpdateStatusByISBN(1, isbn);
        //            _BookIsbnVM.bookISBNRepo.UpdateStatusByISBN(1, isbn);
        //            bookISBNStatus.Status = "Yes";
        //            MessageBox.Show("Update successful!", "Notify", MessageBoxButton.OK, MessageBoxImage.Information);
        //        }
        //    }
        //}
    }
}

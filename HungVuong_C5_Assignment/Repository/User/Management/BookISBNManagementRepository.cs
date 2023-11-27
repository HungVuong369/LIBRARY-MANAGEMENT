using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HungVuong_C5_Assignment
{
    public class BookISBNManagementRepository
    {
        private BookISBNViewModel _BookISBNVM = new BookISBNViewModel();

        public bool Add(string language, string bookTitleName, DateTime publishDate, string authorID, string bookTitleID, string publisherID, decimal bookPrice)
        {
            if(bookPrice <= 0)
            {
                MessageBox.Show("Invalid book price!", "Notify", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
            if (this._BookISBNVM.isExist(language, bookTitleName))
            {
                MessageBox.Show("Book ISBN Existed!", "Notify", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            this._BookISBNVM.bookISBNRepo.Add(language, publishDate, authorID, bookTitleID, publisherID, bookPrice);

            DatabaseFirst.Instance.SaveChanged();

            MessageBox.Show("Add Book ISBN Successfully!!", "Notify", MessageBoxButton.OK, MessageBoxImage.Information);

            return true;
        }
    }
}

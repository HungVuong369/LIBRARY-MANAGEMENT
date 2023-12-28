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

        public bool Add(string isbn, string language, string bookTitleName, string authorID, string bookTitleID)
        {
            // Check book title and author is existed.
            if (this._BookISBNVM.isExist(bookTitleName, authorID))
            {
                MessageBox.Show("Book ISBN Existed!", "Notify", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            if(DatabaseFirst.Instance.db.BookISBNs.FirstOrDefault(i => i.ISBN.ToLower() == isbn.Trim().ToLower()) != null)
            {
                MessageBox.Show("ISBN Existed!", "Notify", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            this._BookISBNVM.bookISBNRepo.Add(language, authorID, bookTitleID);

            DatabaseFirst.Instance.SaveChanged();

            MessageBox.Show("Add Book ISBN Successfully!!", "Notify", MessageBoxButton.OK, MessageBoxImage.Information);

            return true;
        }
    }
}

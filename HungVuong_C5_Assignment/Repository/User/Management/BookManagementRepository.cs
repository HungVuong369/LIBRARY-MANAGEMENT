using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HungVuong_C5_Assignment
{
    public class BookManagementRepository
    {
        private BookViewModel _BookVM = new BookViewModel();
        private BookISBNViewModel _BookISBNVM = new BookISBNViewModel();
        private ParameterViewModel _ParameterVM = new ParameterViewModel();

        private void UpdateStatusBookISBN(string isbn)
        {
            if (_BookVM.bookRepo.Items.LastOrDefault().BookISBN.Status == false)
            {
                _BookISBNVM.bookISBNRepo.UpdateStatusByISBN(1, isbn);
                DatabaseFirst.Instance.SaveChanged();
            }
        }

        public bool Add(string isbn, string publisherID, string translatorID, string language, DateTime publishDate, decimal price, int quantity)
        {
            BookISBNViewModel bookISBNVM = new BookISBNViewModel();
            if(bookISBNVM.bookISBNRepo.Items.FirstOrDefault(i => i.ISBN == isbn).OriginLanguage == language)
            {
                MessageBox.Show("The language already exists in the Book ISBN", "Notify", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
            this._BookVM.bookRepo.Add(isbn, publisherID, translatorID, language, publishDate, price, quantity);

            DatabaseFirst.Instance.SaveChanged();

            UpdateStatusBookISBN(isbn);

            return true;
        }
    }
}

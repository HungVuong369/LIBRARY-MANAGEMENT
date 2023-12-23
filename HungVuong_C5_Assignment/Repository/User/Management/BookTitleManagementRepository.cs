using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HungVuong_C5_Assignment
{
    public class BookTitleManagementRepository
    {
        private BookTitleViewModel _BookTitleVM = new BookTitleViewModel();

        public bool Add(string bookTitleName, string categoryID, string summary)
        {
            if (_BookTitleVM.isExist(bookTitleName.Trim().ToLower(), categoryID, summary.Trim().ToLower()))
            {
                MessageBox.Show("Book title already exists!", "Notify", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            _BookTitleVM.bookTitleRepo.Add(
                categoryID,
                bookTitleName,
                summary
            );

            DatabaseFirst.Instance.SaveChanged();

            MessageBox.Show("Book title successfully added!", "Notify", MessageBoxButton.OK, MessageBoxImage.Information);

            return true;
        }
    }
}

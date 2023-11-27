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
        private EnrolViewModel _EnrollVM = new EnrolViewModel();
        private ParameterViewModel _ParameterVM = new ParameterViewModel();

        private void UpdateEnroll(string isbn)
        {
            // Duyệt xem có Enroll nào có cùng ISBN, có được danh sách Enrolls
            // Duyệt xem Enroll nào có EnrolDate sớm nhất
            // Tiến hành gán IdBook, ExpiryDate cho Enroll đó
            // Save changed

            var enroll = _EnrollVM.enrolRepo.Items.Where(i => i.ISBN == isbn && i.IdBook == null).OrderBy(i => i.EnrolDate).FirstOrDefault();

            if (enroll == null)
                return;

            enroll.IdBook = _BookVM.bookRepo.Items.LastOrDefault().Id;
            enroll.ExpiryDate = DateTime.Now.AddDays(int.Parse(_ParameterVM.GetValueByID("QD10")));
            DatabaseFirst.Instance.SaveChanged();
        }

        private void UpdateStatusBookISBN(string isbn)
        {
            if (_BookVM.bookRepo.Items.LastOrDefault().BookISBN.Status == false)
            {
                _BookISBNVM.bookISBNRepo.UpdateStatusByISBN(1, isbn);
                DatabaseFirst.Instance.SaveChanged();
            }
        }

        public bool Add(string isbn, decimal bookPrice)
        {
            decimal priceBookISBN = _BookISBNVM.bookISBNRepo.GetByISBN(isbn).BookPrice;

            if (bookPrice <= priceBookISBN)
            {
                MessageBox.Show("Invalid Book Price", "Notify", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            this._BookVM.bookRepo.Add(isbn, bookPrice);

            DatabaseFirst.Instance.SaveChanged();

            UpdateStatusBookISBN(isbn);

            UpdateEnroll(isbn);

            return true;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HungVuong_C5_Assignment
{
    public class BookISBNViewModel
    {
        private static readonly UnitOfWork unitOfWork = new UnitOfWork();
        public BookISBNRepository bookISBNRepo { get; set; }

        public BookISBNViewModel()
        {
            bookISBNRepo = unitOfWork.BookISBNs;
        }

        public bool isExist(string language, string bookTitleName)
        {
            BookTitleViewModel bookTitleVM = new BookTitleViewModel();

            foreach (var item in this.bookISBNRepo.Items)
            {
                if (item.Language == language && bookTitleVM.bookTitleRepo.GetById(item.IdBookTitle).Name == bookTitleName)
                    return true;
            }
            return false;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HungVuong_C5_Assignment
{
    public class BookTitleViewModel
    {
        private static readonly UnitOfWork unitOfWork = new UnitOfWork();
        public BookTitleRepository bookTitleRepo;

        public BookTitleViewModel()
        {
            bookTitleRepo = unitOfWork.BookTitles;
        }

        public bool isExist(string name, string categoryID, string summary, string authorID)
        {
            foreach(var item in bookTitleRepo.Items)
            {
                if (item.Name.ToLower() == name && item.IdCategory == categoryID && item.Summary.ToLower() == summary && item.IdAuthor == authorID)
                    return true;
            }
            return false;
        }
    }
}

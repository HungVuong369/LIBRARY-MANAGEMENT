using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HungVuong_C5_Assignment
{
    public class BookViewModel
    {
        private static readonly UnitOfWork unitOfWork = new UnitOfWork();
        public BookRepository bookRepo;

        public BookViewModel()
        {
            this.bookRepo = unitOfWork.Books;
        }

        public int GetQuantityBookByISBN(string isbn, bool status)
        {
            int quantity = 0;

            foreach(var item in bookRepo.Items)
            {
                if(status)
                {
                    if (item.ISBN == isbn && item.Status)
                        quantity++;
                }
                else
                {
                    if (item.ISBN == isbn && !item.Status)
                        quantity++;
                }
            }
            return quantity;
        }
    }
}

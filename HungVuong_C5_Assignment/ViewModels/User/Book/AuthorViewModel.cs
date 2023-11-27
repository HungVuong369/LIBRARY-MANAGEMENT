using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HungVuong_C5_Assignment
{
    public class AuthorViewModel
    {
        private static readonly UnitOfWork unitOfWork = new UnitOfWork();
        public AuthorRepository authorRepo { get; set; }

        public AuthorViewModel()
        {
            authorRepo = unitOfWork.Authors;
        }
    }
}

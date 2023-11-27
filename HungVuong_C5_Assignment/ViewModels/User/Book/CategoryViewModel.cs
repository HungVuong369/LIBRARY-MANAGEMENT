using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HungVuong_C5_Assignment
{
    public class CategoryViewModel
    {
        private static readonly UnitOfWork unitOfWork = new UnitOfWork();
        public CategoryRepository categoryRepo;

        public CategoryViewModel()
        {
            categoryRepo = unitOfWork.Categories;
        }
    }
}

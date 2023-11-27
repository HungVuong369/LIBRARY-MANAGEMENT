using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HungVuong_C5_Assignment
{
    public class RoleFunctionViewModel
    {
        private static readonly UnitOfWork unitOfWork = new UnitOfWork();
        public RoleFunctionRepository roleFunctionRepo;

        public RoleFunctionViewModel()
        {
            this.roleFunctionRepo = unitOfWork.RoleFunctions;
        }
    }
}

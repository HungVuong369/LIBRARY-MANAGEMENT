using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HungVuong_C5_Assignment
{
    public class LoanSlipViewModel
    {
        private static readonly UnitOfWork unitOfWork = new UnitOfWork();
        public LoanSlipRepository loanSlipRepo;

        public LoanSlipViewModel()
        {
            this.loanSlipRepo = unitOfWork.Loanslips;
        }
    }
}

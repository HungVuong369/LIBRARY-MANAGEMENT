using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HungVuong_C5_Assignment
{
    public class LoanDetailHistoryViewModel
    {
        private static readonly UnitOfWork unitOfWork = new UnitOfWork();
        public LoanDetailHistoryRepository loanDetailHistoryRepo;

        public LoanDetailHistoryViewModel()
        {
            this.loanDetailHistoryRepo = unitOfWork.LoanDetailHistories;
        }
    }
}

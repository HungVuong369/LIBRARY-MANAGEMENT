using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HungVuong_C5_Assignment
{
    public class LoanManagementRepository
    {
        private LoanSlipViewModel _LoanSlipVM = new LoanSlipViewModel();
        private LoanDetailViewModel _LoanDetailVM = new LoanDetailViewModel();

        public LoanManagementRepository()
        {
        }

        public void Add(LoanSlip loanSlip, List<LoanDetail> lstLoanDetail)
        {
            _LoanSlipVM.loanSlipRepo.Add(loanSlip);
            lstLoanDetail.ForEach(i => _LoanDetailVM.loanDetailRepo.Add(i));

            DatabaseFirst.Instance.SaveChanged();
        }
    }
}

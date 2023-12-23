using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HungVuong_C5_Assignment
{
    public class LoanHistoryManagementRepository
    {
        private LoanHistoryViewModel _LoanHistoryVM = new LoanHistoryViewModel();
        private LoanDetailHistoryViewModel _LoanDetailHistoryVM = new LoanDetailHistoryViewModel();
        private LoanDetailViewModel _LoanDetailVM = new LoanDetailViewModel();
        private LoanSlipViewModel _LoanSlipVM = new LoanSlipViewModel();

        public void Add(LoanHistory loanHistory, List<LoanDetailHistory> loanDetailHistories, LoanSlip loanSlip)
        {
            _LoanHistoryVM.loanHistoryRepo.Add(loanHistory);
            loanDetailHistories.ForEach(i => _LoanDetailHistoryVM.loanDetailHistoryRepo.Add(i));

            foreach (var item in loanSlip.LoanDetails.ToList()) {

                _LoanDetailVM.loanDetailRepo.Remove(item);
            }  

            _LoanSlipVM.loanSlipRepo.Remove(loanSlip);

            DatabaseFirst.Instance.SaveChanged();
        }
    }
}

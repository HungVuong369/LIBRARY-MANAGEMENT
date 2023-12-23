using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HungVuong_C5_Assignment
{
    public class PenaltyReasonViewModel
    {
        private static readonly UnitOfWork unitOfWork = new UnitOfWork();
        public PenaltyReasonRepository roleRepo;

        public PenaltyReasonViewModel()
        {
            this.roleRepo = unitOfWork.PenaltyReasons;
        }
    }
}

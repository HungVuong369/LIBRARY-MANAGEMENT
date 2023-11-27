using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HungVuong_C5_Assignment
{
    public class EnrolViewModel
    {
        private static readonly UnitOfWork unitOfWork = new UnitOfWork();
        public EnrolRepository enrolRepo;

        public EnrolViewModel()
        {
            this.enrolRepo = unitOfWork.Enrols;
        }

    }
}

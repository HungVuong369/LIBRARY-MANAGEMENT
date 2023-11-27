using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HungVuong_C5_Assignment
{
    public class AdultViewModel
    {
        private static readonly UnitOfWork unitOfWork = new UnitOfWork();
        public AdultRepository adultRepo { get; set; }

        public AdultViewModel()
        {
            adultRepo = unitOfWork.Adults;
        }

        public bool IsExistIdentify(string identify)
        {
            var check = DatabaseFirst.Instance.db.Adults.FirstOrDefault(i => i.Identify == identify);

            if (check == null)
                return false;
            return true;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HungVuong_C5_Assignment
{
    public class LoanSlipRepository : RepositoryBase<LoanSlip>
    {
        public LoanSlipRepository()
        {
            Items = new List<LoanSlip>();
        }

        public List<LoanSlip> Load()
        {
            Items.Clear();

            Items.AddRange(DatabaseFirst.Instance.db.LoanSlips);

            return Items;
        }

        public static string GetNewID()
        {
            string id = "L";

            var number = DatabaseFirst.Instance.db.LoanSlips.Select(i => i.Id.Substring(1)).AsEnumerable().Select(num => int.Parse(num)).DefaultIfEmpty().Max() + 1;

            if (number <= 9)
                id += "0" + number;
            else
                id += number;

            return id;
        }

        public void Add(LoanSlip newLoanSlip)
        {
            Items.Add(newLoanSlip);

            DatabaseFirst.Instance.db.LoanSlips.Add(newLoanSlip);
        }

        public LoanSlip GetByID(string id) => Items.Find(e => e.Id.CompareTo(id) == 0);
    }

}
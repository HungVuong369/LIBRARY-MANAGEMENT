using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HungVuong_C5_Assignment
{
    public class LoanDetailRepository : RepositoryBase<LoanDetail>
    {
        public LoanDetailRepository()
        {
            Items = new List<LoanDetail>();
        }

        public List<LoanDetail> Load()
        {
            Items.Clear();

            Items.AddRange(DatabaseFirst.Instance.db.LoanDetails);

            return Items;
        }

        public static string GetNewID()
        {
            string id = "LDT";

            var number = DatabaseFirst.Instance.db.LoanDetails.Local.Select(i => i.Id.Substring(3)).AsEnumerable().Select(num => int.Parse(num)).DefaultIfEmpty().Max() + 1;
            
            if (number <= 9)
                id += "0" + number;
            else
                id += number;

            return id;
        }

        public void Add(LoanDetail loanDetail)
        {
            Items.Add(loanDetail);

            DatabaseFirst.Instance.db.LoanDetails.Add(loanDetail);
        }

        public LoanDetail GetByID(string id) => Items.Find(e => e.Id.CompareTo(id) == 0);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HungVuong_C5_Assignment
{
    public class LoanHistoryRepository : RepositoryBase<LoanHistory>
    {
        public LoanHistoryRepository()
        {
            Items = new List<LoanHistory>();
        }

        public List<LoanHistory> Load()
        {
            Items.Clear();

            Items.AddRange(DatabaseFirst.Instance.db.LoanHistories);

            return Items;
        }

        public static string GetNewID()
        {
            string id = "LH";

            var number = DatabaseFirst.Instance.db.LoanHistories.Select(i => i.Id.Substring(2)).AsEnumerable().Select(num => int.Parse(num)).DefaultIfEmpty().Max() + 1;

            if (number <= 9)
                id += "0" + number;
            else
                id += number;

            return id;
        }

        public LoanHistory GetByID(string id) => Items.Find(e => e.Id.CompareTo(id) == 0);

        public void Add(LoanHistory loanHistory)
        {
            Items.Add(loanHistory);
            DatabaseFirst.Instance.db.LoanHistories.Add(loanHistory);
        }
    }
}

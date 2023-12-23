using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HungVuong_C5_Assignment
{
    public class PenaltyReasonRepository : RepositoryBase<PenaltyReason>
    {
        public PenaltyReasonRepository()
        {
            Items = new List<PenaltyReason>();
        }

        public List<PenaltyReason> Load()
        {
            Items.Clear();

            Items.AddRange(DatabaseFirst.Instance.db.PenaltyReasons);

            return Items;
        }

        public string GetNewID()
        {
            string id = "PR";

            var number = DatabaseFirst.Instance.db.PenaltyReasons.Select(i => i.Id.Substring(id.Length)).AsEnumerable().Select(num => int.Parse(num)).DefaultIfEmpty().Max() + 1;

            if (number <= 9)
                id += "0" + number;
            else
                id += number;

            return id;
        }

        public PenaltyReason GetByID(string id) => Items.Find(e => e.Id.CompareTo(id) == 0);

    }
}

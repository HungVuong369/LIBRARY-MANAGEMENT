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

        public static string GetNewID()
        {
            string id = "PR";

            var number = DatabaseFirst.Instance.db.PenaltyReasons.Select(i => i.Id.Substring(id.Length)).AsEnumerable().Select(num => int.Parse(num)).DefaultIfEmpty().Max() + 1;

            id += number;

            return id;
        }

        public void Add(PenaltyReason newPenaltyReason)
        {
            Items.Add(newPenaltyReason);

            DatabaseFirst.Instance.db.PenaltyReasons.Add(newPenaltyReason);
        }

        public void Remove(PenaltyReason PenaltyReason)
        {
            Items.Remove(PenaltyReason);

            DatabaseFirst.Instance.db.PenaltyReasons.Remove(PenaltyReason);
        }

        public void Update(PenaltyReason PenaltyReason, PenaltyReason newPenaltyReason)
        {
            PenaltyReason.Name = newPenaltyReason.Name;
            PenaltyReason.Description = newPenaltyReason.Description;
            PenaltyReason.Price = newPenaltyReason.Price;
            PenaltyReason.CreatedAt = newPenaltyReason.CreatedAt;
            PenaltyReason.ModifiedAt = newPenaltyReason.ModifiedAt;

            var item = DatabaseFirst.Instance.db.PenaltyReasons.FirstOrDefault(i => i.Id == PenaltyReason.Id);

            item.Name = newPenaltyReason.Name;
            item.Description = newPenaltyReason.Description;
            item.Price = newPenaltyReason.Price;
            item.CreatedAt = newPenaltyReason.CreatedAt;
            item.ModifiedAt = newPenaltyReason.ModifiedAt;
        }

        public PenaltyReason GetByID(string id) => Items.Find(e => e.Id.CompareTo(id) == 0);

    }
}

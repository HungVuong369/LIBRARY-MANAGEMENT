using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HungVuong_C5_Assignment
{
    public class EnrolRepository : RepositoryBase<Enroll>
    {
        public EnrolRepository()
        {
            Items = new List<Enroll>();
        }

        public List<Enroll> Load()
        {
            Items.Clear();

            Items.AddRange(DatabaseFirst.Instance.db.Enrolls);

            return Items;
        }

        public static string GetNewID()
        {
            string id = "E";

            var number = DatabaseFirst.Instance.db.Enrolls.Local.Select(i => i.Id.Substring(1)).AsEnumerable().Select(num => int.Parse(num)).DefaultIfEmpty().Max() + 1;

            if (number <= 9)
                id += "0" + number;
            else
                id += number;

            return id;
        }

        public void Add(Enroll enrol)
        {
            DatabaseFirst.Instance.db.Enrolls.Add(enrol);
            Items.Add(enrol);
        }

        public Enroll GetByID(string id) => Items.Find(e => e.Id.CompareTo(id) == 0);
    }
}

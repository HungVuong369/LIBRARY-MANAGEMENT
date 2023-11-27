using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HungVuong_C5_Assignment
{
    public class PublisherRepository : RepositoryBase<Publisher>
    {
        public PublisherRepository()
        {
            Items = new List<Publisher>();
        }

        public List<Publisher> Load()
        {
            Items.Clear();

            Items.AddRange(DatabaseFirst.Instance.db.Publishers);

            return Items;
        }

        public string GetNewID()
        {
            string id = "P";

            var number = DatabaseFirst.Instance.db.Publishers.Select(i => i.Id.Substring(1)).AsEnumerable().Select(num => int.Parse(num)).DefaultIfEmpty().Max() + 1;

            if (number <= 9)
                id += "0" + number;
            else
                id += number;

            return id;
        }

        public Publisher GetByID(string id) => Items.Find(e => e.Id.CompareTo(id) == 0);
    }
}

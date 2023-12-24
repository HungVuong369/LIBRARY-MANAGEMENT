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

        public void Add(Publisher newPublisher)
        {
            Items.Add(newPublisher);

            DatabaseFirst.Instance.db.Publishers.Add(newPublisher);
        }

        public void Remove(Publisher publisher)
        {
            Items.Remove(publisher);

            DatabaseFirst.Instance.db.Publishers.Remove(publisher);
        }

        public void Update(Publisher publisher, Publisher newPublisher)
        {
            publisher.Name = newPublisher.Name;
            publisher.Phone = newPublisher.Phone;
            publisher.Address = newPublisher.Address;

            var item = DatabaseFirst.Instance.db.Publishers.FirstOrDefault(i => i.Id == publisher.Id);

            item.Name = newPublisher.Name;
            item.Phone = newPublisher.Phone;
            item.Address = newPublisher.Address;
        }

        public static string GetNewID()
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

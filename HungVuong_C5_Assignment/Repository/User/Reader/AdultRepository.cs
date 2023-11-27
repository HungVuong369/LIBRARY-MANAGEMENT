using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HungVuong_C5_Assignment
{
    public class AdultRepository : RepositoryBase<Adult>, IRepositoryBase<Adult>
    {
        public AdultRepository()
        {
            Items = new List<Adult>();
        }

        public List<Adult> Load(bool status)
        {
            Items.Clear();

            Items.AddRange(DatabaseFirst.Instance.db.Adults.Where(i => i.Status == status));

            return Items;
        }

        public void Add(string identify, string address, string city, string phone, DateTime expDate, bool status, DateTime createdAt, DateTime modifiedAt)
        {
            string newID = ReaderRepository.GetNewID();
            var newAdult = new Adult()
            {
                Address = address,
                City = city,
                CreatedAt = createdAt,
                IdReader = newID,
                Identify = identify,
                ModifiedAt = modifiedAt,
                Phone = phone,
                ExpireDate = expDate,
                Status = true
            };

            DatabaseFirst.Instance.db.Adults.Add(newAdult);
            Items.Add(newAdult);
        }

        public void RemoveByIdReader(string id)
        {
            var item = DatabaseFirst.Instance.db.Adults.FirstOrDefault(i => i.IdReader == id);
            item.Status = false;
            Items.Remove(GetByIdReader(id));
        }

        public void Restore(Adult adult)
        {
            var item = DatabaseFirst.Instance.db.Adults.FirstOrDefault(i => i.IdReader == adult.IdReader);
            item.Status = true;
            Items.Remove(GetByIdReader(adult.IdReader));
        }

        public Adult GetByIdReader(string IdReader) => Items.Find(e => e.IdReader.CompareTo(IdReader) == 0);

        public void Delete(string id)
        {
            var entity = Items.Where(e => e.IdReader.CompareTo(id) == 0).FirstOrDefault();
            Items.Remove(entity);
        }
    }
}

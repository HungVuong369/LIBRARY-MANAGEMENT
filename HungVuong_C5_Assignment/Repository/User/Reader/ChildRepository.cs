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
    public class ChildRepository : RepositoryBase<Child>, IRepositoryBase<Child>
    {
        public ChildRepository()
        {
            Items = new List<Child>();
        }

        public List<Child> Load(bool status)
        {
            Items.Clear();

            Items.AddRange(DatabaseFirst.Instance.db.Children.Include("Reader").Include("Adult").Where(i => i.Status == status));

            return Items;
        }

        public void Add(string adultID)
        {
            string newID = ReaderRepository.GetNewID();

            var newChild = new Child()
            {
                CreatedAt = DateTime.Now,
                ModifiedAt = DateTime.Now,
                IdAdult = adultID,
                Status = true,
                IdReader = newID
            };

            Items.Add(newChild);

            DatabaseFirst.Instance.db.Children.Add(newChild);
        }

        public void RemoveByIdReader(string id)
        {
            var item = DatabaseFirst.Instance.db.Children.FirstOrDefault(i => i.IdReader == id);
            item.Status = false;
            Items.Remove(GetByIdReader(id));
        }

        public void DeleteByIdReader(string id)
        {
            Items.Remove(GetByIdReader(id));
            var item = DatabaseFirst.Instance.db.Children.FirstOrDefault(i => i.IdReader == id);
            DatabaseFirst.Instance.db.Children.Remove(item);
        }

        public void Restore(Child child)
        {
            var item = DatabaseFirst.Instance.db.Children.FirstOrDefault(i => i.IdReader == child.IdReader);
            item.Status = true;
            Items.Remove(GetByIdReader(child.IdReader));
        }

        public void TransitionChild(string childIdReader, string adultIdReader)
        {
            var itemDB = DatabaseFirst.Instance.db.Children.FirstOrDefault(i => i.IdReader == childIdReader);
            itemDB.IdAdult = adultIdReader;

            Child item = Items.FirstOrDefault(i => i.IdReader == childIdReader);
            item.IdAdult = adultIdReader;
        }

        public Child GetByIdReader(string IdReader) => Items.Find(e => e.IdReader.CompareTo(IdReader) == 0);

        public void Delete(string id)
        {
            var entity = Items.Where(e => e.IdReader.CompareTo(id) == 0).FirstOrDefault();
            Items.Remove(entity);
        }
    }
}

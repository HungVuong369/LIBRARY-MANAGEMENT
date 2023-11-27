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
    public class ReaderRepository : RepositoryBase<Reader>, IRepositoryBase<Reader>
    {
        public ReaderRepository()
        {
            Items = new List<Reader>();
        }

        public List<Reader> Load(bool status)
        {
            Items.Clear();

            Items.AddRange(DatabaseFirst.Instance.db.Readers.Where(i => i.Status == status));

            return Items;
        }

        public void Add(string lName, string fName, DateTime boF, bool readerType, bool status, DateTime createdAt, DateTime modifiedAt)
        {
            string newID = GetNewID();

            var newReader = new Reader()
            {
                boF = boF,
                CreatedAt = createdAt,
                ModifiedAt = modifiedAt,
                FName = fName,
                LName = lName,
                Id = newID,
                ReaderType = readerType,
                Status = status
            };

            DatabaseFirst.Instance.db.Readers.Add(newReader);

            Items.Add(newReader);
        }

        public void RemoveByID(string id)
        {
            var item = DatabaseFirst.Instance.db.Readers.FirstOrDefault(i => i.Id == id);
            item.Status = false;
            Items.Remove(GetById(id));
        }

        public void Restore(Reader reader)
        {
            var item = DatabaseFirst.Instance.db.Readers.FirstOrDefault(i => i.Id == reader.Id);
            item.Status = true;
            Items.Remove(GetById(reader.Id));
        }

        public Reader GetById(string id) => Items.Find(e => e.Id.ToLower().CompareTo(id.ToLower()) == 0);

        public static string GetNewID()
        {
            string id = "R";

            var number = DatabaseFirst.Instance.db.Readers.Select(reader => reader.Id.Substring(1)).AsEnumerable().Select(num => int.Parse(num)).DefaultIfEmpty().Max() + 1;

            if (number <= 9)
                id += "0" + number;
            else
                id += number;

            return id;
        }

        public Reader GetFirstReader()
        {
            if (Items.Count == 0)
                return null;
            return Items[0];
        }

        public void Delete(string id)
        {
            var entity = Items.Where(e => e.Id.CompareTo(id) == 0).FirstOrDefault();
            Items.Remove(entity);
        }
    }
}

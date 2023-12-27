using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HungVuong_C5_Assignment
{
    public class BookStatusRepository : RepositoryBase<BookStatu>
    {
        public BookStatusRepository()
        {
            Items = new List<BookStatu>();
        }

        public List<BookStatu> Load()
        {
            Items.Clear();

            Items.AddRange(DatabaseFirst.Instance.db.BookStatus.Where(i => i.Status));

            return Items;
        }

        public BookStatu GetByID(string id) => Items.Find(e => e.Id.CompareTo(id) == 0);
    }
}

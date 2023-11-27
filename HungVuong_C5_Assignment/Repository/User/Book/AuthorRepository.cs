using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HungVuong_C5_Assignment
{
    public class AuthorRepository : RepositoryBase<Author>
    {
        public AuthorRepository()
        {
            Items = new List<Author>();
        }

        public List<Author> Load()
        {
            Items.Clear();

            Items.AddRange(DatabaseFirst.Instance.db.Authors);

            return Items;
        }

        public Author GetById(string id) => Items.Find(e => e.Id.CompareTo(id) == 0);
    }
}

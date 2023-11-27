using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HungVuong_C5_Assignment
{
    public class CategoryRepository : RepositoryBase<Category>
    {
        public CategoryRepository()
        {
            Items = new List<Category>();
        }

        public List<Category> Load()
        {
            Items.Clear();

            Items.AddRange(DatabaseFirst.Instance.db.Categories);
           
            return Items;
        }

        public Category GetById(string id) => Items.Find(e => e.Id.CompareTo(id) == 0);
    }
}

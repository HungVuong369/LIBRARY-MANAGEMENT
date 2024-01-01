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

            Items.AddRange(DatabaseFirst.Instance.db.Categories.Where(i => i.Status));
           
            return Items;
        }

        public static string GetNewID()
        {
            string id = "C";

            var number = DatabaseFirst.Instance.db.Categories.Select(reader => reader.Id.Substring(1)).AsEnumerable().Select(num => int.Parse(num)).DefaultIfEmpty().Max() + 1;

            if (number <= 9)
                id += "0" + number;
            else
                id += number;

            return id;
        }

        public void Add(Category newCategory)
        {
            Items.Add(newCategory);

            DatabaseFirst.Instance.db.Categories.Add(newCategory);
        }

        public void Lock(Category category)
        {
            Items.Remove(category);

            var item = DatabaseFirst.Instance.db.Categories.FirstOrDefault(i => i.Id == category.Id);

            item.Status = false;
        }

        public void Delete(Category category)
        {
            Items.Remove(category);

            var item = DatabaseFirst.Instance.db.Categories.FirstOrDefault(i => i.Id == category.Id);

            DatabaseFirst.Instance.db.Categories.Remove(item);
        }

        public void Restore(Category category)
        {
            Items.Remove(category);

            var item = DatabaseFirst.Instance.db.Categories.FirstOrDefault(i => i.Id == category.Id);

            item.Status = true;
        }

        public void Update(Category category, Category newCategory)
        {
            category.ModifiedAt = newCategory.ModifiedAt;
            category.Name = newCategory.Name;

            var item = DatabaseFirst.Instance.db.Categories.FirstOrDefault(i => i.Id == category.Id);

            item.Name = newCategory.Name;
            item.ModifiedAt = newCategory.ModifiedAt;
        }

        public Category GetById(string id) => Items.Find(e => e.Id.CompareTo(id) == 0);
    }
}

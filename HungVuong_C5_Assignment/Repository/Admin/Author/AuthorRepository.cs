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

        public static string GetNewID()
        {
            string id = "A";

            var number = DatabaseFirst.Instance.db.Authors.Select(i => i.Id.Substring(1)).AsEnumerable().Select(num => int.Parse(num)).DefaultIfEmpty().Max() + 1;

            if (number <= 9)
                id += "0" + number;
            else
                id += number;

            return id;
        }

        public void Add(Author newAuthor)
        {
            Items.Add(newAuthor);

            DatabaseFirst.Instance.db.Authors.Add(newAuthor);
        }

        public void Lock(Author author)
        {
            Items.Remove(author);

            var item = DatabaseFirst.Instance.db.Authors.FirstOrDefault(i => i.Id == author.Id);

            item.Status = false;
        }

        public void Delete(Author author)
        {
            Items.Remove(author);

            var item = DatabaseFirst.Instance.db.Authors.FirstOrDefault(i => i.Id == author.Id);

            DatabaseFirst.Instance.db.Authors.Remove(item);
        }

        public void Restore(Author author)
        {
            Items.Remove(author);

            var item = DatabaseFirst.Instance.db.Authors.FirstOrDefault(i => i.Id == author.Id);

            item.Status = true;
        }

        public void Update(Author author, Author newAuthor)
        {
            author.ModifiedAt = newAuthor.ModifiedAt;
            author.Name = newAuthor.Name;
            author.Description = newAuthor.Description;
            author.Summary = newAuthor.Summary;
            author.boF = newAuthor.boF;

            var item = DatabaseFirst.Instance.db.Authors.FirstOrDefault(i => i.Id == author.Id);

            item.ModifiedAt = newAuthor.ModifiedAt;
            item.Name = newAuthor.Name;
            item.Description = newAuthor.Description;
            item.Summary = newAuthor.Summary;
            item.boF = newAuthor.boF;
        }

        public Author GetById(string id) => Items.Find(e => e.Id.CompareTo(id) == 0);
    }
}

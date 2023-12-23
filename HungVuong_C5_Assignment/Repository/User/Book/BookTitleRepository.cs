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
    public class BookTitleRepository : RepositoryBase<BookTitle>
    {
        public BookTitleRepository()
        {
            Items = new List<BookTitle>();
        }

        public List<BookTitle> Load()
        {
            Items.Clear();

            Items.AddRange(DatabaseFirst.Instance.db.BookTitles);

            return Items;
        }

        public BookTitle GetById(string id) => Items.Find(e => e.Id.CompareTo(id) == 0);

        public static string GetNewID()
        {
            string id = "BT";

            var number = DatabaseFirst.Instance.db.BookTitles.Select(bookTitle => bookTitle.Id.Substring(2)).AsEnumerable().Select(num => int.Parse(num)).DefaultIfEmpty().Max() + 1;

            if (number <= 9)
                id += "0" + number;
            else
                id += number;

            return id;
        }

        public void Add(string categoryID, string name, string summary)
        {
            string newID = GetNewID();

            var newBookTitle = new BookTitle()
            {
                Id = newID,
                IdCategory = categoryID,
                Name = name,
                Summary = summary
            };

            DatabaseFirst.Instance.db.BookTitles.Add(newBookTitle);

            Items.Add(newBookTitle);
        }
    }
}

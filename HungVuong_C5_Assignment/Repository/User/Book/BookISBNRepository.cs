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
    public class BookISBNRepository : RepositoryBase<BookISBN>
    {
        public BookISBNRepository()
        {
            Items = new List<BookISBN>();
        }

        public List<BookISBN> Load()
        {
            Items.Clear();

            Items.AddRange(DatabaseFirst.Instance.db.BookISBNs);

            return Items;
        }

        public void UpdateStatusByISBN(int status, string isbn)
        {
            var bookISBN = DatabaseFirst.Instance.db.BookISBNs.FirstOrDefault(i => i.ISBN == isbn);
            bookISBN.Status = status == 0 ? false : true;

            var item = GetByISBN(isbn);
            item.Status = status == 0 ? false : true;
        }

        public static string GetNewISBN()
        {
            string id = "ISBN";

            var number = DatabaseFirst.Instance.db.BookISBNs.Select(i => i.ISBN.Substring(4)).AsEnumerable().Select(num => int.Parse(num)).DefaultIfEmpty().Max() + 1;

            if (number <= 9)
                id += "0" + number;
            else
                id += number;

            return id;
        }

        public void Add(string language, string authorID, string bookTitleID)
        {
            string newISBN = GetNewISBN();

            var newBookISBN = new BookISBN()
            {
                ISBN = newISBN,
                IdBookTitle = bookTitleID,
                IdAuthor = authorID,
                OriginLanguage = language,

                Status = false
            };

            DatabaseFirst.Instance.db.BookISBNs.Add(newBookISBN);

            Items.Add(newBookISBN);
        }

        public BookISBN GetByISBN(string isbn) => Items.Find(e => e.ISBN.ToLower().CompareTo(isbn.ToLower()) == 0);
    }
}

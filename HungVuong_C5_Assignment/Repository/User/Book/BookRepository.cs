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
    public class BookRepository : RepositoryBase<Book>
    {
        public BookRepository()
        {
            Items = new List<Book>();
        }

        public List<Book> Load()
        {
            Items.Clear();

            Items.AddRange(DatabaseFirst.Instance.db.Books.Include("Translator"));

            return Items;
        }


        public static int GetNewID()
        {
            string id = string.Empty;

            var number = DatabaseFirst.Instance.db.Books.Local.Select(book => book.Id).Max() + 1;

            if (number <= 9)
                id += "0" + number;
            else
                id += number;

            return int.Parse(id);
        }


        public void Add(string isbn, string publisherID, string translatorID, string language, DateTime publishDate, decimal price, int quantity)
        {
            for(int index = 0; index < quantity; index++)
            {
                int newID = GetNewID();

                var newBook = new Book()
                {
                    Id = newID,
                    ISBN = isbn,
                    PublishDate = publishDate,
                    IdPublisher = publisherID,
                    IdTranslator = translatorID,
                    Language = language,
                    Price = price,
                    PriceCurrent = price,
                    IdBookStatus = "BS1",

                    CreatedAt = DateTime.Now,
                    ModifiedAt = DateTime.Now,
                    Status = true,
                };
                Items.Add(newBook);
                DatabaseFirst.Instance.db.Books.Add(newBook);
            }
        }

        public Book GetById(string id) => Items.Find(e => e.Id.CompareTo(id) == 0);
        public Book GetByISBN(string isbn) => Items.Find(e => e.ISBN.CompareTo(isbn) == 0);
    }
}

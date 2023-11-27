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

            Items.AddRange(DatabaseFirst.Instance.db.Books);

            return Items;
        }

        public void UpdateStatusByISBN(int status, string isbn)
        {
            DataProvider.Instance.parameters = new string[] { FieldName.ISBN };
            DataProvider.Instance.values = new object[] { isbn };

            int nRow = DataProvider.Instance.ExcuteNonQuery(CommandType.Text, TSQL.UpdateStatusBook(status, isbn));

            if (nRow != -1)
            {
                foreach(var item in Items)
                {
                    if (item.ISBN == isbn)
                        item.Status = status == 0 ? false : true;
                }
            }
            else
                MessageBox.Show("Records Deleted Failed!");
        }

        public static int GetNewID()
        {
            string id = string.Empty;

            var number = DatabaseFirst.Instance.db.Books.Select(book => book.Id).Max() + 1;

            if (number <= 9)
                id += "0" + number;
            else
                id += number;

            return int.Parse(id);
        }


        public void Add(string isbn, decimal bookPrice)
        {
            int newID = GetNewID();

            var newBook = new Book()
            {
                Id = newID,
                ISBN = isbn,
                CreatedAt = DateTime.Now,
                ModifiedAt = DateTime.Now,
                Status = true,
                DonGia = bookPrice,
                DonGiaHienTai = bookPrice
            };
            Items.Add(newBook);

            DatabaseFirst.Instance.db.Books.Add(newBook);
        }

        public Book GetById(string id) => Items.Find(e => e.Id.CompareTo(id) == 0);
        public Book GetByISBN(string isbn) => Items.Find(e => e.ISBN.CompareTo(isbn) == 0);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HungVuong_C5_Assignment
{
    public class BookISBNInformation
    {
        public string ISBN { get; set; }
        public DateTime PublishDate { get; set; }
        public string Language { get; set; }
        public string AuthorName { get; set; }
        public DateTime AuthorBoF { get; set; }
        public decimal BookPrice { get; set; }
        public bool Status { get; set; }

        public BookISBNInformation(string isbn, DateTime publishDate, string language, string authorName, DateTime AuthorBoF, decimal bookPrice, bool status)
        {
            this.ISBN = isbn;
            this.PublishDate = publishDate;
            this.Language = language;
            this.AuthorName = authorName;
            this.AuthorBoF = AuthorBoF;
            this.BookPrice = bookPrice;
            this.Status = status;
        }
    }
}

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
        public string Language { get; set; }
        public string AuthorID { get; set; }
        public string AuthorName { get; set; }
        public DateTime AuthorBoF { get; set; }
        public bool Status { get; set; }

        public BookISBNInformation(string isbn, string language, string authorID, string authorName, DateTime AuthorBoF, bool status)
        {
            this.ISBN = isbn;
            this.Language = language;
            this.AuthorName = authorName;
            this.AuthorBoF = AuthorBoF;
            this.Status = status;
            this.AuthorID = authorID;
        }

        public BookISBNInformation() { }
    }
}

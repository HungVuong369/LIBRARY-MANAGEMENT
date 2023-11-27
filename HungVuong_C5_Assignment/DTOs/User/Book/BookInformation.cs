using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HungVuong_C5_Assignment
{
    public class BookInformation
    {
        public string ISBN { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Author { get; set; }
        public string Language { get; set; }
        public string Translator { get; set; }
        public DateTime PublishDate { get; set; }
        public int Quantity { get; set; }
        public bool Status { get; set; }

        public BookInformation(string isbn, string name, string category, string author, string language, string translator, DateTime publishDate, int quantity, bool status)
        {
            this.ISBN = isbn;
            this.Name = name;
            this.Category = category;
            this.Author = author;
            this.Language = language;
            this.Translator = translator;
            this.PublishDate = publishDate;
            this.Quantity = quantity;
            this.Status = status;
        }
    }
}

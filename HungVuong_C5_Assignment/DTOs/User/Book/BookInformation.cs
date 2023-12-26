using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HungVuong_C5_Assignment
{
    public class BookInformation
    {
        public int Id { get; set; }
        public string ISBN { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public Author BookAuthor { get; set; }
        public Translator BookTranslator { get; set; }
        public Publisher BookPublisher { get; set; }
        public string Language { get; set; }
        public DateTime PublishDate { get; set; }
        public int Quantity { get; set; }
        public bool Status { get; set; }
        public string BookStatus { get; set; }

        public BookInformation() {
            
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HungVuong_C5_Assignment
{
    public class LoanDetailDto
    {
        // Name Book
        public int Id { get; set; }
        public string ISBN { get; set; }
        public string Book { get; set; }
        public Category Category { get; set; }
        public string Language { get; set; }
        public Translator Translator { get; set; }
        public Author Author { get; set; }
        public decimal Price { get; set; }
        public DateTime EnrollDate { get; set; }
        public Publisher Publisher { get; set; }
        public string Status { get; set; }
    }
}

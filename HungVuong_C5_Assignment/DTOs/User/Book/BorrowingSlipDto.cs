using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HungVuong_C5_Assignment
{
    public class BorrowingSlipDto
    {
        public string Name { get; set; }
        public bool ReaderType { get; set; }
        public DateTime BoF { get; set; }
        public string BookName { get; set; }
        public string Author { get; set; }
        public string Category { get; set; }
        public string Language { get; set; }
        public DateTime EnrollDate { get; set; }
        public string Status { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HungVuong_C5_Assignment
{
    public class EnrollDto
    {
        public string Id { get; set; }
        public string ISBN { get; set; }
        public Reader Reader { get; set; }
        public DateTime EnrollDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string Note { get; set; }
        public bool Status { get; set; }
    }
}

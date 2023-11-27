using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HungVuong_C5_Assignment
{
    public class LoanSlipDto
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public int Quantity { get; set; }
        public DateTime LoanDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public decimal LoanPaid { get; set; }
        public decimal Deposit { get; set; }
    }
}

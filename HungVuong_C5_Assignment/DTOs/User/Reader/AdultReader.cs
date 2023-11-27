using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HungVuong_C5_Assignment
{
    public class AdultReader
    {
        public string Identify { get; set; }
        public string Id { get; set; }
        public string Lname { get; set; }
        public string FName { get; set; }
        public string Address { get; set; }
        public string FullName { get; set; }
        public string Province { get; set; }
        public string Phone { get; set; }
        public DateTime BoF { get; set; }
        public bool Type { get; set; }
        public bool Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ExpireDate { get; set; }
        public DateTime ModifiedAt { get; set; }

        public AdultReader(string id, string lName, string fName, DateTime boF, bool type, bool status, DateTime createdAt, DateTime modifiedAt, string identify)
        {
            this.Identify = identify;
            this.Id = id;
            this.Lname = lName;
            this.FName = fName;
            this.FullName = lName + " " + fName;
            this.BoF = boF;
            this.Type = type;
            this.Status = status;
            this.CreatedAt = createdAt;
            this.ModifiedAt = modifiedAt;
        }

        public AdultReader() { }
    }
}

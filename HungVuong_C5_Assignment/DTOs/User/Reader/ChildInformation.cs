using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HungVuong_C5_Assignment
{
    public class ChildInformation 
    {
        public string IdReader { get; set; }
        public string FullName { get; set; }
        public DateTime BoF { get; set; }
        public string ReaderType { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }

        public ChildInformation(string IdReader, string fullName, DateTime boF, string readerType, DateTime createdAt, DateTime modifiedAt)
        {
            this.IdReader = IdReader;
            this.FullName = fullName;
            this.BoF = boF;
            this.ReaderType = readerType;
            this.CreatedAt = createdAt;
            this.ModifiedAt = modifiedAt;
        }
    }
}

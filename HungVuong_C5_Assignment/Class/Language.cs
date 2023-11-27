using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HungVuong_C5_Assignment
{
    public class Language
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public Language(string id, string name)
        {
            this.Id = id;
            this.Name = name;
        }
    }
}

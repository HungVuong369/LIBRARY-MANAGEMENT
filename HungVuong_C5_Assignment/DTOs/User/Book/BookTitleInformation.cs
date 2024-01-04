using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HungVuong_C5_Assignment
{
    public class BookTitleInformation
    {
        public string Id { get; set; }
        public string Category { get; set; }
        public string Name { get; set; }
        public string Summary { get; set; }
        public string UrlImage { get; set; }

        public BookTitleInformation(string id, string category, string name, string summary, string urlImage)
        {
            this.Id = id;
            this.Category = category;
            this.Name = name;
            this.Summary = summary;
            this.UrlImage = urlImage;
        }
    }
}

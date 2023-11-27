using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HungVuong_C5_Assignment
{
    public class PublisherViewModel
    {
        private static readonly UnitOfWork unitOfWork = new UnitOfWork();
        public PublisherRepository PublisherRepo { get; set; }

        public PublisherViewModel()
        {
            PublisherRepo = unitOfWork.Publishers;
        }
    }
}

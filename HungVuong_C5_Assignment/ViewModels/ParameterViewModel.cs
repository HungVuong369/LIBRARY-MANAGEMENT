using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HungVuong_C5_Assignment
{
    public class ParameterViewModel
    {
        private static readonly UnitOfWork unitOfWork = new UnitOfWork();
        public ParameterRepository parameterRepo { get; set; }

        public ParameterViewModel()
        {
            parameterRepo = unitOfWork.Parameters;
        }

        public string GetValueByID(string id)
        {
            foreach(var item in parameterRepo.Items)
            {
                if(item.Id == id)
                    return item.Value;
            }
            return null;
        }
    }
}

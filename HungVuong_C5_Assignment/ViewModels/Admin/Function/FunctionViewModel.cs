using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HungVuong_C5_Assignment
{
    public class FunctionViewModel
    {
        private static readonly UnitOfWork unitOfWork = new UnitOfWork();
        public FunctionRepository functionRepo;

        public FunctionViewModel()
        {
            this.functionRepo = unitOfWork.Functions;
        }

        public bool IsExist(string name, string idParent)
        {
            var item = DatabaseFirst.Instance.db.Functions.FirstOrDefault(i => i.IdParent == idParent && i.Name.ToLower() == name.ToLower());
            return item == null ? false : true;
        }

        public List<Function> GetListFunctionDelete(List<Function> functions)
        {
            List<Function> lstFunction = new List<Function>();
            lstFunction.AddRange(functions.Where(i => i.IdParent == null));

            foreach (var item in new List<Function>(lstFunction))
            {
                lstFunction.AddRange(functionRepo.Items.Where(i => i.IdParent == item.Id));
            }

            foreach (var item in functions.Where(i => i.IdParent != string.Empty))
            {
                if (!lstFunction.Contains(item))
                    lstFunction.Add(item);
            }
            return lstFunction;
        }

        public List<Function> GetListFunctionDelete(string IdFunction)
        {
            List<Function> lstFunction = new List<Function>();
            lstFunction.Add(functionRepo.Items.Find(i => i.Id == IdFunction));
            lstFunction.AddRange(functionRepo.Items.Where(i => i.IdParent == IdFunction));
            return lstFunction;
        }

        public List<Function> GetListFunctionRestore(List<Function> functions)
        {
            List<Function> lstFunction = new List<Function>();

            foreach(var item in functions.Where(i => i.IdParent != string.Empty))
            {
                Function functionParent = functionRepo.Items.Find(i => i.Id == item.IdParent);

                if(functionParent != null && !lstFunction.Contains(functionParent))
                    lstFunction.Add(functionParent);

                lstFunction.Add(item);
            }

            foreach(var item in functions.Where(i => i.IdParent == null))
            {
                if(!lstFunction.Contains(item))
                {
                    lstFunction.Add(item);
                }
            }

            return lstFunction;
        }
    }
}

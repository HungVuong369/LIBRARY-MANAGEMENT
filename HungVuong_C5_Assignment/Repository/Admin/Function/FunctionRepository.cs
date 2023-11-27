using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HungVuong_C5_Assignment
{
    public class FunctionRepository : RepositoryBase<Function>
    {
        public FunctionRepository()
        {
            Items = new List<Function>();
        }

        public List<Function> Load(bool status)
        {
            Items.Clear();

            Items.AddRange(DatabaseFirst.Instance.db.Functions.Where(i => i.Status == status));

            return Items;
        }

        public void Remove(Function function)
        {
            var func = DatabaseFirst.Instance.db.Functions.FirstOrDefault(i => i.Id == function.Id);

            func.Status = false;

            Items.Remove(function);
        }

        public void Restore(Function function)
        {
            var func = DatabaseFirst.Instance.db.Functions.FirstOrDefault(i => i.Id == function.Id);
            func.Status = true;
            Items.Remove(function);
        }

        public void UpdateByID(string id, string name, string description, string IdParent, string urlImage)
        {
            Function function = Items.Find(i => i.Id == id);
            function.Name = name;
            function.Description = description;
            function.IdParent = IdParent;
            function.UrlImage = urlImage;

            var functionDB = DatabaseFirst.Instance.db.Functions.FirstOrDefault(i => i.Id == id);
            functionDB.Name = name;
            functionDB.Description = description;
            functionDB.IdParent = IdParent;
            functionDB.UrlImage = urlImage;
        }

        public Function GetByID(string id) => Items.Find(e => e.Id.CompareTo(id) == 0);
    }
}

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
    public class RoleFunctionRepository : RepositoryBase<RoleFunction>
    {
        public RoleFunctionRepository()
        {
            Items = new List<RoleFunction>();
        }

        public List<RoleFunction> Load()
        {
            Items.Clear();

            Items.AddRange(DatabaseFirst.Instance.db.RoleFunctions);

            return Items;
        }

        public string GetNewID()
        {
            string id = "RF";

            int number = Items.Select(item => int.Parse(item.Id.Substring(2))).DefaultIfEmpty(0).Max() + 1;

            id += number;

            return id;
        }

        public void Add(string idRole, string idFunction)
        {
            string newID = GetNewID();

            var newRoleFunction = new RoleFunction()
            {
                Id = newID,
                IdFunction = idFunction,
                IdRole = idRole
            };

            Items.Add(newRoleFunction);

            DatabaseFirst.Instance.db.RoleFunctions.Add(newRoleFunction);
        }

        public void Delete(string id)
        {
            RoleFunction roleFunction = Items.FirstOrDefault(i => i.Id == id);

            Items.Remove(roleFunction);

            DatabaseFirst.Instance.db.RoleFunctions.Remove(DatabaseFirst.Instance.db.RoleFunctions.FirstOrDefault(i => i.Id == id));
        }

        public RoleFunction GetByID(string id) => Items.Find(e => e.Id.CompareTo(id) == 0);
    }
}

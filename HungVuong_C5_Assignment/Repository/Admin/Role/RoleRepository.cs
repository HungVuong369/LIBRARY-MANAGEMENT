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
    public class RoleRepository : RepositoryBase<Role>
    {
        public RoleRepository()
        {
            Items = new List<Role>();
        }

        public List<Role> Load()
        {
            Items.Clear();

            Items.AddRange(DatabaseFirst.Instance.db.Roles);

            return Items;
        }

        public string GetNewID()
        {
            string id = "R";

            int number = Items.Select(item => int.Parse(item.Id.Split('R')[1])).DefaultIfEmpty(0).Max() + 1;

            id += number;

            return id;
        }

        public void Add(string roleName, string group)
        {
            string newID = GetNewID();

            var newRole = new Role()
            {
                Group = group,
                Id = newID,
                Name = roleName,
                Status = true
            };
            Items.Add(newRole);

            DatabaseFirst.Instance.db.Roles.Add(newRole);
        }

        public Role GetByID(string id) => Items.Find(e => e.Id.CompareTo(id) == 0);
    }
}

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
    public class UserRoleRepository : RepositoryBase<UserRole>
    {
        public UserRoleRepository()
        {
            Items = new List<UserRole>();
        }

        public List<UserRole> Load()
        {
            Items.Clear();

            Items.AddRange(DatabaseFirst.Instance.db.UserRoles);

            return Items;
        }

        public string GetNewID()
        {
            string id = "UR";

            int number = Items.Select(item => int.Parse(item.Id.Substring(2))).DefaultIfEmpty(0).Max() + 1;

            id += number;

            return id;
        }

        public void DeleteByIdUser(string IdUser)
        {
            if (Items.Where(i => i.IdUser == IdUser).ToList().Count == 0)
            {
                return;
            }

            var items = Items.Where(i => i.IdUser == IdUser).ToList();
            for (int index = items.Count - 1; index >= 0; index--)
            {
                Items.Remove(items[index]);
            }

            DatabaseFirst.Instance.db.UserRoles.RemoveRange(DatabaseFirst.Instance.db.UserRoles.Where(i => i.IdUser == IdUser));
        }

        public void Add(string idUser, string idRole)
        {
            string newID = GetNewID();

            var newUserRole = new UserRole()
            {
                Id = newID,
                IdRole = idRole,
                IdUser = idUser
            };

            Items.Add(newUserRole);

            DatabaseFirst.Instance.db.UserRoles.Add(newUserRole);
        }

        public void UpdateIdRole(string IdUser, string IdRole, string newIdRole)
        {
            var item = Items.FirstOrDefault(i => i.IdRole == IdRole && i.IdUser == IdUser);
            item.IdRole = newIdRole;

            var userRole = DatabaseFirst.Instance.db.UserRoles.FirstOrDefault(i => i.IdRole == IdRole && i.IdUser == IdUser);
            userRole.IdRole = newIdRole;
        }

        public UserRole GetByID(string id) => Items.Find(e => e.Id.CompareTo(id) == 0);

        public UserRole GetByIdUser(string IdUser) => Items.Find(e => e.IdUser.CompareTo(IdUser) == 0);
    }
}

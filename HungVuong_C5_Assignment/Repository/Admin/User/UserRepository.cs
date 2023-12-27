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
    public class UserRepository : RepositoryBase<User>
    {
        public UserRepository()
        {
            Items = new List<User>();
        }

        public List<User> Load()
        {
            Items.Clear();

            Items.AddRange(DatabaseFirst.Instance.db.Users.Include("UserInfo"));

            return Items;
        }

        public string GetNewID()
        {
            string id = "U";

            int number = Items.Select(item => int.Parse(item.Id.Split('U')[1])).DefaultIfEmpty(0).Max() + 1;

            id += number;

            return id;
        }

        public void Add(string username, string password)
        {
            string newID = GetNewID();

            DateTime createdAt = DateTime.Now;

            string id = GetNewID();

            var newUser = new User
            {
                Id = id,
                Status = true,
                CreatedAt = DateTime.Now,
                ModifiedAt = DateTime.Now,
                Username = username,
                Password = password
            };

            Items.Add(newUser);

            DatabaseFirst.Instance.db.Users.Add(newUser);
        }

        public void Delete(string id)
        {
            Items.Remove(Items.FirstOrDefault(i => i.Id == id));

            DatabaseFirst.Instance.db.Users.Remove(DatabaseFirst.Instance.db.Users.FirstOrDefault(i => i.Id == id));
        }

        public void UpdateByID(string id, string username, string password)
        {
            User user = Items.FirstOrDefault(i => i.Id == id);
            user.Username = username;
            user.Password = password;
            user.ModifiedAt = DateTime.Now;

            var userDB = DatabaseFirst.Instance.db.Users.FirstOrDefault(i => i.Id == id);
            userDB.Username = username;
            userDB.Password = password;
            userDB.ModifiedAt = DateTime.Now;
        }

        public User GetByID(string id) => Items.Find(e => e.Id.CompareTo(id) == 0);

        public User GetByUsernameAndPassword(string username, string password) => Items.Find(i => i.Username.ToLower() == username.ToLower() && i.Password.ToLower() == password.ToLower());
    }
}

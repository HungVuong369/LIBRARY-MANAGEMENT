using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HungVuong_C5_Assignment
{
    public class UserViewModel
    {
        private static readonly UnitOfWork unitOfWork = new UnitOfWork();

        public UserRepository userRepo { get; set; }

        public UserViewModel()
        {
            userRepo = unitOfWork.Users;
        }

        public bool IsExist(string username)
        {
            var item = DatabaseFirst.Instance.db.Users.FirstOrDefault(i => i.Username.ToLower() == username.ToLower());
            return item == null ? false : true;
        }
    }
}

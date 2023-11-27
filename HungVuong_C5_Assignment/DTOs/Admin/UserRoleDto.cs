using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HungVuong_C5_Assignment
{
    public class UserRoleDto
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
        public string NameRole { get; set; }
        public string Group { get; set; }

        public UserRoleDto(string id, string username, string password, bool status, DateTime createdAt, DateTime modifiedAt, string nameRole, string group)
        {
            this.Id = id;
            this.Username = username;
            this.Password = password;
            this.Status = status;
            this.CreatedAt = createdAt;
            this.ModifiedAt = modifiedAt;
            this.NameRole = nameRole;
            this.Group = group;
        }
    }
}

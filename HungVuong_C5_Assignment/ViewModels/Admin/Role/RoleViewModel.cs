using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HungVuong_C5_Assignment
{
    public class RoleViewModel
    {
        private static readonly UnitOfWork unitOfWork = new UnitOfWork();
        public RoleRepository roleRepo;

        public RoleViewModel()
        {
            this.roleRepo = unitOfWork.Roles;
        }

        public List<string> GetListGroup()
        {
            var items = this.roleRepo.Items.Select(i => i.Group).Distinct().ToList();

            return items;
        }
    }
}

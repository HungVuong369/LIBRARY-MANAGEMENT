using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HungVuong_C5_Assignment
{
    public class RoleManagementRepository
    {
        private UserRoleViewModel _UserRoleVM = new UserRoleViewModel();
        private RoleFunctionViewModel _RoleFunctionVM = new RoleFunctionViewModel();
        private RoleViewModel _RoleVM = new RoleViewModel();

        public void UserAssignment(string userID, string roleID)
        {
            this._UserRoleVM.userRoleRepo.Add(userID, roleID);
            DatabaseFirst.Instance.SaveChanged();
        }

        public void UpdateUserAssignment(string userID, string roleID, string newRoleID)
        {
            this._UserRoleVM.userRoleRepo.UpdateIdRole(userID, roleID, newRoleID);
            DatabaseFirst.Instance.SaveChanged();
        }

        public void DeleteRoleFunction(string roleFunctionID)
        {
            _RoleFunctionVM.roleFunctionRepo.Delete(roleFunctionID);
            DatabaseFirst.Instance.SaveChanged();
        }

        public void AddRoleFunction(string roleID, string functionID)
        {
            _RoleFunctionVM.roleFunctionRepo.Add(roleID, functionID);
            DatabaseFirst.Instance.SaveChanged();
        }

        public bool AddRole(string nameRole, string group)
        {
            Role role = this._RoleVM.roleRepo.Items.Find(i => i.Name.ToLower() == nameRole.Trim().ToLower());

            if (role != null)
            {
                MessageBox.Show("Name role is existed!", "Notify", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            this._RoleVM.roleRepo.Add(nameRole, group);

            DatabaseFirst.Instance.SaveChanged();

            return true;
        }
    }
}

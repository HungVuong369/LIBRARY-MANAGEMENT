using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HungVuong_C5_Assignment
{
    public class UserManagementRepository
    {
        private UserViewModel _UserVM = new UserViewModel();
        private UserInfoViewModel _UserInfoVM = new UserInfoViewModel();
        private UserRoleViewModel _UserRoleVM = new UserRoleViewModel();

        public bool AddUser(UserDto userDto)
        {
            if (_UserVM.IsExist(userDto.Username))
            {
                MessageBox.Show("Username already taken!", "Notify", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            _UserVM.userRepo.Add(userDto.Username, userDto.Password);
            _UserInfoVM.UserInfoRepo.Add(userDto.LName, userDto.FName, userDto.Phone, userDto.Address);

            DatabaseFirst.Instance.SaveChanged();
            return true;
        }

        public void DeleteUser(string userID)
        {
            this._UserInfoVM.UserInfoRepo.Delete(userID);
            this._UserRoleVM.userRoleRepo.DeleteByIdUser(userID);
            this._UserVM.userRepo.Delete(userID);

            DatabaseFirst.Instance.SaveChanged();
        }

        public bool UpdateUser(UserDto userDto, string beforeUsername)
        {
            if (_UserVM.IsExist(userDto.Username) && userDto.Username.ToLower() != beforeUsername.ToLower())
            {
                MessageBox.Show("Username already taken!", "Notify", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            this._UserVM.userRepo.UpdateByID(userDto.Id, userDto.Username, userDto.Password);
            this._UserInfoVM.UserInfoRepo.UpdateByIdUser(userDto.Id, userDto.LName, userDto.FName, userDto.Phone, userDto.Address);

            DatabaseFirst.Instance.SaveChanged();
            return true;
        }
    }
}

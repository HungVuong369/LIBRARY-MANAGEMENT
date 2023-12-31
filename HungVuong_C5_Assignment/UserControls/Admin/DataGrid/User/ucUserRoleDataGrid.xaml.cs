using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HungVuong_C5_Assignment
{
    /// <summary>
    /// Interaction logic for ucUserRoleDataGrid.xaml
    /// </summary>
    public partial class ucUserRoleDataGrid : UserControl
    {
        private ObservableCollection<UserRoleDto> _StorageLstUser;
        private ObservableCollection<UserRoleDto> _LstUser;

        public delegate void UserAssignmentHandle(object sender, RoutedEventArgs e);
        public event UserAssignmentHandle userAssignmentEvent;

        private UserViewModel _UserVM = new UserViewModel();
        private UserRoleViewModel _UserRoleVM = new UserRoleViewModel();
        private RoleViewModel _RoleVM = new RoleViewModel();
        private UserInfoViewModel _UserInfoVM = new UserInfoViewModel();

        public ucUserRoleDataGrid()
        {
            InitializeComponent();

            this._StorageLstUser = new ObservableCollection<UserRoleDto>(GetListUserRoleDto(true));

            this._LstUser = new ObservableCollection<UserRoleDto>(this._StorageLstUser);

            SetMaxPage();

            dgUserRole.ItemsSource = _LstUser.Take(pagination.ItemPerPage);

            pagination.LoadPage();
        }

        private void SetMaxPage()
        {
            pagination.MaxPage = (_LstUser.Count / pagination.ItemPerPage);

            if (_LstUser.Count % pagination.ItemPerPage != 0)
            {
                pagination.MaxPage += 1;
            }
        }

        public void ReloadShowing()
        {
            if(pagination.MaxPage == 0)
                pagination.lblShowing.Content = $"Showing 0 to 0 entities";
            else if (pagination.MaxPage == pagination.CurrentPage && _LstUser.Count() % pagination.ItemPerPage != 0)
                pagination.lblShowing.Content = $"Showing {(pagination.CurrentPage - 1) * pagination.ItemPerPage + 1} to {(pagination.CurrentPage - 1) * pagination.ItemPerPage + _LstUser.Count % pagination.ItemPerPage} entities";
            else
                pagination.lblShowing.Content = $"Showing {(pagination.CurrentPage - 1) * pagination.ItemPerPage + 1} to {(pagination.CurrentPage) * pagination.ItemPerPage} entities";
        }

        public void ReloadDataGrid()
        {
            dgUserRole.ItemsSource = null;
            dgUserRole.ItemsSource = _LstUser.Skip((pagination.CurrentPage - 1) * pagination.ItemPerPage).Take(pagination.ItemPerPage);
            ReloadShowing();
        }

        public void ReloadStorage(bool isModify)
        {
            this._StorageLstUser = new ObservableCollection<UserRoleDto>(GetListUserRoleDto(isModify));

            this._LstUser = new ObservableCollection<UserRoleDto>(this._StorageLstUser);

            SetMaxPage();

            dgUserRole.ItemsSource = _LstUser.Skip((pagination.CurrentPage - 1) * pagination.ItemPerPage).Take(pagination.ItemPerPage);
        }

        public void VisibilityButton(Visibility visibilityAssignment)
        {
            dgUserRole.Columns[8].Visibility = visibilityAssignment;
        }

        private List<UserRoleDto> GetListUserRoleDto(bool isModify)
        {
            List<UserRoleDto> lstUserRoleDto = new List<UserRoleDto>();

            foreach (var user in _UserVM.userRepo.Items)
            {
                if (isModify)
                {
                    var userRole = _UserRoleVM.userRoleRepo.Items.Find(i => i.IdUser == user.Id);
                    if (userRole == null)
                    {
                        lstUserRoleDto.Add(new UserRoleDto(user.Id, user.Username, user.Password, user.Status, user.CreatedAt,
                                       user.ModifiedAt, "None", "None"));
                    }
                    else
                    {
                        Role role = _RoleVM.roleRepo.Items.Find(i => i.Id == userRole.IdRole);
                        lstUserRoleDto.Add(new UserRoleDto(user.Id, user.Username, user.Password, user.Status, user.CreatedAt,
                                       user.ModifiedAt, role.Name, role.Group));
                    }
                }
                else
                {
                    var userRole = _UserRoleVM.userRoleRepo.Items.Find(i => i.IdUser == user.Id);
                    if (userRole == null)
                    {
                        lstUserRoleDto.Add(new UserRoleDto(user.Id, user.Username, user.Password, user.Status, user.CreatedAt,
                                       user.ModifiedAt, "None", "None"));
                    }
                }
            }

            return lstUserRoleDto;
        }

        private void btnInfo_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            UserRoleDto user = button.Tag as UserRoleDto;
            UserInfo userInfo = _UserInfoVM.UserInfoRepo.GetByID(user.Id);

            WindowDefault window = new WindowDefault();
            window.grdContainer.Children.Add(new ucUserInfoShow(userInfo));
            window.ShowDialog();
        }

        private void btnUserAssignment_Click(object sender, RoutedEventArgs e)
        {
            userAssignmentEvent?.Invoke(sender, e);
        }

        public void Search(string search)
        {
            this._LstUser.Clear();

            foreach (var item in this._StorageLstUser)
            {
                if (item.Id.ToLower().Contains(search.ToLower()))
                {
                    this._LstUser.Add(item);
                }
                else if (item.Username.ToLower().Contains(search.ToLower()))
                {
                    this._LstUser.Add(item);
                }
                else if (item.Password.ToLower().Contains(search.ToLower()))
                {
                    this._LstUser.Add(item);
                }
                else if (item.CreatedAt.ToString("dd/MM/yyyy").Contains(search))
                {
                    this._LstUser.Add(item);
                }
                else if (item.ModifiedAt.ToString("dd/MM/yyyy").Contains(search))
                {
                    this._LstUser.Add(item);
                }
                else if(item.NameRole.ToLower().Contains(search.ToLower()))
                {
                    this._LstUser.Add(item);
                }
                else if(item.Group.ToLower().Contains(search.ToLower()))
                {
                    this._LstUser.Add(item);
                }
            }
            SetMaxPage();
            pagination.CurrentPage = 1;
            pagination.LoadPage();
        }
    }
}

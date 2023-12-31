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
    /// Interaction logic for UserDataGrid.xaml
    /// </summary>
    public partial class UserDataGrid : UserControl
    {
        private ObservableCollection<User> _StorageLstUser;
        private ObservableCollection<User> _LstUser;

        public delegate void DeleteHandle(object sender, RoutedEventArgs e);
        public event DeleteHandle deleteEvent;

        public delegate void UpdateHandle(object sender, RoutedEventArgs e);
        public event UpdateHandle updateEvent;

        public delegate void UserAssignmentHandle(object sender, RoutedEventArgs e);
        public event UserAssignmentHandle userAssignmentEvent;

        public delegate void SelectionChangedHandle(object sender, RoutedEventArgs e);
        public event SelectionChangedHandle selectionChangedEvent;

        private UserViewModel _UserVM = new UserViewModel();
        private UserInfoViewModel _UserInfoVM = new UserInfoViewModel();

        public UserDataGrid()
        {
            InitializeComponent();

            this._StorageLstUser = new ObservableCollection<User>(_UserVM.userRepo.Items);

            this._LstUser = new ObservableCollection<User>(this._StorageLstUser);

            SetMaxPage();

            dgUser.ItemsSource = _LstUser.Take(pagination.ItemPerPage);

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
            if (pagination.MaxPage == 0)
                pagination.lblShowing.Content = $"Showing 0 to 0 entities";
            else if (pagination.MaxPage == pagination.CurrentPage && _LstUser.Count() % pagination.ItemPerPage != 0)
                pagination.lblShowing.Content = $"Showing {(pagination.CurrentPage - 1) * pagination.ItemPerPage + 1} to {(pagination.CurrentPage - 1) * pagination.ItemPerPage + _LstUser.Count % pagination.ItemPerPage} entities";
            else
                pagination.lblShowing.Content = $"Showing {(pagination.CurrentPage - 1) * pagination.ItemPerPage + 1} to {(pagination.CurrentPage) * pagination.ItemPerPage} entities";
        }

        public void ReloadDataGrid()
        {
            dgUser.ItemsSource = null;
            dgUser.ItemsSource = _LstUser.Skip((pagination.CurrentPage - 1) * pagination.ItemPerPage).Take(pagination.ItemPerPage);
            ReloadShowing();
        }

        public void ReloadStorage()
        {
            this._StorageLstUser = new ObservableCollection<User>(_UserVM.userRepo.Items);

            this._LstUser = new ObservableCollection<User>(this._StorageLstUser);

            SetMaxPage();

            dgUser.ItemsSource = _LstUser.Skip((pagination.CurrentPage - 1) * pagination.ItemPerPage).Take(pagination.ItemPerPage);
        }

        private void btnInfo_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            User user = button.Tag as User;
            UserInfo userInfo = _UserInfoVM.UserInfoRepo.GetByID(user.Id);

            WindowDefault window = new WindowDefault();
            window.grdContainer.Children.Add(new ucUserInfoShow(userInfo));
            window.ShowDialog();
        }

        public void VisibilityButton(Visibility visibilityDelete, Visibility visibilityDetail, Visibility visibilityUpdate, Visibility visibilityAssignment)
        {
            dgUser.Columns[6].Visibility = visibilityDetail;
            dgUser.Columns[7].Visibility = visibilityDelete;
            dgUser.Columns[8].Visibility = visibilityUpdate;
            dgUser.Columns[9].Visibility = visibilityAssignment;
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            deleteEvent?.Invoke(sender, e);
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            updateEvent?.Invoke(sender, e);
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
            }
            SetMaxPage();
            pagination.CurrentPage = 1;
            pagination.LoadPage();
        }

        private void dgUser_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectionChangedEvent?.Invoke(sender, e);
        }
    }
}
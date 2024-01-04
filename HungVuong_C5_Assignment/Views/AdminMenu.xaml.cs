using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace HungVuong_C5_Assignment
{
    /// <summary>
    /// Interaction logic for AdminMenu.xaml
    /// </summary>
    public partial class AdminMenu : Window
    {
        private FunctionViewModel _FunctionVM = new FunctionViewModel();
        private RoleFunctionViewModel _RoleFunctionVM = new RoleFunctionViewModel();
        private Role _Role;
        public UserInfo UserInfo { get; set; }
        private bool isOpenFeature = false;

        private bool flag = false;
        private double WidthDefault;
        private double HeightDefault;

        public AdminMenu(Role role, UserInfo userInfo)
        {
            InitializeComponent();
            UserInfo = userInfo;

            this._Role = role;
            LoadMenu();
        }

        private TreeViewItem CreateTreeViewItem(string header, string urlImage)
        {
            TreeViewItem treeViewItem = new TreeViewItem();
            treeViewItem.Header = header;
            treeViewItem.Tag = urlImage;
            treeViewItem.Padding = new Thickness(5);
            treeViewItem.Margin = new Thickness(5);

            string colorCode = "#0C1C2F";
            BrushConverter brushConverter = new BrushConverter();
            //Brush brush = (Brush)brushConverter.ConvertFromString(colorCode);
            //Brush brush = Brushes.Transparent;

            //treeViewItem.Background = brush;

            return treeViewItem;
        }

        private void LoadMenu()
        {
            var lstRoleFunctionAdmin = _RoleFunctionVM.roleFunctionRepo.Items.Where(i => i.IdRole == "R1");

            foreach (RoleFunction item in lstRoleFunctionAdmin)
            {
                Function function = _FunctionVM.functionRepo.Items.FirstOrDefault(i => i.Id == item.IdFunction);
                if (function == null)
                    continue;
                if (function.IdParent == null)
                {
                    TreeViewItem treeViewItem = CreateTreeViewItem(function.Name, function.UrlImage);
                    TreeView.Items.Add(treeViewItem);

                    treeViewItem.MouseLeftButtonUp += (sender, e) =>
                        {
                            var actual = TreeView.ActualWidth;
                            Animation();
                            OpenFeature(function.Id);
                        };
                }
            }
        }

        private void OpenFeature(string IdFunction)
        {
            TreeViewItem selectedItem = TreeView.SelectedItem as TreeViewItem;

            if (isOpenFeature == true)
            {
                try
                {
                    if (grdMain.Children[1] is FeatureManagement)
                    {
                        _FunctionVM.functionRepo.Load(true);
                    }
                }
                catch (ArgumentOutOfRangeException)
                {

                }
                grdMain.Children.RemoveAt(1);
            }
            else
                isOpenFeature = true;

            switch (IdFunction)
            {
                case "F1":
                    UserManagement ucUserManagement = new UserManagement();
                    grdMain.Children.Add(ucUserManagement);
                    break;
                case "F7":
                    FeatureManagement ucFeatureManagement = new FeatureManagement();
                    grdMain.Children.Add(ucFeatureManagement);
                    break;
                case "F12":
                    grdMain.Children.Add(new RoleManagement());
                    break;
                case "F45":
                    grdMain.Children.Add(new CategoryManagement());
                    break;
                case "F50":
                    grdMain.Children.Add(new ucPublisherManagement());
                    break;
                case "F54":
                    grdMain.Children.Add(new ucAuthorManagement());
                    break;
                case "F59":
                    grdMain.Children.Add(new ucTranslatorManagement());
                    break;
                case "F64":
                    grdMain.Children.Add(new ucProvinceManagement());
                    break;
                case "F69":
                    grdMain.Children.Add(new ucPenaltyReasonManagement());
                    break;
                case "F73":
                    grdMain.Children.Add(new ParameterManagement());
                    break;
                default:
                    isOpenFeature = false;
                    break;
            }
        }

        private void Animation()
        {
            if (!flag)
            {
                WidthDefault = mainWindow.Width;
                HeightDefault = mainWindow.Height;
                flag = true;
            }
            Border bdrSub = new Border();

            DoubleAnimation animationHeight = new DoubleAnimation()
            {
                From = 0,
                To = HeightDefault,
                // Default 0.4
                Duration = TimeSpan.FromSeconds(0.4)
            };
            DoubleAnimation animationWidth = new DoubleAnimation()
            {
                From = 0,
                To = mainWindow.WidthDefault,
                Duration = TimeSpan.FromSeconds(0.4)
            };

            if (grdMain.Children.Count >= 1)
                grdMain.Children.RemoveAt(0);

            grdMain.Children.Insert(0, bdrSub);
            bdrSub.Background = Brushes.Blue;

            ColorAnimation colorAnimation = new ColorAnimation();

            //colorAnimation.From = (Color)ColorConverter.ConvertFromString("#C3C2C9");
            //colorAnimation.To = Colors.White;

            colorAnimation.From = Colors.Transparent;
            colorAnimation.To = Colors.Transparent;
            colorAnimation.Duration = new Duration(TimeSpan.FromSeconds(1));

            Storyboard storyboard = new Storyboard();
            storyboard.Children.Add(colorAnimation);

            Storyboard.SetTarget(colorAnimation, bdrSub);
            Storyboard.SetTargetProperty(colorAnimation, new PropertyPath("Background.Color"));
            bdrSub.BeginAnimation(HeightProperty, animationHeight);
            bdrSub.BeginAnimation(WidthProperty, animationWidth);
            storyboard.Begin();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Close();
        }

        //private void TreeView_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        //{
        //    TreeViewItem selectedItem = TreeView.SelectedItem as TreeViewItem;
        //    TreeViewItem treeViewParent = selectedItem.Parent as TreeViewItem;

        //    Animation();

        //    if (selectedItem.IsHitTestVisible == false)
        //    {
        //        return;
        //    }


        //    if (isOpenFeature == true)
        //    {
        //        if (grdMain.Children[1] is FeatureManagement)
        //            _FunctionVM.functionRepo.Load(true);
        //        grdMain.Children.RemoveAt(1);
        //    }
        //    else
        //        isOpenFeature = true;

        //    if (treeViewParent != null)
        //    {
        //        switch (selectedItem.Header.ToString())
        //        {
        //            case "User":
        //                grdMain.Children.Add(new UserManagement());
        //                isOpenFeature = true;
        //                return;
        //            case "Feature":
        //                grdMain.Children.Add(new FeatureManagement());
        //                isOpenFeature = true;
        //                return;
        //            case "Role":
        //                grdMain.Children.Add(new RoleManagement());
        //                isOpenFeature = true;
        //                return;
        //        }
        //    }
        //    else
        //        isOpenFeature = false;
        //}

        private void TextBlock_Loaded(object sender, RoutedEventArgs e)
        {
            TextBlock textBlock = sender as TextBlock;
            textBlock.Text = UserInfo.FName;
        }

        private void ucUserInfo_Loaded(object sender, RoutedEventArgs e)
        {
            ucUserInfoShow userInfo = sender as ucUserInfoShow;
            userInfo.DataContext = UserInfo;
        }
    }
}

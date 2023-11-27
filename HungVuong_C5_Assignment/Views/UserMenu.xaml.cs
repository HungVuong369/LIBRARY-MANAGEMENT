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
    /// Interaction logic for MainMenu1.xaml
    /// </summary>
    public partial class UserMenu : Window
    {
        private bool isOpenFeature = false;

        private Role _Role;
        private RoleFunctionViewModel _RoleFunctionVM = new RoleFunctionViewModel();
        private FunctionViewModel _FunctionVM = new FunctionViewModel();
        private ReaderViewModel _ReaderVM = new ReaderViewModel();
        private AdultViewModel _AdultVM = new AdultViewModel();
        private ChildViewModel _ChildVM = new ChildViewModel();

        public UserInfo UserInfo { get; set; }

        private double WidthDefault;
        private double HeightDefault;
        private bool flag = false;

        public UserMenu(Role role, UserInfo userInfo)
        {
            InitializeComponent();

            this._Role = role;

            this.UserInfo = userInfo;

            LoadMenu();
        }

        private TreeViewItem CreateTreeViewItem(string header, string urlImage)
        {
            TreeViewItem treeViewItem = new TreeViewItem();
            treeViewItem.Header = header;
            treeViewItem.Tag = urlImage;
            treeViewItem.Padding = new Thickness(0, 5, 0, 5);

            string colorCode = "#0C1C2F";
            BrushConverter brushConverter = new BrushConverter();
            Brush brush = (Brush)brushConverter.ConvertFromString(colorCode);

            treeViewItem.Background = brush;

            return treeViewItem;
        }

        private void LoadMenu()
        {
            List<Function> lstFunction = _RoleFunctionVM.roleFunctionRepo.Items.Where(i => i.IdRole == _Role.Id).Select(item => _FunctionVM.functionRepo.Items.FirstOrDefault(i => i.Id == item.IdFunction)).ToList();

            foreach (var item in lstFunction.Where(i => i != null && i.IdParent == null))
            {
                if (item == null)
                    continue;
                TreeViewItem treeViewItem = CreateTreeViewItem(item.Name, item.UrlImage);
                tvManagement.Items.Add(treeViewItem);

                treeViewItem.MouseLeftButtonUp += (sender, e) =>
                {
                    Animation();
                    OpenFeature(item.Id);
                };
                //foreach (var function in lstFunction)
                //{
                //    if (function == null)
                //        continue;
                //    if (function.IdParent == item.Id)
                //    {
                //        TreeViewItem subTreeViewItem = CreateTreeViewItem(function.Name, function.UrlImage);

                //        subTreeViewItem.MouseLeftButtonUp += (sender, e) =>
                //        {
                //            Animation();
                //            OpenFeature(function.Id);
                //        };
                //        treeViewItem.Items.Add(subTreeViewItem);
                //    }
                //}
            }
        }

        private void OpenFeature(string IdFunction)
        {
            TreeViewItem selectedItem = TreeView.SelectedItem as TreeViewItem;
            TreeViewItem treeViewParent = selectedItem.Parent as TreeViewItem;

            if (isOpenFeature == true)
            {
                if(grdMain.Children[1] is ReaderManagement)
                {
                    _ChildVM.childRepo.Load(true);
                    _AdultVM.adultRepo.Load(true);
                    _ReaderVM.readerRepo.Load(true);
                }
                grdMain.Children.RemoveAt(1);
            }
            else
                isOpenFeature = true;

            if (treeViewParent != null)
            {
                switch (IdFunction)
                {
                    case "F21":
                        grdMain.Children.Add(new ReaderManagement());
                        break;
                    case "F29":
                        grdMain.Children.Add(new BookTitleManagement());
                        break;
                    case "F32":
                        grdMain.Children.Add(new BookISBN_Management());
                        break;
                    case "F36":
                        grdMain.Children.Add(new BookManagement());
                        break;
                    case "F22":
                        ucReaderInformation ucReader = new ucReaderInformation();
                        grdMain.Children.Add(ucReader);
                        break;
                    //case "F17":
                    //    grdMain.Children.Add(new ucAddAdultReader());
                    //    break;
                    //case "F18":
                    //    grdMain.Children.Add(new ucAddChildReader());
                    //    break;
                    case "F24":
                        ucDeleteReader ucDeleteReader = new ucDeleteReader();
                        grdMain.Children.Add(ucDeleteReader);
                        break;
                    case "F25":
                        grdMain.Children.Add(new ucRestoreReader());
                        break;
                    case "F42":
                        grdMain.Children.Add(new ucSearchByIdentify());
                        break;
                    case "F28":
                        grdMain.Children.Add(new ucTransitioningChild());
                        break;

                    case "F30":
                        grdMain.Children.Add(new ucBookTitleInformation());
                        break;
                    case "F33":
                        grdMain.Children.Add(new ucBookISBNInformation());
                        break;
                    case "F31":
                        break;
                    case "F34":
                        break;
                    case "F38":
                        break;
                    case "F41":
                        grdMain.Children.Add(new ucSearchBook());
                        break;
                    default:
                        isOpenFeature = false;
                        break;
                }
            }
            else
                isOpenFeature = false;
        }

        private void Animation()
        {
            if(!flag)
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
                Duration = TimeSpan.FromSeconds(0.4)
            };
            DoubleAnimation animationWidth = new DoubleAnimation()
            {
                From = 0,
                To = WidthDefault,
                Duration = TimeSpan.FromSeconds(0.4)
            };

            if (grdMain.Children.Count >= 1)
                grdMain.Children.RemoveAt(0);

            grdMain.Children.Insert(0, bdrSub);
            bdrSub.Background = Brushes.Blue;

            ColorAnimation colorAnimation = new ColorAnimation();

            colorAnimation.From = (Color)ColorConverter.ConvertFromString("#C3C2C9");
            colorAnimation.To = Colors.White;
            colorAnimation.Duration = new Duration(TimeSpan.FromSeconds(1));

            Storyboard storyboard = new Storyboard();
            storyboard.Children.Add(colorAnimation);

            Storyboard.SetTarget(colorAnimation, bdrSub);
            Storyboard.SetTargetProperty(colorAnimation, new PropertyPath("Background.Color"));
            bdrSub.BeginAnimation(HeightProperty, animationHeight);
            bdrSub.BeginAnimation(WidthProperty, animationWidth);
            storyboard.Begin();
        }

        private void Path_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (grdContainer.Visibility == Visibility.Visible)
                grdContainer.Visibility = Visibility.Collapsed;
            else
                grdContainer.Visibility = Visibility.Visible;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Close();
        }

        private void StackPanel_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            StackPanel sp = sender as StackPanel;
            foreach (var item in sp.Children)
            {
                if (item is Grid)
                {
                    if ((item as Grid).Visibility == Visibility.Collapsed)
                        (item as Grid).Visibility = Visibility.Visible;
                    else
                        (item as Grid).Visibility = Visibility.Collapsed;
                    if ((item as Grid).Children[0] is ucUserInfoShow)
                    {
                        var userInfoShow = (item as Grid).Children[0] as ucUserInfoShow;

                        userInfoShow.DataContext = UserInfo;
                        userInfoShow.lblHeader.Visibility = Visibility.Collapsed;
                    }
                }
            }
        }

        private void TextBlock_Loaded(object sender, RoutedEventArgs e)
        {
            TextBlock textBlock = sender as TextBlock;
            textBlock.Text = UserInfo.FName;
        }
    }
}

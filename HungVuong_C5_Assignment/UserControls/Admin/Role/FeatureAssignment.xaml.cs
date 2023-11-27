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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HungVuong_C5_Assignment
{
    /// <summary>
    /// Interaction logic for FeatureAssignment.xaml
    /// </summary>
    public partial class FeatureAssignment : UserControl
    {
        private FunctionViewModel _FunctionVM = new FunctionViewModel();
        private RoleViewModel _RoleVM = new RoleViewModel();
        private RoleFunctionViewModel _RoleFunctionVM = new RoleFunctionViewModel();
        private List<CheckBox> _ListCheckBoxSub = new List<CheckBox>();
        private List<CheckBox> _ListCheckBoxMain = new List<CheckBox>();

        private RoleManagementRepository _RoleManagementRepo = new RoleManagementRepository();

        private TreeViewItem _TreeViewItem = null;
        private ListBox _LstBox = null;

        public FeatureAssignment()
        {
            InitializeComponent();

            Loaded += FeatureAssignment_Loaded;
            
            Load();
        }

        private void FeatureAssignment_Loaded(object sender, RoutedEventArgs e)
        {
            Grid grdMain = FindParent<Grid>(this);

            Grid grd1 = FindParent<Grid>(grdMain);
            _LstBox = grd1.Children[0] as ListBox;
            Grid grd2 = FindParent<Grid>(grd1);
            Grid grd3 = FindParent<Grid>(grd2);
            Grid grd4 = FindParent<Grid>(grd3);
            Grid grd5 = FindParent<Grid>(grd4);


            Grid menuGrid = grd5.Children[0] as Grid;
            TreeView treeView = menuGrid.Children[1] as TreeView;
            TreeViewItem treeViewItem = treeView.Items[0] as TreeViewItem;
            _TreeViewItem = treeViewItem;
        }

        private static T FindParent<T>(DependencyObject child) where T : DependencyObject
        {
            DependencyObject parentObject = VisualTreeHelper.GetParent(child);

            if (parentObject == null)
                return null;

            T parent = parentObject as T;
            if (parent != null)
            {
                return parent;
            }
            else
            {
                return FindParent<T>(parentObject);
            }
        }

        public void Load()
        {
            cbRole.ItemsSource = this._RoleVM.roleRepo.Items.Where(i => i.Id != "R1");
        }

        private CheckBox CreateCheckBox(string content)
        {
            CheckBox checkBox = new CheckBox();
            checkBox.FontSize = 14;
            checkBox.Content = content;
            return checkBox;
        }

        private Label CreateLabel(string content, string id)
        {
            Label label = new Label();
            label.Content = content;
            label.FontSize = 16;
            label.FontWeight = FontWeights.SemiBold;
            label.HorizontalAlignment = HorizontalAlignment.Center;

            Grid.SetRow(label, 0);

            /// Reader Management
            if (id == "F21")
            {
                Grid.SetColumn(label, 0);
            }
            else
            {
                /// Book Management
                Grid.SetColumn(label, 1);
            }
            return label;
        }

        private void SetIsHitTestVisible(bool treeViewItem, bool listBox)
        {
            _TreeViewItem.IsHitTestVisible = treeViewItem;
            _LstBox.IsHitTestVisible = listBox;
        }

        private void cbRole_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SetIsHitTestVisible(true, true);
            SetLblSave(Brushes.Black);
            Role role = (cbRole.SelectedItem as Role);

            if (role.Group == "librarian")
            {
                TreeView tv = new TreeView();

                grdMain.Children.Clear();
                _ListCheckBoxMain.Clear();
                _ListCheckBoxSub.Clear();

                /// Reader Management
                /// Book Management
                /// Book Title Management
                /// Book ISBN Management
                var mainItems = this._FunctionVM.functionRepo.Items.Where(i => i.IdParent == null && (i.Id == "F21" || i.Id == "F36" || i.Id == "F29" || i.Id == "F32")).ToList();

                foreach (var mainItem in mainItems)
                {
                    TreeViewItem treeViewItemMain = new TreeViewItem();

                    tv.Items.Add(treeViewItemMain);

                    treeViewItemMain.Style = (Style)FindResource("TreeViewItemStyle");
                    treeViewItemMain.Header = mainItem.Name;
                    treeViewItemMain.FontSize = 14;

                    treeViewItemMain.Loaded += (sender1, e1) =>
                    {
                        CheckBox mainCheckBox = (sender1 as TreeViewItem).FindChild<CheckBox>("checkBox123");

                        if (mainCheckBox != null)
                        {
                            treeViewItemMain.IsExpanded = true;

                            mainCheckBox.Tag = mainItem;
                            _ListCheckBoxMain.Add(mainCheckBox);
                            mainCheckBox.IsChecked = _RoleFunctionVM.roleFunctionRepo.Items.FirstOrDefault(i => i.IdRole == role.Id && i.IdFunction == mainItem.Id) == null ? false : true;
                            mainCheckBox.Checked += MainCheckBox_Checked;
                            mainCheckBox.Unchecked += MainCheckBox_Unchecked;
                        }
                    };

                    foreach (var subItem in this._FunctionVM.functionRepo.Items.Where(i => i.IdParent == mainItem.Id))
                    {
                        var roleFunction = _RoleFunctionVM.roleFunctionRepo.Items.FirstOrDefault(i => i.IdRole == role.Id && i.IdFunction == subItem.Id);

                        TreeViewItem treeViewItemSub = new TreeViewItem();

                        treeViewItemSub.Header = subItem.Name;
                        treeViewItemSub.Style = (Style)FindResource("TreeViewItemStyle");
                        treeViewItemSub.FontSize = 14;

                        treeViewItemMain.Items.Add(treeViewItemSub);

                        treeViewItemSub.Loaded += (sender2, e2) =>
                        {
                            CheckBox subCheckBox = treeViewItemSub.FindChild<CheckBox>("checkBox123");
                            treeViewItemSub.IsExpanded = true;
                            if (subCheckBox != null)
                            {
                                subCheckBox.Tag = subItem;

                                _ListCheckBoxSub.Add(subCheckBox);

                                if (roleFunction == null)
                                {
                                    subCheckBox.IsChecked = false;
                                }
                                else
                                {
                                    subCheckBox.IsChecked = true;
                                }
                                subCheckBox.Unchecked += CheckBox_Unchecked;
                                subCheckBox.Checked += CheckBox_Checked;
                            }
                        };
                    }
                }
                grdMain.Children.Add(tv);
                Button button = new Button();
                button.Content = "Save";
                button.Name = "btnSave";
                button.Click += btnSave_Click;
                button.Margin = new Thickness(10);
                Grid.SetRow(button, 1);
                grdMain.Children.Add(button);
            }
        }

        private void MainCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            SetIsHitTestVisible(false, false);

            SetLblSave(Brushes.Red);
            Function functionMain = (sender as CheckBox).Tag as Function;

            foreach (var item in _ListCheckBoxSub)
            {
                Function function = item.Tag as Function;

                if (functionMain.Id == function.IdParent)
                    item.IsChecked = false;
            }
        }

        private void MainCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            SetIsHitTestVisible(false, false);

            SetLblSave(Brushes.Red);

            Function functionMain = (sender as CheckBox).Tag as Function;

            int count = _ListCheckBoxSub.Where(i => (i.Tag as Function).IdParent == functionMain.Id).ToList().Count;

            foreach(var item in _ListCheckBoxSub.Where(i => (i.Tag as Function).IdParent == functionMain.Id))
            {
                if(item.IsChecked == false)
                {
                    count--;
                }
            }

            if(count == 0)
            {
                foreach(var item in _ListCheckBoxSub.Where(i => (i.Tag as Function).IdParent == functionMain.Id))
                {
                    item.IsChecked = true;
                }
            }
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            SetIsHitTestVisible(false, false);
            SetLblSave(Brushes.Red);

            Function function = (sender as CheckBox).Tag as Function;
            Function functionMain = _ListCheckBoxMain.FirstOrDefault(i => (i.Tag as Function).Id == function.IdParent).Tag as Function;

            int count = _ListCheckBoxSub.Where(i => (i.Tag as Function).IdParent == functionMain.Id).ToList().Count;

            foreach (var item in _ListCheckBoxSub.Where(i => (i.Tag as Function).IdParent == functionMain.Id))
            {
                if (item.IsChecked == false)
                {
                    count--;
                }
            }

            if (count == 0)
            {
                var item = _ListCheckBoxMain.Where(i => (i.Tag as Function).Id == ((sender as CheckBox).Tag as Function).IdParent).FirstOrDefault();
                item.IsChecked = false;
            }
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            SetIsHitTestVisible(false, false);
            SetLblSave(Brushes.Red);

            var item = _ListCheckBoxMain.Where(i => (i.Tag as Function).Id == ((sender as CheckBox).Tag as Function).IdParent).FirstOrDefault();
            item.IsChecked = true;
        }

        private void SetLblSave(Brush brush)
        {
            lblRole.Foreground = brush;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            SetIsHitTestVisible(true, true);

            SetLblSave(Brushes.Green);

            foreach (var item in _ListCheckBoxMain)
            {
                if(item.IsChecked == true)
                {
                    Function functionMain = item.Tag as Function;

                    var roleFunction = _RoleFunctionVM.roleFunctionRepo.Items.FirstOrDefault(i => i.IdRole == (cbRole.SelectedItem as Role).Id && i.IdFunction == functionMain.Id);
                    if (roleFunction != null)
                        _RoleManagementRepo.DeleteRoleFunction(roleFunction.Id);
                    _RoleManagementRepo.AddRoleFunction((cbRole.SelectedItem as Role).Id, ((item as CheckBox).Tag as Function).Id);
                }
                else
                {
                    Function functionMain = item.Tag as Function;

                    var roleFunction = _RoleFunctionVM.roleFunctionRepo.Items.FirstOrDefault(i => i.IdRole == (cbRole.SelectedItem as Role).Id && i.IdFunction == functionMain.Id);
                    if(roleFunction != null)
                        _RoleManagementRepo.DeleteRoleFunction(roleFunction.Id);
                }
            }

            foreach(var item in _ListCheckBoxSub)
            {
                if(item.IsChecked == true)
                {
                    var roleFunction = _RoleFunctionVM.roleFunctionRepo.Items.FirstOrDefault(i => i.IdRole == (cbRole.SelectedItem as Role).Id && i.IdFunction == ((item as CheckBox).Tag as Function).Id);
                    if (roleFunction != null)
                        _RoleManagementRepo.DeleteRoleFunction(roleFunction.Id);
                    _RoleManagementRepo.AddRoleFunction((cbRole.SelectedItem as Role).Id, ((item as CheckBox).Tag as Function).Id);
                }
                else
                {
                    var roleFunction = _RoleFunctionVM.roleFunctionRepo.Items.FirstOrDefault(i => i.IdRole == (cbRole.SelectedItem as Role).Id && i.IdFunction == ((item as CheckBox).Tag as Function).Id);
                    if(roleFunction != null)
                        _RoleManagementRepo.DeleteRoleFunction(roleFunction.Id);
                }
            }

            _FunctionVM.functionRepo.Load(false);

            foreach (var item in _ListCheckBoxMain)
            {
                if(item.IsChecked == false)
                {
                    var items = _FunctionVM.functionRepo.Items.Where(i => i.IdParent == (item.Tag as Function).Id);

                    foreach(var subItem in items)
                    {
                        var roleFunction = _RoleFunctionVM.roleFunctionRepo.Items.FirstOrDefault(i => i.IdRole == (cbRole.SelectedItem as Role).Id && i.IdFunction == subItem.Id);
                        if (roleFunction != null)
                            _RoleManagementRepo.DeleteRoleFunction(roleFunction.Id);
                    }
                }
                else
                {
                    var items = _FunctionVM.functionRepo.Items.Where(i => i.IdParent == (item.Tag as Function).Id);

                    foreach (var subItem in items)
                    {
                        var roleFunction = _RoleFunctionVM.roleFunctionRepo.Items.FirstOrDefault(i => i.IdRole == (cbRole.SelectedItem as Role).Id && i.IdFunction == subItem.Id);
                        if (roleFunction != null)
                            _RoleManagementRepo.DeleteRoleFunction(roleFunction.Id);
                        _RoleManagementRepo.AddRoleFunction((cbRole.SelectedItem as Role).Id, subItem.Id);
                    }
                }
            }
            _FunctionVM.functionRepo.Load(true);

            MessageBox.Show("Save Successfully!", "Notify", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}

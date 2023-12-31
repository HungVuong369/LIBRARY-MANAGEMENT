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
using Microsoft.Win32;
using System.IO;

namespace HungVuong_C5_Assignment
{
    /// <summary>
    /// Interaction logic for ucInputFeature.xaml
    /// </summary>
    public partial class ucInputFeature : UserControl
    {
        public delegate void TextChangedHandle(object sender, TextChangedEventArgs e);
        public event TextChangedEventHandler TextChangedEvent;

        public string NameFeature { get; set; }
        public string Description { get; set; }

        private FunctionViewModel _FunctionVM = new FunctionViewModel();

        public ucInputFeature()
        {
            InitializeComponent();
            DataContext = this;

        }

        private string OpenImageFile()
        {
            string imagePath = string.Empty;

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.jpg, *.png) | *.jpg; *.png";

            if (openFileDialog.ShowDialog() == true)
            {
                imagePath = openFileDialog.FileName;

                // Kiểm tra xem thư mục /Images có tồn tại không
                //string imagesDirectory = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName + "\\Images";

                //if (File.Exists(imagePath))
                //{
                //    if(_FunctionVM.functionRepo.Items.Find(i => i.UrlImage == $"/Images/{System.IO.Path.GetFileName(imagePath)}") == null)
                //    {
                //        // Tạo đường dẫn mới trong thư mục /Images
                //        string destinationPath = System.IO.Path.Combine(imagesDirectory, System.IO.Path.GetFileName(imagePath));

                //        // Copy tệp hình ảnh vào thư mục /Images
                //        File.Copy(imagePath, destinationPath, true);
                //    }
                //}
                //imagePath = $"/Images/{System.IO.Path.GetFileName(imagePath)}";
                //IncludeImageInProject("Images" + @"\" + $"{System.IO.Path.GetFileName(imagePath)}");
            }
            return imagePath;
        }

        private void IncludeImageInProject(string imagePath)
        {
            // Đường dẫn tới tệp hình ảnh trong project
            //string projectFilePath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "HungVuong_C4_B1.csproj");
            string projectFilePath = System.IO.Path.Combine(Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName, "HungVuong_C4_B1.csproj");

            // Đọc nội dung của tệp project vào một chuỗi
            string projectContent = File.ReadAllText(projectFilePath);


            // Tạo một phần tử <ItemGroup> chứa hình ảnh cần thêm vào project
            string itemGroup = $"<ItemGroup>\n\t<Resource Include=\"{imagePath}\" />\n</ItemGroup>";
            if (projectContent.Contains($"<Resource Include=\"{imagePath}\" />"))
            {
                return;
            }

            // Thay thế phần cuối cùng của tệp project với nội dung mới (bao gồm phần tử <ItemGroup>)
            projectContent = projectContent.Replace("</Project>", itemGroup + "</Project>");

            // Ghi lại nội dung đã thay đổi vào tệp project
            File.WriteAllText(projectFilePath, projectContent);
        }

        private void txtUrlImage_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txtUrlImage.IsFocused == true)
            {
                string path = OpenImageFile();

                if (path != string.Empty)
                {
                    SetImage(path);
                    txtUrlImage.Text = path;
                }
                txtUrlImage.MoveFocus(new TraversalRequest(FocusNavigationDirection.Up));
            }
        }

        private void btnSelect_Click(object sender, RoutedEventArgs e)
        {
            WindowDefault window = new WindowDefault();
            window.Tag = this.Tag;
            ucConfirmFeature confirm = new ucConfirmFeature(window);

            confirm.ucFunction.pagination.ChangedPageEvent += (sender1) =>
            {
                if (window.Tag == null)
                    confirm.ucFunction.ReloadDataGrid();
            };

            confirm.ucFunction.SetVisibilityButton(Visibility.Collapsed, Visibility.Collapsed, Visibility.Collapsed);
            window.grdContainer.Children.Add(confirm);
            window.ShowDialog();

            if (window.DialogResult == true)
            {
                Function function = window.Tag as Function;

                if (function == null)
                    return;

                txtParent.Tag = function;

                txtParent.Text = function.Name;
            }
        }

        public void ClearTextBox()
        {
            txtParent.Text = "None";
            txtParent.Tag = null;
            txtUrlImage.Text = "Click me!";
            txtName.Text = txtDescription.Text = string.Empty;
        }

        private void txtName_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextChangedEvent?.Invoke(sender, e);
        }

        private void SetImage(string url)
        {
            BitmapImage bitmapImage = new BitmapImage();
            bitmapImage.BeginInit();
            bitmapImage.UriSource = new Uri(url, UriKind.RelativeOrAbsolute);
            try
            {
                bitmapImage.EndInit();
            }
            catch (FileNotFoundException)
            {
                return;
            }
            catch(ArgumentException)
            {
                return;
            }
            catch (InvalidOperationException)
            {
                return;
            }
            imgFeature.Source = bitmapImage;
        }

        public void SetValue(Function function)
        {
            Description = function.Description;
            NameFeature = function.Name;
            Function parentFunction = _FunctionVM.functionRepo.Items.Find(i => i.Id == function.IdParent);
            if (parentFunction == null)
                txtParent.Text = "None";
            else
                txtParent.Text = parentFunction.Name;
            txtParent.Tag = parentFunction;

            if (function.UrlImage == "None")
                txtUrlImage.Text = "Click me!";
            else
            {
                txtUrlImage.Text = function.UrlImage;
                // Tạo một đối tượng BitmapImage
                SetImage(function.UrlImage);
            }
        }
    }
}

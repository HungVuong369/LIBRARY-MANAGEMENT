using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;

namespace HungVuong_C5_Assignment
{
    public class BookTitleViewModel : BaseViewModel
    {
        public string Name { get; set; }
        public string Summary { get; set; }
        public string UrlImage { get; set; } = "/Assets/Images/ErrorImage.png";
        public string DestinationPath { get; set; }
        public string FileName { get; set; }

        public Category SelectedCategory { get; set; }

        private static readonly UnitOfWork unitOfWork = new UnitOfWork();
        public BookTitleRepository bookTitleRepo;

        public ObservableCollection<Category> Categories { get; set; }

        private BitmapImage _imageSource = new BitmapImage(new Uri("/Assets/Images/ErrorImage.png", UriKind.Relative));

        public BitmapImage ImageSource
        {
            get { return _imageSource; }
            set
            {
                if (_imageSource != value)
                {
                    _imageSource = value;
                    OnPropertyChanged(nameof(ImageSource));
                }
            }
        }

        public RelayCommand<object> AddCommand { get; private set; }
        public RelayCommand<object> CancelCommand { get; private set; }
        public RelayCommand<object> ChooseImageCommand { get; private set; }

        public WindowDefault Parent;

        public BookTitleViewModel()
        {
            Categories = new ObservableCollection<Category>(DatabaseFirst.Instance.db.Categories);

            bookTitleRepo = unitOfWork.BookTitles;

            var newID = BookTitleRepository.GetNewID();

            if (Categories.Count != 0)
            {
                SelectedCategory = Categories[0];
            }

            AddCommand = new RelayCommand<object>(
                 p => { return true; },
                 p =>
                 {
                     BookTitleManagementRepository bookTitleManagementRepo = new BookTitleManagementRepository();

                     bool isCheck = true;

                     try
                     {
                         isCheck = bookTitleManagementRepo.Add(this.Name, this.SelectedCategory.Id, this.Summary, UrlImage);
                     }
                     catch (Exception)
                     {
                         Parent.DialogResult = isCheck = false;
                         MessageBox.Show("Please select a category", "Notify", MessageBoxButton.OK, MessageBoxImage.Warning);
                     }

                     if (isCheck)
                     {
                         if(UrlImage != "/Assets/Images/ErrorImage.png")
                         {
                             File.Copy(FileName, DestinationPath, true);
                         }

                         Parent.DialogResult = true;
                         Parent.Close();
                     }
                 }
             );

            CancelCommand = new RelayCommand<object>(
                p => { return true; },
                p =>
                {
                    Parent.DialogResult = false;
                    Parent.Close();
                }
            );

            ChooseImageCommand = new RelayCommand<object>(
                p => true,
                p =>
                {
                    OpenFileDialog openFileDialog = new OpenFileDialog();
                    openFileDialog.Filter = "Image files (*.png;*.jpg;*.jpeg)|*.png;*.jpg;*.jpeg|All files (*.*)|*.*";

                    if (openFileDialog.ShowDialog() == true)
                    {
                        // Lấy đường dẫn tương đối của thư mục dự án
                        string projectDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;

                        // Tạo đường dẫn đến thư mục lưu ảnh trong dự án
                        string imageDirectory = System.IO.Path.Combine(projectDirectory, "Assets/BookImages");

                        // Kiểm tra xem thư mục tồn tại chưa, nếu không thì tạo mới
                        if (!Directory.Exists(imageDirectory))
                        {
                            Directory.CreateDirectory(imageDirectory);
                        }

                        // Lấy tên file và tạo đường dẫn mới để sao chép vào
                        string fileName = System.IO.Path.GetFileName(openFileDialog.FileName);
                        DestinationPath = System.IO.Path.Combine(imageDirectory, $"{newID}{Path.GetExtension(fileName)}");
                        UrlImage = $"/Assets/BookImages/{newID}{Path.GetExtension(fileName)}";
                        // Sao chép file vào thư mục của dự án
                        FileName = openFileDialog.FileName;

                        // Hiển thị hình ảnh đã chọn
                        BitmapImage bitmap = new BitmapImage(new Uri(openFileDialog.FileName));
                        ImageSource = bitmap;
                    }
                }
            );
        }

        public bool isExist(string name, string categoryID, string summary)
        {
            foreach (var item in bookTitleRepo.Items)
            {
                if (item.Name.ToLower() == name && item.IdCategory == categoryID && item.Summary.ToLower() == summary)
                    return true;
            }
            return false;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HungVuong_C5_Assignment
{
    public class BookTitleViewModel
    {
        public string Name { get; set; }
        public string Summary { get; set; }

        public Category SelectedCategory { get; set; }

        private static readonly UnitOfWork unitOfWork = new UnitOfWork();
        public BookTitleRepository bookTitleRepo;

        public ObservableCollection<Category> Categories { get; set; }

        public RelayCommand<object> AddCommand { get; private set; }
        public RelayCommand<object> CancelCommand { get; private set; }

        public WindowDefault Parent;

        public BookTitleViewModel()
        {
            Categories = new ObservableCollection<Category>(DatabaseFirst.Instance.db.Categories);

            bookTitleRepo = unitOfWork.BookTitles;

            if (Categories.Count != 0)
            {
                SelectedCategory = Categories[0];
            }

            AddCommand = new RelayCommand<object>(
                p => { return true; },
                p => {
                    BookTitleManagementRepository bookTitleManagementRepo = new BookTitleManagementRepository();

                    bool isCheck = true;

                    try
                    {
                        isCheck = bookTitleManagementRepo.Add(this.Name, this.SelectedCategory.Id, this.Summary);
                    }
                    catch (Exception)
                    {
                        Parent.DialogResult = isCheck = false;
                        MessageBox.Show("Please select a category", "Notify", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }

                    if(isCheck)
                    {
                        Parent.DialogResult = true;
                        Parent.Close();
                    }
                }
            );

            CancelCommand = new RelayCommand<object>(
                p => { return true; },
                p => {
                    Parent.DialogResult = false;
                    Parent.Close();
                }
            );
        }

        public bool isExist(string name, string categoryID, string summary)
        {
            foreach(var item in bookTitleRepo.Items)
            {
                if (item.Name.ToLower() == name && item.IdCategory == categoryID && item.Summary.ToLower() == summary)
                    return true;
            }
            return false;
        }
    }
}

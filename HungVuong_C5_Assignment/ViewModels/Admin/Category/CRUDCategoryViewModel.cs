using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace HungVuong_C5_Assignment
{
    public class CRUDCategoryViewModel : BaseViewModel
    {
        public string CategoryName { get; set; }
        public string NewCategoryID { get; private set; } = CategoryRepository.GetNewID();

        private bool _IsEnabledAdd = false;
        public bool IsEnabledAdd
        {
            get
            {
                return _IsEnabledAdd;
            }
            set
            {
                _IsEnabledAdd = value;
                OnPropertyChanged();
            }
        }

        private Category UpdateCategory;

        public DateTime CreatedAt { get; private set; } = DateTime.Now;
        public DateTime ModifiedAt { get; private set; }

        public RelayCommand<object> NameTextChangedCommand { get; private set; }

        public RelayCommand<object> AddCommand { get; private set; }
        public RelayCommand<object> UpdateCommand { get; private set; }
        public RelayCommand<object> CancelCommand { get; private set; }

        public CRUDCategoryViewModel(WindowDefault parent, TextBox txtName)
        {
            AddCommand = new RelayCommand<object>(
                p => true,
                p =>
                {
                    if (DatabaseFirst.Instance.db.Categories.FirstOrDefault(i => i.Name.ToLower() == txtName.Text.Trim().ToLower()) != null)
                    {
                        MessageBox.Show("The category '" + txtName.Text + "' is existed!", "Notify", MessageBoxButton.OK, MessageBoxImage.Warning);
                        return;
                    }

                    parent.DialogResult = true;

                    parent.Tag = new Category()
                    {
                        Id = NewCategoryID,
                        CreatedAt = CreatedAt,
                        ModifiedAt = CreatedAt,
                        Name = txtName.Text.Trim(),
                        Status = true
                    };

                    parent.Close();
                }
            );

            UpdateCommand = new RelayCommand<object>(
                p => true,
                p =>
                {
                    if (DatabaseFirst.Instance.db.Categories.FirstOrDefault(i => i.Id != UpdateCategory.Id && i.Name.ToLower() == txtName.Text.Trim().ToLower()) != null)
                    {
                        MessageBox.Show("The category '" + txtName.Text + "' is existed!", "Notify", MessageBoxButton.OK, MessageBoxImage.Warning);
                        return;
                    }

                    parent.DialogResult = true;

                    parent.Tag = new Category()
                    {
                        Id = NewCategoryID,
                        CreatedAt = CreatedAt,
                        ModifiedAt = DateTime.Now,
                        Name = txtName.Text.Trim(),
                        Status = true
                    };

                    parent.Close();
                }
            );

            CancelCommand = new RelayCommand<object>(
                p => true,
                p =>
                {
                    parent.DialogResult = false;
                    parent.Close();
                }
            );

            NameTextChangedCommand = new RelayCommand<object>(
                p => true,
                p =>
                {
                    bool isNumeric = txtName.Text.Replace(" ", "").All(char.IsLetter);

                    if (!isNumeric || txtName.Text == string.Empty || txtName.Text == null)
                        IsEnabledAdd = false;
                    else
                        IsEnabledAdd = true;
                }
            );
        }

        public void Update(Category category)
        {
            IsEnabledAdd = true;
            NewCategoryID = category.Id;
            CreatedAt = category.CreatedAt;
            ModifiedAt = category.ModifiedAt;
            CategoryName = category.Name;
            OnPropertyChanged(nameof(CategoryName));
            UpdateCategory = category;
        }
    }
}

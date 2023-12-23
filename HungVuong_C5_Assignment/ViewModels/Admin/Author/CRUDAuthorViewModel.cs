using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace HungVuong_C5_Assignment
{
    public class CRUDAuthorViewModel : BaseViewModel
    {
        public string AuthorName { get; set; }
        public string Description { get; set; }
        public string Summary { get; set; }
        public DateTime BoF { get; set; } = new DateTime(1753, 1, 1);
        public string NewAuthorID { get; private set; } = AuthorRepository.GetNewID();

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

        private Author UpdateAuthor;

        public DateTime CreatedAt { get; private set; } = DateTime.Now;
        public DateTime ModifiedAt { get; private set; }

        public RelayCommand<object> NameTextChangedCommand { get; private set; }

        public RelayCommand<object> AddCommand { get; private set; }
        public RelayCommand<object> UpdateCommand { get; private set; }
        public RelayCommand<object> CancelCommand { get; private set; }

        public CRUDAuthorViewModel(WindowDefault parent, TextBox txtName, TextBox txtDescription, TextBox txtSummary)
        {
            AddCommand = new RelayCommand<object>(
                p => true,
                p =>
                {
                    parent.DialogResult = true;

                    parent.Tag = new Author()
                    {
                        Id = NewAuthorID,
                        CreatedAt = CreatedAt,
                        ModifiedAt = CreatedAt,
                        Name = txtName.Text.Trim(),
                        Status = true,
                        boF = BoF,
                        Description = Description,
                        Summary = Summary
                    };

                    parent.Close();
                }
            );

            UpdateCommand = new RelayCommand<object>(
                p => true,
                p =>
                {
                    parent.DialogResult = true;

                    parent.Tag = new Author()
                    {
                        Id = NewAuthorID,
                        CreatedAt = CreatedAt,
                        ModifiedAt = DateTime.Now,
                        Name = txtName.Text.Trim(),
                        Status = true,
                        Summary = Summary,
                        Description = Description,
                        boF = BoF
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

                    IsEnabledAdd = true;

                    if (!isNumeric || txtName.Text == string.Empty || txtName.Text == null)
                        IsEnabledAdd = false;

                    if (string.IsNullOrWhiteSpace(txtDescription.Text))
                    {
                        IsEnabledAdd = false;
                    }

                    if (Regex.IsMatch(txtDescription.Text, @"^\d+$"))
                    {
                        IsEnabledAdd = false;
                    }

                    if (string.IsNullOrWhiteSpace(txtSummary.Text))
                    {
                        IsEnabledAdd = false;
                    }

                    if (Regex.IsMatch(txtSummary.Text, @"^\d+$"))
                    {
                        IsEnabledAdd = false;
                    }
                }
            );
        }

        public void Update(Author author)
        {
            IsEnabledAdd = true;
            NewAuthorID = author.Id;
            CreatedAt = author.CreatedAt;
            ModifiedAt = author.ModifiedAt;
            AuthorName = author.Name;
            UpdateAuthor = author;
            Description = author.Description;
            Summary = author.Summary;

            OnPropertyChanged(nameof(AuthorName));
            OnPropertyChanged(nameof(Description));
            OnPropertyChanged(nameof(Summary));
        }
    }
}

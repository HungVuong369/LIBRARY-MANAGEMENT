using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace HungVuong_C5_Assignment
{
    public class CRUDTranslatorViewModel :BaseViewModel
    {
        public string AuthorName { get; set; }
        public string Description { get; set; }
        public string Summary { get; set; }
        public DateTime BoF { get; set; } = new DateTime(1753, 1, 1);
        public string NewTranslatorID { get; private set; } = TranslatorRepository.GetNewID();

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

        private Translator UpdateTranslator;

        public DateTime CreatedAt { get; private set; } = DateTime.Now;
        public DateTime ModifiedAt { get; private set; }

        public RelayCommand<object> NameTextChangedCommand { get; private set; }

        public RelayCommand<object> AddCommand { get; private set; }
        public RelayCommand<object> UpdateCommand { get; private set; }
        public RelayCommand<object> CancelCommand { get; private set; }

        public CRUDTranslatorViewModel(WindowDefault parent, TextBox txtName, TextBox txtDescription, TextBox txtSummary)
        {
            AddCommand = new RelayCommand<object>(
                p => true,
                p =>
                {
                    parent.DialogResult = true;

                    parent.Tag = new Translator()
                    {
                        Id = NewTranslatorID,
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

                    parent.Tag = new Translator()
                    {
                        Id = NewTranslatorID,
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

        public void Update(Translator translator)
        {
            IsEnabledAdd = true;
            NewTranslatorID = translator.Id;
            CreatedAt = translator.CreatedAt;
            ModifiedAt = translator.ModifiedAt;
            AuthorName = translator.Name;
            UpdateTranslator = translator;
            Description = translator.Description;
            Summary = translator.Summary;

            OnPropertyChanged(nameof(AuthorName));
            OnPropertyChanged(nameof(Description));
            OnPropertyChanged(nameof(Summary));
        }
    }
}

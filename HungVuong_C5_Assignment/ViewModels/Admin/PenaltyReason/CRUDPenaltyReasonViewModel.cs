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
    class CRUDPenaltyReasonViewModel : BaseViewModel
    {
        public string PenaltyReasonName { get; set; }
        public string Description { get; set; }
        public string Price { get; set; } = "0,000";
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime ModifiedAt { get; set; }
        public string NewPenaltyReasonID { get; private set; } = PenaltyReasonRepository.GetNewID();

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

        private PenaltyReason UpdatePenaltyReason;

        public RelayCommand<object> TextChanged { get; private set; }
        public RelayCommand<object> PriceTextChanged { get; private set; }

        public RelayCommand<object> AddCommand { get; private set; }
        public RelayCommand<object> UpdateCommand { get; private set; }
        public RelayCommand<object> CancelCommand { get; private set; }

        public CRUDPenaltyReasonViewModel(WindowDefault parent, TextBox txtName, TextBox txtDescription, TextBox txtPrice)
        {
            AddCommand = new RelayCommand<object>(
                p => true,
                p =>
                {
                    if (DatabaseFirst.Instance.db.PenaltyReasons.FirstOrDefault(i => i.Name.ToLower() == txtName.Text.Trim().ToLower()) != null)
                    {
                        MessageBox.Show("The PenaltyReason '" + txtName.Text + "' is existed!", "Notify", MessageBoxButton.OK, MessageBoxImage.Warning);
                        return;
                    }

                    parent.DialogResult = true;

                    parent.Tag = new PenaltyReason()
                    {
                        Id = NewPenaltyReasonID,
                        Name = txtName.Text.Trim(),
                        CreatedAt = CreatedAt,
                        ModifiedAt = CreatedAt,
                        Description = txtDescription.Text.Trim(),
                        Price = decimal.Parse(Price.Replace(".", ",").Replace(",", "").Insert(Price.Replace(".", ",").Replace(",", "").Length - 3, "."))
                    };

                    parent.Close();
                }
            );

            UpdateCommand = new RelayCommand<object>(
                p => true,
                p =>
                {
                    if (DatabaseFirst.Instance.db.PenaltyReasons.FirstOrDefault(i => i.Id != UpdatePenaltyReason.Id && i.Name.ToLower() == txtName.Text.Trim().ToLower()) != null)
                    {
                        MessageBox.Show("The PenaltyReason '" + txtName.Text + "' is existed!", "Notify", MessageBoxButton.OK, MessageBoxImage.Warning);
                        return;
                    }

                    parent.DialogResult = true;

                    parent.Tag = new PenaltyReason()
                    {
                        Id = NewPenaltyReasonID,
                        Name = txtName.Text.Trim(),
                        CreatedAt = CreatedAt,
                        ModifiedAt = DateTime.Now,
                        Price = decimal.Parse(Price.Replace(".", ",").Replace(",", "").Insert(Price.Replace(".", ",").Replace(",", "").Length - 3, ".")),
                        Description = txtDescription.Text.Trim()
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

            TextChanged = new RelayCommand<object>(
                p => true,
                p =>
                {
                    bool isNumeric = txtName.Text.Replace(" ", "").All(char.IsLetter);

                    IsEnabledAdd = true;

                    if (!isNumeric || txtName.Text == string.Empty || txtName.Text == null)
                        IsEnabledAdd = false;

                    if (txtDescription.Text == null || string.IsNullOrWhiteSpace(txtDescription.Text))
                    {
                        IsEnabledAdd = false;
                    }
                }
            );

            PriceTextChanged = new RelayCommand<object>(
                p => true,
                p =>
                {
                    if (txtPrice.Text == string.Empty)
                    {
                        txtPrice.Text = "0,000";
                        return;
                    }

                    if (txtPrice.Text.Length <= 3)
                    {
                        txtPrice.Text = txtPrice.Text + ",000";
                    }
                    else
                    {
                        if (txtPrice.Text == "0.000" || txtPrice.Text == "0,000")
                        {
                            return;
                        }
                        if (txtPrice.Text.Substring(1) == ",00" || txtPrice.Text.Substring(1) == ".00")
                        {
                            txtPrice.Text = "0,000";
                            return;
                        }

                        txtPrice.Text = double.Parse(Price.Replace(",", "")).ToString("N0");
                    }
                    txtPrice.SelectionStart = Price.Length - 4;
                }
            );
        }

        public void Update(PenaltyReason PenaltyReason)
        {
            IsEnabledAdd = true;
            NewPenaltyReasonID = PenaltyReason.Id;

            PenaltyReasonName = PenaltyReason.Name;
            Description = PenaltyReason.Description;
            CreatedAt = PenaltyReason.CreatedAt;
            ModifiedAt = PenaltyReason.ModifiedAt;

            if(PenaltyReason.Price == 0)
            {
                Price = "0,000";
            }
            else
                Price = PenaltyReason.Price.ToString().Replace(".", ",");

            OnPropertyChanged(nameof(PenaltyReasonName));
            OnPropertyChanged(nameof(Description));
            OnPropertyChanged(nameof(Price));

            UpdatePenaltyReason = PenaltyReason;
        }
    }
}

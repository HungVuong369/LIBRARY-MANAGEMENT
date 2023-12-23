using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace HungVuong_C5_Assignment
{
    public class CRUDProvinceViewModel : BaseViewModel
    {
        public string ProvinceName { get; set; }
        public string NewProvinceID { get; private set; } = ProvinceRepository.GetNewID();

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

        public bool Status { get; set; }

        private Province UpdateProvince;

        public RelayCommand<object> NameTextChangedCommand { get; private set; }

        public RelayCommand<object> AddCommand { get; private set; }
        public RelayCommand<object> UpdateCommand { get; private set; }
        public RelayCommand<object> CancelCommand { get; private set; }

        public CRUDProvinceViewModel(WindowDefault parent, TextBox txtName)
        {
            AddCommand = new RelayCommand<object>(
                p => true,
                p =>
                {
                    if (DatabaseFirst.Instance.db.Provinces.FirstOrDefault(i => i.Name.ToLower() == txtName.Text.Trim().ToLower()) != null)
                    {
                        MessageBox.Show("The Province '" + txtName.Text + "' is existed!", "Notify", MessageBoxButton.OK, MessageBoxImage.Warning);
                        return;
                    }

                    parent.DialogResult = true;

                    parent.Tag = new Province()
                    {
                        Id = int.Parse(NewProvinceID),
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
                    if (DatabaseFirst.Instance.db.Provinces.FirstOrDefault(i => i.Id != UpdateProvince.Id && i.Name.ToLower() == txtName.Text.Trim().ToLower()) != null)
                    {
                        MessageBox.Show("The Province '" + txtName.Text + "' is existed!", "Notify", MessageBoxButton.OK, MessageBoxImage.Warning);
                        return;
                    }

                    parent.DialogResult = true;

                    parent.Tag = new Province()
                    {
                        Id = int.Parse(NewProvinceID),
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

        public void Update(Province Province)
        {
            IsEnabledAdd = true;
            NewProvinceID = Province.Id.ToString();
            ProvinceName = Province.Name;
            OnPropertyChanged(nameof(ProvinceName));
            UpdateProvince = Province;
            Status = Province.Status;
        }
    }
}

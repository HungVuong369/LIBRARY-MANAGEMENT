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
    public class CRUDPublisherViewModel : BaseViewModel
    {
        public string PublisherName { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string NewPublisherID { get; private set; } = PublisherRepository.GetNewID();

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

        private Publisher UpdatePublisher;

        public RelayCommand<object> TextChanged { get; private set; }

        public RelayCommand<object> AddCommand { get; private set; }
        public RelayCommand<object> UpdateCommand { get; private set; }
        public RelayCommand<object> CancelCommand { get; private set; }

        public CRUDPublisherViewModel(WindowDefault parent, TextBox txtName, TextBox txtPhone, TextBox txtAddress)
        {
            AddCommand = new RelayCommand<object>(
                p => true,
                p =>
                {
                    if (DatabaseFirst.Instance.db.Publishers.FirstOrDefault(i => i.Name.ToLower() == txtName.Text.Trim().ToLower()) != null)
                    {
                        MessageBox.Show("The publisher '" + txtName.Text + "' is existed!", "Notify", MessageBoxButton.OK, MessageBoxImage.Warning);
                        return;
                    }

                    parent.DialogResult = true;

                    parent.Tag = new Publisher()
                    {
                        Id = NewPublisherID,
                        Name = txtName.Text.Trim(),
                        Address = txtAddress.Text.Trim(),
                        Phone = txtPhone.Text.Trim()
                    };

                    parent.Close();
                }
            );

            UpdateCommand = new RelayCommand<object>(
                p => true,
                p =>
                {
                    if (DatabaseFirst.Instance.db.Publishers.FirstOrDefault(i => i.Id != UpdatePublisher.Id && i.Name.ToLower() == txtName.Text.Trim().ToLower()) != null)
                    {
                        MessageBox.Show("The publisher '" + txtName.Text + "' is existed!", "Notify", MessageBoxButton.OK, MessageBoxImage.Warning);
                        return;
                    }

                    parent.DialogResult = true;

                    parent.Tag = new Publisher()
                    {
                        Id = NewPublisherID,
                        Name = txtName.Text.Trim(),
                        Address = txtAddress.Text.Trim(),
                        Phone = txtPhone.Text.Trim()
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

                    if (string.IsNullOrWhiteSpace(txtPhone.Text))
                        IsEnabledAdd = false;

                    if (!Regex.IsMatch(txtPhone.Text, @"^\d{10}$"))
                        IsEnabledAdd = false;

                    if (string.IsNullOrWhiteSpace(txtAddress.Text))
                        IsEnabledAdd = false;

                    if (Regex.IsMatch(txtAddress.Text, @"^\d+$"))
                        IsEnabledAdd = false;
                }
            );
        }

        public void Update(Publisher publisher)
        {
            IsEnabledAdd = true;
            NewPublisherID = publisher.Id;
            PublisherName = publisher.Name;
            Phone = publisher.Phone;
            Address = publisher.Address;
            OnPropertyChanged(nameof(PublisherName));
            OnPropertyChanged(nameof(Phone));
            OnPropertyChanged(nameof(Address));

            UpdatePublisher = publisher;
        }
    }
}

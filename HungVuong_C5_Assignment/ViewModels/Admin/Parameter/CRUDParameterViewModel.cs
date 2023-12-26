using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace HungVuong_C5_Assignment
{
    public class CRUDParameterViewModel : BaseViewModel
    {
        public string ParameterName { get; set; }
        public string Description { get; set; }
        public string Value { get; set; }
        public string NewParameterID { get; private set; } = ParameterRepository.GetNewID();

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

        private Parameter UpdateParameter;

        public DateTime CreatedAt { get; private set; } = DateTime.Now;
        public DateTime ModifiedAt { get; private set; }

        public RelayCommand<object> NameTextChangedCommand { get; private set; }

        public RelayCommand<object> ValueTextChangedCommand { get; private set; }
        public RelayCommand<object> ValueIntergerCommand { get; private set; }
        public RelayCommand<object> ValueDecimalCommand { get; private set; }
        public RelayCommand<object> ValuePercentCommand { get; private set; }

        public RelayCommand<object> AddCommand { get; private set; }
        public RelayCommand<object> UpdateCommand { get; private set; }
        public RelayCommand<object> CancelCommand { get; private set; }

        public CRUDParameterViewModel(WindowDefault parent, TextBox txtName, TextBox txtDescription, TextBox txtValue)
        {
            AddCommand = new RelayCommand<object>(
                p => true,
                p =>
                {
                    if (DatabaseFirst.Instance.db.Parameters.FirstOrDefault(i => i.Name.ToLower() == txtName.Text.Trim().ToLower()) != null)
                    {
                        MessageBox.Show("The Parameter '" + txtName.Text + "' is existed!", "Notify", MessageBoxButton.OK, MessageBoxImage.Warning);
                        return;
                    }

                    parent.DialogResult = true;

                    parent.Tag = new Parameter()
                    {
                        Id = NewParameterID,
                        CreatedAt = CreatedAt,
                        ModifiedAt = CreatedAt,
                        Name = txtName.Text.Trim(),
                        Description = txtDescription.Text.Trim(),
                        Value = txtValue.Text.Trim(),
                        Status = true
                    };

                    parent.Close();
                }
            );

            UpdateCommand = new RelayCommand<object>(
                p => true,
                p =>
                {
                    if (DatabaseFirst.Instance.db.Categories.FirstOrDefault(i => i.Id != UpdateParameter.Id && i.Name.ToLower() == txtName.Text.Trim().ToLower()) != null)
                    {
                        MessageBox.Show("The Parameter '" + txtName.Text + "' is existed!", "Notify", MessageBoxButton.OK, MessageBoxImage.Warning);
                        return;
                    }

                    if(NewParameterID == "QD1")
                    {
                        int maxChildInAdult = DatabaseFirst.Instance.db.Adults.Select(i => i.Children.Count).Max();

                        if (int.Parse(txtValue.Text) < maxChildInAdult)
                        {
                            MessageBox.Show("Cannot update new value!", "Notify", MessageBoxButton.OK, MessageBoxImage.Warning);
                            return;
                        }
                    }

                    if(NewParameterID == "QD2")
                    {
                        int max = 0;
                        foreach(var item in DatabaseFirst.Instance.db.Readers.ToList())
                        {
                            if(item.ReaderType)
                            {
                                int quantityLoanSlipAdult = item.LoanSlips.Select(i => i.Quantity).Sum();
                                int quantityLoanSlipChild = item.Adult.Children.Select(i => i.Reader.LoanSlips.Select(loanSlip => loanSlip.Quantity).Sum()).Sum();

                                if (quantityLoanSlipChild + quantityLoanSlipAdult > max)
                                    max = quantityLoanSlipAdult + quantityLoanSlipChild;
                            }
                        }

                        if(int.Parse(Value) < max)
                        {
                            MessageBox.Show("Cannot update new value!", "Notify", MessageBoxButton.OK, MessageBoxImage.Warning);
                            return;
                        }
                    }

                    if(NewParameterID == "QD3")
                    {
                        int max = 0;
                        foreach(var item in DatabaseFirst.Instance.db.Readers.Where(i => i.ReaderType == false))
                        {
                            int quantity = item.LoanSlips.Select(i => i.Quantity).Sum();
                            if (quantity > max)
                                max = quantity;
                        }

                        if (int.Parse(Value) < max)
                        {
                            MessageBox.Show("Cannot update new value!", "Notify", MessageBoxButton.OK, MessageBoxImage.Warning);
                            return;
                        }
                    }

                    parent.DialogResult = true;

                    string valueTemp = string.Empty;

                    if(NewParameterID == "QD10")
                    {
                        valueTemp = decimal.Parse(Value.Replace(".", ",").Replace(",", "").Insert(Value.Replace(".", ",").Replace(",", "").Length - 3, ".")).ToString();
                    }
                    else
                    {
                        valueTemp = txtValue.Text.Trim();
                    }

                    parent.Tag = new Parameter()
                    {
                        Id = NewParameterID,
                        CreatedAt = CreatedAt,
                        ModifiedAt = DateTime.Now,
                        Name = txtName.Text.Trim(),
                        Description = txtDescription.Text.Trim(),
                        Value = valueTemp,
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
                    SetEnabledButton(txtName.Text, txtDescription.Text, txtValue.Text);
                }
            );

            ValueTextChangedCommand = new RelayCommand<object>(
                p => true,
                p =>
                {
                    SetEnabledButton(txtName.Text, txtDescription.Text, txtValue.Text);
                }
            );

            ValueIntergerCommand = new RelayCommand<object>(
                p => false,
                p =>
                {
                    if (txtValue.Text == string.Empty)
                    {
                        SetEnabledButton(txtName.Text, txtDescription.Text, txtValue.Text);
                        return;
                    }
                    if (txtValue.Text.FirstOrDefault(i => !char.IsDigit(i)) != 0)
                    {
                        string letter = txtValue.Text.FirstOrDefault(i => !char.IsDigit(i)).ToString();
                        txtValue.Text = txtValue.Text.Replace(letter, "");
                        txtValue.SelectionStart = txtValue.Text.Length;
                    }
                    SetEnabledButton(txtName.Text, txtDescription.Text, txtValue.Text);
                }
            );

            ValueDecimalCommand = new RelayCommand<object>(
                p => false,
                p =>
                {
                    if (txtValue.Text == string.Empty)
                    {
                        txtValue.Text = "0,000";
                        return;
                    }

                    if (txtValue.Text.Length <= 3)
                    {
                        txtValue.Text = txtValue.Text + ",000";
                    }
                    else
                    {
                        if (txtValue.Text == "0.000" || txtValue.Text == "0,000")
                        {
                            return;
                        }
                        if (txtValue.Text.Substring(1) == ",00" || txtValue.Text.Substring(1) == ".00")
                        {
                            txtValue.Text = "0,000";
                            return;
                        }

                        txtValue.Text = double.Parse(Value.Replace(",", "")).ToString("N0");
                    }
                    txtValue.SelectionStart = Value.Length - 4;
                }
            );

            ValuePercentCommand = new RelayCommand<object>(
                p => false,
                p =>
                {
                    if(!txtValue.Text.Contains("%"))
                        txtValue.Text += "%";

                    if(txtValue.Text.Contains("%") && txtValue.Text.Length == 1)
                    {
                        txtValue.Text = "0%";
                    }
                    int value = int.Parse(txtValue.Text.Split('%')[0].ToString());
                    txtValue.Text = value + "%";
                    txtValue.SelectionStart = txtValue.Text.Length - 1;
                }
            );
        }

        private void TxtValue_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            if(e.Text != string.Empty && !char.IsDigit(e.Text[0]))
            {
                e.Handled = true;
            }
        }

        public void Update(Parameter Parameter, TextBox txtValue)
        {
            IsEnabledAdd = true;
            NewParameterID = Parameter.Id;
            CreatedAt = Parameter.CreatedAt;
            ModifiedAt = Parameter.ModifiedAt;
            ParameterName = Parameter.Name;
            Description = Parameter.Description;
            Value = Parameter.Value;

            OnPropertyChanged(nameof(ParameterName));
            UpdateParameter = Parameter;

            switch(Parameter.Id)
            {
                case "QD1":
                case "QD2":
                case "QD3":
                case "QD7":
                case "QD8":
                case "QD9":
                    ValueTextChangedCommand.SetCanExecute(false);
                    ValueIntergerCommand.SetCanExecute(true);
                    break;
                case "QD10":
                    ValueTextChangedCommand.SetCanExecute(false);
                    ValueDecimalCommand.SetCanExecute(true);
                    Value = Parameter.Value.Replace(".", ",");
                    txtValue.PreviewTextInput += TxtValue_PreviewTextInput;
                    break;
                case "QD11":
                    ValueTextChangedCommand.SetCanExecute(false);
                    ValuePercentCommand.SetCanExecute(true);
                    txtValue.PreviewTextInput += TxtValue_PreviewTextInput;
                    break;

            }
        }

        private void SetEnabledButton(string name, string description, string value)
        {
            IsEnabledAdd = true;

            if (string.IsNullOrEmpty(name) || string.IsNullOrWhiteSpace(name))
            {
                IsEnabledAdd = false;
            }

            //if (string.IsNullOrEmpty(description) || string.IsNullOrWhiteSpace(description))
            //{
            //    IsEnabledAdd = false;
            //}

            if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
            {
                IsEnabledAdd = false;
            }
        }
    }
}

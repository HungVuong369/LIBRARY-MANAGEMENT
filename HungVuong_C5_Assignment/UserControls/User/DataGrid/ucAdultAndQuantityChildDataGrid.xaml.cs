using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace HungVuong_C5_Assignment
{
    /// <summary>
    /// Interaction logic for ucAdultAndQuantityChildDataGrid.xaml
    /// </summary>
    public partial class ucAdultAndQuantityChildDataGrid : UserControl
    {
        private ChildViewModel childVM = new ChildViewModel();
        private List<Guardian> _Guardians;
        private List<Guardian> _GuardiansUpdate = new List<Guardian>();
        private ParameterViewModel _ParameterVM = new ParameterViewModel();

        public ucAdultAndQuantityChildDataGrid()
        {
            InitializeComponent();

            UpdateDataGridByQuantityChild(int.Parse(_ParameterVM.GetValueByID("QU1")));
        }

        public void RemoveGuardianByQuantityChild(int quantity)
        {
            var items = this._Guardians.Where(g => g.QuantityChild == quantity).ToList();

            foreach(var item in items)
            {
                this._Guardians.Remove(item);
            }

            dgAdult.ItemsSource = GetListGuardianByIdentify(string.Empty);
        }

        public void UpdateDataGridByQuantityChild(int quantity)
        {
            _Guardians = DataAccess.GetListGuardian(quantity);

            dgAdult.ItemsSource = null;

            dgAdult.ItemsSource = GetListGuardianByIdentify(string.Empty);
        }

        public void SelectedItemByIdentify(string identify)
        {
            int index = 0;
            foreach(Guardian item in dgAdult.Items)
            {
                if (item.Identify == identify)
                {
                    dgAdult.SelectedIndex = index;
                    break;
                }
                index++;
            }
        }

        private List<Guardian> GetListGuardianByIdentify(string identify)
        {
            this._GuardiansUpdate.Clear();

            foreach (var item in _Guardians)
            {
                if (item.Identify.Contains(identify))
                {
                    this._GuardiansUpdate.Add(item);
                }
            }

            return this._GuardiansUpdate;
        }

        public void RemoveByGuardian(Guardian guardian)
        {
            this._Guardians.Remove(guardian);
            this._GuardiansUpdate.Remove(guardian);
        }

        public void UpdateDataGrid()
        {
            dgAdult.ItemsSource = null;
            dgAdult.ItemsSource = this._GuardiansUpdate;
        }

        public void UpdateDataGridByIdentify(string identify)
        {
            dgAdult.ItemsSource = null;
            dgAdult.ItemsSource = GetListGuardianByIdentify(identify.Trim());
        }
    }
}

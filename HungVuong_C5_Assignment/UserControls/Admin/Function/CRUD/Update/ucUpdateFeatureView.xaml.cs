using System;
using System.Collections.Generic;
using System.Linq;
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
    /// Interaction logic for ucUpdateFeatureView.xaml
    /// </summary>
    public partial class ucUpdateFeatureView : UserControl
    {
        private WindowDefault _Parent;
        private FunctionViewModel _FunctionVM = new FunctionViewModel();
        private FeatureManagementRepository _FeatureManagementRepo = new FeatureManagementRepository();

        public ucUpdateFeatureView(WindowDefault parent, Function function)
        {
            InitializeComponent();
            ucInputFeature.SetValue(function);
            this._Parent = parent;
            _Parent.Tag = function.Id;
            ucInputFeature.Tag = function.Id;
            ucInputFeature.TextChangedEvent += UcInputFeature_TextChangedEvent;
            btnUpdate.IsEnabled = isCheckValidation();
        }

        private bool isCheckValidation()
        {
            bool isCheck = true;

            if (StaticValidation.GetValidationRule<InputTextRule>(ucInputFeature.txtName) == null)
            {
                isCheck = false;
            }
            else if (StaticValidation.GetValidationRule<InputTextAndNumber>(ucInputFeature.txtDescription) == null)
            {
                isCheck = false;
            }
            return isCheck;
        }

        private void UcInputFeature_TextChangedEvent(object sender, TextChangedEventArgs e)
        {
            btnUpdate.IsEnabled = isCheckValidation();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            bool isUpdated = _FeatureManagementRepo.Update(ucInputFeature.txtParent.Tag as Function, ucInputFeature.Tag.ToString(), ucInputFeature.txtName.Text, ucInputFeature.txtDescription.Text, ucInputFeature.txtUrlImage.Text);

            if (!isUpdated)
                return;

            _Parent.DialogResult = true;

            _Parent.Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            _Parent.DialogResult = false;
            _Parent.Close();
        }
    }
}

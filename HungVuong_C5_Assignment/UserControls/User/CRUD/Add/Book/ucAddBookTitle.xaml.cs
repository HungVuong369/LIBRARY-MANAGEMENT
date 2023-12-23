using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for ucAddBookTitle.xaml
    /// </summary>
    public partial class ucAddBookTitle : UserControl
    {
        private BookTitleManagementRepository _BookTitleManagementRepo = new BookTitleManagementRepository();

        private BookTitleViewModel _BookTitleVM = new BookTitleViewModel();

        public ucAddBookTitle(WindowDefault window)
        {
            InitializeComponent();
            BookTitleViewModel bookTitleVM = new BookTitleViewModel();
            bookTitleVM.Parent = window;

            btnAdd.IsEnabled = IsCheckValidation();

            DataContext = bookTitleVM;
        }

        private bool IsCheckValidation()
        {
            bool isCheck = true;
            if (StaticValidation.GetValidationRule<InputTextAndNumber>(txtBookTitleName) == null)
                isCheck = false;
            if(StaticValidation.GetValidationRule<InputTextAndNumber>(txtSummary) == null)
                isCheck = false;
            return isCheck;
        }

        private void txtBookTitleName_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (e.Text != string.Empty && char.IsDigit(e.Text[0]))
                e.Handled = true;
        }

        private bool isEmptyTextBox()
        {
            if (txtBookTitleName.Text == string.Empty)
            {
                txtBookTitleName.Focus();
                return true;
            }

            if (txtSummary.Text == string.Empty)
            {
                txtSummary.Focus();
                return true;
            }

            return false;
        }

        private void txtBookTitleName_TextChanged(object sender, TextChangedEventArgs e)
        {
            btnAdd.IsEnabled = IsCheckValidation();
        }
    }
}

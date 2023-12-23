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
    /// Interaction logic for ucUpdatePublisher.xaml
    /// </summary>
    public partial class ucUpdatePublisher : UserControl
    {
        public ucUpdatePublisher(WindowDefault window, Publisher publisher)
        {
            InitializeComponent();
            CRUDPublisherViewModel crud = new CRUDPublisherViewModel(window, txtName, txtPhone, txtAddress);
            crud.Update(publisher);
            DataContext = crud;
        }

        private void txtPhone_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (e.Text != string.Empty && !char.IsDigit(e.Text[0]))
                e.Handled = true;
        }

        private void txtPhone_TextChanged(object sender, TextChangedEventArgs e)
        {
            txtPhone.Text = txtPhone.Text.Trim();
        }
    }
}

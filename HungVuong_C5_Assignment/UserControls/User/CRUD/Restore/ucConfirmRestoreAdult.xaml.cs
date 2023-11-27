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
    /// Interaction logic for ucConfirmAdult.xaml
    /// </summary>
    public partial class ucConfirmRestoreAdult : UserControl
    {
        private WindowDefault _ParentWindow;
        private ReaderViewModel readerVM = new ReaderViewModel();
        public Child Child1 { get; set; }
        public Child Child2 { get; set; }
        public Reader ChildReader1 { get; set; }
        public Reader ChildReader2 { get; set; }

        public string FullNameChild1 { get; set; }
        public string FullNameChild2 { get; set; }

        public ucConfirmRestoreAdult(WindowDefault parentWindow, Reader childReader1, Child child1, Reader childReader2, Child child2)
        {
            InitializeComponent();

            this._ParentWindow = parentWindow;
            this.Child1 = child1;
            this.Child2 = child2;

            this.ChildReader1 = childReader1;
            FullNameChild1 = childReader1.LName + " " + childReader1.FName;

            if (child2 != null)
            {
                this.ChildReader2 = childReader2;
                grdChild2.Visibility = grdChildReader2.Visibility = Visibility.Visible;
                FullNameChild2 = childReader2.LName + " " + childReader2.FName;
            }

            this.DataContext = this;
        }

        private void btnRestore_Click(object sender, RoutedEventArgs e)
        {
            this._ParentWindow.DialogResult = true;
            this._ParentWindow.Tag = "Restore All Child And Adult";
            this._ParentWindow.Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this._ParentWindow.DialogResult = false;
            this._ParentWindow.Close();
        }

        private void btnRestoreAdult_Click(object sender, RoutedEventArgs e)
        {
            this._ParentWindow.DialogResult = true;
            this._ParentWindow.Tag = "Restore Adult";
            this._ParentWindow.Close();
        }
    }
}

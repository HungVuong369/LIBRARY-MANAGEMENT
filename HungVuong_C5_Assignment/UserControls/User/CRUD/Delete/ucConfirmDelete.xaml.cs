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
    /// Interaction logic for ucConfirmDelete.xaml
    /// </summary>
    public partial class ucConfirmDelete : UserControl
    {
        private WindowDefault _ParentWindow;
        private ReaderViewModel readerVM = new ReaderViewModel();
        public Child Child1 { get; set; }
        public Child Child2 { get; set; }
        public Reader ChildReader1 { get; set; }
        public Reader ChildReader2 { get; set; }

        public string FullNameChild1 { get; set; }
        public string FullNameChild2 { get; set; }

        public ucConfirmDelete(WindowDefault parentWindow, Child child1, Child child2)
        {
            InitializeComponent();

            this._ParentWindow = parentWindow;
            this.Child1 = child1;
            FullNameChild1 = Child1.Reader.LName + " " + Child1.Reader.FName;
            this.Child2 = child2;
            
            this.ChildReader1 = readerVM.readerRepo.GetById(child1.IdReader);

            if(child2 != null)
            {
                this.ChildReader2 = readerVM.readerRepo.GetById(child2.IdReader);
                FullNameChild2 = Child2.Reader.LName + " " + Child2.Reader.FName;

                grdChild2.Visibility = grdChildReader2.Visibility = Visibility.Visible;
            }

            this.DataContext = this;
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            this._ParentWindow.DialogResult = true;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this._ParentWindow.DialogResult = false;
            this._ParentWindow.Close();
        }
    }
}

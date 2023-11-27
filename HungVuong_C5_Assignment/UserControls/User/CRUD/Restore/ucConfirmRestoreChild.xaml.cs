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
    /// Interaction logic for ucConfirmRestoreChild.xaml
    /// </summary>
    public partial class ucConfirmRestoreChild : UserControl
    {
        private WindowDefault _ParentWindow;
        public Reader Reader { get; set; }
        public Adult Adult { get; set; }
        public string FullName { get; set; }

        public ucConfirmRestoreChild(WindowDefault parentWindow, Reader reader, Adult adult)
        {
            InitializeComponent();

            this.Reader = reader;
            this.Adult = adult;
            this._ParentWindow = parentWindow;

            FullName = reader.LName + " " + reader.FName;
            
            DataContext = this;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this._ParentWindow.DialogResult = false;
            this._ParentWindow.Close();
        }

        private void btnRestore_Click(object sender, RoutedEventArgs e)
        {
            this._ParentWindow.DialogResult = true;
            this._ParentWindow.Close();
        }
    }
}

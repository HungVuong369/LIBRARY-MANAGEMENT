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
    /// Interaction logic for ucChildInformation.xaml
    /// </summary>
    public partial class ucChildInformation : UserControl
    {
        public Reader AdultReader { get; set; }
        public Adult Adult { get; set; }

        public Reader ChildReader { get; set; }
        public Child Child { get; set; }

        public string FullNameChild { get; set; }
        public string FullNameAdult { get; set; }

        public ucChildInformation(Reader adultReader, Adult adult, Reader childReader, Child child)
        {
            InitializeComponent();
            FullNameChild = childReader.LName + " " + childReader.LName;
            FullNameAdult = adultReader.LName + " " + adultReader.LName;
            
            this.AdultReader = adultReader;
            this.Adult = adult;
            this.ChildReader = childReader;
            this.Child = child;

            
            DataContext = this;
        }
    }
}

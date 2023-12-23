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
using System.Windows.Shapes;

namespace HungVuong_C5_Assignment
{
    /// <summary>
    /// Interaction logic for WindowDefault.xaml
    /// </summary>
    public partial class WindowDefault : Window
    {
        public WindowDefault()
        {
            InitializeComponent();
        }

        public WindowDefault(int width, int height)
        {
            InitializeComponent();
            this.SizeToContent = SizeToContent.Manual;
            this.Width = width;
            this.Height = height;
        }
    }
}

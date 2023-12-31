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
    /// Interaction logic for ucStatiRectangle.xaml
    /// </summary>
    public partial class ucStatiRectangle : UserControl
    {
        public ucStatiRectangle(string source, string quantity, string content, string colorQuantity, string colorFill, int width = 50, int height = 50)
        {
            InitializeComponent();
            path.Tag = source;
            tbQuantity.Text = quantity;
            gbContainer.Header = content;
            path.Width = width;
            path.Height = height;

            BrushConverter brushConverter = new BrushConverter();
            tbQuantity.Foreground = (Brush)brushConverter.ConvertFromString(colorQuantity);

            path.Fill = (Brush)brushConverter.ConvertFromString(colorFill);
        }
    }
}

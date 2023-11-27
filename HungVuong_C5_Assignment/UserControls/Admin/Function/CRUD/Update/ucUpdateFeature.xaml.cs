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
    /// Interaction logic for ucUpdateFeature.xaml
    /// </summary>
    public partial class ucUpdateFeature : UserControl
    {
        public ucUpdateFeature()
        {
            InitializeComponent();
            ucFunction.SetVisibilityButton(Visibility.Collapsed, Visibility.Visible, Visibility.Collapsed);
            ucFunction.updateEvent += UcFunction_updateEvent;
        }

        private void UcFunction_updateEvent(object sender, RoutedEventArgs e)
        {
            
        }
    }
}

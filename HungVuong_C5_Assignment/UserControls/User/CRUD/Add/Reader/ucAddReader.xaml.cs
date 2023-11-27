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
    /// Interaction logic for ucAddReader.xaml
    /// </summary>
    public partial class ucAddReader : UserControl
    {
        private WindowDefault _Parent;

        public ucAddReader(WindowDefault window)
        {
            InitializeComponent();
            _Parent = window;
            ucAdult.AddedEvent += UcAdult_AddedEvent;
            ucAdult.CancelEvent += UcAdult_CancelEvent;

            ucChild.AddedEvent += UcChild_AddedEvent;
            ucChild.CancelEvent += UcChild_CancelEvent;
            lbTabMenu.SelectedIndex = 0;
        }

        private void UcChild_CancelEvent(object sender, RoutedEventArgs e)
        {
            _Parent.DialogResult = false;
            _Parent.Close();
        }

        private void UcChild_AddedEvent(object sender, RoutedEventArgs e)
        {
            _Parent.DialogResult = true;
            _Parent.Close();
        }

        private void UcAdult_CancelEvent(object sender, RoutedEventArgs e)
        {
            _Parent.DialogResult = false;
            _Parent.Close();
        }

        private void UcAdult_AddedEvent(object sender, RoutedEventArgs e)
        {
            _Parent.DialogResult = true;
            _Parent.Close();
        }

        private void SetVisibility(Visibility adult, Visibility child)
        {
            ucAdult.Visibility = adult;
            ucChild.Visibility = child;
        }

        private void lbTabMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string tab = (lbTabMenu.SelectedValue as ListBoxItem).Content.ToString();

            switch (tab)
            {
                case "Add Adult":
                    SetVisibility(Visibility.Visible, Visibility.Collapsed);
                    break;
                case "Add Child":
                    SetVisibility(Visibility.Collapsed, Visibility.Visible);
                    break;
            }
        }
    }
}

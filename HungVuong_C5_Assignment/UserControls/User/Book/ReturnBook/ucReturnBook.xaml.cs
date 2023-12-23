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
    /// Interaction logic for ucReturnBook.xaml
    /// </summary>
    public partial class ucReturnBook : UserControl
    {
        public LoanHistoryViewModel LoanHistoryVM { get; private set; } = new LoanHistoryViewModel();
        public LoanHistoryDataGrid LoanHistoryDataGrid { get; } = LoanHistoryDataGrid.Instance;

        public ucReturnBook()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        private HitTestFilterBehavior FilterCallback(DependencyObject o)
        {
            var c = o as Control;
            if ((c != null) && !(o is MainWindow))
            {
                if (c.Focusable)
                {
                    if (c is ComboBox)
                    {
                        (c as ComboBox).IsDropDownOpen = true;
                    }
                    else
                    {
                        var mouseDevice = Mouse.PrimaryDevice;
                        var mouseButtonEventArgs = new MouseButtonEventArgs(mouseDevice, 0, MouseButton.Left)
                        {
                            RoutedEvent = Mouse.MouseDownEvent,
                            Source = c
                        };
                        c.RaiseEvent(mouseButtonEventArgs);
                    }

                    return HitTestFilterBehavior.Stop;
                }
            }
            return HitTestFilterBehavior.Continue;
        }

        private HitTestResultBehavior ResultCallback(HitTestResult r)
        {
            return HitTestResultBehavior.Continue;
        }

        private void cbReaderID_DropDownClosed(object sender, EventArgs e)
        {
            Point m = Mouse.GetPosition(this);
            VisualTreeHelper.HitTest(this, this.FilterCallback, this.ResultCallback, new PointHitTestParameters(m));
        }

        private void txtPrice_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (e.Text != string.Empty && !char.IsDigit(e.Text[0]))
                e.Handled = true;
        }

        private void txtPrice_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (LoanHistoryVM.SelectedPenaltyReason != null && LoanHistoryVM.SelectedPenaltyReason.Id == "PR3")
            {
                TextBox textBox = sender as TextBox;
                if (textBox.Text == string.Empty)
                {
                    textBox.Text = "0,000";
                    return;
                }

                if (textBox.Text.Length <= 3)
                {
                    textBox.Text = textBox.Text + ",000";
                }
                else
                {
                    if(textBox.Text == "0.000" || textBox.Text == "0,000")
                    {
                        return;
                    }
                    if(textBox.Text.Substring(1) == ",00" || textBox.Text.Substring(1) == ".00")
                    {
                        textBox.Text = "0,000";
                        return;
                    }
                    
                    textBox.Text = double.Parse(textBox.Text.Replace(",", "")).ToString("N0");
                }
                textBox.SelectionStart = textBox.Text.Length - 4;
            }
        }
    }
}

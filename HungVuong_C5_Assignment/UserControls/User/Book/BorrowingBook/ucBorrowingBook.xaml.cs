using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
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
    /// Interaction logic for ucBorrowingBook.xaml
    /// </summary>
    public partial class ucBorrowingBook : UserControl
    {
        public ucBorrowingBook()
        {
            InitializeComponent();

            LoanSlipViewModel loanSlipVM = new LoanSlipViewModel();
            loanSlipVM.borrowingBook = this;
            this.DataContext = loanSlipVM;
            grdSearch.DataContext = new SearchBookViewModel();
            btnCreate.DataContext = loanSlipVM;
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
    }
}

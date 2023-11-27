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
    /// Interaction logic for ucLoanDetail.xaml
    /// </summary>
    public partial class ucLoanDetail : UserControl
    {
        public ucLoanDetail(LoanSlip loanSlip)
        {
            InitializeComponent();

            dgLoanDetails.ItemsSource = loanSlip.LoanDetails;

            tbReaderName.Text = loanSlip.Reader.LName + " " + loanSlip.Reader.FName;
            tbDeposit.Text = loanSlip.Deposit.ToString().Replace(".", ",") + " VND";
            tbLoanDate.Text = loanSlip.LoanDate.ToString("dd/MM/yyyy");
            tbLoanPaid.Text = loanSlip.LoanPaid.ToString().Replace(".", ",") + " VND";
            tbQuantityBook.Text = loanSlip.LoanDetails.Count.ToString();
            tbReturnDate.Text = loanSlip.ExpDate.ToString("dd/MM/yyyy");
        }
    }
}

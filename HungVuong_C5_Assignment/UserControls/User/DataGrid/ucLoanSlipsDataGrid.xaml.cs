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
    /// Interaction logic for ucLoanSlipsDataGrid.xaml
    /// </summary>
    public partial class ucLoanSlipsDataGrid : UserControl
    {
        private LoanSlipViewModel _LoanSlipVM = new LoanSlipViewModel();

        public ucLoanSlipsDataGrid()
        {
            InitializeComponent();
            ReloadDataGrid();
        }

        public void ReloadDataGrid()
        {
            dgLoanSlips.ItemsSource = null;

            List<LoanSlipDto> loanSlipsDto = new List<LoanSlipDto>();

            foreach (var loanSlip in _LoanSlipVM.loanSlipRepo.Items)
            {
                var newLoanSlipDto = new LoanSlipDto()
                {
                    Deposit = loanSlip.Deposit,
                    FullName = loanSlip.Reader.LName + " " + loanSlip.Reader.FName,
                    Id = loanSlip.Id,
                    LoanDate = loanSlip.LoanDate,
                    LoanPaid = loanSlip.LoanPaid,
                    Quantity = loanSlip.Quantity,
                    ReturnDate = loanSlip.ExpDate
                };
                loanSlipsDto.Add(newLoanSlipDto);
            }
            dgLoanSlips.ItemsSource = loanSlipsDto;
        }

        private void btnDetail_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            LoanSlipDto loanSlipDto = button.Tag as LoanSlipDto;
            LoanSlip loanSlip = _LoanSlipVM.loanSlipRepo.GetByID(loanSlipDto.Id);

            WindowDefault window = new WindowDefault();
            window.Content = new ucLoanDetail(loanSlip);
            window.ShowDialog();
        }
    }
}

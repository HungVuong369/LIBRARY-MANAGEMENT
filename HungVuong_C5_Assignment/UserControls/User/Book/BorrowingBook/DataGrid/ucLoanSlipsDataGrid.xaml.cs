using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        private ObservableCollection<LoanSlipDto> _StorageLstLoanSlip;
        private ObservableCollection<LoanSlipDto> _LstLoanSlip;

        public ucLoanSlipsDataGrid()
        {
            InitializeComponent();
        }

        private List<LoanSlipDto> GetLoanSlipDto()
        {
            List<LoanSlipDto> loanSlipsDto = new List<LoanSlipDto>();

            foreach (var loanSlip in _LoanSlipVM.loanSlipRepo.Items)
            {
                var newLoanSlipDto = new LoanSlipDto()
                {
                    Deposit = loanSlip.Deposit,
                    FullName = loanSlip.Reader.LName + " " + loanSlip.Reader.FName,
                    ReaderID = loanSlip.Reader.Id,
                    Id = loanSlip.Id,
                    LoanDate = loanSlip.LoanDate,
                    LoanPaid = loanSlip.LoanPaid,
                    Quantity = loanSlip.Quantity,
                    ReturnDate = loanSlip.ExpDate,
                    CreatedBy = loanSlip.User.Username
                };
                loanSlipsDto.Add(newLoanSlipDto);
            }
            return loanSlipsDto;
        }

        public void ReloadStorage()
        {
            this._StorageLstLoanSlip = new ObservableCollection<LoanSlipDto>(this.GetLoanSlipDto());

            this._LstLoanSlip = new ObservableCollection<LoanSlipDto>(this._StorageLstLoanSlip);

            pagination.SetMaxPage<LoanSlipDto>(_LstLoanSlip.Count);

            dgLoanSlips.ItemsSource = _LstLoanSlip.Skip((pagination.CurrentPage - 1) * pagination.ItemPerPage).Take(pagination.ItemPerPage);
        }

        public void ReloadStorageByReaderID(string readerID)
        {
            this._StorageLstLoanSlip = new ObservableCollection<LoanSlipDto>(this.GetLoanSlipDto().Where(i => i.ReaderID == readerID));

            this._LstLoanSlip = new ObservableCollection<LoanSlipDto>(this._StorageLstLoanSlip);

            pagination.SetMaxPage<LoanSlipDto>(_LstLoanSlip.Count);

            dgLoanSlips.ItemsSource = _LstLoanSlip.Skip((pagination.CurrentPage - 1) * pagination.ItemPerPage).Take(pagination.ItemPerPage);
        }

        public void ReloadDataGrid()
        {
            dgLoanSlips.ItemsSource = null;
            dgLoanSlips.ItemsSource = _LstLoanSlip.Skip((pagination.CurrentPage - 1) * pagination.ItemPerPage).Take(pagination.ItemPerPage);
            pagination.ReloadShowing<LoanSlipDto>(_LstLoanSlip.Count);
        }

        public void Search(string search)
        {
            this._LstLoanSlip.Clear();

            foreach (var item in this._StorageLstLoanSlip)
            {
                if (item.FullName.ToLower().Contains(search.ToLower()))
                    this._LstLoanSlip.Add(item);
                else if(item.Id.ToLower().Contains(search.ToLower()))
                    this._LstLoanSlip.Add(item);
                else if(item.Quantity.ToString().Contains(search))
                    this._LstLoanSlip.Add(item);
                else if(item.LoanDate.ToString("dd/MM/yyyy").Contains(search))
                    this._LstLoanSlip.Add(item);
                else if (item.ReturnDate.ToString("dd/MM/yyyy").Contains(search))
                    this._LstLoanSlip.Add(item);
            }

            pagination.SetMaxPage<LoanSlipDto>(_LstLoanSlip.Count);
            pagination.CurrentPage = 1;
            pagination.LoadPage();
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

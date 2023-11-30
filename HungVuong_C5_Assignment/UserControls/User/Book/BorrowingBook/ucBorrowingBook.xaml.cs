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
        private WindowDefault _Parent;
        LoanManagementRepository loanManagementRepo = new LoanManagementRepository();

        private ParameterViewModel _ParameterVM = new ParameterViewModel();
        private ReaderViewModel _ReaderVM = new ReaderViewModel();
        private BookISBNViewModel _BookISBNVM = new BookISBNViewModel();

        private LoanSlipViewModel _LoanSlipVM = new LoanSlipViewModel();
        private LoanDetailViewModel _LoanDetailVM = new LoanDetailViewModel();
        private EnrolViewModel _EnrolVM = new EnrolViewModel();
        private BookViewModel _BookVM = new BookViewModel();

        private bool flag = false;

        public ucBorrowingBook(WindowDefault window)
        {
            InitializeComponent();

            _Parent = window;

            _Parent.Closing += _Parent_Closing;

            loanManagementRepo.LoanSlip.Id = txtBorrowingSlipID.Text = LoanSlipRepository.GetNewID();

            txtBorrowingDate.Text = DateTime.Now.ToString("dd/MM/yyyy");

            loanManagementRepo.LoanSlip.LoanDate = DateTime.Now;

            int day = int.Parse(_ParameterVM.GetValueByID("QD9"));

            txtReturnDate.Text = DateTime.Now.AddDays(day).ToString("dd/MM/yyyy");

            loanManagementRepo.LoanSlip.ExpDate = DateTime.Now.AddDays(day);
        }

        private void ResetDatabase()
        {
            foreach (var loanDetail in DatabaseFirst.Instance.db.LoanDetails.Local.ToList())
            {
                var item = DatabaseFirst.Instance.db.Entry(loanDetail);

                if (item.State == EntityState.Added)
                    item.State = EntityState.Detached;
            }

            foreach (var loanSlip in DatabaseFirst.Instance.db.LoanSlips.Local.ToList())
            {
                var item = DatabaseFirst.Instance.db.Entry(loanSlip);

                if (item.State == EntityState.Added)
                    item.State = EntityState.Detached;
            }

            foreach (var book in DatabaseFirst.Instance.db.Books.Local.ToList())
            {
                var item = DatabaseFirst.Instance.db.Entry(book);

                if (item.State == EntityState.Modified)
                    item.State = EntityState.Unchanged;
            }

            foreach (var bookISBN in DatabaseFirst.Instance.db.BookISBNs.Local.ToList())
            {
                var item = DatabaseFirst.Instance.db.Entry(bookISBN);

                if (item.State == EntityState.Modified)
                {
                    item.State = EntityState.Unchanged;
                }
            }
        }

        private void _Parent_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if(_Parent.DialogResult == null || _Parent.DialogResult == false)
            {
                foreach (var enroll in DatabaseFirst.Instance.db.Enrolls.Local.ToList())
                {
                    var item = DatabaseFirst.Instance.db.Entry(enroll);

                    if (item.State == EntityState.Added)
                        item.State = EntityState.Detached;
                }
                foreach(var enroll in DatabaseFirst.Instance.db.Enrolls.ToList())
                {
                    var item = DatabaseFirst.Instance.db.Entry(enroll);
                    if (item.State == EntityState.Modified)
                        item.State = EntityState.Unchanged;
                }
                ResetDatabase();

                DatabaseFirst.Instance.SaveChanged();
            }

            else if(_Parent.DialogResult == true)
            {
                foreach (var enroll in DatabaseFirst.Instance.db.Enrolls.ToList())
                {
                    var item = DatabaseFirst.Instance.db.Entry(enroll);
                    if (item.State == EntityState.Modified)
                        item.State = EntityState.Deleted;
                }

                if (IsFullEnroll())
                {
                    ResetDatabase();
                    DatabaseFirst.Instance.SaveChanged();
                    MessageBox.Show("Add Enrolls Slip Successfully!", "Notify", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    DatabaseFirst.Instance.SaveChanged();
                    MessageBox.Show("Add Loan Slip Successfully!", "Notify", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }

            _BookISBNVM.bookISBNRepo.Load();
            _BookVM.bookRepo.Load();
            _LoanDetailVM.loanDetailRepo.Load();
            _LoanSlipVM.loanSlipRepo.Load();
            _EnrolVM.enrolRepo.Load();
        }

        private void btnAddDetailBorrowing_Click(object sender, RoutedEventArgs e)
        {
            int isCheck = loanManagementRepo.AddLoanDetail(txtBookISBN.Text, txtReaderID.Text, ref flag);

            if (isCheck == 0)
                return;

            var reader = _ReaderVM.readerRepo.GetById(txtReaderID.Text);
            var bookISBN = _BookISBNVM.bookISBNRepo.GetByISBN(txtBookISBN.Text);

            if(reader.ReaderType)
                txtExpireReader.Text = reader.Adult.ExpireDate.ToString("dd/MM/yyyy");
            else
                txtExpireReader.Text = reader.Child.Adult.ExpireDate.ToString("dd/MM/yyyy");
            txtReaderID.IsEnabled = false;

            string status = "Loan";

            if (isCheck == 1)
                status = "Enroll";
            else if(isCheck == 3)
                status = "Loan book have been enrolled";

            var newBorrowingDto = new BorrowingSlipDto()
            {
                Name = reader.LName + " " + reader.FName,
                ReaderType = reader.ReaderType,
                BoF = reader.boF,
                BookName = bookISBN.BookTitle.Name,
                Author = bookISBN.Author.Name,
                Category = bookISBN.BookTitle.Category.Name,
                Language = bookISBN.Language,
                EnrollDate = DateTime.ParseExact(txtBorrowingDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture),
                Status = status
            };

            ucBorrowing.dgBorrowingDetail.Items.Add(newBorrowingDto);
            txtLoanPaid.Text = loanManagementRepo.LoanSlip.LoanPaid.ToString().Replace('.', ',') + " VND";
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            _Parent.DialogResult = false;
            _Parent.Close();
        }

        private bool IsFullEnroll()
        {
            foreach(BorrowingSlipDto item in ucBorrowing.dgBorrowingDetail.Items)
            {
                if (item.Status == "Loan")
                    return false;
                else if (item.Status == "Loan book have been enrolled")
                    return false;
            }
            return true;
        }

        private void btnConfirmBorrowing_Click(object sender, RoutedEventArgs e)
        {
            if(ucBorrowing.dgBorrowingDetail.Items.Count == 0)
            {
                MessageBox.Show("Please add details to the loan for confirmation", "Notify", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if(txtDeposit.Text == string.Empty || loanManagementRepo.LoanSlip.LoanPaid >= decimal.Parse(txtDeposit.Text.Replace(",", ".")))
            {
                MessageBox.Show("Invalid deposit!", "Notify", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            loanManagementRepo.LoanSlip.Deposit = decimal.Parse(txtDeposit.Text.Replace(",", "."));

            _Parent.DialogResult = true;
            _Parent.Close();
        }

        private void txtBookISBN_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtBookISBN.Text == string.Empty)
            {
                cbBookISBN.IsDropDownOpen = false;
                return;
            }

            var bookISBNs = _BookISBNVM.bookISBNRepo.Items.Where(i => i.ISBN.ToLower().Contains(txtBookISBN.Text.ToLower())).ToList();

            if (bookISBNs.Count == 0)
            {
                cbBookISBN.IsDropDownOpen = false;
                return;
            }

            cbBookISBN.ItemsSource = null;

            cbBookISBN.ItemsSource = bookISBNs;

            cbBookISBN.IsDropDownOpen = true;
        }

        private void txtReaderID_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtReaderID.Text == string.Empty)
            {
                cbReaderID.IsDropDownOpen = false;
                return;
            }

            var readers = _ReaderVM.readerRepo.Items.Where(i => i.Status == true && i.Id.ToLower().Contains(txtReaderID.Text.ToLower())).ToList();
            if (readers.Count == 0)
            {
                cbReaderID.IsDropDownOpen = false;
                return;
            }
            cbReaderID.ItemsSource = null;

            cbReaderID.ItemsSource = readers;

            cbReaderID.IsDropDownOpen = true;
        }

        private void cbBookISBN_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbBookISBN.SelectedIndex == -1)
                return;
            txtBookISBN.Text = cbBookISBN.SelectedValue.ToString();
            cbBookISBN.SelectedIndex = -1;
        }

        private void cbReaderID_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbReaderID.SelectedIndex == -1)
                return;
            txtReaderID.Text = cbReaderID.SelectedValue.ToString();
            cbReaderID.SelectedIndex = -1;
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

        private void cbBookISBN_DropDownClosed(object sender, EventArgs e)
        {
            Point m = Mouse.GetPosition(this);
            VisualTreeHelper.HitTest(this, this.FilterCallback, this.ResultCallback, new PointHitTestParameters(m));
        }

        private void txtDeposit_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtDeposit.Text == string.Empty)
                return;
            txtDeposit.Text = double.Parse(txtDeposit.Text.Replace(",", "")).ToString("N0");
            txtDeposit.SelectionStart = txtDeposit.Text.Length;
        }

        private void txtDeposit_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (e.Text != string.Empty && !char.IsDigit(e.Text[0]))
                e.Handled = true;
        }
    }
}

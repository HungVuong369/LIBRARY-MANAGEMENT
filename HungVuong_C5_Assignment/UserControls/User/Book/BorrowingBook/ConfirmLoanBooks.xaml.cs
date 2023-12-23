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
    /// Interaction logic for ConfirmLoanBooks.xaml
    /// </summary>
    public partial class ConfirmLoanBooks : UserControl
    {
        private WindowDefault _Parent;
        public LoanSlip LoanSlip { get; private set; }
        public Reader Reader { get; private set; }
        public string FullName { get; set; }
        public string ReaderType { get; set; }

        public ConfirmLoanBooks(WindowDefault window, LoanSlip loanSlip, List<Book> lstLoanBook)
        {
            InitializeComponent();
            LoanSlip = loanSlip;
            Reader = DatabaseFirst.Instance.db.Readers.FirstOrDefault(i => i.Id == loanSlip.IdReader);
            FullName = Reader.LName + " " + Reader.FName;
            if(Reader.ReaderType)
                ReaderType = "Người lớn";
            else
                ReaderType = "Trẻ em";
            this.DataContext = this;
            dgLoanDetails.ItemsSource = lstLoanBook;
            _Parent = window;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            _Parent.DialogResult = false;
            _Parent.Close();
        }

        private void btnConfirm_Click(object sender, RoutedEventArgs e)
        {
            _Parent.DialogResult = true;
            _Parent.Close();
        }
    }
}

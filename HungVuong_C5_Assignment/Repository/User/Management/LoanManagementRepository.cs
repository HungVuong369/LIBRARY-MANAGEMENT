using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HungVuong_C5_Assignment
{
    public class LoanManagementRepository
    {
        private LoanSlipViewModel _LoanSlipVM = new LoanSlipViewModel();
        private LoanDetailViewModel _LoanDetailVM = new LoanDetailViewModel();

        public LoanManagementRepository()
        {
        }

        //private bool IsEmptyLoanDetail(string bookISBN, string readerID)
        //{
        //    if (bookISBN == string.Empty || readerID == string.Empty)
        //    {
        //        MessageBox.Show("Please do not leave data blank!", "Notify", MessageBoxButton.OK, MessageBoxImage.Warning);
        //        return true;
        //    }
        //    return false;
        //}

        //private bool IsNullLoanDetail(Reader reader, BookISBN bookISBN)
        //{
        //    if (reader == null || bookISBN == null)
        //    {
        //        MessageBox.Show("Reader or ISBN not found!", "Notify", MessageBoxButton.OK, MessageBoxImage.Warning);
        //        return true;
        //    }
        //    return false;
        //}

        //private void IsCheckLoanSlip(IEnumerable<LoanSlip> loanSlips, string isbn, ref int count, ref bool isDuplicateISBN)
        //{
        //    foreach (var loanSlip in loanSlips)
        //    {
        //        count += loanSlip.LoanDetails.Count;

        //        foreach (var loanDetail in loanSlip.LoanDetails)
        //        {
        //            if (loanDetail.Book.BookISBN.ISBN == isbn)
        //            {
        //                isDuplicateISBN = true;
        //                break;
        //            }
        //        }
        //    }
        //}

        //private int IsCheckLoanSlips(Reader reader, BookISBN bookISBN, ref int count, ref bool isDuplicateISBN)
        //{
        //    IEnumerable<LoanSlip> loanSlipsBase = DatabaseFirst.Instance.db.LoanSlips.Local.Where(i => i.IdReader == reader.Id);

        //    IsCheckLoanSlip(loanSlipsBase, bookISBN.ISBN, ref count, ref isDuplicateISBN);

        //    if(reader.ReaderType)
        //    {
        //        foreach(var child in reader.Adult.Children)
        //        {
        //            IEnumerable<LoanSlip> loanSlipsChild = DatabaseFirst.Instance.db.LoanSlips.Local.Where(i => i.IdReader == child.IdReader);

        //            IsCheckLoanSlip(loanSlipsChild, bookISBN.ISBN, ref count, ref isDuplicateISBN);
        //        }

        //        if (count > int.Parse(_ParameterVM.GetValueByID("QD2").Split(':')[0]))
        //            return -1;
        //    }
        //    else
        //    {
        //        if (count > int.Parse(_ParameterVM.GetValueByID("QD3")))
        //            return -2;

        //        IEnumerable<LoanSlip> loanSlipsAdult = DatabaseFirst.Instance.db.LoanSlips.Local.Where(i => i.IdReader == reader.Child.Adult.IdReader);

        //        foreach (var child in reader.Child.Adult.Children.Where(i => i.IdReader != reader.Id))
        //        {
        //            IEnumerable<LoanSlip> loanSlipsChild = DatabaseFirst.Instance.db.LoanSlips.Local.Where(i => i.IdReader == child.IdReader);
        //            IsCheckLoanSlip(loanSlipsChild, bookISBN.ISBN, ref count, ref isDuplicateISBN);
        //        }

        //        IsCheckLoanSlip(loanSlipsAdult, bookISBN.ISBN, ref count, ref isDuplicateISBN);

        //        if (count > int.Parse(_ParameterVM.GetValueByID("QD2").Split(':')[0]))
        //            return -1;
        //    }

        //    if (isDuplicateISBN)
        //        return 0;

        //    return 1;
        //}

        //private int IsCheckEnroll(IEnumerable<Enroll> enrolls, string isbn, ref bool isDuplicateISBN)
        //{
        //    foreach (var enroll in enrolls)
        //    {
        //        if (enroll.BookISBN.ISBN == isbn)
        //        {
        //            if(enroll.IdBook == null)
        //            {
        //                isDuplicateISBN = true;
        //                break;
        //            }
        //        }
        //    }
        //    return 1;
        //}

        //private int IsCheckEnrolls(Reader reader, BookISBN bookISBN, ref bool isDuplicateISBN)
        //{
        //    IEnumerable<Enroll> enrollsBase = DatabaseFirst.Instance.db.Enrolls.Local.Where(i => i.IdReader == reader.Id);

        //    IsCheckEnroll(enrollsBase, bookISBN.ISBN, ref isDuplicateISBN);

        //    if(reader.ReaderType)
        //    {
        //        foreach (var child in reader.Adult.Children)
        //        {
        //            IEnumerable<Enroll> enrollsChild = DatabaseFirst.Instance.db.Enrolls.Local.Where(i => i.IdReader == child.IdReader);

        //            IsCheckEnroll(enrollsChild, bookISBN.ISBN, ref isDuplicateISBN);
        //        }
        //    }
        //    else
        //    {
        //        IEnumerable<Enroll> enrollsAdult = DatabaseFirst.Instance.db.Enrolls.Local.Where(i => i.IdReader == reader.Child.Adult.IdReader);

        //        foreach (var child in reader.Child.Adult.Children.Where(i => i.IdReader != reader.Id))
        //        {
        //            IEnumerable<Enroll> enrollsChild = DatabaseFirst.Instance.db.Enrolls.Local.Where(i => i.IdReader == child.IdReader);
        //            IsCheckEnroll(enrollsChild, bookISBN.ISBN, ref isDuplicateISBN);
        //        }

        //        IsCheckEnroll(enrollsAdult, bookISBN.ISBN, ref isDuplicateISBN);
        //    }

        //    if (isDuplicateISBN)
        //        return 0;

        //    return 1;
        //}

        //private int IsCheckLoanSlipsAndEnrolls(Reader reader, BookISBN bookISBN)
        //{
        //    int count = 1;
        //    bool isDuplicateISBN = false;
        //    int isCheck = IsCheckLoanSlips(reader, bookISBN, ref count, ref isDuplicateISBN);

        //    if (isCheck != 1)
        //        return isCheck;

        //    isCheck = IsCheckEnrolls(reader, bookISBN, ref isDuplicateISBN);

        //    if (isCheck != 1)
        //        return isCheck;

        //    return 1;
        //}

        //private int Message(int isCheck, BookISBN bookISBN)
        //{
        //    if (isCheck == 0)
        //    {
        //        MessageBox.Show($"{"'" + bookISBN.ISBN + "'"} ISBN borrowers are limited to one book", "Notify", MessageBoxButton.OK, MessageBoxImage.Warning);
        //        return 0;
        //    }
        //    if (isCheck == -1)
        //    {
        //        MessageBox.Show($"Adult readers are limited to a {_ParameterVM.GetValueByID("QD2").Split(':')[0]}-book borrowing maximum", "Notify", MessageBoxButton.OK, MessageBoxImage.Warning);
        //        return 0;
        //    }
        //    if (isCheck == -2)
        //    {
        //        MessageBox.Show($"Child readers are limited to a {_ParameterVM.GetValueByID("QD3")}-book borrowing maximum", "Notify", MessageBoxButton.OK, MessageBoxImage.Warning);
        //        return 0;
        //    }
        //    return 1;
        //}

        //private int AddDetail(Reader reader, BookISBN bookISBN)
        //{
        //    // Enroll
        //    if (!bookISBN.Status)
        //    {
        //        var newEnrol = new Enroll()
        //        {
        //            Id = EnrolRepository.GetNewID(),
        //            ISBN = bookISBN.ISBN,
        //            IdReader = reader.Id,
        //            EnrolDate = DateTime.Now,
        //            Note = "",
        //            IdBook = null,
        //            ExpDate = null
        //        };

        //        _EnrollVM.enrolRepo.Add(newEnrol);
        //        return 1;
        //    }
        //    // Loan
        //    else
        //    {
        //        Book book = null;

        //        var enrolls = _EnrollVM.enrolRepo.Items.Where(i => i.IdBook != null && i.ISBN == bookISBN.ISBN);
        //        Enroll flagEnroll = null;

        //        foreach (var enroll in enrolls)
        //        {
        //            if(enroll.ISBN == bookISBN.ISBN)
        //            {
        //                if(enroll.IdBook != null)
        //                {
        //                    book = bookISBN.Books.FirstOrDefault(i => i.Id == enroll.IdBook);
        //                    flagEnroll = enroll;
        //                    break;
        //                }
        //            }
        //        }
        //        if(flagEnroll == null)
        //            book = bookISBN.Books.FirstOrDefault(i => i.ISBN == bookISBN.ISBN && i.Status == true && !enrolls.Any(e => e.IdBook == i.Id));
        //        else
        //        {
        //            var item = DatabaseFirst.Instance.db.Entry(flagEnroll);
        //            item.State = System.Data.Entity.EntityState.Modified;
        //        }

        //        if (book == null)
        //        {
        //            MessageBox.Show("Book not found!", "Notify", MessageBoxButton.OK, MessageBoxImage.Warning);
        //            return 0;
        //        }
        //        var newLoanDetail = new LoanDetail()
        //        {
        //            Id = LoanDetailRepository.GetNewID(),
        //            IdLoan = LoanSlip.Id,
        //            IdBook = book.Id,
        //            ExpDate = LoanSlip.ExpDate
        //        };
        //        book.Status = false;
        //        var quantityBook = bookISBN.Books.Where(i => i.Status == true).Count();

        //        if (quantityBook == 0)
        //            bookISBN.Status = false;
        //        else
        //            bookISBN.Status = true;

        //        LoanSlip.Quantity += 1;
        //        ///LoanSlip.LoanPaid += book.DonGiaHienTai;
        //        LoanSlip.LoanDetails.Add(newLoanDetail);
        //        _LoanDetailVM.loanDetailRepo.Add(newLoanDetail);

        //        if(flagEnroll != null)
        //            return 3;
        //    }
        //    return 2;
        //}

        //public int AddLoanDetail(string isbn, string readerID, ref bool flag)
        //{
        //    if (IsEmptyLoanDetail(isbn, readerID))
        //        return 0;

        //    var reader = _ReaderVM.readerRepo.GetById(readerID);
        //    var bookISBN = _BookISBNVM.bookISBNRepo.GetByISBN(isbn);

        //    if (IsNullLoanDetail(reader, bookISBN))
        //        return 0;

        //    int isCheck = IsCheckLoanSlipsAndEnrolls(reader, bookISBN);
        //    Message(isCheck, bookISBN);

        //    if(isCheck != 1)
        //        return 0;

        //    if (!flag)
        //    {
        //        flag = true;
        //        LoanSlip.IdReader = reader.Id;
        //        _LoanSlipVM.loanSlipRepo.Add(LoanSlip);
        //    }

        //    return AddDetail(reader, bookISBN);
        //}

        public void Add(LoanSlip loanSlip, List<LoanDetail> lstLoanDetail)
        {
            _LoanSlipVM.loanSlipRepo.Add(loanSlip);
            lstLoanDetail.ForEach(i => _LoanDetailVM.loanDetailRepo.Add(i));

            DatabaseFirst.Instance.SaveChanged();
        }
    }
}

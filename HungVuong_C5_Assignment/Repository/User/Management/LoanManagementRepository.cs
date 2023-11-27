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
        public LoanSlip LoanSlip { get; set; }

        private ReaderViewModel _ReaderVM = new ReaderViewModel();
        private BookISBNViewModel _BookISBNVM = new BookISBNViewModel();
        private ParameterViewModel _ParameterVM = new ParameterViewModel();

        private LoanSlipViewModel _LoanSlipVM = new LoanSlipViewModel();
        private LoanDetailViewModel _LoanDetailVM = new LoanDetailViewModel();
        private EnrolViewModel _EnrollVM = new EnrolViewModel();

        public LoanManagementRepository()
        {
            LoanSlip = new LoanSlip();
        }

        private bool IsEmptyLoanDetail(string bookISBN, string readerID)
        {
            if (bookISBN == string.Empty || readerID == string.Empty)
            {
                MessageBox.Show("Please do not leave data blank!", "Notify", MessageBoxButton.OK, MessageBoxImage.Warning);
                return true;
            }
            return false;
        }

        private bool IsNullLoanDetail(Reader reader, BookISBN bookISBN)
        {
            if (reader == null || bookISBN == null)
            {
                MessageBox.Show("Reader or ISBN not found!", "Notify", MessageBoxButton.OK, MessageBoxImage.Warning);
                return true;
            }
            return false;
        }

        private void IsCheckLoanSlip(IEnumerable<LoanSlip> loanSlips, string language, ref int count, ref bool isDuplicateLanguage)
        {
            foreach (var loanSlip in loanSlips)
            {
                count += loanSlip.LoanDetails.Count;

                foreach (var loanDetail in loanSlip.LoanDetails)
                {
                    if (loanDetail.Book.BookISBN.Language == language)
                    {
                        isDuplicateLanguage = true;
                        break;
                    }
                }
            }
        }

        private int IsCheckLoanSlips(Reader reader, BookISBN bookISBN, ref int count, ref bool isDuplicateLanguage)
        {
            IEnumerable<LoanSlip> loanSlipsBase = DatabaseFirst.Instance.db.LoanSlips.Local.Where(i => i.IdReader == reader.Id);

            IsCheckLoanSlip(loanSlipsBase, bookISBN.Language, ref count, ref isDuplicateLanguage);
            
            if(reader.ReaderType)
            {
                foreach(var child in reader.Adult.Children)
                {
                    IEnumerable<LoanSlip> loanSlipsChild = DatabaseFirst.Instance.db.LoanSlips.Local.Where(i => i.IdReader == child.IdReader);

                    IsCheckLoanSlip(loanSlipsChild, bookISBN.Language, ref count, ref isDuplicateLanguage);
                }

                if (count > int.Parse(_ParameterVM.GetValueByID("QD2").Split(':')[0]))
                    return -1;
            }
            else
            {
                if (count > int.Parse(_ParameterVM.GetValueByID("QD3")))
                    return -2;

                IEnumerable<LoanSlip> loanSlipsAdult = DatabaseFirst.Instance.db.LoanSlips.Local.Where(i => i.IdReader == reader.Child.Adult.IdReader);

                foreach (var child in reader.Child.Adult.Children.Where(i => i.IdReader != reader.Id))
                {
                    IEnumerable<LoanSlip> loanSlipsChild = DatabaseFirst.Instance.db.LoanSlips.Local.Where(i => i.IdReader == child.IdReader);
                    IsCheckLoanSlip(loanSlipsChild, bookISBN.Language, ref count, ref isDuplicateLanguage);
                }

                IsCheckLoanSlip(loanSlipsAdult, bookISBN.Language, ref count, ref isDuplicateLanguage);

                if (count > int.Parse(_ParameterVM.GetValueByID("QD2").Split(':')[0]))
                    return -1;
            }

            if (isDuplicateLanguage)
                return 0;

            return 1;
        }

        private int IsCheckEnroll(IEnumerable<Enroll> enrolls, string language, ref bool isDuplicateLanguage)
        {
            foreach (var enroll in enrolls)
            {
                if (enroll.BookISBN.Language == language)
                {
                    isDuplicateLanguage = true;
                    break;
                }
            }
            return 1;
        }

        private int IsCheckEnrolls(Reader reader, BookISBN bookISBN, ref bool isDuplicateLanguage)
        {
            IEnumerable<Enroll> enrollsBase = DatabaseFirst.Instance.db.Enrolls.Local.Where(i => i.IdReader == reader.Id);

            IsCheckEnroll(enrollsBase, bookISBN.Language, ref isDuplicateLanguage);

            if(reader.ReaderType)
            {
                foreach (var child in reader.Adult.Children)
                {
                    IEnumerable<Enroll> enrollsChild = DatabaseFirst.Instance.db.Enrolls.Local.Where(i => i.IdReader == child.IdReader);

                    IsCheckEnroll(enrollsChild, bookISBN.Language, ref isDuplicateLanguage);
                }
            }
            else
            {
                IEnumerable<Enroll> enrollsAdult = DatabaseFirst.Instance.db.Enrolls.Local.Where(i => i.IdReader == reader.Child.Adult.IdReader);

                foreach (var child in reader.Child.Adult.Children.Where(i => i.IdReader != reader.Id))
                {
                    IEnumerable<Enroll> enrollsChild = DatabaseFirst.Instance.db.Enrolls.Local.Where(i => i.IdReader == child.IdReader);
                    IsCheckEnroll(enrollsChild, bookISBN.Language, ref isDuplicateLanguage);
                }

                IsCheckEnroll(enrollsAdult, bookISBN.Language, ref isDuplicateLanguage);
            }

            if (isDuplicateLanguage)
                return 0;

            return 1;
        }

        private int IsCheckLoanSlipsAndEnrolls(Reader reader, BookISBN bookISBN)
        {
            int count = 1;
            bool isDuplicateLanguage = false;
            int isCheck = IsCheckLoanSlips(reader, bookISBN, ref count, ref isDuplicateLanguage);

            if (isCheck != 1)
                return isCheck;

            isCheck = IsCheckEnrolls(reader, bookISBN, ref isDuplicateLanguage);

            if (isCheck != 1)
                return isCheck;

            return 1;
        }

        private int Message(int isCheck, BookISBN bookISBN)
        {
            if (isCheck == 0)
            {
                MessageBox.Show($"{"'" + bookISBN.Language + "'"} language borrowers are limited to one book", "Notify", MessageBoxButton.OK, MessageBoxImage.Warning);
                return 0;
            }
            if (isCheck == -1)
            {
                MessageBox.Show($"Adult readers are limited to a {_ParameterVM.GetValueByID("QD2").Split(':')[0]}-book borrowing maximum", "Notify", MessageBoxButton.OK, MessageBoxImage.Warning);
                return 0;
            }
            if (isCheck == -2)
            {
                MessageBox.Show($"Child readers are limited to a {_ParameterVM.GetValueByID("QD3")}-book borrowing maximum", "Notify", MessageBoxButton.OK, MessageBoxImage.Warning);
                return 0;
            }
            return 1;
        }

        private int AddDetail(Reader reader, BookISBN bookISBN)
        {
            // Enroll
            if (!bookISBN.Status)
            {
                var newEnrol = new Enroll()
                {
                    Id = EnrolRepository.GetNewID(),
                    ISBN = bookISBN.ISBN,
                    IdReader = reader.Id,
                    EnrolDate = DateTime.Now,
                    Note = "",
                    IdBook = null,
                    ExpiryDate = null
                };

                _EnrollVM.enrolRepo.Add(newEnrol);
                return 1;
            }
            // Loan
            else
            {
                var enrolls = _EnrollVM.enrolRepo.Items.Where(i => i.IdBook != null && i.ISBN == bookISBN.ISBN);

                Book book = bookISBN.Books.FirstOrDefault(i => i.ISBN == bookISBN.ISBN && i.Status == true && !enrolls.Any(e => e.IdBook == i.Id));

                //var enrolls = _EnrollVM.enrolRepo.Items.Where(i => i.IdBook != null && i.ISBN == bookISBN.ISBN);
                
                //Book book = null;
                //foreach (var item in bookISBN.Books.Where(i => i.ISBN == bookISBN.ISBN && i.Status == true))
                //{
                //    bool flag = false;
                //    foreach(var enroll in enrolls)
                //    {
                //        if(item.Id == enroll.IdBook)
                //        {
                //            flag = true;
                //            break;
                //        }
                //    }
                //    if(!flag)
                //    {
                //        book = item;
                //        break;
                //    }
                //}

                if(book == null)
                {
                    MessageBox.Show("Book not found!", "Notify", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return 0;
                }
                var newLoanDetail = new LoanDetail()
                {
                    Id = LoanDetailRepository.GetNewID(),
                    IdLoan = LoanSlip.Id,
                    IdBook = book.Id,
                    ExpDate = LoanSlip.ExpDate
                };
                book.Status = false;
                var quantityBook = bookISBN.Books.Where(i => i.Status == true).Count();

                if (quantityBook == 0)
                    bookISBN.Status = false;
                else
                    bookISBN.Status = true;

                LoanSlip.Quantity += 1;
                LoanSlip.LoanPaid += book.DonGiaHienTai;
                LoanSlip.LoanDetails.Add(newLoanDetail);
                _LoanDetailVM.loanDetailRepo.Add(newLoanDetail);
            }
            return 2;
        }

        public int AddLoanDetail(string isbn, string readerID, ref bool flag)
        {
            if (IsEmptyLoanDetail(isbn, readerID))
                return 0;

            var reader = _ReaderVM.readerRepo.GetById(readerID);
            var bookISBN = _BookISBNVM.bookISBNRepo.GetByISBN(isbn);

            if (IsNullLoanDetail(reader, bookISBN))
                return 0;

            int isCheck = IsCheckLoanSlipsAndEnrolls(reader, bookISBN);
            Message(isCheck, bookISBN);

            if(isCheck != 1)
                return 0;

            if (!flag)
            {
                flag = true;
                LoanSlip.IdReader = reader.Id;
                _LoanSlipVM.loanSlipRepo.Add(LoanSlip);
            }

            return AddDetail(reader, bookISBN);
        }
    }
}

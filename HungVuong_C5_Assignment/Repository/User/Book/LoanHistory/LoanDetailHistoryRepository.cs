using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HungVuong_C5_Assignment
{
    public class LoanDetailHistoryRepository : RepositoryBase<LoanDetailHistory>
    {
        public LoanDetailHistoryRepository()
        {
            Items = new List<LoanDetailHistory>();
        }

        public List<LoanDetailHistory> Load()
        {
            Items.Clear();

            Items.AddRange(DatabaseFirst.Instance.db.LoanDetailHistories);

            return Items;
        }

        public static string GetNewID()
        {
            string id = "LDTH";

            var number = DatabaseFirst.Instance.db.Readers.Select(i => i.Id.Substring(4)).AsEnumerable().Select(num => int.Parse(num)).DefaultIfEmpty().Max() + 1;

            if (number <= 9)
                id += "0" + number;
            else
                id += number;

            return id;
        }

        public static string GetNewID(int count)
        {
            string id = "LDTH";

            var number = DatabaseFirst.Instance.db.LoanDetailHistories.Select(i => i.Id.Substring(4)).AsEnumerable().Select(num => int.Parse(num)).DefaultIfEmpty().Max() + count;

            if (number <= 9)
                id += "0" + number;
            else
                id += number;

            return id;
        }

        public LoanDetailHistory GetByID(string id) => Items.Find(e => e.Id.CompareTo(id) == 0);

        public void Add(LoanDetailHistory loanDetailHistory)
        {
            Items.Add(loanDetailHistory);
            
            DatabaseFirst.Instance.db.LoanDetailHistories.Add(loanDetailHistory);

            var book = DatabaseFirst.Instance.db.Books.FirstOrDefault(i => i.Id == loanDetailHistory.IdBook);
            book.Status = true;

            var bookISBN = DatabaseFirst.Instance.db.BookISBNs.Local.FirstOrDefault(i => i.ISBN == book.ISBN);

            if (bookISBN.Status == false)
                bookISBN.Status = true;

            if(loanDetailHistory.Note == "PR2")
            {
                book.Status = false;
                book.IdBookStatus = "BS2";

                // Không một cuốn sách nào có status là true
                if(bookISBN.Books.FirstOrDefault(i => i.Status) == null)
                {
                    bookISBN.Status = false;
                }
            }
            else if(loanDetailHistory.Note == "PR3")
            {
                book.IdBookStatus = "BS3";
            }
        }
    }
}

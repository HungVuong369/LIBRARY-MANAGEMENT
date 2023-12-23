using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HungVuong_C5_Assignment
{
    public class BookISBNViewModel
    {
        public string NewID { get; set; } = BookISBNRepository.GetNewISBN();
        public string SelectedLanguage { get; set; }
        public List<string> Languages { get; set; } = new List<string>();

        public Author SelectedAuthor { get; set; }
        public BookTitleInformation SelectedBookTitleInformation { get; set; }

        private static readonly UnitOfWork unitOfWork = new UnitOfWork();
        public BookISBNRepository bookISBNRepo { get; set; }

        public RelayCommand<object> AddCommand { get; private set; }
        public RelayCommand<object> CancelCommand { get; private set; }

        public WindowDefault Parent;

        public BookISBNViewModel()
        {
            Languages.AddRange(DataAccess.GetListLanguage().Select(i => i.Name));
            SelectedLanguage = Languages[0];

            bookISBNRepo = unitOfWork.BookISBNs;

            AddCommand = new RelayCommand<object>(
                p => { return true; },
                p => {
                    BookISBNManagementRepository _BookISBNManagementVM = new BookISBNManagementRepository();

                    if (!_BookISBNManagementVM.Add(SelectedLanguage, SelectedBookTitleInformation.Name, SelectedAuthor.Id, SelectedBookTitleInformation.Id))
                    {
                        return;
                    }

                    Parent.DialogResult = true;
                    Parent.Close();
                }
            );

            CancelCommand = new RelayCommand<object>(
                p => { return true; },
                p => {
                    Parent.DialogResult = false;
                    Parent.Close();
                }
            );
        }

        public bool isExist(string bookTitleName, string authorID)
        {
            BookTitleViewModel bookTitleVM = new BookTitleViewModel();
            AuthorViewModel authorVM = new AuthorViewModel();

            foreach (var item in this.bookISBNRepo.Items)
            {
                if (bookTitleVM.bookTitleRepo.GetById(item.IdBookTitle).Name == bookTitleName && item.IdAuthor.ToLower() == authorID.ToLower())
                    return true;
            }
            return false;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace HungVuong_C5_Assignment
{
    public class BookISBNStatus : INotifyPropertyChanged
    {
        public string ISBN { get; set; }
        public DateTime PublishDate { get; set; }
        public string Language { get; set; }
        public string AuthorName { get; set; }
        public DateTime AuthorBoF { get; set; }

        private string _Status;
        public string Status
        {
            get
            {
                return _Status;
            }
            set
            {
                _Status = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public BookISBNStatus(string isbn, DateTime publishDate, string language, string authorName, DateTime AuthorBoF)
        {
            this.ISBN = isbn;
            this.PublishDate = publishDate;
            this.Language = language;
            this.AuthorName = authorName;
            this.AuthorBoF = AuthorBoF;
        }

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}

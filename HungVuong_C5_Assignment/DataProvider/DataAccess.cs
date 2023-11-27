using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HungVuong_C5_Assignment
{
    public static class DataAccess
    {
        public static List<Reader> GetListReader(bool status)
        {
            List<Reader> readers = new List<Reader>();

            using (QuanLyThuVienEntities db = new QuanLyThuVienEntities())
            {
                db.Configuration.LazyLoadingEnabled = false;
                readers.AddRange(db.Readers.Where(i => i.Status == status));
            }

            return readers;
        }

        public static List<Adult> GetListAdult(bool status)
        {
            List<Adult> adults = new List<Adult>();

            using (QuanLyThuVienEntities db = new QuanLyThuVienEntities())
            {
                db.Configuration.LazyLoadingEnabled = false;
                adults.AddRange(db.Adults.Where(i => i.Status == status));
            }

            return adults;
        }

        public static List<Child> GetListChild(bool status)
        {
            List<Child> children = new List<Child>();

            using (QuanLyThuVienEntities db = new QuanLyThuVienEntities())
            {
                db.Configuration.LazyLoadingEnabled = false;
                children.AddRange(db.Children.Where(i => i.Status == status));
            }
            return children;
        }

        public static List<Guardian> GetListGuardian(int quantity)
        {
            List<Guardian> guardians = new List<Guardian>();

            using (QuanLyThuVienEntities db = new QuanLyThuVienEntities())
            {
                ChildViewModel childVM = new ChildViewModel();

                db.Configuration.LazyLoadingEnabled = false;

                foreach(var item in db.Adults.Include("Reader"))
                {
                    if (item.Reader.Status == false)
                        continue;
                    int quantityChild = childVM.GetQuantityChildByAdultID(item.IdReader);
                    if(quantityChild < quantity)
                        guardians.Add(new Guardian(item.IdReader, item.Identify, item.Reader.LName + " " + item.Reader.FName, item.City, item.Phone, quantityChild, item.Reader.boF));
                }
            }

            return guardians;
        }

        public static List<BookISBNInformation> GetListBookISBNInformation()
        {
            List<BookISBNInformation> bookISBNsInformation = new List<BookISBNInformation>();
            BookViewModel bookVM = new BookViewModel();

            using (QuanLyThuVienEntities db = new QuanLyThuVienEntities())
            {
                db.Configuration.LazyLoadingEnabled = false;

                foreach (var item in db.BookISBNs.Include("Author"))
                {
                    bookISBNsInformation.Add(new BookISBNInformation(item.ISBN, item.PublishDate, item.Language, item.Author.Name, item.Author.boF, decimal.Parse(item.BookPrice.ToString()), bookVM.GetQuantityBookByISBN(item.ISBN, true) != 0));
                }
            }

            return bookISBNsInformation;
        }

        public static List<BookISBNStatus> GetListBookISBNStatus()
        {
            List<BookISBNStatus> lstBookISBNStatus = new List<BookISBNStatus>();

            BookViewModel bookVM = new BookViewModel();

            using (QuanLyThuVienEntities db = new QuanLyThuVienEntities())
            {
                db.Configuration.LazyLoadingEnabled = false;

                foreach (var item in db.BookISBNs.Include("Author"))
                {
                    BookISBNStatus bookISBNStatus = new BookISBNStatus(item.ISBN, item.PublishDate, item.Language, item.Author.Name, item.Author.boF);

                    if (bookVM.GetQuantityBookByISBN(item.ISBN, true) == 0)
                        bookISBNStatus.Status = "No";
                    else
                        bookISBNStatus.Status = "Yes";

                    lstBookISBNStatus.Add(bookISBNStatus);
                }
            }
            return lstBookISBNStatus;
        }

        public static List<Province> GetListProvince()
        {
            List<Province> provinces = new List<Province>() {
                new Province() { Id = 1, Name = "Khánh Hòa" },
                new Province() { Id = 2, Name = "Bà Rịa - Vũng Tàu" },
                new Province() { Id = 3, Name = "Bắc Giang" },
                new Province() { Id = 4, Name = "Bắc Kạn" },
                new Province() { Id = 5, Name = "Bạc Liêu" },
                new Province() { Id = 6, Name = "Bắc Ninh" },
                new Province() { Id = 7, Name = "Bến Tre" },
                new Province() { Id = 8, Name = "Bình Định" },
                new Province() { Id = 9, Name = "Bình Dương" },
                new Province() { Id = 10, Name = "Bình Phước" },
                new Province() { Id = 11, Name = "Bình Thuận" },
                new Province() { Id = 12, Name = "Cà Mau" },
                new Province() { Id = 13, Name = "Cần Thơ" },
                new Province() { Id = 14, Name = "Cao Bằng" },
                new Province() { Id = 15, Name = "Đà Nẵng" },
                new Province() { Id = 16, Name = "Đắk Lắk" },
                new Province() { Id = 17, Name = "Đắk Nông" },
                new Province() { Id = 18, Name = "Điện Biên" },
                new Province() { Id = 19, Name = "Đồng Nai" },
                new Province() { Id = 20, Name = "Đồng Tháp" },
                new Province() { Id = 21, Name = "Gia Lai" },
                new Province() { Id = 22, Name = "Hà Giang" },
                new Province() { Id = 23, Name = "Hà Nam" },
                new Province() { Id = 24, Name = "Hà Nội" },
                new Province() { Id = 25, Name = "Hà Tĩnh" },
                new Province() { Id = 26, Name = "Hải Dương" },
                new Province() { Id = 27, Name = "Hải Phòng" },
                new Province() { Id = 28, Name = "Hậu Giang" },
                new Province() { Id = 29, Name = "Hòa Bình" },
                new Province() { Id = 30, Name = "Hưng Yên" },
                new Province() { Id = 31, Name = "An Giang" },
                new Province() { Id = 32, Name = "Kiên Giang" },
                new Province() { Id = 33, Name = "Kon Tum" },
                new Province() { Id = 34, Name = "Lai Châu" },
                new Province() { Id = 35, Name = "Lâm Đồng" },
                new Province() { Id = 36, Name = "Lạng Sơn" },
                new Province() { Id = 37, Name = "Lào Cai" },
                new Province() { Id = 38, Name = "Long An" },
                new Province() { Id = 39, Name = "Nam Định" },
                new Province() { Id = 40, Name = "Nghệ An" },
                new Province() { Id = 41, Name = "Ninh Bình" },
                new Province() { Id = 42, Name = "Ninh Thuận" },
                new Province() { Id = 43, Name = "Phú Thọ" },
                new Province() { Id = 44, Name = "Phú Yên" },
                new Province() { Id = 45, Name = "Quảng Bình" },
                new Province() { Id = 46, Name = "Quảng Nam" },
                new Province() { Id = 47, Name = "Quảng Ngãi" },
                new Province() { Id = 48, Name = "Quảng Ninh" },
                new Province() { Id = 49, Name = "Quảng Trị" },
                new Province() { Id = 50, Name = "Sóc Trăng" },
                new Province() { Id = 51, Name = "Sơn La" },
                new Province() { Id = 52, Name = "Tây Ninh" },
                new Province() { Id = 53, Name = "Thái Bình" },
                new Province() { Id = 54, Name = "Thái Nguyên" },
                new Province() { Id = 55, Name = "Thanh Hóa" },
                new Province() { Id = 56, Name = "Thừa Thiên Huế" },
                new Province() { Id = 57, Name = "Tiền Giang" },
                new Province() { Id = 58, Name = "TP Hồ Chí Minh" },
                new Province() { Id = 59, Name = "Trà Vinh" },
                new Province() { Id = 60, Name = "Tuyên Quang" },
                new Province() { Id = 61, Name = "Vĩnh Long" },
                new Province() { Id = 62, Name = "Vĩnh Phúc" },
                new Province() { Id = 63, Name = "Yên Bái" },
                new Province() { Id = 64, Name = "Đồng Nai" }
            };
            return provinces;
        }

        public static List<Language> GetListLanguage()
        {
            List<Language> languages = new List<Language>();
            CultureInfo[] cultureInfos = CultureInfo.GetCultures(CultureTypes.AllCultures);

            Language vietnamese1 = null;
            Language vietnamese2 = null;

            foreach (CultureInfo cultureInfo in cultureInfos)
            {
                try
                {
                    if(cultureInfo.DisplayName == "Vietnamese")
                    {
                        vietnamese1 = new Language(cultureInfo.Name, cultureInfo.DisplayName);
                        continue;
                    }
                    else if (cultureInfo.DisplayName == "Vietnamese (Vietnam)")
                    {
                        vietnamese2 = new Language(cultureInfo.Name, cultureInfo.DisplayName);
                        continue;
                    }
                    Language language = new Language(cultureInfo.Name, cultureInfo.DisplayName);
                    languages.Add(language);
                }
                catch (CultureNotFoundException)
                {
                }
            }
            languages.Insert(0, vietnamese1);
            languages.Insert(0, vietnamese2);
            return languages;
        }
    }
}

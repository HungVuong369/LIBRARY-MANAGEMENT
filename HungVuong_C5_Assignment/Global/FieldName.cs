using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HungVuong_C5_Assignment
{
    public static class FieldName
    {
        // Reader
        public static string LName = "LName";
        public static string FName = "FName";
        public static string BoF = "boF";
        public static string ReaderType = "ReaderType";

        // Adult
        public static string IdReader = "IdReader";
        public static string Address = "Address";
        public static string City = "City";
        public static string Phone = "Phone";
        public static string ExpDate = "ExpireDate";
        public static string Identify = "Identify";

        // Child
        public static string AdultID = "IdAdult";

        // BookISBN
        public static string ISBN = "ISBN";
        public static string BookTitleID = "IdBookTitle";
        public static string AuthorID = "IdAuthor";
        public static string PublishDate = "PublishDate";
        public static string Language = "Language";

        // Author
        public static string Summary = "Summary";

        // BookTitle
        public static string CategoryID = "IdCategory";

        // Parameter
        public static string Description = "Description";
        public static string Value = "Value";

        // User
        public static string Username = "Username";
        public static string Password = "Password";

        // UserRole
        public static string IdUser = "IdUser";
        public static string IdRole = "IdRole";

        // Function
        public static string IdFunction = "IdFunction";
        public static string IdParent = "IdParent";
        public static string UrlImage = "UrlImage";

        // Role
        public static string Group = "Group";

        // Share
        public static string Id = "Id";
        public static string Name = "Name";
        public static string Status = "Status";
        public static string CreatedAt = "CreatedAt";
        public static string ModifiedAt = "ModifiedAt";
    }
}

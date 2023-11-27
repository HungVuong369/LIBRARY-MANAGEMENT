using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HungVuong_C5_Assignment
{
    public static class TSQL
    {
        public static string AllReaderTrue = "select * from Reader where [Status] = 1";
        public static string AllReaderFalse = "select * from Reader where [Status] = 0";
        public static string AllAdultTrue = "select * from Adult where [Status] = 1";
        public static string AllAdultFalse = "select * from Adult where [Status] = 0";
        public static string AllChildTrue = "select * from Child where [Status] = 1";
        public static string AllChildFalse = "select * from Child where [Status] = 0";
        public static string AllAuthor = "select * from Author";
        public static string AllBookTitle = "select * from BookTitle";
        public static string AllBookISBN = "select * from BookISBN";
        public static string AllBook = "select * from Book";
        public static string AllCategory = "select * from Category";
        public static string AllParameter = "select * from [Parameter]";

        public static string AllUser = "select * from [User]";
        public static string AllUserInfo = "select * from [UserInfo]";
        public static string AllUserRole = "select * from [UserRole]";
        public static string AllRoleFunction = "select * from [RoleFunction]";
        public static string AllUserFunction = "select * from [UserFunction]";
        public static string AllFunction = "select * from [Function]";
        public static string AllRole = "select * from [Role]";

        public static string InsertReader = $"INSERT INTO Reader VALUES(@{FieldName.Id}, @{FieldName.LName}, @{FieldName.FName}, @{FieldName.BoF}, @{FieldName.ReaderType}, @{FieldName.Status}, @{FieldName.CreatedAt}, @{FieldName.ModifiedAt})";
        public static string InsertAdult = $"INSERT INTO Adult VALUES(@{FieldName.IdReader}, @{FieldName.Identify}, @{FieldName.Address}, @{FieldName.City}, @{FieldName.Phone}, @{FieldName.ExpDate}, @{FieldName.Status}, @{FieldName.CreatedAt}, @{FieldName.ModifiedAt})";
        public static string InsertChild = $"INSERT INTO Child VALUES(@{FieldName.IdReader}, @{FieldName.AdultID}, @{FieldName.Status}, @{FieldName.CreatedAt}, @{FieldName.ModifiedAt})";
        public static string InsertBook = $"INSERT INTO Book VALUES(@{FieldName.Id}, @{FieldName.ISBN}, @{FieldName.Status})";
        public static string InsertBookISBN = $"INSERT INTO BookISBN VALUES(@{FieldName.ISBN}, @{FieldName.BookTitleID}, @{FieldName.AuthorID}, @{FieldName.PublishDate}, @{FieldName.Language}, @{FieldName.Status})";

        public static string InsertRole = $"INSERT INTO [Role] VALUES(@{FieldName.Id}, @{FieldName.Name}, @{FieldName.Group}, @{FieldName.Status})";
        public static string InsertRoleFunction = $"INSERT INTO [RoleFunction] VALUES(@{FieldName.Id}, @{FieldName.IdRole}, @{FieldName.IdFunction})";
        public static string InsertUser = $"INSERT INTO [User] VALUES(@{FieldName.Id}, @{FieldName.Username}, @{FieldName.Password}, @{FieldName.Status}, @{FieldName.CreatedAt}, @{FieldName.ModifiedAt})";
        public static string InsertFunction = $"INSERT INTO [Function] VALUES(@{FieldName.Id}, @{FieldName.Name}, @{FieldName.Description}, @{FieldName.IdParent}, @{FieldName.UrlImage}, @{FieldName.Status})";
        public static string InsertUserInfo = $"INSERT INTO [UserInfo] VALUES(@{FieldName.IdUser}, @{FieldName.LName}, @{FieldName.FName}, @{FieldName.Phone}, @{FieldName.Address})";

        public static string InsertBookTitle = $"INSERT INTO BookTitle VALUES(@{FieldName.Id}, @{FieldName.CategoryID}, @{FieldName.Name}, @{FieldName.AuthorID}, @{FieldName.Summary})";

        public static string InsertUserRole = $"INSERT INTO [UserRole] VALUES(@{FieldName.Id}, @{FieldName.IdUser}, @{FieldName.IdRole})";

        public static string LastRole = $"SELECT TOP 1 {FieldName.Id} FROM [Role] ORDER BY CAST(SUBSTRING({FieldName.Id}, 2, LEN({FieldName.Id})) AS INT) DESC";
        public static string LastUser = $"SELECT TOP 1 {FieldName.Id} FROM [User] ORDER BY CAST(SUBSTRING({FieldName.Id}, 2, LEN({FieldName.Id})) AS INT) DESC";
        public static string LastFunction = $"SELECT TOP 1 {FieldName.Id} FROM [Function] ORDER BY CAST(SUBSTRING({FieldName.Id}, 2, LEN({FieldName.Id})) AS INT) DESC";
        public static string LastUserInfo = $"SELECT TOP 1 {FieldName.IdUser} FROM [UserInfo] ORDER BY CAST(SUBSTRING({FieldName.IdUser}, 2, LEN({FieldName.IdUser})) AS INT) DESC";
        public static string LastRoleFunction = $"SELECT TOP 1 {FieldName.Id} FROM [RoleFunction] ORDER BY CAST(SUBSTRING({FieldName.Id}, 3, LEN({FieldName.Id})) AS INT) DESC";
        public static string LastBook = $"SELECT TOP 1 {FieldName.Id} FROM Book ORDER BY CAST(SUBSTRING({FieldName.Id}, 2, LEN({FieldName.Id})) AS INT) DESC";

        public static string LastReader = $"SELECT TOP 1 {FieldName.Id} FROM Reader ORDER BY {FieldName.Id} DESC";
        public static string LastBookTitle = $"SELECT TOP 1 {FieldName.Id} FROM BookTitle ORDER BY {FieldName.Id} DESC";
        public static string LastUserRole = $"SELECT TOP 1 {FieldName.Id} FROM [UserRole] ORDER BY {FieldName.Id} DESC";
        public static string LastBookISBN = $"SELECT TOP 1 {FieldName.ISBN} From BookISBN ORDER BY {FieldName.ISBN} DESC";

        //DTOs
        public static string AllReaderAndAdult = $"select * from Adult a, Reader r where r.Id = a.IdReader and r.Status = 1 and a.Status = 1";
        public static string AllBookISBNInformation = $"select * from BookISBN, Author where BookISBN.IdAuthor = Author.Id";

        public static string UpdateUser(string id)
        {
            return $"UPDATE [User] SET Username = @{FieldName.Username}, Password = @{FieldName.Password}, ModifiedAt = @{FieldName.ModifiedAt} WHERE {FieldName.Id} = '{id}'";
        }

        public static string UpdateFunction(string id)
        {
            return $"UPDATE [Function] SET Name = @{FieldName.Name}, Description = @{FieldName.Description}, IdParent = @{FieldName.IdParent}, UrlImage = @{FieldName.UrlImage} WHERE {FieldName.Id} = '{id}'";
        }

        public static string UpdateUserRole(string IdRole, string IdUser)
        {
            return $"UPDATE [UserRole] SET IdRole = @{FieldName.IdRole} WHERE {FieldName.IdRole} = '{IdRole}' and {FieldName.IdUser} = '{IdUser}'";
        }

        public static string UpdateUserInfo(string IdUser)
        {
            return $"UPDATE [UserInfo] SET LName = @{FieldName.LName}, FName = @{FieldName.FName}, Phone = @{FieldName.Phone}, Address =@{FieldName.Address} WHERE {FieldName.IdUser} = '{IdUser}'";
        }

        public static string UpdateParameterById(string id, string value)
        {
            return $"UPDATE [Parameter] SET Value = '{value}' WHERE {FieldName.Id} = '{id}'";
        }

        public static string UpdateStatusChild(int status, string IdReader)
        {
            return $"update Child set Status = {status} where {FieldName.IdReader} = '{IdReader}'";
        }

        public static string UpdateAdultIDChild(string IdReader, string adultID)
        {
            return $"update Child set IdAdult = '{adultID}' where {FieldName.IdReader} = '{IdReader}'";
        }

        public static string UpdateStatusAdult(int status, string IdReader)
        {
            return $"update Adult set Status = {status} where {FieldName.IdReader} = '{IdReader}'";
        }

        public static string UpdateStatusReader(int status, string IdReader)
        {
            return $"update Reader set Status = {status} where {FieldName.Id} = '{IdReader}'";
        }

        public static string UpdateStatusFunction(int status, string id)
        {
            return $"update [Function] set Status = {status} where {FieldName.Id} = '{id}'";
        }

        public static string UpdateStatusBook(int status, string isbn)
        {
            return $"update Book set Status = {status} where {FieldName.ISBN} = '{isbn}'";
        }

        public static string UpdateStatusBookISBN(int status, string isbn)
        {
            return $"update BookISBN set Status = {status} where {FieldName.ISBN} = '{isbn}'";
        }

        public static string ExistIdentify(string identify)
        {
            return $"SELECT * FROM Adult WHERE Identify = '{identify}'";
        }

        public static string ExistUsername(string username)
        {
            return $"SELECT * FROM [User] WHERE LOWER(Username) = '{username.ToLower()}'";
        }

        public static string ExistFunction(string idParent)
        {
            return $"SELECT * FROM [Function] WHERE [IdParent] = '{idParent}' AND Lower(Name) = @Name";
        }

        public static string DeleteUser(string id)
        {
            return $"Delete from [User] Where {FieldName.Id}='{id}'";
        }

        public static string DeleteRoleFunction(string id)
        {
            return $"Delete from [RoleFunction] Where {FieldName.Id}='{id}'";
        }

        public static string DeleteUserRole(string IdUser)
        {
            return $"Delete from [UserRole] Where {FieldName.IdUser}='{IdUser}'";
        }

        public static string DeleteUserInfo(string IdUser)
        {
            return $"Delete from [UserInfo] Where {FieldName.IdUser}='{IdUser}'";
        }
    }
}

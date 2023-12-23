﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HungVuong_C5_Assignment
{
    using System;
    using System.Configuration;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    public partial class QuanLyThuVienEntities : DbContext
    {
        public QuanLyThuVienEntities()
            : base(GetConnection())
        {
        }
        
        private static string GetConnection()
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            ConnectionStringSettings connectionStringSetting = config.ConnectionStrings.ConnectionStrings["QuanLyThuVienEntities"];
            return connectionStringSetting.ConnectionString;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Adult> Adults { get; set; }
        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<BookISBN> BookISBNs { get; set; }
        public virtual DbSet<BookStatu> BookStatus { get; set; }
        public virtual DbSet<BookTitle> BookTitles { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Child> Children { get; set; }
        public virtual DbSet<Function> Functions { get; set; }
        public virtual DbSet<LoanDetail> LoanDetails { get; set; }
        public virtual DbSet<LoanDetailHistory> LoanDetailHistories { get; set; }
        public virtual DbSet<LoanHistory> LoanHistories { get; set; }
        public virtual DbSet<LoanSlip> LoanSlips { get; set; }
        public virtual DbSet<Parameter> Parameters { get; set; }
        public virtual DbSet<PenaltyReason> PenaltyReasons { get; set; }
        public virtual DbSet<Province> Provinces { get; set; }
        public virtual DbSet<Publisher> Publishers { get; set; }
        public virtual DbSet<Reader> Readers { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<RoleFunction> RoleFunctions { get; set; }
        public virtual DbSet<Translator> Translators { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserInfo> UserInfoes { get; set; }
        public virtual DbSet<UserRole> UserRoles { get; set; }
    }
}

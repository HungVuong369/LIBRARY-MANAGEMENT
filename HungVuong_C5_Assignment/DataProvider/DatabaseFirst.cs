using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HungVuong_C5_Assignment
{
    public class DatabaseFirst
    {
        private static DatabaseFirst _Instance;
        private static readonly object _LockObject = new object();
        public QuanLyThuVienEntities db;
        public User UserLoggedIn;

        private DatabaseFirst()
        {
            db = new QuanLyThuVienEntities();
            db.Configuration.LazyLoadingEnabled = false;
        }

        public static DatabaseFirst Instance
        {
            get
            {
                if (_Instance == null)
                {
                    lock (_LockObject)
                    {
                        if (_Instance == null)
                        {
                            _Instance = new DatabaseFirst();
                        }
                    }
                }

                return _Instance;
            }
        }

        public void SaveChanged()
        {
            db.SaveChanges();
        }
    }
}

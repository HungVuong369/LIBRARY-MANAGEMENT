using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HungVuong_C5_Assignment
{
    public class UserInfoViewModel
    {
        private static readonly UnitOfWork unitOfWork = new UnitOfWork();
        public UserInfoRepository UserInfoRepo;

        public UserInfoViewModel()
        {
            UserInfoRepo = unitOfWork.UserInfos;
        }
    }
}

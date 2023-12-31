﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HungVuong_C5_Assignment
{
    public class UserRoleViewModel
    {
        private static readonly UnitOfWork unitOfWork = new UnitOfWork();

        public UserRoleRepository userRoleRepo { get; set; }

        public UserRoleViewModel()
        {
            userRoleRepo = unitOfWork.UserRoles;
        }
    }
}

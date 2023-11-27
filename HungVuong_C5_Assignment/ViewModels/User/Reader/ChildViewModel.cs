using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HungVuong_C5_Assignment
{
    public class ChildViewModel
    {
        private static readonly UnitOfWork unitOfWork = new UnitOfWork();
        public ChildRepository childRepo { get; set; }

        public ChildViewModel()
        {
            childRepo = unitOfWork.Childs;
        }

        public int GetQuantityChildByAdultID(string adultID)
        {
            int count = 0;
            foreach(var item in childRepo.Items)
            {
                if(item.IdAdult == adultID)
                    count++;
            }
            return count;
        }

        public Child GetByAdultID(string adultID)
        {
            foreach(var item in childRepo.Items)
            {
                if (item.IdAdult == adultID)
                    return item;
            }
            return null;
        }

        public Child GetByAdultIDSecond(string adultID)
        {
            bool flag = false;

            foreach (var item in childRepo.Items)
            {
                if (item.IdAdult == adultID)
                {
                    if (!flag)
                    {
                        flag = true;
                        continue;
                    }

                    return item;
                }
            }
            return null;
        }
    }
}

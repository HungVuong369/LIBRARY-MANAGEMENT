using System.Collections.Generic;

namespace HungVuong_C5_Assignment
{
    interface IRepositoryBase<T>
    {
        int Length();

        List<T> Gets();
        T GetByIndex(int index);
    }
}

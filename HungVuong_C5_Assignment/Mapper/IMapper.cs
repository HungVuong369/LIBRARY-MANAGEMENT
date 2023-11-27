using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HungVuong_C5_Assignment
{
    public interface IMapper<TSource, TDestination>
    {
        TDestination MapTo(TSource source);
        TSource MapFrom(TDestination destination);
    }
}

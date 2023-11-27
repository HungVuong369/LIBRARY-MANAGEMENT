using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HungVuong_C5_Assignment
{
    class Mapper<TSource, TDestination> : IMapper<TSource, TDestination>
    {
        public TSource MapFrom(TDestination destination)
        {
            throw new NotImplementedException();
        }

        public TDestination MapTo(TSource source)
        {
            throw new NotImplementedException();
        }
    }
}

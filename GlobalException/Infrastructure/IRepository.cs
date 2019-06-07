using GlobalException.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GlobalException.Infrastructure
{
    public interface IRepository<T>
    {
        T Add();       
    }
}

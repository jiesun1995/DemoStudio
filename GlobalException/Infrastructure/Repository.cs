using GlobalException.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GlobalException.Infrastructure
{
    public class Repository<T> : IRepository<T> where T: Entity,new()
    {
        public T Add()
        {
            return new T();
        }
    }
}

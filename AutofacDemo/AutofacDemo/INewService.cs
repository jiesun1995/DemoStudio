using System;
using System.Collections.Generic;
using System.Text;

namespace AutofacDemo
{
    public interface INewService:IDependency
    {
        void Newfun();
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace AutofacDemo
{
    public interface ITestService: IDependency
    {
        void Test();
    }
}

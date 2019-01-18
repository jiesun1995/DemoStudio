using System;
using System.Collections.Generic;
using System.Text;

namespace AutofacDemo
{
    public class TestService : ITestService
    {
        public void Test()
        {
            Console.WriteLine("test 方法");
        }
    }
}

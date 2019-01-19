using System;
using System.Collections.Generic;
using System.Text;

namespace AutofacDemo
{
    public class TestService : ITestService
    {
        private readonly INewService _newService;

        public TestService(INewService newService)
        {
            _newService = newService;
        }

        public void Test()
        {
            _newService.Newfun();
            Console.WriteLine("test 方法");
        }
    }
}

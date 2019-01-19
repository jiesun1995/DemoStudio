using System;
using System.Collections.Generic;
using System.Text;

namespace AutofacDemo
{
    public class Startup:IDependency
    {
        private readonly ITestService _testService;

        public Startup(ITestService testService)
        {
            _testService = testService;
        }

        public void Run()
        {
            _testService.Test();
            Console.WriteLine("Running");
        }
    }
}

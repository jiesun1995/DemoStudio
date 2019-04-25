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
            Dictionary<string, string> kvs = new Dictionary<string, string>();

            //将控件的name新增进去去重
            if (kvs.TryAdd("1", "2"))
            {
                //做sql拼接
            }

            //_testService.Test();
            //Console.WriteLine("Running");
        }
    }
}

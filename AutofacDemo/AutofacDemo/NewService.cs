using System;
using System.Collections.Generic;
using System.Text;

namespace AutofacDemo
{
    public class NewService : INewService
    {
        public void Newfun()
        {
            Console.WriteLine("这是一个新方法");
        }
    }
}

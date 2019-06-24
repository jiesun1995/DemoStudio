using System;
using System.Net;

namespace dapperDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            IPAddress[] addressList = Dns.GetHostEntry(Dns.GetHostName()).AddressList;

            //如果本机IP列表小于2，则返回空字符串
            if (addressList.Length < 2)
            {
                return ;
            }

            //返回本机的广域网IP
            addressList[1].ToString();


            Console.WriteLine("Hello World!");
        }
    }
}

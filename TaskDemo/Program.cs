using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace TaskDemo
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var watch = Stopwatch.StartNew();
            watch.Start();
            Func<int, Task<int>> func = async x =>
               {
                   Console.WriteLine(x);
                   await Task.Delay(x * 1000);
                   Console.WriteLine(x);
                   return x * 2;
               };

            var first = await func(5);
            var last = await func(3);
            Console.WriteLine( first);
            Console.WriteLine( last);
            watch.Stop();
            Console.WriteLine(watch.ElapsedMilliseconds);
            Console.ReadLine();
        }
    }
}

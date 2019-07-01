using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TxtDemo
{
    class Program
    {
        static void Main1(string[] args)
        {





            string readerFileName = @"C:\script.sql";
            string writerFileName = @"C:\script1.sql";
            string val = "use [zh_0322]";
            if (args != null && args.Count() >= 3)
            {
                readerFileName = args[0].ToString();
                writerFileName = args[1].ToString();
                val = args[2].ToString();
            }
            try
            {
                readerFileName = @"C:\Users\Administrator\Desktop\script.sql";
                writerFileName = @"C:\Users\Administrator\Desktop\script1.sql";
                val = "use [zh_0322]";
                var index = 1;
                //using (FileStream reader = new FileStream(readerFileName, FileMode.Open))
                using (StreamReader reader = new StreamReader(readerFileName))
                {
                    //reader.ReadLine();
                    //using (FileStream writer = new FileStream(writerFileName, FileMode.Create))
                    using (StreamWriter writer = new StreamWriter(writerFileName))
                    {
                        //StringBuilder line = new StringBuilder();
                        var line = string.Empty;

                        reader.ReadLine();
                        writer.WriteLine($"{val}");
                        index++;
                        while ((line = reader.ReadLine()) != null)
                        {
                            //var line = reader.ReadLine();
                            index++;
                            writer.WriteLine(line);
                        }
                        if (line == null)
                        {
                            Console.WriteLine(index);
                            Console.WriteLine($"{reader.ReadLine()}");
                            Console.WriteLine($"{reader.ReadLine()}");
                        }
                        writer.Flush();
                        //var frist = Encoding.Default.GetBytes($"{val} \r\n");

                        //writer.Write(frist, 0, frist.Length);
                        //var data = new byte[1024 * 1024];

                        //while ((reader.BaseStream.Read(data, 0, data.Length)) > 0)//把流中数据写入到字符数组中 读取流中数据
                        //{
                        //    writer.Write(data, 0, data.Count());//从字符数组中读取流
                        //}
                    }
                }
                //using (StreamReader writer = File.OpenText(writerFileName))
                //{
                //    using (StreamReader reader = File.OpenText(readerFileName))
                //    {
                //        for (int i = 0; i < 100; i++)
                //        {
                //            Console.WriteLine($"{writer.ReadLine()}");
                //            Console.WriteLine($"{reader.ReadLine()}");
                //        }
                //    }
                //}
            }
            catch (Exception ex)
            {

                Console.WriteLine($"{ex.Message}");
            }
            Console.ReadLine();
        }

        static void Main(string[] args)
        {
            var t1 = Task.Factory.StartNew(() =>
            {
                Console.WriteLine(help.num);
                help.str = "task change help";
                Thread.Sleep(1000);
                Console.WriteLine(help.str);

            });
            var t2 = Task.Factory.StartNew(() =>
            {
                Console.WriteLine(help.str);
                help.num = 1;
                Thread.Sleep(1000);
                Console.WriteLine(help.num);
            });
            Task.WaitAll(t1, t2);
            Thread.Sleep(0);
            Console.ReadLine();
        }
    }
    public class help
    {
        public static int num = 10;
        public static string str = "this is string";
             
    }
}

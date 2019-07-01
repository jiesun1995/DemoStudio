using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace stringint
{
    class Program
    {
        static void Main(string[] args)
        {
            var watch = Stopwatch.StartNew();
            watch.Start();
            StringBuilder stringBuilder = new StringBuilder();
            var sum = 0;
            for (int i = 0; i < 10000; i++)
            {
                string str = i.ToString();
                int num = Convert.ToInt32(str);
                sum += i;
            }
            watch.Stop();
            //Console.WriteLine(stringBuilder.ToString());
            //Console.WriteLine(sum);
            //Console.WriteLine(watch.ElapsedMilliseconds);



            String str1 = "world";
            String str2 = new String("world");
            Console.WriteLine(str1==str2);
            Console.WriteLine(str1.Equals(str2));

            /////深拷贝
            //School school = new School()
            //{
            //    Name = "zhangsan",
            //    Students=new List<Student>()
            //    {
            //        new Student(){ Name="lisi" },
            //    },
            //};            
            //var school1 = school.Clone() as School;

            //school1.Name = "lisi";
            //school1.Students[0].Name = "wangwu";

            Console.ReadLine();
        }

    }
    public class School : ICloneable
    {
        public List<Student> Students { set; get; } = new List<Student>();
        public string Name { set; get; }
        public School()
        {            
        }
        private School(List<Student> Students)
        {
            foreach (var item in Students)
            {
                this.Students.Add(item.Clone() as Student);
            }
        }
        public object Clone()
        {
            return new School(this.Students);
        }
    }
    public class Student: ICloneable
    {
        public string Name { set; get; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}

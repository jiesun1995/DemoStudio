using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Reflection;

namespace EFDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //var ConnectionString = "Data Source=blogging.db";
            var serviceDescriptors = new ServiceCollection();

            serviceDescriptors.AddDbContext<BloggingContext>();
            var Services = serviceDescriptors.BuildServiceProvider();            
        }
    }
}

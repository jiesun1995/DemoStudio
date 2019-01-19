using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Reflection;

namespace AutofacDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ContainerBuilder();//实例化 AutoFac  容器   
            var serviceDescriptors = new ServiceCollection();

            
            var assemblys = AppDomain.CurrentDomain.GetAssemblies().ToList();//Service是继承接口的实现方法类库名称
            var baseType = typeof(IDependency);//IDependency 是一个接口（所有要实现依赖注入的借口都要继承该接口）
            builder.RegisterAssemblyTypes(assemblys.ToArray())
             .Where(m => baseType.IsAssignableFrom(m) && m != baseType)
             .AsImplementedInterfaces().InstancePerLifetimeScope();


            builder.RegisterAssemblyTypes(assemblys.ToArray())
                .Where(x => x.GetInterfaces().Contains(baseType))
                .AsSelf()
                .InstancePerDependency();
            //builder.RegisterType<Startup>();
            builder.Populate(serviceDescriptors);
            var ApplicationContainer = builder.Build();
            //var ApplicationContainer= new AutofacServiceProvider(ApplicationContainer);



            //var testservice = ApplicationContainer.Resolve<ITestService>();
            var startup = ApplicationContainer.Resolve<Startup>();
            startup.Run();
            //testservice.Test();
            Console.WriteLine("Hello World!");
            Console.ReadLine();


        }
    }
}

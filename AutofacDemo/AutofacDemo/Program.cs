using Autofac;
using System;
using System.Reflection;

namespace AutofacDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ContainerBuilder();//实例化 AutoFac  容器   



            var assemblys = Assembly.GetAssembly(typeof(Program));//Service是继承接口的实现方法类库名称
            var baseType = typeof(IDependency);//IDependency 是一个接口（所有要实现依赖注入的借口都要继承该接口）
            builder.RegisterAssemblyTypes(assemblys)
             .Where(m => baseType.IsAssignableFrom(m) && m != baseType)
             .AsImplementedInterfaces().InstancePerLifetimeScope();

            //builder.Populate(services);
            var ApplicationContainer = builder.Build();
            //return new AutofacServiceProvider(ApplicationContainer);



            var testservice = ApplicationContainer.Resolve<ITestService>();
            testservice.Test();
            Console.WriteLine("Hello World!");
            Console.ReadLine();


        }
    }
}

using System;
using System.Reflection.Emit;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;

namespace ClassClone
{
    class Program
    {
        static void Main(string[] args)
        {

            List<int> list = new List<int>()
            {
                1,2,3,4,1,2,3
            };
            var newlist = list.Where(x => {
                //Console.WriteLine(x);
                var result = !list.Any(y => {

                    var result1= y == x;
                    Console.WriteLine(y);
                    Console.WriteLine(x);
                    Console.WriteLine(result1);
                    return result1; });
                return result;
            }).ToList();
            Console.ReadLine();
            //return "value";


            //School school = new School()
            //{
            //    Name = "昆明小学",
            //    Students = new List<Student>()
            //    {
            //        new Student(){ Name="li",Age=10 },
            //        new Student(){  Name="zhang",Age=12},
            //        new Student(){  Name="sun",Age=11}

            //    },
            //};
            //var newschool = new School();
            //FastProperty<School> fastProperty = new FastProperty<School>(newschool);
            
            //var val= fastProperty.SetPropertyValue($"{nameof(newschool.Students)}", school);
            


            //Console.WriteLine("Hello World!");
        }
    }


    public class School
    {
        public string Name { set; get; }
        public List<Student> Students { set; get; } 
    }
    public class Student
    {
        public string Name { set; get; }
        public int Age { set; get; }

    }

    public class FastProperty<T>

    {

        public delegate void SetValueDelegateHandler(T owner, object value);

        private readonly Type ParameterType = typeof(object);



        private T _owner;

        public T Owner { get { return this._owner; } }



        private Type _ownerType;



        public FastProperty(T owner)

        {

            this._owner = owner;

            this._ownerType = typeof(T);

        }





        public SetValueDelegateHandler SetPropertyValue(string propertyName, object value)

        {



            // 指定函数名

            string methodName = "set_" + propertyName;

            // 搜索函数，不区分大小写 IgnoreCase

            var callMethod = this._ownerType.GetMethod(methodName, BindingFlags.Instance | BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.NonPublic);

            // 获取参数

            var para = callMethod.GetParameters()[0];

            // 创建动态函数

            DynamicMethod method = new DynamicMethod("EmitCallable", null, new Type[] { this._ownerType, ParameterType }, this._ownerType.Module);

            // 获取动态函数的 IL 生成器

            var il = method.GetILGenerator();

            // 创建一个本地变量，主要用于 Object Type to Propety Type

            var local = il.DeclareLocal(para.ParameterType, true);

            // 加载第 2 个参数【(T owner, object value)】的 value

            il.Emit(OpCodes.Ldarg_1);

            if (para.ParameterType.IsValueType)

            {

                il.Emit(OpCodes.Unbox_Any, para.ParameterType);// 如果是值类型，拆箱 string = (string)object;

            }

            else

            {

                il.Emit(OpCodes.Castclass, para.ParameterType);// 如果是引用类型，转换 Class = object as Class

            }

            il.Emit(OpCodes.Stloc, local);// 将上面的拆箱或转换，赋值到本地变量，现在这个本地变量是一个与目标函数相同数据类型的字段了。

            il.Emit(OpCodes.Ldarg_0);   // 加载第一个参数 owner

            il.Emit(OpCodes.Ldloc, local);// 加载本地参数

            il.EmitCall(OpCodes.Callvirt, callMethod, null);//调用函数

            il.Emit(OpCodes.Ret);   // 返回

            /* 生成的动态函数类似：

             * void EmitCallable(T owner, object value)

             * {

             *     T local = (T)value;

             *     owner.Method(local);

             * }

             */

            return method.CreateDelegate(typeof(SetValueDelegateHandler)) as SetValueDelegateHandler;





        }

    }
}

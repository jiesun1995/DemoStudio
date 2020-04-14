using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Oracle.ManagedDataAccess.Client;
using Dos.ORM;

namespace dapperDemoFW
{
    class Program
    {
        static string con = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=192.168.33.80)(PORT=1521)))(CONNECT_DATA=(sid =xe)));User Id=sj;Password=admin";
        //public static readonly DbSession Context = new DbSession("SqlServerConn");
        public static readonly DbSession Context = new DbSession(DatabaseType.Oracle,con);
        static void Main(string[] args)
        {
             
        //SessionFactory.AddDataSource(new DataSource()
        //{
        //    Name = "mysql",
        //    Source = () => new SqlConnection("connectionString"),
        //    SourceType = DataSourceType.SQLSERVER,
        //    UseProxy = true//使用Session的静态代理实现，记录日志，执行耗时,线上环境建议关闭代理
        //});
        //string strcon = "";
        //IDbConnection con = new OracleConnection(strcon);



        Context.RegisterSqlLogger(delegate (string sql)
            {
                //在此可以记录sql日志
                //写日志会影响性能，建议开发版本记录sql以便调试，发布正式版本不要记录
                //LogHelper.Debug(sql, "SQL日志");
                Console.WriteLine(sql);
            });

            var model = new PersonEntity()
            {
                CarId = 1,
                CreateTime = DateTime.Now,
                IsActive = 1,
                PersonId = 2,
                PersonName = "测试",
                UpdateTime = DateTime.Now
            };
            var rows= Context.Insert<PersonEntity>(entity:model);

            model = Context.From<PersonEntity>().Where(x => x.PersonId == 2).Select().ToFirstDefault();
            Console.WriteLine($"{nameof(model.PersonName)}:{model.PersonName}");
            Console.ReadLine();
        }
    }
}

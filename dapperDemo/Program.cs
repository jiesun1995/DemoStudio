using Dapper.Common;
using System;
using System.Net;
using Oracle.ManagedDataAccess.Client;
using System.Linq;

namespace dapperDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            string con = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=192.168.33.80)(PORT=1521)))(CONNECT_DATA=(sid =xe)));User Id=sj;Password=admin";

            SessionFactory.AddDataSource(new DataSource()
            {
                SourceType = DataSourceType.ORACLE,
                Source = () => new OracleConnection (con),
                UseProxy = true,
                Name = "test",
            });
            var session = SessionFactory.GetSession("test");

            session.From<PersonEntity>().Insert(new PersonEntity()
            {
                CarId = 1,
                CreateTime = DateTime.Now,
                IsActive = 1,
                PersonId = 2,
                PersonName = "测试",
                UpdateTime=DateTime.Now
            });

            var model = session.From<PersonEntity>().Where(x => x.PersonId == 2).Select().FirstOrDefault(); ;

            Console.WriteLine($"{nameof(model.PersonName)}:{model.PersonName}");
            Console.ReadLine();
        }
    }
}

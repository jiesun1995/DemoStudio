using Dapper.Common;
using System;
using System.Net;
using Oracle.ManagedDataAccess.Client;
using System.Linq;
using System.Data;
using Dapper;
using System.Collections.Generic;

namespace dapperDemo
{
    class Program
    {
        private readonly static string _stringConnection= "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=172.16.1.7)(PORT=1521)))(CONNECT_DATA=(SERVICE_NAME = sjzsk)));User Id=system;Password=manager;";
        static void Main(string[] args)
        {
            test2();
            Console.ReadLine();
        }
        private static void test2()
        {
            OracleDynamicParameters dynParams = new OracleDynamicParameters();
            dynParams.Add(":rslt1", OracleDbType.RefCursor, ParameterDirection.Output);
            dynParams.Add(":rslt2", OracleDbType.RefCursor, ParameterDirection.Output);
            using (IDbConnection dbConnection = new OracleConnection(_stringConnection))
            {
                var data = dbConnection.QueryMultiple(@"BEGIN OPEN :rslt1 FOR select * from dept_dict ;
            OPEN :rslt2 FOR select * from staff_dict; end;",dynParams);
            }
        }
        private static void test1(){
            string con = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=192.168.33.80)(PORT=1521)))(CONNECT_DATA=(sid =xe)));User Id=sj;Password=admin";

            SessionFactory.AddDataSource(new DataSource()
            {
                SourceType = DataSourceType.ORACLE,
                Source = () => new OracleConnection(con),
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
                UpdateTime = DateTime.Now
            });

            var model = session.From<PersonEntity>().Where(x => x.PersonId == 2).Select().FirstOrDefault();

            Console.WriteLine($"{nameof(model.PersonName)}:{model.PersonName}");
            Console.ReadLine();
        }
    }
    public class OracleDynamicParameters : SqlMapper.IDynamicParameters
    {
        private readonly DynamicParameters dynamicParameters = new DynamicParameters();

        private readonly List<OracleParameter> oracleParameters = new List<OracleParameter>();

        public void Add(string name, OracleDbType oracleDbType, ParameterDirection direction, object value = null, int? size = null)
        {
            OracleParameter oracleParameter;
            if (size.HasValue)
            {
                oracleParameter = new OracleParameter(name, oracleDbType, size.Value, value, direction);
            }
            else
            {
                oracleParameter = new OracleParameter(name, oracleDbType, value, direction);
            }

            oracleParameters.Add(oracleParameter);
        }

        public void Add(string name, OracleDbType oracleDbType, ParameterDirection direction)
        {
            var oracleParameter = new OracleParameter(name, oracleDbType, direction);
            oracleParameters.Add(oracleParameter);
        }

        public void AddParameters(IDbCommand command, SqlMapper.Identity identity)
        {
            ((SqlMapper.IDynamicParameters)dynamicParameters).AddParameters(command, identity);

            var oracleCommand = command as OracleCommand;

            if (oracleCommand != null)
            {
                oracleCommand.Parameters.AddRange(oracleParameters.ToArray());
            }
        }
    }
}

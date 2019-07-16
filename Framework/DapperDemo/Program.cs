using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Oracle.ManagedDataAccess.Client;
using Dapper;

namespace DapperDemo
{
    class Program
    {
        private static string str = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=10.10.128.103)(PORT=1521)))(CONNECT_DATA=(sid =hstest)));User Id=system;Password=manager";
        static void Main(string[] args)
        {
            string sql = @"select 
*
from COMM.V_GGH_CLINIC_MASTER t
 where 1 = 1
       and ZKE197 = :ZKE197 --医院个人管理码
       and ZKE999 is null --平台个人管理码
       and ZAE144 = :ZAE144 --就诊方式";
            IDbConnection con = new OracleConnection(str);
            var p = new DynamicParameters();
            p.Add(":ZKE197", "10044483");
            p.Add(":ZAE144", "1");
            using (var reader = con.ExecuteReader(sql, p))
            {
                DataTable dt = new DataTable();
                dt.Load(reader);
            }
           
            //Console.WriteLine(num.re()[0]);
            Console.ReadLine();
        }
    }
}

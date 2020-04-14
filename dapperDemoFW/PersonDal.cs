using DapperDal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dapperDemoFW
{
    /// <summary>
    /// 人员信息表数据访问类
    /// </summary>
    public class PersonDal : DalBase<PersonEntity, long>
    {
        public PersonDal() : base("DATABASE=Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=192.168.33.80)(PORT=1521)))(CONNECT_DATA=(sid =xe)));User Id=sj;Password=admin")
        {

        }
}
}

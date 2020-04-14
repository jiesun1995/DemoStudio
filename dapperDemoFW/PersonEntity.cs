using Dos.ORM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dapperDemoFW
{
    /// <summary>
    /// 人员信息表实体类
    /// </summary>
    public class PersonEntity:Entity
    {
        public long PersonId { get; set; }

        public string PersonName { get; set; }

        public int CarId { get; set; }

        public DateTime CreateTime { get; set; }

        public DateTime UpdateTime { get; set; }

        public short IsActive { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class School:Entity
    {        
        public override string Id { get => base.Id; set => base.Id = value; }
        public string Name { set; get; }
    }
}

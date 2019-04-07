using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoMapperDemo.Entity
{
    public class School
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public List<Teacher> Teachers {set;get;}
        public List<Student> Students { set; get; }
    }
}

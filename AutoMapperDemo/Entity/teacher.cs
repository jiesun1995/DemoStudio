using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoMapperDemo.Entity
{
    public class Teacher
    {
        public int Id { set; get; }
        public School School { set; get; }
        public string Name { get; set; }
        public List<Student> Students { set; get; }
    }
}

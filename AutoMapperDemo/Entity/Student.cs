using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoMapperDemo.Entity
{
    public class Student
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public int Age { set; get; }
        public School School { set; get; }
        public List<Teacher>  Teachers { set; get; }
    }
}

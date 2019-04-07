using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoMapperDemo.Entity.ViewModel
{
    public class ViewStudent
    {        
        public string Name { set; get; }
        public int Age { set; get; }
        public School School { set; get; }
        public List<ViewTeacher> Teachers { set; get; }
    }
}

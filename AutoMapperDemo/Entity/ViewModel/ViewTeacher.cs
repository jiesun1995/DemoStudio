using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoMapperDemo.Entity.ViewModel
{
    public class ViewTeacher
    {        
        public School School { set; get; }
        public string Name { get; set; }
        public List<ViewStudent> Students { set; get; }
    }
}

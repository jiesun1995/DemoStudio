using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoMapperDemo.Entity.ViewModel
{
    public class ViewSchool
    {        
        public string Name { set; get; }
        public List<ViewTeacher> Teachers { set; get; }
        public List<ViewStudent> Students { set; get; }
    }
}

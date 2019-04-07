using AutoMapper;
using AutoMapperDemo.Entity;
using AutoMapperDemo.Entity.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoMapperDemo
{
    public class AutoMapperProfileConfiguration : Profile
    {
        public AutoMapperProfileConfiguration()
        {
            CreateMap<School, ViewSchool>();
            CreateMap<Teacher, ViewTeacher>();
            //CreateMap<Student, ViewStudent>();
        }
    }
}

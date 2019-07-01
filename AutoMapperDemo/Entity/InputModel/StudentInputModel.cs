using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AutoMapperDemo.Entity.InputModel
{
    public class StudentInputModel
    {
        [Required(ErrorMessage ="Id 为空")]
        public string Id { set; get; }
    }
}
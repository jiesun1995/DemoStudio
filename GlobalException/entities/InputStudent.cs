using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GlobalException.entities
{
    public class InputStudent
    {
        [Required]
        public string Id { set; get; }
    }
}

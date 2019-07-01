using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapperDemo.Entity;
using AutoMapperDemo.Entity.InputModel;
using AutoMapperDemo.Entity.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace AutoMapperDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IMapper _mapper;

        public ValuesController(IMapper mapper)
        {
            _mapper = mapper;
        }

        //GET api/values
        [HttpGet]
        [Route("")]
        [ProducesResponseType(typeof(ViewSchool), 201)]
        public IActionResult Get()
        {
            var zhang = new Teacher()
            {
                Id = 1,
                Name = "zhang",
            };
            var xiaoming = new Student()
            {
                Id = 1,
                Name = "xiaoming",
                Age = 12,

            };
            var school = new School()
            {
                Id = 1,
                Name = "昆山小学",
                Students = new List<Student>() { xiaoming },
                Teachers = new List<Teacher>() { zhang },
            };
            var viewschool = _mapper.Map<ViewSchool>(school);

            return Ok(viewschool);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
        [HttpPost]
        [Route("Student")]
        public IActionResult Set(StudentInputModel input)
        {
            return new JsonResult(input);
        }
    }
}

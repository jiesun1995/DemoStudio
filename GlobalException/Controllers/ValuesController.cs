using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GlobalException.entities;
using GlobalException.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace GlobalException.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            throw new Exception("这是一个异常");
            //throw new PointException("这是一个异常");
            //return new string[] { "value1", "value2" };
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
        [HttpGet]
        [Route("Student")]
        public IActionResult Set(InputStudent input)
        {
            return new JsonResult(input);
        }
    }
}

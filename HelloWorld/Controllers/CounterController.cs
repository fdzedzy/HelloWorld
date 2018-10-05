using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HelloWorld.Models;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HelloWorld.Controllers
{
    [Route("api/[controller]")]
    public class CounterController : Controller
    {
        // GET: api/<controller>
        [HttpGet]
        public IActionResult Get()
        {
            return Json(new { CounterValue = Counter.CounterValue.ToString() });
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]string value)
        {
            if (value == "increase")
            {
                Counter.IncrementCounter();
            } else if (value == "decrease")
            {
                Counter.DecrementCounter();
            }
        }

        // PUT api/<controller>/5
        [HttpPut("{value}")]
        public void Put(int value)
        {
            Counter.CounterValue = value;
        }
    }
}

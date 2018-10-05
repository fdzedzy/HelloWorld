using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using App.Metrics;

namespace HelloWorld.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IMetrics _metrics;
        
        public ValuesController(IMetrics metrics)
        {
            _metrics = metrics;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            int delayedTime = 0;
            _metrics.Measure.Counter.Increment(MetricsRegistry.SampleCounter);
            using (_metrics.Measure.Timer.Time(MetricsRegistry.MyTimer))
            {
                delayedTime = Delay();
            }
            return new string[] { "Hello World!", "Delay time: " + delayedTime.ToString() + " milliseconds." };
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

        private int Delay()
        {
            Random random = new System.Random();
            int timeToDelay = random.Next(0, 100);
            Task.Delay(TimeSpan.FromMilliseconds(timeToDelay));
            return timeToDelay;
        }
    }
}

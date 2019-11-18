using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using UDPListener;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace F1TelemetryApplication.Controllers
{
    [Route("api/[controller]")]
    public class CarDataController : ControllerBase
    {
        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            Listener listener = new Listener(20777, 1289);
            var packettype = "F12017";

            listener.StartListener(packettype);

            return new string[] { "value1", "value2" };
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
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

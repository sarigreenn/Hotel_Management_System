using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using restFul.Entities;

namespace restFul.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuestController : Controller
    {
        private DataContex data;
        public GuestController(DataContex contex)
        {
            data = contex;
        }

        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<Guest> Get() => data.GuestList;


        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public ActionResult <Guest> Get(string id)
        {
            var x = data.GuestList.Find(x => x.Id == id);
            if (x == null)
            {
                return NotFound();
            }
            return x;
        }

        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] Guest value)
        {
            data.GuestList.Add(value);
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public ActionResult< Guest> Put(string id, [FromBody] Guest value)
        {
            var eve = data.GuestList.Find(e => e.Id == id);
            if (eve == null)
            {
                return NotFound();
            }           
            return eve;
        }
        [HttpPut("{id}/status")]
        public Guest Put(string id, [FromBody] string status)
        {
            //find the object by id
            var eve = data.GuestList.Find(e => e.Id == id);
            //udpate properties
            //eve.Title = updateEvent.Title;
            return eve;
        }
        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            var eve = data.GuestList.Find(e => e.Id == id);
            if (eve == null)
            {
                 NotFound();
            }
            data.GuestList.Remove(eve);
        }
    }
}

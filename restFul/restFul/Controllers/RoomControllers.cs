using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using restFul.Entities;

namespace restFul.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   
    public class RoomControllers : Controller
    {
        private DataContex data;
        public RoomControllers(DataContex contex)
        {
            data = contex;
        }


        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<Room> Get() => data.RoomList;


        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public ActionResult <Room>Get(string id)
        {
        
            var x = data.RoomList.Find(x => x.Id == id);
            if (x == null)
            {
                return NotFound();
            }
            return x;
        }

        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] Room value)
        {
            data.RoomList.Add(value);
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public ActionResult< Room> Put(string id, [FromBody] Room value)
        {
            var eve = data.RoomList.Find(e => e.Id == id);
            if (eve == null)
            {
                return NotFound();
            }
            eve.Available = value.Available;
            return eve;
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public  void Delete(string id)
        {
            var eve = data.RoomList.Find(e => e.Id == id);
            if (eve == null)
            {
                 NotFound();
            }
            data.RoomList.Remove(eve);
        }
    }
}

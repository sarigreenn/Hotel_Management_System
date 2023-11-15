using Microsoft.AspNetCore.Mvc;
using restFul.Entities;

namespace restFul.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class PackageController : Controller
    {
        private DataContex data;
        public PackageController(DataContex contex)
        {
            data = contex;
        }


        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<Package> Get() => data.PackageList;


        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public ActionResult<Package> Get(int id)
        {

            var x = data.PackageList.Find(x => x.Id == id);
            if (x == null)
            {
                return NotFound();
            }

            return x;
        }

        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] Package value)
        {
            data.PackageList.Add(value);
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public ActionResult<Package> Put(int id, [FromBody] Package value)
        {
            var package = data.PackageList.Find(e => e.Id == id);
            if (package == null)
            {
                return NotFound();
            }
           
            return package;
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var package = data.PackageList.Find(e => e.Id == id);
            if (package == null)
            {
                NotFound();
            }
            data.PackageList.Remove(package);
        }
    }
}

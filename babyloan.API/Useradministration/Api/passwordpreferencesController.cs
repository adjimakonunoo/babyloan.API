using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace babyloan.API.Useradministration.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class passwordpreferencesController : ControllerBase
    {
        // GET: api/passwordpreferences
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/passwordpreferences/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/passwordpreferences
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/passwordpreferences/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

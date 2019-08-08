using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using babyloan.API.infrastructure.fineract.commons;
using System.Net.Http;
using System.Text;
using System.Net.Http.Headers;
using System.Net;
using Newtonsoft.Json;
using System.IO;
using babyloan.API.infrastructure.fineract;

namespace babyloan.API.Accounting.Closures.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class GLClosuresController : ControllerBase
    {

        private readonly FineractClient _fineractClient;

        public GLClosuresController(FineractClient fineractClient)
        {
            _fineractClient = fineractClient;
        }
        // GET: api/GLClosures
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var response = await ApiService.ProcessRequest(_fineractClient, Request, "glclosures");
            string result = await response.Content.ReadAsStringAsync();
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return Ok(JsonConvert.DeserializeObject(result));

            }
            else if (response.StatusCode == HttpStatusCode.Unauthorized)
            {

                return Unauthorized(JsonConvert.DeserializeObject(result));
            }
            else if (response.StatusCode == HttpStatusCode.BadRequest)
            {

                return BadRequest(JsonConvert.DeserializeObject(result));
            }
            return NotFound(JsonConvert.DeserializeObject("{ \"timestamp\": 1565111721435,\"status\": 404,\"error\": \"Not Found\",\"message\": \"Not Found\",\"path\": \"" + _fineractClient.Client.BaseAddress + "glclosures" + "\"} "));

        }

        // GET: api/GLClosures/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/GLClosures
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/GLClosures/5
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

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
using Microsoft.Extensions.Primitives;

namespace babyloan.API.infrastructure.fineract.useradministration.api
{
    [Route("api/[controller]")]
    [ApiController]
    public class usersController : ControllerBase
    {
        private readonly FineractClient _fineractClient;

        public usersController(FineractClient fineractClient)
        {
            _fineractClient = fineractClient;
        }
        // GET: api/users
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            //reqTask.Wait();
            var _headers = Request.Headers;
            StringValues auth;
            _headers.TryGetValue("Authorization", out auth);
            System.Diagnostics.Debug.WriteLine(auth.ToString().Split(" ")[1]);
     

            
            var apiData = new Data<string, user>();
             apiData.method = "get";
             apiData.password = "password";
             apiData.user = "mifos";
             apiData.resource = "permissions";

            /*.tenant_id = "default";
           System.Diagnostics.Debug.WriteLine("user route");
           Api<string, user> finApi = new Api<string, user>( );*/

            // var s=  finApi.processRequest("ttt",apiData);
            //return new string[] { "value1", "value2" };
       
            var base64String = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{apiData.user}:{apiData.password}"));
            _fineractClient.Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", base64String);
            
            string result = await _fineractClient.Client.GetStringAsync(apiData.resource);
         
            return Ok(JsonConvert.DeserializeObject(result));
        }

        // GET: api/users/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/users
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/users/5
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

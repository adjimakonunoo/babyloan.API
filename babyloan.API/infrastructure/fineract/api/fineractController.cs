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
using System.IO;

namespace babyloan.API.infrastructure.fineract.api
{
    [Route("api/[controller]")]
    [ApiController]
    public class fineractController : ControllerBase
    {

        private readonly FineractClient _fineractClient;

        public fineractController(FineractClient fineractClient)
        {
            _fineractClient = fineractClient;
        }
        // GET: api/fineract
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult> Get([FromQuery] string resource)
        {
            //reqTask.Wait();
            
            var _headers = Request.Headers;
            StringValues auth;
            _headers.TryGetValue("Authorization", out auth);
          
           

           
          if(auth.Count() < 1)
            {
                return Unauthorized(JsonConvert.DeserializeObject("{ \"timestamp\": 1565111721435,\"status\": 401,\"error\": \"Unauthorized\",\"message\": \"Bad credentials\",\"path\": \"/fineract-provider/api/v1/glaccounts/1\"} "));
            }


            /*.tenant_id = "default";
           System.Diagnostics.Debug.WriteLine("user route");
           Api<string, user> finApi = new Api<string, user>( );*/

            // var s=  finApi.processRequest("ttt",apiData);
            //return new string[] { "value1", "value2" };

            //var base64String = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{apiData.user}:{apiData.password}"));
      
            _fineractClient.Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", auth.ToString().Split(" ")[1]);

            HttpResponseMessage response = await _fineractClient.Client.GetAsync(resource);
           
    
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                System.Diagnostics.Debug.WriteLine(content);
                return Ok(JsonConvert.DeserializeObject(content));
            }else if (response.StatusCode==HttpStatusCode.Unauthorized)
            {
                return Unauthorized(JsonConvert.DeserializeObject("{ \"timestamp\": 1565111721435,\"status\": 401,\"error\": \"Unauthorized\",\"message\": \"Bad credentials\",\"path\": \"" + _fineractClient.Client.BaseAddress + resource + "\"} "));
            }

            return  NotFound(JsonConvert.DeserializeObject("{}"));
        
    }

        // GET: api/fineract/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/fineract
        [HttpPost]
        public async Task<ActionResult> Post([FromQuery] string resource)
        {
            var body = "";

            var _headers = Request.Headers;
            StringValues auth;
            _headers.TryGetValue("Authorization", out auth);
            if (auth.Count() < 1)
            {
                return Unauthorized(JsonConvert.DeserializeObject("{ \"timestamp\": 1565111721435,\"status\": 401,\"error\": \"Unauthorized\",\"message\": \"Bad credentials\",\"path\": \"/fineract-provider/api/v1/glaccounts/1\"} "));
            }


            using (StreamReader reader = new StreamReader(Request.Body, Encoding.UTF8))
            {
             body=await reader.ReadToEndAsync();
            }

            //string content = JsonConvert.SerializeObject(da);
            var buffer = Encoding.UTF8.GetBytes(body);
            var byteContent = new ByteArrayContent(buffer);

            _fineractClient.Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", auth.ToString().Split(" ")[1]);
            var response = await _fineractClient.Client.PostAsync(resource,byteContent);
            string result = await response.Content.ReadAsStringAsync();
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return Ok(JsonConvert.DeserializeObject(result));

            } else if (response.StatusCode==HttpStatusCode.Unauthorized){

                return Unauthorized(JsonConvert.DeserializeObject(result));
            }
            else if (response.StatusCode == HttpStatusCode.BadRequest)
            {
               
                return BadRequest(JsonConvert.DeserializeObject(result));
            }
            return NotFound(JsonConvert.DeserializeObject("{ \"timestamp\": 1565111721435,\"status\": 404,\"error\": \"Not Found\",\"message\": \"Not Found\",\"path\": \"" + _fineractClient.Client.BaseAddress + resource + "\"} "));
           
        }

        // PUT: api/fineract/5
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

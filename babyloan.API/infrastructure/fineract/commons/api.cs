using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http.Headers;


namespace babyloan.API.infrastructure.fineract.commons
{
    public class Api<t,r>
    {

        ///static HttpClient Client = new HttpClient();
        private readonly IHttpClientFactory _clientFactory;

 

        public  async Task<string> processRequest(string url,Data<t,r> requestData)

        {
            //var base_url = "https://localhost:8443/fineract-provider/api/v1";

          
            var base64String = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{requestData.user}:{requestData.password}"));
            HttpRequestMessage request;
            HttpResponseMessage response=null;
            
            var client = _clientFactory.CreateClient("fineract");
            System.Diagnostics.Debug.WriteLine("step one");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", base64String);
           
            switch (requestData.method.ToLower())
            {

                case "get":
                    System.Diagnostics.Debug.WriteLine("step two");
                    request = new HttpRequestMessage(HttpMethod.Get, requestData.resource);
                    response = await client.SendAsync(request);
                    break;
                case "post":
                    request = new HttpRequestMessage(HttpMethod.Post, requestData.resource);
                    break;
                case "put":
                    request = new HttpRequestMessage(HttpMethod.Put, requestData.resource);
                    break;
            }

   


         

            System.Diagnostics.Debug.WriteLine("three");



            
            System.Diagnostics.Debug.WriteLine("four");
            //stafflist objstafflist = new stafflist();
          
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                System.Diagnostics.Debug.WriteLine(content);
              //var data = JsonConvert.DeserializeObject<r>(content);

                System.Diagnostics.Debug.WriteLine("is good");
                return content;
            }
            else
            {

               
                return null;
            }
        }

        }
    }

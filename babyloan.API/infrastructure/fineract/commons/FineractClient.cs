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
using System.Net;

namespace babyloan.API.infrastructure.fineract.commons
{
    public class FineractClient
    {
        public HttpClient Client { get; private set; }

        public FineractClient(HttpClient httpClient)
        {

     
           //httpClient.BaseAddress = new Uri("https://10.10.30.62:443/fineract-provider/api/v1/");
           httpClient.BaseAddress = new Uri("https://localhost:8443/fineract-provider/api/v1/");
            httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
            httpClient.DefaultRequestHeaders.Add("Fineract-Platform-TenantId", "Default");
          
            Client = httpClient;
        }
    }
}

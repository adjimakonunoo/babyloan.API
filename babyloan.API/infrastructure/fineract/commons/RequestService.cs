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
    public class RequestService
    {


        static HttpClient Client = new HttpClient();

        public static  async Task<string> getApi(string url)
         
        {
            System.Diagnostics.Debug.WriteLine("step two");

          
            var uri = new Uri(string.Format(url, string.Empty));
            Client.DefaultRequestHeaders.Clear();
            Client.DefaultRequestHeaders.Accept.Clear();
            var user = "mifos";
            var password = "password";
           var base64String = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{user}:{password}"));
      
           
            Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", base64String);
            Client.DefaultRequestHeaders.Accept.Add( new MediaTypeWithQualityHeaderValue("application/json"));
            
            Client.DefaultRequestHeaders.Add("Fineract-Platform-TenantId", "default");

   
              System.Diagnostics.Debug.WriteLine("three");
           
   
            
            HttpResponseMessage response = await Client.GetAsync(uri).ConfigureAwait(false);
            System.Diagnostics.Debug.WriteLine("four");
            //stafflist objstafflist = new stafflist();
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                System.Diagnostics.Debug.WriteLine(content);
               // data = JsonConvert.DeserializeObject<T>(content);
              
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
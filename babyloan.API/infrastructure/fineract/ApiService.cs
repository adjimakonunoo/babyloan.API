using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using babyloan.API.infrastructure.fineract.commons;
using System.Net.Http;
using System.Text;
using System.Net.Http.Headers;
using Microsoft.Extensions.Primitives;
using System.IO;

namespace babyloan.API.infrastructure.fineract
{
    public class ApiService
    {
        public static async Task<HttpResponseMessage> ProcessRequest(FineractClient _fineractClient, HttpRequest request)
        {
            var _headers = request.Headers;
            var queryParam = request.QueryString.ToString();
            var _resource = request.Path.ToString().Substring(5) + queryParam;
            string strAuth = "";
            StringValues auth;
            _headers.TryGetValue("Authorization", out auth);

            if (auth.Count() < 1)
            {
                strAuth = "";

            }
            else
            {

                strAuth = auth.ToString().Split(" ")[1];
            }
            HttpResponseMessage response = null;
            switch (request.Method.ToLower())
            {
                case "get":

                    _fineractClient.Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", strAuth);

                    response = await _fineractClient.Client.GetAsync(_resource);
                    return response;

                case "post":
                    var body = "";
                    using (StreamReader reader = new StreamReader(request.Body, Encoding.UTF8))
                    {
                        body = await reader.ReadToEndAsync();
                    }

                    //string content = JsonConvert.SerializeObject(da);
                    var buffer = Encoding.UTF8.GetBytes(body);
                    var byteContent = new ByteArrayContent(buffer);

                    _fineractClient.Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", auth.ToString().Split(" ")[1]);
                    response = await _fineractClient.Client.PostAsync(_resource, byteContent);
                    return response;

                case "put":

                    _fineractClient.Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", strAuth);

                    response = await _fineractClient.Client.GetAsync(_resource);
                    return response;

            }


            return response;
            ;
        }
    }
}
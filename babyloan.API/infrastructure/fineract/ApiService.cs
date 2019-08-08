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

namespace babyloan.API.infrastructure.fineract
{
    public class ApiService
    {
       public static async Task<HttpResponseMessage> ProcessRequest(FineractClient  _fineractClient,HttpRequest request,string resource)
        {
            var _headers = request.Headers;
            var queryParam = request.QueryString;
            StringValues auth;
            _headers.TryGetValue("Authorization", out auth);
            HttpResponseMessage response = null;
            switch (request.Method.ToLower())
            {
                case "get":
                    _fineractClient.Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", auth.ToString().Split(" ")[1]);

                   response = await _fineractClient.Client.GetAsync(resource);
                    return response;
                    break;
                case "post":
                    break;
                case "put":
                    break;

            }


            return response;
           ;
        }
    }
}

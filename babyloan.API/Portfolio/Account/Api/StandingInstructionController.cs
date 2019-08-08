﻿using System;
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

namespace babyloan.API.Portfolio.Account.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class StandingInstructionController : ControllerBase
    {
        private readonly FineractClient _fineractClient;

        public StandingInstructionController(FineractClient fineractClient)
        {
            _fineractClient = fineractClient;
        }

        // GET: api/StandingInstruction
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/StandingInstruction/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/StandingInstruction
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/StandingInstruction/5
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

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace NL.Order.WebApi.Controllers
{
    public class MenuController : ApiController
    {
        // GET: api/Menu
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Menu/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Menu
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Menu/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Menu/5
        public void Delete(int id)
        {
        }
    }
}

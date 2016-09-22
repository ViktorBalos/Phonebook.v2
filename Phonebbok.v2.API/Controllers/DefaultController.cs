using Newtonsoft.Json;
using Phonebook.v2.DataAccess.UnitOfWork;
using Phonebook.V2.Data;
using Phonebook.V2.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;

namespace Phonebbok.v2.API.Controllers
{
    public class DefaultController : ApiController
    {
        // GET: api/Default
        [HttpGet]
        public string Get()
        {
            string[] retVal = new string[] { "value1", "value2" };
            //var data = new UnitOfWork(new PhonebookContext()).ContactRepository.Get();
            Country data = new Country()
            {
                ID = 123,
                CountryName = "Srbija",
                Cities = null
            };
            Country data2 = new Country()
            {
                ID = 124,
                CountryName = "Srbijaaaa",
                Cities = null
            };
            List<Country> list = new List<Country>();
            list.Add(data);
            list.Add(data2);
            var json = JsonConvert.SerializeObject(list);
            return json;
        }

        // GET: api/Default/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Default
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Default/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Default/5
        public void Delete(int id)
        {
        }
    }
}

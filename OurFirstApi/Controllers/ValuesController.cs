using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using OurFirstApi.Models;

namespace OurFirstApi.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int randomNumber)
        {
            return "value";
        }

        // POST api/values
        public HttpResponseMessage Post(EmployeeListResult employee)
        {
            Console.WriteLine($"{employee.FirstName} {employee.LastName}");

            return Request.CreateResponse(HttpStatusCode.Created);
        }

        // PUT api/values/5
        public HttpResponseMessage Put(int id, EmployeeListResult employee)
        {
            Console.WriteLine($"{employee.FirstName} {employee.LastName}");

            return Request.CreateResponse(HttpStatusCode.Accepted);
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
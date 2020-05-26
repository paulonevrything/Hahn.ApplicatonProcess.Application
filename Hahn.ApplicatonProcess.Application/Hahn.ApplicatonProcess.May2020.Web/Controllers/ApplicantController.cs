using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Hahn.ApplicatonProcess.May2020.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Swashbuckle.AspNetCore.Filters;

namespace Hahn.ApplicatonProcess.May2020.Web.Controllers
{
    [ApiVersion("1")]
    [Route("api/[controller]/v{version:apiVersion}")]
    [ApiController]
    public class ApplicantController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        [HttpPost]
        [Route("create-applicant")]
        [SwaggerRequestExample(typeof(ApplicantModel), typeof(ApplicantModelExample))]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(ApplicantModel), Description = "Delivery options for the country found and returned successfully")]
        [SwaggerResponseExample((int)HttpStatusCode.OK, typeof(ApplicantModel))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Type = typeof(ApplicantModel), Description = "An invalid or missing input parameter will result in a bad request")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Type = typeof(ApplicantModel), Description = "An unexpected error occurred, should not return sensitive information")]
        public void Post([FromBody] ApplicantModel applicant)
        {

        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

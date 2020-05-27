using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Hahn.ApplicatonProcess.May2020.Data.DataAccess;
using Hahn.ApplicatonProcess.May2020.Data.Entities;
using Hahn.ApplicatonProcess.May2020.Domain.Models;
using Hahn.ApplicatonProcess.May2020.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Swashbuckle.AspNetCore.Annotations;
using Swashbuckle.AspNetCore.Filters;
using FluentValidation.Results;
using Microsoft.Extensions.Logging;

namespace Hahn.ApplicatonProcess.May2020.Web.Controllers
{
    [ApiVersion("1")]
    [Route("api/[controller]/v{version:apiVersion}")]
    [ApiController]
    public class ApplicantController : ControllerBase
    {
        private readonly IApplicantService _applicantService;
        private readonly IConfiguration _configuration;
        private readonly ILogger _logger;
        public ApplicantController(IApplicantService applicantService, IConfiguration configuration, ILogger<ApplicantController> logger)
        {
            _applicantService = applicantService;
            _configuration = configuration;
            _logger = logger;
        }


        [HttpPost]
        [Route("create-applicant")]
        [SwaggerRequestExample(typeof(ApplicantModel), typeof(ApplicantModelExample))]
        [SwaggerResponseExample((int)HttpStatusCode.Created, typeof(ApplicantModel))]
        [SwaggerResponse((int)HttpStatusCode.Created, Type = typeof(ApplicantModel), Description = "Applicant has been created successfully")]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Description = "An invalid or missing input parameter will result in a bad request")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "An unexpected error occurred, should not return sensitive information")]
        public IActionResult Post([FromBody] ApplicantModel applicant)
        {
            _logger.LogInformation("Start : Getting item details for {ID}", applicant);

            ApplicantModelValidator validationRules = new ApplicantModelValidator(_configuration);

            ValidationResult result = validationRules.Validate(applicant);

            if (!result.IsValid)
            {
                foreach(ValidationFailure validationFailure in result.Errors)
                {
                    ModelState.AddModelError(validationFailure.PropertyName, validationFailure.ErrorMessage);
                }

                return BadRequest(ModelState);
            }
            return Ok(_applicantService.CreateApplicant(applicant));
        }

        [HttpGet("{id}")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(ApplicantModel), Description = "Applicant {id} is found and returned successfully")]
        [SwaggerResponse((int)HttpStatusCode.NotFound, Type = typeof(ApplicantModel), Description = "Applicant {id} is not found in the record")]
        public IActionResult Get(int id)
        {
            return Ok(_applicantService.GetApplicantById(id));
        }

        [HttpGet]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(List<ApplicantModel>), Description = "Applicants are found and returned successfully")]
        public IActionResult Get()
        {
            return Ok(_applicantService.GetAllApplicant());
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, ApplicantModel applicant)
        {
            ApplicantModelValidator validationRules = new ApplicantModelValidator(_configuration);

            ValidationResult result = validationRules.Validate(applicant);

            if (!result.IsValid)
            {
                foreach (ValidationFailure validationFailure in result.Errors)
                {
                    ModelState.AddModelError(validationFailure.PropertyName, validationFailure.ErrorMessage);
                }
            }
            return Ok(_applicantService.UpdtateApplicantById(id, applicant));
        }

        [HttpDelete("{id}")]
        [SwaggerResponse((int)HttpStatusCode.NotFound, Type = typeof(ApplicantModel), Description = "Applicant {id} is not found in the record")]
        public IActionResult Delete(int id)
        {
            return Ok(_applicantService.DeleteApplicantById(id));
        }
    }
}

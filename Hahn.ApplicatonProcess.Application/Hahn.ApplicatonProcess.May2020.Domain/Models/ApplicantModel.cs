using FluentValidation;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using RestSharp;
using System.Configuration;
using Microsoft.Extensions.Configuration;
using Hahn.ApplicatonProcess.May2020.Data.Entities;

namespace Hahn.ApplicatonProcess.May2020.Domain.Models
{
    public class ApplicantModelValidator : AbstractValidator<ApplicantModel>
    {
        public IConfiguration Configuration { get; }

        public ApplicantModelValidator(IConfiguration configuration)
        {
            Configuration = configuration;

            RuleFor(x => x.Hired).NotNull().WithMessage("Applicant hired status must not be null");
            RuleFor(x => x.Name).MinimumLength(5).WithMessage("Applicant Name must not be less than 5 characters");
            RuleFor(x => x.FamilyName).MinimumLength(5).WithMessage("Applicant FamilyName must not be less than 5 characters");
            RuleFor(x => x.EMailAdress).EmailAddress().WithMessage("Please provide a valid EmailAddress");
            RuleFor(x => x.Age).InclusiveBetween(20, 60).WithMessage("Applicant Age must be between 20 and 60");
            RuleFor(x => x.Address).MinimumLength(10).WithMessage("Applicant Address must not be less than 10 characters");
            RuleFor(x => x.CountryOfOrigin).Must(countryFullName => CountryIsValid(countryFullName))
                .WithMessage("The applicant's country is not a valid country");
        }

        private bool CountryIsValid(string countryFulName)
        {
            string baseUrl = Configuration.GetSection("RestCountryBaseUrl").Value;

            var client = new RestClient(baseUrl + $"{countryFulName}?fullText=true");

            var request = new RestRequest();

            var response = client.Get(request);

            var customerDto = JsonConvert.DeserializeObject<InvalidCountryDTO>(response.Content);
            
            if(customerDto.status == null)
            {
                return true;
            }
            return false;
        }
    }

    public class InvalidCountryDTO
    {
        public string status { get; set; }
        public string message { get; set; }
    }
}

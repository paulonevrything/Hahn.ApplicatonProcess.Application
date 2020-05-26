using Swashbuckle.AspNetCore.Filters;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hahn.ApplicatonProcess.May2020.Domain.Models
{
    public class ApplicantModelExample : IExamplesProvider<ApplicantModel>
    {
        public ApplicantModel GetExamples()
        {
            return new ApplicantModel
            {
                Name = "Paul",
                FamilyName = "Olabisi",
                Address = "1 Gwalior Road, London, GB, SW15 1NP",
                CountryOfOrigin = "Nigeria",
                EMailAdress = "pauloolabisi@gmail.com",
                Age = 27,
                Hired = true
            };
        }
    }
}

using Hahn.ApplicatonProcess.May2020.Data.Entities;
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
                Name = "Paulo",
                FamilyName = "Olabisi",
                Address = "1 Joseph Lambo Street, Ebute Metta, Lagos",
                CountryOfOrigin = "Nigeria",
                EMailAdress = "pauloolabisi@gmail.com",
                Age = 27,
                Hired = true
            };
        }
    }
}

using Hahn.ApplicatonProcess.May2020.Data.Entities;
using Hahn.ApplicatonProcess.May2020.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hahn.ApplicatonProcess.May2020.Domain.Services
{
    public interface IApplicantService
    {
        Response CreateApplicant(ApplicantModel applicant);
        Response GetApplicantById(int id);
        Response GetAllApplicant();
        Response UpdtateApplicantById(int id, ApplicantModel applicant);
        Response DeleteApplicantById(int id);

    }
}

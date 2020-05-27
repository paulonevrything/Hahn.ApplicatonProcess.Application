using Hahn.ApplicatonProcess.May2020.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hahn.ApplicatonProcess.May2020.Data.DataAccess
{
    public interface IApplicantRepository : IDisposable
    {
        IEnumerable<ApplicantModel> GetApplicants();
        ApplicantModel GetApplicantByID(int applicantId);
        void InsertApplicant(ApplicantModel applicant);
        void DeleteApplicant(int applicantId);
        void UpdateApplicant(ApplicantModel applicant);
        void Save();
    }
}

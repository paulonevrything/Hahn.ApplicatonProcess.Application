using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Data;
using Microsoft.EntityFrameworkCore;
using Hahn.ApplicatonProcess.May2020.Data.Entities;

namespace Hahn.ApplicatonProcess.May2020.Data.DataAccess
{
    public class ApplicantRepository : IApplicantRepository, IDisposable
    {
        private ApplicantContext context;

        public ApplicantRepository(ApplicantContext context)
        {
            this.context = context;
        }

        public IEnumerable<ApplicantModel> GetApplicants()
        {
            return context.Applicants.ToList();
        }

        public ApplicantModel GetApplicantByID(int id)
        {
            return context.Applicants.Find(id);
        }

        public void InsertApplicant(ApplicantModel applicant)
        {
            context.Applicants.Add(applicant);
        }

        public void DeleteApplicant(int applicantID)
        {
            ApplicantModel applicant = context.Applicants.Find(applicantID);
            context.Applicants.Remove(applicant);
        }

        public void UpdateApplicant(ApplicantModel applicant)
        {
            context.Entry(applicant).State = EntityState.Modified;
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}

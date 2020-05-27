using Hahn.ApplicatonProcess.May2020.Domain.Models;
using Hahn.ApplicatonProcess.May2020.Data.DataAccess;
using Hahn.ApplicatonProcess.May2020.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Hahn.ApplicatonProcess.May2020.Domain.Utils;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;

namespace Hahn.ApplicatonProcess.May2020.Domain.Services
{
    public class ApplicantService : IApplicantService
    {
        private readonly ApplicantContext _context;
        private readonly IApplicantRepository _applicantRepository;
        private readonly Utilities _utilities;
        public ApplicantService(ApplicantContext context, ILogger<ApplicantService> logger, IConfiguration configuration,
            IApplicantRepository applicantRepository)
        {
            _context = context;
            _utilities = new Utilities(logger, configuration);
            _applicantRepository = applicantRepository;
        }
        public Response CreateApplicant(ApplicantModel applicant)
        {
            Response response = _utilities.InitializeResponse();
            _applicantRepository.InsertApplicant(applicant);
            _applicantRepository.Save();

            response.Data = applicant;
            return response;
        }

        public Response DeleteApplicantById(int id)
        {
            Response response = _utilities.InitializeResponse();
            var applicant = _applicantRepository.GetApplicantByID(id);

            if(applicant == null)
            {
                return _utilities.UnsuccessfulResponse(response, "Invalid id supplied. Could not match applicant to id");
            }

            _applicantRepository.DeleteApplicant(id);
            _applicantRepository.Save();

            response.Data = applicant;
            return response;
        }

        public Response GetAllApplicant()
        {
            Response response = _utilities.InitializeResponse();

            response.Data = _applicantRepository.GetApplicants();

            return response;
        }

        public Response GetApplicantById(int id)
        {
            Response response = _utilities.InitializeResponse();
            var applicant = _applicantRepository.GetApplicantByID(id);

            if (applicant == null)
            {
                return _utilities.UnsuccessfulResponse(response, "Invalid id supplied. Could not match applicant to id");
            }

            response.Data = applicant;
            return response;
        }

        public Response UpdtateApplicantById(int id, ApplicantModel applicant)
        {
            Response response = _utilities.InitializeResponse();
            var applicantFound = _applicantRepository.GetApplicantByID(id);

            if (applicantFound == null)
            {
                return _utilities.UnsuccessfulResponse(response, "Invalid id supplied. Could not match applicant to id");
            }

            // Update and save changes
            _applicantRepository.UpdateApplicant(applicant);
            _applicantRepository.Save();

            response.Data = _applicantRepository.GetApplicantByID(id);

            return response;
        }
    }
}

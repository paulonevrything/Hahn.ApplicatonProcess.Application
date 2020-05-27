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
        private readonly IApplicantRepository _applicantRepository;
        private readonly Utilities _utilities;
        private readonly IConfiguration _configuration;
        private readonly ILogger _logger;
        public ApplicantService(ILogger<ApplicantService> logger, IConfiguration configuration,
            IApplicantRepository applicantRepository)
        {
            _utilities = new Utilities(logger, configuration);
            _applicantRepository = applicantRepository;
            _configuration = configuration;
            _logger = logger;
        }
        public Response CreateApplicant(ApplicantModel applicant)
        {
            _logger.LogInformation("Request Made to CreateApplicant: ", applicant.ToString());
            Response response = _utilities.InitializeResponse();

            try
            {
                _applicantRepository.InsertApplicant(applicant);
                _applicantRepository.Save();
            }
            catch (Exception ex)
            {
                return _utilities.CatchException(ex, response);
            }

            var applicantUrl = _configuration.GetSection("AppBaseUrl").Value;

            response.Data = applicantUrl + applicant.ID;

            _logger.LogInformation($"Successfully created applicant {applicant.ID}");
            return response;
        }

        public Response DeleteApplicantById(int id)
        {
            Response response = _utilities.InitializeResponse();
            var applicant = _applicantRepository.GetApplicantByID(id);

            if (applicant == null)
            {
                return _utilities.UnsuccessfulResponse(response, "Invalid id supplied. Could not match applicant to id");
            }

            _applicantRepository.DeleteApplicant(id);
            _applicantRepository.Save();
            _logger.LogInformation($"Successfully deleted applicant {id}");

            return response;
        }

        public Response GetAllApplicant()
        {
            _logger.LogInformation($"Retrieving all applicants...");

            Response response = _utilities.InitializeResponse();

            response.Data = _applicantRepository.GetApplicants();

            return response;
        }

        public Response GetApplicantById(int id)
        {
            _logger.LogInformation($"Retrieving applicants {id}");
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
            try
            {
                // Update and save changes
                _applicantRepository.UpdateApplicant(applicant);
                _applicantRepository.Save();
            }
            catch (Exception ex)
            {
                return _utilities.CatchException(ex, response);
            }
            
            response.Data = _applicantRepository.GetApplicantByID(id);

            _logger.LogInformation($"Successfully updated {id}");

            return response;
        }
    }
}

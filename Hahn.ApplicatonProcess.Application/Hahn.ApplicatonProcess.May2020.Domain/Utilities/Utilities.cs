using Hahn.ApplicatonProcess.May2020.Domain.Models;
using Hahn.ApplicatonProcess.May2020.Domain.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hahn.ApplicatonProcess.May2020.Domain.Utils
{
    public class Utilities
    {
        private ILogger<ApplicantService> logger;
        private IConfiguration configuration;

        public Utilities(ILogger<ApplicantService> logger, IConfiguration configuration)
        {
            this.logger = logger;
            this.configuration = configuration;
        }

        public Response InitializeResponse()
        {
            Response response = new Response();
            string requestId = String.Format("{0}_{1:N}", "", Guid.NewGuid());
            response.RequestId = requestId;
            response.ResponseCode = "00";
            response.ResponseMessage = "Successful";
            return response;
        }
        public Response UnsuccessfulResponse(Response response, string message, string data = null)
        {
            response.ResponseCode = "02";
            response.ResponseMessage = message;
            response.Data = data;

            logger.LogInformation($"REQUEST => {Environment.NewLine}" +
                                       $"RESPONSE => {response.Data} {response.ResponseMessage}");

            return response;
        }

        public Response CatchException(Exception ex, Response response, string v)
        {
            response.ResponseCode = "99";
            response.ResponseMessage = "Error occurred while processing your request";
            logger.LogError($"{ex.Message} REQUEST BODY =>  REQUEST ID => {response.RequestId}");
            return response;
        }
    }
}

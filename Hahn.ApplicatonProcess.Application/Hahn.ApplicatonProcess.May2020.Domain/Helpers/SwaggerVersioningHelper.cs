using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hahn.ApplicatonProcess.May2020.Domain.Helpers
{
    public class RemoveVersionFromParameter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            var versionParameter = operation.Parameters.Single(p => p.Name == "version");
            operation.Parameters.Remove(versionParameter);
        }
    }

    public class ReplaceVersionWithExactValueInPath : IDocumentFilter
    {

        public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
        {
            var oap = new OpenApiPaths();
            foreach (var p in swaggerDoc.Paths)
                oap.Add(p.Key.Replace("v{version}", swaggerDoc.Info.Version),
                    p.Value);
            swaggerDoc.Paths = oap;
        }
    }
}

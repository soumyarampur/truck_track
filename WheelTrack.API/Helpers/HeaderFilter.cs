﻿using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace WheelTrack.API.Helpers
{
    public class HeaderFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            if (operation.Parameters == null)
                operation.Parameters = new List<OpenApiParameter>();

            operation.Parameters.Add(new OpenApiParameter
            {
                Name = "org",
                In = ParameterLocation.Header,
                Schema = new OpenApiSchema { Type = "integer" },
                Required = true
            });
            operation.Parameters.Add(new OpenApiParameter
            {
                Name = "user",
                In = ParameterLocation.Header,
                Schema = new OpenApiSchema { Type = "integer" },
                Required = true
            });
            operation.Parameters.Add(new OpenApiParameter
            {
                Name = "instance_code",
                In = ParameterLocation.Header,
                Schema = new OpenApiSchema { Type = "string" },
                Required = true
            });
        }
    }
}

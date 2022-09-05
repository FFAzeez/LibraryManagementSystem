using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.IO;

namespace LibraryManagementAPI.Extentions
{
    public static class SwaggerConfiguration
    {
        public static void AddSwaggerWithApiKeySecurity(this IServiceCollection services,
            IConfiguration configuration, string assemblyName)
        {
            var apiKeyConfiguration = configuration["ApiKeyString:ApiKey"];

            services.AddSwaggerGen(c =>
            {
                const string securityDefinition = "ApiKey";
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "LibraryManagementAPI",
                    Version = "v1"
                });

                c.AddSecurityDefinition(securityDefinition, new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Name = securityDefinition,
                    Type = SecuritySchemeType.ApiKey
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Name = apiKeyConfiguration,
                            Type = SecuritySchemeType.ApiKey,
                            In = ParameterLocation.Header,
                            Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = securityDefinition }
                        },
                        new List<string>()
                    }
                });

                var xmlFile = $"{assemblyName}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
        }
    }
}

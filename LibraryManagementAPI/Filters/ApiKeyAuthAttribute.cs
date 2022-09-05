using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace LibraryManagementAPI.Filters
{
    [AttributeUsage(AttributeTargets.Class| AttributeTargets.Method )]
    public class ApiKeyAuthAttribute : Attribute, IAsyncActionFilter
    {
        private const string ApiKeyName = "ApiKey";
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if(!context.HttpContext.Request.Headers.TryGetValue(ApiKeyName,out var getApiKey))
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            // get the secret key to compare it with the one be passed to the controller
            var appSettings = context.HttpContext.RequestServices.GetRequiredService<IConfiguration>();
            var apiKey = appSettings.GetValue<string>("ApiKeyString:ApiKey");
            if (!apiKey.Equals(getApiKey))
            {
                context.Result = new UnauthorizedResult();
            }

            await next();
        }
    }
}

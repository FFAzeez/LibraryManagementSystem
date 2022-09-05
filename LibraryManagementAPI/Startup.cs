using LibraryManagementAPI.Extentions;
using LibraryManagementAPI.Middleware;
using LibraryManagementCore.Mapping;
using LibraryManagementCore.Services;
using LibraryManagementCore.Services.Interface;
using LibraryManagementInfrastructure.Context;
using LibraryManagementInfrastructure.Repositories;
using LibraryManagementInfrastructure.Repositories.Interface;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System.Reflection;

namespace LibraryManagementAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddDIConfiguration();
            services.AddDbContext<LMDbContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("DbCon")));
            services.AddIdentityConfiguration();
            services.AddControllers();
            services.AddSwaggerWithApiKeySecurity(Configuration, $"{Assembly.GetExecutingAssembly().GetName().Name}");
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "LibraryManagementAPI v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseMiddleware<ErrorHandlerMiddleware>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

    }
}

using LibraryManagementCore.Mapping;
using LibraryManagementCore.Services;
using LibraryManagementCore.Services.Interface;
using LibraryManagementInfrastructure.Repositories;
using LibraryManagementInfrastructure.Repositories.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace LibraryManagementAPI.Extentions
{
    public static class DIConfigure
    {
        public static void AddDIConfiguration(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IBookServices, BookServices>();
            services.AddScoped<IClientServices, ClientServices>();
            services.AddScoped<ICustomerServices, CustomerServices>();
            services.AddAutoMapper(typeof(LibraryMapping));
        }
    }
}

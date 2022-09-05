using LibraryManagementInfrastructure.Context;
using LibraryManagementInfrastructure.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace LibraryManagementAPI.Extentions
{
    public static class IdentityConfiguration
    {
        public static void AddIdentityConfiguration(this IServiceCollection services)
        {
            services.AddIdentity<Customer, IdentityRole>()
              .AddEntityFrameworkStores<LMDbContext>()
              .AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options =>
            {
                options.User.RequireUniqueEmail = true;
                options.Password.RequiredLength = 7;
            }); 
        }
    }
}

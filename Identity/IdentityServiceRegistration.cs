using Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Identity
{
    public static class IdentityServiceRegistration
    {
        public static IServiceCollection AddIdentityService(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<AppIdentityDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("IdentityConnectionString"));
            });

            services.AddIdentity<AppUser,IdentityRole>()
                .AddEntityFrameworkStores<AppIdentityDbContext>()
                .AddDefaultTokenProviders();


            return services;
        }
    }
}

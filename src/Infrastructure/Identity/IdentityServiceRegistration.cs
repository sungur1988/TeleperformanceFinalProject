using Application.Contracts.Identities;
using Application.Models;
using Identity.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
namespace Identity
{
    public static class IdentityServiceRegistration
    {

        public static IServiceCollection AddIdentityService(this IServiceCollection services,IConfiguration configuration)
        {
            services.Configure<CustomJwtSettings>(configuration.GetSection("CustomJwtSettings"));

            services.AddDbContext<AppIdentityDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("IdentityConnectionString"));
            });

            services.AddIdentity<AppUser, IdentityRole>(options =>
            {
                options.User.RequireUniqueEmail = true;
            })
                .AddEntityFrameworkStores<AppIdentityDbContext>()
                .AddDefaultTokenProviders();

            services.AddScoped<ITokenService, JwtTokenService>();
            services.AddScoped<IUserService,UserService>();
            services.AddScoped<IAuthService, AuthService>();

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(o =>
                 {
                     var tokenOptions = configuration.GetSection("CustomJwtSettings").Get<CustomJwtSettings>();
                     o.TokenValidationParameters = new TokenValidationParameters
                     {
                         ValidateIssuerSigningKey = true,
                         ValidateIssuer = true,
                         ValidateAudience = true,
                         ValidateLifetime = true,
                         ClockSkew = TimeSpan.Zero,
                         ValidIssuer = tokenOptions.Issuer,//configuration["CustomJwtSettings:Issuer"],
                         ValidAudience = tokenOptions.Audience,//configuration["CustomJwtSettings:Audience"],
                         IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenOptions.Key))
                     };
                 });
            return services;
        }
    }
}

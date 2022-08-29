using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using UserManagementSystemAPI.Contracts.Repository;
using UserManagementSystemAPI.Contracts.Services;
using UserManagementSystemAPI.DataLayer;
using UserManagementSystemAPI.Middleware;
using UserManagementSystemAPI.Repositories;
using UserManagementSystemAPI.Services.Services;

namespace UserManagementSystemAPI.Extensions
{
    /// <summary>
    /// ServiceExtensions
    /// </summary>
    public static class ServiceExtensions
    {
        /// <summary>
        /// ConfigureMySqlContext
        /// </summary>
        /// <param name="services"></param>
        /// <param name="config"></param>
        public static void ConfigureMySqlContext(this IServiceCollection services, IConfiguration config)
        {
            var connectionString = config["ConnectionString:MySqlConnection"];
            var serverVersion = new MySqlServerVersion(new Version(5, 7, 30));


            services.AddDbContext<RepositoryDbContext>(options =>
                           options.UseMySql(connectionString, serverVersion));
        }
        /// <summary>
        /// Middleware configuration
        /// </summary>
        /// <param name="services"></param>
        /// <param name="config"></param>
        public static void ConfigureMiddleware(this IServiceCollection services, IConfiguration config)
        {
            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
           .AddJwtBearer(options =>
           {
               options.TokenValidationParameters = new TokenValidationParameters
               {
                   ValidateIssuer = true,
                   ValidateAudience = true,
                   ValidateLifetime = true,
                   ValidateIssuerSigningKey = true,
               // set clockskew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
               ClockSkew = TimeSpan.Zero,
                   ValidIssuer = "http://localhost:44387",
                   ValidAudience = "http://localhost:44387",
                   IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII
                          .GetBytes(config.GetSection("JwtToken:Key").Value)),
               };
           });
            services.AddTransient<ExceptionHandlingMiddleware>();
        }
        /// <summary>
        /// Configure Repository Manager
        /// </summary>
        /// <param name="services"></param>
        public static void ConfigureRepositoryManager(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryManager, RepositoryManager>();
        }
        /// <summary>
        /// Configure Services Manager
        /// </summary>
        /// <param name="services"></param>
        public static void ConfigureServicesManager(this IServiceCollection services)
        {
            services.AddScoped<IServiceManager, ServiceManager>();
        }
 

    }
}

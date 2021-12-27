using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TenantsAPI.Helper.Constants;
using TenantsAPI.Models.DbContexts;

namespace TenantsAPI.Helpers.Configurations
{
    /// <summary>
    /// Configurations related to entity framework
    /// </summary>
    public static class DbConfiguration
    {
        /// <summary>
        /// Configures the service.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <param name="configuration">The configuration.</param>
        public static void ConfigureService(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<TenantsAPIDbContext>(options => options
                .UseSqlServer(configuration.GetConnectionString(DefaultConstants.TenantsAPIConnection), sqlServerOptions => sqlServerOptions.CommandTimeout(180))
                .EnableDetailedErrors()
            );
        }
    }
}
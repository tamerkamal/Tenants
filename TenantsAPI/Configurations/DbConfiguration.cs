using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Base.Helpers.Constants;
using Tenants.Models.DbContexts;

namespace Tenants.Helpers.Configurations
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
            services.AddDbContext<TenantsDbContext>(options => options
                .UseSqlServer(configuration.GetConnectionString(TenantsConstants.TenantsConnection), sqlServerOptions => sqlServerOptions.CommandTimeout(180))
                .EnableDetailedErrors()
            );
        }
    }
}
using Base.Helper.Constants;
using Master.Entity.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Master.Helpers.Configurations
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
            services.AddDbContext<MasterDbContext>(
                      options => options.UseSqlServer(configuration.GetConnectionString(DbConnections.MasterDbConnection),
                                                      sqlServerOptions => sqlServerOptions.CommandTimeout(180))
                    .EnableDetailedErrors()
            );
        }
    }
}
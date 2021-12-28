using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using StreamLine.Api.Security.AuthorizationHandler;
using StreamLine.Api.Security.AuthorizationPolicyProvider;
using System.Reflection;
using Tenants.Helpers.Constants;
using Tenants.Infrastructure.UnitOfWork;

namespace Tenants.Helpers.Configurations
{
    /// <summary>
    /// IOC Container start-up configuration
    /// </summary>
    public static class IocContainerConfiguration
    {
        /// <summary>
        /// Configures the service.
        /// </summary>
        /// <param name="services">The services.</param>
        public static void ConfigureService(IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            //services.AddScoped<IAuthorizationHandler, PermissionAuthorizationHandler>();
            services.AddScoped<IAuthorizationHandler, AuthorizationHandler>();
            services.AddSingleton<IAuthorizationPolicyProvider, PolicyProvider>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            // Registers the repository layer using scrutor plugin
            services.Scan(scan => scan.FromAssemblies(Assembly.Load(DefaultConstants.TenantsRepositoryLibraryName))?.AddClasses().AsMatchingInterface().WithScopedLifetime());

            // Registers the service layer using scrutor plugin
            services.Scan(scan => scan.FromAssemblies(Assembly.Load(DefaultConstants.TenantsServiceLibraryName))?.AddClasses().AsMatchingInterface().WithScopedLifetime());           
        }
    }
}
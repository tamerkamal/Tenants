using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Tenants.Api.Security.AuthorizationHandler;
using Tenants.Api.Security.AuthorizationPolicyProvider;
using System.Reflection;
using Base.Helpers.Constants;
using Base.Infrastructure.UnitOfWork;

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
            services.Scan(scan => scan.FromAssemblies(Assembly.Load(TenantsConstants.TenantsRepositoryLibraryName))?.AddClasses().AsMatchingInterface().WithScopedLifetime());

            // Registers the service layer using scrutor plugin
            services.Scan(scan => scan.FromAssemblies(Assembly.Load(TenantsConstants.TenantsServiceLibraryName))?.AddClasses().AsMatchingInterface().WithScopedLifetime());           
        }
    }
}
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Tenants.Api.Security.AuthorizationHandler;
using Tenants.Api.Security.AuthorizationPolicyProvider;
using System.Reflection;
using Base.Helpers.Constants;
using Base.Infrastructure.UnitOfWork;
using Tenants.Service.AWS.APIGateway.Interfaces;
using Tenants.Service.AWS.APIGateway.Classes;
using Tenants.Service.AWS.Cognito.CLasses;
using Tenants.Service.AWS.Cognito.Interfaces;

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

            //services.AddScoped<IAPIGatewayService, APIGatewayService>();
            //services.AddScoped<IUserPoolService, UserPoolService>();

            // Registers the repository layer using scrutor plugin
            services.Scan(scan => scan.FromAssemblies(Assembly.Load(TenantsConstants.TenantsRepositoryLibraryName))?.AddClasses().AsMatchingInterface().WithScopedLifetime());

            // Registers the service layer using scrutor plugin
            services.Scan(scan => scan.FromAssemblies(Assembly.Load(TenantsConstants.TenantsServiceLibraryName))?.AddClasses().AsMatchingInterface().WithScopedLifetime());           
        }
    }
}
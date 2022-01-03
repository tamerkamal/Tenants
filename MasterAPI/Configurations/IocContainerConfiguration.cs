using AWS.Service.APIGateway.Models;
using Base.Helpers.Constants;
using Base.Infrastructure.UnitOfWork;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Tenants.Api.Security.AuthorizationHandler;
using Tenants.Api.Security.AuthorizationPolicyProvider;
using Tenants.Service.AWS.APIGateway.Classes;
using Tenants.Service.AWS.APIGateway.Interfaces;

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
        public static void ConfigureService(IServiceCollection services, IConfiguration configuration)
        {
            #region Register Services

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<IAuthorizationPolicyProvider, PolicyProvider>();

            services.AddScoped<IAuthorizationHandler, AuthorizationHandler>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IAPIGatewayService, APIGatewayService>();

            #region register Scoped Layers

            // Registers the repository layer using scrutor plugin
            services.Scan(scan => scan.FromAssemblies(Assembly.Load(MasterConstants.RepositoryLibraryName))?.AddClasses().AsMatchingInterface().WithScopedLifetime());

            // Registers the service layer using scrutor plugin
            services.Scan(scan => scan.FromAssemblies(Assembly.Load(MasterConstants.ServiceLibraryName))?.AddClasses().AsMatchingInterface().WithScopedLifetime());

            #endregion

            #endregion

            #region Register Cognito Identity Provider

            //Adds Amazon Cognito as Identity Provider
            services.AddCognitoIdentity();

            #endregion        

            #region Add appsettings Config objects 

            services.Configure<AwsApiGatewaySettings>(configuration.GetSection(nameof(AwsApiGatewaySettings)));

            #endregion

           
        }
    }
}
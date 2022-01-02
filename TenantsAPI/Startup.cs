using Amazon.APIGateway;
using Base.Helpers.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Tenants.Helpers.Configurations;
using Tenants.Service.AWS.APIGateway.Classes;
using Tenants.Service.AWS.APIGateway.Interfaces;

namespace Tenants
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            {
                // Cognito authentication configuration
                CognitoConfiguration.ConfigureService(services);
            }
            // else
            //{
            //    // Ntlm authentication configuration
            //    StreamlineAuthConfiguration.ConfigureService(services, Configuration);
            //}

            // DB configuration
            DbConfiguration.ConfigureService(services, Configuration);

            // Add DI (Dependency Injection) / IOC containers
            IocContainerConfiguration.ConfigureService(services,Configuration);

            // Add and configure mvc core feature
            MvcCoreConfiguration.ConfigureService(services, Configuration);

            // Swagger API documentation
            SwaggerConfiguration.ConfigureService(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Set app culture
            Localization.SetCulture();

            //if (env.IsDevelopment())
            {
                // Configure jwt authentication
                CognitoConfiguration.Configure(app);
            }
            //else
            //{
            //    // Configure ntlm authentication
            //    StreamlineAuthConfiguration.Configure(app);
            //}

            // Configure middleware
            MiddlewareConfiguration.Configure(app);

            // Configure mvc core feature
            MvcCoreConfiguration.Configure(app);

            // Configure the Swagger API documentation
            SwaggerConfiguration.Configure(app);

            // Configure the Serilog
            SerilogConfiguration.Configure(app);
        }
    }
}

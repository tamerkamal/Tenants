using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.IO.Compression;

namespace TenantsAPI.Helpers.Configurations
{
    /// <summary>
    /// Configure MVC Core for the application
    /// </summary>
    public static class MvcCoreConfiguration
    {
        /// <summary>
        /// Add and configure MVC Core for the application
        /// </summary>
        /// <param name="services">Collection of service descriptors</param>
        /// <param name="configuration">IConfiguration</param>
        public static void ConfigureService(IServiceCollection services, IConfiguration configuration)
        {
            // Add cors policy
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAllOriginsPolicy",
                    builder =>
                    {
                        builder.WithOrigins(
                            "https://localhost:44300",
                            "https://streamline.dev.tech2.com.au",
                            "https://streamline.tech2.com.au",
                            "https://streamline.qa.tech2.com.au",
                            "https://streamline.test.tech2.com.au");
                        //builder.AllowAnyOrigin();
                        builder.AllowAnyHeader();
                        builder.AllowAnyMethod();
                        //builder.AllowCredentials(); // Added
                    });
            });

            // Add SignalR
            //services.AddSignalR();

            // Add controllers
            services.AddControllers();

            // Add health check
            services.AddHealthChecks();

            // Add response caching
            //services.AddResponseCaching();

            // Add compression
            services.AddResponseCompression();
            services.Configure<GzipCompressionProviderOptions>(options => { options.Level = CompressionLevel.Fastest; });

            // Add functionality to inject IOptions<T>
            services.AddOptions();

          

            // Add basic mvc core feature
            var mvcCoreBuilder = services.AddMvcCore();

            //add HSTS
            services.AddHsts(options =>
            {
                options.Preload = true;
                options.IncludeSubDomains = true;
                options.MaxAge = TimeSpan.FromHours(1);
                //options.ExcludedHosts.Add("example.com");
                //options.ExcludedHosts.Add("www.example.com");
            });

            services.AddHttpsRedirection(options =>
            {
                options.RedirectStatusCode = StatusCodes.Status307TemporaryRedirect;
                //options.HttpsPort = 5001;
            });


            // Sets the default value of settings on MvcOptions to match the behavior of asp.net core mvc latest
            mvcCoreBuilder.SetCompatibilityVersion(CompatibilityVersion.Latest);

            // MVC now serializes JSON with local datetime zone by default
            mvcCoreBuilder.AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.Local;
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            });

            // Register controllers as services, it'll allow to override them
            //mvcCoreBuilder.AddControllersAsServices();

            // The ApiExplorer contains functionality for discovering and exposing metadata about your MVC application.
            // Used for Swagger
            mvcCoreBuilder.AddApiExplorer();

            // Add fluent validation
            mvcCoreBuilder.AddFluentValidation();
        }

        /// <summary>
        /// Configures the specified application.
        /// </summary>
        /// <param name="app">The application.</param>
        public static void Configure(IApplicationBuilder app)
        {
            // Enable compression
            app.UseResponseCompression();

            // Enable Hsts
            //if (env.IsDevelopment())
            //{
            app.UseHsts();
            //}

            app.UseHttpsRedirection();

            // Use the CORS policy
            app.UseCors("AllowAllOriginsPolicy");

            // Configure routing
            app.UseRouting();

            // Enable authorization
            app.UseAuthorization();

            // Enable response caching
            app.UseResponseCaching();

            app.Use(async (context, next) =>
            {
                context.Response.GetTypedHeaders().CacheControl =
                    new Microsoft.Net.Http.Headers.CacheControlHeaderValue()
                    {
                        Public = true,
                        MaxAge = TimeSpan.FromSeconds(10)
                    };
                context.Response.Headers[Microsoft.Net.Http.Headers.HeaderNames.Vary] = new[] { "Accept-Encoding" };
                await next();
            });

            // Configure end points
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHealthChecks("/health");

                //// Map Hub
                //endpoints.MapHub<SignalRHub>("/signalRHub");
            });
        }
    }
}

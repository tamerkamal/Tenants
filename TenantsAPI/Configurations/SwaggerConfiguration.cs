using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;
using System;

namespace Tenants.Helpers.Configurations
{
    /// <summary>
    /// Swagger API documentation components start-up configuration
    /// </summary>
    public static class SwaggerConfiguration
    {
        /// <summary>
        /// Configures the service.
        /// </summary>
        /// <param name="services">The services.</param>
        public static void ConfigureService(IServiceCollection services)
        {
            // Inject an implementation of ISwaggerProvider with defaulted settings applied.
            // Swagger API documentation
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1.0.0",
                    Title = "Tenants API Documentation",
                    Description = "Welcome to Tenants Portal",
                    Contact = new OpenApiContact { Name = "tech2", Email = "techsupport@tech2.com.au" },
                    TermsOfService = new Uri("https://www.tech2.com.au/about-tech2/terms-conditions"),
                    License = new OpenApiLicense { Name = "MIT", Url = new Uri("https://www.tech2.com.au/about-tech2/privacy-policy") }
                });
                c.SwaggerDoc("integration", new OpenApiInfo
                {
                    Version = "v1.0.0",
                    Title = "Tenants Integration API Documentation",
                    Description = "Welcome to Tenants API",
                    Contact = new OpenApiContact { Name = "tech2", Email = "techsupport@tech2.com.au" },
                    TermsOfService = new Uri("https://www.tech2.com.au/about-tech2/terms-conditions"),
                    License = new OpenApiLicense { Name = "MIT", Url = new Uri("https://www.tech2.com.au/about-tech2/privacy-policy") }
                });

                // Adds fluent Token to swagger
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please insert JWT with Bearer into field",
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] { }
                    }
                });

                // split documentation by group names
                c.DocInclusionPredicate((name, api) => name == (api.GroupName ?? "v1"));

                //// remove "groupName" from documentation
                //c.OperationFilter<RemoveGroupNameFromParameter>();
                //c.DocumentFilter<ReplaceGroupNamePath>();

                //// Adds fluent validation rules to swagger
                //c.AddFluentValidationRules();

                // Set the comments path for the Swagger JSON and UI.
                //var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                //var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

                // Include Descriptions from XML Comments
                //c.IncludeXmlComments(xmlPath);
            });
        }

        /// <summary>
        /// Configures the specified application.
        /// </summary>
        /// <param name="app">The application.</param>
        public static void Configure(IApplicationBuilder app)
        {
            // This will redirect default url to Swagger url
            var option = new RewriteOptions();
            option.AddRedirect("^$", "swagger");
            app.UseRewriter(option);

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui assets (HTML, JS, CSS etc.)
            // Specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.DocumentTitle = "Tenants API Documentation";
                c.DefaultModelExpandDepth(2);
                c.DefaultModelRendering(ModelRendering.Model);
                c.DefaultModelsExpandDepth(-1);
                c.DisplayOperationId();
                c.DisplayRequestDuration();
                c.DocExpansion(DocExpansion.None);
                c.EnableDeepLinking();
                c.EnableFilter();
                c.MaxDisplayedTags(100);
                c.ShowExtensions();
                c.EnableValidator();
                c.SupportedSubmitMethods(SubmitMethod.Get, SubmitMethod.Post, SubmitMethod.Delete, SubmitMethod.Put, SubmitMethod.Head);
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Tenants API Documentation v1.0.0");
                c.SwaggerEndpoint("/swagger/integration/swagger.json", "Tenants API Documentation v1.0.0");
                c.RoutePrefix= string.Empty;
            });
        }
    }
}
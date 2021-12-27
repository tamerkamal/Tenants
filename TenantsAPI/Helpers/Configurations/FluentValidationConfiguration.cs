using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;

namespace TenantsAPI.Helpers.Configurations
{
    /// <summary>
    /// Configure fluent validation for the application
    /// </summary>
    public static class FluentValidationConfiguration
    {
        /// <summary>
        /// Configures the fluent validation.
        /// </summary>
        /// <param name="mvcCoreBuilder">IMvcCoreBuilder</param>
        public static void AddFluentValidation(this IMvcCoreBuilder mvcCoreBuilder)
        {
            // Configure fluent validation
            mvcCoreBuilder.AddFluentValidation(configuration =>
            {
                // register all available validators from assemblies
                //configuration.RegisterValidatorsFromAssembly(Assembly.Load(DefaultConstants.StreamLineServiceLibraryName));

                // prevent default mvc validation
                configuration.DisableDataAnnotationsValidation = false;

                // implicit/automatic validation of child properties
                configuration.ImplicitlyValidateChildProperties = true;
            });
        }
    }
}
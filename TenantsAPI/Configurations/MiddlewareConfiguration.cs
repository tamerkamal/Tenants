using Microsoft.AspNetCore.Builder;
using Tenants.CustomMiddlewares;

namespace Tenants.Helpers.Configurations
{
    /// <summary>
    /// Configure middleware for the application
    /// </summary>
    public static class MiddlewareConfiguration
    {
        /// <summary>
        /// Configures the specified application.
        /// </summary>
        /// <param name="app">The application.</param>
        public static void Configure(IApplicationBuilder app)
        {
            // One transaction per server roundtrip
            app.UseMiddleware<TransactionPerRequestMiddleware>();

            //app.UseMiddleware<StackifyMiddleware.RequestTracerMiddleware>();

            // Configure central error/exception handler Middleware
            app.UseMiddleware<ExceptionHandlerMiddleware>();
        }
    }
}
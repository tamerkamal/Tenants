using Microsoft.AspNetCore.Builder;
using Serilog;
using Serilog.Events;
using Serilog.Formatting.Compact;

namespace TenantsAPI.Helpers.Configurations
{
    /// <summary>
    /// Configure Serilog for the application
    /// </summary>
    public static class SerilogConfiguration
    {
        /// <summary>
        /// Configures the serilog.
        /// </summary>
        public static void Configure()
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Verbose()
                .Enrich.FromLogContext()
                .WriteTo.Console(new RenderedCompactJsonFormatter(), LogEventLevel.Error)
                .WriteTo.RollingFile("Logs/log-{Date}.txt", LogEventLevel.Error)
                //.WriteTo.Seq(Environment.GetEnvironmentVariable("SEQ_URL") ?? "http://localhost:5341")
                //.WriteTo.Http("http://logstash:8080")
                .CreateLogger();
        }

        /// <summary>
        /// Configures the specified application.
        /// </summary>
        /// <param name="app">The application.</param>
        public static void Configure(IApplicationBuilder app)
        {
            //app.UseSerilogRequestLogging();
        }
    }
}
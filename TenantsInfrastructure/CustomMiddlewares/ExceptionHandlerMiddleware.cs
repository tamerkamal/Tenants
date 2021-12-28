using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using Serilog;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net;
using Tenants.Helpers.Models;
using Tenants.Models.DbContexts;

namespace Tenants.CustomMiddlewares
{
    /// <summary>
    /// Central error/exception handler Middleware
    /// </summary>
    public class ExceptionHandlerMiddleware
    {
        private const string JsonContentType = "application/json";
        private readonly RequestDelegate _next;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExceptionHandlerMiddleware"/> middleware.
        /// </summary>
        /// <param name="next">The delegate representing the remaining middleware in the request pipeline.</param>

        public ExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        /// <summary>
        /// Invokes the specified context.
        /// </summary>
        /// <param name="httpContext">The http context.</param>
        /// <param name="environment">IWebHostEnvironment</param>
        /// <param name="dbContext">The database context</param>
        /// <returns></returns>
        public async System.Threading.Tasks.Task Invoke(HttpContext httpContext, IWebHostEnvironment environment, TenantsDbContext dbContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception exception)
            {
                try
                {

                    dbContext.Database.CurrentTransaction?.Rollback();
                }

                finally
                {
                    dbContext.Database.CurrentTransaction?.Dispose();
                }

                await HandleExceptionAsync(httpContext, environment, exception);
            }
        }

        private static async System.Threading.Tasks.Task HandleExceptionAsync(HttpContext httpContext, IHostEnvironment environment, Exception exception)
        {
            // get http status code
            var httpStatusCode = ConfigureExceptionTypes(exception);

            //set http response header to hide cors error
            httpContext.Response.Headers.Add("Access-Control-Allow-Origin", "*");

            // set http status code and content type
            httpContext.Response.StatusCode = httpStatusCode;
            httpContext.Response.ContentType = JsonContentType;
            // create exception messages
            var briefMessage = CreateBriefMessage(exception);
            var fullMessage = CreateFullMessage(exception);

            // log the full message
            Log.Error(fullMessage);

            // create response object.
            var response = JsonConvert.SerializeObject(new ErrorModel
            {
                StatusCode = httpStatusCode,
                Message = (environment.IsDevelopment() ? fullMessage : briefMessage)
            });

            // writes / returns error model to the response
            await httpContext.Response.WriteAsync(response);

            // This is throwing readonly exception
            //httpContext.Response.Headers.Clear();
        }

        /// <summary>
        /// Configure/maps exception to the proper HTTP error Type
        /// </summary>
        /// <param name="exception">The exception.</param>
        /// <returns></returns>
        private static int ConfigureExceptionTypes(Exception exception)
        {
            int httpStatusCode;

            // Exception type To Http Status configuration 
            switch (exception)
            {
                case var _ when exception is ValidationException:
                    httpStatusCode = (int)HttpStatusCode.BadRequest;
                    break;
                default:
                    httpStatusCode = (int)HttpStatusCode.InternalServerError;
                    break;
            }

            return httpStatusCode;
        }

        private static string CreateBriefMessage(Exception exception)
        {
            var message = "Exception caught in global error handler.";
            message += $"{Environment.NewLine}Exception: {exception.Message}";
            return message;
        }

        private static string CreateFullMessage(Exception exception)
        {
            // Limit how far into the exception-nesting we will go
            const int maxDepth = 100; // Generous is ok; just want to stop somewhere

            // Prepare to record lines of our message
            var lines = new List<string>();

            // Keep appending exceptions until we hit the bottom, or the depth limit
            var depth = 0;
            while (exception != null && depth < maxDepth)
            {
                // Prefix before exception is different on the 1st one
                lines.Add(depth == 0 ? "Exception caught in global error handler." : "(inner exception follows)");

                // Add the exception details
                lines.Add($"Exception: {exception.Message}");
                lines.Add(exception.StackTrace);

                // Move down to the nested income
                exception = exception.InnerException;
                depth++;
            }

            // Merge all the lines, separated by a newline
            return string.Join(Environment.NewLine, lines);
        }
    }
}
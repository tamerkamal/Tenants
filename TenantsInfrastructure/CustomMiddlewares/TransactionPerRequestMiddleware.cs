using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Tenants.Infrastructure.UnitOfWork;
using Tenants.Models.DbContexts;
using Task = System.Threading.Tasks.Task;

namespace Tenants.CustomMiddlewares
{
    /// <summary>
    /// One transaction per server roundtrip
    /// </summary>
    public class TransactionPerRequestMiddleware
    {
        private readonly RequestDelegate _next;

        /// <summary>
        /// Initializes a new instance of the <see cref="TransactionPerRequestMiddleware"/> middleware.
        /// </summary>
        /// <param name="next">The delegate representing the remaining middleware in the request pipeline.</param>

        public TransactionPerRequestMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        /// <summary>
        /// Invokes the specified context.
        /// </summary>
        /// <param name="httpContext">The http context.</param>
        /// <param name="dbContext">The database context</param>
        /// <returns></returns>
        public async Task Invoke(HttpContext httpContext, TenantsDbContext dbContext)
        {
            // This for allow cross Origin
            httpContext.Response.Headers.Add("Access-Control-Allow-Credentials", new[] { "true" });
            httpContext.Response.Headers.Add("Access-Control-Allow-Headers", new[] { "Origin, X-Requested-With, Content-Type, Accept, Athorization, ,X-Custom-header,ActualUserOrImpersonatedUserSamAccount, IsImpersonatedUser" });
            httpContext.Response.Headers.Add("Access-Control-Allow-Methods", new[] { "GET, POST, PUT, DELETE, OPTIONS" });

            var methodType = httpContext.Request.Method.ToUpper();
            if (methodType.Equals("GET") || methodType.Equals("OPTIONS"))
            {
                await _next.Invoke(httpContext);
            }
            else
            {
                // Start a new transaction
                var transaction = dbContext.Database.BeginTransaction(System.Data.IsolationLevel.ReadUncommitted);

                // Invoke and complete the request
                await _next.Invoke(httpContext);

                try
                { 
                    if ((httpContext.Response.StatusCode == 200 || httpContext.Response.StatusCode == 302) && dbContext.Database.CurrentTransaction != null)
                        transaction.Commit();
                    // role back in ExceptionHandlerMiddleware
                }
                finally
                {
                    transaction?.Dispose();
                }

            }
        }
    }
}
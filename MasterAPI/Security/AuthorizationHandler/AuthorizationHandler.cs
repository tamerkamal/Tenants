using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Tenants.Api.Security.AuthorizationRequirement;
using System.Threading.Tasks;

namespace Tenants.Api.Security.AuthorizationHandler
{
    internal class AuthorizationHandler : AuthorizationHandler<AuthorizeRequirement>
    {
        //private readonly IAuthorizationManager _authorizationManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
      


        public AuthorizationHandler(//IAuthorizationManager authorizationManager,
                                    IHttpContextAccessor httpContextAccessor)
        {
            //_authorizationManager = authorizationManager;
            _httpContextAccessor = httpContextAccessor;
        }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, AuthorizeRequirement requirement)
        {
            bool hasAccess;
            var routeValues = _httpContextAccessor.HttpContext.Request.RouteValues;
            switch (requirement.AuthorizePolicyCode)
            {
                //missing project region authorization policy
                //case AuthorizePolicy.JobAuthorizePolicy.JobVisitAccess:
                //{
                //    var jobVisitId = Convert.ToInt32(routeValues["jobVisitId"]);
                //    hasAccess = _authorizationManager.HasJobVisitAccess(jobVisitId);
                //    break;
                //}
                //case AuthorizePolicy.JobAuthorizePolicy.JobTypeAccess:
                //{
                //    var jobTypeId = Convert.ToInt32(routeValues["jobTypeId"]);
                //    hasAccess = _authorizationManager.HasJobTypeAccess(jobTypeId);
                //    break;
                //}
                //case AuthorizePolicy.JobAuthorizePolicy.JobAccess:
                //{
                //    var jobId = Convert.ToInt32(routeValues["jobId"]);
                //    hasAccess = _authorizationManager.HasJobAccess(jobId);
                //    break;
                //}
                //case AuthorizePolicy.TaskAuthorizePolicy.TaskAccess:
                //{
                //    var taskId = Convert.ToInt32(routeValues["taskId"]);
                //    hasAccess = _authorizationManager.HasTaskAccess(taskId);
                //    break;
                //}
                default:
                    hasAccess = true;
                    break;
            }

            if (hasAccess)
                context.Succeed(requirement);
            else
                context.Fail();

            return Task.FromResult(0);
        }
        
    }
}
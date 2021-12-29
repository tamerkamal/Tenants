using Microsoft.AspNetCore.Authorization;

namespace Tenants.Api.Security.AuthorizationRequirement
{
    internal class AuthorizeRequirement : IAuthorizationRequirement
    {
       

        public string AuthorizePolicyCode { get; }



        public AuthorizeRequirement(string authorizePolicyCode)
        {

            AuthorizePolicyCode = authorizePolicyCode;
        }
    }
}
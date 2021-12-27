using Microsoft.AspNetCore.Authorization;

namespace StreamLine.Api.Security.AuthorizationRequirement
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
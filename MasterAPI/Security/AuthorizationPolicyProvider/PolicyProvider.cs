using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;
using Tenants.Api.Security.AuthorizationRequirement;
using System;
using System.Linq;
using System.Threading.Tasks;
using Base.Helpers.Constants;
using Base.Helpers.Enums;
using Base.Helpers.Extensions;

namespace Tenants.Api.Security.AuthorizationPolicyProvider
{
    internal class PolicyProvider : DefaultAuthorizationPolicyProvider
    {
        public PolicyProvider(IOptions<AuthorizationOptions> options) : base(options) { }

        public override Task<AuthorizationPolicy> GetPolicyAsync(string fullPolicyName)
        {
            if (fullPolicyName.StartsWith(Permissions.PolicyPrefix, StringComparison.OrdinalIgnoreCase))
            {
            var policyData = fullPolicyName.Substring(Permissions.PolicyPrefix.Length).Split('|').ToList();

            var permissionId = Convert.ToInt32(policyData[1]);
               PermissionLevels permissionLevel = policyData[2].TryParseEnum<PermissionLevels>();
            var policy = new AuthorizationPolicyBuilder();
           // policy.AddRequirements(new PermissionRequirement(permissionId, permissionLevel));

             return Task.FromResult(policy.Build());
            }
            else if (fullPolicyName.StartsWith(AuthorizePolicy.PolicyPrefix, StringComparison.OrdinalIgnoreCase))
            {
                var policyData = fullPolicyName.Substring(AuthorizePolicy.PolicyPrefix.Length).Split('|').ToList();
                var code = policyData[1];
              
                var policy = new AuthorizationPolicyBuilder();
                policy.AddRequirements(new AuthorizeRequirement(code));
                return Task.FromResult(policy.Build());

            }
            else 
            {
                return base.GetPolicyAsync(fullPolicyName);
            }

         
        }
    }
}
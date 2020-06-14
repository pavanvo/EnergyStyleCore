
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace CustomPolicyProvider
{
    // This class contains logic for determining whether MinimumAgeRequirements in authorization
    // policies are satisfied or not
    internal class RoleAuthorizationHandler : AuthorizationHandler<RoleRequirement>
    {
        public RoleAuthorizationHandler()
        {

        }

        // Check whether a given MinimumAgeRequirement is satisfied or not for a particular context
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, RoleRequirement requirement)
        {
            // Check the user's age
            var roleClaim = context.User.FindFirst(c => c.Type == ClaimTypes.Role);
            if (roleClaim != null)
            {
                // If the user has a date of birth claim, check their age
                var role = roleClaim.Value;
                if (role.Contains(requirement.Role))
                {
                    // Adjust age if the user hasn't had a birthday yet this year
                   context.Succeed(requirement);
                }
            }
            return Task.CompletedTask;
        }
    }
}

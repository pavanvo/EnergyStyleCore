using Microsoft.AspNetCore.Authorization;

namespace CustomPolicyProvider
{
    internal class RoleRequirement : IAuthorizationRequirement
    {
        public string Role { get; private set; }

        public RoleRequirement(string role) { Role = role; }
    }
}
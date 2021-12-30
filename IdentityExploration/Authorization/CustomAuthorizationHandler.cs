using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityExploration.Authorization
{
    public class CustomAuthorizationHandler : AuthorizationHandler<CustomRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, CustomRequirement requirement)
        {
            var dateOfBirthString = context.User.Claims.FirstOrDefault(x => x.Type == "DateOfBirth")?.Value;
            var isValid = DateTime.TryParse(dateOfBirthString, out DateTime value);
            var year = DateTime.Now.Year;

            if (isValid && (year - value.Year) >= 30)
                context.Succeed(requirement);

            return Task.CompletedTask;
        }
    }
}

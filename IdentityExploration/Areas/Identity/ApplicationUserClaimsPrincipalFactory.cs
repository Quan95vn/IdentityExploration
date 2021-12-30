using IdentityExploration.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace IdentityExploration.Areas.Identity
{
    /// <summary>
    /// Add custom claim to user, but can only work within Identity framework
    /// </summary>
    public class ApplicationUserClaimsPrincipalFactory : 
        UserClaimsPrincipalFactory<ApplicationUser, IdentityRole>
    {
        public ApplicationUserClaimsPrincipalFactory(
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,
            IOptions<IdentityOptions> options
            ) : base(userManager, roleManager, options)
        {

        }

        protected override async Task<ClaimsIdentity> GenerateClaimsAsync(ApplicationUser user)
        {
            var identity = await base.GenerateClaimsAsync(user);

            identity.AddClaim(new Claim("DateOfBirth",
                user.DateOfBirth.Value.ToShortDateString()));
            identity.AddClaim(new Claim("CareerStartedDate", 
                user.CareerStartedDate.Value.ToShortDateString()));

            return identity;
        }
    }
}

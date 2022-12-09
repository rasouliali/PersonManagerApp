using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using IdentityModel;

namespace PersonManager.InfraStructure.Services
{
    public class ClaimsFactory<T> : UserClaimsPrincipalFactory<Infrastructure.Identity.ApplicationUser>
     where T : IdentityUser
    {
        private readonly UserManager<Infrastructure.Identity.ApplicationUser> _userManager;

        public ClaimsFactory(
            UserManager<Infrastructure.Identity.ApplicationUser> userManager,
            IOptions<IdentityOptions> optionsAccessor) : base(userManager, optionsAccessor)
        {
            _userManager = userManager;
        }

        protected override async Task<ClaimsIdentity> GenerateClaimsAsync(Infrastructure.Identity.ApplicationUser user)
        {
            var identity = await base.GenerateClaimsAsync(user);
            var roles = await _userManager.GetRolesAsync(user);

            identity.AddClaims(roles.Select(role => new Claim(JwtClaimTypes.Role, role)));

            return identity;
        }
    }

}

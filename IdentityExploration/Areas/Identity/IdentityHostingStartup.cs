using IdentityExploration.Areas.Identity.Data;
using IdentityExploration.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(IdentityExploration.Areas.Identity.IdentityHostingStartup))]
namespace IdentityExploration.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<IdentityExplorationContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("IdentityExplorationContextConnection")));

                // Change from AddDefaultIdentity -> AddIdentity to support get claims from Roles, RoleClaims tables
                services.AddIdentity<ApplicationUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<IdentityExplorationContext>()
                    .AddDefaultUI()
                    .AddDefaultTokenProviders();

                services.AddScoped<IUserClaimsPrincipalFactory<ApplicationUser>, ApplicationUserClaimsPrincipalFactory>();

                services.AddAuthentication().AddGoogle(g =>
                {
                    g.ClientId = context.Configuration["Google:ClientId"];
                    g.ClientSecret = context.Configuration["Google:ClientSecret"];
                });
            });
        }
    }
}
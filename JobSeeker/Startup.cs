using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(JobSeeker.Startup))]
namespace JobSeeker
{
    public partial class Startup
    {
        ApplicationDbContext context = new ApplicationDbContext();
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CreateDefaultRolesAndUser();
        }

        public void CreateDefaultRolesAndUser()
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var userManager = new UserManager<IdentityUser>(new UserStore<IdentityUser>(context));
            IdentityRole role = new IdentityRole();
            if (!roleManager.RoleExists("Admin"))
            {
                role.Name="Admin";
                roleManager.Create(role);
                ApplicationUser user = new ApplicationUser();
                user.Email = "jobseeker@admin.local";
                user.UserName = "jobseeker@admin.local";
                user.PasswordHash = "P@ssw0rd";
                var result = userManager.Create(user);
                if (result.Succeeded)
                {
                    userManager.AddToRole(user.Id, "Admin");
                }
            }
        }
    }
}

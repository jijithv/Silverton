using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Silverton.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<Silverton.Models.ProjectViewModels> ProjectViewModels { get; set; }

        public System.Data.Entity.DbSet<Silverton.Models.CameraViewModels> CameraViewModels { get; set; }

        public System.Data.Entity.DbSet<Silverton.Models.ScenarioViewModels> ScenarioViewModels { get; set; }

        public System.Data.Entity.DbSet<Silverton.Models.NotificationsViewModels> NotificationsViewModels { get; set; }

        public System.Data.Entity.DbSet<Silverton.Models.UserSetupViewModels> UserSetupViewModels { get; set; }

        public System.Data.Entity.DbSet<Silverton.Models.LogsViewModels> LogsViewModels { get; set; }
    }
}
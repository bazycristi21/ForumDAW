using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using ForumDAW.DataAccessLayer;
using System;

namespace ForumDAW.Models
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
            // Database.SetInitializer<ApplicationDbContext>(new Initp());
        }
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Component> Components { get; set; }

    }
    public class IdentityDbInit : DropCreateDatabaseAlways<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            PerformInitialSetup(context);
            base.Seed(context);
        }
        public void PerformInitialSetup(ApplicationDbContext context)
        {
            using (var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context)))
            {
                using (var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context)))
                {
                    //system Role
                    if (!roleManager.RoleExists("admin"))
                    {
                        roleManager.Create(new IdentityRole("admin"));
                    }
                    var user = new ApplicationUser() { UserName = "admin@admin.com", Email = "admin@admin.com" };
                    if (userManager.Create(user, "000000") != IdentityResult.Success)
                    {
                        throw new Exception("failed");
                    }
                    // role
                    userManager.AddToRole(user.Id, "admin");
                    context.SaveChanges();
                }
            }

        }
    }
}
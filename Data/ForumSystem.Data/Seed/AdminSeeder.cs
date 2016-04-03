namespace ForumSystem.Data.Seed
{
    using System;
    using System.Linq;
    using ForumSystem.Common.Constants;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    
    public class AdminSeeder : IDataSeeder
    {
        public void Seed(ForumSystemDbContext context)
        {
            string masterAdminUserName = "admin@abv.bg";

            string roleName = Admin.AdminRole;

            var isMasterAdminSeeded = context.Users.Any(u => u.UserName == masterAdminUserName);

            if (!isMasterAdminSeeded)
            {
                var userManager = new UserManager<User>(new UserStore<User>(context));
                var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

                userManager.Create(new User() { UserName = masterAdminUserName, Email = masterAdminUserName, CreatedOn = DateTime.UtcNow, Photo = "http://cdn2.hubspot.net/hub/245562/file-306538470-png/v3/ninja2.png?t=1453934745802" }, "123456");

                roleManager.Create(new IdentityRole() { Name = roleName });

                var admin = context.Users.FirstOrDefault(u => u.UserName == masterAdminUserName);

                userManager.AddToRole(admin.Id, roleName);
            }
        }
    }
}

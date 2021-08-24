using Microsoft.AspNetCore.Identity;

namespace Axxes.Haxx.EntityFramework
{
    public class ApplicationDbInitializer
    {
        public static void SeedUsers(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            if (!roleManager.RoleExistsAsync("ADMIN").Result)
                _ = roleManager.CreateAsync(new IdentityRole("ADMIN")).Result;

            if (userManager.FindByEmailAsync("admin@admin.com").Result == null)
            {
                var hash = new PasswordHasher<ApplicationUser>();
                var admin = new ApplicationUser
                {
                    UserName = "admin@admin.com",
                    Email = "admin@admin.com",
                    FullName = "SysAdmin",
                    PasswordHash = hash.HashPassword(null, "admin"),
                    EmailConfirmed = true
                };

                if (userManager.CreateAsync(admin, "admin").Result.Succeeded)
                    _ = userManager.AddToRoleAsync(admin, "ADMIN").Result;
            }
        }
    }
}

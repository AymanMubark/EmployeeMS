using EmployeeMS.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace EmployeeMS.Data
{
    public static class SeedContext
    {
        public static async Task initalApp(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            var services = scope.ServiceProvider;
            var context = services.GetRequiredService<ApplicationDbContext>();
            var userManager = services.GetRequiredService<UserManager<IdentityUser>>();

            await context!.Database.MigrateAsync();

            if (!await context.Users.AnyAsync())
            {
                var admin = new IdentityUser { UserName = "admin@admin.com", Email = "admin@admin.com",EmailConfirmed =true };
                await userManager.CreateAsync(admin, "P@$$0rd");
            }


            if (!await context.Departments.AnyAsync())
            {
                var departments = new[]
                {
                  new  Department(){Name = "IT"},
                  new  Department(){Name = "HR"},
                  new  Department(){Name = "Sales"}
                };
                await context.Departments.AddRangeAsync(departments);
                await context.SaveChangesAsync();
            }

        }
    }
}

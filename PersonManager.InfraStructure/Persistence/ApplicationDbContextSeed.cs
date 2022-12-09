using PersonManager.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading.Tasks;

namespace PersonManager.Infrastructure.Persistence
{
    public static class ApplicationDbContextSeed
    {
        public static async Task SeedDefaultUserAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            var administratorRole = new IdentityRole("role_admin");

            if (roleManager.Roles.All(r => r.Name != administratorRole.Name))
            {
                await roleManager.CreateAsync(administratorRole);
            }
            var userRole = new IdentityRole("role_user");

            if (roleManager.Roles.All(r => r.Name != userRole.Name))
            {
                await roleManager.CreateAsync(userRole);
            }

            var administrator = new ApplicationUser { UserName = "admin", Email = "admin@local" };

            if (userManager.Users.All(u => u.UserName != administrator.UserName))
            {
                await userManager.CreateAsync(administrator, "Administrator1!");
                await userManager.AddToRolesAsync(administrator, new[] { administratorRole.Name });
                var code = await userManager.GenerateEmailConfirmationTokenAsync(administrator);
                await userManager.ConfirmEmailAsync(administrator, code);
            }

            var user = new ApplicationUser { UserName = "user", Email = "user@local" };

            if (userManager.Users.All(u => u.UserName != user.UserName))
            {
                await userManager.CreateAsync(user, "User1!");
                await userManager.AddToRolesAsync(user, new[] { userRole.Name });
                var code = await userManager.GenerateEmailConfirmationTokenAsync(user);
                await userManager.ConfirmEmailAsync(user, code);
            }
            administrator = new ApplicationUser { UserName = "admin2@local", Email = "admin2@local" };

            if (userManager.Users.All(u => u.UserName != administrator.UserName))
            {
                await userManager.CreateAsync(administrator, "Administrator1!");
                await userManager.AddToRolesAsync(administrator, new[] { administratorRole.Name });
                var code = await userManager.GenerateEmailConfirmationTokenAsync(administrator);
                await userManager.ConfirmEmailAsync(administrator, code);
            }

            user = new ApplicationUser { UserName = "user2@local", Email = "user2@local"};

            if (userManager.Users.All(u => u.UserName != user.UserName))
            {
                await userManager.CreateAsync(user, "User1!");
                await userManager.AddToRolesAsync(user, new[] { userRole.Name });
                var code = await userManager.GenerateEmailConfirmationTokenAsync(user);
                await userManager.ConfirmEmailAsync(user, code);
            }
        }

        //public static async Task SeedSampleDataAsync(ApplicationDbContext context)
        //{
        //    // Seed, if necessary
        //    if (!context.TodoLists.Any())
        //    {
        //        context.TodoLists.Add(new TodoList
        //        {
        //            Title = "Shopping",
        //            Colour = Colour.Blue,
        //            Items =
        //            {
        //                new TodoItem { Title = "Apples", Done = true },
        //                new TodoItem { Title = "Milk", Done = true },
        //                new TodoItem { Title = "Bread", Done = true },
        //                new TodoItem { Title = "Toilet paper" },
        //                new TodoItem { Title = "Pasta" },
        //                new TodoItem { Title = "Tissues" },
        //                new TodoItem { Title = "Tuna" },
        //                new TodoItem { Title = "Water" }
        //            }
        //        });

        //        await context.SaveChangesAsync();
        //    }
        //}
    }
}

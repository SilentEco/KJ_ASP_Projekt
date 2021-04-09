using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using KJ_ASP_Projekt.Model;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace KJ_ASP_Projekt.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Event> Events { get; set; }



        public async Task Seed(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
           // await Database.EnsureDeletedAsync();
            await Database.EnsureCreatedAsync();

            await roleManager.CreateAsync(new IdentityRole("admin"));
            await roleManager.CreateAsync(new IdentityRole("organizer"));

            User admin1= new User() { FirstName = "Kristopher", LastName = "Kram", Email = "test1@hotmail.com", EmailConfirmed = true, UserName = "admin1"  };
            User admin2 = new User() { FirstName = "Jakob", LastName = "Larsson", Email = "test2@hotmail.com", EmailConfirmed = true, UserName = "admin2" };

            await userManager.CreateAsync(admin1, "Passw0rd!");
            await userManager.CreateAsync(admin2, "Passw0rd!");

            await userManager.AddToRoleAsync(admin1, "admin");
            await userManager.AddToRoleAsync(admin2, "organizer");

            await SaveChangesAsync();

            
            

        }
    }
}

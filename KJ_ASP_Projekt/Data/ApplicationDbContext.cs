﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
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

        DbSet<Event> Events { get; set; }



        public async Task Seed(UserManager<User> userManager)
        {

            /* Users.AddRange(new List<User>()
             {
                 new User(){FirstName = "Kristopher", LastName = "Kram" },
                 new User(){FirstName = "Jakob", LastName = "Larsson" }


             });*/

            User admin1= new User() { FirstName = "Kristopher", LastName = "Kram" };
            User admin2 = new User() { FirstName = "Jakob", LastName = "Larsson" };

            await userManager.CreateAsync(admin1, "Passw0rd!");
            await userManager.CreateAsync(admin2, "Passw0rd!");


            

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KJ_ASP_Projekt.Data;
using KJ_ASP_Projekt.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;


namespace KJ_ASP_Projekt.Pages.Admin
{
    [Authorize(Roles ="admin")]
    public class UsersListModel : PageModel
    {
        private readonly KJ_ASP_Projekt.Data.ApplicationDbContext _context;

        public readonly UserManager<User> _userManager;




        public UsersListModel(KJ_ASP_Projekt.Data.ApplicationDbContext context,
                                UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        

        public List<User> Users { get; set; }

        public async Task OnGetAsync()
        {
            

            Users = await _context.Users.ToListAsync();

            
            var test = await _userManager.IsInRoleAsync(Users[0], "organizer");

            test = true;

            var test1 = 0;

            await _context.SaveChangesAsync();

            

        }

        public async Task<IActionResult> OnPost(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            
            var userId = await _context.Users.FirstOrDefaultAsync(m => m.Id == id);

            await _userManager.AddToRoleAsync(userId, "organizer");

            await _context.SaveChangesAsync();

            return RedirectToPage("/Index");
            // return RedirectToPage("/JoinedEvents");
        }
    }
}

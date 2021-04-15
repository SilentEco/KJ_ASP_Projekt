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

            
           

            await _context.SaveChangesAsync();

            

        }

        public async Task<IActionResult> OnPost(string id )
        {
            if (id == null)
            {
                return NotFound();
            }


            
            var userId = await _context.Users.FirstOrDefaultAsync(m => m.Id == id);

            //var isOrganizer = await _userManager.IsInRoleAsync(userId, "organizer");

            if(await _userManager.IsInRoleAsync(userId, "organizer"))
            {
                await _userManager.RemoveFromRoleAsync(userId, "organizer");
            }
            else
            {
                await _userManager.AddToRoleAsync(userId, "organizer");
            }
            

            await _context.SaveChangesAsync();

            return RedirectToPage(this);
        }
    }
}

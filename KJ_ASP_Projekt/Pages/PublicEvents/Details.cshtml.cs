using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KJ_ASP_Projekt.Data;
using KJ_ASP_Projekt.Model;

namespace KJ_ASP_Projekt.Pages.PublicEvents
{
    public class DetailsModel : PageModel
    {
        private readonly KJ_ASP_Projekt.Data.ApplicationDbContext _context;

        public DetailsModel(KJ_ASP_Projekt.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Event Event { get; set; }
        public bool SuccessfullyJoined { get; set; }
        public bool Joined { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {

            Joined = AlreadyJoined(id);
            SuccessfullyJoined = false;
            if (id == null)
            {
                return NotFound();
            }

            Event = await _context.Events.FirstOrDefaultAsync(m => m.Id == id);

            if (Event == null)
            {
                return NotFound();
            }
            return Page();
        }
        public async Task<IActionResult> OnPostAsync(int? id)
        {
            var user = User.Identity;

            var userModel = _context.Users.Include(j => j.JoinedEvents).FirstOrDefault(m => m.UserName == user.Name);

            if (userModel == null)
            {
                return RedirectToPage("/Account/Login", new { area = "Identity" });
            }
            SuccessfullyJoined = true;
            Event = await _context.Events.FirstOrDefaultAsync(m => m.Id == id);
            


            userModel.JoinedEvents.Add(Event);
            await _context.SaveChangesAsync();
            return Page();
        }

        public bool AlreadyJoined(int? id)
        {
            Event = _context.Events.FirstOrDefault(m => m.Id == id);
            
            var user = User.Identity;
            var userModel = _context.Users.Include(j => j.JoinedEvents).FirstOrDefault(m => m.UserName == user.Name);
            if (userModel == null)
            {
                return false;
            }
            if (userModel.JoinedEvents.Contains(Event))
            {
                return true;
            }
            else return false;
        }
    }
   
}

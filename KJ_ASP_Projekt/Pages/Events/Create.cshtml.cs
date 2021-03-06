using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using KJ_ASP_Projekt.Data;
using KJ_ASP_Projekt.Model;

namespace KJ_ASP_Projekt.Pages.Events
{
    public class CreateModel : PageModel
    {
        private readonly KJ_ASP_Projekt.Data.ApplicationDbContext _context;

        public CreateModel(KJ_ASP_Projekt.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            var user = User.Identity;

            var userModel = _context.Users.FirstOrDefault(m => m.UserName == user.Name);

            if (userModel.OrganizerTitle == null)
            {
                return RedirectToPage("/Account/Manage/Index", new { area = "Identity" });
            }
            return Page();
        }

        [BindProperty]
        public Event Event { get; set; }

        public User Users { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var user = User.Identity;

            var userModel =  _context.Users.FirstOrDefault(m => m.UserName == user.Name);
            Event.Organizer = userModel;
            _context.Events.Add(Event);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}

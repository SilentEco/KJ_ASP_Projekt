using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KJ_ASP_Projekt.Data;
using KJ_ASP_Projekt.Model;

namespace KJ_ASP_Projekt.Pages.Events
{
    public class IndexModel : PageModel
    {
        private readonly KJ_ASP_Projekt.Data.ApplicationDbContext _context;

        public IndexModel(KJ_ASP_Projekt.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Event> Event { get;set; }

        public List<User> Users { get; set; }

        public async Task OnGetAsync()
        {
            Event = await _context.Events.ToListAsync();

            Users = await _context.Users.ToListAsync();
        }
    }
}

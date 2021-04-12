using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KJ_ASP_Projekt.Data;
using KJ_ASP_Projekt.Model;

namespace KJ_ASP_Projekt.Pages.PersonalEventList
{
    public class PersonalListModel : PageModel
    {
        private readonly KJ_ASP_Projekt.Data.ApplicationDbContext _context;

        public PersonalListModel(KJ_ASP_Projekt.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Event> Event { get;set; }

        public List<Event> JoinedEvents { get; set; }

        public async Task OnGetAsync()
        {
            var user = User.Identity;

            var userModel = _context.Users.FirstOrDefault(m => m.UserName == user.Name);

            Event = await _context.Events.Include(a => a.Attendees).ToListAsync();

            JoinedEvents = new List<Event>();

            foreach (var item in Event)
            {
                if (item.Attendees.Contains(userModel))
                {
                    JoinedEvents.Add(item);
                }
            }
        }
    }
}

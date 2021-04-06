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

namespace KJ_ASP_Projekt.Pages.Admin
{
    [Authorize(Roles ="admin")]
    public class UsersListModel : PageModel
    {
        private readonly KJ_ASP_Projekt.Data.ApplicationDbContext _context;

        public UsersListModel(KJ_ASP_Projekt.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        

        public List<User> Users { get; set; }

        public async Task OnGetAsync()
        {
            

            Users = await _context.Users.ToListAsync();

        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace KJ_ASP_Projekt.Model
{
    public class User : IdentityUser
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        [InverseProperty("Organizer")]
        public List<Event> HostedEvents { get; set; }

        [InverseProperty("Attendees")]
        public List<Event> JoinedEvents { get; set; }
    }
}

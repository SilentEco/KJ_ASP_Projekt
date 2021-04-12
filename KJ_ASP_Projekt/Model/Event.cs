using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KJ_ASP_Projekt.Model
{
    public class Event
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Place { get; set; }

        public string Adress { get; set; }

        public DateTime Date { get; set; }

        public int SpotsAvailable { get; set; }

        public User Organizer { get; set; }

        public List<User> Attendees { get; set; }


    }
}

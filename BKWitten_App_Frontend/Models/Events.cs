using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BKWitten_App_Frontend.Models
{
    public class Events
    {
        public int EventID { get; set; }

        [Required(ErrorMessage = "Event title is required")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Event description is required")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Start date is required")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "End date is required")]
     
        public DateTime EndDate { get; set; }

        public int UserID { get; set; }  // Fremdschlüssel zu User

        public Users User { get; set; }
        public class EventsVM { 
        
            public List<Events>? Events { get; set; }
            public int skip { get; set; }
            public int limit { get; set; }
            public int total { get; set; }
        }
    }
}

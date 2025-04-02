using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BKWitten_App_Frontend.Models
{
    public class Users
    {
        public int UserID { get; set; }  // Primärschlüssel
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool IsTeacher { get; set; }
        public bool IsAdmin { get; set; }
        public string Password { get; set; } 
        public string? TelNr { get; set; }  // Telefonnummer (optional)
        public ICollection<Posts> Posts { get; set; }  // Beziehung zu Posts (1-N)
        public Users() { }
    }
}

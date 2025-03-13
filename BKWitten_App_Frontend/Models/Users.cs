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
        [Required(ErrorMessage = "First name is required")]
        [StringLength(100, ErrorMessage = "First name can't be longer than 100 characters")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        [StringLength(100, ErrorMessage = "Last name can't be longer than 100 characters")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }

        public bool IsTeacher { get; set; }
        public bool IsAdmin { get; set; }

        [Required]
        public string PassHash { get; set; }  // Gehashter Passwort-String

        public string? TelNr { get; set; }  // Telefonnummer (optional)

        public ICollection<Posts> Posts { get; set; }  // Beziehung zu Posts (1-N)
        public Users() { }
    }
}

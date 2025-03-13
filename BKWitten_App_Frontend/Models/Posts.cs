using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BKWitten_App_Frontend.Models
{
    public class Posts
    {
        public int PostID { get; set; }  // Primärschlüssel

        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }

        public DateTime CreationDate { get; set; }
        public DateTime? PublishDate { get; set; }

        public int Likes { get; set; }

        public int ViewCount { get; set; }
        public bool IsPending { get; set; }
        public string? Category { get; set; }

        public int UserID { get; set; }  // Fremdschlüssel zu User

        public Users User { get; set; }  // Beziehung zum User

        public ICollection<Media> Media { get; set; }  // 1-N Beziehung zu Media
        public Posts() { }      
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BKWitten_App_Frontend.Models
{
    public class Media
    {
        public int MediaID { get; set; }  // Primärschlüssel

        [Required(ErrorMessage = "Alt text is required")]
        public string AltText { get; set; }

        public bool IsVideo { get; set; }

        [Required(ErrorMessage = "File path is required")]
        public string FilePath { get; set; }

        public long FileSize { get; set; }
        public string FileType { get; set; }

        public int PostID { get; set; }  // Fremdschlüssel zu Post
        public Posts Post { get; set; }  // Beziehung zum Post
        public Media() { }
    }
}

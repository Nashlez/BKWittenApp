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
        public string AltText { get; set; }
        public bool IsVideo { get; set; }
        public string FilePath { get; set; }
        public long FileSize { get; set; }
        public string FileType { get; set; }
        public int PostID { get; set; }  // Fremdschlüssel zu Post
        public Posts Post { get; set; }  // Beziehung zum Post
        public Media() { }
    }
}

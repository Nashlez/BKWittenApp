using System;
using System.ComponentModel.DataAnnotations;

namespace BKWitten_App_Frontend.Models
{
    public class Events
    {
        public int EventID { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Url { get; set; }
        public string? Type { get; set; }
        public int UserID { get; set; }
        public Users User { get; set; }
    }
}

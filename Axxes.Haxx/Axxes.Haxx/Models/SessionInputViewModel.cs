using System;
using System.ComponentModel.DataAnnotations;

namespace Axxes.Haxx.Models
{
    public class SessionInputViewModel
    {
        [Required]
        [Display(Name = "Title")]
        [MaxLength(200)]
        public string Title { get; set; }
        [Required]
        [Display(Name = "Date")]
        public DateTime Date { get; set; }
        [Display(Name = "Description")]
        public string Description { get; set; }
        [Display(Name = "Category")]
        public string Category { get; set; }
        [Display(Name = "Public presentation")]
        public bool IsPublic { get; set; }
    }
}

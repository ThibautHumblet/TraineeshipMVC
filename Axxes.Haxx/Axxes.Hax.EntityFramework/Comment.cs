using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Axxes.Haxx.EntityFramework
{
    public class Comment
    {
        public Comment()
        {
            Date = DateTime.UtcNow;
        }

        public int Id { get; set; }
        [Required]
        public string Text { get; set; }
        [Required]
        public DateTime Date { get; set; }
        public string AuthorId { get; set; }
        public virtual ApplicationUser Author { get; set; }
        public int SessionId { get; set; }
        [Required]
        public virtual Session Session { get; set; }
    }
}

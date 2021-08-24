using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Axxes.Haxx.EntityFramework
{
    public class Session
    {
        public Session()
        {
            IsPublic = true;
            Date = DateTime.UtcNow;
            Comments = new HashSet<Comment>();
        }

        public int Id { get; set; }
        [Required]
        [MaxLength(200)]
        public string Title { get; set; }
        [Required]
        public DateTime Date { get; set; }
        public string SpeakerId { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public bool IsPublic { get; set; }
        public virtual ApplicationUser Speaker { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}

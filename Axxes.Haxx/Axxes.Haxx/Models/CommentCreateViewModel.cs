using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Axxes.Haxx.Models
{
    public class CommentCreateViewModel
    {
        public int SessionId { get; set; }

        [Required]
        [DisplayName("Comment")]
        public string Text { get; set; }
    }
}

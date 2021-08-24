using Axxes.Haxx.EntityFramework;
using System;
using System.Linq.Expressions;

namespace Axxes.Haxx.Models
{
    public class CommentViewModel
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
        public ApplicationUser Author { get; set; }
        public Session Session { get; set; }

        public static Expression<Func<Comment, CommentViewModel>> ViewModel
        {
            get
            {
                return comment => new CommentViewModel
                {
                    Id = comment.Id,
                    Text = comment.Text,
                    Date = comment.Date,
                    Author = comment.Author,
                    Session = comment.Session
                };
            }
        }
    }
}

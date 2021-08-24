using Axxes.Haxx.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Axxes.Haxx.Models
{
    public class SessionViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string Category { get; set; }
        public ApplicationUser Speaker { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public bool IsPublic { get; set; }

        public static Expression<Func<Session, SessionViewModel>> ViewModel
        {
            get
            {
                return session => new SessionViewModel
                {
                    Id = session.Id,
                    Title = session.Title,
                    Date = session.Date,
                    Speaker = session.Speaker,
                    Category = session.Category,
                    IsPublic = session.IsPublic
                };
            }
        }
    }
}

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace Axxes.Haxx.EntityFramework.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Session> Sessions { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            CreateSessions(builder);
        }

        private void CreateSessions(ModelBuilder builder)
        {
            builder.Entity<Session>().HasData(new Session
            {
                Id = 1,
                Title = "Allround .NET",
                Date = DateTime.UtcNow.AddDays(-5),
                Description = "Allround .NET session",
                Category = ".NET",
                IsPublic = true
            }, new Session
            {
                Id = 2,
                Title = "Allround Java",
                Date = DateTime.UtcNow.AddDays(5),
                Description = "Allround Java session",
                Category = "Java",
                IsPublic = true
            }, new Session
            {
                Id = 3,
                Title = "VS Code basics",
                Date = DateTime.UtcNow.AddDays(-2),
                Description = "Basics about Visual Studio code",
                Category = "General",
                IsPublic = false
            });

            builder.Entity<Comment>().HasData(new Comment
            {
                Id = 1,
                Date = DateTime.UtcNow,
                Text = "Nice session",
                SessionId = 1
            }, new Comment
            {
                Id = 2,
                Date = DateTime.UtcNow,
                Text = "Interesting",
                SessionId = 3
            });
        }
    }
}

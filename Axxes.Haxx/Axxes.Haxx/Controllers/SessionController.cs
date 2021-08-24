using Axxes.Haxx.EntityFramework;
using Axxes.Haxx.EntityFramework.Data;
using Axxes.Haxx.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Security.Claims;

namespace Axxes.Haxx.Controllers
{
    [Authorize]
    public class SessionController : BaseController
    {
        public SessionController(ApplicationDbContext db, UserManager<ApplicationUser> userManager) : base(db, userManager)
        {
        }

        public IActionResult Create()
        {
            return View("CreateSessionViewModel");
        }

        [HttpPost]
        public IActionResult Create(SessionInputViewModel model)
        {
            if (model != null && ModelState.IsValid)
            {
                var currentUser = this.User.FindFirst(ClaimTypes.NameIdentifier);
                var currentUserId = currentUser?.Value;

                var newSession = new Session
                {
                    Title = model.Title,
                    Date = model.Date,
                    Description = model.Description,
                    SpeakerId = currentUserId,
                    Category = model.Category,
                    IsPublic = model.IsPublic
                };

                Db.Add(newSession);
                Db.SaveChanges();

                return RedirectToAction("MySessions");
            }

            return View("CreateSessionViewModel");
        }

        public IActionResult MySessions()
        {
            var currentUser = this.User.FindFirst(ClaimTypes.NameIdentifier);
            var currentUserId = currentUser?.Value;

            var sessions = this.Db.Sessions
                .Where(session => session.SpeakerId == currentUserId)
                .OrderBy(session => session.Date)
                .Select(SessionViewModel.ViewModel);

            var upcomingPersonalSessions = sessions.Where(session => session.Date >= DateTime.UtcNow);
            var passedPersonalSessions = sessions.Where(session => session.Date < DateTime.UtcNow);

            return View("MySessionsViewModel", new UpcomingPassedSessionsViewModel
            {
                UpcomingSessions = upcomingPersonalSessions,
                PassedSessions = passedPersonalSessions
            });
        }

        public IActionResult Edit(int id)
        {
            var session = this.Db.Sessions
            .Where(session => session.Id == id)
            .Select(SessionViewModel.ViewModel)
            .FirstOrDefault();

            var sessionDetail = this.Db.Sessions
                .Where(session => session.Id == id)
                .Select(SessionDetailsViewModel.ViewModel)
                .FirstOrDefault();

            return View("EditSessionViewModel", new SessionInputViewModel
            {
                Title = session.Title,
                Category = session.Category,
                Date = session.Date,
                IsPublic = session.IsPublic,
                Description = sessionDetail.Description
            });
        }

        [HttpPost]
        public IActionResult Edit(SessionInputViewModel model)
        {
            if (model != null && ModelState.IsValid)
            {
                var currentUser = this.User.FindFirst(ClaimTypes.NameIdentifier);
                var currentUserId = currentUser?.Value;

                var editSession = new Session
                {
                    Title = model.Title,
                    Date = model.Date,
                    Description = model.Description,
                    SpeakerId = currentUserId,
                    Category = model.Category,
                    IsPublic = model.IsPublic
                };

                Db.Add(editSession);
                Db.SaveChanges();

                return RedirectToAction("MySessions");
            }

            return View("EditSessionViewModel", model);
        }

        public IActionResult Delete(int id)
        {
            var session = this.Db.Sessions
                .Where(session => session.Id == id)
                .Select(SessionViewModel.ViewModel)
                .FirstOrDefault();

            var sessionDetail = this.Db.Sessions
                .Where(session => session.Id == id)
                .Select(SessionDetailsViewModel.ViewModel)
                .FirstOrDefault();

            return View("DeleteSessionViewModel", new SessionInputViewModel
            {
                Title = session.Title,
                Category = session.Category,
                Date = session.Date,
                IsPublic = session.IsPublic,
                Description = sessionDetail.Description
            });
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteSession(int id)
        {
            var session = this.Db.Sessions
                .Where(session => session.Id == id)
                .FirstOrDefault();
            if (session != null)
            {
                Db.Sessions.Remove(session);
                Db.SaveChanges();
            }
            return RedirectToAction("MySessions");
        }
    }
}

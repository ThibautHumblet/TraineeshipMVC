using Axxes.Haxx.EntityFramework;
using Axxes.Haxx.EntityFramework.Data;
using Axxes.Haxx.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;

namespace Axxes.Haxx.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(ApplicationDbContext db, UserManager<ApplicationUser> userManager) : base(db, userManager)
        {
        }

        public IActionResult Index()
        {
            var sessions = this.Db.Sessions
                .Where(session => session.IsPublic)
                .OrderBy(session => session.Date)
                .Select(SessionViewModel.ViewModel);

            var upcomingSessions = sessions.Where(session => session.Date >= DateTime.UtcNow);
            var passedSessions = sessions.Where(session => session.Date < DateTime.UtcNow);

            return View(new UpcomingPassedSessionsViewModel
            {
                UpcomingSessions = upcomingSessions,
                PassedSessions = passedSessions
            });
        }

        public IActionResult OpenDetailsViewModel([FromRoute] int id)
        {
            var currentUser = this.User.FindFirst(ClaimTypes.NameIdentifier);
            var currentUserId = currentUser?.Value;
            var isAdmin = this.IsAdmin();
            var sessionDetails = this.Db.Sessions
                .Where(e => e.Id == id)
                .Where(e => e.IsPublic || isAdmin || (e.SpeakerId != null && e.SpeakerId == currentUserId))
                .Select(SessionDetailsViewModel.ViewModel)
                .FirstOrDefault();

            var isOwner = (sessionDetails != null && sessionDetails.SpeakerId != null &&
                           sessionDetails.SpeakerId == currentUserId);

            this.ViewBag.CanEdit = isOwner || isAdmin;

            return this.PartialView("_SessionDetailsPartial", sessionDetails);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

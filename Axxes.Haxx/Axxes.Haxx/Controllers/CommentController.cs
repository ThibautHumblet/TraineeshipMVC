using Axxes.Haxx.EntityFramework;
using Axxes.Haxx.EntityFramework.Data;
using Axxes.Haxx.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace Axxes.Haxx.Controllers
{
    public class CommentController : BaseController
    {
        public CommentController(ApplicationDbContext db, UserManager<ApplicationUser> userManager) : base(db, userManager)
        {
        }

        public IActionResult Create(int id)
        {
            var model = new CommentCreateViewModel
            {
                SessionId = id
            };
            return PartialView("_CreateComment", model);
        }

        [HttpPost]
        public IActionResult Create(int id, CommentCreateViewModel model)
        {
            if (model != null && ModelState.IsValid)
            {
                var comment = new Comment
                {
                    AuthorId = UserManager.GetUserId(this.User),
                    Text = model.Text,
                    Date = DateTime.Now,
                    SessionId = id
                };

                this.Db.Comments.Add(comment);
                this.Db.SaveChanges();
                return RedirectToAction("ReplaceCommentsList", new
                {
                    id
                });
            }
            return View(model);
        }

        public IActionResult ReplaceCommentsList(int id)
        {
            var comments = this.Db.Comments
                .Where(session => session.SessionId == id)
                .Select(CommentViewModel.ViewModel);

            var model = new SessionDetailsViewModel
            {
                Comments = comments
            };
            return PartialView("_CommentViewModel", model);
        }
    }
}

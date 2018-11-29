using System.Web.Mvc;
using Lab._06.MVC.BL.CommentsService;
using Lab._06.MVC.BL.DTO;
using Lab._06.MVC.Web.Models;
using Microsoft.AspNet.Identity;

namespace Lab._06.MVC.Web.Controllers
{
    public class CommentsController : Controller
    {
        private readonly ICommentsService commentsService;

        public CommentsController(ICommentsService commentsService)
        {
            this.commentsService = commentsService;
        }

        [Authorize]
        public ActionResult AddComment() => PartialView();

        [HttpPost]
        [Authorize]
        public ActionResult AddComment(CommentsModel model)
        {
            if (ModelState.IsValid)
            {
                var commentDto = new CommentsDto
                {
                    MovieId = model.MovieAddCommentsId,
                    Comment = model.UserComment,
                    Id = HttpContext.User.Identity.GetUserId(),
                    UserName = HttpContext.User.Identity.GetUserName(),
                    CommentRating = 0
                };
                commentsService.Create(commentDto);
            }
            return RedirectToAction("GetCurrentMovie", "Movie", new { movieid = model.MovieAddCommentsId });
        }

        [Authorize]
        public ActionResult RemoveComment(int commentId, int movieId)
        {
            commentsService.Remove(commentId);
            return RedirectToAction("GetCurrentMovie", "Movie", new { movieId });
        }
    }
}
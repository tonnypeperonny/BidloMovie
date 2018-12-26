using System.Linq;
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
        private readonly MapperWeb mapper;

        public CommentsController(ICommentsService commentsService, MapperWeb mapper)
        {
            this.commentsService = commentsService;
            this.mapper = mapper;
        }

        [HttpGet]
        [Authorize]
        public ActionResult AddComment() => PartialView();

        [HttpPost]
        [Authorize]
        public JsonResult AddComment(AddCommentViewModel model)
        {
            if (ModelState.IsValid)
            {
                var commentDto = new UserCommentDto
                {
                    MovieID = model.MovieID,
                    UserComment = model.UserComment,
                    UserID = HttpContext.User.Identity.GetUserId(),
                    UserName = HttpContext.User.Identity.GetUserName(),
                    CommentRating = 0
                };
                commentsService.Create(commentDto);
                return Json(new { success = true, responseText = "Comment was added." });
            }
            return Json(new { success = false, responseText = "Error during comment adding." });
        }

        [HttpPost]
        [Authorize]
        public ActionResult GetAllMovieComments(int movieID)
        {
            return PartialView("GetAllMovieCommentsPartial", mapper.CreateMap(commentsService.GetAllMovieComments(movieID).Reverse()));
        }

        [Authorize]
        public ActionResult RemoveComment(int commentId, int movieId)
        {
            commentsService.Remove(commentId);
            return RedirectToAction("GetCurrentMovie", "Movie", new { movieId });
        }
    }
}
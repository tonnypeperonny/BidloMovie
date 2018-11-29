using Lab._06.MVC.BL.DTO;
using Lab._06.MVC.DL.Models;
using Lab._06.MVC.DL.Uow;

namespace Lab._06.MVC.BL.CommentsService
{
    public class CommentsService : ICommentsService
    {
        private readonly IUow uow;

        public CommentsService(IUow uow)
        {
            this.uow = uow;
        }

        public void Create(CommentsDto commentDto)
        {
           var userComment = new UserComment
                {
                   Comment = commentDto.Comment,
                   MovieId = commentDto.MovieId,
                   Id = commentDto.Id,
                   UserName = commentDto.UserName
                };
            uow.CommentsRepository.Create(userComment);
            uow.Save();
        }

        public void Remove(int commentId)
        {
            var comment = uow.CommentsRepository.GetById(commentId);
            uow.CommentsRepository.Delete(comment);
            uow.Save();
        }
    }
}

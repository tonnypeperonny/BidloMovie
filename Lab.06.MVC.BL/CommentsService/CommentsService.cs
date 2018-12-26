using System.Collections.Generic;
using System.Linq;
using Lab._06.MVC.BL.DTO;
using Lab._06.MVC.BL.DTO.Mapper;
using Lab._06.MVC.DL.Models;
using Lab._06.MVC.DL.Uow;

namespace Lab._06.MVC.BL.CommentsService
{
    public class CommentsService : ICommentsService
    {
        private readonly IUow uow;
        private readonly MapperBL mapper;

        public CommentsService(IUow uow, MapperBL mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }

        public void Create(UserCommentDto commentDto)
        {
           var userComment = new UserComment
                {
                   Comment = commentDto.UserComment,
                   MovieID = commentDto.MovieID,
                   UserID = commentDto.UserID,
                   UserName = commentDto.UserName
                };
            uow.CommentsRepository.Create(userComment);
            uow.Save();
        }

        public IEnumerable<UserCommentDto> GetAllMovieComments(int movieID)
        {
            return uow.CommentsRepository.GetAllMovieComments(movieID).Select(comment => mapper.CreateMap(comment));
        }

        public void Remove(int commentId)
        {
            var comment = uow.CommentsRepository.GetById(commentId);
            uow.CommentsRepository.Delete(comment);
            uow.Save();
        }
    }
}

using System.Collections.Generic;
using Lab._06.MVC.BL.DTO;

namespace Lab._06.MVC.BL.CommentsService
{
    public interface ICommentsService
    {
        void Create(UserCommentDto commentDto);
        void Remove(int commentId);
        IEnumerable<UserCommentDto> GetAllMovieComments(int movieID);
    }
}
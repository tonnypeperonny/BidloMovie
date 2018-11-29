using Lab._06.MVC.BL.DTO;

namespace Lab._06.MVC.BL.CommentsService
{
    public interface ICommentsService
    {
        void Create(CommentsDto commentDto);
        void Remove(int commentId);
    }
}
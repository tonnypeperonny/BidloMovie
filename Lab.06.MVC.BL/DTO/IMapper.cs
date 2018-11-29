using Lab._06.MVC.DL.Models;

namespace Lab._06.MVC.BL.DTO
{
    public interface IMapper
    {
        MovieDto MovieMapper(Movie movie);
        CommentsDto CommentMapper(UserComment userComment);
    }
}
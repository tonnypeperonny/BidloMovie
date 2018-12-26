using System.Collections.Generic;
using System.Linq;
using Lab._06.MVC.BL.DTO;
using Mapper;

namespace Lab._06.MVC.Web.Models
{
    public class MapperWeb : IMapper<MovieDto, MovieViewModel>, IMapper<UserCommentDto, UserCommentViewModel>
    {
        public MovieViewModel CreateMap(MovieDto entity) => new MovieViewModel
        {
            MovieID = entity.MovieID,
            MovieName = entity.MovieName,
            MoviePoster = entity.MoviePoster,
            UserMovieNote = entity.UserMovieNote
        };

        public UserCommentViewModel CreateMap(UserCommentDto entity) => new UserCommentViewModel
        {
            MovieID = entity.MovieID,
            UserComment = entity.UserComment,
            CommentID = entity.CommentID,
            CommentRating = entity.CommentRating,
            UserID = entity.UserID,
            UserName = entity.UserName
        };

        public IEnumerable<UserCommentViewModel> CreateMap(IEnumerable<UserCommentDto> entities)
        {
            return entities.Select(CreateMap);
        }
    }
}
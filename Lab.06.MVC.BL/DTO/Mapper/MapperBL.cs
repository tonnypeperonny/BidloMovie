using System.Collections.Generic;
using Lab._06.MVC.DL.Models;
using Mapper;

namespace Lab._06.MVC.BL.DTO.Mapper
{
    public class MapperBL : IMapper<Movie,MovieDto> , IMapper<UserComment,UserCommentDto>
    {
        public MovieDto CreateMap(Movie movie) => new MovieDto
        {
            MovieID = movie.MovieID,
            MovieName = movie.MovieName,
            MoviePoster = movie.MoviePoster,
            UserMovieNote = movie.UserMovieNote
        };

        public UserCommentDto CreateMap(UserComment userComment) => new UserCommentDto
        {
            UserComment = userComment.Comment,
            CommentID = userComment.CommentId,
            UserID = userComment.UserID,
            MovieID = userComment.MovieId,
            UserName = userComment.UserName,
            CommentRating = userComment.CommentRating
        };
    }
}

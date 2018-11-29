using System.Collections.Generic;
using Lab._06.MVC.DL.Models;

namespace Lab._06.MVC.BL.DTO
{
    public class Mapper : IMapper
    {
        public MovieDto MovieMapper(Movie movie)
        {
            var dtomovie = new MovieDto
            {
                MovieId = movie.MovieId,
                MovieName = movie.MovieName,
                MoviePoster = movie.MoviePoster,
                UserMovieNote = movie.UserMovieNote,
                MovieComments = new List<CommentsDto>()
            };

            foreach (var item in movie.MovieComments)
            {
                dtomovie.MovieComments.Add(CommentMapper(item));
            }

            dtomovie.MovieComments.Reverse();
            return dtomovie;
        }

        public CommentsDto CommentMapper(UserComment userComment) => new CommentsDto
        {
            Comment = userComment.Comment,
            CommentId = userComment.CommentId,
            Id = userComment.Id,
            MovieId = userComment.MovieId,
            UserName = userComment.UserName,
            CommentRating = userComment.CommentRating
        };
    }
}

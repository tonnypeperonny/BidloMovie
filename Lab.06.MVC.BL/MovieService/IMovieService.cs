using System.Collections.Generic;
using Lab._06.MVC.BL.DTO;

namespace Lab._06.MVC.BL.MovieService
{
    public interface IMovieService<T>
        where T : class
    {
        void Create(MovieDto movieDto);
        void Remove(string movieName);
        List<T> AllMovies { get; }

        MovieDto GetCurrentMovie(int movieid);
        void Update(MovieDto movieDto);
    }
}
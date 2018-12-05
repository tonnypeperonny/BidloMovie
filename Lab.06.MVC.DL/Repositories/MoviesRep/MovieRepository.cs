using System.Collections.Generic;
using System.Linq;
using Lab._06.MVC.DL.Context;
using Lab._06.MVC.DL.Models;

namespace Lab._06.MVC.DL.Repositories.MoviesRep
{
    public class MovieRepository : IMovieRepository<Movie>
    {
        private readonly MovieLibraryContext context;

        public MovieRepository(MovieLibraryContext context)
        {
            this.context = context;
        }

        public List<Movie> GetAll() => context.Movies.ToList();

        public Movie GetById(int id) => context.Movies.SingleOrDefault(s => s.MovieID == id);

        public Movie GetByName(string moviename) => context.Movies.SingleOrDefault(s => s.MovieName == moviename);

        public void Create(Movie entity) => context.Movies.Add(entity);

        public void Update(Movie entity)
        {
            var oldEntity = context.Movies.Find(entity.MovieID);
            if (entity.MoviePoster == null)
            {
                entity.MoviePoster = oldEntity.MoviePoster;
            }
            context.Entry(oldEntity).CurrentValues.SetValues(entity);
        }

        public void Delete(Movie entity) => context.Movies.Remove(entity);
    }
}

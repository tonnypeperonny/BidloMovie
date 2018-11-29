using System.Collections.Generic;

namespace Lab._06.MVC.DL.Repositories.MoviesRep
{
    public interface IMovieRepository<T>
        where T : class
    {
        List<T> GetAll();
        T GetById(int id);
        T GetByName(string moviename);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
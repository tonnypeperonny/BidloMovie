using System.Collections.Generic;

namespace Lab._06.MVC.DL.Repositories.CommentsRep
{
    public interface ICommentsRepository<T>
        where T : class
    {
        List<T> GetAll();
        T GetById(int id);
        List<T> GetAllMovieComments(int movieId);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
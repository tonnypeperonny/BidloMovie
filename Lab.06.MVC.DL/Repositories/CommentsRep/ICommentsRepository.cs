using System.Collections.Generic;
using Lab._06.MVC.DL.Models;

namespace Lab._06.MVC.DL.Repositories.CommentsRep
{
    public interface ICommentsRepository<T>
        where T : class
    {
        T GetById(int id);
        IEnumerable<UserComment> GetAllMovieComments(int movieId);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
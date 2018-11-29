using System.Collections.Generic;
using System.Linq;
using Lab._06.MVC.DL.Context;
using Lab._06.MVC.DL.Models;

namespace Lab._06.MVC.DL.Repositories.CommentsRep
{
    public class CommentsRepository : ICommentsRepository<UserComment>
    {
        private readonly MovieLibraryContext context;

        public CommentsRepository(MovieLibraryContext context)
        {
            this.context = context;
        }

        public List<UserComment> GetAll() => context.Comments.ToList();

        public UserComment GetById(int id) => context.Comments.SingleOrDefault(s => s.CommentId == id);

        public List<UserComment> GetAllMovieComments(int movieId) => GetAll().Where(x => x.MovieId == movieId).ToList();

        public List<UserComment> GetAllUserComments(int userId) => GetAll().Where(x => x.Id == userId.ToString()).ToList();

        public void Create(UserComment entity) => context.Comments.Add(entity);

        public void Update(UserComment entity)
        {
            var oldEntity = context.Comments.Find(entity.CommentId);
            context.Entry(oldEntity).CurrentValues.SetValues(entity);
        }

        public void Delete(UserComment entity) => context.Comments.Remove(entity);
    }
}

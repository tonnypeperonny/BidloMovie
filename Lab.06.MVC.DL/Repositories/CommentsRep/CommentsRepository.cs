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

        public UserComment GetById(int ID) => context.Comments.SingleOrDefault(s => s.CommentId == ID);

        public IEnumerable<UserComment> GetAllMovieComments(int movieID)
        {
            return context.Comments.Where(x => x.MovieID == movieID);
        }

        public List<UserComment> GetAllUserComments(int userID) => context.Comments.Where(x => x.UserID == userID.ToString()).ToList();

        public void Create(UserComment entity) => context.Comments.Add(entity);

        public void Update(UserComment entity)
        {
            var oldEntity = context.Comments.Find(entity.CommentId);
            context.Entry(oldEntity).CurrentValues.SetValues(entity);
        }

        public void Delete(UserComment entity) => context.Comments.Remove(entity);
    }
}

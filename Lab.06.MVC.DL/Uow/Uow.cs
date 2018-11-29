using System;
using Lab._06.MVC.DL.Context;
using Lab._06.MVC.DL.Models;
using Lab._06.MVC.DL.Repositories.CommentsRep;
using Lab._06.MVC.DL.Repositories.MoviesRep;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Lab._06.MVC.DL.Uow
{
    public class Uow : IUow
    {
        private readonly MovieLibraryContext context;
        private RoleManager<ApplicationRole> roleManager;
        private UserManager<ApplicationUser> userManager;
        private IMovieRepository<Movie> movieRepository;
        private ICommentsRepository<UserComment> commentsRepository;

        public Uow(MovieLibraryContext context)
        {
            this.context = context;
        }

        public RoleManager<ApplicationRole> RoleManager => roleManager ??
                                                           (roleManager = new RoleManager<ApplicationRole>(new RoleStore<ApplicationRole>(context)));

        public UserManager<ApplicationUser> UserManager => userManager ??
                                                           (userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context)));

        public IMovieRepository<Movie> MovieRepository => movieRepository ?? (movieRepository = new MovieRepository(context));

        public ICommentsRepository<UserComment> CommentsRepository => commentsRepository ?? (commentsRepository = new CommentsRepository(context));

        public void Save() => context.SaveChanges();

        private bool disposed;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed && disposing)
            {
                context.Dispose();
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}


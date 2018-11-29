using System;
using Lab._06.MVC.DL.Models;
using Lab._06.MVC.DL.Repositories.CommentsRep;
using Lab._06.MVC.DL.Repositories.MoviesRep;
using Microsoft.AspNet.Identity;

namespace Lab._06.MVC.DL.Uow
{
    public interface IUow : IDisposable
    {
        RoleManager<ApplicationRole> RoleManager { get; }
        UserManager<ApplicationUser> UserManager { get; }
        IMovieRepository<Movie> MovieRepository { get; }
        ICommentsRepository<UserComment> CommentsRepository { get; }
        void Save();
    }
}
using Autofac;
using Lab._06.MVC.BL.CommentsService;
using Lab._06.MVC.BL.DTO;
using Lab._06.MVC.BL.MovieService;
using Lab._06.MVC.BL.UserService;
using Lab._06.MVC.DL.Context;
using Lab._06.MVC.DL.Models;
using Lab._06.MVC.DL.Repositories.CommentsRep;
using Lab._06.MVC.DL.Repositories.MoviesRep;
using Lab._06.MVC.DL.Uow;

namespace Lab._06.MVC.Ioc
{
    public class Autofac
    {
        public ContainerBuilder ConfigureContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<MovieService>().As<IMovieService<MovieDto>>().InstancePerRequest();
            builder.RegisterType<UserService>().As<IUserService>().InstancePerRequest();
            builder.RegisterType<MovieRepository>().As<IMovieRepository<Movie>>().InstancePerRequest();
            builder.RegisterType<Uow>().As<IUow>().InstancePerRequest();
            builder.RegisterType<MovieLibraryContext>().AsSelf().InstancePerRequest();
            builder.RegisterType<CommentsRepository>().As<ICommentsRepository<UserComment>>().InstancePerRequest();
            builder.RegisterType<CommentsService>().As<ICommentsService>().InstancePerRequest();
            builder.RegisterType<Mapper>().As<IMapper>().InstancePerRequest();
            return builder;
        }
    }
}


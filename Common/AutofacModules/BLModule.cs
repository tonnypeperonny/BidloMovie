using Autofac;
using Lab._06.MVC.DL.Context;
using Lab._06.MVC.DL.Models;
using Lab._06.MVC.DL.Repositories.CommentsRep;
using Lab._06.MVC.DL.Repositories.MoviesRep;

namespace Common.AutofacModules
{
    public class BLModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<MovieRepository>().As<IMovieRepository<Movie>>().InstancePerRequest();
            builder.RegisterType<CommentsRepository>().As<ICommentsRepository<UserComment>>().InstancePerRequest();
            builder.RegisterType<MovieLibraryContext>().AsSelf().InstancePerRequest();
            base.Load(builder);
        }
    }
}

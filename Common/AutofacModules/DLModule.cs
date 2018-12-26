using Autofac;
using Lab._06.MVC.BL.CommentsService;
using Lab._06.MVC.BL.DTO;
using Lab._06.MVC.BL.DTO.Mapper;
using Lab._06.MVC.BL.MovieService;
using Lab._06.MVC.BL.UserService;
using Lab._06.MVC.DL.Uow;

namespace Common.AutofacModules
{
    public class DLModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<MovieService>().As<IMovieService<MovieDto>>().InstancePerRequest();
            builder.RegisterType<UserService>().As<IUserService>().InstancePerRequest();
            builder.RegisterType<CommentsService>().As<ICommentsService>().InstancePerRequest();
            builder.RegisterType<MapperBL>().AsSelf().SingleInstance();
            builder.RegisterType<Uow>().As<IUow>().InstancePerRequest();
            base.Load(builder);
        }
    }
}

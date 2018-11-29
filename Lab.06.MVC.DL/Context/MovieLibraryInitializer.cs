using System;
using System.Data.Entity;
using System.IO;
using Lab._06.MVC.DL.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Lab._06.MVC.DL.Context
{
    public class MovieLibraryInitializer : DropCreateDatabaseIfModelChanges<MovieLibraryContext>
    {
        protected override void Seed(MovieLibraryContext context)
        {
            var roleManager = new RoleManager<ApplicationRole>(new RoleStore<ApplicationRole>(context));
            roleManager.Create(new ApplicationRole { Name = "admin" });
            roleManager.Create(new ApplicationRole { Name = "user" });

            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            var user = new ApplicationUser { Email = "admin@admin.com", UserName = "admin" };
            userManager.Create(user, "123123q");

            var admin = userManager.FindByEmail(user.Email);
            userManager.AddToRole(admin.Id, "admin");
            userManager.AddToRole(admin.Id, "user");

            var appPath = AppDomain.CurrentDomain.BaseDirectory;

            var movie = new Movie
            {
                MovieName = "You Were Never Really Here",
                UserMovieNote = "A traumatized veteran, unafraid of violence, tracks down missing girls for a living." +
                                " When a job spins out of control, Joe's nightmares overtake him as a conspiracy is uncovered leading to what may be his death trip or his awakening.",
                MoviePoster = File.ReadAllBytes(appPath + "Content/dy_ipjnxkaaxdka.jpg")
            };
            var movie1 = new Movie
            {
                MovieName = "Mad Max: Fury Road",
                UserMovieNote = "In the furthest reaches of our planet, in a stark desert landscape where humanity is broken," +
                                " and everyone is fighting for the necessities of life, there are two rebels who just might be able to restore order—Max (Tom Hardy)," +
                                " a man of action and few words, who seeks peace of mind following the loss of his wife and child in the aftermath of the chaos, " +
                                "and Furiosa (Charlize Theron), a woman of action who believes her path to survival may be achieved if she can make it across the desert " +
                                "back to her childhood homeland.",
                MoviePoster = File.ReadAllBytes(appPath + "Content/Kilian-Eng-Mad-Max-Fury-Road-700x300.jpg")
            };
            context.Movies.Add(movie);
            context.Movies.Add(movie1);

            context.SaveChanges();
            base.Seed(context);
        }
    }
}

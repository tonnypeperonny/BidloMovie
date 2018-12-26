using System.Data.Entity;
using Lab._06.MVC.DL.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Lab._06.MVC.DL.Context
{
    public class MovieLibraryContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<UserComment> Comments { get; set; }

        public MovieLibraryContext()
            : base("MovieBase")
        {
            Database.SetInitializer(new MovieLibraryInitializer());
            Database.Initialize(false);
        }

        public static MovieLibraryContext Create() => new MovieLibraryContext();

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>().HasMany(file => file.MovieComments).WithRequired(x => x.Movie).HasForeignKey(x => x.MovieID);
            modelBuilder.Entity<ApplicationUser>().HasMany(x => x.UserComments).WithRequired(x => x.User)
                .HasForeignKey(x => x.UserID);
            base.OnModelCreating(modelBuilder);
        }
    }
}
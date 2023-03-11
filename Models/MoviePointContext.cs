using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MoviePoint.Models
{
    public class MoviePointContext : IdentityDbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Cinema> Cinemas { get; set; }
        public DbSet<Actor_Movie> Actor_Movies { get; set; }
        public DbSet<Producer> Producers { get; set; }

        public MoviePointContext() :base ()
        {

        }
        public MoviePointContext(DbContextOptions<MoviePointContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-RAGNM1O;Initial Catalog=MoviePointDB;Integrated Security=True;Encrypt=False");
            base.OnConfiguring(optionsBuilder);
        }
    }
}

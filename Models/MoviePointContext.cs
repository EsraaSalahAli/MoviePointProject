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

            //optionsBuilder.UseSqlServer(@"Data source=HADEER_SALAH\SQL19; initial catalog=MoviePointDB;integrated security = true; trust server certificate =true");
            //base.OnConfiguring(optionsBuilder);

            //optionsBuilder.UseSqlServer(@"Data source=.\SQL19; initial catalog = MoviePointDB; user id = Ghada_ITI; password=1111; trust server certificate = true");
            //base.OnConfiguring(optionsBuilder);
        }
    }
}

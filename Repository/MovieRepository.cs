using MoviePoint.Models;

namespace MoviePoint.Repository
{
    public class MovieRepository : IMovieRepository
    {
        MoviePointContext context;

        public MovieRepository()
        {
            context = new MoviePointContext();
        }

        public List<Movie> GetAll()
        {
            return context.Movies.ToList();
        }

        public Movie GetById(int id)
        {
            return context.Movies.FirstOrDefault(c => c.Id == id);
        }
        public void Insert(Movie movie)
        {
            context.Movies.Add(movie);
            context.SaveChanges();
        }
        public void Update(int id, Movie movie)
        {
            Movie org = GetById(id);
            org.Name = movie.Name;
            org.Price = movie.Price;
            org.ProducerID = movie.ProducerID;
            org.StartDate = movie.StartDate;
            org.Category = movie.Category;
            org.CinemaID = movie.CinemaID;
            org.Description = movie.Description;
            org.ImageUrl = movie.ImageUrl;
            org.EndtDate = movie.EndtDate;
            context.SaveChanges();
        }
        public void Delete(int id)
        {
            Movie org = GetById(id);
            context.Movies.Remove(org);
            context.SaveChanges();
        }
    }
}

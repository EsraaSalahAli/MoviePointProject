using MoviePoint.Models;

namespace MoviePoint.Repository
{
    public interface IMovieRepository
    {
        List<Movie> GetAll();
        Movie GetById(int id);
        void Insert(Movie movie);
        void Update(int id, Movie movie);
        void Delete(int id);
    }
}

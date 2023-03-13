using Microsoft.AspNetCore.Mvc;
using MoviePoint.Models;
using MoviePoint.Repository;

namespace MoviePoint.Controllers
{
	public class MovieController : Controller
	{
        IMovieRepository movieRepository;

        public MovieController
            (IMovieRepository _movRepo)
        {
            movieRepository = _movRepo; 
        }

        public IActionResult Index()
		{
            List<Movie> movies = movieRepository.GetAll();
			return View(movies);
		}
	}
}

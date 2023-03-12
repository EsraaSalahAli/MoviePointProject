using Microsoft.AspNetCore.Mvc;
using MoviePoint.Models;
using MoviePoint.Repository;
using MoviePoint.ViewModel;
using System.Diagnostics;

namespace MoviePoint.Controllers
{
    public class HomeController : Controller
    {
		IMovieRepository movieRepository;
		IActorRepository actorRepository;
		public HomeController
			(IMovieRepository _MovieRepo, IActorRepository _ActorRepo)//inject
		{
			movieRepository = _MovieRepo; 
			actorRepository = _ActorRepo; 
		}
		public IActionResult Home()
        {
			List<MovieWithActorViewModel> movieWithActorViewModels = new List<MovieWithActorViewModel>();
			List<Movie> movies = movieRepository.GetAll();
			List<Actor> actors = actorRepository.GetAll();

			//foreach (var itemMovie in movies)
			//{
			//	foreach (var itemVM in movieWithActorViewModels)
			//	{
			//		itemVM.MovieName = itemMovie.Name;
			//		itemVM.MovieDescription = itemMovie.Description;
			//		itemVM.MoviePicture = itemMovie.ImageUrl;
			//	}

			//}

			//foreach (var itemActor in actors)
			//{
			//	foreach (var itemVM in movieWithActorViewModels)
			//	{
			//		itemVM.ActorPicture = itemActor.ProfilePicUrl;
			//	}

			//}

			foreach (var itemVM in movieWithActorViewModels)
			{
				foreach (var itemMovie in movies)
				{
					itemVM.MovieName = itemMovie.Name;
					itemVM.MovieDescription = itemMovie.Description;
					itemVM.MoviePicture = itemMovie.ImageUrl;

				}

				foreach (var itemActor in actors)
				{
					itemVM.ActorPicture = itemActor.ProfilePicUrl;
				}
			}

			return View(movieWithActorViewModels);
        }

         
    }
}
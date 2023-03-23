using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviePoint.Models;
using MoviePoint.Repository;
using MoviePoint.ViewModel;
using NuGet.Protocol.Core.Types;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MoviePoint.Controllers
{
	[Authorize]
	public class MovieController : Controller
	{
		IMovieRepository movieRepository;
        IActorRepository actorRepository;

        IProducerRepository producerRepository;
        ICinemaRepository cinemaRepository;
        IActorMovieRepository actormovieRepository;



        public MovieController
			(IMovieRepository _movRepo, IActorRepository _actRepo, IProducerRepository _proRepo, ICinemaRepository _cinemaRepo, IActorMovieRepository _actmovieRepo)
		{
            movieRepository = _movRepo;
            actorRepository = _actRepo;
            producerRepository = _proRepo;
            cinemaRepository = _cinemaRepo;
            actormovieRepository= _actmovieRepo;
        }

		public IActionResult Index()
		{
			List<Movie> movies = movieRepository.GetAll();
			return View(movies);
		}

		public IActionResult Details(int id)
		{
			MovieDetailsViewModel movieModel = new MovieDetailsViewModel();
			Movie movie = movieRepository.GetMovieWithDetails(id);
			movieModel.MovieName = movie.Name;
			movieModel.MovieCategory = movie.Category;
			movieModel.MoviePrice = movie.Price;
			movieModel.MovieEndDate = movie.EndtDate;
			movieModel.MovieStartDate = movie.StartDate;
			movieModel.MovieDescription = movie.Description;
			movieModel.MovieImageUrl = movie.ImageUrl;
			movieModel.CinemaName = movie.Cinema.Name;
			movieModel.CinemaLocation = movie.Cinema.Location;
			movieModel.ProducerName = movie.Producer.FullName;
            
			return View(movieModel);
		}

        [HttpGet]
        public IActionResult Insert()
        {
            MoiveViewModel NewMoive =
                new MoiveViewModel();

           // NewMoive.ActorsObj = actorRepository.GetAll();
            NewMoive.cinemas = cinemaRepository.GetAll();
            NewMoive.producers = producerRepository.GetAll();
            NewMoive.Actor_Movies = actormovieRepository.GetAll();
            NewMoive.AllActors = actorRepository.GetAll();


            return View(NewMoive);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Insert(MoiveViewModel moiveViewModel)
        {
            
            if (ModelState.IsValid == true)
            {
                Movie movie = new Movie();

                movie.Name = moiveViewModel.Name;
                movie.Description = moiveViewModel.Description;
                movie.Price = moiveViewModel.Price;
                movie.ImageUrl = moiveViewModel.ImageUrl;
                movie.StartDate = moiveViewModel.StartDate;
                movie.EndtDate = moiveViewModel.EndtDate;
                movie.ProducerID = moiveViewModel.ProducerID;
                movie.CinemaID = moiveViewModel.CinemaID;
                movie.Category=moiveViewModel.Category;
                movie.videoURL = moiveViewModel.videoURL;
                moiveViewModel.AllActors = actorRepository.GetAll();
                moiveViewModel.cinemas = cinemaRepository.GetAll();
                moiveViewModel.producers = producerRepository.GetAll();
                moiveViewModel.Actor_Movies = actormovieRepository.GetAll();
              

                movieRepository.Insert(movie);

                List<Actor> actors = new List<Actor>();
                foreach (var ctorid in moiveViewModel.Actors)
                {
                    
                    actors.Add( actorRepository.GetById(ctorid));

                }
                moiveViewModel.ActorsObj = actors;


                foreach (var actorId in moiveViewModel.Actors)
                {
                    var newActorMovie = new Actor_Movie()
                    {
                        MovieID = movie.Id,
                        ActorID = actorId
                    };
                    actormovieRepository.Insert(newActorMovie);
                }
                return RedirectToAction("Index");
            }

            return View(moiveViewModel);
        }



        [HttpGet]
        public IActionResult Update(int id)
        {
            Cinema cinema = cinemaRepository.GetById(id);
            return View(cinema);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Cinema newCinema, [FromRoute] int id)
        {
            if (ModelState.IsValid == true)
            {
                cinemaRepository.Update(id, newCinema);
                return RedirectToAction("Index");
            }
            return View(newCinema);

        }

        public IActionResult Delete(int id)
        {
            //MoiveViewModel NewMoive =
            //   new MoiveViewModel();
          //  Movie movie= movieRepository.GetById(id);
			//NewMoive.Name = movie.Name;
			//NewMoive.Description = movie.Description;
			//NewMoive.Price = movie.Price;
			//NewMoive.ImageUrl = movie.ImageUrl;
			//NewMoive.StartDate = movie.StartDate;
			//NewMoive.EndtDate = movie.EndtDate;
			//NewMoive.ProducerID = movie.ProducerID;
			//NewMoive.CinemaID = movie.CinemaID;
			//NewMoive.Category = movie.Category;
			//NewMoive.videoURL = movie.videoURL;

            List<Actor_Movie> ActorMovie= actormovieRepository.GetByMovieId(id);


			foreach (var actor in ActorMovie)
			{
				//Movie movie = new Movie();

    //            var newActorMovie = new Actor_Movie()
    //            {
    //                MovieID = actor.MovieID,
    //                ActorID = actor.ActorID
				//};
				actormovieRepository.Delete(actor.ID);
			}
			 movieRepository.Delete(id);

			return RedirectToAction("Index");
        }
    }
}

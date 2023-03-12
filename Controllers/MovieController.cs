using Microsoft.AspNetCore.Mvc;

namespace MoviePoint.Controllers
{
	public class MovieController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}

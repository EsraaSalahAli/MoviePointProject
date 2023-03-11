using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MoviePoint.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;

        public AccountController
            (UserManager<IdentityUser> _userManager, SignInManager<IdentityUser> signInManager)
        {
            this.userManager = _userManager;
            this.signInManager = signInManager;
        }

        public IActionResult Registration()
        {
            return View();
        }
    }
}

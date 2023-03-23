using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MoviePoint.ViewModel;

namespace MoviePoint.Controllers
{
    [Authorize(Roles="Admin,HR")]
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;

        public RoleController(RoleManager<IdentityRole> RoleManager)
        {
            roleManager = RoleManager;
        }
        public IActionResult New()
        {
            return View();
        }


        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> New(RoleViewModel roleVM)
        {
            if (ModelState.IsValid)
            {
                IdentityRole roleModel = new IdentityRole();
                roleModel.Name = roleVM.RoleName;
                IdentityResult result = await roleManager.CreateAsync(roleModel);//unique
                if (result.Succeeded)
                {
                    return View();
                }
                else
                {
                    //foreach(var item in result.Errors) //to display all errors
                    //{
                    //    ModelState.AddModelError("", item.Description);

                    //}
                    ModelState.AddModelError("", result.Errors.FirstOrDefault().Description);
                }

                //RoleManager<IdentityRole> roleManager=new RoleManager<IdentityRole>()
            }
            return View(roleVM);
        }
    }
}

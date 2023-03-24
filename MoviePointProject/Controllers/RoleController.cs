﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MoviePoint.Models;
using MoviePoint.ViewModel;

namespace MoviePoint.Controllers
{
    [Authorize(Roles="Admin")]
    public class RoleController : Controller
    {
		private readonly RoleManager<IdentityRole> roleManager;
		private readonly UserManager<IdentityUser> userManager;
		MoviePointContext context = new MoviePointContext();

		public RoleController(RoleManager<IdentityRole> RoleManager,UserManager<IdentityUser> UserManager)
        {
            roleManager = RoleManager;
            userManager = UserManager;

		}
        //public IActionResult New()
        //{
        //    return View();
        //}


        //[HttpPost]
        ////[ValidateAntiForgeryToken]
        //public async Task<IActionResult> New(RoleViewModel roleVM)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        IdentityRole roleModel = new IdentityRole();
        //        roleModel.Name = roleVM.RoleName;
        //        IdentityResult result = await roleManager.CreateAsync(roleModel);//unique
        //        if (result.Succeeded)
        //        {
        //            return View();
        //        }
        //        else
        //        {
        //            //foreach(var item in result.Errors) //to display all errors
        //            //{
        //            //    ModelState.AddModelError("", item.Description);

        //            //}
        //            ModelState.AddModelError("", result.Errors.FirstOrDefault().Description);
        //        }

        //        //RoleManager<IdentityRole> roleManager=new RoleManager<IdentityRole>()
        //    }
        //    return View(roleVM);
        //}
       
        public IActionResult AssigRole()
        {
            RoleViewModel roleView=new RoleViewModel();
			roleView.Users = context.Users.ToList();
			roleView.Roles = context.Roles.ToList();

			return View();
        }

        [HttpPost]
		public async Task<IActionResult> AssigRole(RoleViewModel RoleVM)
		{
			if (ModelState.IsValid)
            {
                IdentityUserRole<string> roleModel = new IdentityUserRole<string>();

				roleModel.UserId = RoleVM.UserID;
				roleModel.RoleId = RoleVM.RoleID;
                IdentityUser SelectedUser = RoleVM.Users.FirstOrDefault(u => u.Id == RoleVM.UserID);
				IdentityResult result = await userManager.AddToRoleAsync(SelectedUser, RoleVM.RoleName);
				//await roleManager. CreateAsync(roleModel);//unique
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
            return View(RoleVM);
        }
	}
}

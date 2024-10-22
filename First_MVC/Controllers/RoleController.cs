using First_MVC.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace First_MVC.Controllers
{
    public class RoleController : Controller
    {
        private RoleManager<IdentityRole> roleManager;

        public RoleController(RoleManager<IdentityRole> roleManager)
        {
            this.roleManager = roleManager;
        }

        [Authorize(Roles ="Admin")]
        public IActionResult AddRole()
        {
            return View();
        }
        public async Task <IActionResult> SaveRole(RoleViewModel roleViewModel)
        {
            if(ModelState.IsValid == true) 
            {
                IdentityRole role = new IdentityRole();
                role.Name=roleViewModel.RoleName;
                IdentityResult result = await roleManager.CreateAsync(role);
                if(result.Succeeded == true)
                { 
                    ViewBag.sucess = true;
                    return View("AddRole");
                }
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
            }
            return View("AddRole",roleViewModel);
        }
    }
}

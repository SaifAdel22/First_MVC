using First_MVC.Models.Idenity;
using First_MVC.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace First_MVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public AccountController(UserManager<ApplicationUser> userManager,SignInManager<ApplicationUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View("Register");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task <IActionResult> SaveRegister(RegisterViewModel registerViewModel)
        {
            if(ModelState.IsValid)
            {
                ApplicationUser user = new ApplicationUser();
                user.Addres = registerViewModel.Address;
                user.UserName = registerViewModel.UserName;
                user.PasswordHash = registerViewModel.Password;
                IdentityResult result = await userManager.CreateAsync(user, registerViewModel.Password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user,"Admin");
                    await signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index","Department");
                }
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("",item.Description);
                }
            }
            return View("Register",registerViewModel);
        }

        public async Task <IActionResult> SignOut()
        {
            await signInManager.SignOutAsync();
            return View("LogIn");
        }
        public IActionResult LogIn()
        {
            return View("LogIn");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task <IActionResult> LogInCheck(LoginUserViewModel loginUserViewModel)
        {
            if(ModelState.IsValid)
            {
                ApplicationUser user = await userManager.FindByNameAsync(loginUserViewModel.UserName);
                if(user != null)
                {
                    //ModelState.AddModelError("", "UserName");

                    bool right = await userManager.CheckPasswordAsync(user,loginUserViewModel.Password);
                    if (right == true)
                    {
                        //ModelState.AddModelError("", "Password");
                        List<Claim>? claims = new List<Claim>();
                        claims.Add(new Claim("UserAddress", user.Addres));
                        await signInManager.SignInWithClaimsAsync(user, loginUserViewModel.RememberMe, claims);
                        //await signInManager.SignInAsync(user, loginUserViewModel.RememberMe);
                        return RedirectToAction("Index", "Department");

                    }
                }
                ModelState.AddModelError("", "Wrong UserName Or Password");
            }
            return View("LogIn", loginUserViewModel);

        }
    }
}

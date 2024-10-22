using First_MVC.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace First_MVC.Controllers
{
    public class ServiceController : Controller
    {
        public IActionResult TestAuth()
        {

            if (User.Identity.IsAuthenticated)
            {
                Claim IDClaim = User.Claims
                    .FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
                Claim AddressClaim = User.Claims
                   .FirstOrDefault(c => c.Type == "UserAddress");

                return Content($"Welcome {User.Identity.Name} {IDClaim} {AddressClaim}");
            }
            return Content("Welcome Guest");

        }
        IDepartmentRepository departmentRepository;
        public ServiceController(IDepartmentRepository _departmentRepository) 
        {
            departmentRepository = _departmentRepository;
        }

        public IActionResult Index([FromServices] IDepartmentRepository dept)
        {
            ViewBag.Id = departmentRepository.Id;
            return View("Index");
        }
    }
}

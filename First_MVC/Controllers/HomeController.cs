using First_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace First_MVC.Controllers
{
    public class HomeController : Controller
    {


        public ContentResult showCont()
        {
            return Content("Hello World");
        }

        public ViewResult showView()
        {         
            return View("View1");
        }

        public IActionResult showMix(int id)
        {
            if (id % 2 == 0)
            {
               return View("View1");
            }
            else
            {
               return Content("Hello World");
            }

        }

       



        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

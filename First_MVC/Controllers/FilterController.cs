using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using First_MVC.Filter;


namespace First_MVC.Controllers
{
    //  [HandelError]
//    [Authorize]
    public class FilterController : Controller
    {
         [HandelError]
        public IActionResult Index()
        {
           throw new Exception("Exception Fr index");
        }
//        [HandelError]

        public IActionResult Index2()
        {
            throw new Exception("Exception Fr index");
        }
    }
}

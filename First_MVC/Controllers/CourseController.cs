using First_MVC.Models;
using First_MVC.Models.Entity;
using First_MVC.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace First_MVC.Controllers
{
    public class CourseController : Controller
    {
        //AppDbContext context = new AppDbContext();
        //public ICourseRepository CourseRepository;
        //public IDepartmentRepository DepartmentRepository;
        public IGenericRepository<Department> DepartmentRepository;
        public IGenericRepository<Course> CourseRepository;

        // Constructor with DI
        public CourseController(IGenericRepository<Course> CourseRepository, IGenericRepository<Department> DepartmentRepository)
        {
            this.CourseRepository = CourseRepository;
            this.DepartmentRepository = DepartmentRepository;
        }

        public IActionResult Index()
        {
            var ret = CourseRepository.GetAll();
            return View("Index", ret);
        }
        public IActionResult Add()
        {
            ViewBag.DeptList = DepartmentRepository.GetAll();
            return View("Add");
        }
        public IActionResult SaveAdd(Course course)
        {
            ModelState.Remove("CrsResults");
            ModelState.Remove("Instructors");
            if (ModelState.IsValid)
            {
                CourseRepository.Add(course);
                CourseRepository.Save();
                return RedirectToAction("Index");
            }
            ModelState.Remove("CrsResults");
            ModelState.Remove("Instructor");
            ModelState.AddModelError("Name", "Must be uniq");
            ViewBag.DeptList = DepartmentRepository.GetAll();
            return View("Add");
        }

        [HttpGet]
        public IActionResult ValidateMinDegree(int MinDegree, int Degree)
        {
            // Check if MinDegree is less than Degree
            if (MinDegree >= Degree)
            {
                return Json($"MinDegree ({MinDegree}) must be less than Degree ({Degree}).");
            }

            return Json(true);
        }

    }
}

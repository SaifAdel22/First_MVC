using First_MVC.Models;
using First_MVC.Models.Entity;
using First_MVC.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace First_MVC.Controllers
{
    public class DepartmentController : Controller
    {
        //AppDbContext context = new AppDbContext();
        IGenericRepository<Department> Deptrepository;
        IEmployeeRepository Embrepository;

        public DepartmentController(IGenericRepository<Department> Deptrepository, IEmployeeRepository Embrepository)

        {
            this.Deptrepository = Deptrepository;
            this.Embrepository = Embrepository;
        }


        public IActionResult DeptEmps()
        {
            return View("DeptEmps", Deptrepository.GetAll().ToList());//List<department>
        }

        //DEpartment/GetEmpsByDEptId?deptId=1
        public IActionResult GetEmpsByDEptId(int deptId)
        {
            List<Employee> EmpList = Embrepository.GetByDEptID(deptId);
            return Json(EmpList);
        }
        [Authorize]
        public IActionResult Index(string searchString, int page = 1)
        {
            int pageSize = 4; // Set page size to 4 departments per page

            var query = Deptrepository.GetAll().AsQueryable();

            // Search filter
            if (!string.IsNullOrEmpty(searchString))
            {
                query = query.Where(d => d.Name.Contains(searchString) || d.ManagerName.Contains(searchString));
            }

            // Paging logic
            var paginatedDepartments = query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            // Total records for pagination
            int totalRecords = query.Count();
            ViewBag.TotalPages = (int)Math.Ceiling((double)totalRecords / pageSize);
            ViewBag.CurrentPage = page;
            ViewBag.SearchString = searchString; // Pass search string back to view

            return View("Index", paginatedDepartments);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View("Add");
        }

        [HttpPost]
        public IActionResult SaveAdd(Department dept)
        {
            if (Request.Method == "POST")
            {
                if (dept.Name != null)
                {
                    Deptrepository.Add(dept);
                    Deptrepository.Save();
                    return RedirectToAction("Index");
                }
            }
            return View("Add", dept);
        }
    }
}

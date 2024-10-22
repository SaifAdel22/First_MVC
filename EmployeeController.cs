using First_MVC.Models;
using First_MVC.Models.Entity;
using First_MVC.Repository;
using First_MVC.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Q3DotNetAssiut.Repository;

namespace First_MVC.Controllers
{
    public class EmployeeController : Controller
    {
        // AppDbContext context = new AppDbContext();
        private readonly AppDbContext context;

        // DepartmentRepository departmentRepository;
        private GenericRepository<Employee> employeeRepository;
        private GenericRepository<Department> departmentRepository;

        // public EmployeeController()
        public EmployeeController(AppDbContext _context)
        {
            // context = new AppDbContext();
            context = _context;

            // departmentRepository = new DepartmentRepository();
            employeeRepository = new GenericRepository<Employee>(context);
            departmentRepository = new GenericRepository<Department>(context);
        }

        [HttpGet]
        public IActionResult Index()
        {
            // List<Employee> employees = context.Employees.Include(x => x.Department).ToList();
            var employees = employeeRepository.GetAll()
                .Include(e => e.Department).ToList();
            return View("Index", employees);
        }

        [HttpGet]
        public IActionResult New()
        {
            // ViewBag.DeptList = context.Departments.ToList();
            ViewBag.DeptList = departmentRepository.GetAll();
            return View("New");
        }

        [HttpPost]
        public IActionResult SaveNew(Employee emp)
        {
            // Validate the DepartmentId
            // if (emp.DepartmentId == 0) {...}
            if (emp.DepartmentId == 0)
            {
                ModelState.AddModelError("DepartmentId", "Please select a department.");
            }
            else if (!context.Departments.Any(d => d.Id == emp.DepartmentId)) // Added validation check
            {
                ModelState.AddModelError("DepartmentId", "The selected department does not exist.");
            }

            //ModelState.Remove("Department");
            //ModelState.Remove("DepartmentId");

            if (ModelState.IsValid)
            {
                try
                {
                    // context.Add(emp);
                    employeeRepository.Add(emp);

                    // context.SaveChanges();
                    employeeRepository.Save();
                    TempData["Message"] = "Employee added successfully.";
                    TempData["MessageType"] = "success";
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                }
            }

            // ViewBag.DeptList = context.Departments.ToList();
            ViewBag.DeptList = departmentRepository.GetAll(); // Ensure the department list is sent back on error
            return View("New", emp);
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            // var updateEmp = context.Employees.FirstOrDefault(x => x.Id == id);
            var updateEmp = employeeRepository.GetById(id);

            if (updateEmp == null)
            {
                return NotFound();
            }

            // ViewBag.DeptList = context.Departments.ToList();
            ViewBag.DeptList = departmentRepository.GetAll();

            EmployeeWithDeptList empViewModel = new EmployeeWithDeptList();
            empViewModel.Id = updateEmp.Id;
            empViewModel.Address = updateEmp.Address;
            empViewModel.salary = updateEmp.salary;
            empViewModel.ImageURL = updateEmp.ImageURL;
            empViewModel.Name = updateEmp.Name;
            empViewModel.JobTitle = updateEmp.JobTitle;
            empViewModel.DepartmentId = updateEmp.DepartmentId;
            empViewModel.DepartmentList = departmentRepository.GetAllAsList();
            return View("Update", empViewModel);
        }

        [HttpPost]
        public IActionResult SaveUpdate(EmployeeWithDeptList emp)
        {
            // var DBemp = context.Employees.FirstOrDefault(x => x.Id == emp.Id);
            var DBemp = employeeRepository.GetById(emp.Id);

            if (ModelState.IsValid)
            {
                if (DBemp.Name != emp.Name)
                {
                    if (context.Employees.Any(e => e.Name == emp.Name))
                    {
                        ModelState.AddModelError("Name", "This employee name is already taken.");
                        return View("Update", emp);
                    }
                }

                DBemp.Address = emp.Address;
                DBemp.salary = emp.salary;
                DBemp.ImageURL = emp.ImageURL;
                DBemp.Name = emp.Name;
                DBemp.JobTitle = emp.JobTitle;
                DBemp.DepartmentId = emp.DepartmentId;

                // context.SaveChanges();
                employeeRepository.Save();

                TempData["Message"] = "Employee updated successfully.";
                TempData["MessageType"] = "success";
                return RedirectToAction("Index");
            }

            emp.DepartmentList = departmentRepository.GetAllAsList();
            return View("Update", emp);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            // var del = context.Employees.FirstOrDefault(x => x.Id == id);
            employeeRepository.Delete(id);

            // context.Employees.Remove(del);
            // context.SaveChanges();
            employeeRepository.Save();

            TempData["Message"] = "Employee deleted successfully.";
            TempData["MessageType"] = "success";
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            string msg = "Hello From Action";
            int temp = 50;
            List<string> branches = new List<string>
            {
                new string("Assuit"),
                new string("Alex"),
                new string("Cairo")
            };

            ViewData["Msg"] = msg;
            ViewData["Temp"] = temp;
            ViewData["Branches"] = branches;
            ViewBag.Color = "Red";

            // Employee EmpModel = context.Employees.FirstOrDefault(x => x.Id == id);
            var emp = employeeRepository.GetById(id);
            return View("Details", emp);
        }

        public IActionResult DetailsVM(int id)
        {
            // Employee emp = context.Employees.Include(x => x.Department).FirstOrDefault(x => x.Id == id);
            Employee emp = employeeRepository.GetAll().Include(x => x.Department).FirstOrDefault(x => x.Id == id);

            List<string> branches = new List<string>
            {
                new string("Assuit"),
                new string("Alex"),
                new string("Cairo")
            };

            string msg = "Hello From Action";
            int temp = 50;

            EmpDeptColorTempBranchesViewModel EmpVm = new EmpDeptColorTempBranchesViewModel
            {
                EmpName = emp.Name,
                DeptName = emp.Department.Name,
                Branches = branches,
                Msg = msg,
                Temp = temp,
                Color = "Green"
            };

            return View("DetailsVM", EmpVm);
        }
    }
}

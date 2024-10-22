using First_MVC.Models;
using First_MVC.Models.Entity;
using First_MVC.Repository;
using First_MVC.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace First_MVC.Controllers
{
    public class EmployeeController : Controller
    {
        // AppDbContext context = new AppDbContext();
        AppDbContext context;
        IGenericRepository<Employee> EmployeeRepository;
        IGenericRepository<Department> DepartmentRepository;
        public EmployeeController(IGenericRepository<Employee> EmpRep, IGenericRepository<Department> DepRep)
        {
            EmployeeRepository = EmpRep;
            DepartmentRepository = DepRep;
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var del = EmployeeRepository.GetById(id); 
            if (del != null)
            {
                EmployeeRepository.Delete(del.Id);
                EmployeeRepository.Save();
                TempData["Message"] = "Employee deleted successfully.";
                TempData["MessageType"] = "success"; // You can set different types if needed
            }
            else
            {
                TempData["Message"] = "Employee does not exist.";
                TempData["MessageType"] = "error";
            }

            return RedirectToAction("Index"); // Redirect back to the list
        }


        [HttpGet]
        public IActionResult New()
        {
            ViewBag.DeptList = DepartmentRepository.GetAll();
            return View("New");
        }
        [HttpPost]
        [HttpPost]
        public IActionResult SaveNew(Employee emp)
        {
            // Validate the DepartmentId
            if (emp.DepartmentId == 0)
            {
                ModelState.AddModelError("DepartmentId", "Please select a department.");
            }
            else
            {
                // Check if the department exists
                var departmentExists = DepartmentRepository.GetById(emp.DepartmentId);
                if (departmentExists.Id == null)
                {
                    ModelState.AddModelError("DepartmentId", "The selected department does not exist.");
                }
            }

            //ModelState.Remove("Department");
            //ModelState.Remove("DepartmentId");
            if (ModelState.IsValid)
            {
                try
                {
                    emp.Department = DepartmentRepository.GetById(emp.DepartmentId);
                    EmployeeRepository.Add(emp);
                    EmployeeRepository.Save();
                    TempData["Message"] = "Employee added successfully.";
                    TempData["MessageType"] = "success";
                    return RedirectToAction("Index");
                }
                catch(Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                }
                //if(emp.DepartmentId != 0)
                //{
                //    emp.Department = context.Departments.FirstOrDefault(d => d.Id == emp.DepartmentId);

                //    context.Add(emp);
                //    context.SaveChanges();
                //    TempData["Message"] = "Employee added successfully.";
                //    TempData["MessageType"] = "success";
                //    return RedirectToAction("Index");
                //}
                //else
                //{
                //    ModelState.AddModelError("DepartmentId", "Select Department");
                //}
            }

            ViewBag.DeptList = DepartmentRepository.GetAll(); // Ensure the department list is sent back on error
            return View("New", emp);
        }


        [Authorize]
        [HttpGet]
        public IActionResult Index()
        {
            List<Employee> employees = EmployeeRepository.GetAll().Include(d=>d.Department).ToList();
            return View("Index",employees);
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
		    var updateEmp = EmployeeRepository.GetById(id);
			if (updateEmp == null)
			{
				return NotFound(); 
			}
            List<Department> departmentList = DepartmentRepository.GetAll().ToList();
            EmployeeWithDeptList empViewModel = new EmployeeWithDeptList();
            empViewModel.Id=updateEmp.Id;
            empViewModel.Address = updateEmp.Address;
            empViewModel.salary = updateEmp.salary;
            empViewModel.ImageURL = updateEmp.ImageURL;
            empViewModel.Name = updateEmp.Name;
            empViewModel.JobTitle = updateEmp.JobTitle;
            empViewModel.DepartmentId = updateEmp.DepartmentId;
            empViewModel.DepartmentList = departmentList;
            return View("Update", empViewModel);
        }
        [HttpPost]
        public IActionResult SaveUpdate(EmployeeWithDeptList emp)
        {
            Employee DBemp = EmployeeRepository.GetById(emp.Id);
            emp.DepartmentList = DepartmentRepository.GetAll().ToList();
            ModelState.Remove("Department");
            if (ModelState.IsValid == true)
            {
                if(DBemp.Name != emp.Name)
                {
                    if (context.Employees.Any(e => e.Name == emp.Name))
                    {
                        ModelState.AddModelError("Name", "This employee name is already taken.");
                        return View("Update",emp);
                    }
                }
                DBemp.Address = emp.Address;
                DBemp.salary = emp.salary;
                DBemp.ImageURL = emp.ImageURL;
                DBemp.Name = emp.Name;
                DBemp.JobTitle = emp.JobTitle;
                DBemp.DepartmentId = emp.DepartmentId;
                DBemp.Id = emp.Id;
                EmployeeRepository.Update(DBemp);
                EmployeeRepository.Save();
                return RedirectToAction("Index");
            }
            return View("Update", emp);
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
            Employee EmpModel = EmployeeRepository.GetById(id);
            return View("Details",EmpModel);
        }

        public IActionResult DetailsVM(int id)
        {
            Employee emp = EmployeeRepository.GetById(id);
                List<string> branches = new List<string>
            {
                new string("Assuit"),
                new string("Alex"),
                new string("Cairo")
            };

            string msg = "Hello From Action";
            int temp = 50;
            EmpDeptColorTempBranchesViewModel EmpVm = new EmpDeptColorTempBranchesViewModel();
            
            EmpVm.EmpName = emp.Name;
            EmpVm.DeptName = emp.Department.Name;
            EmpVm.Branches = branches;
            EmpVm.Msg = msg;
            EmpVm.Temp = temp;
            EmpVm.Color = "Green";

           
            return View("DetailsVM" , EmpVm);
            

        }
    }
}

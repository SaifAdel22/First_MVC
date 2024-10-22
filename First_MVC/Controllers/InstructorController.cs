using First_MVC.Models;
using First_MVC.Models.Entity;
using First_MVC.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace First_MVC.Controllers
{
    public class InstructorController : Controller
    {
        //AppDbContext context = new AppDbContext();
        private readonly AppDbContext context;

        // Constructor with DI
        public InstructorController(AppDbContext _context)
        {
            context = _context;
        }
        public IActionResult Index()
        {
            List<Instructor> list = context.Instructors
                .Include(x => x.Course)
                .Include(y=>y.Department)
                .ToList();
            return View("Index",list);
        }

        public IActionResult Details(int id)
        {
            var inst = context.Instructors
                      .Include(x => x.Course)
                      .Include(y => y.Department)
                      .FirstOrDefault(x => x.Id == id);
            return View("Details", inst);
        }
        [HttpGet]
        public IActionResult Add()
        {
            InstructorWithCourseAndDepartment list = new InstructorWithCourseAndDepartment();
            list.Courses = context.Courses.ToList();
            list.Departments = context.Departments.ToList();
            return View("Add",list);
        }
        [HttpPost]
        public IActionResult SaveAdd(InstructorWithCourseAndDepartment inst)
        {
            if(inst.Name != null)
            {
                Instructor ToAdd = new Instructor
                {
                    Id = inst.Id,
                    Name = inst.Name,
                    Salary = inst.Salary,
                    Address = inst.Address,
                    ImageURL = inst.ImageURL,
                    CourseId = inst.CourseId,
                    DepartmentId = inst.DepartmentId,
                };
                context.Instructors.Add(ToAdd);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            inst.Courses = context.Courses.ToList();
            inst.Departments = context.Departments.ToList();
            return View("Add",inst);
        }
        //public int Id { get; set; }
        //public string Name { get; set; }
        //public string ImageURL { get; set; }
        //public decimal Salary { get; set; }
        //public string Address { get; set; }
        //public Course Course { get; set; }
        //public int CourseId { get; set; }
        ////public List<InstructorCourse> instructorCourses { get; set; }

        //public Department Department { get; set; }
        //public int DepartmentId { get; set; }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var inst = context.Instructors.FirstOrDefault(x=> x.Id == id);
            if(inst == null) { return NotFound(); } 
            InstructorWithCourseAndDepartment instModel = new InstructorWithCourseAndDepartment
            {
                Id=inst.Id,
                Name = inst.Name,
                Salary = inst.Salary,
                Address = inst.Address,
                ImageURL = inst.ImageURL,
                CourseId = inst.CourseId,
                DepartmentId = inst.DepartmentId,
            };
            instModel.Courses = context.Courses.ToList();
            instModel.Departments = context.Departments.ToList();
            return View("Edit",instModel);


        }
        [HttpPost]
        [HttpPost]
        public IActionResult SaveEdit(InstructorWithCourseAndDepartment inst)
        {
            var instModel = context.Instructors.FirstOrDefault(x => x.Id == inst.Id);
            if (instModel != null && inst.Name != null)
            {
                instModel.Name = inst.Name;
                instModel.Salary = inst.Salary;
                instModel.Address = inst.Address;
                instModel.ImageURL = inst.ImageURL;
                instModel.CourseId = inst.CourseId; // Ensure this CourseId is valid
                instModel.DepartmentId = inst.DepartmentId;

              
                    context.SaveChanges();
                    return RedirectToAction("Index");
               
            }

            inst.Courses = context.Courses.ToList();
            inst.Departments = context.Departments.ToList();
            return View("Edit", inst);
        }



    }
}

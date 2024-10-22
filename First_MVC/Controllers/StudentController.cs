using First_MVC.Models;
using First_MVC.Models.Entity;
using Microsoft.AspNetCore.Mvc;

namespace First_MVC.Controllers
{
    public class StudentController : Controller
	{
		public IActionResult ShowAll()
		{
			StudentBL studentBL = new StudentBL();
			List<Student> students = studentBL.GetAll();
			return View("ShowAll",students);
		}
		public IActionResult ShowById( int id)
		{
			StudentBL studentBL = new StudentBL();
			Student student = studentBL.GetById(id);
			return View("ShowDetails", student);
		}
	}
}

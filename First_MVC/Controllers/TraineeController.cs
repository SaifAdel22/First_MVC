using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using First_MVC.Models;
using First_MVC.Models.Entity;

namespace First_MVC.Controllers
{
    public class TraineeController : Controller
    {
        private readonly AppDbContext context;

        // Constructor with DI
        public TraineeController(AppDbContext _context)
        {
            context = _context;
        }
        // GET: Trainee
        public async Task<IActionResult> Index()
        {
            var trainees = await context.Trainees
                .ToListAsync();  // Ensure you are directly querying the DbSet
            return View(trainees);
        }


        // GET: Trainee/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trainee = await context.Trainees
                .Include(t => t.Department)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (trainee == null)
            {
                return NotFound();
            }

            return View(trainee);
        }

        // GET: Trainee/Create
        public IActionResult Create()
        {
            ViewData["DepartmentId"] = new SelectList(context.Departments, "Id", "ManagerName");
            return View();
        }

        // POST: Trainee/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,ImageURL,Address,Grade,DepartmentId")] Trainee trainee)
        {
            if (ModelState.IsValid)
            {
                context.Add(trainee);
                await context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DepartmentId"] = new SelectList(context.Departments, "Id", "ManagerName", trainee.DepartmentId);
            return View(trainee);
        }

        // GET: Trainee/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trainee = await context.Trainees.FindAsync(id);
            if (trainee == null)
            {
                return NotFound();
            }
            ViewData["DepartmentId"] = new SelectList(context.Departments, "Id", "ManagerName", trainee.DepartmentId);
            return View(trainee);
        }

        // POST: Trainee/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,ImageURL,Address,Grade,DepartmentId")] Trainee trainee)
        {
            if (id != trainee.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    context.Update(trainee);
                    await context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TraineeExists(trainee.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["DepartmentId"] = new SelectList(context.Departments, "Id", "ManagerName", trainee.DepartmentId);
            return View(trainee);
        }

        // GET: Trainee/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trainee = await context.Trainees
                .Include(t => t.Department)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (trainee == null)
            {
                return NotFound();
            }

            return View(trainee);
        }

        // POST: Trainee/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var trainee = await context.Trainees.FindAsync(id);
            if (trainee != null)
            {
                context.Trainees.Remove(trainee);
            }

            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TraineeExists(int id)
        {
            return context.Trainees.Any(e => e.Id == id);
        }

        public IActionResult Result(int id)
        {
            var trainee = context.Trainees
                   .Include(t => t.CrsResults)
                       .ThenInclude(cr => cr.Course)
                   .FirstOrDefault(t => t.Id == id);

            if (trainee == null)
            {
                return NotFound();
            }

            // Prepare the view model with necessary data
            var traineeCourses = trainee.CrsResults.Select(cr => new
            {
                CourseName = cr.Course.Name,
                TraineeGrade = trainee.Grade, // Accessing the trainee's grade
                cr.Course.MinDegree, // Minimum passing grade
                IsPass = trainee.Grade >= cr.Course.MinDegree // Check if the trainee passed
            }).ToList();

            // Pass the data to the view
            ViewBag.TraineeName = trainee.Name;
            return View(traineeCourses);



        }
        public IActionResult TraineCardDel(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trainee =  context.Trainees
                .Include(t => t.Department)
                .FirstOrDefault(m => m.Id == id);
            var ret = new Trainee();
            ret.Name = trainee.Name;
            ret.Grade = trainee.Grade;
            if (trainee == null)
            {
                return NotFound();
            }

            return View(ret);
        }
        public IActionResult TraineCardDet(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trainee = context.Trainees
                .Include(t => t.Department)
                .FirstOrDefault(m => m.Id == id);
            var ret = new Trainee();
            ret.Name = trainee.Name;
            ret.Grade = trainee.Grade;
            if (trainee == null)
            {
                return NotFound();
            }

            return View(ret);
        }
		public IActionResult TraiCard(int id)
		{
			

			return PartialView("_Part",context.Trainees
				.FirstOrDefault(m => m.Id == id));
		}

	}
}

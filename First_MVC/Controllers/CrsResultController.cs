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
    public class CrsResultController : Controller
    {
        AppDbContext context = new AppDbContext();
        // GET: CrsResult
        public async Task<IActionResult> Index()
        {
            var appDbContext = context.CrsResults.Include(c => c.Course).Include(c => c.Trainee);
            return View(await appDbContext.ToListAsync());
        }

        // GET: CrsResult/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var crsResult = await context.CrsResults
                .Include(c => c.Course)
                .Include(c => c.Trainee)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (crsResult == null)
            {
                return NotFound();
            }

            return View(crsResult);
        }

        // GET: CrsResult/Create
        public IActionResult Create()
        {
            ViewData["CourseId"] = new SelectList(context.Courses, "Id", "Name");
            ViewData["TraineeId"] = new SelectList(context.Trainees, "Id", "Address");
            return View();
        }

        // POST: CrsResult/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Degree,CourseId,TraineeId")] CrsResult crsResult)
        {
            if (ModelState.IsValid)
            {
                context.Add(crsResult);
                await context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CourseId"] = new SelectList(context.Courses, "Id", "Name", crsResult.CourseId);
            ViewData["TraineeId"] = new SelectList(context.Trainees, "Id", "Address", crsResult.TraineeId);
            return View(crsResult);
        }

        // GET: CrsResult/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var crsResult = await context.CrsResults.FindAsync(id);
            if (crsResult == null)
            {
                return NotFound();
            }
            ViewData["CourseId"] = new SelectList(context.Courses, "Id", "Name", crsResult.CourseId);
            ViewData["TraineeId"] = new SelectList(context.Trainees, "Id", "Address", crsResult.TraineeId);
            return View(crsResult);
        }

        // POST: CrsResult/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Degree,CourseId,TraineeId")] CrsResult crsResult)
        {
            if (id != crsResult.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    context.Update(crsResult);
                    await context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CrsResultExists(crsResult.Id))
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
            ViewData["CourseId"] = new SelectList(context.Courses, "Id", "Name", crsResult.CourseId);
            ViewData["TraineeId"] = new SelectList(context.Trainees, "Id", "Address", crsResult.TraineeId);
            return View(crsResult);
        }

        // GET: CrsResult/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var crsResult = await context.CrsResults
                .Include(c => c.Course)
                .Include(c => c.Trainee)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (crsResult == null)
            {
                return NotFound();
            }

            return View(crsResult);
        }

        // POST: CrsResult/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var crsResult = await context.CrsResults.FindAsync(id);
            if (crsResult != null)
            {
                context.CrsResults.Remove(crsResult);
            }

            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CrsResultExists(int id)
        {
            return context.CrsResults.Any(e => e.Id == id);
        }
    }
}

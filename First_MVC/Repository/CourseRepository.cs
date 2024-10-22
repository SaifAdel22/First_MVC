using First_MVC.Models.Entity;
using First_MVC.Models;
using Microsoft.EntityFrameworkCore;

namespace First_MVC.Repository
{
    public class CourseRepository : ICourseRepository
    {
        AppDbContext context;
        public CourseRepository(AppDbContext _context)
        {
            context = _context;
        }
        //CRUD

        public void Add(Course obj)
        {
            context.Add(obj);
        }
        public void Update(Course obj)
        {
            context.Update(obj);

        }

        public void Delete(int id)
        {
            Course cour = GetById(id);
            context.Remove(cour);
        }
        public List<Course> GetAll()
        {
            // Include the Department when fetching Employees
            return context.Courses.Include(e => e.Department).ToList();
        }

        public Course GetById(int id)
        {
            return context.Courses.Include(e => e.Department).FirstOrDefault(e => e.Id == id);
        }
        public void Save()
        {
            context.SaveChanges();
        }
    }
}

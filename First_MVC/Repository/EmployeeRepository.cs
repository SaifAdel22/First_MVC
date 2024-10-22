using First_MVC.Models;
using First_MVC.Models.Entity;
using Microsoft.EntityFrameworkCore;

namespace First_MVC.Repository
{
    public class EmployeeRepository:IEmployeeRepository
    {
       AppDbContext context  ;
        public EmployeeRepository(AppDbContext _context)
        {
            context = _context;
        }
        //CRUD

        public void Add(Employee obj)
        {
            context.Add(obj);
        }
        public void Update(Employee obj)
        {
            context.Update(obj);

        }

        public void Delete(int id)
        {
            Employee Emp = GetById(id);
            context.Remove(Emp);
        }
        public List<Employee> GetAll()
        {
            // Include the Department when fetching Employees
            return context.Employees.Include(e => e.Department).ToList();
        }

        public Employee GetById(int id)
        {
            return context.Employees.Include(e => e.Department).FirstOrDefault(e => e.Id == id);
        }
        public void Save()
        {
            context.SaveChanges();
        }
        public List<Employee> GetByDEptID(int id)
        {
            return context.Employees.Where(e=>e.DepartmentId == id).ToList();
        }

    }
}

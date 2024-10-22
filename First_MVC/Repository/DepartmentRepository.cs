using First_MVC.Models.Entity;
using First_MVC.Models;
using Microsoft.EntityFrameworkCore;

namespace First_MVC.Repository
{
    public class DepartmentRepository:IDepartmentRepository
    {
        AppDbContext context;
        public DepartmentRepository(AppDbContext context)
        {
            this.context = context;
        }

        public string Id {  get; set; }
        //CRUD
        public DepartmentRepository()
        {
            Id=Guid.NewGuid().ToString();

        }
        public void Add(Department obj)
        {
            context.Add(obj);
        }
        public void Update(Department obj)
        {
            context.Update(obj);

        }

        public void Delete(int id)
        {
            Department Emp = GetById(id);
            context.Remove(Emp);
        }
        public List<Department> GetAll() 
        {
            return context.Departments.Include(k=>k.Employees).ToList();
        }
        public Department GetById(int id)
        {
            return context.Departments.FirstOrDefault(e => e.Id == id);
        }
        public void Save()
        {
            context.SaveChanges();
        }
    }
}

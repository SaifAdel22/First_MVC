using System.ComponentModel.DataAnnotations;

namespace First_MVC.Models.Entity
{
    public class Department
    {
        public int Id { get; set; }

        [Display(Name ="Dep Name")]
        public string Name { get; set; }
        public string? ManagerName { get; set; }
        public List<Employee>? Employees { get; set; }
        public List<Trainee> Trainees { get; set; }
        public List<Instructor> Instructors { get; set; }
        public List<Course> Courses { get; set; }
    }
}

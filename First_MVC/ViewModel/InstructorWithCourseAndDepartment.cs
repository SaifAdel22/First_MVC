using First_MVC.Models.Entity;

namespace First_MVC.ViewModel
{
    public class InstructorWithCourseAndDepartment
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageURL { get; set; }
        public decimal Salary { get; set; }
        public string Address { get; set; }
        public int CourseId { get; set; }
        //public List<InstructorCourse> instructorCourses { get; set; }
        public int DepartmentId { get; set; }
        public List<Department> Departments { get; set; }
        public List<Course> Courses { get; set; }

    }
}

namespace First_MVC.Models.Entity
{
    public class Instructor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageURL { get; set; }
        public decimal Salary { get; set; }
        public string Address { get; set; }
        public Course Course { get; set; }
        public int CourseId { get; set; }
        //public List<InstructorCourse> instructorCourses { get; set; }

        public Department Department { get; set; }
        public int DepartmentId { get; set; }
    }
}

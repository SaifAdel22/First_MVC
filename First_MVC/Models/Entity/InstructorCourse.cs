namespace First_MVC.Models.Entity
{
    public class InstructorCourse
    {
        public Course Course { get; set; }
        public int CourseId { get; set; }
        public Instructor Instructor { get; set; }
        public int InstructorId { get; set; }
    }
}

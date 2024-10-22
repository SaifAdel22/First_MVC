namespace First_MVC.Models.Entity
{
    public class CrsResult
    {
        public int Id { get; set; }
        public int Degree {  get; set; }
        public Course Course { get; set; }
        public int CourseId { get; set; }
        public Trainee Trainee { get; set; }
        public int TraineeId { get;  set; }
    }
}

namespace First_MVC.Models.Entity
{
    public class Trainee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageURL { get; set; }
        public string Address { get; set; }
        public int Grade { get; set; }
        public List<CrsResult> CrsResults { get; set; }
        public Department Department { get; set; }
        public int DepartmentId { get; set; }

    }

}

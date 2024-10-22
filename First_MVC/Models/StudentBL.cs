using First_MVC.Models.Entity;

namespace First_MVC.Models
{
    public class StudentBL : Student
	{
		public List<Student> students = new List<Student> 
		{
			new Student {Id = 5 , Name ="Saif" , ImageUrl = "5.png"}
		};
		
		
		public StudentBL()
		{
			
			students.Add(new Student { Id = 1, Name = "Ahmed", ImageUrl = "1.png" });
			students.Add(new Student { Id = 2, Name = "Mohamed", ImageUrl = "2.png" });
			students.Add(new Student { Id = 3, Name = "Rewida", ImageUrl = "3.png" });
			students.Add(new Student { Id = 4, Name = "Alaa", ImageUrl = "4.png" });
		}
		

		public List<Student> GetAll()
		{
			return students;
		}

		public Student GetById(int id)
		{
			return students.FirstOrDefault(x => x.Id == id);
		}
	}
}

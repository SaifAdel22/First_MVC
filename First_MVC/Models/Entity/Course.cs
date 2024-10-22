using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace First_MVC.Models.Entity
{
    public class Course
    {
        AppDbContext context;
        [Required(ErrorMessage = "Id is required.")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [MaxLength(20, ErrorMessage = "Name cannot exceed 20 characters.")]
        [MinLength(2, ErrorMessage = "Name must be at least 2 characters long.")]
        [CourseNameCustom(ErrorMessage = "This course name already exists.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Degree is required.")]
        [Range(50, 100, ErrorMessage = "Degree must be between 50 and 100.")]
        public int Degree { get; set; }

        [Required(ErrorMessage = "MinDegree is required.")]
        [Remote(action: "ValidateMinDegree", controller: "Course", AdditionalFields = "Degree", ErrorMessage = "MinDegree must be less than Degree.")]
        public int MinDegree { get; set; }

        public int Hours { get; set; }

        public List<Instructor> instructors { get; set; }

        public List<CrsResult> CrsResults { get; set; }

        public Department? Department { get; set; }

        [Required(ErrorMessage = "DepartmentId is required.")]
        public int DepartmentId { get; set; }
    }
}

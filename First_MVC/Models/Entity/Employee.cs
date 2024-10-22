using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace First_MVC.Models.Entity
{
    public class Employee
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Full name")]
        [MinLength(3, ErrorMessage = "Name must be at least 3 characters long.")]
        [MaxLength(50, ErrorMessage = "Name cannot exceed 50 characters.")]
        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "Name can only contain letters.")]
        [UniqueNew]
        public string Name { get; set; }

        [Range(10000, 200000, ErrorMessage = "Salary must be between 10,000 and 200,000.")]
        public int salary { get; set; } // Changed 'salary' to 'Salary' to follow C# naming conventions

        public string JobTitle { get; set; }

        [Required(ErrorMessage = "Image URL is required.")]
        [RegularExpression(@"\w+\.(jpg|png)", ErrorMessage = "Image URL must be a valid .jpg or .png file.")]
        public string ImageURL { get; set; }

        public string Address { get; set; }

        public Department? Department { get; set; }

        [Required(ErrorMessage = "Department is required.")]
        public int DepartmentId { get; set; }
    }
}

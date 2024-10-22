using First_MVC.Models.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace First_MVC.ViewModel
{
    public class EmployeeWithDeptList
    {
        public int Id { get; set; }

        [Display(Name = "Full name")]
        [MinLength(3)]
        [MaxLength(50)]
        [RegularExpression("^[a-zA-Z]+$")]
        public string Name { get; set; }

        [Range(10000,200000)]
        public int salary { get; set; }

        public string JobTitle { get; set; }

        [Required] 
        [RegularExpression(@"\w+\.(jpg|png)")]
        public string ImageURL { get; set; }

        public string Address { get; set; }

        [ForeignKey(nameof(Department))]
        public int DepartmentId { get; set; }
        public List<Department>? DepartmentList { get; set; }
    }
}

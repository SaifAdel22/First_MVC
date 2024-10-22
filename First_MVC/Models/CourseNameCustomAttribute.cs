using First_MVC.Models.Entity;
using System.ComponentModel.DataAnnotations;

namespace First_MVC.Models
{
    public class CourseNameCustomAttribute : ValidationAttribute
    {
        //AppDbContext context;
        //public CourseNameCustomAttribute(AppDbContext context) { this.context = context; }
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null) { return null; }
            string newName = value.ToString();

            AppDbContext context = new AppDbContext();

            Course courForm = (Course)validationContext.ObjectInstance;

            Course cour = context.Courses.FirstOrDefault(x => x.Name == newName);
            if (cour != null && cour.Id != courForm.Id)
            {
                return new ValidationResult("This employee name is already taken.");
            }
            return ValidationResult.Success;
            // return base.IsValid(value, validationContext);
        }
    }
}

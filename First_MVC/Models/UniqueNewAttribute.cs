using First_MVC.Models.Entity;
using System.ComponentModel.DataAnnotations;

namespace First_MVC.Models
{
    public class UniqueNewAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null) { return null; }
            string newName = value.ToString();

            AppDbContext context = new AppDbContext();

            Employee empForm = (Employee)validationContext.ObjectInstance;

            Employee emp = context.Employees.FirstOrDefault(x=>x.Name == newName);
            if (emp != null && emp.Id != empForm.Id)
            {
                return new ValidationResult("This employee name is already taken.");
            }
            return ValidationResult.Success;
           // return base.IsValid(value, validationContext);
        }
        //public override string FormatErrorMessage(string name)
        //{
        //    return base.FormatErrorMessage(name);
        //}
    }
}

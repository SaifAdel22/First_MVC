using System.ComponentModel.DataAnnotations;

namespace First_MVC.ViewModel
{
    public class RoleViewModel
    {
        [Display(Name ="Role Name")]
        public string RoleName {  get; set; }

    }
}

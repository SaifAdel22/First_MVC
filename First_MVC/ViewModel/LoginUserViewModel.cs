using System.ComponentModel.DataAnnotations;

namespace First_MVC.ViewModel
{
    public class LoginUserViewModel
    {
        [Required(ErrorMessage ="*")]
        public string UserName { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}

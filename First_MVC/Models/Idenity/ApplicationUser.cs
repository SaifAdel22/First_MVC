using Microsoft.AspNetCore.Identity;

namespace First_MVC.Models.Idenity
{
    public class ApplicationUser : IdentityUser
    {
        public string? Addres {  get; set; }
    }
}
